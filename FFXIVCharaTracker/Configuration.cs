using Dalamud.Configuration;
using Dalamud.Plugin;

namespace FFXIVCharaTracker
{

    [Serializable]
    public class Configuration : IPluginConfiguration
    {
        public int Version { get; set; } = 1;
        public int DbVersion { get; set; } = 0;

        // the below exist just to make saving less cumbersome

        [NonSerialized]
        private DalamudPluginInterface? pluginInterface;

        public void Initialize(DalamudPluginInterface pluginInterface)
        {
            this.pluginInterface = pluginInterface;
        }

        public void Save()
        {
            this.pluginInterface!.SavePluginConfig(this);
        }
    }
}
