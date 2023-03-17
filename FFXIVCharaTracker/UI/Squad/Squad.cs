using FFXIVCharaTracker.DB;
using ImGuiNET;
using System.Data.Entity;
using System.Numerics;

namespace FFXIVCharaTracker
{
    internal partial class PluginUI
    {
        internal void DrawSquadTab()
        {
            if (Context.Charas.Count() > 1)
            {
                if (ImGui.BeginTabItem("Squad"))
                {
                    var charas = Context.Charas.Include(c => c.Retainers).OrderBy(c => c.Account).ThenBy(c => c.WorldID).ThenBy(c => (long)c.CharaID).AsNoTracking().ToList();
                    ImGui.Indent();
                    if (ImGui.BeginTabBar("squadSubtypes"))
                    {
                        DrawSquadCharacterSection(charas);
                        DrawSquadDoWDoMSection(charas);
                        DrawSquadDoHDoLSection(charas);
                        DrawSquadEmotesSection(charas);
                        DrawSquadHairstylesSection(charas);
                        DrawSquadMinionsSection(charas);
                        DrawSquadMountsSection(charas);
                        DrawSquadOptionalSection(charas);

                        ImGui.EndTabBar();
                        ImGui.Unindent();
                    }
                    ImGui.EndTabItem();
                }
            }
        }

        private void DrawAccountAndWorldInfo(ref int lastAccount, ref uint lastWorld, Chara chara)
        {
            if (chara.Account != lastAccount)
            {
                if (lastAccount > -1)
                {
                    ImGui.Unindent();
                    ImGui.Unindent();
                }
                lastAccount = chara.Account;
                lastWorld = 0;
                ImGui.TableNextRow();
                ImGui.TableNextColumn();
                ImGui.Text($"Account {chara.Account + 1}");
                ImGui.Indent();
            }
            if (chara.WorldID != lastWorld)
            {
                if (lastWorld > 0)
                {
                    ImGui.Unindent();
                }
                lastWorld = chara.WorldID;
                ImGui.TableNextRow();
                ImGui.TableNextColumn();
                ImGui.Text($"{Plugin.Worlds.GetRow(chara.WorldID)!.Name}");
                ImGui.Indent();
            }
            ImGui.TableNextRow();
        }

        private static void SetCellBackground(Vector4 colour)
        {
            ImGui.TableNextColumn();
            ImGui.TableSetBgColor(ImGuiTableBgTarget.CellBg, ImGui.GetColorU32(colour));
        }

        private static void SetUpSquadTableHeaders(float width, params string[] objects)
        {
            ImGui.TableSetupScrollFreeze(1, 0);

            ImGui.TableSetupColumn("Name", ImGuiTableColumnFlags.WidthFixed, 200 * Scale);
            foreach (var title in objects)
            {
                ImGui.TableSetupColumn(title, ImGuiTableColumnFlags.WidthFixed, (width > 0 ? width : ImGui.CalcTextSize(title).X) * Scale);
            }
            ImGui.TableHeadersRow();
        }
    }
}
