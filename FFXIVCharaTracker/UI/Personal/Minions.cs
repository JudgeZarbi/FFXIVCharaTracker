using FFXIVCharaTracker.DB;
using ImGuiNET;

namespace FFXIVCharaTracker
{
    internal partial class PluginUI
    {
        internal void DrawMinionsSection(Chara charaData)
        {
            if (ImGui.TreeNode("Minions"))
            {
                if (ImGui.TreeNode("Achievements"))
                {
                    if (ImGui.BeginTable("minionsAchievement", 2))
                    {
                        SetUpTableColumns();

                        DrawTableRowText("Black Chocobo Chick", charaData.IsMinionUnlocked(54));
                        DrawTableRowText("Beady Eye", charaData.IsMinionUnlocked(36));
                        DrawTableRowText("Wind-up Cursor", charaData.IsMinionUnlocked(51));
                        DrawTableRowText("Wind-up Leader", charaData.IsMinionUnlocked(71));
                        DrawTableRowText("Minion of Light", charaData.IsMinionUnlocked(67));
                        DrawTableRowText("Wind-up Odin", charaData.IsMinionUnlocked(76));
                        DrawTableRowText("Wind-up Warrior of Light ", charaData.IsMinionUnlocked(77));
                        DrawTableRowText("Wind-up Goblin", charaData.IsMinionUnlocked(49));
                        DrawTableRowText("Wind-up Gilgamesh", charaData.IsMinionUnlocked(85));
                        DrawTableRowText("Wind-up Nanamo", charaData.IsMinionUnlocked(84));
                        DrawTableRowText("Wind-up Firion", charaData.IsMinionUnlocked(167));
                        DrawTableRowText("Komainu", charaData.IsMinionUnlocked(288));
                        DrawTableRowText("Mammet #003L", charaData.IsMinionUnlocked(6));
                        DrawTableRowText("Mammet #003G", charaData.IsMinionUnlocked(7));
                        DrawTableRowText("Mammet #003U", charaData.IsMinionUnlocked(8));
                        DrawTableRowText("Princely Hatchling", charaData.IsMinionUnlocked(75));
                        DrawTableRowText("Fledgling Apkallu", charaData.IsMinionUnlocked(40));
                        DrawTableRowText("Wind-up Louisoix", charaData.IsMinionUnlocked(118));
                        DrawTableRowText("Shalloweye", charaData.IsMinionUnlocked(163));
                        DrawTableRowText("Clockwork Twintania", charaData.IsMinionUnlocked(165));
                        DrawTableRowText("Penguin Prince", charaData.IsMinionUnlocked(164));
                        DrawTableRowText("Hellpup", charaData.IsMinionUnlocked(234));
                        DrawTableRowText("Faepup", charaData.IsMinionUnlocked(240));
                        DrawTableRowText("The Major-General", charaData.IsMinionUnlocked(375));
                        DrawTableRowText("Malone", charaData.IsMinionUnlocked(367));
                        DrawTableRowText("Laladile", charaData.IsMinionUnlocked(378));
                        DrawTableRowText("Much-coveted Mora", charaData.IsMinionUnlocked(396));
                        DrawTableRowText("Dolphin Calf", charaData.IsMinionUnlocked(410));
                        DrawTableRowText("Gull", charaData.IsMinionUnlocked(408));

                        ImGui.EndTable();
                    }
                    ImGui.TreePop();
                }
                if (ImGui.TreeNode("Tribes"))
                {
                    if (ImGui.BeginTable("minionsTribe", 2))
                    {
                        SetUpTableColumns();

                        DrawTableRowText("Wind-up Sylph", charaData.IsMinionUnlocked(50));
                        DrawTableRowText("Wind-up Violet", charaData.IsMinionUnlocked(123));
                        DrawTableRowText("Wind-up Amalj'aa", charaData.IsMinionUnlocked(58));
                        DrawTableRowText("Wind-up Founder", charaData.IsMinionUnlocked(124));
                        DrawTableRowText("Wind-up Kobold", charaData.IsMinionUnlocked(60));
                        DrawTableRowText("Wind-up Kobolder", charaData.IsMinionUnlocked(60));
                        DrawTableRowText("Wind-up Sahagin", charaData.IsMinionUnlocked(61));
                        DrawTableRowText("Wind-up Sea Devil", charaData.IsMinionUnlocked(127));
                        DrawTableRowText("Wind-up Dezul Qualan", charaData.IsMinionUnlocked(125));
                        DrawTableRowText("Wind-up Ixal", charaData.IsMinionUnlocked(59));
                        DrawTableRowText("Wind-up Gundu Warrior", charaData.IsMinionUnlocked(135));
                        DrawTableRowText("Wind-up Zundu Warrior", charaData.IsMinionUnlocked(172));
                        DrawTableRowText("Wind-up Vath", charaData.IsMinionUnlocked(175));
                        DrawTableRowText("Wind-up Gnath", charaData.IsMinionUnlocked(156));
                        DrawTableRowText("Wind-up Dragonet", charaData.IsMinionUnlocked(184));
                        DrawTableRowText("Wind-up Ohl Deeh", charaData.IsMinionUnlocked(235));
                        DrawTableRowText("Wind-up Kojin", charaData.IsMinionUnlocked(266));
                        DrawTableRowText("Wind-up Redback", charaData.IsMinionUnlocked(323));
                        DrawTableRowText("Zephyrous Zabuton", charaData.IsMinionUnlocked(328));
                        DrawTableRowText("Wind-up Ananta", charaData.IsMinionUnlocked(277));
                        DrawTableRowText("Wind-up Qalyana", charaData.IsMinionUnlocked(322));
                        DrawTableRowText("Attendee #777", charaData.IsMinionUnlocked(302));
                        DrawTableRowText("Wind-up Pixie", charaData.IsMinionUnlocked(354));
                        DrawTableRowText("The Behelmeted Serpent of Ronka", charaData.IsMinionUnlocked(369));
                        DrawTableRowText("The Behatted Serpent of Ronka", charaData.IsMinionUnlocked(370));
                        DrawTableRowText("Lalinator 5.H0", charaData.IsMinionUnlocked(380));
                        DrawTableRowText("Wind-up Arkasodara", charaData.IsMinionUnlocked(444));
                        DrawTableRowText("Lumini", charaData.IsMinionUnlocked(457));

                        ImGui.EndTable();
                    }
                    ImGui.TreePop();
                }
                if (ImGui.TreeNode("Bozja"))
                {
                    if (ImGui.BeginTable("minionsBozja", 2))
                    {
                        SetUpTableColumns();

                        DrawTableRowText("Mameshiba", charaData.IsMinionUnlocked(267));
                        DrawTableRowText("Koala Joey", charaData.IsMinionUnlocked(271));
                        DrawTableRowText("Salt & Pepper Seal", charaData.IsMinionUnlocked(272));
                        DrawTableRowText("Axolotl Eft", charaData.IsMinionUnlocked(273));
                        DrawTableRowText("Wind-up Ravana", charaData.IsMinionUnlocked(265));
                        DrawTableRowText("Wind-up Shinryu", charaData.IsMinionUnlocked(275));
                        DrawTableRowText("Tengu Doll", charaData.IsMinionUnlocked(268));
                        DrawTableRowText("White Whittret", charaData.IsMinionUnlocked(279));
                        DrawTableRowText("Aurelia Polyp", charaData.IsMinionUnlocked(283));
                        DrawTableRowText("Byakko Cub", charaData.IsMinionUnlocked(284));
                        DrawTableRowText("Private Moai", charaData.IsMinionUnlocked(278));
                        DrawTableRowText("Monkey King", charaData.IsMinionUnlocked(290));
                        DrawTableRowText("Mudpie", charaData.IsMinionUnlocked(312));
                        DrawTableRowText("Scarlet Peacock", charaData.IsMinionUnlocked(303));
                        DrawTableRowText("Abroader Otter", charaData.IsMinionUnlocked(329));
                        DrawTableRowText("Seitei", charaData.IsMinionUnlocked(327));
                        DrawTableRowText("Wind-up Weapon", charaData.IsMinionUnlocked(321));
                        DrawTableRowText("Chameleon", charaData.IsMinionUnlocked(334));
                        DrawTableRowText("Sharksucker-class Insubmersible", charaData.IsMinionUnlocked(348));
                        DrawTableRowText("Magitek Helldiver F1", charaData.IsMinionUnlocked(383));
                        DrawTableRowText("Dáinsleif F1", charaData.IsMinionUnlocked(389));
                        DrawTableRowText("Save the Princess", charaData.IsMinionUnlocked(404));
                        DrawTableRowText("Wind-up Gunnhildr", charaData.IsMinionUnlocked(418));

                        ImGui.EndTable();
                    }
                    ImGui.TreePop();
                }
                if (ImGui.TreeNode("Crafted"))
                {
                    if (ImGui.BeginTable("minionsCrafted", 2))
                    {
                        SetUpTableColumns();

                        DrawTableRowText("Magic Broom", charaData.IsMinionUnlocked(81));
                        DrawTableRowText("Clockwork Barrow", charaData.IsMinionUnlocked(140));
                        DrawTableRowText("Model Magitek Bit", charaData.IsMinionUnlocked(100));
                        DrawTableRowText("Private Moai", charaData.IsMinionUnlocked(278));
                        DrawTableRowText("Wind-up Dullahan", charaData.IsMinionUnlocked(29));
                        DrawTableRowText("Steam-powered Gobwalker G-VII", charaData.IsMinionUnlocked(147));
                        DrawTableRowText("Bantam Train", charaData.IsMinionUnlocked(475));
                        DrawTableRowText("Gravel Golem", charaData.IsMinionUnlocked(22));
                        DrawTableRowText("Model Vanguard", charaData.IsMinionUnlocked(43));
                        DrawTableRowText("Wind-up Aldgoat", charaData.IsMinionUnlocked(39));
                        DrawTableRowText("Wind-up Qiqirn", charaData.IsMinionUnlocked(53));
                        DrawTableRowText("Plush Cushion", charaData.IsMinionUnlocked(66));
                        DrawTableRowText("Nana Bear", charaData.IsMinionUnlocked(95));
                        DrawTableRowText("Wind-up Illuminatus", charaData.IsMinionUnlocked(158));
                        DrawTableRowText("Wind-up Chimera", charaData.IsMinionUnlocked(255));
                        DrawTableRowText("Wind-up Sadu", charaData.IsMinionUnlocked(294));
                        DrawTableRowText("Wind-up Magnai", charaData.IsMinionUnlocked(282));
                        DrawTableRowText("Adventurer's Basket", charaData.IsMinionUnlocked(436));
                        DrawTableRowText("Wind-up Ifrit", charaData.IsMinionUnlocked(168));
                        DrawTableRowText("Wind-up Garuda", charaData.IsMinionUnlocked(169));
                        DrawTableRowText("Wind-up Titan", charaData.IsMinionUnlocked(170));
                        DrawTableRowText("Wind-up Leviathan", charaData.IsMinionUnlocked(171));
                        DrawTableRowText("Wind-up Ramuh", charaData.IsMinionUnlocked(185));
                        DrawTableRowText("Wind-up Shiva", charaData.IsMinionUnlocked(186));
                        DrawTableRowText("Wind-up Bismarck", charaData.IsMinionUnlocked(263));
                        DrawTableRowText("Wind-up Susano", charaData.IsMinionUnlocked(261));
                        DrawTableRowText("Wind-up Lakshmi", charaData.IsMinionUnlocked(262));
                        DrawTableRowText("Wind-up Ravana", charaData.IsMinionUnlocked(265));
                        DrawTableRowText("Wind-up Shinryu", charaData.IsMinionUnlocked(275));
                        DrawTableRowText("Byakko Cub", charaData.IsMinionUnlocked(284));
                        DrawTableRowText("Scarlet Peacock", charaData.IsMinionUnlocked(303));
                        DrawTableRowText("Seitei", charaData.IsMinionUnlocked(327));
                        DrawTableRowText("Atrophied Atomos", charaData.IsMinionUnlocked(136));
                        DrawTableRowText("Wanderer's Campfire", charaData.IsMinionUnlocked(414));

                        ImGui.EndTable();
                    }
                    ImGui.TreePop();
                }
                if (ImGui.TreeNode("Deep Dungeon"))
                {
                    if (ImGui.BeginTable("minionsDeep", 2))
                    {
                        SetUpTableColumns();

                        DrawTableRowText("Wind-up Tonberry", charaData.IsMinionUnlocked(23));
                        DrawTableRowText("Tiny Bulb", charaData.IsMinionUnlocked(27));
                        DrawTableRowText("Bluebird", charaData.IsMinionUnlocked(16));
                        DrawTableRowText("Minute Mindflayer", charaData.IsMinionUnlocked(56));
                        DrawTableRowText("Baby Opo-opo", charaData.IsMinionUnlocked(80));
                        DrawTableRowText("Nutkin", charaData.IsMinionUnlocked(97));
                        DrawTableRowText("Miniature Minecart", charaData.IsMinionUnlocked(96));
                        DrawTableRowText("Mummy's Little Mummy", charaData.IsMinionUnlocked(112));
                        DrawTableRowText("Gaelikitten", charaData.IsMinionUnlocked(139));
                        DrawTableRowText("Page 63", charaData.IsMinionUnlocked(142));
                        DrawTableRowText("Unicolt", charaData.IsMinionUnlocked(134));
                        DrawTableRowText("Lesser Panda", charaData.IsMinionUnlocked(141));
                        DrawTableRowText("Gestahl", charaData.IsMinionUnlocked(146));
                        DrawTableRowText("Owlet", charaData.IsMinionUnlocked(137));
                        DrawTableRowText("Ugly Duckling", charaData.IsMinionUnlocked(138));
                        DrawTableRowText("Paissa Brat", charaData.IsMinionUnlocked(157));
                        DrawTableRowText("Korpokkur Kid", charaData.IsMinionUnlocked(166));
                        DrawTableRowText("Hunting Hawk", charaData.IsMinionUnlocked(162));
                        DrawTableRowText("Wind-up Ifrit", charaData.IsMinionUnlocked(168));
                        DrawTableRowText("Morpho", charaData.IsMinionUnlocked(180));
                        DrawTableRowText("Wind-up Garuda", charaData.IsMinionUnlocked(169));
                        DrawTableRowText("Wind-up Titan", charaData.IsMinionUnlocked(170));
                        DrawTableRowText("Wind-up Leviathan", charaData.IsMinionUnlocked(171));
                        DrawTableRowText("Dwarf Rabbit", charaData.IsMinionUnlocked(197));
                        DrawTableRowText("Wind-up Ramuh", charaData.IsMinionUnlocked(185));
                        DrawTableRowText("Wind-up Shiva", charaData.IsMinionUnlocked(186));
                        DrawTableRowText("Wind-up Sasquatch", charaData.IsMinionUnlocked(196));
                        DrawTableRowText("Hecteye", charaData.IsMinionUnlocked(198));
                        DrawTableRowText("Shaggy Shoat", charaData.IsMinionUnlocked(216));
                        DrawTableRowText("Wind-up Edda", charaData.IsMinionUnlocked(219));
                        DrawTableRowText("Baby Brachiosaur", charaData.IsMinionUnlocked(190));
                        DrawTableRowText("Castaway Chocobo Chick", charaData.IsMinionUnlocked(237));
                        DrawTableRowText("Tiny Tatsunoko", charaData.IsMinionUnlocked(244));
                        DrawTableRowText("Bombfish", charaData.IsMinionUnlocked(245));
                        DrawTableRowText("Bom Boko", charaData.IsMinionUnlocked(246));
                        DrawTableRowText("Odder Otter", charaData.IsMinionUnlocked(241));
                        DrawTableRowText("Ghido", charaData.IsMinionUnlocked(258));
                        DrawTableRowText("Road Sparrow", charaData.IsMinionUnlocked(247));
                        DrawTableRowText("Wind-up Bismarck", charaData.IsMinionUnlocked(263));
                        DrawTableRowText("Wind-up Susano", charaData.IsMinionUnlocked(261));
                        DrawTableRowText("Wind-up Lakshmi", charaData.IsMinionUnlocked(262));
                        DrawTableRowText("Wind-up Ravana", charaData.IsMinionUnlocked(265));
                        DrawTableRowText("Frilled Dragon", charaData.IsMinionUnlocked(292));

                        ImGui.EndTable();
                    }
                    ImGui.TreePop();
                }
                if (ImGui.TreeNode("Dungeon"))
                {
                    if (ImGui.BeginTable("minionsDungeon", 2))
                    {
                        SetUpTableColumns();

                        DrawTableRowText("Morbol Seedling", charaData.IsMinionUnlocked(12));
                        DrawTableRowText("Bite-sized Pudding", charaData.IsMinionUnlocked(42));
                        DrawTableRowText("Demon Brick", charaData.IsMinionUnlocked(44));
                        DrawTableRowText("Slime Puddle", charaData.IsMinionUnlocked(47));
                        DrawTableRowText("Baby Opo-opo", charaData.IsMinionUnlocked(80));
                        DrawTableRowText("Naughty Nanka", charaData.IsMinionUnlocked(102));
                        DrawTableRowText("Tight-beaked Parrot", charaData.IsMinionUnlocked(57));
                        DrawTableRowText("Mummy's Little Mummy", charaData.IsMinionUnlocked(112));
                        DrawTableRowText("Gaelikitten", charaData.IsMinionUnlocked(139));
                        DrawTableRowText("Page 63", charaData.IsMinionUnlocked(142));
                        DrawTableRowText("Unicolt", charaData.IsMinionUnlocked(134));
                        DrawTableRowText("Lesser Panda", charaData.IsMinionUnlocked(141));
                        DrawTableRowText("Owlet", charaData.IsMinionUnlocked(137));
                        DrawTableRowText("Ugly Duckling", charaData.IsMinionUnlocked(138));
                        DrawTableRowText("Korpokkur Kid", charaData.IsMinionUnlocked(166));
                        DrawTableRowText("Calca", charaData.IsMinionUnlocked(178));
                        DrawTableRowText("Brina", charaData.IsMinionUnlocked(179));
                        DrawTableRowText("Morpho", charaData.IsMinionUnlocked(180));
                        DrawTableRowText("Calamari", charaData.IsMinionUnlocked(189));
                        DrawTableRowText("Shaggy Shoat", charaData.IsMinionUnlocked(216));
                        DrawTableRowText("Bullpup", charaData.IsMinionUnlocked(226));
                        DrawTableRowText("Bombfish", charaData.IsMinionUnlocked(245));
                        DrawTableRowText("Ivon Coeurlfist Doll", charaData.IsMinionUnlocked(254));
                        DrawTableRowText("Ghido", charaData.IsMinionUnlocked(258));
                        DrawTableRowText("Road Sparrow", charaData.IsMinionUnlocked(247));
                        DrawTableRowText("Dress-up Yugiri", charaData.IsMinionUnlocked(249));
                        DrawTableRowText("Mock-up Grynewaht", charaData.IsMinionUnlocked(252));
                        DrawTableRowText("Magitek Avenger F1", charaData.IsMinionUnlocked(257));
                        DrawTableRowText("Salt & Pepper Seal", charaData.IsMinionUnlocked(272));
                        DrawTableRowText("White Whittret", charaData.IsMinionUnlocked(279));
                        DrawTableRowText("Monkey King", charaData.IsMinionUnlocked(290));
                        DrawTableRowText("Mudpie", charaData.IsMinionUnlocked(312));
                        DrawTableRowText("Wind-up Weapon", charaData.IsMinionUnlocked(321));
                        DrawTableRowText("Armadillo Bowler", charaData.IsMinionUnlocked(336));
                        DrawTableRowText("Clionid Larva", charaData.IsMinionUnlocked(339));
                        DrawTableRowText("Tiny Echevore", charaData.IsMinionUnlocked(347));
                        DrawTableRowText("Forgiven Hate", charaData.IsMinionUnlocked(352));
                        DrawTableRowText("Black Hayate", charaData.IsMinionUnlocked(333));
                        DrawTableRowText("Chameleon", charaData.IsMinionUnlocked(334));
                        DrawTableRowText("Shoebill", charaData.IsMinionUnlocked(349));
                        DrawTableRowText("Little Leannan", charaData.IsMinionUnlocked(361));
                        DrawTableRowText("Ancient One", charaData.IsMinionUnlocked(374));
                        DrawTableRowText("Ephemeral Necromancer", charaData.IsMinionUnlocked(385));
                        DrawTableRowText("Drippy", charaData.IsMinionUnlocked(405));
                        DrawTableRowText("Magitek Predator F1", charaData.IsMinionUnlocked(411));
                        DrawTableRowText("Prince Lunatender", charaData.IsMinionUnlocked(433));
                        DrawTableRowText("Tiny Troll", charaData.IsMinionUnlocked(434));
                        DrawTableRowText("Wind-up Magus Sisters", charaData.IsMinionUnlocked(424));
                        DrawTableRowText("Wind-up Anima", charaData.IsMinionUnlocked(426));
                        DrawTableRowText("Hippo Calf", charaData.IsMinionUnlocked(431));
                        DrawTableRowText("Caduceus", charaData.IsMinionUnlocked(435));
                        DrawTableRowText("Starbird", charaData.IsMinionUnlocked(427));
                        DrawTableRowText("Optimus Omicron", charaData.IsMinionUnlocked(425));
                        DrawTableRowText("Teacup Kapikulu", charaData.IsMinionUnlocked(447));
                        DrawTableRowText("Wind-up Scarmiglione", charaData.IsMinionUnlocked(460));
                        DrawTableRowText("Sponge Silkie", charaData.IsMinionUnlocked(463));
                        DrawTableRowText("Sewer Skink", charaData.IsMinionUnlocked(464));
                        DrawTableRowText("Wind-up Cagnazzo", charaData.IsMinionUnlocked(471));

                        ImGui.EndTable();
                    }
                    ImGui.TreePop();
                }
                if (ImGui.TreeNode("Eureka"))
                {
                    if (ImGui.BeginTable("minionsEureka", 2))
                    {
                        SetUpTableColumns();

                        DrawTableRowText("Calca", charaData.IsMinionUnlocked(178));
                        DrawTableRowText("Wind-up Fafnir", charaData.IsMinionUnlocked(285));
                        DrawTableRowText("The Prince Of Anemos", charaData.IsMinionUnlocked(287));
                        DrawTableRowText("Wind-up Mithra", charaData.IsMinionUnlocked(286));
                        DrawTableRowText("Copycat Bulb", charaData.IsMinionUnlocked(295));
                        DrawTableRowText("Wind-up Tarutaru", charaData.IsMinionUnlocked(296));
                        DrawTableRowText("Dhalmel Calf", charaData.IsMinionUnlocked(315));
                        DrawTableRowText("Wind-up Elvaan", charaData.IsMinionUnlocked(314));
                        DrawTableRowText("Conditional Virtue", charaData.IsMinionUnlocked(318));
                        DrawTableRowText("Yukinko Snowflake", charaData.IsMinionUnlocked(319));

                        ImGui.EndTable();
                    }
                    ImGui.TreePop();
                }
                if (ImGui.TreeNode("FATE"))
                {
                    if (ImGui.BeginTable("minionsFate", 2))
                    {
                        SetUpTableColumns();

                        DrawTableRowText("Baby Bun", charaData.IsMinionUnlocked(14));
                        DrawTableRowText("Infant Imp", charaData.IsMinionUnlocked(18));
                        DrawTableRowText("Pudgy Puk", charaData.IsMinionUnlocked(31));
                        DrawTableRowText("Smallshell", charaData.IsMinionUnlocked(34));
                        DrawTableRowText("Gold Rush Minecart", charaData.IsMinionUnlocked(154));
                        DrawTableRowText("Fox Kit", charaData.IsMinionUnlocked(242));
                        DrawTableRowText("Wind-up Ixion", charaData.IsMinionUnlocked(274));
                        DrawTableRowText("Micro Gigantender", charaData.IsMinionUnlocked(338));
                        DrawTableRowText("Butterfly Effect", charaData.IsMinionUnlocked(350));
                        DrawTableRowText("Ironfrog Ambler", charaData.IsMinionUnlocked(351));
                        DrawTableRowText("Tinker's Bell", charaData.IsMinionUnlocked(346));
                        DrawTableRowText("Little Leafman", charaData.IsMinionUnlocked(368));
                        DrawTableRowText("Amaro Hatchling", charaData.IsMinionUnlocked(377));
                        DrawTableRowText("Wee Ea", charaData.IsMinionUnlocked(423));
                        DrawTableRowText("Wind-up Daivadipa", charaData.IsMinionUnlocked(442));

                        ImGui.EndTable();
                    }
                    ImGui.TreePop();
                }
                if (ImGui.TreeNode("Gathering"))
                {
                    if (ImGui.BeginTable("minionsGather", 2))
                    {
                        SetUpTableColumns();

                        DrawTableRowText("Tiny Tortoise", charaData.IsMinionUnlocked(24));
                        DrawTableRowText("Gigantpole", charaData.IsMinionUnlocked(30));
                        DrawTableRowText("Kidragora", charaData.IsMinionUnlocked(48));
                        DrawTableRowText("Coblyn Larva", charaData.IsMinionUnlocked(38));
                        DrawTableRowText("Magic Bucket", charaData.IsMinionUnlocked(188));
                        DrawTableRowText("Castaway Chocobo Chick", charaData.IsMinionUnlocked(237));
                        DrawTableRowText("Tiny Tatsunoko", charaData.IsMinionUnlocked(244));

                        ImGui.EndTable();
                    }
                    ImGui.TreePop();
                }
                if (ImGui.TreeNode("Mog Station/Collector's Edition"))
                {
                    if (ImGui.BeginTable("minionsMog", 2))
                    {
                        SetUpTableColumns();

                        DrawTableRowText("Baby Behemoth", charaData.IsMinionUnlocked(5));
                        DrawTableRowText("Tender Lamb", charaData.IsMinionUnlocked(46));
                        DrawTableRowText("Wind-up Edvya", charaData.IsMinionUnlocked(64));
                        DrawTableRowText("Wind-up Shantotto", charaData.IsMinionUnlocked(63));
                        DrawTableRowText("Wind-up Moogle", charaData.IsMinionUnlocked(79));
                        DrawTableRowText("Wind-up Minfilia", charaData.IsMinionUnlocked(98));
                        DrawTableRowText("Wind-up Thancred", charaData.IsMinionUnlocked(99));
                        DrawTableRowText("Wind-up Y'shtola", charaData.IsMinionUnlocked(91));
                        DrawTableRowText("Wind-up Yda", charaData.IsMinionUnlocked(107));
                        DrawTableRowText("Wind-up Papalymo", charaData.IsMinionUnlocked(108));
                        DrawTableRowText("Wind-up Urianger", charaData.IsMinionUnlocked(109));
                        DrawTableRowText("Hoary The Snowman", charaData.IsMinionUnlocked(105));
                        DrawTableRowText("Wind-up Kain", charaData.IsMinionUnlocked(129));
                        DrawTableRowText("Wind-up Alisaie", charaData.IsMinionUnlocked(131));
                        DrawTableRowText("Wind-up Tataru", charaData.IsMinionUnlocked(132));
                        DrawTableRowText("Wind-up Iceheart", charaData.IsMinionUnlocked(145));
                        DrawTableRowText("Pumpkin Butler", charaData.IsMinionUnlocked(159));
                        DrawTableRowText("Wind-up Yugiri", charaData.IsMinionUnlocked(150));
                        DrawTableRowText("Panda Cub", charaData.IsMinionUnlocked(103));
                        DrawTableRowText("Doman Magpie", charaData.IsMinionUnlocked(121));
                        DrawTableRowText("Dress-up Y'shtola", charaData.IsMinionUnlocked(177));
                        DrawTableRowText("Wind-up Krile", charaData.IsMinionUnlocked(192));
                        DrawTableRowText("Continental Eye", charaData.IsMinionUnlocked(225));
                        DrawTableRowText("Wind-up Rikku", charaData.IsMinionUnlocked(221));
                        DrawTableRowText("Wind-up Lulu", charaData.IsMinionUnlocked(222));
                        DrawTableRowText("Angel Of Mercy", charaData.IsMinionUnlocked(227));
                        DrawTableRowText("Wind-up Yuna", charaData.IsMinionUnlocked(220));
                        DrawTableRowText("Wind-up Bartz", charaData.IsMinionUnlocked(238));
                        DrawTableRowText("Wind-up Lyse", charaData.IsMinionUnlocked(248));
                        DrawTableRowText("Wind-up Gosetsu", charaData.IsMinionUnlocked(250));
                        DrawTableRowText("Motley Egg", charaData.IsMinionUnlocked(280));
                        DrawTableRowText("Wind-up Cirina", charaData.IsMinionUnlocked(293));
                        DrawTableRowText("Little Yin", charaData.IsMinionUnlocked(307));
                        DrawTableRowText("Little Yang", charaData.IsMinionUnlocked(308));
                        DrawTableRowText("Wind-up Tifa", charaData.IsMinionUnlocked(311));
                        DrawTableRowText("Wind-up Cloud", charaData.IsMinionUnlocked(309));
                        DrawTableRowText("Wind-up Aerith", charaData.IsMinionUnlocked(310));
                        DrawTableRowText("Wind-up Fran", charaData.IsMinionUnlocked(325));
                        DrawTableRowText("Brave New Y'shtola", charaData.IsMinionUnlocked(331));
                        DrawTableRowText("Wind-up Ardbert", charaData.IsMinionUnlocked(382));
                        DrawTableRowText("Wind-up Edge", charaData.IsMinionUnlocked(401));
                        DrawTableRowText("Wind-up Rydia", charaData.IsMinionUnlocked(402));
                        DrawTableRowText("Wind-up Rosa", charaData.IsMinionUnlocked(403));
                        DrawTableRowText("Wind-up Rudy", charaData.IsMinionUnlocked(420));
                        DrawTableRowText("Squirrel Emperor", charaData.IsMinionUnlocked(421));
                        DrawTableRowText("Wind-up Porom", charaData.IsMinionUnlocked(400));

                        ImGui.EndTable();
                    }
                    ImGui.TreePop();
                }
                if (ImGui.TreeNode("PvP"))
                {
                    if (ImGui.BeginTable("minionsPvp", 2))
                    {
                        SetUpTableColumns();

                        DrawTableRowText("Fenrir Pup", charaData.IsMinionUnlocked(183));
                        DrawTableRowText("Wind-up Cheerleader", charaData.IsMinionUnlocked(191));
                        DrawTableRowText("Clockwork Lantern", charaData.IsMinionUnlocked(291));
                        DrawTableRowText("Minitek Conveyor", charaData.IsMinionUnlocked(324));
                        DrawTableRowText("Protonaught", charaData.IsMinionUnlocked(446));

                        ImGui.EndTable();
                    }
                    ImGui.TreePop();
                }
                if (ImGui.TreeNode("Quest"))
                {
                    if (ImGui.BeginTable("minionsQuest", 2))
                    {
                        SetUpTableColumns();

                        DrawTableRowText("Chigoe Larva", charaData.IsMinionUnlocked(15));
                        DrawTableRowText("Cactuar Cutting", charaData.IsMinionUnlocked(33));
                        DrawTableRowText("Goobbue Sproutling", charaData.IsMinionUnlocked(41));
                        DrawTableRowText("Coeurl Kitten", charaData.IsMinionUnlocked(19));
                        DrawTableRowText("Wolf Pup", charaData.IsMinionUnlocked(35));
                        DrawTableRowText("Mini Mole", charaData.IsMinionUnlocked(45));
                        DrawTableRowText("Wind-up Gentleman", charaData.IsMinionUnlocked(21));
                        DrawTableRowText("Accompaniment Node", charaData.IsMinionUnlocked(149));
                        DrawTableRowText("Gigi", charaData.IsMinionUnlocked(230));
                        DrawTableRowText("Anima", charaData.IsMinionUnlocked(231));
                        DrawTableRowText("Palico", charaData.IsMinionUnlocked(300));
                        DrawTableRowText("Wind-up Alpha", charaData.IsMinionUnlocked(304));
                        DrawTableRowText("The Great Serpent Of Ronka", charaData.IsMinionUnlocked(337));
                        DrawTableRowText("Golden Dhyata", charaData.IsMinionUnlocked(437));

                        ImGui.EndTable();
                    }
                    ImGui.TreePop();
                }
                if (ImGui.TreeNode("Raid"))
                {
                    if (ImGui.BeginTable("minionsRaid", 2))
                    {
                        SetUpTableColumns();

                        DrawTableRowText("Wind-up Onion Knight", charaData.IsMinionUnlocked(92));
                        DrawTableRowText("Puff Of Darkness", charaData.IsMinionUnlocked(101));
                        DrawTableRowText("Wind-up Echidna", charaData.IsMinionUnlocked(160));
                        DrawTableRowText("Faustlet", charaData.IsMinionUnlocked(176));
                        DrawTableRowText("Wind-up Calofisteri", charaData.IsMinionUnlocked(195));
                        DrawTableRowText("Toy Alexander", charaData.IsMinionUnlocked(215));
                        DrawTableRowText("Wind-up Scathach", charaData.IsMinionUnlocked(232));
                        DrawTableRowText("Wind-up Exdeath", charaData.IsMinionUnlocked(259));
                        DrawTableRowText("Wind-up Kefka", charaData.IsMinionUnlocked(281));
                        DrawTableRowText("Construct 8", charaData.IsMinionUnlocked(299));
                        DrawTableRowText("OMG", charaData.IsMinionUnlocked(305));
                        DrawTableRowText("Wind-up Ramza", charaData.IsMinionUnlocked(270));
                        DrawTableRowText("Eden Minor", charaData.IsMinionUnlocked(341));
                        DrawTableRowText("Pod 054", charaData.IsMinionUnlocked(364));
                        DrawTableRowText("Pod 316", charaData.IsMinionUnlocked(365));
                        DrawTableRowText("Wind-up Ryne", charaData.IsMinionUnlocked(332));
                        DrawTableRowText("2B Automaton", charaData.IsMinionUnlocked(394));
                        DrawTableRowText("2P Automaton", charaData.IsMinionUnlocked(395));
                        DrawTableRowText("Wind-up Gaia", charaData.IsMinionUnlocked(398));
                        DrawTableRowText("Smaller Stubby", charaData.IsMinionUnlocked(415));
                        DrawTableRowText("9S Automaton", charaData.IsMinionUnlocked(419));
                        DrawTableRowText("Nosferatu", charaData.IsMinionUnlocked(440));
                        DrawTableRowText("Wind-up Azeyma", charaData.IsMinionUnlocked(451));
                        DrawTableRowText("Wind-up Erichthonios", charaData.IsMinionUnlocked(466));
                        DrawTableRowText("Wind-up Halone", charaData.IsMinionUnlocked(474));

                        ImGui.EndTable();
                    }
                    ImGui.TreePop();
                }
                if (ImGui.TreeNode("Ishgardian Restoration"))
                {
                    if (ImGui.BeginTable("minionsSkybuilder", 2))
                    {
                        SetUpTableColumns();

                        DrawTableRowText("Plush Cushion", charaData.IsMinionUnlocked(66));
                        DrawTableRowText("Nutkin", charaData.IsMinionUnlocked(97));
                        DrawTableRowText("Atrophied Atomos", charaData.IsMinionUnlocked(136));
                        DrawTableRowText("Gaelikitten", charaData.IsMinionUnlocked(139));
                        DrawTableRowText("Owlet", charaData.IsMinionUnlocked(137));
                        DrawTableRowText("Ugly Duckling", charaData.IsMinionUnlocked(138));
                        DrawTableRowText("Clockwork Barrow", charaData.IsMinionUnlocked(140));
                        DrawTableRowText("Paissa Brat", charaData.IsMinionUnlocked(157));
                        DrawTableRowText("Hunting Hawk", charaData.IsMinionUnlocked(162));
                        DrawTableRowText("Morpho", charaData.IsMinionUnlocked(180));
                        DrawTableRowText("Calamari", charaData.IsMinionUnlocked(189));
                        DrawTableRowText("Dwarf Rabbit", charaData.IsMinionUnlocked(197));
                        DrawTableRowText("Shaggy Shoat", charaData.IsMinionUnlocked(216));
                        DrawTableRowText("Bullpup", charaData.IsMinionUnlocked(226));
                        DrawTableRowText("Baby Brachiosaur", charaData.IsMinionUnlocked(190));
                        DrawTableRowText("Pegasus Colt", charaData.IsMinionUnlocked(194));
                        DrawTableRowText("Miniature White Knight", charaData.IsMinionUnlocked(357));
                        DrawTableRowText("Dress-up Estinien", charaData.IsMinionUnlocked(360));
                        DrawTableRowText("Paissa Patissier", charaData.IsMinionUnlocked(372));
                        DrawTableRowText("Paissa Threadpuller", charaData.IsMinionUnlocked(373));
                        DrawTableRowText("Cerberpup", charaData.IsMinionUnlocked(363));
                        DrawTableRowText("Weatherproof Gaelicat", charaData.IsMinionUnlocked(384));
                        DrawTableRowText("Petit Pteranodon", charaData.IsMinionUnlocked(388));
                        DrawTableRowText("Trike", charaData.IsMinionUnlocked(406));

                        ImGui.EndTable();
                    }
                    ImGui.TreePop();
                }
                if (ImGui.TreeNode("Treasure Hunt"))
                {
                    if (ImGui.BeginTable("minionsTreasure", 2))
                    {
                        SetUpTableColumns();

                        DrawTableRowText("Wind-up Tonberry", charaData.IsMinionUnlocked(23));
                        DrawTableRowText("Tiny Bulb", charaData.IsMinionUnlocked(27));
                        DrawTableRowText("Bluebird", charaData.IsMinionUnlocked(16));
                        DrawTableRowText("Minute Mindflayer", charaData.IsMinionUnlocked(56));
                        DrawTableRowText("Baby Opo-opo", charaData.IsMinionUnlocked(80));
                        DrawTableRowText("Nutkin", charaData.IsMinionUnlocked(97));
                        DrawTableRowText("Tight-beaked Parrot", charaData.IsMinionUnlocked(57));
                        DrawTableRowText("Mummy's Little Mummy", charaData.IsMinionUnlocked(112));
                        DrawTableRowText("Gaelikitten", charaData.IsMinionUnlocked(139));
                        DrawTableRowText("Page 63", charaData.IsMinionUnlocked(142));
                        DrawTableRowText("Unicolt", charaData.IsMinionUnlocked(134));
                        DrawTableRowText("Lesser Panda", charaData.IsMinionUnlocked(141));
                        DrawTableRowText("Owlet", charaData.IsMinionUnlocked(137));
                        DrawTableRowText("Ugly Duckling", charaData.IsMinionUnlocked(138));
                        DrawTableRowText("Paissa Brat", charaData.IsMinionUnlocked(157));
                        DrawTableRowText("Dwarf Rabbit", charaData.IsMinionUnlocked(197));
                        DrawTableRowText("Wind-up Namazu", charaData.IsMinionUnlocked(253));
                        DrawTableRowText("Wind-up Matanga", charaData.IsMinionUnlocked(269));
                        DrawTableRowText("The Gold Whisker", charaData.IsMinionUnlocked(289));
                        DrawTableRowText("Capybara Pup", charaData.IsMinionUnlocked(316));
                        DrawTableRowText("Hedgehoglet", charaData.IsMinionUnlocked(330));
                        DrawTableRowText("Wind-up Fuath", charaData.IsMinionUnlocked(335));
                        DrawTableRowText("Sungold Talos", charaData.IsMinionUnlocked(366));
                        DrawTableRowText("Golden Beaver", charaData.IsMinionUnlocked(407));
                        DrawTableRowText("Royal Lunatender", charaData.IsMinionUnlocked(443));
                        DrawTableRowText("Wind-up Aidoneus", charaData.IsMinionUnlocked(477));
                        DrawTableRowText("Wind-up Philos", charaData.IsMinionUnlocked(465));

                        ImGui.EndTable();
                    }
                    ImGui.TreePop();
                }
                if (ImGui.TreeNode("Trial"))
                {
                    if (ImGui.BeginTable("minionsTrial", 2))
                    {
                        SetUpTableColumns();

                        DrawTableRowText("Wind-up Ultros", charaData.IsMinionUnlocked(104));
                        DrawTableRowText("Enkidu", charaData.IsMinionUnlocked(122));
                        DrawTableRowText("Poogie", charaData.IsMinionUnlocked(301));
                        DrawTableRowText("Giant Beaver", charaData.IsMinionUnlocked(342));

                        ImGui.EndTable();
                    }
                    ImGui.TreePop();
                }
                if (ImGui.TreeNode("Venture"))
                {
                    if (ImGui.BeginTable("minionsVenture", 2))
                    {
                        SetUpTableColumns();

                        DrawTableRowText("Minute Mindflayer", charaData.IsMinionUnlocked(56));
                        DrawTableRowText("Tiny Tapir", charaData.IsMinionUnlocked(94));
                        DrawTableRowText("Miniature Minecart", charaData.IsMinionUnlocked(96));
                        DrawTableRowText("Littlefoot", charaData.IsMinionUnlocked(111));
                        DrawTableRowText("Fat Cat", charaData.IsMinionUnlocked(110));
                        DrawTableRowText("Gestahl", charaData.IsMinionUnlocked(146));
                        DrawTableRowText("Bom Boko", charaData.IsMinionUnlocked(246));
                        DrawTableRowText("Odder Otter", charaData.IsMinionUnlocked(241));
                        DrawTableRowText("Mameshiba", charaData.IsMinionUnlocked(267));
                        DrawTableRowText("Koala Joey", charaData.IsMinionUnlocked(271));
                        DrawTableRowText("Axolotl Eft", charaData.IsMinionUnlocked(273));
                        DrawTableRowText("Tengu Doll", charaData.IsMinionUnlocked(268));
                        DrawTableRowText("Bacon Bits", charaData.IsMinionUnlocked(353));
                        DrawTableRowText("Mystic Weapon", charaData.IsMinionUnlocked(355));
                        DrawTableRowText("Domakin", charaData.IsMinionUnlocked(359));
                        DrawTableRowText("Wind-up Hobgoblin", charaData.IsMinionUnlocked(362));
                        DrawTableRowText("Allagan Melon", charaData.IsMinionUnlocked(386));
                        DrawTableRowText("Greener Gleaner", charaData.IsMinionUnlocked(438));
                        DrawTableRowText("Flag", charaData.IsMinionUnlocked(422));
                        DrawTableRowText("Crabe De La Crabe", charaData.IsMinionUnlocked(432));
                        DrawTableRowText("Wind-up Grebuloff", charaData.IsMinionUnlocked(439));
                        DrawTableRowText("Wind-up Kangaroo", charaData.IsMinionUnlocked(445));
                        DrawTableRowText("Chewy", charaData.IsMinionUnlocked(448));
                        DrawTableRowText("Blue-footed Booby", charaData.IsMinionUnlocked(453));
                        DrawTableRowText("Clockwork Novus D", charaData.IsMinionUnlocked(449));

                        ImGui.EndTable();
                    }
                    ImGui.TreePop();
                }
                if (ImGui.TreeNode("Voyages"))
                {
                    if (ImGui.BeginTable("minionsVoyage", 2))
                    {
                        SetUpTableColumns();

                        DrawTableRowText("Aurelia Polyp", charaData.IsMinionUnlocked(283));
                        DrawTableRowText("Abroader Otter", charaData.IsMinionUnlocked(329));
                        DrawTableRowText("Sharksucker-class Insubmersible", charaData.IsMinionUnlocked(348));
                        DrawTableRowText("Meerkat", charaData.IsMinionUnlocked(356));
                        DrawTableRowText("Silver Dasher", charaData.IsMinionUnlocked(371));
                        DrawTableRowText("Syldrion-class Insubmersible", charaData.IsMinionUnlocked(397));
                        DrawTableRowText("Benben Stone", charaData.IsMinionUnlocked(413));
                        DrawTableRowText("Suzusaurus", charaData.IsMinionUnlocked(469));

                        ImGui.EndTable();
                    }
                    ImGui.TreePop();
                }
                if (ImGui.TreeNode("Wondrous Tails/Faux Hollows"))
                {
                    if (ImGui.BeginTable("minionsTails", 2))
                    {
                        SetUpTableColumns();

                        DrawTableRowText("Dress-up Thancred", charaData.IsMinionUnlocked(217));
                        DrawTableRowText("Dress-up Alisaie", charaData.IsMinionUnlocked(218));
                        DrawTableRowText("Wind-up Estinien", charaData.IsMinionUnlocked(228));
                        DrawTableRowText("Wind-up Khloe", charaData.IsMinionUnlocked(260));
                        DrawTableRowText("Wind-up Hien", charaData.IsMinionUnlocked(264));
                        DrawTableRowText("Wind-up Zhloe", charaData.IsMinionUnlocked(298));
                        DrawTableRowText("Wind-up Omega-M", charaData.IsMinionUnlocked(344));
                        DrawTableRowText("Wind-up Omega-F", charaData.IsMinionUnlocked(345));
                        DrawTableRowText("Sand Fox", charaData.IsMinionUnlocked(387));
                        DrawTableRowText("Anteater", charaData.IsMinionUnlocked(409));
                        DrawTableRowText("Brave New Urianger", charaData.IsMinionUnlocked(429));
                        DrawTableRowText("Pterosquirrel", charaData.IsMinionUnlocked(462));
                        DrawTableRowText("Corgi", charaData.IsMinionUnlocked(467));

                        ImGui.EndTable();
                    }
                    ImGui.TreePop();
                }
                if (ImGui.TreeNode("Shop"))
                {
                    if (ImGui.TreeNode("Gil"))
                    {
                        if (ImGui.BeginTable("minionsGil", 2))
                        {
                            SetUpTableColumns();

                            DrawTableRowText("Wayward Hatchling", charaData.IsMinionUnlocked(3));
                            DrawTableRowText("Cherry Bomb", charaData.IsMinionUnlocked(1));
                            DrawTableRowText("Tiny Rat", charaData.IsMinionUnlocked(13));
                            DrawTableRowText("Baby Raptor", charaData.IsMinionUnlocked(25));
                            DrawTableRowText("Baby Bat", charaData.IsMinionUnlocked(26));
                            DrawTableRowText("Mammet #001", charaData.IsMinionUnlocked(2));

                            ImGui.EndTable();
                        }
                        ImGui.TreePop();
                    }
                    if (ImGui.TreeNode("MGP"))
                    {
                        if (ImGui.BeginTable("minionsSaucer", 2))
                        {
                            SetUpTableColumns();

                            DrawTableRowText("Zu Hatchling", charaData.IsMinionUnlocked(83));
                            DrawTableRowText("Heavy Hatchling", charaData.IsMinionUnlocked(106));
                            DrawTableRowText("Black Coeurl", charaData.IsMinionUnlocked(20));
                            DrawTableRowText("Water Imp", charaData.IsMinionUnlocked(117));
                            DrawTableRowText("Wind-up Nero Tol Scaeva", charaData.IsMinionUnlocked(174));
                            DrawTableRowText("Piggy", charaData.IsMinionUnlocked(187));
                            DrawTableRowText("Wind-up Daivadipa", charaData.IsMinionUnlocked(442));
                            DrawTableRowText("Mama Automaton", charaData.IsMinionUnlocked(470));

                            ImGui.EndTable();
                        }
                        ImGui.TreePop();
                    }
                    if (ImGui.TreeNode("Poetics"))
                    {
                        if (ImGui.BeginTable("minionsPoetics", 2))
                        {
                            SetUpTableColumns();

                            DrawTableRowText("Wide-eyed Fawn", charaData.IsMinionUnlocked(17));
                            DrawTableRowText("Dust Bunny", charaData.IsMinionUnlocked(28));
                            DrawTableRowText("Fledgling Dodo", charaData.IsMinionUnlocked(37));

                            ImGui.EndTable();
                        }
                        ImGui.TreePop();
                    }
                    if (ImGui.TreeNode("Hunt Currency"))
                    {
                        if (ImGui.BeginTable("minionsHunts", 2))
                        {
                            SetUpTableColumns();

                            DrawTableRowText("Wind-up Succubus", charaData.IsMinionUnlocked(82));
                            DrawTableRowText("Treasure Box", charaData.IsMinionUnlocked(93));
                            DrawTableRowText("Behemoth Heir", charaData.IsMinionUnlocked(148));
                            DrawTableRowText("Griffin Hatchling", charaData.IsMinionUnlocked(144));
                            DrawTableRowText("Tora-jiro", charaData.IsMinionUnlocked(243));
                            DrawTableRowText("Wind-up Meateater", charaData.IsMinionUnlocked(256));
                            DrawTableRowText("Bitty Duckbill", charaData.IsMinionUnlocked(340));
                            DrawTableRowText("Cute Justice", charaData.IsMinionUnlocked(358));
                            DrawTableRowText("Nagxian Cat", charaData.IsMinionUnlocked(428));
                            DrawTableRowText("Wind-up Nu Mou", charaData.IsMinionUnlocked(326));

                            ImGui.EndTable();
                        }
                        ImGui.TreePop();
                    }
                    if (ImGui.TreeNode("Grand Company"))
                    {
                        if (ImGui.BeginTable("minionsGc", 2))
                        {
                            SetUpTableColumns();

                            DrawTableRowText("Storm Hatchling", charaData.IsMinionUnlocked(9));
                            DrawTableRowText("Serpent Hatchling", charaData.IsMinionUnlocked(10));
                            DrawTableRowText("Flame Hatchling", charaData.IsMinionUnlocked(11));

                            ImGui.EndTable();
                        }
                        ImGui.TreePop();
                    }
                    if (ImGui.TreeNode("Island Sanctuary"))
                    {
                        if (ImGui.BeginTable("minionsSanctuary", 2))
                        {
                            SetUpTableColumns();

                            DrawTableRowText("Felicitous Fuzzball", charaData.IsMinionUnlocked(456));
                            DrawTableRowText("Sky Blue Back", charaData.IsMinionUnlocked(468));

                            ImGui.EndTable();
                        }
                        ImGui.TreePop();
                    }
                    if (ImGui.TreeNode("Other"))
                    {
                        if (ImGui.BeginTable("minionsOther", 2))
                        {
                            SetUpTableColumns();

                            DrawTableRowText("Wind-up Sun", charaData.IsMinionUnlocked(65));
                            DrawTableRowText("Wind-up Moon", charaData.IsMinionUnlocked(236));

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
