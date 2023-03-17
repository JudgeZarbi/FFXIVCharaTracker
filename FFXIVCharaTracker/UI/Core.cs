using FFXIVCharaTracker.DB;
using ImGuiNET;
using System.Diagnostics;
using System.Numerics;

namespace FFXIVCharaTracker
{
    internal partial class PluginUI : IDisposable
    {
        private Plugin Plugin { get; }

        internal bool Show;

        public bool UIUpdated = false;

        public CharaContext Context = new();

        private static float Scale;
        private readonly Stopwatch SearchTimer = new();

        internal PluginUI(Plugin plugin)
        {
            Plugin = plugin;

            Plugin.PluginInterface.UiBuilder.Draw += Draw;

            unsafe
            {
                Clipper = ImGuiNative.ImGuiListClipper_ImGuiListClipper();
            }

            CraftingTask = Task.Run(CraftingThreadTask);
        }

        public void Dispose()
        {
            Plugin.PluginInterface.UiBuilder.Draw -= Draw;
            Context.Dispose();
            StopCraftingTask = true;
            while (CraftingTask.Status is not TaskStatus.RanToCompletion and not TaskStatus.Faulted)
            {
            }
        }

        internal void Draw()
        {
            if (!Show)
            {
                return;
            }

            UIUpdated = false;

            Scale = ImGui.GetIO().FontGlobalScale;
            ImGui.SetNextWindowSize(new Vector2(700, 500), ImGuiCond.FirstUseEver);

            ImGui.Begin($"FFXIV Character Tracker", ref Show);

            var flags = ImGuiTabBarFlags.AutoSelectNewTabs;
            if (ImGui.BeginTabBar("showTypeTabBar", flags))
            {
                DrawPersonalTab();
                DrawSquadTab();
                DrawInventoryTab();
                DrawCraftingTab();
                DrawExtrasTab();
                ImGui.EndTabBar();
            }
            if (UIUpdated)
            {
                Context.SaveChanges();
            }
        }
        private static void SetUpTableColumns(float column1Width = 4.0f, float column2Width = 6.0f)
        {
            ImGui.TableSetupColumn("", ImGuiTableColumnFlags.WidthStretch, column1Width);
            ImGui.TableSetupColumn("", ImGuiTableColumnFlags.WidthStretch, column2Width);
        }

        private void SetCellBackgroundWithText(Vector4 colour, string text, Vector4? textColour = null)
        {
            ImGui.TableNextColumn();
            ImGui.TableSetBgColor(ImGuiTableBgTarget.CellBg, ImGui.GetColorU32(colour));
            ImGui.TextColored(textColour ?? Black, text);
        }
    }
}
