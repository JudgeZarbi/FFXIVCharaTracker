using FFXIVCharaTracker.DB;
using ImGuiNET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFXIVCharaTracker
{
    internal partial class PluginUI
    {
        internal void DrawSquadOrchestrionSection(List<Chara> charas)
        {
            if (ImGui.BeginTabItem("Orchestrion Rolls"))
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

                        if (ImGui.BeginTable("SquadOrchestrionAchievement", SquadOrchestrionAchievementStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, SquadOrchestrionAchievementStrings);

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsOrchestrionUnlocked(12) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(28) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(75) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(84) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(201) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(291) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(271) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(436) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Bozja"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("SquadOrchestrionBozja", SquadOrchestrionBozjaStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, SquadOrchestrionBozjaStrings);

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsOrchestrionUnlocked(387) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(388) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(389) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(390) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(391) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(392) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(413) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(414) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(415) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(438) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Crafted"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("SquadOrchestrionCrafted", SquadOrchestrionCraftedStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, SquadOrchestrionCraftedStrings);

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsOrchestrionUnlocked(35) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(36) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(29) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(37) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(30) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(38) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(18) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(31) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(19) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(32) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(39) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(33) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(40) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(34) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(41) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(42) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(23) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(14) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(22) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(43) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(15) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(26) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(44) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(45) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(9) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(21) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(20) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(10) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(11) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(24) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(25) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(68) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(69) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(70) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(71) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(72) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(74) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(54) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(55) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(56) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(104) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(105) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(106) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(107) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(91) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(133) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(134) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(135) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(136) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(137) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(138) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(157) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(158) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(159) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(160) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(184) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(185) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(176) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(215) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(216) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(222) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(240) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(241) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(230) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(252) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(268) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(283) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(287) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(313) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(314) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(343) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(366) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(386) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(385) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(411) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(437) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(482) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(483) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(507) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(508) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(536) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(565) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Deep Dungeon"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("SquadOrchestrionDeep", SquadOrchestrionDeepStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, SquadOrchestrionDeepStrings);

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsOrchestrionUnlocked(23) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(26) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(21) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(20) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(25) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(67) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(64) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(97) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(98) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(99) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(100) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(156) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(183) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(211) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(229) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(224) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(225) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(251) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(250) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(317) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(318) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(319) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(320) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(321) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(322) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(324) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(323) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(344) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(393) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(416) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(475) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(476) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(477) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(478) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(479) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(480) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(481) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(506) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(537) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(568) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(583) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(584) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Dungeon"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("SquadOrchestrionDungeon", SquadOrchestrionDungeonStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, SquadOrchestrionDungeonStrings);

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsOrchestrionUnlocked(67) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(62) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(64) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(65) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(66) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(102) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(101) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(130) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(155) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(156) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(180) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(181) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(182) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(183) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(213) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(212) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(210) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(211) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(227) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(228) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(229) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(249) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(248) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(247) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(251) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(250) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(269) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(317) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(318) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(319) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(320) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(321) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(322) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(324) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(323) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(326) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(325) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(344) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(368) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(369) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(370) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(396) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(395) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(393) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(431) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(426) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(416) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(432) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(439) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(502) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(475) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(476) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(477) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(478) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(479) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(480) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(481) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(501) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(500) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(506) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(530) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(529) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(528) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(559) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(560) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(537) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(538) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(555) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(556) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(567) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(575) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(576) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(577) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(574) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(578) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(579) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Eureka"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("SquadOrchestrionEureka", SquadOrchestrionEurekaStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, SquadOrchestrionEurekaStrings);

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsOrchestrionUnlocked(208) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(209) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(288) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(289) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(290) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("FATE"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("SquadOrchestrionFate", SquadOrchestrionFateStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, SquadOrchestrionFateStrings);

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsOrchestrionUnlocked(120) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(161) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(162) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(331) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(332) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(307) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(308) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(309) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(310) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(311) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(312) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(334) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(335) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(336) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(337) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(338) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(339) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(340) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(341) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(379) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(380) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(378) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(487) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(488) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(489) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(490) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(491) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(492) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(493) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(494) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(515) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(516) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(517) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(518) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(519) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(520) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(521) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(523) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(524) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(522) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(557) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(558) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Gathering"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("SquadOrchestrionGather", SquadOrchestrionGatherStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, SquadOrchestrionGatherStrings);

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsOrchestrionUnlocked(177) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(284) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(285) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(286) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(443) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Gold Saucer"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("SquadOrchestrionSaucer", SquadOrchestrionSaucerStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, SquadOrchestrionSaucerStrings);

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsOrchestrionUnlocked(27) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(13) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(8) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(7) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(1) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(73) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(96) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(140) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(139) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(200) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(217) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(214) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(270) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(276) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(373) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(430) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(531) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(561) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Hunts"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("SquadOrchestrionHunt", SquadOrchestrionHuntStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, SquadOrchestrionHuntStrings);

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsOrchestrionUnlocked(122) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(163) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(329) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(360) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(361) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(412) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(495) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Island Sanctuary"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("SquadOrchestrionSanctuary", SquadOrchestrionSanctuaryStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, SquadOrchestrionSanctuaryStrings);

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsOrchestrionUnlocked(544) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(545) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Other"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("SquadOrchestrionOther", SquadOrchestrionOtherStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, SquadOrchestrionOtherStrings);

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsOrchestrionUnlocked(17) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(47) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Mog Station"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("SquadOrchestrionMog", SquadOrchestrionMogStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, SquadOrchestrionMogStrings);

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsOrchestrionUnlocked(16) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(60) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(61) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(80) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(81) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(82) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(83) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(114) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(115) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(116) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(148) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(149) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(150) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(191) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(192) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(193) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(220) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(242) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(243) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(244) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(226) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(245) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(272) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(273) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(274) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(277) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(278) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(279) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(280) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(281) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(282) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(305) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(306) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(348) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(358) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(359) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(407) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(408) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(409) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(405) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(406) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(433) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(434) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(435) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(445) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(446) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(447) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(448) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(449) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(450) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(451) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(452) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(453) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(454) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(455) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(456) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(457) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(458) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(459) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(460) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(461) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(462) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(503) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(504) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(505) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(533) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(534) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(535) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(562) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(563) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(588) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(589) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Shop"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("SquadOrchestrionShop", SquadOrchestrionShopStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, SquadOrchestrionShopStrings);

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsOrchestrionUnlocked(2) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(3) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(4) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(6) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(46) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(5) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(49) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(50) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(48) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(58) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(59) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(57) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(51) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(52) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(53) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(63) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(89) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(93) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(90) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(87) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(88) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(94) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(127) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(142) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(143) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(144) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(145) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(119) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(121) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(152) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(151) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(153) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(154) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(164) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(168) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(169) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(170) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(174) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(194) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(195) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(196) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(197) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(219) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(204) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(206) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(221) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(223) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(246) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(532) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(547) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(551) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(552) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(553) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(564) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(548) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(549) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(550) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(585) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(586) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("PvP"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("SquadOrchestrionPvP", SquadOrchestrionPvPStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, SquadOrchestrionPvPStrings);

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsOrchestrionUnlocked(171) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(202) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(346) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(347) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(525) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(526) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(527) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Quests"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("SquadOrchestrionSidequest", SquadOrchestrionSidequestStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, SquadOrchestrionSidequestStrings);

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsOrchestrionUnlocked(79) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(108) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(109) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(110) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(111) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(112) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(113) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(103) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(128) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(146) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(147) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(132) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(131) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(126) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(125) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(124) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(172) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(173) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(189) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(190) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(198) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(199) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(232) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(233) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(266) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(267) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(265) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(292) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(293) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(315) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(316) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(350) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(342) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(353) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(372) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(362) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(399) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(400) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(410) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(470) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(471) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(472) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(473) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(474) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(440) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(469) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(498) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(499) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(509) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(590) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Raids"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("SquadOrchestrionRaid", SquadOrchestrionRaidStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, SquadOrchestrionRaidStrings);

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsOrchestrionUnlocked(141) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(186) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(187) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(188) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(218) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(234) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(235) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(236) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(253) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(254) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(255) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(256) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(257) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(258) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(259) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(260) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(261) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(262) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(263) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(264) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(275) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(294) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(295) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(296) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(297) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(298) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(327) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(333) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(328) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(351) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(354) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(355) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(356) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(357) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(363) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(364) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(365) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(401) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(402) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(403) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(404) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(417) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(418) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(419) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(420) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(464) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(465) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(352) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(467) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(468) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(485) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(486) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(511) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(512) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(513) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(540) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(541) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(542) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(543) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(569) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(570) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(571) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Ishgardian Restoration"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("SquadOrchestrionResto", SquadOrchestrionRestoStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, SquadOrchestrionRestoStrings);

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsOrchestrionUnlocked(123) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(165) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(166) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(167) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(248) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(247) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(349) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(376) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(377) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(382) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(374) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(375) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(398) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(397) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(428) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(427) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(429) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(463) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(441) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(554) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Treasure Maps"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("SquadOrchestrionTreasure", SquadOrchestrionTreasureStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, SquadOrchestrionTreasureStrings);

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsOrchestrionUnlocked(76) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(77) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(78) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(95) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(92) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(129) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(165) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(166) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(167) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(175) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(178) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(203) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(205) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(330) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(381) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(425) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(422) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(423) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(424) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(444) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(496) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(497) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(572) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(573) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Trials"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("SquadOrchestrionTrial", SquadOrchestrionTrialStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, SquadOrchestrionTrialStrings);

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsOrchestrionUnlocked(237) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(238) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(239) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Beast Tribes"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("SquadOrchestrionTribe", SquadOrchestrionTribeStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, SquadOrchestrionTribeStrings);

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsOrchestrionUnlocked(85) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(86) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(117) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(118) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(179) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(207) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(231) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(345) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(371) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(383) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(514) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(546) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(566) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(582) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Variant/Criterion"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("SquadOrchestrionVandC", SquadOrchestrionVandCStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, SquadOrchestrionVandCStrings);

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsOrchestrionUnlocked(539) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Voyages"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("SquadOrchestrionVoyage", SquadOrchestrionVoyageStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, SquadOrchestrionVoyageStrings);

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsOrchestrionUnlocked(394) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(421) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(442) ? Green : Red);
                                SetCellBackground(c.IsOrchestrionUnlocked(587) ? Green : Red);
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
