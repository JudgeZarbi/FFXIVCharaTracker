using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using ImGuiNET;

namespace FFXIVCharaTracker
{
    internal partial class PluginUI
    {
        public void DrawPersonalTab()
        {
            if (ImGui.BeginTabItem("Personal"))
            {
                var charaData = Plugin.CurCharaData!;
                if (Plugin.CurCharaData == null)
                {
                    ImGui.Text("This character is not registered in the database.");
                    if (ImGui.Button("Register character"))
                    {
                        Plugin.AddNewCharacter();
                    }
                }
                else
                {
                    DrawCharacterSection(charaData);
                    DrawDoMDoWSection(charaData);
                    DrawDoLDoHSection(charaData);
                    DrawEmotesSection(charaData);
                    DrawHairstylesSection(charaData);
                    DrawMinionsSection(charaData);
                    DrawMountsSection(charaData);
                    DrawOptionalContentSection(charaData);
                }
                ImGui.EndTabItem();
            }

        }

        private void DrawTableRowText(string name, bool have, Vector4? colour = null, string? value = null)
        {
            ImGui.TableNextRow();
            ImGui.TableNextColumn();
            ImGui.PushItemWidth(ImGui.GetContentRegionAvail().X);
            ImGui.Text(name);
            ImGui.TableNextColumn();
            ImGui.PushItemWidth(ImGui.GetContentRegionAvail().X);
            if (have)
            {
                ImGui.TextColored(colour ?? Green, value ?? "Yes");
            }
            else
            {
                ImGui.TextColored(colour ?? Red, value ?? "No");
            }
        }

    }
}
