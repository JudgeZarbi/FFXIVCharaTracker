using FFXIVCharaTracker.DB;
using FFXIVClientStructs.FFXIV.Client.Game.UI;
using ImGuiNET;

namespace FFXIVCharaTracker
{
    internal partial class PluginUI
    {
        internal void DrawCharacterSection(Chara charaData)
        {
            if (ImGui.TreeNode($"Character"))
            {
                if (ImGui.BeginTable("tablePersonal", 2))
                {
                    SetUpTableColumns();

                    ImGui.TableNextRow();
                    ImGui.TableNextColumn();
                    var account = charaData.Account;
                    var oldAccount = account;
                    ImGui.AlignTextToFramePadding();
                    ImGui.PushItemWidth(ImGui.GetContentRegionAvail().X);
                    ImGui.Text("Account");
                    ImGui.TableNextColumn();
                    ImGui.PushItemWidth(ImGui.GetContentRegionAvail().X);
                    ImGui.Combo("###Account", ref account, new string[] { "1", "2", "3", "4", "5", "6", "7", "8" }, 8);
                    if (oldAccount != account)
                    {
                        Plugin.queuedChanges.Enqueue(() => charaData.Account = account);
                    }
                    ImGui.TableNextRow();
                    ImGui.TableNextColumn();
                    ImGui.AlignTextToFramePadding();
                    ImGui.Text("Class");
                    ImGui.TableNextColumn();
                    var dropdownID = (int)ClassIDToDropdown[charaData.ClassID];
                    ImGui.Combo("###Class", ref dropdownID, new string[] { "AST", "BLM", "BRD", "DNC", "DRG", "DRK",
                                    "GNB", "MCH", "MNK", "NIN", "PLD", "RDM", "RPR", "SAM", "SCH", "SGE", "SMN", "WAR", "WHM" }, 19);
                    if (charaData.ClassID != DropdownToClassID[(uint)dropdownID])
                    {
                        Plugin.queuedChanges.Enqueue(() => charaData.ClassID = DropdownToClassID[(uint)dropdownID]);
                        unsafe
                        {
                            Plugin.queuedChanges.Enqueue(() => charaData.UpdateLevels(UIState.Instance()));
                        }
                    }

                    DrawTableRowText("Name", true, White, $"{charaData.Forename} {charaData.Surname}");

                    DrawTableRowText("Home World", true, White, Plugin.Worlds.GetRow(charaData.WorldID)!.Name);

                    if (ImGui.Button("Reset character data"))
                    {
                        Plugin.queuedChanges.Enqueue(() => charaData.SetDefaultArrays());
                    }

                    var chocoLevel = charaData.ChocoboLevel;
                    DrawTableRowText("Chocobo level", true, chocoLevel == Data.MaxChocoboLevel ? Green : (chocoLevel > 0 ? Yellow : Red),
                        chocoLevel.ToString());

                    var raceChocoRank = charaData.RaceChocoboRank;
                    var raceChocoPedigree = charaData.RaceChocoboPedigree;
                    DrawTableRowText("Race chocobo", true, raceChocoRank == Data.MaxRaceChocoboLevel && raceChocoPedigree == 9 ? Green : (raceChocoRank >= 40 ? Blue : (raceChocoRank > 0 ? Yellow : Red)),
                        raceChocoPedigree > 0 ? $"Rank {raceChocoRank} (Pedigree {raceChocoPedigree}" : "Not unlocked/updated!");

                    var gcRank = charaData.GCRank;
                    DrawTableRowText("Grand Company rank", true, gcRank == Data.MaxGCLevel ? Green : (gcRank > 0 ? Yellow : Red),
                        GCRankToString[gcRank]);

                    var sanctuaryRank = charaData.IslandSanctuaryLevel;
                    DrawTableRowText("Island Sanctuary rank", true, sanctuaryRank == Data.MaxIslandSanctuaryLevel ? Green : (sanctuaryRank > 0 ? Yellow : Red),
                        sanctuaryRank.ToString());

                    ImGui.EndTable();
                }
                if (ImGui.TreeNode("Retainers"))
                {
                    if (ImGui.BeginTable("tableRetainer", 2))
                    {
                        SetUpTableColumns();

                        ImGui.TableNextRow();
                        ImGui.TableNextColumn();
                        ImGui.Text("Storing");
                        ImGui.TableNextColumn();
                        var input = charaData.RetainersStoringDescription;
                        ImGui.InputText("", ref input, 10000);
                        if (input != charaData.RetainersStoringDescription)
                        {
                            Plugin.queuedChanges.Enqueue(() => charaData.RetainersStoringDescription = input);
                        }
                        ImGui.EndTable();
                    }
                    foreach (var r in charaData.Retainers)
                    {
                        if (ImGui.TreeNode(r.Name))
                        {
                            if (ImGui.BeginTable($"tableRetainer{r.RetainerID}", 2))
                            {
                                SetUpTableColumns();

                                var level = r.Level;
                                DrawTableRowText("Level", true, level == Data.MaxLevel ? Green : (level > 0 ? Yellow : Red),
                                    level.ToString());

                                DrawTableRowText("Gear", r.Gear, null);

                                ImGui.EndTable();
                            }
                            ImGui.TreePop();
                        }
                    }
                    if (ImGui.TreeNode("Missing retainer items"))
                    {
                        if (ImGui.TreeNode("Miner"))
                        {
                            foreach (var item in charaData.GetMissingMinerItems())
                            {
                                ImGui.Text(item);
                            }
                            ImGui.TreePop();
                        }
                        if (ImGui.TreeNode("Botanist"))
                        {
                            foreach (var item in charaData.GetMissingBotanistItems())
                            {
                                ImGui.Text(item);
                            }
                            ImGui.TreePop();
                        }
                        if (ImGui.TreeNode("Fisher"))
                        {
                            foreach (var item in charaData.GetMissingFisherItems())
                            {
                                ImGui.Text(item);
                            }
                            ImGui.TreePop();
                        }
                        ImGui.TreePop();
                    }
                    ImGui.TreePop();
                }
                ImGui.TreePop();
            }
        }
    }
}
