using FFXIVCharaTracker.DB;
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

                                if (ImGui.BeginTable("squadoptionalGeneralHousing", 6, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                                {
                                    SetUpSquadTableHeaders(0, "Mist", "Lavender Beds", "The Goblet", "Shirogane", "Empyreum");

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

                                if (ImGui.BeginTable("squadoptionalGeneralMateria", 4, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                                {
                                    SetUpSquadTableHeaders(0, "Spiritbond", "Materia Melding", "Advanced Materia Melding");

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

                                if (ImGui.BeginTable("squadoptionalGeneralAppearance", 5, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                                {
                                    SetUpSquadTableHeaders(0, "Dyeing", "Glamours", "Egi Glamours", "Aesthetician");

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

                                if (ImGui.BeginTable("squadoptionalGeneralZones", 3, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                                {
                                    SetUpSquadTableHeaders(0, "Gold Saucer", "White Wolf Gate");

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

                                if (ImGui.BeginTable("squadoptionalGeneralPvP", 4, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                                {
                                    SetUpSquadTableHeaders(0, "Crystalline Conflict", "Frontlines", "Rival Wings");

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
                                if (ImGui.BeginTable("squadoptionalGeneralHunt", 19))
                                {
                                    SetUpSquadTableHeaders(0, "ARR Hunts", "HW 1-star", "HW 2-star", "HW 3-star", "HW Elite", "SB 1-star", "SB 2-star", "SB 3-star", "SB Elite", "ShB 1-star", "ShB 2-star", "ShB 3-star", "ShB Elite", "EW 1-star", "EW 2-star", "EW 3-star", "EW Elite");

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
                                if (ImGui.BeginTable("squadoptionalGeneralTribes", 2))
                                {
                                    SetUpSquadTableHeaders(0, "Amalj'aa", "Sylphs", "Kobolds", "Sahagin", "Ixal", "Vanu Vanu", "Vath", "Moogles", "Kojin", "Ananta", "Namazu", "Pixies", "Qitari", "Dwarves", "Arkasodara", "Omicrons", "Loporrits");

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
                                if (ImGui.BeginTable("squadoptionalGeneralCollectables", 7))
                                {
                                    SetUpSquadTableHeaders(0, "Collectables", "Heavensward", "Stormblood", "Shadowbringers", "Endwalker", "Reduction");

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
                                if (ImGui.BeginTable("squadoptionalGeneralSightseeing", 6))
                                {
                                    SetUpSquadTableHeaders(0, "A Realm Reborn", "Heavensward", "Stormblood", "Shadowbringers", "Endwalker");

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
                                if (ImGui.BeginTable("squadoptionalGeneralDummies", 5))
                                {
                                    SetUpSquadTableHeaders(0, "Heavensward", "Stormblood", "Shadowbringers", "Endwalker");

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

                                if (ImGui.BeginTable("squadoptionalGeneralOther", 7, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                                {
                                    SetUpSquadTableHeaders(0, "Ventures", "Desynthesis", "Combat Chocobo", "Chocobo Raising", "Treasure Maps", "Master Recipes", "Challenge Log", "Wondrous Tails", "Faux Hollows");

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

                                if (ImGui.BeginTable("squadDungeonsArr", 21, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                                {
                                    SetUpSquadTableHeaders(0, "Halatali", "The Sunken Temple of Qarn", "Cutter's Cry", "Dzemael Darkhold", "The Aurum Vale", "Amdapor Keep", "The Wanderer's Palace", "Copperbell Mines (Hard)", "Haukke Manor (Hard)", "Pharos Sirius", "Brayflox's Longstop (Hard)", "Halatali (Hard)", "The Lost City of Amdapor (Hard)", "Hullbreaker Isle", "The Stone Vigil (Hard)", "The Tam-Tara Deepcroft (Hard)", "Sastasha (Hard)", "The Sunken Temple of Qarn (Hard)", "Amdapor Keep (Hard)", "The Wanderer's Palace (Hard)");

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

                                if (ImGui.BeginTable("squadTrialsArr", 15, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                                {
                                    SetUpSquadTableHeaders(0, "Battle on the Big Bridge", "A Relic Reborn: The Chimera", "A Relic Reborn: The Hydra", "The Minstrel's Ballad: Ultima's Bane", "The Howling Eye (Extreme)", "The Navel (Extreme)", "The Bowl of Embers (Extreme)", "The Dragon's Neck", "The Whorleater (Extreme)", "Thornmarch (Extreme)", "The Striking Tree (Extreme)", "Battle in the Big Keep", "Akh Afah Amphitheatre (Extreme)", "Urth's Fount");

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

                                if (ImGui.BeginTable("squadRaidsArr", 18, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                                {
                                    SetUpSquadTableHeaders(0, "The Binding Coil of Bahamut - Turn 1", "The Binding Coil of Bahamut - Turn 2", "The Binding Coil of Bahamut - Turn 3", "The Binding Coil of Bahamut - Turn 4", "The Binding Coil of Bahamut - Turn 5", "The Second Coil of Bahamut - Turn 1", "The Second Coil of Bahamut - Turn 2", "The Second Coil of Bahamut - Turn 3", "The Second Coil of Bahamut - Turn 4", "The Second Coil of Bahamut - Turn 1 (Savage)", "The Second Coil of Bahamut - Turn 2 (Savage)", "The Second Coil of Bahamut - Turn 3 (Savage)", "The Second Coil of Bahamut - Turn 4 (Savage)", "The Final Coil of Bahamut - Turn 1", "The Final Coil of Bahamut - Turn 2", "The Final Coil of Bahamut - Turn 3", "The Final Coil of Bahamut - Turn 4");

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

                                if (ImGui.BeginTable("squadDungeonsHw", 11, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                                {
                                    SetUpSquadTableHeaders(0, "The Dusk Vigil", "Neverreap", "The Fractal Continuum", "Saint Mocianne's Arboretum", "Pharos Sirius (Hard)", "The Lost City of Amdapor (Hard)", "Hullbreaker Isle (Hard)", "The Great Gubal Library (Hard)", "Sohm Al (Hard)", "The Palace of the Dead");

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

                                if (ImGui.BeginTable("squadTrialsHw", 11, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                                {
                                    SetUpSquadTableHeaders(0, "The Limitless Blue (Extreme)", "Thok ast Thok (Extreme)", "Containment Bay S1T7", "The Minstrel's Ballad: Thordan's Reign", "Containment Bay S1T7 (Extreme)", "Containment Bay P1T6", "The Minstrel's Ballad: Nidhogg's Rage", "Containment Bay P1T6 (Extreme)", "Containment Bay Z1T9", "Containment Bay Z1T9 (Extreme)");

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

                                        if (ImGui.BeginTable("squadNormalRaidsHw", 25, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                                        {
                                            SetUpSquadTableHeaders(0, "Alexander - The Fist of the Father", "Alexander - The Cuff of the Father", "Alexander - The Arm of the Father", "Alexander - The Burden of the Father", "Alexander - The Fist of the Father (Savage)", "Alexander - The Cuff of the Father (Savage)", "Alexander - The Arm of the Father (Savage)", "Alexander - The Burden of the Father (Savage)", "Alexander - The Fist of the Son", "Alexander - The Cuff of the Son", "Alexander - The Arm of the Son", "Alexander - The Burden of the Son (Savage)", "Alexander - The Fist of the Son (Savage)", "Alexander - The Cuff of the Son (Savage)", "Alexander - The Arm of the Son (Savage)", "Alexander - The Burden of the Son (Savage)", "Alexander - The Eyes of the Creator", "Alexander - The Breath of the Creator", "Alexander - The Heart of the Creator", "Alexander - The Soul of the Creator", "Alexander - The Eyes of the Creator (Savage)", "Alexander - The Breath of the Creator (Savage)", "Alexander - The Heart of the Creator (Savage)", "Alexander - The Soul of the Creator (Savage)");

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

                                        if (ImGui.BeginTable("squadAllianceRaidsHw", 4, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                                        {
                                            SetUpSquadTableHeaders(0, "The Void Ark", "The Weeping City of Mhach", "Dun Scaith");

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

                                if (ImGui.BeginTable("squadDungeonsSb", 9, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                                {
                                    SetUpSquadTableHeaders(0, "Shisui of the Violet Tides", "Kugane Castle", "The Temple of the Fist", "Hell's Lid", "The Fractal Continuum (Hard)", "The Swallow's Compass", "Saint Mocianne's Arboretum (Hard)", "Heaven-on-High");

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

                                if (ImGui.BeginTable("squadTrialsSb", 14, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                                {
                                    SetUpSquadTableHeaders(0, "Emanation (Extreme)", "The Pool of Tribute (Extreme)", "The Great Hunt", "The Minstrel's Ballad: Shinryu's Domain", "The Jade Stoa", "The Jade Stoa (Extreme)", "The Great Hunt (Extreme)", "The Minstrel's Ballad: Tsukuyomi's Pain", "Hells' Kier", "Kugane Ohashi", "The Wreath of Snakes", "Hells' Kier (Extreme)", "The Wreath of Snakes (Extreme)");

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

                                        if (ImGui.BeginTable("squadNormalRaidsSb", 25, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                                        {
                                            SetUpSquadTableHeaders(0, "Deltascape V1.0", "Deltascape V2.0", "Deltascape V3.0", "Deltascape V4.0", "Deltascape V1.0 (Savage)", "Deltascape V2.0 (Savage)", "Deltascape V3.0 (Savage)", "Deltascape V4.0 (Savage)", "Sigmascape V1.0", "Sigmascape V2.0", "Sigmascape V3.0", "Sigmascape V4.0", "Sigmascape V1.0 (Savage)", "Sigmascape V2.0 (Savage)", "Sigmascape V3.0 (Savage)", "Sigmascape V4.0 (Savage)", "Alphascape V1.0", "Alphascape V2.0", "Alphascape V3.0", "Alphascape V4.0", "Alphascape V1.0 (Savage)", "Alphascape V2.0 (Savage)", "Alphascape V3.0 (Savage)", "Alphascape V4.0 (Savage)");

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

                                        if (ImGui.BeginTable("squadAllianceRaidsSb", 4, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                                        {
                                            SetUpSquadTableHeaders(0, "The Royal City of Rabanastre", "The Ridorana Lighthouse", "The Orbonne Monastery");

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

                                if (ImGui.BeginTable("squadEurekaSb", 5, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                                {
                                    SetUpSquadTableHeaders(0, "The Forbidden Land, Eureka Anemos", "The Forbidden Land, Eureka Pagos", "The Forbidden Land, Eureka Pyros", "The Forbidden Land, Eureka Hydatos");

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

                                if (ImGui.BeginTable("squadDungeonsShb", 3, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                                {
                                    SetUpSquadTableHeaders(0, "Akadaemia Anyder", "The Twinning");

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

                                if (ImGui.BeginTable("squadTrialsShb", 11, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                                {
                                    SetUpSquadTableHeaders(0, "The Crown of the Immaculate (Extreme)", "The Minstrel's Ballad: Hades' Elegy", "Cinder Drift", "Cinder Drift (Extreme)", "Memoria Misera (Extreme)", "The Seat of Sacrifice (Extreme)", "Castrum Marinum", "The Cloud Deck", "Castrum Marinum (Extreme)", "The Cloud Deck (Extreme)");

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

                                        if (ImGui.BeginTable("squadNormalRaidsShb", 25, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                                        {
                                            SetUpSquadTableHeaders(0, "Eden's Gate: Resurrection", "Eden's Gate: Descent", "Eden's Gate: Inundation", "Eden's Gate: Sepulture", "Eden's Gate: Resurrection (Savage)", "Eden's Gate: Descent (Savage)", "Eden's Gate: Inundation (Savage)", "Eden's Gate: Sepulture (Savage)", "Eden's Verse: Fulmination", "Eden's Verse: Furor", "Eden's Verse: Iconoclasm", "Eden's Verse: Refulgence", "Eden's Verse: Fulmination (Savage)", "Eden's Verse: Furor (Savage)", "Eden's Verse: Iconoclasm (Savage)", "Eden's Verse: Refulgence (Savage)", "Eden's Promise: Umbra", "Eden's Promise: Litany", "Eden's Promise: Anamorphosis", "Eden's Promise: Eternity", "Eden's Promise: Umbra (Savage)", "Eden's Promise: Litany (Savage)", "Eden's Promise: Anamorphosis (Savage)", "Eden's Promise: Eternity (Savage)");

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

                                        if (ImGui.BeginTable("squadAllianceRaidsShb", 4, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                                        {
                                            SetUpSquadTableHeaders(0, "The Copied Factory", "The Puppets' Bunker", "The Tower at Paradigm's Breach");

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

                                if (ImGui.BeginTable("squadBozjaShb", 4, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                                {
                                    SetUpSquadTableHeaders(0, "The Bozjan Southern Front", "Zadnor", "Bozja complete");

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

                                if (ImGui.BeginTable("squadDungeonsEw", 3, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                                {
                                    SetUpSquadTableHeaders(0, "Smileton", "The Stigma Dreamscape", "Eureka Orthos");

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

                                if (ImGui.BeginTable("squadTrialsEw", 6, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                                {
                                    SetUpSquadTableHeaders(0, "The Minstrel's Ballad: Hydaelyn's Call", "The Minstrel's Ballad: Zodiark's Fall", "The Minstrel's Ballad: Endsinger's Aria", "Storm's Crown (Extreme)", "Mount Ordeals (Extreme)");

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

                                        if (ImGui.BeginTable("squadNormalRaidsEw", 17, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                                        {
                                            SetUpSquadTableHeaders(0, "Asphodelos: The First Circle", "Asphodelos: The Second Circle", "Asphodelos: The Third Circle", "Asphodelos: The Fourth Circle", "Asphodelos: The First Circle (Savage)", "Asphodelos: The Second Circle (Savage)", "Asphodelos: The Third Circle (Savage)", "Asphodelos: The Fourth Circle (Savage)", "Abyssos: The Fifth Circle", "Abyssos: The Sixth Circle", "Abyssos: The Seventh Circle", "Abyssos: The Eighth Circle", "Abyssos: The Fifth Circle (Savage)", "Abyssos: The Sixth Circle (Savage)", "Abyssos: The Seventh Circle (Savage)", "Abyssos: The Eighth Circle (Savage)");

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

                                        if (ImGui.BeginTable("squadAllianceRaidsEw", 3, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                                        {
                                            SetUpSquadTableHeaders(0, "Aglaia", "Euphrosyne");

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
