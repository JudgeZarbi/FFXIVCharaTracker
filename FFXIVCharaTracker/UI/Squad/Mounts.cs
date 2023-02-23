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
        internal void DrawSquadMountsSection(List<Chara> charas)
        {
            if (ImGui.BeginTabItem("Mounts"))
            {
                ImGui.Indent();

                var lastAccount = -1;
                var lastWorld = 0u;

                if (ImGui.BeginTabBar("squadMounts"))
                {
                    if (ImGui.BeginTabItem("Achievements"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("squadmountsAchievement", 40, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, "Ahriman", "Behemoth", "Gilded Magitek Armor", "Warlion", "Warbear", "Storm Warsteed", "Serpent Warsteed", "Flame Warsteed", "Parade Chocobo", "Logistics System", "War Panther", "Gloria-class Airship", "Astrope", "Aerodynamics System", "Goten", "Ginga", "Raigo", "Battle Lion", "Battle Bear", "Battle Panther", "Centurio Tiger", "Magitek Avenger", "Magitek Death Claw", "Safeguard System", "Juedi", "Magitek Avenger A1", "Demi-Ozma", "War Tiger", "Triceratops", "Amaro", "Battle Tiger", "Morbol", "Construct VII", "Hybodus", "Pteranodon", "Cerberus", "Al-iklil", "Victor", "Silkie");

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsMountUnlocked(9) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(18) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(21) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(32) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(33) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(36) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(37) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(38) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(44) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(48) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(56) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(80) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(83) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(91) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(95) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(96) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(102) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(122) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(123) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(124) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(127) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(141) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(145) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(168) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(166) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(141) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(186) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(183) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(190) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(187) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(197) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(200) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(204) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(218) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(216) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(235) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(246) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(267) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(304) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Tribes"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("squadmountsTribe", 18, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, "Cavalry Drake", "Laurel Goobbue", "Cavalry Elbst", "Bomb Palanquin", "Direwolf", "Sanuwa", "Kongamato", "Cloud Mallow", "Striped Ray", "Marid", "True Griffin", "Mikoshi", "Portly Porxie", "Great Vessel Of Ronka", "Rolling Tankard", "Hippo Cart", "Miw Miisv");

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsMountUnlocked(19) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(20) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(26) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(27) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(35) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(53) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(72) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(86) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(136) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(146) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(148) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(164) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(201) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(215) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(223) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(287) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(298) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Bozja"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("squadmountsBozja", 5, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, "Construct 14", "Gabriel Î‘", "Gabriel Mark III", "Deinonychus");

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsMountUnlocked(213) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(224) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(241) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(212) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Crafted"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("squadmountsCrafted", 3, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, "Flying Chair", "Magicked Bed");

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsMountUnlocked(140) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(193) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Deep Dungeon"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("squadmountsDeep", 5, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, "Disembodied Head", "Black Pegasus", "Dodo", "Sil'dihn Throne");

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsMountUnlocked(92) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(100) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(159) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(303) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Dungeon"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("squadmountsDungeon", 2, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, "Magitek Predator");

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsMountUnlocked(121) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Eureka"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("squadmountsEureka", 4, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, "Tyrannosaur", "Eldthurs", "Eurekan Petrel");

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsMountUnlocked(150) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(178) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(184) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("FATE"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("squadmountsFate", 5, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, "Ixion", "Ironfrog Mover", "Level Checker", "Wivre");

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsMountUnlocked(130) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(191) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(268) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(273) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Mog Station/Collector's Edition"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("squadmountsMog", 49, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, "Coeurl", "Fat Chocobo", "Draught Chocobo", "Sleipnir", "Ceremony Chocobo", "Griffin", "Amber Draught Chocobo", "Twintania", "Witch's Broom", "White Devil", "Red Baron", "Original Fat Chocobo", "Bennu", "Fat Moogle", "Eggshilaration System", "Syldra", "Managarm", "Mystic Panda", "Starlight Bear", "Aquamarine Carbuncle", "Citrine Carbuncle", "Nezha Chariot", "Broken Heart", "Broken Heart", "Red Hare", "Indigo Whale", "SDS Fenrir", "Fatter Cat", "Fat Black Chocobo", "Magicked Carpet", "Grani", "Circus Ahriman", "Sunspun Cumulus", "Spriggan Stonecarrier", "Kingly Peacock", "Rubellite Carbuncle", "Chocobo Carriage", "Snowman", "Lunar Whale", "Polar Bear", "Cruise Chaser", "Arion", "Papa Paissa", "Megashiba", "Mechanical Lotus", "Magicked Umbrella", "Magicked Parasol", "Set Of Ceruleum Balloons");

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsMountUnlocked(8) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(25) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(34) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(42) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(41) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(54) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(52) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(59) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(62) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(68) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(69) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(82) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(74) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(84) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(106) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(111) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(93) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(97) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(99) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(138) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(139) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(135) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(152) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(153) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(143) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(160) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(71) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(171) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(177) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(175) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(170) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(194) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(195) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(206) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(214) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(220) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(222) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(232) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(233) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(250) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(247) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(237) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(269) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(294) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(279) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(300) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(301) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(310) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("PvP"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("squadmountsPvp", 4, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, "Magitek Sky Armor");

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsMountUnlocked(174) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Raid"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("squadmountsRaid", 11, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, "Gobwalker", "Arrhidaeus", "Alte Roite", "Air Force", "Model O", "Skyslipper", "Ramuh", "Eden", "Demi-Phoinix", "Sunforged");

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsMountUnlocked(58) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(101) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(126) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(156) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(173) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(188) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(219) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(234) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(265) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(305) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Ishgardian Restoration"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("squadmountsSkybuilder", 9, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, "Pegasus", "Ufiti", "Dhalmel", "Albino Karakul", "Megalotragus", "Big Shell", "Antelope Doe", "Antelope Stag");

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsMountUnlocked(67) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(211) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(208) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(209) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(225) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(236) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(242) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(243) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Treasure Hunt"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("squadmountsTreasure", 4, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, "Alkonost", "Phaethon", "Pinky");

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsMountUnlocked(281) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(313) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(314) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Trial"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("squadmountsTrial", 35, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, "Nightmare", "Aithon", "Xanthos", "Gullfaxi", "Enbarr", "Markab", "Boreas", "White Lanner", "Rose Lanner", "Round Lanner", "Warring Lanner", "Dark Lanner", "Sophic Lanner", "Demonic Lanner", "Blissful Kamuy", "Reveling Kamuy", "Legendary Kamuy", "Auspicious Kamuy", "Lunar Kamuy", "Rathalos", "Euphonious Kamuy", "Hallowed Kamuy", "Fae Gwiber", "Innocent Gwiber", "Shadow Gwiber", "Ruby Gwiber", "Gwiber Of Light", "Emerald Gwiber", "Diamond Gwiber", "Lynx Of Eternal Darkness", "Lynx Of Divine Light", "Bluefeather Lynx", "Lynx Of Imperious Wind", "Lynx Of Righteous Fire");

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsMountUnlocked(22) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(28) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(29) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(30) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(31) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(40) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(43) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(75) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(76) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(77) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(78) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(90) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(98) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(104) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(115) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(116) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(133) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(144) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(158) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(161) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(172) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(182) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(189) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(192) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(205) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(217) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(226) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(238) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(249) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(261) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(262) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(293) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(306) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(315) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Voyages"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("squadmountsVoyage", 2, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, "Zu");

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsMountUnlocked(73) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Wondrous Tails/Faux Hollows"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("squadmountsTails", 7, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, "Ixion", "Incitatus", "Construct VI-S", "Calydontis", "Troll", "Wondrous Lanner");

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsMountUnlocked(130) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(231) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(248) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(266) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(288) ? Green : Red);
                                SetCellBackground(c.IsMountUnlocked(299) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Shop"))
                    {
                        ImGui.Indent();
                        if (ImGui.BeginTabBar("squadMountsShop"))
                        {
                            if (ImGui.BeginTabItem("Gil"))
                            {
                                ImGui.Unindent();
                                ImGui.Unindent();
                                ImGui.Unindent();

                                if (ImGui.BeginTable("squadmountsGil", 5, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                                {
                                    SetUpSquadTableHeaders(0, "Gilded Mikoshi", "Resplendent Vessel Of Ronka", "Magitek Avenger G1", "Chrysomallos");

                                    foreach (var c in charas)
                                    {
                                        DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                        SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                        SetCellBackground(c.IsMountUnlocked(252) ? Green : Red);
                                        SetCellBackground(c.IsMountUnlocked(253) ? Green : Red);
                                        SetCellBackground(c.IsMountUnlocked(141) ? Green : Red);
                                        SetCellBackground(c.IsMountUnlocked(317) ? Green : Red);
                                    }
                                    ImGui.EndTable();
                                }
                                ImGui.EndTabItem();
                            }
                            if (ImGui.BeginTabItem("MGP"))
                            {
                                ImGui.Unindent();
                                ImGui.Unindent();
                                ImGui.Unindent();

                                if (ImGui.BeginTable("squadmountsSaucer", 9, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                                {
                                    SetUpSquadTableHeaders(0, "Adamantoise", "Fenrir", "Archon Throne", "Korpokkur Kolossus", "Typhon", "Sabotender Emperador", "Pod 602", "Blackjack");

                                    foreach (var c in charas)
                                    {
                                        DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                        SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                        SetCellBackground(c.IsMountUnlocked(46) ? Green : Red);
                                        SetCellBackground(c.IsMountUnlocked(49) ? Green : Red);
                                        SetCellBackground(c.IsMountUnlocked(110) ? Green : Red);
                                        SetCellBackground(c.IsMountUnlocked(142) ? Green : Red);
                                        SetCellBackground(c.IsMountUnlocked(154) ? Green : Red);
                                        SetCellBackground(c.IsMountUnlocked(180) ? Green : Red);
                                        SetCellBackground(c.IsMountUnlocked(284) ? Green : Red);
                                        SetCellBackground(c.IsMountUnlocked(312) ? Green : Red);
                                    }
                                    ImGui.EndTable();
                                }
                                ImGui.EndTabItem();
                            }
                            if (ImGui.BeginTabItem("Hunt Currency"))
                            {
                                ImGui.Unindent();
                                ImGui.Unindent();
                                ImGui.Unindent();

                                if (ImGui.BeginTable("squadmountsHunts", 4, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                                {
                                    SetUpSquadTableHeaders(0, "Wyvern", "Forgiven Reticence", "Vinegaroon");

                                    foreach (var c in charas)
                                    {
                                        DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                        SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                        SetCellBackground(c.IsMountUnlocked(70) ? Green : Red);
                                        SetCellBackground(c.IsMountUnlocked(207) ? Green : Red);
                                        SetCellBackground(c.IsMountUnlocked(291) ? Green : Red);
                                    }
                                    ImGui.EndTable();
                                }
                                ImGui.EndTabItem();
                            }
                            if (ImGui.BeginTabItem("Island Sanctuary"))
                            {
                                ImGui.Unindent();
                                ImGui.Unindent();
                                ImGui.Unindent();

                                if (ImGui.BeginTable("squadmountsSanctuary", 6, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                                {
                                    SetUpSquadTableHeaders(0, "Garlond GL-II", "Island Mandragora", "Island Onion Prince", "Island Eggplant Knight", "Island Alligator");

                                    foreach (var c in charas)
                                    {
                                        DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                        SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                        SetCellBackground(c.IsMountUnlocked(277) ? Green : Red);
                                        SetCellBackground(c.IsMountUnlocked(255) ? Green : Red);
                                        SetCellBackground(c.IsMountUnlocked(256) ? Green : Red);
                                        SetCellBackground(c.IsMountUnlocked(257) ? Green : Red);
                                        SetCellBackground(c.IsMountUnlocked(286) ? Green : Red);
                                    }
                                    ImGui.EndTable();
                                }
                                ImGui.EndTabItem();
                            }
                            ImGui.EndTabBar();
                        }
                        ImGui.EndTabItem();
                    }
                    ImGui.EndTabBar();
                }
                ImGui.EndTabItem();
            }

        }
    }
}
