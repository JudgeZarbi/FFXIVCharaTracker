using FFXIVCharaTracker.DB;
using ImGuiNET;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace FFXIVCharaTracker
{
    internal partial class PluginUI
    {
        internal void DrawSquadDoWDoMSection(List<Chara> charas)
        {
            if (ImGui.BeginTabItem("DoW/DoM"))
            {
                ImGui.Unindent();

                if (ImGui.BeginTable("squadDoWDoM", SquadDoWDoMStrings.Length + 1, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                {
                    SetUpSquadTableHeaders(100, SquadDoWDoMStrings);

                    var lastAccount = -1;
                    var lastWorld = 0u;

                    foreach (var c in charas)
                    {
                        DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                        SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                        SetCellBackgroundWithText(default, CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Plugin.ClassJobs.GetRow(c.ClassID)!.Name), White);
                        var level = c.ClassLevel;
                        SetCellBackgroundWithText(level == Data.MaxLevel ? Green : (level > 0 ? Yellow : Red), level.ToString(), Black);
                        var storyProgress = c.GetStoryProgress();
                        SetCellBackgroundWithText(storyProgress == Data.MaxStoryLevel ? Green : (storyProgress > 0 ? Yellow : Red), StoryProgressToString[storyProgress], Black);
                        SetCellBackground(c.LowGear || c.ClassLevel == Data.MaxLevel ? Green : Red);
                        SetCellBackground(c.CurGear ? Green : Red);

                    }

                    ImGui.TableNextRow();
                    SetCellBackgroundWithText(default, $"Tanks", Black);
                    ImGui.TableNextRow();
                    SetCellBackgroundWithText(default, $"Tanks", White);
                    ImGui.TableNextColumn();
                    SetCellBackgroundWithText(default, $"DPS", White);
                    ImGui.TableNextColumn();
                    SetCellBackgroundWithText(default, $"Healers", White);
                    ImGui.TableNextRow();
                    SetCellBackgroundWithText(default, $"DRK", White);
                    SetCellBackgroundWithText(default, Context.Charas.Where(c => c.ClassID == 32).AsNoTracking().Count().ToString(), White);
                    SetCellBackgroundWithText(default, $"BLM", White);
                    SetCellBackgroundWithText(default, Context.Charas.Where(c => c.ClassID == 25).AsNoTracking().Count().ToString(), White);
                    SetCellBackgroundWithText(default, $"AST", White);
                    SetCellBackgroundWithText(default, Context.Charas.Where(c => c.ClassID == 33).AsNoTracking().Count().ToString(), White);
                    ImGui.TableNextRow();
                    SetCellBackgroundWithText(default, $"GNB", White);
                    SetCellBackgroundWithText(default, Context.Charas.Where(c => c.ClassID == 37).AsNoTracking().Count().ToString(), White);
                    SetCellBackgroundWithText(default, $"BRD", White);
                    SetCellBackgroundWithText(default, Context.Charas.Where(c => c.ClassID == 23).AsNoTracking().Count().ToString(), White);
                    SetCellBackgroundWithText(default, $"SCH", White);
                    SetCellBackgroundWithText(default, Context.Charas.Where(c => c.ClassID == 28).AsNoTracking().Count().ToString(), White);
                    ImGui.TableNextRow();
                    SetCellBackgroundWithText(default, $"PLD", White);
                    SetCellBackgroundWithText(default, Context.Charas.Where(c => c.ClassID == 19).AsNoTracking().Count().ToString(), White);
                    SetCellBackgroundWithText(default, $"DNC", White);
                    SetCellBackgroundWithText(default, Context.Charas.Where(c => c.ClassID == 38).AsNoTracking().Count().ToString(), White);
                    SetCellBackgroundWithText(default, $"SGE", White);
                    SetCellBackgroundWithText(default, Context.Charas.Where(c => c.ClassID == 40).AsNoTracking().Count().ToString(), White);
                    ImGui.TableNextRow();
                    SetCellBackgroundWithText(default, $"WAR", White);
                    SetCellBackgroundWithText(default, Context.Charas.Where(c => c.ClassID == 21).AsNoTracking().Count().ToString(), White);
                    SetCellBackgroundWithText(default, $"DRG", White);
                    SetCellBackgroundWithText(default, Context.Charas.Where(c => c.ClassID == 22).AsNoTracking().Count().ToString(), White);
                    SetCellBackgroundWithText(default, $"WHM", White);
                    SetCellBackgroundWithText(default, Context.Charas.Where(c => c.ClassID == 24).AsNoTracking().Count().ToString(), White);
                    ImGui.TableNextRow();
                    ImGui.TableNextColumn();
                    ImGui.TableNextColumn();
                    SetCellBackgroundWithText(default, $"MCH", White);
                    SetCellBackgroundWithText(default, Context.Charas.Where(c => c.ClassID == 31).AsNoTracking().Count().ToString(), White);
                    ImGui.TableNextColumn();
                    ImGui.TableNextColumn();
                    ImGui.TableNextRow();
                    ImGui.TableNextColumn();
                    ImGui.TableNextColumn();
                    SetCellBackgroundWithText(default, $"MNK", White);
                    SetCellBackgroundWithText(default, Context.Charas.Where(c => c.ClassID == 20).AsNoTracking().Count().ToString(), White);
                    ImGui.TableNextColumn();
                    ImGui.TableNextColumn();
                    ImGui.TableNextRow();
                    ImGui.TableNextColumn();
                    ImGui.TableNextColumn();
                    SetCellBackgroundWithText(default, $"NIN", White);
                    SetCellBackgroundWithText(default, Context.Charas.Where(c => c.ClassID == 30).AsNoTracking().Count().ToString(), White);
                    ImGui.TableNextColumn();
                    ImGui.TableNextColumn();
                    ImGui.TableNextRow();
                    ImGui.TableNextColumn();
                    ImGui.TableNextColumn();
                    SetCellBackgroundWithText(default, $"RDM", White);
                    SetCellBackgroundWithText(default, Context.Charas.Where(c => c.ClassID == 35).AsNoTracking().Count().ToString(), White);
                    ImGui.TableNextColumn();
                    ImGui.TableNextColumn();
                    ImGui.TableNextRow();
                    ImGui.TableNextColumn();
                    ImGui.TableNextColumn();
                    SetCellBackgroundWithText(default, $"RPR", White);
                    SetCellBackgroundWithText(default, Context.Charas.Where(c => c.ClassID == 39).AsNoTracking().Count().ToString(), White);
                    ImGui.TableNextColumn();
                    ImGui.TableNextColumn();
                    ImGui.TableNextRow();
                    ImGui.TableNextColumn();
                    ImGui.TableNextColumn();
                    SetCellBackgroundWithText(default, $"SAM", White);
                    SetCellBackgroundWithText(default, Context.Charas.Where(c => c.ClassID == 34).AsNoTracking().Count().ToString(), White);
                    ImGui.TableNextColumn();
                    ImGui.TableNextColumn();
                    ImGui.TableNextRow();
                    ImGui.TableNextColumn();
                    ImGui.TableNextColumn();
                    SetCellBackgroundWithText(default, $"SMN", White);
                    SetCellBackgroundWithText(default, Context.Charas.Where(c => c.ClassID == 27).AsNoTracking().Count().ToString(), White);
                    ImGui.TableNextColumn();
                    ImGui.TableNextColumn();

                    ImGui.EndTable();
                }
                ImGui.EndTabItem();
            }

        }
    }
}
