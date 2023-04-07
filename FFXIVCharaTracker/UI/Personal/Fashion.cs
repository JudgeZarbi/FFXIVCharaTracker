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
        internal void DrawFashionSection(Chara charaData)
        {
            if (ImGui.TreeNode("Fashion Accessories"))
            {
                if (ImGui.TreeNode("Achievements"))
                {
                    if (ImGui.BeginTable("FashionAchievement", 2))
                    {
                        SetUpTableColumns();

                        DrawTableRowText("Gold Parasaucer", charaData.IsFashionUnlocked(10));

                        ImGui.EndTable();
                    }
                    ImGui.TreePop();
                }
                if (ImGui.TreeNode("Bozja"))
                {
                    if (ImGui.BeginTable("FashionBozja", 2))
                    {
                        SetUpTableColumns();

                        DrawTableRowText("Classy Checkered Parasol", charaData.IsFashionUnlocked(8));
                        DrawTableRowText("Pleasant Dot Parasol", charaData.IsFashionUnlocked(11));

                        ImGui.EndTable();
                    }
                    ImGui.TreePop();
                }
                if (ImGui.TreeNode("Deep Dungeon"))
                {
                    if (ImGui.BeginTable("FashionDeep", 2))
                    {
                        SetUpTableColumns();

                        DrawTableRowText("Raindrop Defense System", charaData.IsFashionUnlocked(31));

                        ImGui.EndTable();
                    }
                    ImGui.TreePop();
                }
                if (ImGui.TreeNode("FATE"))
                {
                    if (ImGui.BeginTable("FashionFate", 2))
                    {
                        SetUpTableColumns();

                        DrawTableRowText("Fallen Angel Wings", charaData.IsFashionUnlocked(17));

                        ImGui.EndTable();
                    }
                    ImGui.TreePop();
                }
                if (ImGui.TreeNode("Gold Saucer"))
                {
                    if (ImGui.BeginTable("FashionSaucer", 2))
                    {
                        SetUpTableColumns();

                        DrawTableRowText("Gold Paper Parasol", charaData.IsFashionUnlocked(5));
                        DrawTableRowText("Angel Wings", charaData.IsFashionUnlocked(9));
                        DrawTableRowText("False Spectacles", charaData.IsFashionUnlocked(22));

                        ImGui.EndTable();
                    }
                    ImGui.TreePop();
                }
                if (ImGui.TreeNode("Hunts"))
                {
                    if (ImGui.BeginTable("FashionHunt", 2))
                    {
                        SetUpTableColumns();

                        DrawTableRowText("Diabolos Wings", charaData.IsFashionUnlocked(19));

                        ImGui.EndTable();
                    }
                    ImGui.TreePop();
                }
                if (ImGui.TreeNode("Island Sanctuary"))
                {
                    if (ImGui.BeginTable("FashionSanctuary", 2))
                    {
                        SetUpTableColumns();

                        DrawTableRowText("Bluepowder Pixie Wings", charaData.IsFashionUnlocked(28));
                        DrawTableRowText("Felicitous Furball Umbrella", charaData.IsFashionUnlocked(30));

                        ImGui.EndTable();
                    }
                    ImGui.TreePop();
                }
                if (ImGui.TreeNode("Mog Station"))
                {
                    if (ImGui.BeginTable("FashionMog", 2))
                    {
                        SetUpTableColumns();

                        DrawTableRowText("Red Moon Parasol", charaData.IsFashionUnlocked(16));

                        ImGui.EndTable();
                    }
                    ImGui.TreePop();
                }
                if (ImGui.TreeNode("Shop"))
                {
                    if (ImGui.BeginTable("FashionShop", 2))
                    {
                        SetUpTableColumns();

                        DrawTableRowText("Vermilion Paper Parasol", charaData.IsFashionUnlocked(3));
                        DrawTableRowText("Prim Dot Parasol", charaData.IsFashionUnlocked(12));

                        ImGui.EndTable();
                    }
                    ImGui.TreePop();
                }
                if (ImGui.TreeNode("Ishgardian Restoration"))
                {
                    if (ImGui.BeginTable("FashionResto", 2))
                    {
                        SetUpTableColumns();

                        DrawTableRowText("Parasol", charaData.IsFashionUnlocked(1));
                        DrawTableRowText("Sky Blue Parasol", charaData.IsFashionUnlocked(2));
                        DrawTableRowText("Calming Checkered Parasol", charaData.IsFashionUnlocked(6));
                        DrawTableRowText("Cheerful Checkered Parasol", charaData.IsFashionUnlocked(7));
                        DrawTableRowText("Pastoral Dot Parasol", charaData.IsFashionUnlocked(13));

                        ImGui.EndTable();
                    }
                    ImGui.TreePop();
                }
                if (ImGui.TreeNode("Treasure Maps"))
                {
                    if (ImGui.BeginTable("FashionTreasure", 2))
                    {
                        SetUpTableColumns();

                        DrawTableRowText("Pixie Wings", charaData.IsFashionUnlocked(20));
                        DrawTableRowText("Archangel Wings", charaData.IsFashionUnlocked(18));
                        DrawTableRowText("White Lace Parasol", charaData.IsFashionUnlocked(23));

                        ImGui.EndTable();
                    }
                    ImGui.TreePop();
                }
                if (ImGui.TreeNode("Variant/Criterion"))
                {
                    if (ImGui.BeginTable("FashionVandC", 2))
                    {
                        SetUpTableColumns();

                        DrawTableRowText("Sabotender Parasol", charaData.IsFashionUnlocked(27));

                        ImGui.EndTable();
                    }
                    ImGui.TreePop();
                }
                if (ImGui.TreeNode("Voyages"))
                {
                    if (ImGui.BeginTable("FashionVoyage", 2))
                    {
                        SetUpTableColumns();

                        DrawTableRowText("Plum Paper Parasol", charaData.IsFashionUnlocked(4));
                        DrawTableRowText("Blue Blossom Parasol", charaData.IsFashionUnlocked(24));
                        DrawTableRowText("False Classic Spectacles", charaData.IsFashionUnlocked(26));

                        ImGui.EndTable();
                    }
                    ImGui.TreePop();
                }
                ImGui.TreePop();
            }
        }
    }
}
