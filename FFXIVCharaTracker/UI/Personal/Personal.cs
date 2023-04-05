using ImGuiNET;
using System.Numerics;

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
                        Plugin.CurCharaData = DB.Chara.AddNewCharacter();
                        if (Plugin.CurCharaData != null)
                        {
                            Plugin.Context.Add(Plugin.CurCharaData);
                        }
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
