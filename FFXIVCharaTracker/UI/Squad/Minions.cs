using FFXIVCharaTracker.DB;
using ImGuiNET;

namespace FFXIVCharaTracker
{
    internal partial class PluginUI
    {
        internal void DrawSquadMinionsSection(List<Chara> charas)
        {
            if (ImGui.BeginTabItem("Minions"))
            {
                ImGui.Indent();

                var lastAccount = -1;
                var lastWorld = 0u;

                if (ImGui.BeginTabBar("squadMinions"))
                {
                    if (ImGui.BeginTabItem("Achievements"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("SquadMinionAchievement", SquadMinionAchievementStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, SquadMinionAchievementStrings);

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsMinionUnlocked(54) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(36) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(6) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(7) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(8) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(51) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(75) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(71) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(67) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(76) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(77) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(40) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(49) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(85) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(118) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(84) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(167) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(163) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(165) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(164) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(234) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(240) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(288) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(375) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(367) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(378) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(396) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(410) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(408) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Bozja"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("SquadMinionBozja", SquadMinionBozjaStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, SquadMinionBozjaStrings);

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsMinionUnlocked(267) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(271) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(272) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(273) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(265) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(275) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(268) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(279) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(283) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(284) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(278) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(290) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(312) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(303) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(329) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(327) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(321) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(334) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(348) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(383) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(389) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(404) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(418) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Crafted"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("SquadMinionCrafted", SquadMinionCraftedStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, SquadMinionCraftedStrings);

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsMinionUnlocked(22) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(29) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(39) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(53) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(43) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(66) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(81) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(95) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(100) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(136) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(143) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(140) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(147) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(158) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(168) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(169) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(170) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(171) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(185) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(186) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(263) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(261) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(262) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(255) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(265) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(275) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(284) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(278) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(282) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(294) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(303) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(327) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(414) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(436) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(475) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Deep Dungeon"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("SquadMinionDeep", SquadMinionDeepStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, SquadMinionDeepStrings);

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsMinionUnlocked(23) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(27) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(16) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(56) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(80) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(97) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(96) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(112) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(139) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(142) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(134) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(141) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(146) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(137) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(138) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(157) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(166) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(162) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(168) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(180) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(169) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(170) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(171) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(197) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(185) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(186) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(196) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(198) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(216) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(219) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(190) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(237) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(244) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(245) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(246) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(241) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(258) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(247) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(263) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(261) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(262) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(272) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(279) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(290) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(292) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(312) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(321) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(336) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(339) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(347) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(333) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(334) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(349) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(353) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(355) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(361) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(356) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(411) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(433) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(431) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(425) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(473) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Dungeon"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("SquadMinionDungeon", SquadMinionDungeonStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, SquadMinionDungeonStrings);

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsMinionUnlocked(12) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(42) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(44) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(47) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(80) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(102) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(57) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(112) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(139) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(142) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(134) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(141) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(137) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(138) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(166) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(178) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(179) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(180) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(189) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(216) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(226) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(245) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(254) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(258) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(247) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(249) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(252) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(257) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(272) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(279) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(290) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(312) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(321) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(336) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(339) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(347) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(352) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(333) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(334) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(349) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(361) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(374) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(385) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(405) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(411) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(433) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(434) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(424) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(426) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(431) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(435) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(427) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(425) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(447) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(460) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(471) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Eureka"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("SquadMinionEureka", SquadMinionEurekaStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, SquadMinionEurekaStrings);

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsMinionUnlocked(178) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(285) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(287) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(286) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(295) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(296) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(315) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(314) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(318) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(319) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("FATE"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("SquadMinionFate", SquadMinionFateStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, SquadMinionFateStrings);

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsMinionUnlocked(14) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(18) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(31) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(34) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(154) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(242) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(274) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(338) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(350) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(351) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(346) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(368) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(377) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(423) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(442) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Gathering"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("SquadMinionGather", SquadMinionGatherStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, SquadMinionGatherStrings);

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsMinionUnlocked(24) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(30) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(48) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(38) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(188) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(237) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(244) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Gold Saucer"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("SquadMinionSaucer", SquadMinionSaucerStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, SquadMinionSaucerStrings);

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsMinionUnlocked(83) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(106) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(20) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(117) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(174) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(187) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(379) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(470) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Hunts"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("SquadMinionHunt", SquadMinionHuntStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, SquadMinionHuntStrings);

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsMinionUnlocked(82) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(93) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(148) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(144) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(243) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(256) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(340) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(326) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(358) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(428) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Island Sanctuary"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("SquadMinionSanctuary", SquadMinionSanctuaryStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, SquadMinionSanctuaryStrings);

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsMinionUnlocked(456) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(468) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Other"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("SquadMinionOther", SquadMinionOtherStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, SquadMinionOtherStrings);

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsMinionUnlocked(65) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(86) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(87) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(88) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(89) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(90) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(115) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(116) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(236) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(386) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Mog Station"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("SquadMinionMog", SquadMinionMogStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, SquadMinionMogStrings);

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsMinionUnlocked(5) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(46) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(64) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(63) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(79) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(98) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(99) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(91) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(107) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(108) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(109) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(105) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(129) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(131) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(132) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(145) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(159) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(150) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(103) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(121) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(177) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(192) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(225) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(221) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(222) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(227) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(220) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(238) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(248) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(250) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(280) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(293) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(313) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(307) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(308) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(311) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(309) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(310) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(325) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(331) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(382) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(401) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(402) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(403) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(420) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(421) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(400) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(450) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Shop"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("SquadMinionShop", SquadMinionShopStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, SquadMinionShopStrings);

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsMinionUnlocked(3) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(9) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(10) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(11) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(1) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(13) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(17) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(25) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(26) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(28) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(37) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(2) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("PvP"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("SquadMinionPvP", SquadMinionPvPStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, SquadMinionPvPStrings);

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsMinionUnlocked(183) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(191) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(291) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(324) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(446) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Quests"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("SquadMinionSidequest", SquadMinionSidequestStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, SquadMinionSidequestStrings);

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsMinionUnlocked(15) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(33) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(41) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(52) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(19) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(32) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(35) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(45) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(21) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(119) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(130) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(133) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(149) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(173) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(181) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(193) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(224) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(230) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(231) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(276) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(300) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(304) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(337) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(306) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(381) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(441) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(437) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Raids"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("SquadMinionRaid", SquadMinionRaidStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, SquadMinionRaidStrings);

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsMinionUnlocked(92) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(101) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(160) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(176) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(195) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(215) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(232) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(259) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(281) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(299) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(305) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(270) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(341) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(364) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(365) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(332) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(394) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(395) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(398) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(415) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(419) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(440) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(451) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(466) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(474) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Ishgardian Restoration"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("SquadMinionResto", SquadMinionRestoStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, SquadMinionRestoStrings);

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsMinionUnlocked(66) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(81) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(97) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(136) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(139) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(137) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(138) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(140) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(157) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(162) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(180) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(189) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(197) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(216) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(226) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(190) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(194) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(357) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(360) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(372) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(373) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(363) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(384) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(388) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(406) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Treasure Maps"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("SquadMinionTreasure", SquadMinionTreasureStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, SquadMinionTreasureStrings);

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsMinionUnlocked(23) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(27) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(16) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(56) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(80) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(97) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(57) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(112) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(139) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(142) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(134) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(141) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(137) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(138) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(157) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(197) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(253) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(269) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(289) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(316) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(330) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(335) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(366) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(407) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(443) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(477) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(465) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Trials"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("SquadMinionTrial", SquadMinionTrialStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, SquadMinionTrialStrings);

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsMinionUnlocked(104) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(122) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(301) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(342) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Beast Tribes"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("SquadMinionTribe", SquadMinionTribeStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, SquadMinionTribeStrings);

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsMinionUnlocked(50) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(58) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(60) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(61) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(123) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(124) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(125) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(59) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(126) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(127) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(135) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(172) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(175) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(156) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(184) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(235) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(266) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(277) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(302) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(323) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(322) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(328) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(354) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(369) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(370) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(380) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(444) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(457) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(472) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Variant/Criterion"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("SquadMinionVandC", SquadMinionVandCStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, SquadMinionVandCStrings);

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsMinionUnlocked(463) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(464) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Ventures"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("SquadMinionVenture", SquadMinionVentureStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, SquadMinionVentureStrings);

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsMinionUnlocked(56) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(94) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(96) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(111) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(110) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(146) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(246) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(241) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(267) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(271) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(273) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(268) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(353) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(355) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(359) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(362) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(386) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(438) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(422) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(432) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(439) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(445) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(448) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(453) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(449) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Voyages"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("SquadMinionVoyage", SquadMinionVoyageStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, SquadMinionVoyageStrings);

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsMinionUnlocked(283) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(329) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(348) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(356) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(371) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(397) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(413) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(469) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Wondrous Tails"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("SquadMinionTails", SquadMinionTailsStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, SquadMinionTailsStrings);

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsMinionUnlocked(217) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(218) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(228) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(260) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(264) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(298) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(344) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(345) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(387) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(409) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(429) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(462) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(467) ? Green : Red);
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