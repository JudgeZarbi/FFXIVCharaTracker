using Dalamud.Logging;
using FFXIVCharaTracker.DB;
using ImGuiNET;
using Lumina.Excel.GeneratedSheets;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FFXIVCharaTracker
{
    internal partial class PluginUI
    {
        private class CraftingItemData
        {
            public int ItemID;
            public uint RecipeID;
            public string ItemName = "";
            public int QuantityNeeded;
            public int QuantityHave;
            public int SortOrder;
        }

        private readonly Task CraftingTask;
        private bool StopCraftingTask = false;

        private string LastCraftingSearch = "";
        private List<uint> LastCraftingSearchResults = new();

        private ConcurrentDictionary<uint, uint> CurrentRecipeList = new();
        private int CurrentQuantity = 1;
        private string RecipeListName = "";
        private string RecipeListSubcategory = "";
        private int RecipeListIndex = -1;
        private int RecipeMultiplier = 1;
        private RecipeList? LoadedRecipeList;
        private bool CraftingTabOpen = false;
        private volatile List<CraftingItemData> ComponentData = new();
        private volatile List<InventorySlot> SortedInventoryData = new();

        internal void DrawCraftingTab()
        {
            CraftingTabOpen = ImGui.BeginTabItem("Crafting");
            if (CraftingTabOpen)
            {
                ImGui.Text("Search");
                ImGui.SameLine();
                if (ImGui.InputText("###CraftingSearch", ref LastCraftingSearch, 100))
                {
                    SearchTimer.Restart();
                }

                ImGui.InputInt("", ref RecipeMultiplier);

                if (ImGui.Button("Multiply entire list"))
                {
                    if (RecipeMultiplier > 1)
                    {
                        foreach (var item in CurrentRecipeList)
                        {
                            CurrentRecipeList[item.Key] *= (uint)RecipeMultiplier;
                        }
                    }
                }

                if (ImGui.BeginTable("crafting", 2, ImGuiTableFlags.ScrollY))
                {
                    SetUpTableColumns(8f, 2f);

                    if (SearchTimer.ElapsedMilliseconds > 1000)
                    {
                        SearchTimer.Reset();
                        if (LastCraftingSearch == "")
                        {
                            LastCraftingSearchResults = new();
                        }
                        else
                        {
                            LastCraftingSearchResults = Plugin.Recipes.Where(rec => rec.ItemResult.Value!.Name.ToString().ToLower().Contains(LastCraftingSearch.ToLower())).Select(rec => rec.RowId)
                                .Concat(Plugin.CompanyCraftSequences.Where(seq => seq.ResultItem.Value!.Name.ToString().ToLower().Contains(LastCraftingSearch.ToLower())).Select(seq => seq.RowId + 1000000)).ToList();
                        }
                    }

                    ImGui.TableNextRow();
                    ImGui.TableNextColumn();

                    List<RecipeList> recipeLists = new();
                    if (Context.RecipeLists.AsNoTracking().Any())
                    {
                        recipeLists = Context.RecipeLists.OrderBy(list => list.SubcategoryName).AsNoTracking().ToList();
                    }
                    var lastCategory = "";
                    var lastName = RecipeListIndex >= 0 && RecipeListIndex < recipeLists.Count ? recipeLists[RecipeListIndex].Name : "";

                    if (ImGui.BeginCombo($"###RecipeListCombo", lastName))
                    {
                        for (int n = 0; n < recipeLists.Count; n++)
                        {
                            if (lastCategory != recipeLists[n].SubcategoryName)
                            {
                                lastCategory = recipeLists[n].SubcategoryName;
                                if (ImGui.Selectable($"{recipeLists[n].SubcategoryName}", false))
                                {

                                }
                            }

                            var is_selected = (RecipeListIndex == n);

                            if (ImGui.Selectable($"    {recipeLists[n].Name}", is_selected))
                            {
                                RecipeListIndex = n;
                            }

                            // Set the initial focus when opening the combo (scrolling + keyboard navigation focus)
                            if (is_selected)
                            {
                                ImGui.SetItemDefaultFocus();
                            }
                        }
                        ImGui.EndCombo();
                    }
                    ImGui.SameLine();
                    if (ImGui.Button("Load recipe list"))
                    {
                        if (RecipeListIndex >= 0 && RecipeListIndex < recipeLists.Count)
                        {
                            LoadedRecipeList = recipeLists[RecipeListIndex];
                            CurrentRecipeList = new ConcurrentDictionary<uint, uint>(LoadedRecipeList.ListDataDict.ToArray());
                            RecipeListName = LoadedRecipeList.Name;
                            RecipeListSubcategory = LoadedRecipeList.SubcategoryName;
                        }
                    }
                    ImGui.Text("Recipe list name");
                    ImGui.SameLine();
                    ImGui.InputText("###CraftingName", ref RecipeListName, 100);
                    ImGui.Text("Recipe list subcategory");
                    ImGui.SameLine();
                    ImGui.InputText("###CraftingSubcatName", ref RecipeListSubcategory, 100);
                    if (ImGui.Button("Save recipe list"))
                    {
                        RecipeList recipeList;
                        if (LoadedRecipeList != null && RecipeListName == LoadedRecipeList.Name)
                        {
                            recipeList = LoadedRecipeList;
                            var entry = Context.Entry(recipeList);
                            if (entry.State == EntityState.Detached)
                            {
                                Context.Attach(recipeList);
                            }
                            LoadedRecipeList.SubcategoryName = RecipeListSubcategory;
                            LoadedRecipeList.UpdateRecipeList(CurrentRecipeList);
                        }
                        else
                        {
                            recipeList = new RecipeList(RecipeListName, RecipeListSubcategory, CurrentRecipeList);
                            Context.RecipeLists.Add(recipeList);
                        }
                        UIUpdated = true;
                    }
                    if (ImGui.Button("Clear recipe list"))
                    {
                        LoadedRecipeList = null;
                        CurrentRecipeList = new();
                        RecipeListIndex = -1;
                    }


                    foreach (var item in ComponentData)
                    {
                        if (item.SortOrder > 1 << 24)
                        {
                            break;
                        }
                        ImGui.TableNextRow();
                        ImGui.TableNextColumn();
                        ImGui.Text(item.ItemName);
                        ImGui.TableNextColumn();
                        ImGui.Text(item.QuantityHave.ToString() + "/" + item.QuantityNeeded);
                        ImGui.SameLine();
                        if (ImGui.Button($"Delete##{item.RecipeID}"))
                        {
                            CurrentRecipeList.Remove((uint)item.RecipeID, out var _);
                        }
                    }

                    if (LastCraftingSearch != "")
                    {
                        ImGui.TableNextRow();
                        ImGui.TableNextColumn();
                        foreach (var rowId in LastCraftingSearchResults)
                        {
                            try
                            {
                                ImGui.Text(Plugin.RecipeCache[rowId].ItemResult.Value!.Name.ToString());
                            }
                            catch (KeyNotFoundException)
                            {
                                ImGui.Text(Plugin.CompanyCraftSequences.Where(seq => seq.RowId == rowId - 1000000).Single().ResultItem.Value!.Name.ToString());
                            }
                            if (ImGui.Button($"Add to crafting list##{rowId}"))
                            {
                                if (CurrentRecipeList.TryGetValue(rowId, out var quantity))
                                {
                                    CurrentRecipeList[rowId] = quantity + 1;
                                }
                                else
                                {
                                    CurrentRecipeList[rowId] = 1;
                                }
                            }
                            ImGui.InputInt($"###Quantity{rowId}", ref CurrentQuantity);
                            ImGui.SameLine();
                            if (ImGui.Button($"Add quantity to crafting list##{rowId}"))
                            {
                                if (CurrentQuantity > 0)
                                {
                                    if (CurrentRecipeList.TryGetValue(rowId, out var quantity))
                                    {
                                        CurrentRecipeList[rowId] = quantity + (uint)CurrentQuantity;
                                    }
                                    else
                                    {
                                        CurrentRecipeList[rowId] = (uint)CurrentQuantity;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        ImGui.TableNextRow();
                        ImGui.TableNextColumn();

                        ImGui.TableNextRow();
                        ImGui.TableNextColumn();
                        ImGui.Dummy(new Vector2(0, 50));

                        foreach (var item in ComponentData)
                        {
                            ImGui.TableNextRow();
                            ImGui.TableNextColumn();
                            ImGui.TextColored(item.QuantityHave >= item.QuantityNeeded ? Green : White, item.ItemName);
                            ImGui.TableNextColumn();
                            ImGui.Text(item.QuantityHave + "/" + item.QuantityNeeded);
                        }

                        var lastChara = 0uL;
                        var lastRetainer = 0uL;

                        ImGui.Dummy(new Vector2(0, 50));
                        ImGui.Indent();

                        foreach (var slot in SortedInventoryData)
                        {
                            if ((slot.Chara?.CharaID ?? slot.Retainer!.Owner.CharaID) != lastChara ||
                                (slot.Retainer?.RetainerID != null && slot.Retainer.RetainerID != lastRetainer))
                            {
                                lastChara = slot.Chara?.CharaID ?? slot.Retainer!.Owner.CharaID;
                                lastRetainer = slot.Retainer?.RetainerID ?? 0;
                                ImGui.TableNextRow();
                                ImGui.TableNextColumn();
                                if (slot.Retainer != null)
                                {
                                    ImGui.Unindent();
                                    ImGui.Text($"{slot.Retainer!.Name} ({slot.Retainer.Owner!.Forename} {slot.Retainer.Owner!.Surname})");
                                    ImGui.Indent();
                                }
                                else
                                {
                                    ImGui.Unindent();
                                    ImGui.Text($"{slot.Chara!.Forename} {slot.Chara.Surname}");
                                    ImGui.Indent();
                                }
                            }
                            ImGui.TableNextRow();
                            ImGui.TableNextColumn();
                            ImGui.Text($"{Plugin.ItemCache[slot.ItemID].Item1.Name}");
                            ImGui.TableNextColumn();
                            ImGui.Text($"{slot.Quantity}");
                        }
                    }
                    ImGui.EndTable();
                }
                ImGui.EndTabItem();
            }

        }

        private void CraftingThreadTask()
        {
            var context = new CharaContext();

            while (true)
            {
                try
                {
                    if (StopCraftingTask)
                    {
                        context.Dispose();
                        return;
                    }
                    if (!CraftingTabOpen)
                    {
                        Thread.Sleep(1000);
                        continue;
                    }

                    ConcurrentDictionary<int, CraftingItemData> runningComponents = new();
                    foreach (var item in CurrentRecipeList)
                    {
                        if (item.Key > 1000000)
                        {
                            var recipe = Plugin.CompanyCraftSequences.GetRow(item.Key - 1000000);
                            var craftQuantity = item.Value;
                            var itemId = Plugin.ItemIDToSortID[(uint)recipe!.ResultItem.Value!.RowId];
                            runningComponents[(int)itemId] = new CraftingItemData()
                            {
                                ItemID = (int)itemId,
                                RecipeID = item.Key - 1000000,
                                ItemName = Plugin.CompanyCraftSequences.Where(seq => seq.RowId == item.Key - 1000000).Single().ResultItem.Value!.Name.ToString(),
                                QuantityNeeded = (int)item.Value,
                                QuantityHave = context.GetQuantityByItemID(itemId),
                                SortOrder = 0
                            };
                            foreach (var part in recipe!.CompanyCraftPart)
                            {
                                if (part.Value != null)
                                {
                                    AddWorkshopComponentsToDictionary(context, runningComponents, (int)Math.Max(item.Value - runningComponents[(int)item.Key].QuantityHave, 0), part.Value);
                                }
                            }
                        }
                        else
                        {
                            var recipe = Plugin.RecipeCache[item.Key];
                            runningComponents[(int)recipe.ItemResult.Row] = new CraftingItemData()
                            {
                                ItemID = (int)recipe.ItemResult.Row,
                                RecipeID = item.Key,
                                ItemName = Plugin.RecipeCache[item.Key].ItemResult.Value!.Name.ToString(),
                                QuantityNeeded = (int)item.Value,
                                QuantityHave = context.GetQuantityByItemID(Plugin.ItemIDToSortID[(uint)recipe.ItemResult.Value!.RowId]),
                                SortOrder = (int)(recipe.CraftType.Value!.RowId << 16 | recipe.RecipeLevelTable.Row),
                            };
                            var craftQuantity = (int)Math.Ceiling(Math.Max(item.Value - runningComponents[(int)recipe.ItemResult.Row].QuantityHave, 0) / (float)recipe.AmountResult);
                            AddComponentsToDictionary(context, runningComponents, craftQuantity, recipe.UnkData5);
                        }
                    }


                    var components = runningComponents.Values.OrderBy(comp => comp.SortOrder).ToList();

                    List<InventorySlot> inventories = new();
                    foreach (var item in components)
                    {
                        var count = item.QuantityNeeded;
                        var slots = context.GetSlotsByItemID(Plugin.ItemIDToSortID[(uint)item.ItemID]);
                        foreach (var slot in slots)
                        {
                            slot.Quantity = (uint)Math.Min(count, slot.Quantity);
                            count -= (int)slot.Quantity;
                            inventories.Add(slot);
                            if (count == 0)
                            {
                                break;
                            }
                        }
                    }

                    var sortedInventories = inventories.OrderBy(inv => inv.Chara?.CharaID ?? inv.Retainer!.Owner.CharaID).ThenBy(inv => inv.Retainer?.RetainerID ?? 0).ToList();

                    ComponentData = components;
                    SortedInventoryData = sortedInventories;
                }
                catch (Exception e)
                {
                    PluginLog.Error(e, "Crafting task went wrong!");
                }
            }
        }

        private static void AddComponentsToDictionary(CharaContext context, ConcurrentDictionary<int, CraftingItemData> components, int quantity, Recipe.RecipeUnkData5Obj[] ingredientData)
        {
            if (quantity == 0)
            {
                return;
            }
            foreach (var component in ingredientData)
            {
                if (component.ItemIngredient <= 0)
                {
                    continue;
                }
                if (Plugin.ItemIDToRecipe.TryGetValue(component.ItemIngredient, out var recipeData))
                {
                    if (components.TryGetValue(component.ItemIngredient, out var quantityData))
                    {
                        var craftQuantity = Math.Max(Math.Min(quantityData.QuantityNeeded - quantityData.QuantityHave, 0) + (component.AmountIngredient * quantity), 0);
                        craftQuantity = (int)Math.Ceiling(craftQuantity / (float)recipeData.AmountResult);
                        quantityData.QuantityNeeded += quantity * component.AmountIngredient;
                        quantityData.SortOrder = Math.Min(quantityData.SortOrder, (int)(1 << 24 | recipeData.CraftType.Value!.RowId << 16 | recipeData.RecipeLevelTable.Row));
                        AddComponentsToDictionary(context, components, craftQuantity, recipeData.UnkData5);
                    }
                    else
                    {
                        components[component.ItemIngredient] = new CraftingItemData()
                        {
                            ItemID = component.ItemIngredient,
                            RecipeID = recipeData.RowId,
                            ItemName = Plugin.ItemCache[Plugin.ItemIDToSortID[(uint)component.ItemIngredient]].Item1.Name.ToString(),
                            QuantityNeeded = component.AmountIngredient * quantity,
                            QuantityHave = context.GetQuantityByItemID(Plugin.ItemIDToSortID[(uint)component.ItemIngredient]),
                            SortOrder = (int)(1 << 24 | recipeData.CraftType.Value!.RowId << 16 | recipeData.RecipeLevelTable.Row)
                        };
                        quantityData = components[component.ItemIngredient];
                        var craftQuantity = Math.Max(quantityData.QuantityNeeded - quantityData.QuantityHave, 0);
                        craftQuantity = (int)Math.Ceiling(craftQuantity / (float)recipeData.AmountResult);
                        AddComponentsToDictionary(context, components, (int)craftQuantity, recipeData.UnkData5);
                    }
                }
                else
                {
                    if (components.TryGetValue(component.ItemIngredient, out var quantityData))
                    {
                        quantityData.QuantityNeeded += quantity * component.AmountIngredient;
                    }
                    else
                    {
                        components[component.ItemIngredient] = new CraftingItemData()
                        {
                            ItemID = component.ItemIngredient,
                            ItemName = Plugin.ItemCache[Plugin.ItemIDToSortID[(uint)component.ItemIngredient]].Item1.Name.ToString(),
                            QuantityNeeded = component.AmountIngredient * quantity,
                            QuantityHave = context.GetQuantityByItemID(Plugin.ItemIDToSortID[(uint)component.ItemIngredient]),
                            SortOrder = int.MaxValue
                        };
                    }
                }
            }
        }

        private static void AddWorkshopComponentsToDictionary(CharaContext context, ConcurrentDictionary<int, CraftingItemData> components, int quantity, CompanyCraftPart partData)
        {
            if (quantity == 0)
            {
                return;
            }
            foreach (var process in partData.CompanyCraftProcess)
            {
                if (process.Value == null)
                {
                    continue;
                }
                foreach (var partItem in process.Value.UnkData0)
                {
                    if (partItem.SupplyItem == 0)
                    {
                        break;
                    }
                    var item = Plugin.CompanyCraftSupplyItems.Where(sup => partItem.SupplyItem == sup.RowId).Single().Item.Value!;
                    if (Plugin.ItemIDToRecipe.TryGetValue((int)item.RowId, out var recipeData))
                    {
                        if (components.TryGetValue((int)item.RowId, out var quantityData))
                        {
                            var craftQuantity = Math.Max(Math.Min(quantityData.QuantityNeeded - quantityData.QuantityHave, 0) + (partItem.SetQuantity * partItem.SetsRequired * quantity), 0);
                            craftQuantity = (int)Math.Ceiling(craftQuantity / (float)recipeData.AmountResult);
                            quantityData.QuantityNeeded += quantity * partItem.SetQuantity * partItem.SetsRequired;
                            quantityData.SortOrder = Math.Min(quantityData.SortOrder, 0);
                            AddComponentsToDictionary(context, components, craftQuantity, recipeData.UnkData5);
                        }
                        else
                        {
                            components[(int)item.RowId] = new CraftingItemData()
                            {
                                ItemID = (int)item.RowId,
                                RecipeID = recipeData.RowId,
                                ItemName = Plugin.ItemCache[Plugin.ItemIDToSortID[item.RowId]].Item1.Name.ToString(),
                                QuantityNeeded = partItem.SetQuantity * partItem.SetsRequired * quantity,
                                QuantityHave = context.GetQuantityByItemID(Plugin.ItemIDToSortID[(uint)item.RowId]),
                                SortOrder = 0
                            };
                            quantityData = components[(int)item.RowId];
                            var craftQuantity = Math.Max(Math.Min(quantityData.QuantityNeeded - quantityData.QuantityHave, 0) + (partItem.SetQuantity * partItem.SetsRequired * quantity), 0);
                            craftQuantity = (int)Math.Ceiling(craftQuantity / (float)recipeData.AmountResult);
                            AddComponentsToDictionary(context, components, (int)craftQuantity, recipeData.UnkData5);
                        }
                    }
                    else
                    {
                        if (components.TryGetValue((int)item.RowId, out var quantityData))
                        {
                            quantityData.QuantityNeeded += quantity * partItem.SetQuantity * partItem.SetsRequired;
                        }
                        else
                        {
                            components[(int)item.RowId] = new CraftingItemData()
                            {
                                ItemID = (int)item.RowId,
                                ItemName = Plugin.ItemCache[Plugin.ItemIDToSortID[item.RowId]].Item1.Name.ToString(),
                                QuantityNeeded = partItem.SetQuantity * partItem.SetsRequired * quantity,
                                QuantityHave = context.GetQuantityByItemID(Plugin.ItemIDToSortID[(uint)item.RowId]),
                                SortOrder = int.MaxValue
                            };
                        }
                    }
                }
            }
        }

    }
}
