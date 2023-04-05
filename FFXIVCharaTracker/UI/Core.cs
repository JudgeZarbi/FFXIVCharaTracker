using FFXIVCharaTracker.DB;
using ImGuiNET;
using System.Diagnostics;
using System.Numerics;
using System.Globalization;

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

        private string GetRealDateFromGameDate(int birthDay, int birthMonth)
        {
            if (birthDay == 0 || birthMonth == 0)
            {
                return "";
            }
            var daysInMonth = DateTime.DaysInMonth(2020, birthMonth);

            if (daysInMonth == 29)
            {
                if (birthDay >= 24)
                {
                    birthDay--;
                }
                if (birthDay >= 16)
                {
                    birthDay--;
                }
                if (birthDay >= 8)
                {
                    birthDay--;
                }
            }
            else if (daysInMonth == 30)
            {
                if (birthDay >= 30)
                {
                    birthDay--;
                }
                if (birthDay >= 8)
                {
                    birthDay--;
                }
            }
            else if (daysInMonth == 31)
            {
                if (birthDay >= 29)
                {
                    birthDay--;
                }
            }

            return $"({birthDay}{GetOrdinalSuffix(birthDay)} {CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(birthMonth)})";
        }

        private static string GetOrdinalSuffix(int num)
        {
            string number = num.ToString();
            if (number.EndsWith("11")) return "th";
            if (number.EndsWith("12")) return "th";
            if (number.EndsWith("13")) return "th";
            if (number.EndsWith("1")) return "st";
            if (number.EndsWith("2")) return "nd";
            if (number.EndsWith("3")) return "rd";
            return "th";
        }
    }
}
