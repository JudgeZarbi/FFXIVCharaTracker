using FFXIVCharaTracker.DB;
using ImGuiNET;

namespace FFXIVCharaTracker
{
    internal partial class PluginUI
    {
        internal void DrawSquadEmotesSection(List<Chara> charas)
        {
            if (ImGui.BeginTabItem("Emote"))
            {
                var lastAccount = -1;
                var lastWorld = 0u;

                ImGui.Indent();
                if (ImGui.BeginTabBar("squadEmotes"))
                {
                    if (ImGui.BeginTabItem("Sidequests"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("squadEmotesSidequest", SquadEmoteSidequestStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, SquadEmoteSidequestStrings);

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsEmoteUnlocked(85) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(101) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(102) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(103) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(104) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(114) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(148) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(198) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(199) ? Green : Red);

                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Tribe"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("squadEmotesTribe", SquadEmoteTribeStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, SquadEmoteTribeStrings);

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                ImGui.TableSetBgColor(ImGuiTableBgTarget.CellBg, ImGui.GetColorU32(c.IsEmoteUnlocked(120) ? Green : Red));
                                SetCellBackground(c.IsEmoteUnlocked(126) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(145) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(167) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(64) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(176) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(194) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(217) ? Green : Red);

                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();

                    }
                    if (ImGui.BeginTabItem("Gold Saucer"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("squadEmotesSaucer", SquadEmoteSaucerStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, SquadEmoteSaucerStrings);

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsEmoteUnlocked(118) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(119) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(171) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(81) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(216) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(237) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(238) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();

                    }
                    if (ImGui.BeginTabItem("Squadron"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("squadEmotesSquadron", SquadEmoteSquadronStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, SquadEmoteSquadronStrings);

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsEmoteUnlocked(155) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(156) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(157) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(158) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();

                    }
                    if (ImGui.BeginTabItem("GC Seals"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("squadEmotesGC", SquadEmoteGCStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, SquadEmoteGCStrings);

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsEmoteUnlocked(164) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(165) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(82) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();

                    }
                    if (ImGui.BeginTabItem("Hunts"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("squadEmotesHunts", SquadEmoteHuntStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, SquadEmoteHuntStrings);

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsEmoteUnlocked(170) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(169) ? Green : Red);

                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();

                    }
                    if (ImGui.BeginTabItem("PvP"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("squadEmotesPvP", SquadEmotePvPStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, SquadEmotePvPStrings);

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsEmoteUnlocked(182) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(196) ? Green : Red);

                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();

                    }
                    if (ImGui.BeginTabItem("Deep/Variant Dungeon"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("squadEmotesDeep", SquadEmoteDeepDungeonStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, SquadEmoteDeepDungeonStrings);

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsEmoteUnlocked(180) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(246) ? Green : Red);

                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();

                    }
                    if (ImGui.BeginTabItem("Eureka"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("squadEmotesEureka", SquadEmoteEurekaStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, SquadEmoteEurekaStrings);

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsEmoteUnlocked(181) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(189) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(195) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();

                    }
                    if (ImGui.BeginTabItem("Bozja"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("squadEmotesBozja", SquadEmoteBozjaStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, SquadEmoteBozjaStrings);

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsEmoteUnlocked(214) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(215) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(222) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();

                    }
                    if (ImGui.BeginTabItem("Treasure Hunts"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("squadEmotesTreasure", SquadEmoteTreasureStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, SquadEmoteTreasureStrings);

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsEmoteUnlocked(188) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(224) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(225) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(226) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(227) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();

                    }
                    if (ImGui.BeginTabItem("Ishgardian Restoration"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("squadEmotesResto", SquadEmoteRestoStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, SquadEmoteRestoStrings);

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsEmoteUnlocked(203) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(208) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(206) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(207) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(213) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(220) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(221) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(223) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();

                    }
                    if (ImGui.BeginTabItem("Mog Station"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("squadEmotesMog", SquadEmoteMogStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, SquadEmoteMogStrings);

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsEmoteUnlocked(109) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(110) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(125) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(131) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(135) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(132) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(136) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(130) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(134) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(124) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(146) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(149) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(143) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(128) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(129) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(142) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(153) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(65) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(66) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(67) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(62) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(178) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(63) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(173) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(174) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(197) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(185) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(186) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(202) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(205) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(192) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(193) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(209) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(212) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(210) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(211) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(229) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(230) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(239) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(245) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                        if (ImGui.BeginTabItem("Other"))
                        {
                            ImGui.Unindent();
                            ImGui.Unindent();

                            if (ImGui.BeginTable("squadEmotesOther", SquadEmoteOtherStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                            {
                                SetUpSquadTableHeaders(0, SquadEmoteOtherStrings);

                                foreach (var c in charas)
                                {
                                    DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                    SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                    SetCellBackground(c.IsEmoteUnlocked(204) ? Green : Red);
                                    SetCellBackground(c.IsEmoteUnlocked(113) ? Green : Red);
                                }
                                ImGui.EndTable();
                            }
                            ImGui.EndTabItem();
                        }
                    }
                    ImGui.EndTabBar();
                }
                ImGui.EndTabItem();
            }

        }
    }
}
