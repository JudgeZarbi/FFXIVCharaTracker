using FFXIVCharaTracker.DB;
using ImGuiNET;

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
                    if (ImGui.BeginTabItem("Bozja"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("SquadHairstyleBozja", SquadHairstyleBozjaStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, SquadHairstyleBozjaStrings);

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsHairstyleUnlocked(31407) ? Green : Red);
                                SetCellBackground(c.IsHairstyleUnlocked(32835) ? Green : Red);
                                SetCellBackground(c.IsHairstyleUnlocked(33706) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Deep Dungeon"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("SquadHairstyleDeep", SquadHairstyleDeepStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, SquadHairstyleDeepStrings);

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsHairstyleUnlocked(16703) ? Green : Red);
                                SetCellBackground(c.IsHairstyleUnlocked(23369) ? Green : Red);
                                SetCellBackground(c.IsHairstyleUnlocked(39473) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Eureka"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("SquadHairstyleEureka", SquadHairstyleEurekaStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, SquadHairstyleEurekaStrings);

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
                    if (ImGui.BeginTabItem("Gold Saucer"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("SquadHairstyleSaucer", SquadHairstyleSaucerStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, SquadHairstyleSaucerStrings);

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsHairstyleUnlocked(10084) ? Green : Red);
                                SetCellBackground(c.IsHairstyleUnlocked(13705) ? Green : Red);
                                SetCellBackground(c.IsHairstyleUnlocked(13704) ? Green : Red);
                                SetCellBackground(c.IsHairstyleUnlocked(17471) ? Green : Red);
                                SetCellBackground(c.IsHairstyleUnlocked(24801) ? Green : Red);
                                SetCellBackground(c.IsHairstyleUnlocked(27970) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Island Sanctuary"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("SquadHairstyleSanctuary", SquadHairstyleSanctuaryStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, SquadHairstyleSanctuaryStrings);

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsHairstyleUnlocked(38442) ? Green : Red);
                                SetCellBackground(c.IsHairstyleUnlocked(38443) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Mog Station"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("SquadHairstyleMog", SquadHairstyleMogStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, SquadHairstyleMogStrings);

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsHairstyleUnlocked(28614) ? Green : Red);
                                SetCellBackground(c.IsHairstyleUnlocked(13703) ? Green : Red);
                                SetCellBackground(c.IsHairstyleUnlocked(14970) ? Green : Red);
                                SetCellBackground(c.IsHairstyleUnlocked(15612) ? Green : Red);
                                SetCellBackground(c.IsHairstyleUnlocked(15613) ? Green : Red);
                                SetCellBackground(c.IsHairstyleUnlocked(17472) ? Green : Red);
                                SetCellBackground(c.IsHairstyleUnlocked(32836) ? Green : Red);
                                SetCellBackground(c.IsHairstyleUnlocked(36618) ? Green : Red);
                                SetCellBackground(c.IsHairstyleUnlocked(36812) ? Green : Red);
                                SetCellBackground(c.IsHairstyleUnlocked(39472) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("PvP"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("SquadHairstylePvP", SquadHairstylePvPStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, SquadHairstylePvPStrings);

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsHairstyleUnlocked(23370) ? Green : Red);
                                SetCellBackground(c.IsHairstyleUnlocked(24234) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Raids"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("SquadHairstyleRaid", SquadHairstyleRaidStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, SquadHairstyleRaidStrings);

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsHairstyleUnlocked(33707) ? Green : Red);
                                SetCellBackground(c.IsHairstyleUnlocked(33708) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Ishgardian Restoration"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("SquadHairstyleResto", SquadHairstyleRestoStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, SquadHairstyleRestoStrings);

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsHairstyleUnlocked(28615) ? Green : Red);
                                SetCellBackground(c.IsHairstyleUnlocked(30113) ? Green : Red);
                                SetCellBackground(c.IsHairstyleUnlocked(31406) ? Green : Red);
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
