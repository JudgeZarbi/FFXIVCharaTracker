using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dalamud.Game.Command;
using FFXIVClientStructs.FFXIV.Client.Game.UI;
using Dalamud.Logging;
using Lumina.Data.Parsing;
using Lumina.Excel.GeneratedSheets;
using System.Drawing.Printing;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using Dalamud.Data;

namespace FFXIVCharaTracker
{
    internal partial class Commands : IDisposable
    {
        private Plugin Plugin { get; }

        internal Commands(Plugin plugin)
        {
			Plugin = plugin;

            Plugin.CommandManager.AddHandler("/pchara", new CommandInfo(OnCommand)
            {
                HelpMessage = "Show Character Tracker window",
            });
#if DEBUG || RELEASE_DEV
			Plugin.CommandManager.AddHandler("/charatest", new CommandInfo(OnCommandTest)
			{
				HelpMessage = "KEKW",
			});
#endif
        }

		public void Dispose()
        {
            Plugin.CommandManager.RemoveHandler("/pchara");
#if DEBUG || RELEASE_DEV
			Plugin.CommandManager.RemoveHandler("/charatest");
#endif
        }

		private void OnCommand(string command, string args)
        {
			//this.Plugin.GetCharacterData();
			Plugin.UI.Show ^= true;
			Plugin.UpdateCharacterData();
        }
#if DEBUG || RELEASE_DEV
        private void OnCommandTest(string command, string args)
		{
			/*var data = File.ReadAllText("D:\\Users\\Daniel\\Documents\\Git repos\\FFXIVCharaTracker\\minions.txt");
			var minionIds = new List<uint>();

			foreach (var row in Plugin.Mounts)
			{
				if (row.Singular == "")
				{
					continue;
				}

				var newData = Regex.Replace(data, @$"(DrawMount\(""{row.Singular}( \()?.*"",) (?<id>!=)\);", $"$1 {row.RowId});", RegexOptions.Compiled | RegexOptions.IgnoreCase);

				if (newData != data)
				{
					minionIds.Add(row.RowId);
					data = newData;
				}
			}

			File.WriteAllText("D:\\Users\\Daniel\\Documents\\Git repos\\FFXIVCharaTracker\\minionsNew.txt", data);
			File.WriteAllText("D:\\Users\\Daniel\\Documents\\Git repos\\FFXIVCharaTracker\\minionsIds.txt", String.Join(", ", minionIds));*/
			/*var data = File.ReadAllText("D:\\Users\\Daniel\\Documents\\Git repos\\FFXIVCharaTracker\\minions.txt");
            var minionIds = new List<uint>();

			foreach (var row in Plugin.Companions)
            {
                if (row.Singular == "")
                {
                    continue;
                }

				var newData = Regex.Replace(data, @$"(DrawMinion\(""{row.Singular}( \()?.*"",) (?<id>!=)\);", $"$1 {row.RowId});", RegexOptions.Compiled | RegexOptions.IgnoreCase);

                if (newData != data)
                {
                    minionIds.Add(row.RowId);
                    data = newData;
                }
			}

            File.WriteAllText("D:\\Users\\Daniel\\Documents\\Git repos\\FFXIVCharaTracker\\minionsNew.txt", data);
			File.WriteAllText("D:\\Users\\Daniel\\Documents\\Git repos\\FFXIVCharaTracker\\minionsIds.txt", String.Join(", ", minionIds));*/

			PluginLog.Warning("KEKW");

            foreach (var lul in Plugin.DataManager.Excel.GetSheet<SecretRecipeBook>()!)
            {
                PluginLog.Warning($"{lul.RowId.ToString()}, {lul.Name}");
            }
			//PluginLog.Warning(Plugin.Gui.FindAgentInterface("SatisfactionSupply").ToString());
			//PluginLog.Warning(string.Join(", ", Data.OptionalContentIDs.Select(i => Plugin.ContentFinderConditions.GetRow(i).Content).ToArray()));
		}
#endif
	}

}
