﻿using FFXIVCharaTracker.DB;
using ImGuiNET;

namespace FFXIVCharaTracker
{
    internal partial class PluginUI
    {
        internal void DrawSquadOptionalSection(List<Chara> charas)
        {
            if (ImGui.BeginTabItem("Optional Content"))
            {
                ImGui.Indent();

                var lastAccount = -1;
                var lastWorld = 0u;

                if (ImGui.BeginTabBar("squadOptionalContent"))
                {
                    if (ImGui.BeginTabItem("General"))
                    {
                        if (ImGui.BeginTabBar("squadOptionalContentTypes"))
                        {
                            if (ImGui.BeginTabItem("Housing"))
                            {
                                ImGui.Unindent();
                                ImGui.Unindent();
                                ImGui.Unindent();

                                if (ImGui.BeginTable("squadoptionalGeneralHousing", SquadOptionalHousingStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                                {
                                    SetUpSquadTableHeaders(0, SquadOptionalHousingStrings);

                                    foreach (var c in charas)
                                    {
                                        DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                        SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                        SetCellBackground(c.IsQuestComplete(66750) ? Green : Red);
                                        SetCellBackground(c.IsQuestComplete(66748) ? Green : Red);
                                        SetCellBackground(c.IsQuestComplete(66749) ? Green : Red);
                                        SetCellBackground(c.IsQuestComplete(68167) ? Green : Red);
                                        SetCellBackground(c.IsQuestComplete(69708) ? Green : Red);
                                    }
                                    ImGui.EndTable();
                                }
                                ImGui.EndTabItem();
                            }
                            if (ImGui.BeginTabItem("Materia"))
                            {
                                ImGui.Unindent();
                                ImGui.Unindent();
                                ImGui.Unindent();

                                if (ImGui.BeginTable("squadoptionalGeneralMateria", SquadOptionalGeneralMateriaStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                                {
                                    SetUpSquadTableHeaders(0, SquadOptionalGeneralMateriaStrings);

                                    foreach (var c in charas)
                                    {
                                        DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                        SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                        SetCellBackground(c.IsQuestComplete(66174) ? Green : Red);
                                        SetCellBackground(c.IsQuestComplete(66175) ? Green : Red);
                                        SetCellBackground(c.IsQuestComplete(66176) ? Green : Red);
                                    }
                                    ImGui.EndTable();
                                }
                                ImGui.EndTabItem();
                            }
                            if (ImGui.BeginTabItem("Appearance"))
                            {
                                ImGui.Unindent();
                                ImGui.Unindent();
                                ImGui.Unindent();

                                if (ImGui.BeginTable("squadoptionalGeneralAppearance", SquadOptionalGeneralAppearanceStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                                {
                                    SetUpSquadTableHeaders(0, SquadOptionalGeneralAppearanceStrings);

                                    foreach (var c in charas)
                                    {
                                        DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                        SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                        SetCellBackground(c.IsQuestComplete(66235) ? Green : Red);
                                        SetCellBackground(c.IsQuestComplete(68553) ? Green : Red);
                                        SetCellBackground(c.IsQuestComplete(67896) ? Green : Red);
                                        SetCellBackground(c.IsQuestComplete(66746) ? Green : Red);
                                    }
                                    ImGui.EndTable();
                                }
                                ImGui.EndTabItem();
                            }
                            if (ImGui.BeginTabItem("Zones"))
                            {
                                ImGui.Unindent();
                                ImGui.Unindent();
                                ImGui.Unindent();

                                if (ImGui.BeginTable("squadoptionalGeneralZones", SquadOptionalGeneralZonesStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                                {
                                    SetUpSquadTableHeaders(0, SquadOptionalGeneralZonesStrings);

                                    foreach (var c in charas)
                                    {
                                        DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                        SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                        SetCellBackground(c.IsQuestComplete(65970) ? Green : Red);
                                        SetCellBackground(c.IsQuestComplete(66338) ? Green : Red);
                                    }
                                    ImGui.EndTable();
                                }
                                ImGui.EndTabItem();
                            }
                            if (ImGui.BeginTabItem("PvP"))
                            {
                                ImGui.Unindent();
                                ImGui.Unindent();
                                ImGui.Unindent();

                                if (ImGui.BeginTable("squadoptionalGeneralPvP", SquadOptionalGeneralPvPStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                                {
                                    SetUpSquadTableHeaders(0, SquadOptionalGeneralPvPStrings);

                                    foreach (var c in charas)
                                    {
                                        DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                        SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                        SetCellBackground(c.IsQuestComplete(66640) || c.IsQuestComplete(66641) || c.IsQuestComplete(66642) ? Green : Red);
                                        SetCellBackground(c.IsQuestComplete(67063) || c.IsQuestComplete(67064) || c.IsQuestComplete(67065) ? Green : Red);
                                        SetCellBackground(c.IsQuestComplete(68583) ? Green : Red);
                                    }
                                    ImGui.EndTable();
                                }
                                ImGui.EndTabItem();
                            }
                            if (ImGui.BeginTabItem("Hunt"))
                            {
                                if (ImGui.BeginTable("squadoptionalGeneralHunt", SquadOptionalGeneralHuntStrings.Length + 1))
                                {
                                    SetUpSquadTableHeaders(0, SquadOptionalGeneralHuntStrings);

                                    foreach (var c in charas)
                                    {
                                        DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                        SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                        SetCellBackground(c.IsQuestComplete(67099) || c.IsQuestComplete(67100) || c.IsQuestComplete(67101) ? Green : Red);
                                        SetCellBackground(c.IsQuestComplete(67655) ? Green : Red);
                                        SetCellBackground(c.IsQuestComplete(67656) ? Green : Red);
                                        SetCellBackground(c.IsQuestComplete(67657) ? Green : Red);
                                        SetCellBackground(c.IsQuestComplete(67658) ? Green : Red);
                                        SetCellBackground(c.IsQuestComplete(68472) ? Green : Red);
                                        SetCellBackground(c.IsQuestComplete(68473) ? Green : Red);
                                        SetCellBackground(c.IsQuestComplete(68474) ? Green : Red);
                                        SetCellBackground(c.IsQuestComplete(68475) ? Green : Red);
                                        SetCellBackground(c.IsQuestComplete(69133) ? Green : Red);
                                        SetCellBackground(c.IsQuestComplete(69134) ? Green : Red);
                                        SetCellBackground(c.IsQuestComplete(69135) ? Green : Red);
                                        SetCellBackground(c.IsQuestComplete(69136) ? Green : Red);
                                        SetCellBackground(c.IsQuestComplete(69712) ? Green : Red);
                                        SetCellBackground(c.IsQuestComplete(69713) ? Green : Red);
                                        SetCellBackground(c.IsQuestComplete(69714) ? Green : Red);
                                        SetCellBackground(c.IsQuestComplete(69715) ? Green : Red);
                                    }

                                    ImGui.EndTable();
                                }
                                ImGui.EndTabItem();
                            }
                            if (ImGui.BeginTabItem("Tribes"))
                            {
                                if (ImGui.BeginTable("squadoptionalGeneralTribes", SquadOptionalGeneralTribesStrings.Length + 1))
                                {
                                    SetUpSquadTableHeaders(0, SquadOptionalGeneralTribesStrings);

                                    foreach (var c in charas)
                                    {
                                        DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                        SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                        SetCellBackgroundWithText(GetBeastTribeColour(c, 0), $"Rank {c.BeastTribeRanksList[0]}", Black);
                                        SetCellBackgroundWithText(GetBeastTribeColour(c, 1), $"Rank {c.BeastTribeRanksList[1]}", Black);
                                        SetCellBackgroundWithText(GetBeastTribeColour(c, 2), $"Rank {c.BeastTribeRanksList[2]}", Black);
                                        SetCellBackgroundWithText(GetBeastTribeColour(c, 3), $"Rank {c.BeastTribeRanksList[3]}", Black);
                                        SetCellBackgroundWithText(GetBeastTribeColour(c, 4), $"Rank {c.BeastTribeRanksList[4]}", Black);
                                        SetCellBackgroundWithText(GetBeastTribeColour(c, 5), $"Rank {c.BeastTribeRanksList[5]}", Black);
                                        SetCellBackgroundWithText(GetBeastTribeColour(c, 6), $"Rank {c.BeastTribeRanksList[6]}", Black);
                                        SetCellBackgroundWithText(GetBeastTribeColour(c, 7), $"Rank {c.BeastTribeRanksList[7]}", Black);
                                        SetCellBackgroundWithText(GetBeastTribeColour(c, 8), $"Rank {c.BeastTribeRanksList[8]}", Black);
                                        SetCellBackgroundWithText(GetBeastTribeColour(c, 9), $"Rank {c.BeastTribeRanksList[9]}", Black);
                                        SetCellBackgroundWithText(GetBeastTribeColour(c, 10), $"Rank {c.BeastTribeRanksList[10]}", Black);
                                        SetCellBackgroundWithText(GetBeastTribeColour(c, 11), $"Rank {c.BeastTribeRanksList[11]}", Black);
                                        SetCellBackgroundWithText(GetBeastTribeColour(c, 12), $"Rank {c.BeastTribeRanksList[12]}", Black);
                                        SetCellBackgroundWithText(GetBeastTribeColour(c, 13), $"Rank {c.BeastTribeRanksList[13]}", Black);
                                        SetCellBackgroundWithText(GetBeastTribeColour(c, 14), $"Rank {c.BeastTribeRanksList[14]}", Black);
                                        SetCellBackgroundWithText(GetBeastTribeColour(c, 15), $"Rank {c.BeastTribeRanksList[15]}", Black);
                                        SetCellBackgroundWithText(GetBeastTribeColour(c, 16), $"Rank {c.BeastTribeRanksList[16]}", Black);
                                    }
                                    ImGui.EndTable();
                                }
                                ImGui.EndTabItem();
                            }
                            if (ImGui.BeginTabItem("Collectables"))
                            {
                                if (ImGui.BeginTable("squadoptionalGeneralCollectables", SquadOptionalGeneralCollectablesStrings.Length + 1))
                                {
                                    SetUpSquadTableHeaders(0, SquadOptionalGeneralCollectablesStrings);

                                    foreach (var c in charas)
                                    {
                                        DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                        SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                        SetCellBackground(c.IsQuestComplete(67631) ? Green : Red);
                                        SetCellBackground(c.IsQuestComplete(67634) ? Green : Red);
                                        SetCellBackground(c.IsQuestComplete(68477) ? Green : Red);
                                        SetCellBackground(c.IsQuestComplete(69139) ? Green : Red);
                                        SetCellBackground(c.IsQuestComplete(69711) ? Green : Red);
                                        SetCellBackground(c.IsQuestComplete(67633) ? Green : Red);
                                    }
                                    ImGui.EndTable();
                                }
                                ImGui.EndTabItem();
                            }
                            if (ImGui.BeginTabItem("Sightseeing Log"))
                            {
                                if (ImGui.BeginTable("squadoptionalGeneralSightseeing", SquadOptionalGeneralSightseeingStrings.Length + 1))
                                {
                                    SetUpSquadTableHeaders(0, SquadOptionalGeneralSightseeingStrings);

                                    foreach (var c in charas)
                                    {
                                        DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                        SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                        SetCellBackground(c.IsQuestComplete(65698) ? Green : Red);
                                        SetCellBackground(c.IsQuestComplete(67643) ? Green : Red);
                                        SetCellBackground(c.IsQuestComplete(68456) ? Green : Red);
                                        SetCellBackground(c.IsQuestComplete(69140) ? Green : Red);
                                        SetCellBackground(c.IsQuestComplete(69710) ? Green : Red);
                                    }
                                    ImGui.EndTable();
                                }
                                ImGui.EndTabItem();
                            }
                            if (ImGui.TreeNode("Stone, Sea, Sky"))
                            {
                                if (ImGui.BeginTable("squadoptionalGeneralDummies", SquadOptionalGeneralDummiesStrings.Length + 1))
                                {
                                    SetUpSquadTableHeaders(0, SquadOptionalGeneralDummiesStrings);

                                    foreach (var c in charas)
                                    {
                                        DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                        SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                        SetCellBackground(c.IsQuestComplete(67654) ? Green : Red);
                                        SetCellBackground(c.IsQuestComplete(68476) ? Green : Red);
                                        SetCellBackground(c.IsQuestComplete(69137) ? Green : Red);
                                        SetCellBackground(c.IsQuestComplete(69709) ? Green : Red);
                                    }
                                    ImGui.EndTable();
                                }
                                ImGui.TreePop();
                            }
                            if (ImGui.BeginTabItem("Other"))
                            {
                                ImGui.Unindent();
                                ImGui.Unindent();
                                ImGui.Unindent();

                                if (ImGui.BeginTable("squadoptionalGeneralOther", SquadOptionalGeneralOtherStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                                {
                                    SetUpSquadTableHeaders(0, SquadOptionalGeneralOtherStrings);

                                    foreach (var c in charas)
                                    {
                                        DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                        SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                        SetCellBackground(c.IsQuestComplete(66968) || c.IsQuestComplete(66969) || c.IsQuestComplete(66970) ? Green : Red);
                                        SetCellBackground(c.IsQuestComplete(65688) ? Green : Red);
                                        SetCellBackground(c.IsQuestComplete(66698) ? Green : Red);
                                        SetCellBackground(c.IsQuestComplete(67096) ? Green : Red);
                                        SetCellBackground(c.IsQuestComplete(66747) ? Green : Red);
                                        SetCellBackground(c.IsQuestComplete(66959) ? Green : Red);
                                        SetCellBackground(c.IsQuestComplete(66967) ? Green : Red);
                                        SetCellBackground(c.IsQuestComplete(67928) ? Green : Red);
                                        SetCellBackground(c.IsQuestComplete(69501) ? Green : Red);
                                    }
                                    ImGui.EndTable();
                                }
                                ImGui.EndTabItem();
                            }
                            ImGui.EndTabBar();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("A Realm Reborn"))
                    {
                        ImGui.Indent();
                        if (ImGui.BeginTabBar("squadARealmReborn"))
                        {
                            if (ImGui.BeginTabItem("Dungeons"))
                            {
                                ImGui.Unindent();
                                ImGui.Unindent();
                                ImGui.Unindent();

                                if (ImGui.BeginTable("squadDungeonsArr", SquadDungeonsArrStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                                {
                                    SetUpSquadTableHeaders(0, SquadDungeonsArrStrings);

                                    foreach (var c in charas)
                                    {
                                        DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                        SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                        SetCellBackground(c.IsInstanceUnlocked(7) ? Green : Red);
                                        SetCellBackground(c.IsInstanceUnlocked(9) ? Green : Red);
                                        SetCellBackground(c.IsInstanceUnlocked(12) ? Green : Red);
                                        SetCellBackground(c.IsInstanceUnlocked(13) ? Green : Red);
                                        SetCellBackground(c.IsInstanceUnlocked(5) ? Green : Red);
                                        SetCellBackground(c.IsInstanceUnlocked(14) ? Green : Red);
                                        SetCellBackground(c.IsInstanceUnlocked(7) ? Green : Red);
                                        SetCellBackground(c.IsInstanceUnlocked(18) ? Green : Red);
                                        SetCellBackground(c.IsInstanceUnlocked(19) ? Green : Red);
                                        SetCellBackground(c.IsInstanceUnlocked(17) ? Green : Red);
                                        SetCellBackground(c.IsInstanceUnlocked(20) ? Green : Red);
                                        SetCellBackground(c.IsInstanceUnlocked(21) ? Green : Red);
                                        SetCellBackground(c.IsInstanceUnlocked(22) ? Green : Red);
                                        SetCellBackground(c.IsInstanceUnlocked(23) ? Green : Red);
                                        SetCellBackground(c.IsInstanceUnlocked(25) ? Green : Red);
                                        SetCellBackground(c.IsInstanceUnlocked(24) ? Green : Red);
                                        SetCellBackground(c.IsInstanceUnlocked(28) ? Green : Red);
                                        SetCellBackground(c.IsInstanceUnlocked(26) ? Green : Red);
                                        SetCellBackground(c.IsInstanceUnlocked(29) ? Green : Red);
                                        SetCellBackground(c.IsInstanceUnlocked(30) ? Green : Red);
                                    }
                                    ImGui.EndTable();
                                }
                                ImGui.EndTabItem();
                            }
                            if (ImGui.BeginTabItem("Trials"))
                            {
                                ImGui.Unindent();
                                ImGui.Unindent();
                                ImGui.Unindent();

                                if (ImGui.BeginTable("squadTrialsArr", SquadTrialsArrStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                                {
                                    SetUpSquadTableHeaders(0, SquadTrialsArrStrings);

                                    foreach (var c in charas)
                                    {
                                        DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                        SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                        SetCellBackground(c.IsInstanceUnlocked(20021) ? Green : Red);
                                        SetCellBackground(c.IsInstanceUnlocked(20019) ? Green : Red);
                                        SetCellBackground(c.IsInstanceUnlocked(20020) ? Green : Red);
                                        SetCellBackground(c.IsInstanceUnlocked(20013) ? Green : Red);
                                        SetCellBackground(c.IsInstanceUnlocked(20010) ? Green : Red);
                                        SetCellBackground(c.IsInstanceUnlocked(20009) ? Green : Red);
                                        SetCellBackground(c.IsInstanceUnlocked(20008) ? Green : Red);
                                        SetCellBackground(c.IsInstanceUnlocked(20026) ? Green : Red);
                                        SetCellBackground(c.IsInstanceUnlocked(20018) ? Green : Red);
                                        SetCellBackground(c.IsInstanceUnlocked(20012) ? Green : Red);
                                        SetCellBackground(c.IsInstanceUnlocked(20023) ? Green : Red);
                                        SetCellBackground(c.IsInstanceUnlocked(20030) ? Green : Red);
                                        SetCellBackground(c.IsInstanceUnlocked(20025) ? Green : Red);
                                        SetCellBackground(c.IsInstanceUnlocked(20027) ? Green : Red);
                                    }
                                    ImGui.EndTable();
                                }
                                ImGui.EndTabItem();
                            }
                            if (ImGui.BeginTabItem("Raids"))
                            {
                                ImGui.Unindent();
                                ImGui.Unindent();
                                ImGui.Unindent();

                                if (ImGui.BeginTable("squadRaidsArr", SquadRaidsArrStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                                {
                                    SetUpSquadTableHeaders(0, SquadRaidsArrStrings);

                                    foreach (var c in charas)
                                    {
                                        DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                        SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                        SetCellBackground(c.IsInstanceUnlocked(30002) ? Green : Red);
                                        SetCellBackground(c.IsInstanceUnlocked(30003) ? Green : Red);
                                        SetCellBackground(c.IsInstanceUnlocked(30004) ? Green : Red);
                                        SetCellBackground(c.IsInstanceUnlocked(30005) ? Green : Red);
                                        SetCellBackground(c.IsInstanceUnlocked(30006) ? Green : Red);
                                        SetCellBackground(c.IsInstanceUnlocked(30007) ? Green : Red);
                                        SetCellBackground(c.IsInstanceUnlocked(30008) ? Green : Red);
                                        SetCellBackground(c.IsInstanceUnlocked(30009) ? Green : Red);
                                        SetCellBackground(c.IsInstanceUnlocked(30010) ? Green : Red);
                                        SetCellBackground(c.IsInstanceUnlocked(30012) ? Green : Red);
                                        SetCellBackground(c.IsInstanceUnlocked(30013) ? Green : Red);
                                        SetCellBackground(c.IsInstanceUnlocked(30014) ? Green : Red);
                                        SetCellBackground(c.IsInstanceUnlocked(30015) ? Green : Red);
                                        SetCellBackground(c.IsInstanceUnlocked(30016) ? Green : Red);
                                        SetCellBackground(c.IsInstanceUnlocked(30017) ? Green : Red);
                                        SetCellBackground(c.IsInstanceUnlocked(30018) ? Green : Red);
                                        SetCellBackground(c.IsInstanceUnlocked(30019) ? Green : Red);
                                    }
                                    ImGui.EndTable();
                                }
                                ImGui.EndTabItem();
                            }
                            ImGui.EndTabBar();
                            ImGui.Unindent();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Heavensward"))
                    {
                        ImGui.Indent();
                        if (ImGui.BeginTabBar("squadHeavensward"))
                        {
                            if (ImGui.BeginTabItem("Dungeons"))
                            {
                                ImGui.Unindent();
                                ImGui.Unindent();
                                ImGui.Unindent();

                                if (ImGui.BeginTable("squadDungeonsHw", SquadDungeonsHwStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                                {
                                    SetUpSquadTableHeaders(0, SquadDungeonsHwStrings);

                                    foreach (var c in charas)
                                    {
                                        DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                        SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                        SetCellBackground(c.IsInstanceUnlocked(36) ? Green : Red);
                                        SetCellBackground(c.IsInstanceUnlocked(33) ? Green : Red);
                                        SetCellBackground(c.IsInstanceUnlocked(35) ? Green : Red);
                                        SetCellBackground(c.IsInstanceUnlocked(41) ? Green : Red);
                                        SetCellBackground(c.IsInstanceUnlocked(40) ? Green : Red);
                                        SetCellBackground(c.IsInstanceUnlocked(42) ? Green : Red);
                                        SetCellBackground(c.IsInstanceUnlocked(45) ? Green : Red);
                                        SetCellBackground(c.IsInstanceUnlocked(47) ? Green : Red);
                                        SetCellBackground(c.IsInstanceUnlocked(49) ? Green : Red);
                                        SetCellBackground(c.IsQuestComplete(67092) ? Green : Red);
                                    }
                                    ImGui.EndTable();
                                }
                                ImGui.EndTabItem();
                            }
                            if (ImGui.BeginTabItem("Trials"))
                            {
                                ImGui.Unindent();
                                ImGui.Unindent();
                                ImGui.Unindent();

                                if (ImGui.BeginTable("squadTrialsHw", SquadTrialsHwStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                                {
                                    SetUpSquadTableHeaders(0, SquadTrialsHwStrings);

                                    foreach (var c in charas)
                                    {
                                        DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                        SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                        SetCellBackground(c.IsInstanceUnlocked(20034) ? Green : Red);
                                        SetCellBackground(c.IsInstanceUnlocked(20032) ? Green : Red);
                                        SetCellBackground(c.IsInstanceUnlocked(20037) ? Green : Red);
                                        SetCellBackground(c.IsInstanceUnlocked(20036) ? Green : Red);
                                        SetCellBackground(c.IsInstanceUnlocked(20038) ? Green : Red);
                                        SetCellBackground(c.IsInstanceUnlocked(20041) ? Green : Red);
                                        SetCellBackground(c.IsInstanceUnlocked(20040) ? Green : Red);
                                        SetCellBackground(c.IsInstanceUnlocked(20042) ? Green : Red);
                                        SetCellBackground(c.IsInstanceUnlocked(20043) ? Green : Red);
                                        SetCellBackground(c.IsInstanceUnlocked(20044) ? Green : Red);
                                    }
                                    ImGui.EndTable();
                                }
                                ImGui.EndTabItem();
                            }
                            if (ImGui.BeginTabItem("Raids"))
                            {
                                ImGui.Indent();
                                if (ImGui.BeginTabBar("squadRaids"))
                                {
                                    if (ImGui.BeginTabItem("Normal Raids"))
                                    {
                                        ImGui.Unindent();
                                        ImGui.Unindent();
                                        ImGui.Unindent();
                                        ImGui.Unindent();

                                        if (ImGui.BeginTable("squadNormalRaidsHw", SquadNormalRaidsHwStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                                        {
                                            SetUpSquadTableHeaders(0, SquadNormalRaidsHwStrings);

                                            foreach (var c in charas)
                                            {
                                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                                SetCellBackground(c.IsInstanceUnlocked(30021) ? Green : Red);
                                                SetCellBackground(c.IsInstanceUnlocked(30022) ? Green : Red);
                                                SetCellBackground(c.IsInstanceUnlocked(30023) ? Green : Red);
                                                SetCellBackground(c.IsInstanceUnlocked(30024) ? Green : Red);
                                                SetCellBackground(c.IsInstanceUnlocked(30025) ? Green : Red);
                                                SetCellBackground(c.IsInstanceUnlocked(30026) ? Green : Red);
                                                SetCellBackground(c.IsInstanceUnlocked(30027) ? Green : Red);
                                                SetCellBackground(c.IsInstanceUnlocked(30028) ? Green : Red);
                                                SetCellBackground(c.IsInstanceUnlocked(30030) ? Green : Red);
                                                SetCellBackground(c.IsInstanceUnlocked(30031) ? Green : Red);
                                                SetCellBackground(c.IsInstanceUnlocked(30032) ? Green : Red);
                                                SetCellBackground(c.IsInstanceUnlocked(30033) ? Green : Red);
                                                SetCellBackground(c.IsInstanceUnlocked(30034) ? Green : Red);
                                                SetCellBackground(c.IsInstanceUnlocked(30035) ? Green : Red);
                                                SetCellBackground(c.IsInstanceUnlocked(30036) ? Green : Red);
                                                SetCellBackground(c.IsInstanceUnlocked(30037) ? Green : Red);
                                                SetCellBackground(c.IsInstanceUnlocked(30039) ? Green : Red);
                                                SetCellBackground(c.IsInstanceUnlocked(30040) ? Green : Red);
                                                SetCellBackground(c.IsInstanceUnlocked(30041) ? Green : Red);
                                                SetCellBackground(c.IsInstanceUnlocked(30042) ? Green : Red);
                                                SetCellBackground(c.IsInstanceUnlocked(30043) ? Green : Red);
                                                SetCellBackground(c.IsInstanceUnlocked(30044) ? Green : Red);
                                                SetCellBackground(c.IsInstanceUnlocked(30045) ? Green : Red);
                                                SetCellBackground(c.IsInstanceUnlocked(30046) ? Green : Red);
                                            }
                                            ImGui.EndTable();
                                        }
                                        ImGui.EndTabItem();
                                    }
                                    if (ImGui.BeginTabItem("Alliance Raids"))
                                    {
                                        ImGui.Unindent();
                                        ImGui.Unindent();
                                        ImGui.Unindent();
                                        ImGui.Unindent();

                                        if (ImGui.BeginTable("squadAllianceRaidsHw", SquadAllianceRaidsHwStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                                        {
                                            SetUpSquadTableHeaders(0, SquadAllianceRaidsHwStrings);

                                            foreach (var c in charas)
                                            {
                                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                                SetCellBackground(c.IsInstanceUnlocked(30029) ? Green : Red);
                                                SetCellBackground(c.IsInstanceUnlocked(30038) ? Green : Red);
                                                SetCellBackground(c.IsInstanceUnlocked(30047) ? Green : Red);
                                            }
                                            ImGui.EndTable();
                                        }
                                        ImGui.EndTabItem();
                                    }
                                    ImGui.EndTabBar();
                                    ImGui.Unindent();
                                }
                                ImGui.EndTabItem();
                            }
                            ImGui.EndTabBar();
                            ImGui.Unindent();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Stormblood"))
                    {
                        ImGui.Indent();
                        if (ImGui.BeginTabBar("squadStormblood"))
                        {
                            if (ImGui.BeginTabItem("Dungeons"))
                            {
                                ImGui.Unindent();
                                ImGui.Unindent();
                                ImGui.Unindent();

                                if (ImGui.BeginTable("squadDungeonsSb", SquadDungeonsSbStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                                {
                                    SetUpSquadTableHeaders(0, SquadDungeonsSbStrings);

                                    foreach (var c in charas)
                                    {
                                        DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                        SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                        SetCellBackground(c.IsInstanceUnlocked(50) ? Green : Red);
                                        SetCellBackground(c.IsInstanceUnlocked(57) ? Green : Red);
                                        SetCellBackground(c.IsInstanceUnlocked(51) ? Green : Red);
                                        SetCellBackground(c.IsInstanceUnlocked(59) ? Green : Red);
                                        SetCellBackground(c.IsInstanceUnlocked(60) ? Green : Red);
                                        SetCellBackground(c.IsInstanceUnlocked(61) ? Green : Red);
                                        SetCellBackground(c.IsInstanceUnlocked(62) ? Green : Red);
                                        SetCellBackground(c.IsQuestComplete(68667) ? Green : Red);
                                    }
                                    ImGui.EndTable();
                                }
                                ImGui.EndTabItem();
                            }
                            if (ImGui.BeginTabItem("Trials"))
                            {
                                ImGui.Unindent();
                                ImGui.Unindent();
                                ImGui.Unindent();

                                if (ImGui.BeginTable("squadTrialsSb", SquadTrialsSbStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                                {
                                    SetUpSquadTableHeaders(0, SquadTrialsSbStrings);

                                    foreach (var c in charas)
                                    {
                                        DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                        SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                        SetCellBackground(c.IsInstanceUnlocked(20049) ? Green : Red);
                                        SetCellBackground(c.IsInstanceUnlocked(20047) ? Green : Red);
                                        SetCellBackground(c.IsInstanceUnlocked(20053) ? Green : Red);
                                        SetCellBackground(c.IsInstanceUnlocked(20050) ? Green : Red);
                                        SetCellBackground(c.IsInstanceUnlocked(20051) ? Green : Red);
                                        SetCellBackground(c.IsInstanceUnlocked(20052) ? Green : Red);
                                        SetCellBackground(c.IsInstanceUnlocked(20054) ? Green : Red);
                                        SetCellBackground(c.IsInstanceUnlocked(20056) ? Green : Red);
                                        SetCellBackground(c.IsInstanceUnlocked(20057) ? Green : Red);
                                        SetCellBackground(c.IsInstanceUnlocked(20059) ? Green : Red);
                                        SetCellBackground(c.IsInstanceUnlocked(20060) ? Green : Red);
                                        SetCellBackground(c.IsInstanceUnlocked(20058) ? Green : Red);
                                        SetCellBackground(c.IsInstanceUnlocked(20061) ? Green : Red);
                                    }
                                    ImGui.EndTable();
                                }
                                ImGui.EndTabItem();
                            }
                            if (ImGui.BeginTabItem("Raids"))
                            {
                                ImGui.Indent();
                                if (ImGui.BeginTabBar("squadRaids"))
                                {
                                    if (ImGui.BeginTabItem("Normal Raids"))
                                    {
                                        ImGui.Unindent();
                                        ImGui.Unindent();
                                        ImGui.Unindent();
                                        ImGui.Unindent();

                                        if (ImGui.BeginTable("squadNormalRaidsSb", SquadNormalRaidsSbStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                                        {
                                            SetUpSquadTableHeaders(0, SquadNormalRaidsSbStrings);

                                            foreach (var c in charas)
                                            {
                                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                                SetCellBackground(c.IsInstanceUnlocked(30049) ? Green : Red);
                                                SetCellBackground(c.IsInstanceUnlocked(30050) ? Green : Red);
                                                SetCellBackground(c.IsInstanceUnlocked(30051) ? Green : Red);
                                                SetCellBackground(c.IsInstanceUnlocked(30052) ? Green : Red);
                                                SetCellBackground(c.IsInstanceUnlocked(30053) ? Green : Red);
                                                SetCellBackground(c.IsInstanceUnlocked(30054) ? Green : Red);
                                                SetCellBackground(c.IsInstanceUnlocked(30055) ? Green : Red);
                                                SetCellBackground(c.IsInstanceUnlocked(30056) ? Green : Red);
                                                SetCellBackground(c.IsInstanceUnlocked(30059) ? Green : Red);
                                                SetCellBackground(c.IsInstanceUnlocked(30060) ? Green : Red);
                                                SetCellBackground(c.IsInstanceUnlocked(30061) ? Green : Red);
                                                SetCellBackground(c.IsInstanceUnlocked(30062) ? Green : Red);
                                                SetCellBackground(c.IsInstanceUnlocked(30063) ? Green : Red);
                                                SetCellBackground(c.IsInstanceUnlocked(30064) ? Green : Red);
                                                SetCellBackground(c.IsInstanceUnlocked(30065) ? Green : Red);
                                                SetCellBackground(c.IsInstanceUnlocked(30066) ? Green : Red);
                                                SetCellBackground(c.IsInstanceUnlocked(30069) ? Green : Red);
                                                SetCellBackground(c.IsInstanceUnlocked(30070) ? Green : Red);
                                                SetCellBackground(c.IsInstanceUnlocked(30071) ? Green : Red);
                                                SetCellBackground(c.IsInstanceUnlocked(30072) ? Green : Red);
                                                SetCellBackground(c.IsInstanceUnlocked(30073) ? Green : Red);
                                                SetCellBackground(c.IsInstanceUnlocked(30074) ? Green : Red);
                                                SetCellBackground(c.IsInstanceUnlocked(30075) ? Green : Red);
                                                SetCellBackground(c.IsInstanceUnlocked(30076) ? Green : Red);
                                            }
                                            ImGui.EndTable();
                                        }
                                        ImGui.EndTabItem();
                                    }
                                    if (ImGui.BeginTabItem("Alliance Raids"))
                                    {
                                        ImGui.Unindent();
                                        ImGui.Unindent();
                                        ImGui.Unindent();
                                        ImGui.Unindent();

                                        if (ImGui.BeginTable("squadAllianceRaidsSb", SquadAllianceRaidsSbStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                                        {
                                            SetUpSquadTableHeaders(0, SquadAllianceRaidsSbStrings);

                                            foreach (var c in charas)
                                            {
                                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                                SetCellBackground(c.IsInstanceUnlocked(30058) ? Green : Red);
                                                SetCellBackground(c.IsInstanceUnlocked(30068) ? Green : Red);
                                                SetCellBackground(c.IsInstanceUnlocked(30077) ? Green : Red);
                                            }
                                            ImGui.EndTable();
                                        }
                                        ImGui.EndTabItem();
                                    }
                                    ImGui.EndTabBar();
                                    ImGui.Unindent();
                                }
                                ImGui.EndTabItem();
                            }
                            if (ImGui.BeginTabItem("Eureka"))
                            {
                                ImGui.Unindent();
                                ImGui.Unindent();
                                ImGui.Unindent();

                                if (ImGui.BeginTable("squadEurekaSb", SquadEurekaSbStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                                {
                                    SetUpSquadTableHeaders(0, SquadEurekaSbStrings);

                                    foreach (var c in charas)
                                    {
                                        DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                        SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                        SetCellBackground(c.IsQuestComplete(68614) ? Green : Red);
                                        SetCellBackground(c.IsQuestComplete(68478) ? Green : Red);
                                        SetCellBackground(c.IsQuestComplete(68148) ? Green : Red);
                                        SetCellBackground(c.IsQuestComplete(68149) ? Green : Red);
                                    }
                                    ImGui.EndTable();
                                }
                                ImGui.EndTabItem();
                            }
                            ImGui.EndTabBar();
                            ImGui.Unindent();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Shadowbringers"))
                    {
                        ImGui.Indent();
                        if (ImGui.BeginTabBar("squadShadowbringers"))
                        {
                            if (ImGui.BeginTabItem("Dungeons"))
                            {
                                ImGui.Unindent();
                                ImGui.Unindent();
                                ImGui.Unindent();

                                if (ImGui.BeginTable("squadDungeonsShb", SquadDungeonsShbStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                                {
                                    SetUpSquadTableHeaders(0, SquadDungeonsShbStrings);

                                    foreach (var c in charas)
                                    {
                                        DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                        SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                        SetCellBackground(c.IsInstanceUnlocked(71) ? Green : Red);
                                        SetCellBackground(c.IsInstanceUnlocked(20013) ? Green : Red);
                                    }
                                    ImGui.EndTable();
                                }
                                ImGui.EndTabItem();
                            }
                            if (ImGui.BeginTabItem("Trials"))
                            {
                                ImGui.Unindent();
                                ImGui.Unindent();
                                ImGui.Unindent();

                                if (ImGui.BeginTable("squadTrialsShb", SquadTrialsShbStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                                {
                                    SetUpSquadTableHeaders(0, SquadTrialsShbStrings);

                                    foreach (var c in charas)
                                    {
                                        DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                        SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                        SetCellBackground(c.IsInstanceUnlocked(20065) ? Green : Red);
                                        SetCellBackground(c.IsInstanceUnlocked(20067) ? Green : Red);
                                        SetCellBackground(c.IsInstanceUnlocked(20068) ? Green : Red);
                                        SetCellBackground(c.IsInstanceUnlocked(20069) ? Green : Red);
                                        SetCellBackground(c.IsInstanceUnlocked(20070) ? Green : Red);
                                        SetCellBackground(c.IsInstanceUnlocked(20072) ? Green : Red);
                                        SetCellBackground(c.IsInstanceUnlocked(20073) ? Green : Red);
                                        SetCellBackground(c.IsInstanceUnlocked(20075) ? Green : Red);
                                        SetCellBackground(c.IsInstanceUnlocked(20074) ? Green : Red);
                                        SetCellBackground(c.IsInstanceUnlocked(20076) ? Green : Red);
                                    }
                                    ImGui.EndTable();
                                }
                                ImGui.EndTabItem();
                            }
                            if (ImGui.BeginTabItem("Raids"))
                            {
                                ImGui.Indent();
                                if (ImGui.BeginTabBar("squadRaids"))
                                {
                                    if (ImGui.BeginTabItem("Normal Raids"))
                                    {
                                        ImGui.Unindent();
                                        ImGui.Unindent();
                                        ImGui.Unindent();
                                        ImGui.Unindent();

                                        if (ImGui.BeginTable("squadNormalRaidsShb", SquadNormalRaidsShbStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                                        {
                                            SetUpSquadTableHeaders(0, SquadNormalRaidsShbStrings);

                                            foreach (var c in charas)
                                            {
                                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                                SetCellBackground(c.IsInstanceUnlocked(30078) ? Green : Red);
                                                SetCellBackground(c.IsInstanceUnlocked(30082) ? Green : Red);
                                                SetCellBackground(c.IsInstanceUnlocked(30080) ? Green : Red);
                                                SetCellBackground(c.IsInstanceUnlocked(30084) ? Green : Red);
                                                SetCellBackground(c.IsInstanceUnlocked(30079) ? Green : Red);
                                                SetCellBackground(c.IsInstanceUnlocked(30083) ? Green : Red);
                                                SetCellBackground(c.IsInstanceUnlocked(30081) ? Green : Red);
                                                SetCellBackground(c.IsInstanceUnlocked(30085) ? Green : Red);
                                                SetCellBackground(c.IsInstanceUnlocked(30088) ? Green : Red);
                                                SetCellBackground(c.IsInstanceUnlocked(30090) ? Green : Red);
                                                SetCellBackground(c.IsInstanceUnlocked(30092) ? Green : Red);
                                                SetCellBackground(c.IsInstanceUnlocked(30094) ? Green : Red);
                                                SetCellBackground(c.IsInstanceUnlocked(30089) ? Green : Red);
                                                SetCellBackground(c.IsInstanceUnlocked(30091) ? Green : Red);
                                                SetCellBackground(c.IsInstanceUnlocked(30093) ? Green : Red);
                                                SetCellBackground(c.IsInstanceUnlocked(30095) ? Green : Red);
                                                SetCellBackground(c.IsInstanceUnlocked(30097) ? Green : Red);
                                                SetCellBackground(c.IsInstanceUnlocked(30099) ? Green : Red);
                                                SetCellBackground(c.IsInstanceUnlocked(30101) ? Green : Red);
                                                SetCellBackground(c.IsInstanceUnlocked(30103) ? Green : Red);
                                                SetCellBackground(c.IsInstanceUnlocked(30098) ? Green : Red);
                                                SetCellBackground(c.IsInstanceUnlocked(30100) ? Green : Red);
                                                SetCellBackground(c.IsInstanceUnlocked(30102) ? Green : Red);
                                                SetCellBackground(c.IsInstanceUnlocked(30104) ? Green : Red);
                                            }
                                            ImGui.EndTable();
                                        }
                                        ImGui.EndTabItem();
                                    }
                                    if (ImGui.BeginTabItem("Alliance Raids"))
                                    {
                                        ImGui.Unindent();
                                        ImGui.Unindent();
                                        ImGui.Unindent();
                                        ImGui.Unindent();

                                        if (ImGui.BeginTable("squadAllianceRaidsShb", SquadAllianceRaidsShbStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                                        {
                                            SetUpSquadTableHeaders(0, SquadAllianceRaidsShbStrings);

                                            foreach (var c in charas)
                                            {
                                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                                SetCellBackground(c.IsInstanceUnlocked(30087) ? Green : Red);
                                                SetCellBackground(c.IsInstanceUnlocked(30096) ? Green : Red);
                                                SetCellBackground(c.IsInstanceUnlocked(30105) ? Green : Red);
                                            }
                                            ImGui.EndTable();
                                        }
                                        ImGui.EndTabItem();
                                    }
                                    ImGui.EndTabBar();
                                    ImGui.Unindent();
                                }
                                ImGui.EndTabItem();
                            }
                            if (ImGui.BeginTabItem("Bozja"))
                            {
                                ImGui.Unindent();
                                ImGui.Unindent();
                                ImGui.Unindent();

                                if (ImGui.BeginTable("squadBozjaShb", SquadBozjaShbStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                                {
                                    SetUpSquadTableHeaders(0, SquadBozjaShbStrings);

                                    foreach (var c in charas)
                                    {
                                        DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                        SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                        SetCellBackground(c.IsQuestComplete(69477) ? Green : Red);
                                        SetCellBackground(c.IsQuestComplete(69620) ? Green : Red);
                                        SetCellBackground(c.IsQuestComplete(69624) ? Green : Red);
                                    }
                                    ImGui.EndTable();
                                }
                                ImGui.EndTabItem();
                            }
                            ImGui.EndTabBar();
                            ImGui.Unindent();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Endwalker"))
                    {
                        ImGui.Indent();
                        if (ImGui.BeginTabBar("squadEndwalker"))
                        {
                            if (ImGui.BeginTabItem("Dungeons"))
                            {
                                ImGui.Unindent();
                                ImGui.Unindent();
                                ImGui.Unindent();

                                if (ImGui.BeginTable("squadDungeonsEw", SquadDungeonsEwStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                                {
                                    SetUpSquadTableHeaders(0, SquadDungeonsEwStrings);

                                    foreach (var c in charas)
                                    {
                                        DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                        SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                        SetCellBackground(c.IsInstanceUnlocked(20030) ? Green : Red);
                                        SetCellBackground(c.IsInstanceUnlocked(79) ? Green : Red);
                                        SetCellBackground(c.IsQuestComplete(70199) ? Green : Red);
                                    }
                                    ImGui.EndTable();
                                }
                                ImGui.EndTabItem();
                            }
                            if (ImGui.BeginTabItem("Trials"))
                            {
                                ImGui.Unindent();
                                ImGui.Unindent();
                                ImGui.Unindent();

                                if (ImGui.BeginTable("squadTrialsEw", SquadTrialsEwStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                                {
                                    SetUpSquadTableHeaders(0, SquadTrialsEwStrings);

                                    foreach (var c in charas)
                                    {
                                        DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                        SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                        SetCellBackground(c.IsInstanceUnlocked(20078) ? Green : Red);
                                        SetCellBackground(c.IsInstanceUnlocked(20081) ? Green : Red);
                                        SetCellBackground(c.IsInstanceUnlocked(20083) ? Green : Red);
                                        SetCellBackground(c.IsInstanceUnlocked(20085) ? Green : Red);
                                        SetCellBackground(c.IsInstanceUnlocked(20087) ? Green : Red);
                                    }
                                    ImGui.EndTable();
                                }
                                ImGui.EndTabItem();
                            }
                            if (ImGui.BeginTabItem("Raids"))
                            {
                                ImGui.Indent();
                                if (ImGui.BeginTabBar("squadRaids"))
                                {
                                    if (ImGui.BeginTabItem("Normal Raids"))
                                    {
                                        ImGui.Unindent();
                                        ImGui.Unindent();
                                        ImGui.Unindent();
                                        ImGui.Unindent();

                                        if (ImGui.BeginTable("squadNormalRaidsEw", SquadNormalRaidsEwStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                                        {
                                            SetUpSquadTableHeaders(0, SquadNormalRaidsEwStrings);

                                            foreach (var c in charas)
                                            {
                                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                                SetCellBackground(c.IsInstanceUnlocked(30111) ? Green : Red);
                                                SetCellBackground(c.IsInstanceUnlocked(30113) ? Green : Red);
                                                SetCellBackground(c.IsInstanceUnlocked(30109) ? Green : Red);
                                                SetCellBackground(c.IsInstanceUnlocked(30107) ? Green : Red);
                                                SetCellBackground(c.IsInstanceUnlocked(30112) ? Green : Red);
                                                SetCellBackground(c.IsInstanceUnlocked(30114) ? Green : Red);
                                                SetCellBackground(c.IsInstanceUnlocked(30110) ? Green : Red);
                                                SetCellBackground(c.IsInstanceUnlocked(30108) ? Green : Red);
                                                SetCellBackground(c.IsInstanceUnlocked(30116) ? Green : Red);
                                                SetCellBackground(c.IsInstanceUnlocked(30120) ? Green : Red);
                                                SetCellBackground(c.IsInstanceUnlocked(30118) ? Green : Red);
                                                SetCellBackground(c.IsInstanceUnlocked(30122) ? Green : Red);
                                                SetCellBackground(c.IsInstanceUnlocked(30117) ? Green : Red);
                                                SetCellBackground(c.IsInstanceUnlocked(30121) ? Green : Red);
                                                SetCellBackground(c.IsInstanceUnlocked(30119) ? Green : Red);
                                                SetCellBackground(c.IsInstanceUnlocked(30123) ? Green : Red);
                                            }
                                            ImGui.EndTable();
                                        }
                                        ImGui.EndTabItem();
                                    }
                                    if (ImGui.BeginTabItem("Alliance Raids"))
                                    {
                                        ImGui.Unindent();
                                        ImGui.Unindent();
                                        ImGui.Unindent();
                                        ImGui.Unindent();

                                        if (ImGui.BeginTable("squadAllianceRaidsEw", SquadAllianceRaidsEwStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                                        {
                                            SetUpSquadTableHeaders(0, SquadAllianceRaidsEwStrings);

                                            foreach (var c in charas)
                                            {
                                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                                SetCellBackground(c.IsInstanceUnlocked(30115) ? Green : Red);
                                                SetCellBackground(c.IsInstanceUnlocked(30125) ? Green : Red);
                                            }
                                            ImGui.EndTable();
                                        }
                                        ImGui.EndTabItem();
                                    }
                                    ImGui.EndTabBar();
                                    ImGui.Unindent();
                                }
                                ImGui.EndTabItem();
                            }
                            ImGui.EndTabBar();
                            ImGui.Unindent();
                        }
                        ImGui.EndTabItem();
                    }
                    ImGui.EndTabBar();
                    ImGui.Unindent();
                }
                ImGui.EndTabItem();
            }

        }
    }
}
