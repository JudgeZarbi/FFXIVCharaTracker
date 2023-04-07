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
                if (ImGui.TreeNode("Bozja"))
                {
                    if (ImGui.BeginTable("HairstyleBozja", 2))
                    {
                        SetUpTableColumns();

                        DrawTableRowText("Wind Caller", charaData.IsHairstyleUnlocked(31407));
                        DrawTableRowText("Early To Rise", charaData.IsHairstyleUnlocked(32835));
                        DrawTableRowText("Both Ways", charaData.IsHairstyleUnlocked(33706));

                        ImGui.EndTable();
                    }
                    ImGui.TreePop();
                }
                if (ImGui.TreeNode("Deep Dungeon"))
                {
                    if (ImGui.BeginTable("HairstyleDeep", 2))
                    {
                        SetUpTableColumns();

                        DrawTableRowText("Samsonian Locks", charaData.IsHairstyleUnlocked(16703));
                        DrawTableRowText("Gyr Abanian Plait", charaData.IsHairstyleUnlocked(23369));
                        DrawTableRowText("A Close Shave", charaData.IsHairstyleUnlocked(39473));

                        ImGui.EndTable();
                    }
                    ImGui.TreePop();
                }
                if (ImGui.TreeNode("Eureka"))
                {
                    if (ImGui.BeginTable("HairstyleEureka", 2))
                    {
                        SetUpTableColumns();

                        DrawTableRowText("Form And Function", charaData.IsHairstyleUnlocked(24233));

                        ImGui.EndTable();
                    }
                    ImGui.TreePop();
                }
                if (ImGui.TreeNode("Gold Saucer"))
                {
                    if (ImGui.BeginTable("HairstyleSaucer", 2))
                    {
                        SetUpTableColumns();

                        DrawTableRowText("Ponytails", charaData.IsHairstyleUnlocked(10084));
                        DrawTableRowText("Adventure", charaData.IsHairstyleUnlocked(13705));
                        DrawTableRowText("Curls", charaData.IsHairstyleUnlocked(13704));
                        DrawTableRowText("Rainmaker", charaData.IsHairstyleUnlocked(17471));
                        DrawTableRowText("Lexen-tails", charaData.IsHairstyleUnlocked(24801));
                        DrawTableRowText("Great Lengths", charaData.IsHairstyleUnlocked(27970));

                        ImGui.EndTable();
                    }
                    ImGui.TreePop();
                }
                if (ImGui.TreeNode("Island Sanctuary"))
                {
                    if (ImGui.BeginTable("HairstyleSanctuary", 2))
                    {
                        SetUpTableColumns();

                        DrawTableRowText("Tall Tails", charaData.IsHairstyleUnlocked(38442));
                        DrawTableRowText("Practical Ponytails", charaData.IsHairstyleUnlocked(38443));

                        ImGui.EndTable();
                    }
                    ImGui.TreePop();
                }
                if (ImGui.TreeNode("Mog Station"))
                {
                    if (ImGui.BeginTable("HairstyleMog", 2))
                    {
                        SetUpTableColumns();

                        DrawTableRowText("A Wicked Wake", charaData.IsHairstyleUnlocked(28614));
                        DrawTableRowText("Scion Special Issue", charaData.IsHairstyleUnlocked(13703));
                        DrawTableRowText("Pulse", charaData.IsHairstyleUnlocked(14970));
                        DrawTableRowText("Scion Special Issue II", charaData.IsHairstyleUnlocked(15612));
                        DrawTableRowText("Scion Special Issue III", charaData.IsHairstyleUnlocked(15613));
                        DrawTableRowText("Master & Commander", charaData.IsHairstyleUnlocked(17472));
                        DrawTableRowText("Sharlayan Studies", charaData.IsHairstyleUnlocked(32836));
                        DrawTableRowText("Clowning Around", charaData.IsHairstyleUnlocked(36618));
                        DrawTableRowText("Liberating Locks", charaData.IsHairstyleUnlocked(36812));
                        DrawTableRowText("Sharlayan Rebellion", charaData.IsHairstyleUnlocked(39472));

                        ImGui.EndTable();
                    }
                    ImGui.TreePop();
                }
                if (ImGui.TreeNode("PvP"))
                {
                    if (ImGui.BeginTable("HairstylePvP", 2))
                    {
                        SetUpTableColumns();

                        DrawTableRowText("Fashionably Feathered", charaData.IsHairstyleUnlocked(23370));
                        DrawTableRowText("Styled For Hire", charaData.IsHairstyleUnlocked(24234));

                        ImGui.EndTable();
                    }
                    ImGui.TreePop();
                }
                if (ImGui.TreeNode("Raids"))
                {
                    if (ImGui.BeginTable("HairstyleRaid", 2))
                    {
                        SetUpTableColumns();

                        DrawTableRowText("Battle-ready Bobs", charaData.IsHairstyleUnlocked(33707));
                        DrawTableRowText("Scanning For Style", charaData.IsHairstyleUnlocked(33708));

                        ImGui.EndTable();
                    }
                    ImGui.TreePop();
                }
                if (ImGui.TreeNode("Ishgardian Restoration"))
                {
                    if (ImGui.BeginTable("HairstyleResto", 2))
                    {
                        SetUpTableColumns();

                        DrawTableRowText("Modern Legend", charaData.IsHairstyleUnlocked(28615));
                        DrawTableRowText("Controlled Chaos", charaData.IsHairstyleUnlocked(30113));
                        DrawTableRowText("Saintly Style", charaData.IsHairstyleUnlocked(31406));

                        ImGui.EndTable();
                    }
                    ImGui.TreePop();
                }
                ImGui.TreePop();
            }
        }
    }
}
