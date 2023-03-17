using FFXIVCharaTracker.DB;
using ImGuiNET;

namespace FFXIVCharaTracker
{
    internal partial class PluginUI
    {
        internal void DrawHairstylesSection(Chara charaData)
        {
            if (ImGui.TreeNode("Hairstyles"))
            {
                if (ImGui.TreeNode("Gold Saucer"))
                {
                    if (ImGui.BeginTable("hairstylesSaucer", 2))
                    {
                        SetUpTableColumns();

                        DrawTableRowText("Great Lengths", charaData.IsHairstyleUnlocked(27970));
                        DrawTableRowText("Lexen-tails", charaData.IsHairstyleUnlocked(24801));
                        DrawTableRowText("Styled for Hire", charaData.IsHairstyleUnlocked(24234));
                        DrawTableRowText("Fashionably Feathered", charaData.IsHairstyleUnlocked(23370));
                        DrawTableRowText("Rainmaker", charaData.IsHairstyleUnlocked(17471));
                        DrawTableRowText("Curls", charaData.IsHairstyleUnlocked(13704));
                        DrawTableRowText("Adventure", charaData.IsHairstyleUnlocked(13705));
                        DrawTableRowText("Ponytails", charaData.IsHairstyleUnlocked(10084));

                        ImGui.EndTable();
                    }
                    ImGui.TreePop();
                }
                if (ImGui.TreeNode("Eureka"))
                {
                    if (ImGui.BeginTable("hairstylesEureka", 2))
                    {
                        SetUpTableColumns();

                        DrawTableRowText("Form and Function", charaData.IsHairstyleUnlocked(24233));

                        ImGui.EndTable();
                    }
                    ImGui.TreePop();
                }
                if (ImGui.TreeNode("Bozja"))
                {
                    if (ImGui.BeginTable("hairstylesBozja", 2))
                    {
                        SetUpTableColumns();

                        DrawTableRowText("Both Ways", charaData.IsHairstyleUnlocked(33706));
                        DrawTableRowText("Early to Rise", charaData.IsHairstyleUnlocked(32835));
                        DrawTableRowText("Wind Caller", charaData.IsHairstyleUnlocked(31407));

                        ImGui.EndTable();
                    }
                    ImGui.TreePop();
                }
                if (ImGui.TreeNode("Deep Dungeon"))
                {
                    if (ImGui.BeginTable("hairstylesDeep", 2))
                    {
                        SetUpTableColumns();

                        DrawTableRowText("Gyr Abanian Plait", charaData.IsHairstyleUnlocked(23369));
                        DrawTableRowText("Samsonian Locks", charaData.IsHairstyleUnlocked(16703));

                        ImGui.EndTable();
                    }
                    ImGui.TreePop();
                }
                if (ImGui.TreeNode("Ishgardian Restoration"))
                {
                    if (ImGui.BeginTable("hairstylesResto", 2))
                    {
                        SetUpTableColumns();

                        DrawTableRowText("Saintly Style", charaData.IsHairstyleUnlocked(31406));
                        DrawTableRowText("Controlled Chaos", charaData.IsHairstyleUnlocked(30113));
                        DrawTableRowText("Modern Legend", charaData.IsHairstyleUnlocked(28615));

                        ImGui.EndTable();
                    }
                    ImGui.TreePop();
                }
                if (ImGui.TreeNode("Alliance Raids"))
                {
                    if (ImGui.BeginTable("hairstylesAlliance", 2))
                    {
                        SetUpTableColumns();

                        DrawTableRowText("Scanning for Style", charaData.IsHairstyleUnlocked(33708));
                        DrawTableRowText("Battle-ready Bobs", charaData.IsHairstyleUnlocked(33707));

                        ImGui.EndTable();
                    }
                    ImGui.TreePop();
                }
                if (ImGui.TreeNode("Island Sanctuary"))
                {
                    if (ImGui.BeginTable("hairstylesAlliance", 2))
                    {
                        SetUpTableColumns();

                        DrawTableRowText("Practical Ponytails", charaData.IsHairstyleUnlocked(38443));
                        DrawTableRowText("Tall Tails", charaData.IsHairstyleUnlocked(38442));

                        ImGui.EndTable();
                    }
                    ImGui.TreePop();
                }
                if (ImGui.TreeNode("Mog Station"))
                {
                    if (ImGui.BeginTable("hairstylesMog", 2))
                    {
                        SetUpTableColumns();

                        DrawTableRowText("Sharlayan Rebellion", charaData.IsHairstyleUnlocked(39472));
                        DrawTableRowText("Sharlayan Studies", charaData.IsHairstyleUnlocked(32836));
                        DrawTableRowText("Master & Commander", charaData.IsHairstyleUnlocked(17472));
                        DrawTableRowText("Scion Special Issue", charaData.IsHairstyleUnlocked(13703));
                        DrawTableRowText("Scion Special Issue II", charaData.IsHairstyleUnlocked(15612));
                        DrawTableRowText("Scion Special Issue III", charaData.IsHairstyleUnlocked(15613));
                        DrawTableRowText("Pulse", charaData.IsHairstyleUnlocked(14970));
                        DrawTableRowText("Liberating Locks", charaData.IsHairstyleUnlocked(36812));
                        DrawTableRowText("Clowning Around", charaData.IsHairstyleUnlocked(36618));
                        DrawTableRowText("A Wicked Wake", charaData.IsHairstyleUnlocked(28614));

                        ImGui.EndTable();
                    }
                    ImGui.TreePop();

                }
                ImGui.TreePop();
            }
        }
    }
}
