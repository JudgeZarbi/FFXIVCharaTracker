using FFXIVCharaTracker.DB;
using ImGuiNET;
using System.Globalization;
using System.Numerics;

namespace FFXIVCharaTracker
{
    internal partial class PluginUI
    {
        internal void DrawSquadCharacterSection(List<Chara> charas)
        {
            if (ImGui.BeginTabItem("Character"))
            {
                ImGui.Indent();
                if (ImGui.BeginTabBar("squadCharacter"))
                {
                    DrawSquadCharacterGeneralSection(charas);
                    DrawSquadCharacterRetainerSection(charas);
                    ImGui.EndTabBar();
                }
                ImGui.EndTabItem();
            }
        }

        internal void DrawSquadCharacterGeneralSection(List<Chara> charas)
        {
            if (ImGui.BeginTabItem("General"))
            {
                ImGui.Unindent();
                ImGui.Unindent();
                if (ImGui.BeginTable("squadChara", 10, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                {
                    ImGui.TableSetupScrollFreeze(1, 0);

                    ImGui.TableSetupColumn("Name", ImGuiTableColumnFlags.WidthFixed, 200 * Scale);
                    ImGui.TableSetupColumn("Birthday", ImGuiTableColumnFlags.WidthFixed, 100 * Scale);
                    ImGui.TableSetupColumn("Race", ImGuiTableColumnFlags.WidthFixed, 150 * Scale);
                    ImGui.TableSetupColumn("Guardian deity", ImGuiTableColumnFlags.WidthFixed, 150 * Scale);
                    ImGui.TableSetupColumn("Chocobo level", ImGuiTableColumnFlags.WidthFixed, 100 * Scale);
                    ImGui.TableSetupColumn("Race chocobo", ImGuiTableColumnFlags.WidthFixed, 200 * Scale);
                    ImGui.TableSetupColumn("Grand Company rank", ImGuiTableColumnFlags.WidthFixed, 125 * Scale);
                    ImGui.TableSetupColumn("Island Sanctuary", ImGuiTableColumnFlags.WidthFixed, 125 * Scale);
                    ImGui.TableSetupColumn("Retainer storing", ImGuiTableColumnFlags.WidthFixed, 200 * Scale);
                    ImGui.TableSetupColumn("", ImGuiTableColumnFlags.WidthFixed, 100 * Scale);
                    ImGui.TableHeadersRow();

                    var lastAccount = -1;
                    var lastWorld = 0u;

                    foreach (var c in charas)
                    {
                        DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                        SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                        SetCellBackgroundWithText(default, $"{c.BirthDay}/{c.BirthMonth} {GetRealDateFromGameDate(c.BirthDay, c.BirthMonth)}", White);
                        SetCellBackgroundWithText(default, $"{Data.SubRaces[c.Race]} {(c.Race == 0 ? "" : c.Sex == 1 ? "♀" : "♂")}", White);
                        SetCellBackgroundWithText(default, $"{Data.GuardianDeities[c.GuardianDeity]}", White);
                        var chocoLevel = c.ChocoboLevel;
                        SetCellBackgroundWithText(chocoLevel == Data.MaxChocoboLevel ? Green : (chocoLevel > 0 ? Yellow : Red), chocoLevel.ToString(), Black);
                        var raceChocoRank = c.RaceChocoboRank;
                        var raceChocoPedigree = c.RaceChocoboPedigree;
                        SetCellBackgroundWithText(raceChocoRank == Data.MaxRaceChocoboLevel && raceChocoPedigree == 9 ? Green : (raceChocoRank >= 40 ? Blue : (raceChocoRank > 0 ? Yellow : Red)),
                            raceChocoPedigree > 0 ? $"Rank {raceChocoRank} (Pedigree {raceChocoPedigree})" : "Not unlocked/updated!", Black);
                        var gcRank = c.GCRank;
                        SetCellBackgroundWithText(default, GCRankToString[gcRank], gcRank == Data.MaxGCLevel ? Green : (gcRank > 0 ? Yellow : Red));
                        var sanctuaryRank = c.IslandSanctuaryLevel;
                        SetCellBackgroundWithText(default, sanctuaryRank.ToString(), sanctuaryRank == Data.MaxIslandSanctuaryLevel ? Green : (sanctuaryRank > 0 ? Yellow : Red));
                        SetCellBackgroundWithText(default, c.RetainersStoringDescription, White);
                        ImGui.TableNextColumn();
                        if (ImGui.Button($"Delete character##{c.CharaID}"))
                        {
                            Plugin.queuedChanges.Enqueue(() => Plugin.Context.Charas.Remove(c));
                        }
                    }
                    ImGui.EndTable();
                }
                ImGui.EndTabItem();
            }
        }

        internal void DrawSquadCharacterRetainerSection(List<Chara> charas)
        {
            if (ImGui.BeginTabItem("Retainers"))
            {
                ImGui.Unindent();
                ImGui.Unindent();
                var maxRetainerCount = Context.Retainers.GroupBy(r => r.Owner).Select(r => r.Count()).Max();
                if (ImGui.BeginTable("squadChara", 5 * maxRetainerCount, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                {
                    ImGui.TableSetupScrollFreeze(1, 0);
                    for (int i = 1; i <= maxRetainerCount; i++)
                    {
                        ImGui.TableSetupColumn($"Retainer {i} name", ImGuiTableColumnFlags.WidthFixed, 100 * Scale);
                        ImGui.TableSetupColumn($"Retainer {i} class", ImGuiTableColumnFlags.WidthFixed, 100 * Scale);
                        ImGui.TableSetupColumn($"Retainer {i} level", ImGuiTableColumnFlags.WidthFixed, 100 * Scale);
                        ImGui.TableSetupColumn($"Retainer {i} gear", ImGuiTableColumnFlags.WidthFixed, 100 * Scale);
                        ImGui.TableSetupColumn($"Retainer {i} items", ImGuiTableColumnFlags.WidthFixed, 100 * Scale);
                    }
                    ImGui.TableHeadersRow();

                    var lastAccount = -1;
                    var lastWorld = 0u;

                    foreach (var c in charas)
                    {
                        DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                        var nonCombatJobs = new List<uint> { 0, 16, 17, 18 };

                        foreach (var retainer in c.Retainers)
                        {
                            // Calculate the colour here, it's neater
                            Vector4 colour;
                            string count = "";

                            if (nonCombatJobs.Contains(retainer.ClassID))
                            {
                                switch (retainer.ClassID)
                                {
                                    case 16:
                                        if (c.UncollectedMinerItemsSet.Count == Data.RetainerMinerItemIDs.Length)
                                        {
                                            colour = Red;
                                            count = c.UncollectedMinerItemsSet.Count.ToString();
                                        }
                                        else if (c.UncollectedMinerItemsSet.Count > 0)
                                        {
                                            colour = Yellow;
                                            count = c.UncollectedMinerItemsSet.Count.ToString();
                                        }
                                        else
                                        {
                                            colour = Green;
                                        }
                                        break;
                                    case 17:
                                        if (c.UncollectedBotanistItemsSet.Count == Data.RetainerBotanistItemIDs.Length)
                                        {
                                            colour = Red;
                                            count = c.UncollectedBotanistItemsSet.Count.ToString();
                                        }
                                        else if (c.UncollectedBotanistItemsSet.Count > 0)
                                        {
                                            colour = Yellow;
                                            count = c.UncollectedBotanistItemsSet.Count.ToString();
                                        }
                                        else
                                        {
                                            colour = Green;
                                        }
                                        break;
                                    case 18:
                                        if (c.UncollectedFisherItemsSet.Count + c.UncollectedSpearfisherItemsSet.Count == Data.RetainerFisherItemIDs.Length + Data.RetainerSpearfisherItemIDs.Length)
                                        {
                                            colour = Red;
                                            count = (c.UncollectedFisherItemsSet.Count + c.UncollectedSpearfisherItemsSet.Count).ToString();
                                        }
                                        else if (c.UncollectedFisherItemsSet.Count + c.UncollectedSpearfisherItemsSet.Count > 0)
                                        {
                                            colour = Yellow;
                                            count = (c.UncollectedFisherItemsSet.Count + c.UncollectedSpearfisherItemsSet.Count).ToString();
                                        }
                                        else
                                        {
                                            colour = Green;
                                        }
                                        break;
                                    default:
                                        colour = Red;
                                        break;
                                }
                            }
                            else
                            {
                                colour = Green;
                            }

                            SetCellBackgroundWithText(default, retainer.Name, White);
                            SetCellBackgroundWithText(default, CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Plugin.ClassJobs.GetRow(retainer.ClassID)!.Name), White);
                            var level = retainer.Level;
                            SetCellBackgroundWithText(level == Data.MaxLevel ? Green : (level > 0 ? Yellow : Red), level.ToString(), Black);
                            SetCellBackground(retainer.Gear ? Green : Red);
                            SetCellBackgroundWithText(colour, count, Black);
                        }
                    }
                    ImGui.EndTable();
                }
                ImGui.EndTabItem();
            }
        }
    }
}