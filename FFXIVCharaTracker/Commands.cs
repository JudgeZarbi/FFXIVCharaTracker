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
using FFXIVCharaTracker.DB;
using FFXIVClientStructs.FFXIV.Client.Game;
using System.ComponentModel;
using XivCommon.Functions;
using FFXIVClientStructs.FFXIV.Client.System.Framework;
using FFXIVClientStructs.FFXIV.Client.UI;
using Dalamud.Utility.Signatures;
using System.Runtime.InteropServices;
using System.Threading;
using FFXIVClientStructs.Attributes;
using FFXIVClientStructs.FFXIV.Component.GUI;
using FFXIVClientStructs.FFXIV.Client.System.String;
using Dalamud.Hooking;
using System.Windows.Forms;
using System.Drawing;
using TextCopy;
using FFXIVClientStructs.FFXIV.Common.Math;
using System.Globalization;

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
        }

        public void Dispose()
        {
            Plugin.CommandManager.RemoveHandler("/pchara");
		}

		private void OnCommand(string command, string args)
        {
			//this.Plugin.GetCharacterData();
			Plugin.UI.Show ^= true;
			Plugin.UpdateCharacterData();
        }

    }
}
