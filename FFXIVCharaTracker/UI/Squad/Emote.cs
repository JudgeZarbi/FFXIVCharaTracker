using FFXIVCharaTracker.DB;
using ImGuiNET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFXIVCharaTracker
{
    internal partial class PluginUI
    {
        internal void DrawSquadEmotesSection(List<Chara> charas)
        {
            if (ImGui.BeginTabItem("Emote"))
            {
                var lastAccount = -1;
                var lastWorld = 0u;

                ImGui.Indent();
                if (ImGui.BeginTabBar("squadEmotes"))
                {
                    if (ImGui.BeginTabItem("Sidequests"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("squadEmotesSidequest", 10, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, "Throw", "Step Dance", "Harvest Dance", "Ball Dance", "Manderville Dance", "Most Gentlemanly", "Spectacles", "Manderville Mambo", "Lali-ho");

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsEmoteUnlocked(85) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(101) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(102) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(103) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(104) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(114) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(148) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(198) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(199) ? Green : Red);

                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Tribe"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("squadEmotesTribe", 9, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, "Sundrop Dance", "Moogle Dance", "Moonlift Dance", "Ritual Prayer", "Charmed", "Yol Dance", "Gratuity", "Lali Hop");

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                ImGui.TableSetBgColor(ImGuiTableBgTarget.CellBg, ImGui.GetColorU32(c.IsEmoteUnlocked(120) ? Green : Red));
                                SetCellBackground(c.IsEmoteUnlocked(126) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(145) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(167) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(64) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(176) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(194) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(217) ? Green : Red);

                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();

                    }
                    if (ImGui.BeginTabItem("Gold Saucer"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("squadEmotesSaucer", 8, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, "Thavnairian Dance", "Gold Dance", "Aback", "Big Grin", "Bee's Knees", "Sheathe Weapon", "Draw Weapon");

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsEmoteUnlocked(118) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(119) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(171) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(81) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(216) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(237) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(238) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();

                    }
                    if (ImGui.BeginTabItem("Squadron"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("squadEmotesSquadron", 5, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, "Squats", "Push-ups", "Sit-ups", "Breath Control");

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsEmoteUnlocked(155) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(156) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(157) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(158) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();

                    }
                    if (ImGui.BeginTabItem("GC Seals"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("squadEmotesGC", 4, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, "Attention", "At Ease", "Reflect");

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsEmoteUnlocked(164) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(165) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(82) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();

                    }
                    if (ImGui.BeginTabItem("Hunts"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("squadEmotesHunts", 3, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, "Winded", "Tremble");

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsEmoteUnlocked(170) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(169) ? Green : Red);

                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();

                    }
                    if (ImGui.BeginTabItem("PvP"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("squadEmotesPvP", 3, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, "Elucidate", "Reprimand");

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsEmoteUnlocked(182) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(196) ? Green : Red);

                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();

                    }
                    if (ImGui.BeginTabItem("Deep/Variant Dungeon"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("squadEmotesDeep", 3, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, "Sweat", "Wow");

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsEmoteUnlocked(180) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(246) ? Green : Red);

                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();

                    }
                    if (ImGui.BeginTabItem("Eureka"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("squadEmotesEureka", 4, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, "Shiver", "Scheme", "Fist Pump");

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsEmoteUnlocked(181) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(189) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(195) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();

                    }
                    if (ImGui.BeginTabItem("Bozja"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("squadEmotesBozja", 4, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, "Guard", "Malevolence", "Wring Hands");

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsEmoteUnlocked(214) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(215) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(222) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();

                    }
                    if (ImGui.BeginTabItem("Treasure Hunts"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("squadEmotesTreasure", 6, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, "Confirm", "Paint it Black", "Paint it Red", "Paint it Yellow", "Paint it Blue");

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsEmoteUnlocked(188) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(224) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(225) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(226) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(227) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();

                    }
                    if (ImGui.BeginTabItem("Ishgardian Restoration"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("squadEmotesResto", 9, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, "Lean", "Insist", "Break Fast", "Read", "High Five", "Eat Rice Ball", "Eat Apple", "Sweep Up");

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsEmoteUnlocked(203) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(208) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(206) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(207) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(213) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(220) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(221) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(223) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();

                    }
                    if (ImGui.BeginTabItem("Mog Station"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("squadEmotesMog", 41, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, "Bomb Dance", "Huzzah", "Eureka", "Black Ranger Pose A", "Black Ranger Pose B", "Yellow Ranger Pose A", "Yellow Ranger Pose B", "Red Ranger Pose A", "Red Ranger Pose B", "Eastern Greeting", "Dote", "Songbird", "Play Dead", "Eastern Stretch", "Eastern Dance", "Pretty Please", "Power Up", "Cheer On", "Cheer Wave", "Cheer Jump", "Megaflare", "Splash", "Crimson Lotus", "Box Step", "Side Step", "Senor Sabotender", "Get Fantasy", "Popoto Step", "Toast", "Heel Toe", "Goobbue Do", "Consider", "Flame Dance", "Wasshoi", "Flower Shower", "Pantomime", "Vexed", "Drink Tea", "Deride");

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsEmoteUnlocked(109) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(110) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(125) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(131) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(135) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(132) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(136) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(130) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(134) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(124) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(146) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(149) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(143) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(128) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(129) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(142) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(153) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(65) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(66) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(67) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(62) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(178) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(63) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(173) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(174) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(197) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(185) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(186) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(202) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(205) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(192) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(193) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(209) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(212) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(210) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(211) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(229) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(230) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(239) ? Green : Red);
                                SetCellBackground(c.IsEmoteUnlocked(245) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                        if (ImGui.BeginTabItem("Other"))
                        {
                            ImGui.Unindent();
                            ImGui.Unindent();

                            if (ImGui.BeginTable("squadEmotesOther", 2, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                            {
                                SetUpSquadTableHeaders(0, "Headache", "Embrace");

                                foreach (var c in charas)
                                {
                                    DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                    SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                    SetCellBackground(c.IsEmoteUnlocked(204) ? Green : Red);
                                    SetCellBackground(c.IsEmoteUnlocked(113) ? Green : Red);
                                }
                                ImGui.EndTable();
                            }
                            ImGui.EndTabItem();
                        }
                    }
                    ImGui.EndTabBar();
                }
                ImGui.EndTabItem();
            }

        }
    }
}
