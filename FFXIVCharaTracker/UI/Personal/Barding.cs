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
        internal void DrawBardingsSection(Chara charaData)
        {
            if (ImGui.TreeNode("Barding"))
            {
                if (ImGui.TreeNode("Achievements"))
                {
                    if (ImGui.BeginTable("BardingAchievement", 2))
                    {
                        SetUpTableColumns();

                        DrawTableRowText("Black Mage Barding", charaData.IsBardingUnlocked(6029));
                        DrawTableRowText("Sovereign Barding", charaData.IsBardingUnlocked(6995));
                        DrawTableRowText("Barding Of Light", charaData.IsBardingUnlocked(7551));
                        DrawTableRowText("Plumed Barding", charaData.IsBardingUnlocked(8571));
                        DrawTableRowText("Flyer Shaffron", charaData.IsBardingUnlocked(6032));
                        DrawTableRowText("Wild Rose Barding", charaData.IsBardingUnlocked(13111));
                        DrawTableRowText("Race Barding", charaData.IsBardingUnlocked(15129));

                        ImGui.EndTable();
                    }
                    ImGui.TreePop();
                }
                if (ImGui.TreeNode("Bozja"))
                {
                    if (ImGui.BeginTable("BardingBozja", 2))
                    {
                        SetUpTableColumns();

                        DrawTableRowText("Expanse Barding", charaData.IsBardingUnlocked(12082));
                        DrawTableRowText("Hive Barding", charaData.IsBardingUnlocked(12083));
                        DrawTableRowText("Sephirotic Barding", charaData.IsBardingUnlocked(14080));
                        DrawTableRowText("Horde Barding", charaData.IsBardingUnlocked(15427));
                        DrawTableRowText("Sophic Barding", charaData.IsBardingUnlocked(16557));
                        DrawTableRowText("Zurvanite Barding", charaData.IsBardingUnlocked(17522));
                        DrawTableRowText("Reveler's Barding", charaData.IsBardingUnlocked(20558));
                        DrawTableRowText("Shinryu Barding", charaData.IsBardingUnlocked(21042));
                        DrawTableRowText("Byakko Barding", charaData.IsBardingUnlocked(21924));
                        DrawTableRowText("Lunar Barding", charaData.IsBardingUnlocked(23037));
                        DrawTableRowText("Suzaku Barding", charaData.IsBardingUnlocked(24143));
                        DrawTableRowText("Seiryu Barding", charaData.IsBardingUnlocked(24799));
                        DrawTableRowText("Queen's Guard Barding", charaData.IsBardingUnlocked(32824));
                        DrawTableRowText("Bozjan Barding", charaData.IsBardingUnlocked(33672));

                        ImGui.EndTable();
                    }
                    ImGui.TreePop();
                }
                if (ImGui.TreeNode("Crafted"))
                {
                    if (ImGui.BeginTable("BardingCrafted", 2))
                    {
                        SetUpTableColumns();

                        DrawTableRowText("Tidal Barding", charaData.IsBardingUnlocked(7552));
                        DrawTableRowText("Levin Barding", charaData.IsBardingUnlocked(8570));
                        DrawTableRowText("Ice Barding", charaData.IsBardingUnlocked(9355));
                        DrawTableRowText("Orthodox Barding", charaData.IsBardingUnlocked(12991));
                        DrawTableRowText("Highland Barding", charaData.IsBardingUnlocked(12081));
                        DrawTableRowText("Expanse Barding", charaData.IsBardingUnlocked(12082));
                        DrawTableRowText("Hive Barding", charaData.IsBardingUnlocked(12083));
                        DrawTableRowText("Sephirotic Barding", charaData.IsBardingUnlocked(14080));
                        DrawTableRowText("Horde Barding", charaData.IsBardingUnlocked(15427));
                        DrawTableRowText("Sophic Barding", charaData.IsBardingUnlocked(16557));
                        DrawTableRowText("Zurvanite Barding", charaData.IsBardingUnlocked(17522));
                        DrawTableRowText("Reveler's Barding", charaData.IsBardingUnlocked(20558));
                        DrawTableRowText("Blissful Barding", charaData.IsBardingUnlocked(20560));
                        DrawTableRowText("Shinryu Barding", charaData.IsBardingUnlocked(21042));
                        DrawTableRowText("Byakko Barding", charaData.IsBardingUnlocked(21924));
                        DrawTableRowText("Lunar Barding", charaData.IsBardingUnlocked(23037));
                        DrawTableRowText("Suzaku Barding", charaData.IsBardingUnlocked(24143));
                        DrawTableRowText("Seiryu Barding", charaData.IsBardingUnlocked(24799));
                        DrawTableRowText("Titania Barding", charaData.IsBardingUnlocked(27986));
                        DrawTableRowText("Innocence Barding", charaData.IsBardingUnlocked(27987));
                        DrawTableRowText("Hades Barding", charaData.IsBardingUnlocked(28616));
                        DrawTableRowText("Ruby Barding", charaData.IsBardingUnlocked(29402));
                        DrawTableRowText("True Barding Of Light", charaData.IsBardingUnlocked(30678));
                        DrawTableRowText("Emerald Barding", charaData.IsBardingUnlocked(32823));
                        DrawTableRowText("Diamond Barding", charaData.IsBardingUnlocked(33673));
                        DrawTableRowText("Barding Of Eternal Darkness", charaData.IsBardingUnlocked(36011));
                        DrawTableRowText("Barding Of Divine Light", charaData.IsBardingUnlocked(36012));
                        DrawTableRowText("Bluefeather Barding", charaData.IsBardingUnlocked(36849));
                        DrawTableRowText("Windswept Barding", charaData.IsBardingUnlocked(38440));
                        DrawTableRowText("Flamecloaked Barding", charaData.IsBardingUnlocked(39470));

                        ImGui.EndTable();
                    }
                    ImGui.TreePop();
                }
                if (ImGui.TreeNode("Deep Dungeon"))
                {
                    if (ImGui.BeginTable("BardingDeep", 2))
                    {
                        SetUpTableColumns();

                        DrawTableRowText("Tidal Barding", charaData.IsBardingUnlocked(7552));
                        DrawTableRowText("Levin Barding", charaData.IsBardingUnlocked(8570));
                        DrawTableRowText("Ice Barding", charaData.IsBardingUnlocked(9355));
                        DrawTableRowText("Expanse Barding", charaData.IsBardingUnlocked(12082));
                        DrawTableRowText("Hive Barding", charaData.IsBardingUnlocked(12083));
                        DrawTableRowText("Sephirotic Barding", charaData.IsBardingUnlocked(14080));
                        DrawTableRowText("Horde Barding", charaData.IsBardingUnlocked(15427));
                        DrawTableRowText("Abigail Barding", charaData.IsBardingUnlocked(16558));
                        DrawTableRowText("Sophic Barding", charaData.IsBardingUnlocked(16557));
                        DrawTableRowText("Zurvanite Barding", charaData.IsBardingUnlocked(17522));
                        DrawTableRowText("Reveler's Barding", charaData.IsBardingUnlocked(20558));
                        DrawTableRowText("Blissful Barding", charaData.IsBardingUnlocked(20560));
                        DrawTableRowText("Lunar Barding", charaData.IsBardingUnlocked(23037));
                        DrawTableRowText("Suzaku Barding", charaData.IsBardingUnlocked(24143));
                        DrawTableRowText("Seiryu Barding", charaData.IsBardingUnlocked(24799));
                        DrawTableRowText("Titania Barding", charaData.IsBardingUnlocked(27986));
                        DrawTableRowText("Innocence Barding", charaData.IsBardingUnlocked(27987));
                        DrawTableRowText("Ruby Barding", charaData.IsBardingUnlocked(29402));
                        DrawTableRowText("Emerald Barding", charaData.IsBardingUnlocked(32823));
                        DrawTableRowText("Diamond Barding", charaData.IsBardingUnlocked(33673));
                        DrawTableRowText("Barding Of Eternal Darkness", charaData.IsBardingUnlocked(36011));
                        DrawTableRowText("Barding Of Divine Light", charaData.IsBardingUnlocked(36012));
                        DrawTableRowText("Allagan Barding", charaData.IsBardingUnlocked(39471));

                        ImGui.EndTable();
                    }
                    ImGui.TreePop();
                }
                if (ImGui.TreeNode("Eureka"))
                {
                    if (ImGui.BeginTable("BardingEureka", 2))
                    {
                        SetUpTableColumns();

                        DrawTableRowText("Red Mage Barding", charaData.IsBardingUnlocked(21191));
                        DrawTableRowText("Samurai Barding", charaData.IsBardingUnlocked(24144));

                        ImGui.EndTable();
                    }
                    ImGui.TreePop();
                }
                if (ImGui.TreeNode("FATE"))
                {
                    if (ImGui.BeginTable("BardingFate", 2))
                    {
                        SetUpTableColumns();

                        DrawTableRowText("Sleipnir Barding", charaData.IsBardingUnlocked(6030));
                        DrawTableRowText("Ishgardian Half Barding", charaData.IsBardingUnlocked(12077));
                        DrawTableRowText("Ala Mhigan Barding", charaData.IsBardingUnlocked(20559));
                        DrawTableRowText("Ixion Barding", charaData.IsBardingUnlocked(21043));
                        DrawTableRowText("Dancer Barding", charaData.IsBardingUnlocked(27988));
                        DrawTableRowText("Deepshadow Barding", charaData.IsBardingUnlocked(27989));
                        DrawTableRowText("Thavnairian Barding", charaData.IsBardingUnlocked(36014));

                        ImGui.EndTable();
                    }
                    ImGui.TreePop();
                }
                if (ImGui.TreeNode("Gathering"))
                {
                    if (ImGui.BeginTable("BardingGather", 2))
                    {
                        SetUpTableColumns();

                        DrawTableRowText("Chocobo Raincoat", charaData.IsBardingUnlocked(21925));

                        ImGui.EndTable();
                    }
                    ImGui.TreePop();
                }
                if (ImGui.TreeNode("Gold Saucer"))
                {
                    if (ImGui.BeginTable("BardingSaucer", 2))
                    {
                        SetUpTableColumns();

                        DrawTableRowText("Gambler Barding", charaData.IsBardingUnlocked(10083));
                        DrawTableRowText("Mandervillian Barding", charaData.IsBardingUnlocked(16926));

                        ImGui.EndTable();
                    }
                    ImGui.TreePop();
                }
                if (ImGui.TreeNode("Hunts"))
                {
                    if (ImGui.BeginTable("BardingHunt", 2))
                    {
                        SetUpTableColumns();

                        DrawTableRowText("Ishgardian Barding", charaData.IsBardingUnlocked(12078));
                        DrawTableRowText("Hingan Barding", charaData.IsBardingUnlocked(20561));

                        ImGui.EndTable();
                    }
                    ImGui.TreePop();
                }
                if (ImGui.TreeNode("Island Sanctuary"))
                {
                    if (ImGui.BeginTable("BardingSanctuary", 2))
                    {
                        SetUpTableColumns();

                        DrawTableRowText("Isle Pioneer's Barding", charaData.IsBardingUnlocked(38441));

                        ImGui.EndTable();
                    }
                    ImGui.TreePop();
                }
                if (ImGui.TreeNode("Mog Station"))
                {
                    if (ImGui.BeginTable("BardingMog", 2))
                    {
                        SetUpTableColumns();

                        DrawTableRowText("Far Eastern Barding", charaData.IsBardingUnlocked(14860));
                        DrawTableRowText("Butlery Barding", charaData.IsBardingUnlocked(15428));
                        DrawTableRowText("Behemoth Barding", charaData.IsBardingUnlocked(6031));
                        DrawTableRowText("Starlight Barding", charaData.IsBardingUnlocked(7056));
                        DrawTableRowText("Authentic Egg Barding", charaData.IsBardingUnlocked(37482));
                        DrawTableRowText("Eerie Barding", charaData.IsBardingUnlocked(8718));
                        DrawTableRowText("Paramour Barding", charaData.IsBardingUnlocked(10082));
                        DrawTableRowText("Egg Hunter Barding", charaData.IsBardingUnlocked(14081));
                        DrawTableRowText("Angelic Barding", charaData.IsBardingUnlocked(16559));
                        DrawTableRowText("Demonic Barding", charaData.IsBardingUnlocked(16560));
                        DrawTableRowText("Oriental Barding", charaData.IsBardingUnlocked(20562));
                        DrawTableRowText("Nezha Barding", charaData.IsBardingUnlocked(20563));
                        DrawTableRowText("Saintly Barding", charaData.IsBardingUnlocked(28617));
                        DrawTableRowText("Postmoogle Barding", charaData.IsBardingUnlocked(36013));

                        ImGui.EndTable();
                    }
                    ImGui.TreePop();
                }
                if (ImGui.TreeNode("Shop"))
                {
                    if (ImGui.BeginTable("BardingShop", 2))
                    {
                        SetUpTableColumns();

                        DrawTableRowText("Lominsan Half Barding", charaData.IsBardingUnlocked(6020));
                        DrawTableRowText("Lominsan Barding", charaData.IsBardingUnlocked(6021));
                        DrawTableRowText("Lominsan Crested Barding", charaData.IsBardingUnlocked(6022));
                        DrawTableRowText("Gridanian Half Barding", charaData.IsBardingUnlocked(6023));
                        DrawTableRowText("Gridanian Barding", charaData.IsBardingUnlocked(6024));
                        DrawTableRowText("Gridanian Crested Barding", charaData.IsBardingUnlocked(6025));
                        DrawTableRowText("Ul'dahn Half Barding", charaData.IsBardingUnlocked(6026));
                        DrawTableRowText("Ul'dahn Barding", charaData.IsBardingUnlocked(6027));
                        DrawTableRowText("Ul'dahn Crested Barding", charaData.IsBardingUnlocked(6028));

                        ImGui.EndTable();
                    }
                    ImGui.TreePop();
                }
                if (ImGui.TreeNode("PvP"))
                {
                    if (ImGui.BeginTable("BardingPvP", 2))
                    {
                        SetUpTableColumns();

                        DrawTableRowText("Wolf Barding", charaData.IsBardingUnlocked(36850));

                        ImGui.EndTable();
                    }
                    ImGui.TreePop();
                }
                if (ImGui.TreeNode("Ishgardian Restoration"))
                {
                    if (ImGui.BeginTable("BardingResto", 2))
                    {
                        SetUpTableColumns();

                        DrawTableRowText("Tidal Barding", charaData.IsBardingUnlocked(7552));
                        DrawTableRowText("Levin Barding", charaData.IsBardingUnlocked(8570));
                        DrawTableRowText("Ice Barding", charaData.IsBardingUnlocked(9355));
                        DrawTableRowText("Expanse Barding", charaData.IsBardingUnlocked(12082));
                        DrawTableRowText("Hive Barding", charaData.IsBardingUnlocked(12083));
                        DrawTableRowText("Sephirotic Barding", charaData.IsBardingUnlocked(14080));
                        DrawTableRowText("Horde Barding", charaData.IsBardingUnlocked(15427));
                        DrawTableRowText("Sophic Barding", charaData.IsBardingUnlocked(16557));
                        DrawTableRowText("Zurvanite Barding", charaData.IsBardingUnlocked(17522));
                        DrawTableRowText("Machinist Barding", charaData.IsBardingUnlocked(29403));

                        ImGui.EndTable();
                    }
                    ImGui.TreePop();
                }
                if (ImGui.TreeNode("Trials"))
                {
                    if (ImGui.BeginTable("BardingTrial", 2))
                    {
                        SetUpTableColumns();

                        DrawTableRowText("Round Table Barding", charaData.IsBardingUnlocked(13286));
                        DrawTableRowText("Yojimbo Barding", charaData.IsBardingUnlocked(24800));

                        ImGui.EndTable();
                    }
                    ImGui.TreePop();
                }
                ImGui.TreePop();
            }
        }
    }
}
