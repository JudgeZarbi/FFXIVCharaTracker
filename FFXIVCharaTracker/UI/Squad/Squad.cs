﻿using FFXIVCharaTracker.DB;
using ImGuiNET;
using FFXIVClientStructs.FFXIV.Common.Math;
using Microsoft.EntityFrameworkCore;

namespace FFXIVCharaTracker
{
    internal partial class PluginUI
    {
        internal void DrawSquadTab()
        {
            if (Context.Charas.AsNoTracking().Count() > 1)
            {
                if (ImGui.BeginTabItem("Squad"))
                {
                    var charas = Context.Charas.AsNoTracking().Include(c => c.Retainers).OrderBy(c => c.Account).ThenBy(c => c.WorldID).ThenBy(c => (long)c.CharaID).ToList();
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
                        DrawSquadBardingsSection(charas);
                        DrawSquadFashionSection(charas);
                        DrawSquadOrchestrionSection(charas);
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

        internal unsafe Vector4 GetBeastTribeColour(Chara chara, byte tribeId)
        {
            var maxRank = tribeId <= 4 ? 4 : tribeId >= 6 ? 8 : 7;
            return chara.BeastTribeRanksList[tribeId] == maxRank ? Green :
                chara.BeastTribeRanksList[tribeId] > 0 ? Yellow : Red;
        }

    }
}
