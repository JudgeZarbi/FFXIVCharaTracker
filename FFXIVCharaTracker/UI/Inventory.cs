using FFXIVClientStructs.FFXIV.Client.Game;
using ImGuiNET;
using Microsoft.EntityFrameworkCore;

namespace FFXIVCharaTracker
{
    internal partial class PluginUI
    {
        private readonly ImGuiListClipperPtr Clipper;


        private string LastInventorySearch = "";
        private List<uint> LastInventorySearchResults = new();

        internal void DrawInventoryTab()
        {
            if (ImGui.BeginTabItem("Inventory"))
            {
                ImGui.Text("Search");
                ImGui.SameLine();
                if (ImGui.InputText("###InventorySearch", ref LastInventorySearch, 100))
                {
                    SearchTimer.Restart();
                }
                if (ImGui.BeginTable("inventory", 2, ImGuiTableFlags.ScrollY))
                {
                    SetUpTableColumns();

                    if (SearchTimer.ElapsedMilliseconds > 1000)
                    {
                        SearchTimer.Reset();
                        if (LastInventorySearch == "")
                        {
                            LastInventorySearchResults = new();
                        }
                        else
                        {
                            LastInventorySearchResults = Plugin.ItemSheet.Where(it => it.Name.ToString().ToLower().Contains(LastInventorySearch.ToLower())).Select(it => it.RowId).ToList();
                        }
                    }

                    var count = 0;
                    if (LastInventorySearchResults.Count == 0)
                    {
                        count = Context.InventorySlots.GroupBy(inv => inv.ItemID).Count();
                    }
                    else
                    {
                        count = Context.InventorySlots.GroupBy(inv => inv.ItemID).Where(inv => LastInventorySearchResults.Contains((uint)(inv.Key & ((1L << 32) - 1)))).Count();
                    }

                    Clipper.Begin(count + 10, 21 * Scale);
                    while (Clipper.Step())
                    {
                        var items = new List<Tuple<ulong, long>>().Select(it => new { ItemID = it.Item1, Quantity = it.Item2 }).ToList();
                        if (LastInventorySearchResults.Count == 0)
                        {
                            items = Context.InventorySlots.GroupBy(inv => inv.ItemID).Skip(Clipper.DisplayStart).Take(Clipper.DisplayEnd - Clipper.DisplayStart).Select(inv => new { ItemID = inv.Key, Quantity = inv.Sum(inv => inv.Quantity) }).AsNoTracking().ToList();
                        }
                        else
                        {
                            items = Context.InventorySlots.Where(inv => LastInventorySearchResults.Contains((uint)(inv.ItemID & ((1L << 32) - 1)))).GroupBy(inv => inv.ItemID).Skip(Clipper.DisplayStart).Take(Clipper.DisplayEnd - Clipper.DisplayStart).Select(inv => new { ItemID = inv.Key, Quantity = inv.Sum(inv => inv.Quantity) }).AsNoTracking().ToList();
                        }

                        foreach (var item in items)
                        {

                            if (item.ItemID == 0 || item.Quantity == 0)
                            {
                                continue;
                            }
                            ImGui.TableNextRow();
                            ImGui.TableNextColumn();

                            if (!Plugin.ItemCache.TryGetValue(item.ItemID, out var itemData))
                            {
                                continue;
                            }
                            if (ImGui.TreeNode(itemData!.Item1.Name))
                            {
                                ImGui.TableNextColumn();
                                ImGui.Text(item.Quantity.ToString());

                                ImGui.Indent();
                                var itemInventories = Context.InventorySlots.Where(inv => inv.ItemID == item.ItemID && inv.Quantity > 0).Include(inv => inv.Retainer).ThenInclude(r => r!.Owner).Include(inv => inv.Chara).AsNoTracking().ToList().OrderBy(inv => inv.Chara?.CharaID ?? inv.Retainer!.Owner.CharaID).ThenBy(inv => inv.Retainer?.RetainerID ?? 0);
                                foreach (var i in itemInventories)
                                {
                                    ImGui.TableNextRow();
                                    ImGui.TableNextColumn();
                                    var text = "";
                                    switch (i.Inventory)
                                    {
                                        case InventoryType.ArmoryBody:
                                        case InventoryType.ArmoryWrist:
                                        case InventoryType.ArmoryEar:
                                        case InventoryType.ArmoryFeets:
                                        case InventoryType.ArmoryHands:
                                        case InventoryType.ArmoryHead:
                                        case InventoryType.ArmoryLegs:
                                        case InventoryType.ArmoryMainHand:
                                        case InventoryType.ArmoryNeck:
                                        case InventoryType.ArmoryOffHand:
                                        case InventoryType.ArmoryRings:
                                            text = $"Armoury Chest ({i.Chara!.Forename} {i.Chara.Surname})";
                                            break;
                                        case InventoryType.Crystals:
                                        case InventoryType.Currency:
                                        case InventoryType.Inventory1:
                                        case InventoryType.Inventory2:
                                        case InventoryType.Inventory3:
                                        case InventoryType.Inventory4:
                                            text = $"Inventory ({i.Chara!.Forename} {i.Chara.Surname})";
                                            break;
                                        case InventoryType.SaddleBag1:
                                        case InventoryType.SaddleBag2:
                                        case InventoryType.PremiumSaddleBag1:
                                        case InventoryType.PremiumSaddleBag2:
                                            text = $"Saddlebag ({i.Chara!.Forename} {i.Chara.Surname})";
                                            break;
                                        case InventoryType.EquippedItems:
                                            text = $"Equipped ({i.Chara!.Forename} {i.Chara.Surname})";
                                            break;
                                        case InventoryType.RetainerCrystals:
                                        case InventoryType.RetainerGil:
                                        case InventoryType.RetainerPage1:
                                        case InventoryType.RetainerPage2:
                                        case InventoryType.RetainerPage3:
                                        case InventoryType.RetainerPage4:
                                        case InventoryType.RetainerPage5:
                                        case InventoryType.RetainerPage6:
                                        case InventoryType.RetainerPage7:
                                            text = $"Inventory - {i.Retainer!.Name} ({i.Retainer.Owner!.Forename} {i.Retainer.Owner!.Surname})";
                                            break;
                                        case InventoryType.RetainerEquippedItems:
                                            text = $"Equipped - {i.Retainer!.Name} ({i.Retainer.Owner!.Forename} {i.Retainer.Owner!.Surname})";
                                            break;
                                        case InventoryType.RetainerMarket:
                                            text = $"Markets - {i.Retainer!.Name} ({i.Retainer.Owner!.Forename} {i.Retainer.Owner!.Surname})";
                                            break;
                                    }
                                    ImGui.Text(text);
                                    ImGui.TableNextColumn();
                                    ImGui.Text(i.Quantity.ToString());
                                }
                                ImGui.Unindent();
                                ImGui.TreePop();
                            }
                            else
                            {
                                ImGui.TableNextColumn();
                                ImGui.Text(item.Quantity.ToString());
                            }
                        }
                    }

                    Clipper.End();
                    ImGui.EndTable();
                }
                ImGui.EndTabItem();
            }

        }
    }
}
