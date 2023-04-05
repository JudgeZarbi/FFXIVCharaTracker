using FFXIVCharaTracker.DB;
using ImGuiNET;
using System.Numerics;

namespace FFXIVCharaTracker
{
    internal partial class PluginUI
    {
        internal void DrawSquadDoHDoLSection(List<Chara> charas)
        {
            if (ImGui.BeginTabItem("DoH/DoL"))
            {
                ImGui.Unindent();

                if (ImGui.BeginTable("squadDoHDoL", 28, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                {
                    ImGui.TableSetupScrollFreeze(1, 0);

                    ImGui.TableSetupColumn("Name", ImGuiTableColumnFlags.WidthFixed, 200 * Scale);
                    ImGui.TableSetupColumn("Carpenter", ImGuiTableColumnFlags.WidthFixed, 125 * Scale);
                    ImGui.TableSetupColumn("Blacksmith", ImGuiTableColumnFlags.WidthFixed, 125 * Scale);
                    ImGui.TableSetupColumn("Armourer", ImGuiTableColumnFlags.WidthFixed, 125 * Scale);
                    ImGui.TableSetupColumn("Goldsmith", ImGuiTableColumnFlags.WidthFixed, 125 * Scale);
                    ImGui.TableSetupColumn("Leatherworker", ImGuiTableColumnFlags.WidthFixed, 125 * Scale);
                    ImGui.TableSetupColumn("Weaver", ImGuiTableColumnFlags.WidthFixed, 125 * Scale);
                    ImGui.TableSetupColumn("Alchemist", ImGuiTableColumnFlags.WidthFixed, 125 * Scale);
                    ImGui.TableSetupColumn("Culinarian", ImGuiTableColumnFlags.WidthFixed, 125 * Scale);
                    ImGui.TableSetupColumn("Miner", ImGuiTableColumnFlags.WidthFixed, 100 * Scale);
                    ImGui.TableSetupColumn("Botanist", ImGuiTableColumnFlags.WidthFixed, 100 * Scale);
                    ImGui.TableSetupColumn("Fisher", ImGuiTableColumnFlags.WidthFixed, 100 * Scale);
                    ImGui.TableSetupColumn("Ishgardian restoration", ImGuiTableColumnFlags.WidthFixed, 150 * Scale);
                    ImGui.TableSetupColumn("Crafter quests", ImGuiTableColumnFlags.WidthFixed, 100 * Scale);
                    ImGui.TableSetupColumn("Recipe books", ImGuiTableColumnFlags.WidthFixed, 100 * Scale);
                    ImGui.TableSetupColumn("Gathering gear", ImGuiTableColumnFlags.WidthFixed, 100 * Scale);
                    ImGui.TableSetupColumn("Gatherer quests", ImGuiTableColumnFlags.WidthFixed, 100 * Scale);
                    ImGui.TableSetupColumn("Folklore books", ImGuiTableColumnFlags.WidthFixed, 100 * Scale);
                    for (int i = 1; i < Plugin.SatisfactionNpcs.RowCount; i++)
                    {
                        ImGui.TableSetupColumn($"Delivery - {Plugin.SatisfactionNpcs.GetRow((uint)i)!.Npc.Value!.Singular}", ImGuiTableColumnFlags.WidthFixed, 150 * Scale);
                    }
                    ImGui.TableHeadersRow();

                    var lastAccount = -1;
                    var lastWorld = 0u;

                    foreach (var c in charas)
                    {
                        DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                        SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                        var level = c.LevelCrp;
                        var desynthLevel = c.DesynthesisLevelCrp;
                        SetCellBackgroundWithText(level == Data.MaxLevel ? Green : (level > 0 ? Yellow : Red), $"{level} (Desynth: {(desynthLevel == Data.MaxDesynthLevel ? "MAX" : desynthLevel)})", Black);
                        level = c.LevelBsm;
                        desynthLevel = c.DesynthesisLevelBsm;
                        SetCellBackgroundWithText(level == Data.MaxLevel ? Green : (level > 0 ? Yellow : Red), $"{level} (Desynth: {(desynthLevel == Data.MaxDesynthLevel ? "MAX" : desynthLevel)})", Black);
                        level = c.LevelArm;
                        desynthLevel = c.DesynthesisLevelArm;
                        SetCellBackgroundWithText(level == Data.MaxLevel ? Green : (level > 0 ? Yellow : Red), $"{level} (Desynth: {(desynthLevel == Data.MaxDesynthLevel ? "MAX" : desynthLevel)})", Black);
                        level = c.LevelGsm;
                        desynthLevel = c.DesynthesisLevelGsm;
                        SetCellBackgroundWithText(level == Data.MaxLevel ? Green : (level > 0 ? Yellow : Red), $"{level} (Desynth: {(desynthLevel == Data.MaxDesynthLevel ? "MAX" : desynthLevel)})", Black);
                        level = c.LevelLtw;
                        desynthLevel = c.DesynthesisLevelLtw;
                        SetCellBackgroundWithText(level == Data.MaxLevel ? Green : (level > 0 ? Yellow : Red), $"{level} (Desynth: {(desynthLevel == Data.MaxDesynthLevel ? "MAX" : desynthLevel)})", Black);
                        level = c.LevelWvr;
                        desynthLevel = c.DesynthesisLevelWvr;
                        SetCellBackgroundWithText(level == Data.MaxLevel ? Green : (level > 0 ? Yellow : Red), $"{level} (Desynth: {(desynthLevel == Data.MaxDesynthLevel ? "MAX" : desynthLevel)})", Black);
                        level = c.LevelAlc;
                        desynthLevel = c.DesynthesisLevelAlc;
                        SetCellBackgroundWithText(level == Data.MaxLevel ? Green : (level > 0 ? Yellow : Red), $"{level} (Desynth: {(desynthLevel == Data.MaxDesynthLevel ? "MAX" : desynthLevel)})", Black);
                        level = c.LevelCul;
                        desynthLevel = c.DesynthesisLevelCul;
                        SetCellBackgroundWithText(level == Data.MaxLevel ? Green : (level > 0 ? Yellow : Red), $"{level} (Desynth: {(desynthLevel == Data.MaxDesynthLevel ? "MAX" : desynthLevel)})", Black);
                        level = c.LevelMin;
                        SetCellBackgroundWithText(level == Data.MaxLevel ? Green : (level > 0 ? Yellow : Red), level.ToString(), Black);
                        level = c.LevelBtn;
                        SetCellBackgroundWithText(level == Data.MaxLevel ? Green : (level > 0 ? Yellow : Red), level.ToString(), Black);
                        level = c.LevelFsh;
                        SetCellBackgroundWithText(level == Data.MaxLevel ? Green : (level > 0 ? Yellow : Red), level.ToString(), Black);
                        Vector4 colour = default;
                        if (c.LevelCrp >= 80 && c.LevelBsm >= 80 &&
                            c.LevelArm >= 80 && c.LevelGsm >= 80 &&
                            c.LevelLtw >= 80 && c.LevelWvr >= 80 &&
                            c.LevelAlc >= 80 && c.LevelCul >= 80 &&
                            c.LevelMin >= 80 && c.LevelBtn >= 80)
                        {
                            colour = Green;
                        }
                        else if (c.LevelCrp >= 10 && c.LevelBsm >= 10 &&
                            c.LevelArm >= 10 && c.LevelGsm >= 10 &&
                            c.LevelLtw >= 10 && c.LevelWvr >= 10 &&
                            c.LevelAlc >= 10 && c.LevelCul >= 10 &&
                            c.LevelMin >= 10 && c.LevelBtn >= 10 &&
                            c.IsQuestComplete(69208))
                        {
                            colour = Yellow;
                        }
                        else
                        {
                            colour = Red;
                        }
                        SetCellBackground(colour);

                        var missingCrafterQuests = c.GetMissingCrafterQuests();
                        SetCellBackgroundWithText(missingCrafterQuests.Count == 8 ? Red : (missingCrafterQuests.Count == 0 ? Green : Yellow), string.Join(", ", missingCrafterQuests));

                        SetCellBackgroundWithText(c.IncompleteSecretRecipeBooksSet.Count == Data.RecipeBookIDs.Length ? Red : (c.IncompleteSecretRecipeBooksSet.Count == 0 ? Green : Yellow), c.IncompleteSecretRecipeBooksSet.Count > 0 && c.IncompleteSecretRecipeBooksSet.Count < Data.RecipeBookIDs.Length ? c.IncompleteSecretRecipeBooksSet.Count.ToString() : "", Black);

                        SetCellBackground(c.GatherGear ? Green : Red);

                        var missingGathererQuests = c.GetMissingGathererQuests();
                        SetCellBackgroundWithText(missingGathererQuests.Count == 3 ? Red : (missingGathererQuests.Count == 0 ? Green : Yellow), string.Join(", ", missingGathererQuests));

                        SetCellBackgroundWithText(c.IncompleteFolkloreBooksSet.Count == Data.FolkloreIDs.Length ? Red : (c.IncompleteFolkloreBooksSet.Count == 0 ? Green : Yellow), c.IncompleteFolkloreBooksSet.Count > 0 && c.IncompleteFolkloreBooksSet.Count < Data.FolkloreIDs.Length ? c.IncompleteFolkloreBooksSet.Count.ToString() : "", Black);


                        for (int i = 1; i < Plugin.SatisfactionNpcs.RowCount; i++)
                        {
                            var locked = c.LockedCustomDeliveriesSet.Contains(Plugin.SatisfactionNpcs.GetRow((uint)i)!.Npc.Value!.RowId);
                            SetCellBackgroundWithText(locked ? Red : (c.CustomDeliveryRanksList[i - 1] == Data.MaxCustomDeliveryRank) ? Green : Yellow, locked ? "Locked" : $"Rank {c.CustomDeliveryRanksList[i - 1]}", Black);
                        }
                    }
                    ImGui.EndTable();
                }
                ImGui.EndTabItem();
            }

        }
    }
}
