using FFXIVCharaTracker.DB;
using ImGuiNET;

namespace FFXIVCharaTracker
{
    internal partial class PluginUI
    {
        internal void DrawDoLDoHSection(Chara charaData)
        {
            if (ImGui.TreeNode("DoH/DoL"))
            {
                if (ImGui.BeginTable("tableDoHDoL", 2))
                {
                    SetUpTableColumns();

                    var level = charaData.LevelCrp;
                    DrawTableRowText("CRP", true, level == Data.MaxLevel ? Green : (level > 0 ? Yellow : Red),
                        level.ToString());

                    level = charaData.LevelBsm;
                    DrawTableRowText("BSM", true, level == Data.MaxLevel ? Green : (level > 0 ? Yellow : Red),
                        level.ToString());

                    level = charaData.LevelArm;
                    DrawTableRowText("ARM", true, level == Data.MaxLevel ? Green : (level > 0 ? Yellow : Red),
                        level.ToString());

                    level = charaData.LevelGsm;
                    DrawTableRowText("GSM", true, level == Data.MaxLevel ? Green : (level > 0 ? Yellow : Red),
                        level.ToString());

                    level = charaData.LevelLtw;
                    DrawTableRowText("LTW", true, level == Data.MaxLevel ? Green : (level > 0 ? Yellow : Red),
                        level.ToString());

                    level = charaData.LevelWvr;
                    DrawTableRowText("WVR", true, level == Data.MaxLevel ? Green : (level > 0 ? Yellow : Red),
                        level.ToString());

                    level = charaData.LevelAlc;
                    DrawTableRowText("ALC", true, level == Data.MaxLevel ? Green : (level > 0 ? Yellow : Red),
                        level.ToString());

                    level = charaData.LevelCul;
                    DrawTableRowText("CUL", true, level == Data.MaxLevel ? Green : (level > 0 ? Yellow : Red),
                        level.ToString());

                    level = charaData.LevelMin;
                    DrawTableRowText("MIN", true, level == Data.MaxLevel ? Green : (level > 0 ? Yellow : Red),
                        level.ToString());

                    level = charaData.LevelBtn;
                    DrawTableRowText("BTN", true, level == Data.MaxLevel ? Green : (level > 0 ? Yellow : Red),
                        level.ToString());

                    level = charaData.LevelFsh;
                    DrawTableRowText("FSH", true, level == Data.MaxLevel ? Green : (level > 0 ? Yellow : Red),
                        level.ToString());

                    var colour = White;
                    var text = "";
                    if (charaData.LevelCrp >= 80 && charaData.LevelBsm >= 80 &&
                        charaData.LevelArm >= 80 && charaData.LevelGsm >= 80 &&
                        charaData.LevelLtw >= 80 && charaData.LevelWvr >= 80 &&
                        charaData.LevelAlc >= 80 && charaData.LevelCul >= 80 &&
                        charaData.LevelMin >= 80 && charaData.LevelBtn >= 80)
                    {
                        colour = Green;
                        text = "Complete!";
                    }
                    else if (charaData.LevelCrp >= 10 && charaData.LevelBsm >= 10 &&
                        charaData.LevelArm >= 10 && charaData.LevelGsm >= 10 &&
                        charaData.LevelLtw >= 10 && charaData.LevelWvr >= 10 &&
                        charaData.LevelAlc >= 10 && charaData.LevelCul >= 10 &&
                        charaData.LevelMin >= 10 && charaData.LevelBtn >= 10 &&
                        charaData.IsQuestComplete(69208))
                    {
                        colour = Yellow;
                        text = "Available and incomplete!";
                    }
                    else
                    {
                        colour = Red;
                        text = "Unavailable!";
                    }
                    DrawTableRowText("Ishgardian Restoration", true, colour, text);

                    var missingCrafterQuests = charaData.GetMissingCrafterQuests();

                    colour = missingCrafterQuests.Count == 8 ? Green :
                        (missingCrafterQuests.Count == 0 ? Red : Yellow);
                    text = missingCrafterQuests.Count == 8 ? "Complete!" :
                        (missingCrafterQuests.Count == 0 ? "None complete!" :
                        "Missing: " + String.Join(", ", missingCrafterQuests));

                    DrawTableRowText("Crafter quests", true, colour, text);

                    colour = charaData.IncompleteSecretRecipeBooksSet.Count == Data.RecipeBookIDs.Length ? Red :
                        (charaData.IncompleteSecretRecipeBooksSet.Count == 0 ? Green : Yellow);
                    text = charaData.IncompleteSecretRecipeBooksSet.Count == Data.RecipeBookIDs.Length ? "None!" :
                        (charaData.IncompleteSecretRecipeBooksSet.Count == 0 ? "Complete!" :
                        "Missing:\n" + String.Join("\n", charaData.IncompleteSecretRecipeBooksSet.Select(i => Plugin.SecretRecipeBooks.GetRow(i)!.Name)));

                    DrawTableRowText("Secret recipe books", true, colour, text);

                    DrawTableRowText("Gathering gear", charaData.GatherGear);

                    var missingGathererQuests = charaData.GetMissingGathererQuests();
                    colour = missingGathererQuests.Count == 3 ? Green :
                        (missingGathererQuests.Count == 0 ? Red : Yellow);
                    text = missingGathererQuests.Count == 3 ? "Complete!" :
                        (missingGathererQuests.Count == 0 ? "None complete!" :
                        "Missing: " + String.Join(", ", missingGathererQuests));


                    DrawTableRowText("Gatherer quests", true, colour, text);

                    colour = charaData.IncompleteFolkloreBooksSet.Count == Data.FolkloreIDs.Length ? Red :
                        (charaData.IncompleteFolkloreBooksSet.Count == 0 ? Green : Yellow);
                    text = charaData.IncompleteFolkloreBooksSet.Count == Data.FolkloreIDs.Length ? "None!" :
                        (charaData.IncompleteFolkloreBooksSet.Count == 0 ? "Complete!" :
                        "Missing:\n" + String.Join("\n", charaData.IncompleteFolkloreBooksSet.Select(i => Plugin.ItemSheet.GetRow(i)!.Name)));

                    DrawTableRowText("Folklore books", true, colour, text);

                    ImGui.EndTable();
                }
                if (ImGui.TreeNode("Custom Deliveries"))
                {
                    if (ImGui.BeginTable("tableSatisfaction", 2))
                    {
                        SetUpTableColumns();

                        for (int i = 1; i < Plugin.SatisfactionNpcs.RowCount; i++)
                        {
                            var locked = charaData.LockedCustomDeliveriesSet.Contains(Plugin.SatisfactionNpcs.GetRow((uint)i)!.Npc.Value!.RowId);
                            DrawTableRowText(Plugin.SatisfactionNpcs.GetRow((uint)i)!.Npc.Value!.Singular, true,
                                locked ? Red : (charaData.CustomDeliveryRanksSet[i - 1] == Data.MaxCustomDeliveryRank) ? Green : Yellow,
                                locked ? "Locked" : $"Rank {charaData.CustomDeliveryRanksSet[i - 1]}");
                        }
                        ImGui.EndTable();
                    }
                    ImGui.TreePop();
                }
                ImGui.TreePop();
            }

        }
    }
}
