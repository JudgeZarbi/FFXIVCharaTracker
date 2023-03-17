using System.Numerics;

namespace FFXIVCharaTracker
{
    internal partial class PluginUI
    {
        internal readonly Dictionary<int, string> GCRankToString =
            new()
            {
                        { 0, "Start" },
                        { 1, "Private Third Class" },
                        { 2, "Private Second Class" },
                        { 3, "Private First Class" },
                        { 4, "Corporal" },
                        { 5, "Sergeant Third Class" },
                        { 6, "Sergeant Second Class" },
                        { 7, "Sergeant First Class" },
                        { 8, "Chief Sergeant" },
                        { 9, "Second Lieutenant" },
                        { 10, "First Lieutenant" },
                        { 11, "Captain" },
            };

        private readonly Vector4 Red = new(1, 0, 0, 1);
        private readonly Vector4 Green = new(0, 1, 0, 1);
        private readonly Vector4 Blue = new(0, 0, 1, 1);
        private readonly Vector4 Yellow = new(1, 1, 0, 1);
        private readonly Vector4 White = new(1, 1, 1, 1);
        private readonly Vector4 Black = new(0, 0, 0, 1);

        internal static readonly Dictionary<uint, uint> DropdownToClassID =
            new()
            {
                        { 0, 33 },
                        { 1, 25 },
                        { 2, 23 },
                        { 3, 38 },
                        { 4, 22 },
                        { 5, 32 },
                        { 6, 37 },
                        { 7, 31 },
                        { 8, 20 },
                        { 9, 30 },
                        { 10, 19 },
                        { 11, 35 },
                        { 12, 39 },
                        { 13, 34 },
                        { 14, 28 },
                        { 15, 40 },
                        { 16, 27 },
                        { 17, 21 },
                        { 18, 24 },
                        { 33, 0 }
            };

        internal static readonly Dictionary<uint, uint> ClassIDToDropdown =
            DropdownToClassID.ToDictionary(i => i.Value, i => i.Key);

        internal readonly Dictionary<int, string> StoryProgressToString =
            new()
            {
                { 0, "Start" },
                { Data.QuestCompleteOrigin, "Origin" },
                { Data.QuestCompleteRetainer, "Origin" },
                { Data.QuestComplete20, "2.0" },
                { Data.QuestComplete21, "2.1" },
                { Data.QuestComplete22, "2.2" },
                { Data.QuestComplete23, "2.3" },
                { Data.QuestComplete24, "2.4" },
                { Data.QuestComplete255, "2.55" },
                { Data.QuestComplete30, "3.0" },
                { Data.QuestComplete31, "3.1" },
                { Data.QuestComplete32, "3.2" },
                { Data.QuestComplete33, "3.3" },
                { Data.QuestComplete34, "3.4" },
                { Data.QuestComplete355, "3.55" },
                { Data.QuestComplete40, "4.0" },
                { Data.QuestComplete41, "4.1" },
                { Data.QuestComplete42, "4.2" },
                { Data.QuestComplete43, "4.3" },
                { Data.QuestComplete44, "4.4" },
                { Data.QuestComplete455, "4.55" },
                { Data.QuestComplete50, "5.0" },
                { Data.QuestComplete51, "5.1" },
                { Data.QuestComplete52, "5.2" },
                { Data.QuestComplete53, "5.3" },
                { Data.QuestComplete54, "5.4" },
                { Data.QuestComplete555, "5.55" },
                { Data.QuestComplete60, "6.0" },
                { Data.QuestComplete61, "6.1" },
                { Data.QuestComplete62, "6.2" },
                { Data.QuestComplete63, "6.3" },
            };
    }
}
