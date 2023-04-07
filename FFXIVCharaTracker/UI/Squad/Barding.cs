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
        internal void DrawSquadBardingsSection(List<Chara> charas)
        {
            if (ImGui.BeginTabItem("Barding"))
            {
                ImGui.Indent();

                var lastAccount = -1;
                var lastWorld = 0u;

                if (ImGui.BeginTabBar("squadBarding"))
                {
                    if (ImGui.BeginTabItem("Achievements"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("SquadBardingAchievement", SquadBardingAchievementStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, SquadBardingAchievementStrings);

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsBardingUnlocked(6029) ? Green : Red);
                                SetCellBackground(c.IsBardingUnlocked(6995) ? Green : Red);
                                SetCellBackground(c.IsBardingUnlocked(7551) ? Green : Red);
                                SetCellBackground(c.IsBardingUnlocked(8571) ? Green : Red);
                                SetCellBackground(c.IsBardingUnlocked(6032) ? Green : Red);
                                SetCellBackground(c.IsBardingUnlocked(13111) ? Green : Red);
                                SetCellBackground(c.IsBardingUnlocked(15129) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Bozja"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("SquadBardingBozja", SquadBardingBozjaStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, SquadBardingBozjaStrings);

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsBardingUnlocked(12082) ? Green : Red);
                                SetCellBackground(c.IsBardingUnlocked(12083) ? Green : Red);
                                SetCellBackground(c.IsBardingUnlocked(14080) ? Green : Red);
                                SetCellBackground(c.IsBardingUnlocked(15427) ? Green : Red);
                                SetCellBackground(c.IsBardingUnlocked(16557) ? Green : Red);
                                SetCellBackground(c.IsBardingUnlocked(17522) ? Green : Red);
                                SetCellBackground(c.IsBardingUnlocked(20558) ? Green : Red);
                                SetCellBackground(c.IsBardingUnlocked(21042) ? Green : Red);
                                SetCellBackground(c.IsBardingUnlocked(21924) ? Green : Red);
                                SetCellBackground(c.IsBardingUnlocked(23037) ? Green : Red);
                                SetCellBackground(c.IsBardingUnlocked(24143) ? Green : Red);
                                SetCellBackground(c.IsBardingUnlocked(24799) ? Green : Red);
                                SetCellBackground(c.IsBardingUnlocked(32824) ? Green : Red);
                                SetCellBackground(c.IsBardingUnlocked(33672) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Crafted"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("SquadBardingCrafted", SquadBardingCraftedStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, SquadBardingCraftedStrings);

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsBardingUnlocked(7552) ? Green : Red);
                                SetCellBackground(c.IsBardingUnlocked(8570) ? Green : Red);
                                SetCellBackground(c.IsBardingUnlocked(9355) ? Green : Red);
                                SetCellBackground(c.IsBardingUnlocked(12991) ? Green : Red);
                                SetCellBackground(c.IsBardingUnlocked(12081) ? Green : Red);
                                SetCellBackground(c.IsBardingUnlocked(12082) ? Green : Red);
                                SetCellBackground(c.IsBardingUnlocked(12083) ? Green : Red);
                                SetCellBackground(c.IsBardingUnlocked(14080) ? Green : Red);
                                SetCellBackground(c.IsBardingUnlocked(15427) ? Green : Red);
                                SetCellBackground(c.IsBardingUnlocked(16557) ? Green : Red);
                                SetCellBackground(c.IsBardingUnlocked(17522) ? Green : Red);
                                SetCellBackground(c.IsBardingUnlocked(20558) ? Green : Red);
                                SetCellBackground(c.IsBardingUnlocked(20560) ? Green : Red);
                                SetCellBackground(c.IsBardingUnlocked(21042) ? Green : Red);
                                SetCellBackground(c.IsBardingUnlocked(21924) ? Green : Red);
                                SetCellBackground(c.IsBardingUnlocked(23037) ? Green : Red);
                                SetCellBackground(c.IsBardingUnlocked(24143) ? Green : Red);
                                SetCellBackground(c.IsBardingUnlocked(24799) ? Green : Red);
                                SetCellBackground(c.IsBardingUnlocked(27986) ? Green : Red);
                                SetCellBackground(c.IsBardingUnlocked(27987) ? Green : Red);
                                SetCellBackground(c.IsBardingUnlocked(28616) ? Green : Red);
                                SetCellBackground(c.IsBardingUnlocked(29402) ? Green : Red);
                                SetCellBackground(c.IsBardingUnlocked(30678) ? Green : Red);
                                SetCellBackground(c.IsBardingUnlocked(32823) ? Green : Red);
                                SetCellBackground(c.IsBardingUnlocked(33673) ? Green : Red);
                                SetCellBackground(c.IsBardingUnlocked(36011) ? Green : Red);
                                SetCellBackground(c.IsBardingUnlocked(36012) ? Green : Red);
                                SetCellBackground(c.IsBardingUnlocked(36849) ? Green : Red);
                                SetCellBackground(c.IsBardingUnlocked(38440) ? Green : Red);
                                SetCellBackground(c.IsBardingUnlocked(39470) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Deep Dungeon"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("SquadBardingDeep", SquadBardingDeepStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, SquadBardingDeepStrings);

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsBardingUnlocked(7552) ? Green : Red);
                                SetCellBackground(c.IsBardingUnlocked(8570) ? Green : Red);
                                SetCellBackground(c.IsBardingUnlocked(9355) ? Green : Red);
                                SetCellBackground(c.IsBardingUnlocked(12082) ? Green : Red);
                                SetCellBackground(c.IsBardingUnlocked(12083) ? Green : Red);
                                SetCellBackground(c.IsBardingUnlocked(14080) ? Green : Red);
                                SetCellBackground(c.IsBardingUnlocked(15427) ? Green : Red);
                                SetCellBackground(c.IsBardingUnlocked(16558) ? Green : Red);
                                SetCellBackground(c.IsBardingUnlocked(16557) ? Green : Red);
                                SetCellBackground(c.IsBardingUnlocked(17522) ? Green : Red);
                                SetCellBackground(c.IsBardingUnlocked(20558) ? Green : Red);
                                SetCellBackground(c.IsBardingUnlocked(20560) ? Green : Red);
                                SetCellBackground(c.IsBardingUnlocked(23037) ? Green : Red);
                                SetCellBackground(c.IsBardingUnlocked(24143) ? Green : Red);
                                SetCellBackground(c.IsBardingUnlocked(24799) ? Green : Red);
                                SetCellBackground(c.IsBardingUnlocked(27986) ? Green : Red);
                                SetCellBackground(c.IsBardingUnlocked(27987) ? Green : Red);
                                SetCellBackground(c.IsBardingUnlocked(29402) ? Green : Red);
                                SetCellBackground(c.IsBardingUnlocked(32823) ? Green : Red);
                                SetCellBackground(c.IsBardingUnlocked(33673) ? Green : Red);
                                SetCellBackground(c.IsBardingUnlocked(36011) ? Green : Red);
                                SetCellBackground(c.IsBardingUnlocked(36012) ? Green : Red);
                                SetCellBackground(c.IsBardingUnlocked(39471) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Eureka"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("SquadBardingEureka", SquadBardingEurekaStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, SquadBardingEurekaStrings);

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsBardingUnlocked(21191) ? Green : Red);
                                SetCellBackground(c.IsBardingUnlocked(24144) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("FATE"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("SquadBardingFate", SquadBardingFateStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, SquadBardingFateStrings);

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsBardingUnlocked(6030) ? Green : Red);
                                SetCellBackground(c.IsBardingUnlocked(12077) ? Green : Red);
                                SetCellBackground(c.IsBardingUnlocked(20559) ? Green : Red);
                                SetCellBackground(c.IsBardingUnlocked(21043) ? Green : Red);
                                SetCellBackground(c.IsBardingUnlocked(27988) ? Green : Red);
                                SetCellBackground(c.IsBardingUnlocked(27989) ? Green : Red);
                                SetCellBackground(c.IsBardingUnlocked(36014) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Gathering"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("SquadBardingGather", SquadBardingGatherStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, SquadBardingGatherStrings);

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsBardingUnlocked(21925) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Gold Saucer"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("SquadBardingSaucer", SquadBardingSaucerStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, SquadBardingSaucerStrings);

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsBardingUnlocked(10083) ? Green : Red);
                                SetCellBackground(c.IsBardingUnlocked(16926) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Hunts"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("SquadBardingHunt", SquadBardingHuntStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, SquadBardingHuntStrings);

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsBardingUnlocked(12078) ? Green : Red);
                                SetCellBackground(c.IsBardingUnlocked(20561) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Island Sanctuary"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("SquadBardingSanctuary", SquadBardingSanctuaryStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, SquadBardingSanctuaryStrings);

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsBardingUnlocked(38441) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Mog Station"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("SquadBardingMog", SquadBardingMogStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, SquadBardingMogStrings);

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsBardingUnlocked(14860) ? Green : Red);
                                SetCellBackground(c.IsBardingUnlocked(15428) ? Green : Red);
                                SetCellBackground(c.IsBardingUnlocked(6031) ? Green : Red);
                                SetCellBackground(c.IsBardingUnlocked(7056) ? Green : Red);
                                SetCellBackground(c.IsBardingUnlocked(37482) ? Green : Red);
                                SetCellBackground(c.IsBardingUnlocked(8718) ? Green : Red);
                                SetCellBackground(c.IsBardingUnlocked(10082) ? Green : Red);
                                SetCellBackground(c.IsBardingUnlocked(14081) ? Green : Red);
                                SetCellBackground(c.IsBardingUnlocked(16559) ? Green : Red);
                                SetCellBackground(c.IsBardingUnlocked(16560) ? Green : Red);
                                SetCellBackground(c.IsBardingUnlocked(20562) ? Green : Red);
                                SetCellBackground(c.IsBardingUnlocked(20563) ? Green : Red);
                                SetCellBackground(c.IsBardingUnlocked(28617) ? Green : Red);
                                SetCellBackground(c.IsBardingUnlocked(36013) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Shop"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("SquadBardingShop", SquadBardingShopStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, SquadBardingShopStrings);

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsBardingUnlocked(6020) ? Green : Red);
                                SetCellBackground(c.IsBardingUnlocked(6021) ? Green : Red);
                                SetCellBackground(c.IsBardingUnlocked(6022) ? Green : Red);
                                SetCellBackground(c.IsBardingUnlocked(6023) ? Green : Red);
                                SetCellBackground(c.IsBardingUnlocked(6024) ? Green : Red);
                                SetCellBackground(c.IsBardingUnlocked(6025) ? Green : Red);
                                SetCellBackground(c.IsBardingUnlocked(6026) ? Green : Red);
                                SetCellBackground(c.IsBardingUnlocked(6027) ? Green : Red);
                                SetCellBackground(c.IsBardingUnlocked(6028) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("PvP"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("SquadBardingPvP", SquadBardingPvPStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, SquadBardingPvPStrings);

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsBardingUnlocked(36850) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Ishgardian Restoration"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("SquadBardingResto", SquadBardingRestoStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, SquadBardingRestoStrings);

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsBardingUnlocked(7552) ? Green : Red);
                                SetCellBackground(c.IsBardingUnlocked(8570) ? Green : Red);
                                SetCellBackground(c.IsBardingUnlocked(9355) ? Green : Red);
                                SetCellBackground(c.IsBardingUnlocked(12082) ? Green : Red);
                                SetCellBackground(c.IsBardingUnlocked(12083) ? Green : Red);
                                SetCellBackground(c.IsBardingUnlocked(14080) ? Green : Red);
                                SetCellBackground(c.IsBardingUnlocked(15427) ? Green : Red);
                                SetCellBackground(c.IsBardingUnlocked(16557) ? Green : Red);
                                SetCellBackground(c.IsBardingUnlocked(17522) ? Green : Red);
                                SetCellBackground(c.IsBardingUnlocked(29403) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Trials"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("SquadBardingTrial", SquadBardingTrialStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, SquadBardingTrialStrings);

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsBardingUnlocked(13286) ? Green : Red);
                                SetCellBackground(c.IsBardingUnlocked(24800) ? Green : Red);
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
