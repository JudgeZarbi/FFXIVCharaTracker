using Dalamud.Game.Command;

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
			Plugin.CurCharaData?.UpdateCharacterData();
        }

    }
}
