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
        internal void DrawMountsSection(Chara charaData)
        {
            if (ImGui.TreeNode("Mounts"))
            {
                if (ImGui.TreeNode("Achievements"))
                {
                    if (ImGui.BeginTable("mountsAchievement", 2))
                    {
                        SetUpTableColumns();

                        DrawTableRowText("Ahriman", charaData.IsMountUnlocked(9));
                        DrawTableRowText("Behemoth", charaData.IsMountUnlocked(18));
                        DrawTableRowText("Gilded Magitek Armor", charaData.IsMountUnlocked(21));
                        DrawTableRowText("Warlion", charaData.IsMountUnlocked(32));
                        DrawTableRowText("Warbear", charaData.IsMountUnlocked(33));
                        DrawTableRowText("Storm Warsteed", charaData.IsMountUnlocked(36));
                        DrawTableRowText("Serpent Warsteed", charaData.IsMountUnlocked(37));
                        DrawTableRowText("Flame Warsteed", charaData.IsMountUnlocked(38));
                        DrawTableRowText("Parade Chocobo", charaData.IsMountUnlocked(44));
                        DrawTableRowText("Logistics System", charaData.IsMountUnlocked(48));
                        DrawTableRowText("War Panther", charaData.IsMountUnlocked(56));
                        DrawTableRowText("Gloria-class Airship", charaData.IsMountUnlocked(80));
                        DrawTableRowText("Astrope", charaData.IsMountUnlocked(83));
                        DrawTableRowText("Aerodynamics System", charaData.IsMountUnlocked(91));
                        DrawTableRowText("Goten", charaData.IsMountUnlocked(95));
                        DrawTableRowText("Ginga", charaData.IsMountUnlocked(96));
                        DrawTableRowText("Raigo", charaData.IsMountUnlocked(102));
                        DrawTableRowText("Battle Lion", charaData.IsMountUnlocked(122));
                        DrawTableRowText("Battle Bear", charaData.IsMountUnlocked(123));
                        DrawTableRowText("Battle Panther", charaData.IsMountUnlocked(124));
                        DrawTableRowText("Centurio Tiger", charaData.IsMountUnlocked(127));
                        DrawTableRowText("Magitek Avenger", charaData.IsMountUnlocked(141));
                        DrawTableRowText("Magitek Death Claw", charaData.IsMountUnlocked(145));
                        DrawTableRowText("Safeguard System", charaData.IsMountUnlocked(168));
                        DrawTableRowText("Juedi", charaData.IsMountUnlocked(166));
                        DrawTableRowText("Magitek Avenger A1", charaData.IsMountUnlocked(141));
                        DrawTableRowText("Demi-Ozma", charaData.IsMountUnlocked(186));
                        DrawTableRowText("War Tiger", charaData.IsMountUnlocked(183));
                        DrawTableRowText("Triceratops", charaData.IsMountUnlocked(190));
                        DrawTableRowText("Amaro", charaData.IsMountUnlocked(187));
                        DrawTableRowText("Battle Tiger", charaData.IsMountUnlocked(197));
                        DrawTableRowText("Morbol", charaData.IsMountUnlocked(200));
                        DrawTableRowText("Construct VII", charaData.IsMountUnlocked(204));
                        DrawTableRowText("Hybodus", charaData.IsMountUnlocked(218));
                        DrawTableRowText("Pteranodon", charaData.IsMountUnlocked(216));
                        DrawTableRowText("Cerberus", charaData.IsMountUnlocked(235));
                        DrawTableRowText("Al-iklil", charaData.IsMountUnlocked(246));
                        DrawTableRowText("Victor", charaData.IsMountUnlocked(267));
                        DrawTableRowText("Silkie", charaData.IsMountUnlocked(304));

                        ImGui.EndTable();
                    }
                    ImGui.TreePop();

                }
                if (ImGui.TreeNode("Tribes"))
                {
                    if (ImGui.BeginTable("mountsTribe", 2))
                    {
                        SetUpTableColumns();

                        DrawTableRowText("Cavalry Drake", charaData.IsMountUnlocked(19));
                        DrawTableRowText("Laurel Goobbue", charaData.IsMountUnlocked(20));
                        DrawTableRowText("Cavalry Elbst", charaData.IsMountUnlocked(26));
                        DrawTableRowText("Bomb Palanquin", charaData.IsMountUnlocked(27));
                        DrawTableRowText("Direwolf", charaData.IsMountUnlocked(35));
                        DrawTableRowText("Sanuwa", charaData.IsMountUnlocked(53));
                        DrawTableRowText("Kongamato", charaData.IsMountUnlocked(72));
                        DrawTableRowText("Cloud Mallow", charaData.IsMountUnlocked(86));
                        DrawTableRowText("Striped Ray", charaData.IsMountUnlocked(136));
                        DrawTableRowText("Marid", charaData.IsMountUnlocked(146));
                        DrawTableRowText("True Griffin", charaData.IsMountUnlocked(148));
                        DrawTableRowText("Mikoshi", charaData.IsMountUnlocked(164));
                        DrawTableRowText("Portly Porxie", charaData.IsMountUnlocked(201));
                        DrawTableRowText("Great Vessel Of Ronka", charaData.IsMountUnlocked(215));
                        DrawTableRowText("Rolling Tankard", charaData.IsMountUnlocked(223));
                        DrawTableRowText("Hippo Cart", charaData.IsMountUnlocked(287));
                        DrawTableRowText("Miw Miisv", charaData.IsMountUnlocked(298));

                        ImGui.EndTable();
                    }
                    ImGui.TreePop();
                }
                if (ImGui.TreeNode("Bozja"))
                {
                    if (ImGui.BeginTable("mountsBozja", 2))
                    {
                        SetUpTableColumns();

                        DrawTableRowText("Construct 14", charaData.IsMountUnlocked(213));
                        DrawTableRowText("Gabriel Α", charaData.IsMountUnlocked(224));
                        DrawTableRowText("Gabriel Mark III", charaData.IsMountUnlocked(241));
                        DrawTableRowText("Deinonychus", charaData.IsMountUnlocked(212));

                        ImGui.EndTable();
                    }
                    ImGui.TreePop();
                }
                if (ImGui.TreeNode("Crafted"))
                {
                    if (ImGui.BeginTable("mountsCrafted", 2))
                    {
                        SetUpTableColumns();

                        DrawTableRowText("Flying Chair", charaData.IsMountUnlocked(140));
                        DrawTableRowText("Magicked Bed", charaData.IsMountUnlocked(193));

                        ImGui.EndTable();
                    }
                    ImGui.TreePop();
                }
                if (ImGui.TreeNode("Deep Dungeon"))
                {
                    if (ImGui.BeginTable("mountsDeep", 2))
                    {
                        SetUpTableColumns();

                        DrawTableRowText("Disembodied Head", charaData.IsMountUnlocked(92));
                        DrawTableRowText("Black Pegasus", charaData.IsMountUnlocked(100));
                        DrawTableRowText("Dodo", charaData.IsMountUnlocked(159));
                        DrawTableRowText("Sil'dihn Throne", charaData.IsMountUnlocked(303));

                        ImGui.EndTable();
                    }
                    ImGui.TreePop();
                }
                if (ImGui.TreeNode("Dungeon"))
                {
                    if (ImGui.BeginTable("mountsDungeon", 2))
                    {
                        SetUpTableColumns();

                        DrawTableRowText("Magitek Predator", charaData.IsMountUnlocked(121));

                        ImGui.EndTable();
                    }
                    ImGui.TreePop();
                }
                if (ImGui.TreeNode("Eureka"))
                {
                    if (ImGui.BeginTable("mountsEureka", 2))
                    {
                        SetUpTableColumns();

                        DrawTableRowText("Tyrannosaur", charaData.IsMountUnlocked(150));
                        DrawTableRowText("Eldthurs", charaData.IsMountUnlocked(178));
                        DrawTableRowText("Eurekan Petrel", charaData.IsMountUnlocked(184));

                        ImGui.EndTable();
                    }
                    ImGui.TreePop();
                }
                if (ImGui.TreeNode("FATE"))
                {
                    if (ImGui.BeginTable("mountsFate", 2))
                    {
                        SetUpTableColumns();

                        DrawTableRowText("Ixion", charaData.IsMountUnlocked(130));
                        DrawTableRowText("Ironfrog Mover", charaData.IsMountUnlocked(191));
                        DrawTableRowText("Level Checker", charaData.IsMountUnlocked(268));
                        DrawTableRowText("Wivre", charaData.IsMountUnlocked(273));

                        ImGui.EndTable();
                    }
                    ImGui.TreePop();
                }
                if (ImGui.TreeNode("Mog Station/Collector's Edition"))
                {
                    if (ImGui.BeginTable("mountsMog", 2))
                    {
                        SetUpTableColumns();

                        DrawTableRowText("Coeurl", charaData.IsMountUnlocked(8));
                        DrawTableRowText("Fat Chocobo", charaData.IsMountUnlocked(25));
                        DrawTableRowText("Draught Chocobo", charaData.IsMountUnlocked(34));
                        DrawTableRowText("Sleipnir", charaData.IsMountUnlocked(42));
                        DrawTableRowText("Ceremony Chocobo", charaData.IsMountUnlocked(41));
                        DrawTableRowText("Griffin", charaData.IsMountUnlocked(54));
                        DrawTableRowText("Amber Draught Chocobo", charaData.IsMountUnlocked(52));
                        DrawTableRowText("Twintania", charaData.IsMountUnlocked(59));
                        DrawTableRowText("Witch's Broom", charaData.IsMountUnlocked(62));
                        DrawTableRowText("White Devil", charaData.IsMountUnlocked(68));
                        DrawTableRowText("Red Baron", charaData.IsMountUnlocked(69));
                        DrawTableRowText("Original Fat Chocobo", charaData.IsMountUnlocked(82));
                        DrawTableRowText("Bennu", charaData.IsMountUnlocked(74));
                        DrawTableRowText("Fat Moogle", charaData.IsMountUnlocked(84));
                        DrawTableRowText("Eggshilaration System", charaData.IsMountUnlocked(106));
                        DrawTableRowText("Syldra", charaData.IsMountUnlocked(111));
                        DrawTableRowText("Managarm", charaData.IsMountUnlocked(93));
                        DrawTableRowText("Mystic Panda", charaData.IsMountUnlocked(97));
                        DrawTableRowText("Starlight Bear", charaData.IsMountUnlocked(99));
                        DrawTableRowText("Aquamarine Carbuncle", charaData.IsMountUnlocked(138));
                        DrawTableRowText("Citrine Carbuncle", charaData.IsMountUnlocked(139));
                        DrawTableRowText("Nezha Chariot", charaData.IsMountUnlocked(135));
                        DrawTableRowText("Broken Heart", charaData.IsMountUnlocked(152));
                        DrawTableRowText("Broken Heart", charaData.IsMountUnlocked(153));
                        DrawTableRowText("Red Hare", charaData.IsMountUnlocked(143));
                        DrawTableRowText("Indigo Whale", charaData.IsMountUnlocked(160));
                        DrawTableRowText("SDS Fenrir", charaData.IsMountUnlocked(71));
                        DrawTableRowText("Fatter Cat", charaData.IsMountUnlocked(171));
                        DrawTableRowText("Fat Black Chocobo", charaData.IsMountUnlocked(177));
                        DrawTableRowText("Magicked Carpet", charaData.IsMountUnlocked(175));
                        DrawTableRowText("Grani", charaData.IsMountUnlocked(170));
                        DrawTableRowText("Circus Ahriman", charaData.IsMountUnlocked(194));
                        DrawTableRowText("Sunspun Cumulus", charaData.IsMountUnlocked(195));
                        DrawTableRowText("Spriggan Stonecarrier", charaData.IsMountUnlocked(206));
                        DrawTableRowText("Kingly Peacock", charaData.IsMountUnlocked(214));
                        DrawTableRowText("Rubellite Carbuncle", charaData.IsMountUnlocked(220));
                        DrawTableRowText("Chocobo Carriage", charaData.IsMountUnlocked(222));
                        DrawTableRowText("Snowman", charaData.IsMountUnlocked(232));
                        DrawTableRowText("Lunar Whale", charaData.IsMountUnlocked(233));
                        DrawTableRowText("Polar Bear", charaData.IsMountUnlocked(250));
                        DrawTableRowText("Cruise Chaser", charaData.IsMountUnlocked(247));
                        DrawTableRowText("Arion", charaData.IsMountUnlocked(237));
                        DrawTableRowText("Papa Paissa", charaData.IsMountUnlocked(269));
                        DrawTableRowText("Megashiba", charaData.IsMountUnlocked(294));
                        DrawTableRowText("Mechanical Lotus", charaData.IsMountUnlocked(279));
                        DrawTableRowText("Magicked Umbrella", charaData.IsMountUnlocked(300));
                        DrawTableRowText("Magicked Parasol", charaData.IsMountUnlocked(301));
                        DrawTableRowText("Set Of Ceruleum Balloons", charaData.IsMountUnlocked(310));

                        ImGui.EndTable();
                    }
                    ImGui.TreePop();
                }
                if (ImGui.TreeNode("PvP"))
                {
                    if (ImGui.BeginTable("mountsPvp", 2))
                    {
                        SetUpTableColumns();

                        DrawTableRowText("Magitek Sky Armor", charaData.IsMountUnlocked(174));

                        ImGui.EndTable();
                    }
                    ImGui.TreePop();
                }
                if (ImGui.TreeNode("Quest"))
                {
                    if (ImGui.BeginTable("mountsQuest", 2))
                    {
                        SetUpTableColumns();

                        DrawTableRowText("Unicorn", charaData.IsMountUnlocked(15));
                        DrawTableRowText("Kirin", charaData.IsMountUnlocked(47));
                        DrawTableRowText("Firebird", charaData.IsMountUnlocked(105));
                        DrawTableRowText("Kamuy Of The Nine Tails", charaData.IsMountUnlocked(181));
                        DrawTableRowText("Ehll Tou", charaData.IsMountUnlocked(230));
                        DrawTableRowText("Landerwaffe", charaData.IsMountUnlocked(245));
                        DrawTableRowText("Magicked Card", charaData.IsMountUnlocked(254));
                        DrawTableRowText("Argos", charaData.IsMountUnlocked(263));
                        DrawTableRowText("Anden III", charaData.IsMountUnlocked(311));

                        ImGui.EndTable();
                    }
                    ImGui.TreePop();
                }
                if (ImGui.TreeNode("Raid"))
                {
                    if (ImGui.BeginTable("mountsRaid", 2))
                    {
                        SetUpTableColumns();

                        DrawTableRowText("Gobwalker", charaData.IsMountUnlocked(58));
                        DrawTableRowText("Arrhidaeus", charaData.IsMountUnlocked(101));
                        DrawTableRowText("Alte Roite", charaData.IsMountUnlocked(126));
                        DrawTableRowText("Air Force", charaData.IsMountUnlocked(156));
                        DrawTableRowText("Model O", charaData.IsMountUnlocked(173));
                        DrawTableRowText("Skyslipper", charaData.IsMountUnlocked(188));
                        DrawTableRowText("Ramuh", charaData.IsMountUnlocked(219));
                        DrawTableRowText("Eden", charaData.IsMountUnlocked(234));
                        DrawTableRowText("Demi-Phoinix", charaData.IsMountUnlocked(265));
                        DrawTableRowText("Sunforged", charaData.IsMountUnlocked(305));

                        ImGui.EndTable();
                    }
                    ImGui.TreePop();
                }
                if (ImGui.TreeNode("Ishgardian Restoration"))
                {
                    if (ImGui.BeginTable("mountsSkybuilder", 2))
                    {
                        SetUpTableColumns();

                        DrawTableRowText("Pegasus", charaData.IsMountUnlocked(67));
                        DrawTableRowText("Ufiti", charaData.IsMountUnlocked(211));
                        DrawTableRowText("Dhalmel", charaData.IsMountUnlocked(208));
                        DrawTableRowText("Albino Karakul", charaData.IsMountUnlocked(209));
                        DrawTableRowText("Megalotragus", charaData.IsMountUnlocked(225));
                        DrawTableRowText("Big Shell", charaData.IsMountUnlocked(236));
                        DrawTableRowText("Antelope Doe", charaData.IsMountUnlocked(242));
                        DrawTableRowText("Antelope Stag", charaData.IsMountUnlocked(243));

                        ImGui.EndTable();
                    }
                    ImGui.TreePop();
                }
                if (ImGui.TreeNode("Treasure Hunt"))
                {
                    if (ImGui.BeginTable("mountsTreasure", 2))
                    {
                        SetUpTableColumns();

                        DrawTableRowText("Alkonost", charaData.IsMountUnlocked(281));
                        DrawTableRowText("Phaethon", charaData.IsMountUnlocked(313));
                        DrawTableRowText("Pinky", charaData.IsMountUnlocked(314));

                        ImGui.EndTable();
                    }
                    ImGui.TreePop();
                }
                if (ImGui.TreeNode("Trial"))
                {
                    if (ImGui.BeginTable("mountsTrial", 2))
                    {
                        SetUpTableColumns();

                        DrawTableRowText("Nightmare", charaData.IsMountUnlocked(22));
                        DrawTableRowText("Aithon", charaData.IsMountUnlocked(28));
                        DrawTableRowText("Xanthos", charaData.IsMountUnlocked(29));
                        DrawTableRowText("Gullfaxi", charaData.IsMountUnlocked(30));
                        DrawTableRowText("Enbarr", charaData.IsMountUnlocked(31));
                        DrawTableRowText("Markab", charaData.IsMountUnlocked(40));
                        DrawTableRowText("Boreas", charaData.IsMountUnlocked(43));
                        DrawTableRowText("White Lanner", charaData.IsMountUnlocked(75));
                        DrawTableRowText("Rose Lanner", charaData.IsMountUnlocked(76));
                        DrawTableRowText("Round Lanner", charaData.IsMountUnlocked(77));
                        DrawTableRowText("Warring Lanner", charaData.IsMountUnlocked(78));
                        DrawTableRowText("Dark Lanner", charaData.IsMountUnlocked(90));
                        DrawTableRowText("Sophic Lanner", charaData.IsMountUnlocked(98));
                        DrawTableRowText("Demonic Lanner", charaData.IsMountUnlocked(104));
                        DrawTableRowText("Blissful Kamuy", charaData.IsMountUnlocked(115));
                        DrawTableRowText("Reveling Kamuy", charaData.IsMountUnlocked(116));
                        DrawTableRowText("Legendary Kamuy", charaData.IsMountUnlocked(133));
                        DrawTableRowText("Auspicious Kamuy", charaData.IsMountUnlocked(144));
                        DrawTableRowText("Lunar Kamuy", charaData.IsMountUnlocked(158));
                        DrawTableRowText("Rathalos", charaData.IsMountUnlocked(161));
                        DrawTableRowText("Euphonious Kamuy", charaData.IsMountUnlocked(172));
                        DrawTableRowText("Hallowed Kamuy", charaData.IsMountUnlocked(182));
                        DrawTableRowText("Fae Gwiber", charaData.IsMountUnlocked(189));
                        DrawTableRowText("Innocent Gwiber", charaData.IsMountUnlocked(192));
                        DrawTableRowText("Shadow Gwiber", charaData.IsMountUnlocked(205));
                        DrawTableRowText("Ruby Gwiber", charaData.IsMountUnlocked(217));
                        DrawTableRowText("Gwiber Of Light", charaData.IsMountUnlocked(226));
                        DrawTableRowText("Emerald Gwiber", charaData.IsMountUnlocked(238));
                        DrawTableRowText("Diamond Gwiber", charaData.IsMountUnlocked(249));
                        DrawTableRowText("Lynx Of Eternal Darkness", charaData.IsMountUnlocked(261));
                        DrawTableRowText("Lynx Of Divine Light", charaData.IsMountUnlocked(262));
                        DrawTableRowText("Bluefeather Lynx", charaData.IsMountUnlocked(293));
                        DrawTableRowText("Lynx Of Imperious Wind", charaData.IsMountUnlocked(306));
                        DrawTableRowText("Lynx Of Righteous Fire", charaData.IsMountUnlocked(315));

                        ImGui.EndTable();
                    }
                    ImGui.TreePop();
                }
                if (ImGui.TreeNode("Voyages"))
                {
                    if (ImGui.BeginTable("mountsVoyage", 2))
                    {
                        SetUpTableColumns();

                        DrawTableRowText("Zu", charaData.IsMountUnlocked(73));

                        ImGui.EndTable();
                    }
                    ImGui.TreePop();
                }
                if (ImGui.TreeNode("Wondrous Tails/Faux Hollows"))
                {
                    if (ImGui.BeginTable("mountsTails", 2))
                    {
                        SetUpTableColumns();

                        DrawTableRowText("Ixion", charaData.IsMountUnlocked(130));
                        DrawTableRowText("Incitatus", charaData.IsMountUnlocked(231));
                        DrawTableRowText("Construct VI-S", charaData.IsMountUnlocked(248));
                        DrawTableRowText("Calydontis", charaData.IsMountUnlocked(266));
                        DrawTableRowText("Troll", charaData.IsMountUnlocked(288));
                        DrawTableRowText("Wondrous Lanner", charaData.IsMountUnlocked(299));

                        ImGui.EndTable();
                    }
                    ImGui.TreePop();
                }
                if (ImGui.TreeNode("Shop"))
                {
                    if (ImGui.TreeNode("Gil"))
                    {
                        if (ImGui.BeginTable("mountsGil", 2))
                        {
                            SetUpTableColumns();

                            DrawTableRowText("Gilded Mikoshi", charaData.IsMountUnlocked(252));
                            DrawTableRowText("Resplendent Vessel Of Ronka", charaData.IsMountUnlocked(253));
                            DrawTableRowText("Magitek Avenger G1", charaData.IsMountUnlocked(141));
                            DrawTableRowText("Chrysomallos", charaData.IsMountUnlocked(317));

                            ImGui.EndTable();
                        }
                        ImGui.TreePop();
                    }
                    if (ImGui.TreeNode("MGP"))
                    {
                        if (ImGui.BeginTable("mountsSaucer", 2))
                        {
                            SetUpTableColumns();

                            DrawTableRowText("Adamantoise", charaData.IsMountUnlocked(46));
                            DrawTableRowText("Fenrir", charaData.IsMountUnlocked(49));
                            DrawTableRowText("Archon Throne", charaData.IsMountUnlocked(110));
                            DrawTableRowText("Korpokkur Kolossus", charaData.IsMountUnlocked(142));
                            DrawTableRowText("Typhon", charaData.IsMountUnlocked(154));
                            DrawTableRowText("Sabotender Emperador", charaData.IsMountUnlocked(180));
                            DrawTableRowText("Pod 602", charaData.IsMountUnlocked(284));
                            DrawTableRowText("Blackjack", charaData.IsMountUnlocked(312));

                            ImGui.EndTable();
                        }
                        ImGui.TreePop();
                    }
                    if (ImGui.TreeNode("Hunt Currency"))
                    {
                        if (ImGui.BeginTable("mountsHunts", 2))
                        {
                            SetUpTableColumns();

                            DrawTableRowText("Wyvern", charaData.IsMountUnlocked(70));
                            DrawTableRowText("Forgiven Reticence", charaData.IsMountUnlocked(207));
                            DrawTableRowText("Vinegaroon", charaData.IsMountUnlocked(291));

                            ImGui.EndTable();
                        }
                        ImGui.TreePop();
                    }
                    if (ImGui.TreeNode("Island Sanctuary"))
                    {
                        if (ImGui.BeginTable("mountsSanctuary", 2))
                        {
                            SetUpTableColumns();

                            DrawTableRowText("Garlond GL-II", charaData.IsMountUnlocked(277));
                            DrawTableRowText("Island Mandragora", charaData.IsMountUnlocked(255));
                            DrawTableRowText("Island Onion Prince", charaData.IsMountUnlocked(256));
                            DrawTableRowText("Island Eggplant Knight", charaData.IsMountUnlocked(257));
                            DrawTableRowText("Island Alligator", charaData.IsMountUnlocked(286));

                            ImGui.EndTable();
                        }
                        ImGui.TreePop();
                    }
                    ImGui.TreePop();
                }
                ImGui.TreePop();
            }
        }
    }

}
