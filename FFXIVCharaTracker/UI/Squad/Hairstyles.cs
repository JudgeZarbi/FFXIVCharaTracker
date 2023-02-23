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
        internal void DrawSquadHairstylesSection(List<Chara> charas)
        {
            if (ImGui.BeginTabItem("Hairstyles"))
            {
                ImGui.Indent();

                var lastAccount = -1;
                var lastWorld = 0u;

                if (ImGui.BeginTabBar("squadHairstyles"))
                {
                    if (ImGui.BeginTabItem("Gold Saucer"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("squadhairstylesSaucer", 9, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, "Great Lengths", "Lexen-tails", "Styled for Hire", "Fashionably Feathered", "Rainmaker", "Curls", "Adventure", "Ponytails");

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsHairstyleUnlocked(27970) ? Green : Red);
                                SetCellBackground(c.IsHairstyleUnlocked(24801) ? Green : Red);
                                SetCellBackground(c.IsHairstyleUnlocked(24234) ? Green : Red);
                                SetCellBackground(c.IsHairstyleUnlocked(23370) ? Green : Red);
                                SetCellBackground(c.IsHairstyleUnlocked(17471) ? Green : Red);
                                SetCellBackground(c.IsHairstyleUnlocked(13704) ? Green : Red);
                                SetCellBackground(c.IsHairstyleUnlocked(13705) ? Green : Red);
                                SetCellBackground(c.IsHairstyleUnlocked(10084) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Eureka"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("squadhairstylesEureka", 2, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, "Form and Function");

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsHairstyleUnlocked(24233) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Bozja"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("squadhairstylesBozja", 4, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, "Both Ways", "Early to Rise", "Wind Caller");

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsHairstyleUnlocked(33706) ? Green : Red);
                                SetCellBackground(c.IsHairstyleUnlocked(32835) ? Green : Red);
                                SetCellBackground(c.IsHairstyleUnlocked(31407) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Deep Dungeon"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("squadhairstylesDeep", 3, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, "Gyr Abanian Plait", "Samsonian Locks");

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsHairstyleUnlocked(23369) ? Green : Red);
                                SetCellBackground(c.IsHairstyleUnlocked(16703) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Ishgardian Restoration"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("squadhairstylesResto", 4, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, "Saintly Style", "Controlled Chaos", "Modern Legend");

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsHairstyleUnlocked(31406) ? Green : Red);
                                SetCellBackground(c.IsHairstyleUnlocked(30113) ? Green : Red);
                                SetCellBackground(c.IsHairstyleUnlocked(28615) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Alliance Raids"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("squadhairstylesAlliance", 3, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, "Scanning for Style", "Battle-ready Bobs");

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsHairstyleUnlocked(33708) ? Green : Red);
                                SetCellBackground(c.IsHairstyleUnlocked(33707) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Island Sanctuary"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("squadhairstylesAlliance", 3, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, "Practical Ponytails", "Tall Tails");

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsHairstyleUnlocked(38443) ? Green : Red);
                                SetCellBackground(c.IsHairstyleUnlocked(38442) ? Green : Red);

                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Mog Station"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("squadhairstylesMog", 11, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, "Sharlayan Rebellion", "Sharlayan Studies", "Master & Commander", "Scion Special Issue", "Scion Special Issue II", "Scion Special Issue III", "Pulse", "Liberating Locks", "Clowning Around", "A Wicked Wake");

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsHairstyleUnlocked(39472) ? Green : Red);
                                SetCellBackground(c.IsHairstyleUnlocked(32836) ? Green : Red);
                                SetCellBackground(c.IsHairstyleUnlocked(17472) ? Green : Red);
                                SetCellBackground(c.IsHairstyleUnlocked(13703) ? Green : Red);
                                SetCellBackground(c.IsHairstyleUnlocked(15612) ? Green : Red);
                                SetCellBackground(c.IsHairstyleUnlocked(15613) ? Green : Red);
                                SetCellBackground(c.IsHairstyleUnlocked(14970) ? Green : Red);
                                SetCellBackground(c.IsHairstyleUnlocked(36812) ? Green : Red);
                                SetCellBackground(c.IsHairstyleUnlocked(36618) ? Green : Red);
                                SetCellBackground(c.IsHairstyleUnlocked(28614) ? Green : Red);
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
