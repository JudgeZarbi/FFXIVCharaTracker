using FFXIVCharaTracker.DB;
using ImGuiNET;

namespace FFXIVCharaTracker
{
    internal partial class PluginUI
    {
        internal void DrawSquadMountsSection(List<Chara> charas)
        {
            if (ImGui.BeginTabItem("Mounts"))
            {
                ImGui.Indent();

                var lastAccount = -1;
                var lastWorld = 0u;

                if (ImGui.BeginTabBar("squadMounts"))
                {
                    if (ImGui.BeginTabItem("Achievements"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("squadMountsAchievement", squadMountsAchievementStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, squadMountsAchievementStrings);

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsMountUnlocked(9) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(18) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(21) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(32) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(33) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(36) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(37) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(38) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(44) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(48) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(56) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(80) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(83) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(91) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(95) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(96) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(102) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(122) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(123) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(124) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(127) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(141) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(145) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(168) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(166) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(141) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(186) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(183) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(190) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(187) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(197) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(200) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(204) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(218) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(216) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(235) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(246) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(267) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(304) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Tribes"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("squadMountsTribe", squadMountsTribeStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, squadMountsTribeStrings);

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsMountUnlocked(19) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(20) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(26) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(27) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(35) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(53) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(72) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(86) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(136) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(146) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(148) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(164) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(201) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(215) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(223) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(287) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(298) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Bozja"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("squadMountsBozja", squadMountsBozjaStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, squadMountsBozjaStrings);

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsMountUnlocked(213) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(224) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(241) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(212) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Crafted"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("squadMountsCrafted", squadMountsCraftedStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, squadMountsCraftedStrings);

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsMountUnlocked(140) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(193) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Deep Dungeon"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("squadMountsDeep", squadMountsDeepStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, squadMountsDeepStrings);

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsMountUnlocked(92) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(100) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(159) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(303) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Dungeon"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("squadMountsDungeon", squadMountsDungeonStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, squadMountsDungeonStrings);

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsMountUnlocked(121) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Eureka"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("squadMountsEureka", squadMountsEurekaStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, squadMountsEurekaStrings);

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsMountUnlocked(150) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(178) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(184) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("FATE"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("squadMountsFate", squadMountsFateStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, squadMountsFateStrings);

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsMountUnlocked(130) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(191) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(268) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(273) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Mog Station/Collector's Edition"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("squadMountsMog", squadMountsMogStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, squadMountsMogStrings);

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsMountUnlocked(8) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(25) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(34) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(42) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(41) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(54) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(52) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(59) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(62) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(68) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(69) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(82) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(74) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(84) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(106) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(111) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(93) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(97) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(99) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(138) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(139) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(135) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(152) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(153) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(143) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(160) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(71) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(171) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(177) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(175) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(170) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(194) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(195) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(206) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(214) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(220) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(222) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(232) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(233) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(250) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(247) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(237) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(269) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(294) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(279) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(300) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(301) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(310) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("PvP"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("squadMountsPvp", squadMountsPvpStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, squadMountsPvpStrings);

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsMountUnlocked(174) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Raid"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("squadMountsRaid", squadMountsRaidStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, squadMountsRaidStrings);

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsMountUnlocked(58) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(101) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(126) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(156) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(173) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(188) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(219) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(234) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(265) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(305) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Ishgardian Restoration"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("squadMountsSkybuilder", squadMountsSkybuilderStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, squadMountsSkybuilderStrings);

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsMountUnlocked(67) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(211) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(208) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(209) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(225) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(236) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(242) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(243) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Treasure Hunt"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("squadMountsTreasure", squadMountsTreasureStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, squadMountsTreasureStrings);

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsMountUnlocked(281) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(313) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(314) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Trial"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("squadMountsTrial", squadMountsTrialStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, squadMountsTrialStrings);

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsMountUnlocked(22) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(28) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(29) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(30) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(31) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(40) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(43) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(75) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(76) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(77) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(78) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(90) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(98) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(104) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(115) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(116) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(133) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(144) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(158) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(161) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(172) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(182) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(189) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(192) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(205) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(217) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(226) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(238) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(249) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(261) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(262) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(293) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(306) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(315) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Voyages"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("squadMountsVoyage", squadMountsVoyageStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, squadMountsVoyageStrings);

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsMountUnlocked(73) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Wondrous Tails/Faux Hollows"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("squadMountsTails", squadMountsTailsStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, squadMountsTailsStrings);

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsMountUnlocked(130) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(231) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(248) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(266) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(288) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(299) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Shop"))
                    {
                        ImGui.Indent();
                        if (ImGui.BeginTabBar("squadMountsShop"))
                        {
                            if (ImGui.BeginTabItem("Gil"))
                            {
                                ImGui.Unindent();
                                ImGui.Unindent();
                                ImGui.Unindent();

                                if (ImGui.BeginTable("squadMountsGil", squadMountsGilStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                                {
                                    SetUpSquadTableHeaders(0, squadMountsGilStrings);

                                    foreach (var c in charas)
                                    {
                                        DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                        SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                        SetCellBackground(c.IsMountUnlocked(252) ? Green : Red);
                                        SetCellBackground(c.IsMountUnlocked(253) ? Green : Red);
                                        SetCellBackground(c.IsMountUnlocked(141) ? Green : Red);
                                        SetCellBackground(c.IsMountUnlocked(317) ? Green : Red);
                                    }
                                    ImGui.EndTable();
                                }
                                ImGui.EndTabItem();
                            }
                            if (ImGui.BeginTabItem("MGP"))
                            {
                                ImGui.Unindent();
                                ImGui.Unindent();
                                ImGui.Unindent();

                                if (ImGui.BeginTable("squadMountsSaucer", squadMountsSaucerStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                                {
                                    SetUpSquadTableHeaders(0, squadMountsSaucerStrings);

                                    foreach (var c in charas)
                                    {
                                        DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                        SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                        SetCellBackground(c.IsMountUnlocked(46) ? Green : Red);
                                        SetCellBackground(c.IsMountUnlocked(49) ? Green : Red);
                                        SetCellBackground(c.IsMountUnlocked(110) ? Green : Red);
                                        SetCellBackground(c.IsMountUnlocked(142) ? Green : Red);
                                        SetCellBackground(c.IsMountUnlocked(154) ? Green : Red);
                                        SetCellBackground(c.IsMountUnlocked(180) ? Green : Red);
                                        SetCellBackground(c.IsMountUnlocked(284) ? Green : Red);
                                        SetCellBackground(c.IsMountUnlocked(312) ? Green : Red);
                                    }
                                    ImGui.EndTable();
                                }
                                ImGui.EndTabItem();
                            }
                            if (ImGui.BeginTabItem("Hunt Currency"))
                            {
                                ImGui.Unindent();
                                ImGui.Unindent();
                                ImGui.Unindent();

                                if (ImGui.BeginTable("squadMountsHunts", squadMountsHuntsStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                                {
                                    SetUpSquadTableHeaders(0, squadMountsHuntsStrings);

                                    foreach (var c in charas)
                                    {
                                        DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                        SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                        SetCellBackground(c.IsMountUnlocked(70) ? Green : Red);
                                        SetCellBackground(c.IsMountUnlocked(207) ? Green : Red);
                                        SetCellBackground(c.IsMountUnlocked(291) ? Green : Red);
                                    }
                                    ImGui.EndTable();
                                }
                                ImGui.EndTabItem();
                            }
                            if (ImGui.BeginTabItem("Island Sanctuary"))
                            {
                                ImGui.Unindent();
                                ImGui.Unindent();
                                ImGui.Unindent();

                                if (ImGui.BeginTable("squadMountsSanctuary", squadMountsSanctuaryStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                                {
                                    SetUpSquadTableHeaders(0, squadMountsSanctuaryStrings);

                                    foreach (var c in charas)
                                    {
                                        DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                        SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                        SetCellBackground(c.IsMountUnlocked(277) ? Green : Red);
                                        SetCellBackground(c.IsMountUnlocked(255) ? Green : Red);
                                        SetCellBackground(c.IsMountUnlocked(256) ? Green : Red);
                                        SetCellBackground(c.IsMountUnlocked(257) ? Green : Red);
                                        SetCellBackground(c.IsMountUnlocked(286) ? Green : Red);
                                    }
                                    ImGui.EndTable();
                                }
                                ImGui.EndTabItem();
                            }
                            ImGui.EndTabBar();
                        }
                        ImGui.EndTabItem();
                    }
                    ImGui.EndTabBar();
                }
                ImGui.EndTabItem();
            }

        }
    }
}
