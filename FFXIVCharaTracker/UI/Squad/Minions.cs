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
        internal void DrawSquadMinionsSection(List<Chara> charas)
        {
            if (ImGui.BeginTabItem("Minions"))
            {
                ImGui.Indent();

                var lastAccount = -1;
                var lastWorld = 0u;

                if (ImGui.BeginTabBar("squadMinions"))
                {
                    if (ImGui.BeginTabItem("Achievements"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("squadminionsAchievement", 30, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, "Black Chocobo Chick", "Beady Eye", "Wind-up Cursor", "Wind-up Leader", "Minion of Light", "Wind-up Odin", "Wind-up Warrior of Light ", "Wind-up Goblin", "Wind-up Gilgamesh", "Wind-up Nanamo", "Wind-up Firion", "Komainu", "Mammet #003L", "Mammet #003G", "Mammet #003U", "Princely Hatchling", "Fledgling Apkallu", "Wind-up Louisoix", "Shalloweye", "Clockwork Twintania", "Penguin Prince", "Hellpup", "Faepup", "The Major-General", "Malone", "Laladile", "Much-coveted Mora", "Dolphin Calf", "Gull");

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsMinionUnlocked(54) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(36) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(51) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(71) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(67) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(76) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(77) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(49) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(85) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(84) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(167) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(288) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(6) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(7) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(8) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(75) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(40) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(118) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(163) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(165) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(164) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(234) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(240) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(375) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(367) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(378) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(396) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(410) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(408) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Tribes"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("squadminionsTribe", 29, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, "Wind-up Sylph", "Wind-up Violet", "Wind-up Amalj'aa", "Wind-up Founder", "Wind-up Kobold", "Wind-up Kobolder", "Wind-up Sahagin", "Wind-up Sea Devil", "Wind-up Dezul Qualan", "Wind-up Ixal", "Wind-up Gundu Warrior", "Wind-up Zundu Warrior", "Wind-up Vath", "Wind-up Gnath", "Wind-up Dragonet", "Wind-up Ohl Deeh", "Wind-up Kojin", "Wind-up Redback", "Zephyrous Zabuton", "Wind-up Ananta", "Wind-up Qalyana", "Attendee #777", "Wind-up Pixie", "The Behelmeted Serpent of Ronka", "The Behatted Serpent of Ronka", "Lalinator 5.H0", "Wind-up Arkasodara", "Lumini");

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsMinionUnlocked(50) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(123) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(58) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(124) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(60) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(60) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(61) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(127) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(125) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(59) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(135) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(172) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(175) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(156) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(184) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(235) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(266) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(323) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(328) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(277) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(322) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(302) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(354) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(369) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(370) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(380) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(444) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(457) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Bozja"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("squadminionsBozja", 24, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, "Mameshiba", "Koala Joey", "Salt & Pepper Seal", "Axolotl Eft", "Wind-up Ravana", "Wind-up Shinryu", "Tengu Doll", "White Whittret", "Aurelia Polyp", "Byakko Cub", "Private Moai", "Monkey King", "Mudpie (Southern Front Lockbox, Zadnor Lockbox, Saint Mocianne's Arboretum", "Scarlet Peacock", "Abroader Otter", "Seitei", "Wind-up Weapon", "Chameleon", "Sharksucker-class Insubmersible", "Magitek Helldiver F1", "DÃ¡insleif F1", "Save the Princess (Delubrum Reginae", "Wind-up Gunnhildr");

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsMinionUnlocked(267) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(271) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(272) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(273) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(265) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(275) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(268) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(279) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(283) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(284) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(278) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(290) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(312) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(303) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(329) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(327) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(321) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(334) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(348) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(383) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(389) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(404) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(418) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Crafted"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("squadminionsCrafted", 35, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, "Magic Broom", "Clockwork Barrow", "Model Magitek Bit", "Private Moai", "Wind-up Dullahan", "Steam-powered Gobwalker G-VII", "Bantam Train", "Gravel Golem", "Model Vanguard", "Wind-up Aldgoat", "Wind-up Qiqirn", "Plush Cushion", "Nana Bear", "Wind-up Illuminatus", "Wind-up Chimera", "Wind-up Sadu", "Wind-up Magnai", "Adventurer's Basket", "Wind-up Ifrit", "Wind-up Garuda", "Wind-up Titan", "Wind-up Leviathan", "Wind-up Ramuh", "Wind-up Shiva", "Wind-up Bismarck", "Wind-up Susano", "Wind-up Lakshmi", "Wind-up Ravana", "Wind-up Shinryu", "Byakko Cub", "Scarlet Peacock", "Seitei", "Atrophied Atomos", "Wanderer's Campfire");

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsMinionUnlocked(81) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(140) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(100) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(278) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(29) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(147) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(475) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(22) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(43) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(39) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(53) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(66) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(95) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(158) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(255) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(294) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(282) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(436) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(168) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(169) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(170) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(171) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(185) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(186) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(263) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(261) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(262) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(265) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(275) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(284) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(303) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(327) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(136) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(414) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Deep Dungeon"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("squadminionsDeep", 44, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, "Wind-up Tonberry", "Tiny Bulb", "Bluebird", "Minute Mindflayer", "Baby Opo-opo", "Nutkin", "Miniature Minecart", "Mummy's Little Mummy", "Gaelikitten", "Page 63", "Unicolt", "Lesser Panda", "Gestahl", "Owlet", "Ugly Duckling", "Paissa Brat", "Korpokkur Kid", "Hunting Hawk", "Wind-up Ifrit", "Morpho", "Wind-up Garuda", "Wind-up Titan", "Wind-up Leviathan", "Dwarf Rabbit", "Wind-up Ramuh", "Wind-up Shiva", "Wind-up Sasquatch", "Hecteye", "Shaggy Shoat", "Wind-up Edda", "Baby Brachiosaur", "Castaway Chocobo Chick", "Tiny Tatsunoko", "Bombfish", "Bom Boko", "Odder Otter", "Ghido", "Road Sparrow", "Wind-up Bismarck", "Wind-up Susano", "Wind-up Lakshmi", "Wind-up Ravana", "Frilled Dragon");

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsMinionUnlocked(23) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(27) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(16) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(56) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(80) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(97) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(96) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(112) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(139) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(142) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(134) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(141) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(146) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(137) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(138) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(157) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(166) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(162) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(168) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(180) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(169) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(170) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(171) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(197) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(185) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(186) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(196) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(198) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(216) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(219) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(190) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(237) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(244) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(245) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(246) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(241) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(258) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(247) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(263) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(261) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(262) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(265) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(292) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Dungeon"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("squadminionsDungeon", 59, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, "Morbol Seedling", "Bite-sized Pudding", "Demon Brick", "Slime Puddle", "Baby Opo-opo", "Naughty Nanka", "Tight-beaked Parrot", "Mummy's Little Mummy", "Gaelikitten", "Page 63", "Unicolt", "Lesser Panda", "Owlet", "Ugly Duckling", "Korpokkur Kid", "Calca", "Brina", "Morpho", "Calamari", "Shaggy Shoat", "Bullpup", "Bombfish", "Ivon Coeurlfist Doll", "Ghido", "Road Sparrow", "Dress-up Yugiri", "Mock-up Grynewaht", "Magitek Avenger F1", "Salt & Pepper Seal", "White Whittret", "Monkey King", "Mudpie", "Wind-up Weapon", "Armadillo Bowler", "Clionid Larva", "Tiny Echevore", "Forgiven Hate", "Black Hayate", "Chameleon", "Shoebill", "Little Leannan", "Ancient One", "Ephemeral Necromancer", "Drippy", "Magitek Predator F1", "Prince Lunatender", "Tiny Troll", "Wind-up Magus Sisters", "Wind-up Anima", "Hippo Calf", "Caduceus", "Starbird", "Optimus Omicron", "Teacup Kapikulu", "Wind-up Scarmiglione", "Sponge Silkie", "Sewer Skink", "Wind-up Cagnazzo");

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsMinionUnlocked(12) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(42) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(44) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(47) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(80) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(102) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(57) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(112) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(139) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(142) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(134) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(141) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(137) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(138) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(166) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(178) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(179) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(180) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(189) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(216) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(226) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(245) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(254) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(258) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(247) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(249) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(252) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(257) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(272) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(279) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(290) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(312) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(321) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(336) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(339) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(347) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(352) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(333) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(334) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(349) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(361) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(374) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(385) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(405) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(411) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(433) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(434) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(424) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(426) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(431) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(435) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(427) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(425) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(447) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(460) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(463) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(464) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(471) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Eureka"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("squadminionsEureka", 11, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, "Calca", "Wind-up Fafnir", "The Prince Of Anemos", "Wind-up Mithra", "Copycat Bulb", "Wind-up Tarutaru", "Dhalmel Calf", "Wind-up Elvaan", "Conditional Virtue", "Yukinko Snowflake");

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsMinionUnlocked(178) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(285) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(287) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(286) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(295) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(296) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(315) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(314) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(318) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(319) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("FATE"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("squadminionsFate", 16, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, "Baby Bun", "Infant Imp", "Pudgy Puk", "Smallshell", "Gold Rush Minecart", "Fox Kit", "Wind-up Ixion", "Micro Gigantender", "Butterfly Effect", "Ironfrog Ambler", "Tinker's Bell", "Little Leafman", "Amaro Hatchling", "Wee Ea", "Wind-up Daivadipa");

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsMinionUnlocked(14) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(18) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(31) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(34) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(154) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(242) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(274) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(338) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(350) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(351) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(346) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(368) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(377) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(423) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(442) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Gathering"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("squadminionsGather", 8, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, "Tiny Tortoise", "Gigantpole", "Kidragora", "Coblyn Larva", "Magic Bucket", "Castaway Chocobo Chick", "Tiny Tatsunoko");

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsMinionUnlocked(24) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(30) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(48) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(38) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(188) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(237) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(244) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Mog Station/Collector's Edition"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("squadminionsMog", 47, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, "Baby Behemoth", "Tender Lamb", "Wind-up Edvya", "Wind-up Shantotto", "Wind-up Moogle", "Wind-up Minfilia", "Wind-up Thancred", "Wind-up Y'shtola", "Wind-up Yda", "Wind-up Papalymo", "Wind-up Urianger", "Hoary The Snowman", "Wind-up Kain", "Wind-up Alisaie", "Wind-up Tataru", "Wind-up Iceheart", "Pumpkin Butler", "Wind-up Yugiri", "Panda Cub", "Doman Magpie", "Dress-up Y'shtola", "Wind-up Krile", "Continental Eye", "Wind-up Rikku", "Wind-up Lulu", "Angel Of Mercy", "Wind-up Yuna", "Wind-up Bartz", "Wind-up Lyse", "Wind-up Gosetsu", "Motley Egg", "Wind-up Cirina", "Little Yin", "Little Yang", "Wind-up Tifa", "Wind-up Cloud", "Wind-up Aerith", "Wind-up Fran", "Brave New Y'shtola", "Wind-up Ardbert", "Wind-up Edge", "Wind-up Rydia", "Wind-up Rosa", "Wind-up Rudy", "Squirrel Emperor", "Wind-up Porom");

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsMinionUnlocked(5) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(46) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(64) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(63) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(79) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(98) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(99) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(91) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(107) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(108) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(109) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(105) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(129) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(131) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(132) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(145) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(159) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(150) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(103) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(121) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(177) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(192) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(225) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(221) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(222) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(227) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(220) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(238) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(248) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(250) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(280) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(293) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(307) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(308) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(311) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(309) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(310) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(325) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(331) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(382) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(401) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(402) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(403) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(420) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(421) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(400) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("PvP"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("squadminionsPvp", 6, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, "Fenrir Pup", "Wind-up Cheerleader", "Clockwork Lantern", "Minitek Conveyor", "Protonaught");

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsMinionUnlocked(183) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(191) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(291) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(324) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(446) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Quest"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("squadminionsQuest", 15, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, "Chigoe Larva", "Cactuar Cutting", "Goobbue Sproutling", "Coeurl Kitten", "Wolf Pup", "Mini Mole", "Wind-up Gentleman", "Accompaniment Node", "Gigi", "Anima", "Palico", "Wind-up Alpha", "The Great Serpent Of Ronka", "Golden Dhyata");

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsMinionUnlocked(15) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(33) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(41) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(19) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(35) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(45) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(21) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(149) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(230) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(231) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(300) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(304) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(337) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(437) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Raid"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("squadminionsRaid", 26, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, "Wind-up Onion Knight", "Puff Of Darkness", "Wind-up Echidna", "Faustlet", "Wind-up Calofisteri", "Toy Alexander", "Wind-up Scathach", "Wind-up Exdeath", "Wind-up Kefka", "Construct 8", "OMG", "Wind-up Ramza", "Eden Minor", "Pod 054", "Pod 316", "Wind-up Ryne", "2B Automaton", "2P Automaton", "Wind-up Gaia", "Smaller Stubby", "9S Automaton", "Nosferatu", "Wind-up Azeyma", "Wind-up Erichthonios", "Wind-up Halone");

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsMinionUnlocked(92) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(101) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(160) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(176) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(195) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(215) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(232) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(259) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(281) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(299) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(305) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(270) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(341) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(364) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(365) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(332) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(394) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(395) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(398) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(415) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(419) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(440) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(451) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(466) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(474) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Ishgardian Restoration"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("squadminionsSkybuilder", 25, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, "Plush Cushion", "Nutkin", "Atrophied Atomos", "Gaelikitten", "Owlet", "Ugly Duckling", "Clockwork Barrow", "Paissa Brat", "Hunting Hawk", "Morpho", "Calamari", "Dwarf Rabbit", "Shaggy Shoat", "Bullpup", "Baby Brachiosaur", "Pegasus Colt", "Miniature White Knight", "Dress-up Estinien", "Paissa Patissier", "Paissa Threadpuller", "Cerberpup", "Weatherproof Gaelicat", "Petit Pteranodon", "Trike");

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsMinionUnlocked(66) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(97) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(136) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(139) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(137) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(138) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(140) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(157) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(162) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(180) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(189) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(197) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(216) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(226) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(190) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(194) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(357) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(360) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(372) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(373) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(363) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(384) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(388) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(406) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Treasure Hunt"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("squadminionsTreasure", 28, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, "Wind-up Tonberry", "Tiny Bulb", "Bluebird", "Minute Mindflayer", "Baby Opo-opo", "Nutkin", "Tight-beaked Parrot", "Mummy's Little Mummy", "Gaelikitten", "Page 63", "Unicolt", "Lesser Panda", "Owlet", "Ugly Duckling", "Paissa Brat", "Dwarf Rabbit", "Wind-up Namazu", "Wind-up Matanga", "The Gold Whisker", "Capybara Pup", "Hedgehoglet", "Wind-up Fuath", "Sungold Talos", "Golden Beaver", "Royal Lunatender", "Wind-up Aidoneus", "Wind-up Philos");

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsMinionUnlocked(23) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(27) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(16) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(56) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(80) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(97) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(57) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(112) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(139) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(142) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(134) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(141) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(137) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(138) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(157) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(197) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(253) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(269) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(289) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(316) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(330) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(335) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(366) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(407) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(443) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(477) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(465) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Trial"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("squadminionsTrial", 5, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, "Wind-up Ultros", "Enkidu", "Poogie", "Giant Beaver");

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsMinionUnlocked(104) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(122) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(301) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(342) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Venture"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("squadminionsVenture", 26, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, "Minute Mindflayer", "Tiny Tapir", "Miniature Minecart", "Littlefoot", "Fat Cat", "Gestahl", "Bom Boko", "Odder Otter", "Mameshiba", "Koala Joey", "Axolotl Eft", "Tengu Doll", "Bacon Bits", "Mystic Weapon", "Domakin", "Wind-up Hobgoblin", "Allagan Melon", "Greener Gleaner", "Flag", "Crabe De La Crabe", "Wind-up Grebuloff", "Wind-up Kangaroo", "Chewy", "Blue-footed Booby", "Clockwork Novus D");

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsMinionUnlocked(56) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(94) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(96) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(111) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(110) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(146) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(246) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(241) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(267) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(271) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(273) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(268) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(353) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(355) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(359) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(362) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(386) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(438) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(422) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(432) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(439) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(445) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(448) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(453) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(449) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Voyages"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("squadminionsVoyage", 9, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, "Aurelia Polyp", "Abroader Otter", "Sharksucker-class Insubmersible", "Meerkat", "Silver Dasher", "Syldrion-class Insubmersible", "Benben Stone", "Suzusaurus");

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsMinionUnlocked(283) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(329) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(348) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(356) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(371) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(397) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(413) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(469) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Wondrous Tails/Faux Hollows"))
                    {
                        ImGui.Unindent();
                        ImGui.Unindent();

                        if (ImGui.BeginTable("squadminionsTails", 14, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                        {
                            SetUpSquadTableHeaders(0, "Dress-up Thancred", "Dress-up Alisaie", "Wind-up Estinien", "Wind-up Khloe", "Wind-up Hien", "Wind-up Zhloe", "Wind-up Omega-M", "Wind-up Omega-F", "Sand Fox", "Anteater", "Brave New Urianger", "Pterosquirrel", "Corgi");

                            foreach (var c in charas)
                            {
                                DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                SetCellBackground(c.IsMinionUnlocked(217) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(218) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(228) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(260) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(264) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(298) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(344) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(345) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(387) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(409) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(429) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(462) ? Green : Red);
                                SetCellBackground(c.IsMinionUnlocked(467) ? Green : Red);
                            }
                            ImGui.EndTable();
                        }
                        ImGui.EndTabItem();
                    }
                    if (ImGui.BeginTabItem("Shop"))
                    {
                        ImGui.Indent();
                        if (ImGui.BeginTabBar("squadMinionsShop"))
                        {
                            if (ImGui.BeginTabItem("Gil"))
                            {
                                ImGui.Unindent();
                                ImGui.Unindent();
                                ImGui.Unindent();

                                if (ImGui.BeginTable("squadminionsGil", 7, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                                {
                                    SetUpSquadTableHeaders(0, "Wayward Hatchling", "Cherry Bomb", "Tiny Rat", "Baby Raptor", "Baby Bat", "Mammet #001");

                                    foreach (var c in charas)
                                    {
                                        DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                        SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                        SetCellBackground(c.IsMinionUnlocked(3) ? Green : Red);
                                        SetCellBackground(c.IsMinionUnlocked(1) ? Green : Red);
                                        SetCellBackground(c.IsMinionUnlocked(13) ? Green : Red);
                                        SetCellBackground(c.IsMinionUnlocked(25) ? Green : Red);
                                        SetCellBackground(c.IsMinionUnlocked(26) ? Green : Red);
                                        SetCellBackground(c.IsMinionUnlocked(2) ? Green : Red);
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

                                if (ImGui.BeginTable("squadminionsSaucer", 9, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                                {
                                    SetUpSquadTableHeaders(0, "Zu Hatchling", "Heavy Hatchling", "Black Coeurl", "Water Imp", "Wind-up Nero Tol Scaeva", "Piggy", "Wind-up Daivadipa", "Mama Automaton");

                                    foreach (var c in charas)
                                    {
                                        DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                        SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                        SetCellBackground(c.IsMinionUnlocked(83) ? Green : Red);
                                        SetCellBackground(c.IsMinionUnlocked(106) ? Green : Red);
                                        SetCellBackground(c.IsMinionUnlocked(20) ? Green : Red);
                                        SetCellBackground(c.IsMinionUnlocked(117) ? Green : Red);
                                        SetCellBackground(c.IsMinionUnlocked(174) ? Green : Red);
                                        SetCellBackground(c.IsMinionUnlocked(187) ? Green : Red);
                                        SetCellBackground(c.IsMinionUnlocked(442) ? Green : Red);
                                        SetCellBackground(c.IsMinionUnlocked(470) ? Green : Red);
                                    }
                                    ImGui.EndTable();
                                }
                                ImGui.EndTabItem();
                            }
                            if (ImGui.BeginTabItem("Poetics"))
                            {
                                ImGui.Unindent();
                                ImGui.Unindent();
                                ImGui.Unindent();

                                if (ImGui.BeginTable("squadminionsPoetics", 4, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                                {
                                    SetUpSquadTableHeaders(0, "Wide-eyed Fawn", "Dust Bunny", "Fledgling Dodo");

                                    foreach (var c in charas)
                                    {
                                        DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                        SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                        SetCellBackground(c.IsMinionUnlocked(17) ? Green : Red);
                                        SetCellBackground(c.IsMinionUnlocked(28) ? Green : Red);
                                        SetCellBackground(c.IsMinionUnlocked(37) ? Green : Red);
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

                                if (ImGui.BeginTable("squadminionsHunts", 11, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                                {
                                    SetUpSquadTableHeaders(0, "Wind-up Succubus", "Treasure Box", "Behemoth Heir", "Griffin Hatchling", "Tora-jiro", "Wind-up Meateater", "Bitty Duckbill", "Cute Justice", "Nagxian Cat", "Wind-up Nu Mou");

                                    foreach (var c in charas)
                                    {
                                        DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                        SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                        SetCellBackground(c.IsMinionUnlocked(82) ? Green : Red);
                                        SetCellBackground(c.IsMinionUnlocked(93) ? Green : Red);
                                        SetCellBackground(c.IsMinionUnlocked(148) ? Green : Red);
                                        SetCellBackground(c.IsMinionUnlocked(144) ? Green : Red);
                                        SetCellBackground(c.IsMinionUnlocked(243) ? Green : Red);
                                        SetCellBackground(c.IsMinionUnlocked(256) ? Green : Red);
                                        SetCellBackground(c.IsMinionUnlocked(340) ? Green : Red);
                                        SetCellBackground(c.IsMinionUnlocked(358) ? Green : Red);
                                        SetCellBackground(c.IsMinionUnlocked(428) ? Green : Red);
                                        SetCellBackground(c.IsMinionUnlocked(326) ? Green : Red);
                                    }
                                    ImGui.EndTable();
                                }
                                ImGui.EndTabItem();
                            }
                            if (ImGui.BeginTabItem("Grand Company"))
                            {
                                ImGui.Unindent();
                                ImGui.Unindent();
                                ImGui.Unindent();

                                if (ImGui.BeginTable("squadminionsGc", 4, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                                {
                                    SetUpSquadTableHeaders(0, "Storm Hatchling", "Serpent Hatchling", "Flame Hatchling");

                                    foreach (var c in charas)
                                    {
                                        DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                        SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                        SetCellBackground(c.IsMinionUnlocked(9) ? Green : Red);
                                        SetCellBackground(c.IsMinionUnlocked(10) ? Green : Red);
                                        SetCellBackground(c.IsMinionUnlocked(11) ? Green : Red);
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

                                if (ImGui.BeginTable("squadminionsSanctuary", 3, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                                {
                                    SetUpSquadTableHeaders(0, "Felicitous Fuzzball", "Sky Blue Back");

                                    foreach (var c in charas)
                                    {
                                        DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                        SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                        SetCellBackground(c.IsMinionUnlocked(456) ? Green : Red);
                                        SetCellBackground(c.IsMinionUnlocked(468) ? Green : Red);
                                    }
                                    ImGui.EndTable();
                                }
                                ImGui.EndTabItem();
                            }
                            if (ImGui.BeginTabItem("Other"))
                            {
                                ImGui.Unindent();
                                ImGui.Unindent();
                                ImGui.Unindent();

                                if (ImGui.BeginTable("squadminionsOther", 3, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
                                {
                                    SetUpSquadTableHeaders(0, "Wind-up Sun", "Wind-up Moon");

                                    foreach (var c in charas)
                                    {
                                        DrawAccountAndWorldInfo(ref lastAccount, ref lastWorld, c);

                                        SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
                                        SetCellBackground(c.IsMinionUnlocked(65) ? Green : Red);
                                        SetCellBackground(c.IsMinionUnlocked(236) ? Green : Red);
                                    }
                                    ImGui.EndTable();
                                }
                                ImGui.EndTabItem();
                            }
                            ImGui.EndTabBar();
                        }
                        ImGui.EndTabItem();
                    }
                    ImGui.EndTabItem();
                }
                ImGui.EndTabBar();
            }

        }
    }
}