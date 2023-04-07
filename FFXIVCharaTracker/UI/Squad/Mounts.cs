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

                        if (ImGui.BeginTable("SquadMountAchievement", SquadMountAchievementStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, SquadMountAchievementStrings);

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
                                SetCellBackground(c.IsMountUnlocked(185) ? Green : Red);
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
                                SetCellBackground(c.IsMountUnlocked(308) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Bozja"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("SquadMountBozja", SquadMountBozjaStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, SquadMountBozjaStrings);

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

                        if (ImGui.BeginTable("SquadMountCrafted", SquadMountCraftedStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, SquadMountCraftedStrings);

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

                        if (ImGui.BeginTable("SquadMountDeep", SquadMountDeepStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, SquadMountDeepStrings);

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsMountUnlocked(92) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(100) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(159) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(292) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Dungeon"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("SquadMountDungeon", SquadMountDungeonStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, SquadMountDungeonStrings);

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

                        if (ImGui.BeginTable("SquadMountEureka", SquadMountEurekaStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, SquadMountEurekaStrings);

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

                        if (ImGui.BeginTable("SquadMountFate", SquadMountFateStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, SquadMountFateStrings);

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
                    if (ImGui.BeginTabItem("Gold Saucer"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("SquadMountSaucer", SquadMountSaucerStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, SquadMountSaucerStrings);

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
                    if (ImGui.BeginTabItem("Hunts"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("SquadMountHunt", SquadMountHuntStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, SquadMountHuntStrings);

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

                        if (ImGui.BeginTable("SquadMountSanctuary", SquadMountSanctuaryStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, SquadMountSanctuaryStrings);

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
                    if (ImGui.BeginTabItem("Mog Station"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("SquadMountMog", SquadMountMogStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, SquadMountMogStrings);

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
                    if (ImGui.BeginTabItem("Shop"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("SquadMountShop", SquadMountShopStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, SquadMountShopStrings);

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsMountUnlocked(252) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(253) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(316) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(317) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("PvP"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("SquadMountPvP", SquadMountPvPStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, SquadMountPvPStrings);

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
                    if (ImGui.BeginTabItem("Quests"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("SquadMountSidequest", SquadMountSidequestStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, SquadMountSidequestStrings);

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsMountUnlocked(1) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(6) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(15) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(47) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(50) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(55) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(45) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(105) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(125) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(181) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(230) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(245) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(254) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(263) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(311) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Raids"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("SquadMountRaid", SquadMountRaidStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, SquadMountRaidStrings);

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

                        if (ImGui.BeginTable("SquadMountResto", SquadMountRestoStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, SquadMountRestoStrings);

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
                    if (ImGui.BeginTabItem("Treasure Maps"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("SquadMountTreasure", SquadMountTreasureStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, SquadMountTreasureStrings);

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
                    if (ImGui.BeginTabItem("Trials"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("SquadMountTrial", SquadMountTrialStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, SquadMountTrialStrings);

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
                    if (ImGui.BeginTabItem("Beast Tribes"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("SquadMountTribe", SquadMountTribeStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, SquadMountTribeStrings);

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
                                SetCellBackground(c.IsMountUnlocked(285) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Variant/Criterion"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("SquadMountVandC", SquadMountVandCStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, SquadMountVandCStrings);

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsMountUnlocked(303) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Voyages"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("SquadMountVoyage", SquadMountVoyageStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, SquadMountVoyageStrings);

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsMountUnlocked(73) ? Green : Red);
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
                    ImGui.EndTabBar();
                }
                ImGui.EndTabItem();
            }
        }
    }
}
