using FFXIVCharaTracker.DB;
using ImGuiNET;

namespace FFXIVCharaTracker
{
    internal partial class PluginUI
    {
        internal void DrawEmotesSection(Chara charaData)
        {
            if (ImGui.TreeNode("Emotes"))
            {
                if (ImGui.TreeNode("Achievements"))
                {
                    if (ImGui.BeginTable("EmotesAchievement", 2))
                    {
                        SetUpTableColumns();

                        DrawTableRowText("Squats", charaData.IsEmoteUnlocked(155));
                        DrawTableRowText("Push-ups", charaData.IsEmoteUnlocked(156));
                        DrawTableRowText("Sit-ups", charaData.IsEmoteUnlocked(157));
                        DrawTableRowText("Breath Control", charaData.IsEmoteUnlocked(158));

                        ImGui.EndTable();
                    }
                    ImGui.TreePop();
                }
                if (ImGui.TreeNode("Bozja"))
                {
                    if (ImGui.BeginTable("EmotesBozja", 2))
                    {
                        SetUpTableColumns();

                        DrawTableRowText("Guard", charaData.IsEmoteUnlocked(214));
                        DrawTableRowText("Malevolence", charaData.IsEmoteUnlocked(215));
                        DrawTableRowText("Wring Hands", charaData.IsEmoteUnlocked(222));

                        ImGui.EndTable();
                    }
                    ImGui.TreePop();
                }
                if (ImGui.TreeNode("Deep Dungeon"))
                {
                    if (ImGui.BeginTable("EmotesDeep", 2))
                    {
                        SetUpTableColumns();

                        DrawTableRowText("Sweat", charaData.IsEmoteUnlocked(180));

                        ImGui.EndTable();
                    }
                    ImGui.TreePop();
                }
                if (ImGui.TreeNode("Eureka"))
                {
                    if (ImGui.BeginTable("EmotesEureka", 2))
                    {
                        SetUpTableColumns();

                        DrawTableRowText("Shiver", charaData.IsEmoteUnlocked(181));
                        DrawTableRowText("Scheme", charaData.IsEmoteUnlocked(189));
                        DrawTableRowText("Fist Pump", charaData.IsEmoteUnlocked(195));

                        ImGui.EndTable();
                    }
                    ImGui.TreePop();
                }
                if (ImGui.TreeNode("Gold Saucer"))
                {
                    if (ImGui.BeginTable("EmotesSaucer", 2))
                    {
                        SetUpTableColumns();

                        DrawTableRowText("Thavnairian Dance", charaData.IsEmoteUnlocked(118));
                        DrawTableRowText("Gold Dance", charaData.IsEmoteUnlocked(119));
                        DrawTableRowText("Aback", charaData.IsEmoteUnlocked(171));
                        DrawTableRowText("Big Grin", charaData.IsEmoteUnlocked(81));
                        DrawTableRowText("Bee's Knees", charaData.IsEmoteUnlocked(216));
                        DrawTableRowText("Draw Weapon", charaData.IsEmoteUnlocked(238));
                        DrawTableRowText("Sheathe Weapon", charaData.IsEmoteUnlocked(237));

                        ImGui.EndTable();
                    }
                    ImGui.TreePop();
                }
                if (ImGui.TreeNode("Hunts"))
                {
                    if (ImGui.BeginTable("EmotesHunt", 2))
                    {
                        SetUpTableColumns();

                        DrawTableRowText("Tremble", charaData.IsEmoteUnlocked(169));
                        DrawTableRowText("Winded", charaData.IsEmoteUnlocked(170));
                        DrawTableRowText("Headache", charaData.IsEmoteUnlocked(204));

                        ImGui.EndTable();
                    }
                    ImGui.TreePop();
                }
                if (ImGui.TreeNode("Other"))
                {
                    if (ImGui.BeginTable("EmotesOther", 2))
                    {
                        SetUpTableColumns();

                        DrawTableRowText("Fist Bump", charaData.IsEmoteUnlocked(115));
                        DrawTableRowText("Tomestone", charaData.IsEmoteUnlocked(191));

                        ImGui.EndTable();
                    }
                    ImGui.TreePop();
                }
                if (ImGui.TreeNode("Mog Station"))
                {
                    if (ImGui.BeginTable("EmotesMog", 2))
                    {
                        SetUpTableColumns();

                        DrawTableRowText("Bomb Dance", charaData.IsEmoteUnlocked(109));
                        DrawTableRowText("Huzzah", charaData.IsEmoteUnlocked(110));
                        DrawTableRowText("Eureka", charaData.IsEmoteUnlocked(125));
                        DrawTableRowText("Red Ranger Pose A", charaData.IsEmoteUnlocked(130));
                        DrawTableRowText("Red Ranger Pose B", charaData.IsEmoteUnlocked(134));
                        DrawTableRowText("Black Ranger Pose A", charaData.IsEmoteUnlocked(131));
                        DrawTableRowText("Black Ranger Pose B", charaData.IsEmoteUnlocked(135));
                        DrawTableRowText("Yellow Ranger Pose A", charaData.IsEmoteUnlocked(132));
                        DrawTableRowText("Yellow Ranger Pose B", charaData.IsEmoteUnlocked(136));
                        DrawTableRowText("Eastern Greeting", charaData.IsEmoteUnlocked(124));
                        DrawTableRowText("Dote", charaData.IsEmoteUnlocked(146));
                        DrawTableRowText("Backflip", charaData.IsEmoteUnlocked(123));
                        DrawTableRowText("Songbird", charaData.IsEmoteUnlocked(149));
                        DrawTableRowText("Play Dead", charaData.IsEmoteUnlocked(143));
                        DrawTableRowText("Eastern Stretch", charaData.IsEmoteUnlocked(128));
                        DrawTableRowText("Eastern Dance", charaData.IsEmoteUnlocked(129));
                        DrawTableRowText("Pretty Please", charaData.IsEmoteUnlocked(142));
                        DrawTableRowText("Power Up", charaData.IsEmoteUnlocked(153));
                        DrawTableRowText("Cheer On", charaData.IsEmoteUnlocked(65));
                        DrawTableRowText("Cheer Wave", charaData.IsEmoteUnlocked(66));
                        DrawTableRowText("Cheer Jump", charaData.IsEmoteUnlocked(67));
                        DrawTableRowText("Megaflare", charaData.IsEmoteUnlocked(62));
                        DrawTableRowText("Splash", charaData.IsEmoteUnlocked(178));
                        DrawTableRowText("Crimson Lotus", charaData.IsEmoteUnlocked(63));
                        DrawTableRowText("Box Step", charaData.IsEmoteUnlocked(173));
                        DrawTableRowText("Side Step", charaData.IsEmoteUnlocked(174));
                        DrawTableRowText("Senor Sabotender", charaData.IsEmoteUnlocked(197));
                        DrawTableRowText("Get Fantasy", charaData.IsEmoteUnlocked(185));
                        DrawTableRowText("Popoto Step", charaData.IsEmoteUnlocked(186));
                        DrawTableRowText("Toast", charaData.IsEmoteUnlocked(202));
                        DrawTableRowText("Snap", charaData.IsEmoteUnlocked(205));
                        DrawTableRowText("Heel Toe", charaData.IsEmoteUnlocked(192));
                        DrawTableRowText("Goobbue Do", charaData.IsEmoteUnlocked(193));
                        DrawTableRowText("Consider", charaData.IsEmoteUnlocked(209));
                        DrawTableRowText("Flame Dance", charaData.IsEmoteUnlocked(212));
                        DrawTableRowText("Wasshoi", charaData.IsEmoteUnlocked(210));
                        DrawTableRowText("Flower Shower", charaData.IsEmoteUnlocked(211));
                        DrawTableRowText("Vexed", charaData.IsEmoteUnlocked(230));
                        DrawTableRowText("Pantomime", charaData.IsEmoteUnlocked(229));
                        DrawTableRowText("Eat Egg", charaData.IsEmoteUnlocked(235));
                        DrawTableRowText("Drink Tea", charaData.IsEmoteUnlocked(239));
                        DrawTableRowText("Deride", charaData.IsEmoteUnlocked(245));

                        ImGui.EndTable();
                    }
                    ImGui.TreePop();
                }
                if (ImGui.TreeNode("Shop"))
                {
                    if (ImGui.BeginTable("EmotesShop", 2))
                    {
                        SetUpTableColumns();

                        DrawTableRowText("Attention", charaData.IsEmoteUnlocked(164));
                        DrawTableRowText("At Ease", charaData.IsEmoteUnlocked(165));
                        DrawTableRowText("Reflect", charaData.IsEmoteUnlocked(82));

                        ImGui.EndTable();
                    }
                    ImGui.TreePop();
                }
                if (ImGui.TreeNode("PvP"))
                {
                    if (ImGui.BeginTable("EmotesPvP", 2))
                    {
                        SetUpTableColumns();

                        DrawTableRowText("Elucidate", charaData.IsEmoteUnlocked(182));
                        DrawTableRowText("Reprimand", charaData.IsEmoteUnlocked(196));

                        ImGui.EndTable();
                    }
                    ImGui.TreePop();
                }
                if (ImGui.TreeNode("Quests"))
                {
                    if (ImGui.BeginTable("EmotesSidequest", 2))
                    {
                        SetUpTableColumns();

                        DrawTableRowText("Imperial Salute", charaData.IsEmoteUnlocked(59));
                        DrawTableRowText("Throw", charaData.IsEmoteUnlocked(85));
                        DrawTableRowText("Step Dance", charaData.IsEmoteUnlocked(101));
                        DrawTableRowText("Harvest Dance", charaData.IsEmoteUnlocked(102));
                        DrawTableRowText("Ball Dance", charaData.IsEmoteUnlocked(103));
                        DrawTableRowText("Manderville Dance", charaData.IsEmoteUnlocked(104));
                        DrawTableRowText("Embrace", charaData.IsEmoteUnlocked(113));
                        DrawTableRowText("Most Gentlemanly", charaData.IsEmoteUnlocked(114));
                        DrawTableRowText("Sundrop Dance", charaData.IsEmoteUnlocked(120));
                        DrawTableRowText("Battle Stance", charaData.IsEmoteUnlocked(121));
                        DrawTableRowText("Victory", charaData.IsEmoteUnlocked(122));
                        DrawTableRowText("Haurchefant", charaData.IsEmoteUnlocked(127));
                        DrawTableRowText("Moogle Dance", charaData.IsEmoteUnlocked(126));
                        DrawTableRowText("Spectacles", charaData.IsEmoteUnlocked(148));
                        DrawTableRowText("Moonlift Dance", charaData.IsEmoteUnlocked(145));
                        DrawTableRowText("Eastern Bow", charaData.IsEmoteUnlocked(154));
                        DrawTableRowText("Water Flip", charaData.IsEmoteUnlocked(151));
                        DrawTableRowText("Box", charaData.IsEmoteUnlocked(166));
                        DrawTableRowText("Greeting", charaData.IsEmoteUnlocked(172));
                        DrawTableRowText("Ponder", charaData.IsEmoteUnlocked(183));
                        DrawTableRowText("Hum", charaData.IsEmoteUnlocked(187));
                        DrawTableRowText("Endure", charaData.IsEmoteUnlocked(190));
                        DrawTableRowText("Gratuity", charaData.IsEmoteUnlocked(194));
                        DrawTableRowText("Manderville Mambo", charaData.IsEmoteUnlocked(198));
                        DrawTableRowText("Lali-ho", charaData.IsEmoteUnlocked(199));
                        DrawTableRowText("Shush", charaData.IsEmoteUnlocked(231));

                        ImGui.EndTable();
                    }
                    ImGui.TreePop();
                }
                if (ImGui.TreeNode("Ishgardian Restoration"))
                {
                    if (ImGui.BeginTable("EmotesResto", 2))
                    {
                        SetUpTableColumns();

                        DrawTableRowText("Lean", charaData.IsEmoteUnlocked(203));
                        DrawTableRowText("Insist", charaData.IsEmoteUnlocked(208));
                        DrawTableRowText("Break Fast", charaData.IsEmoteUnlocked(206));
                        DrawTableRowText("Read", charaData.IsEmoteUnlocked(207));
                        DrawTableRowText("High Five", charaData.IsEmoteUnlocked(213));
                        DrawTableRowText("Eat Rice Ball", charaData.IsEmoteUnlocked(220));
                        DrawTableRowText("Eat Apple", charaData.IsEmoteUnlocked(221));
                        DrawTableRowText("Sweep Up", charaData.IsEmoteUnlocked(223));

                        ImGui.EndTable();
                    }
                    ImGui.TreePop();
                }
                if (ImGui.TreeNode("Treasure Maps"))
                {
                    if (ImGui.BeginTable("EmotesTreasure", 2))
                    {
                        SetUpTableColumns();

                        DrawTableRowText("Confirm", charaData.IsEmoteUnlocked(188));
                        DrawTableRowText("Paint It Black", charaData.IsEmoteUnlocked(224));
                        DrawTableRowText("Paint It Red", charaData.IsEmoteUnlocked(225));
                        DrawTableRowText("Paint It Yellow", charaData.IsEmoteUnlocked(226));
                        DrawTableRowText("Paint It Blue", charaData.IsEmoteUnlocked(227));

                        ImGui.EndTable();
                    }
                    ImGui.TreePop();
                }
                if (ImGui.TreeNode("Beast Tribes"))
                {
                    if (ImGui.BeginTable("EmotesTribe", 2))
                    {
                        SetUpTableColumns();

                        DrawTableRowText("Ritual Prayer", charaData.IsEmoteUnlocked(167));
                        DrawTableRowText("Charmed", charaData.IsEmoteUnlocked(64));
                        DrawTableRowText("Yol Dance", charaData.IsEmoteUnlocked(176));
                        DrawTableRowText("Lali Hop", charaData.IsEmoteUnlocked(217));
                        DrawTableRowText("Ear Wiggle", charaData.IsEmoteUnlocked(252));

                        ImGui.EndTable();
                    }
                    ImGui.TreePop();
                }
                if (ImGui.TreeNode("Variant/Criterion"))
                {
                    if (ImGui.BeginTable("EmotesVandC", 2))
                    {
                        SetUpTableColumns();

                        DrawTableRowText("Wow", charaData.IsEmoteUnlocked(246));

                        ImGui.EndTable();
                    }
                    ImGui.TreePop();
                }
                ImGui.TreePop();
            }
        }
    }
}
