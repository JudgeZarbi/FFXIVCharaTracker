using ImGuiNET;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextCopy;

namespace FFXIVCharaTracker
{
    internal partial class PluginUI
    {
        internal void DrawExtrasTab()
        {
            if (ImGui.BeginTabItem("Extras"))
            {
                if (ImGui.Button("Export character list to clipboard"))
                {
                    var charas = Context.Charas.FromSql($"SELECT * FROM Charas ORDER BY Account ASC, WorldID ASC, CharaID ASC").AsNoTracking();
                    var output = new StringBuilder();
                    foreach (var c in charas)
                    {
                        var classData = Plugin.ClassJobs.GetRow(c.ClassID);
                        output.AppendLine($":{classData!.NameEnglish.ToString().Replace(" ", "")}: {c.Forename} {c.Surname} - {Plugin.Worlds.GetRow(c.WorldID)!.Name}");
                    }

                    ClipboardService.SetText(output.ToString());
                }
                if (ImGui.Button("Reset player combat gear status"))
                {
                    Context.ResetPlayerCombatGear();
                    UIUpdated = true;
                }
                if (ImGui.Button("Reset player gather gear status"))
                {
                    Context.ResetPlayerGatherGear();
                    UIUpdated = true;
                }
                if (ImGui.Button("Reset retainer combat gear status"))
                {
                    Context.ResetRetainerCombatGear();
                    UIUpdated = true;
                }
                if (ImGui.Button("Reset retainer combat gear status"))
                {
                    Context.ResetRetainerGatherGear();
                    UIUpdated = true;
                }
                if (ImGui.Button("Reset retainer item status"))
                {
                    Context.ResetRetainerItems();
                    UIUpdated = true;
                }
                ImGui.EndTabItem();
            }

        }
    }
}
