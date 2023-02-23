using FFXIVCharaTracker.DB;
using FFXIVClientStructs.FFXIV.Client.Game.UI;
using ImGuiNET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FFXIVCharaTracker
{
    internal partial class PluginUI
    {
        internal void DrawDoMDoWSection(Chara charaData)
        {
            if (ImGui.TreeNode("DoW/DoM"))
            {
                if (ImGui.BeginTable("tableDoMDoW", 2))
                {
                    SetUpTableColumns();

                    var level = charaData.ClassLevel;
                    DrawTableRowText("Level", true, level == Data.MaxLevel ? Green : (level > 0 ? Yellow : Red),
                        level.ToString());

                    var story = charaData.GetStoryProgress();
                    DrawTableRowText("Story", true, story == Data.MaxStoryLevel ? Green : (level > 0 ? Yellow : Red),
                        StoryProgressToString[story]);

                    ImGui.EndTable();

                    if (ImGui.TreeNode("Gear"))
                    {
                        if (ImGui.BeginTable("tableDoMDoWGear", 2))
                        {
                            SetUpTableColumns();

                            var lowGear = charaData.LowGear || level == Data.MaxLevel;
                            DrawTableRowText("Low level", lowGear);

                            DrawTableRowText("Current level", charaData.CurGear);

                            ImGui.EndTable();
                        }
                        ImGui.TreePop();
                    }
                }
                ImGui.TreePop();
            }
        }
    }
}
