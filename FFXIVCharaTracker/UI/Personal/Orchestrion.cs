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
        internal void DrawOrchestrionSection(Chara charaData)
        {
            if (ImGui.TreeNode("Orchestrion Rolls"))
            {
                if (ImGui.TreeNode("Achievements"))
                {
                    if (ImGui.BeginTable("OrchestrionAchievement", 2))
                    {
                        SetUpTableColumns();

                        DrawTableRowText("Prelude – Discoveries", charaData.IsOrchestrionUnlocked(12));
                        DrawTableRowText("Ultima", charaData.IsOrchestrionUnlocked(28));
                        DrawTableRowText("Defender Of The Realm", charaData.IsOrchestrionUnlocked(75));
                        DrawTableRowText("The Seventh Sun", charaData.IsOrchestrionUnlocked(84));
                        DrawTableRowText("Prelude - Long March Home", charaData.IsOrchestrionUnlocked(201));
                        DrawTableRowText("Beyond Redemption", charaData.IsOrchestrionUnlocked(291));
                        DrawTableRowText("Doman Distractions", charaData.IsOrchestrionUnlocked(271));
                        DrawTableRowText("Shuffle Or Boogie (Shadowbringers)", charaData.IsOrchestrionUnlocked(436));

                        ImGui.EndTable();
                    }
                    ImGui.TreePop();
                }
                if (ImGui.TreeNode("Bozja"))
                {
                    if (ImGui.BeginTable("OrchestrionBozja", 2))
                    {
                        SetUpTableColumns();

                        DrawTableRowText("Wind On The Plains", charaData.IsOrchestrionUnlocked(387));
                        DrawTableRowText("Blood On The Wind", charaData.IsOrchestrionUnlocked(388));
                        DrawTableRowText("Discord: Imperial (Zodiac Age Version)", charaData.IsOrchestrionUnlocked(389));
                        DrawTableRowText("Into The Fortress (Zodiac Age Version)", charaData.IsOrchestrionUnlocked(390));
                        DrawTableRowText("Battle With An Esper (Zodiac Age Version)", charaData.IsOrchestrionUnlocked(391));
                        DrawTableRowText("Life And Death (Zodiac Age Version)", charaData.IsOrchestrionUnlocked(392));
                        DrawTableRowText("The Sochen Cave Palace (Zodiac Age Version)", charaData.IsOrchestrionUnlocked(413));
                        DrawTableRowText("Giving Chase (Zodiac Age Version)", charaData.IsOrchestrionUnlocked(414));
                        DrawTableRowText("The Queen Awakens", charaData.IsOrchestrionUnlocked(415));
                        DrawTableRowText("Wrath Of The Harrier", charaData.IsOrchestrionUnlocked(438));

                        ImGui.EndTable();
                    }
                    ImGui.TreePop();
                }
                if (ImGui.TreeNode("Crafted"))
                {
                    if (ImGui.BeginTable("OrchestrionCrafted", 2))
                    {
                        SetUpTableColumns();

                        DrawTableRowText("Hubris", charaData.IsOrchestrionUnlocked(35));
                        DrawTableRowText("Tumbling Down", charaData.IsOrchestrionUnlocked(36));
                        DrawTableRowText("The Maker's Ruin", charaData.IsOrchestrionUnlocked(29));
                        DrawTableRowText("Now I Know The Truth", charaData.IsOrchestrionUnlocked(37));
                        DrawTableRowText("Primal Judgment", charaData.IsOrchestrionUnlocked(30));
                        DrawTableRowText("Out Of The Labyrinth", charaData.IsOrchestrionUnlocked(38));
                        DrawTableRowText("Blood For Blood", charaData.IsOrchestrionUnlocked(18));
                        DrawTableRowText("Fallen Angel", charaData.IsOrchestrionUnlocked(31));
                        DrawTableRowText("Starved", charaData.IsOrchestrionUnlocked(19));
                        DrawTableRowText("Under The Weight", charaData.IsOrchestrionUnlocked(32));
                        DrawTableRowText("Blind To The Dark", charaData.IsOrchestrionUnlocked(39));
                        DrawTableRowText("Heroes", charaData.IsOrchestrionUnlocked(33));
                        DrawTableRowText("Hunger", charaData.IsOrchestrionUnlocked(40));
                        DrawTableRowText("Fiend", charaData.IsOrchestrionUnlocked(34));
                        DrawTableRowText("Eternal Wind", charaData.IsOrchestrionUnlocked(41));
                        DrawTableRowText("Thunderer", charaData.IsOrchestrionUnlocked(42));
                        DrawTableRowText("A Light In The Storm", charaData.IsOrchestrionUnlocked(23));
                        DrawTableRowText("The Only Path", charaData.IsOrchestrionUnlocked(14));
                        DrawTableRowText("The Dark's Embrace", charaData.IsOrchestrionUnlocked(22));
                        DrawTableRowText("Rise Of The White Raven", charaData.IsOrchestrionUnlocked(43));
                        DrawTableRowText("A World Apart", charaData.IsOrchestrionUnlocked(15));
                        DrawTableRowText("The Scars Of Battle", charaData.IsOrchestrionUnlocked(26));
                        DrawTableRowText("From The Ashes", charaData.IsOrchestrionUnlocked(44));
                        DrawTableRowText("Answers", charaData.IsOrchestrionUnlocked(45));
                        DrawTableRowText("Another Round", charaData.IsOrchestrionUnlocked(9));
                        DrawTableRowText("Dark Vows", charaData.IsOrchestrionUnlocked(21));
                        DrawTableRowText("Riptide", charaData.IsOrchestrionUnlocked(20));
                        DrawTableRowText("Painted Foothills", charaData.IsOrchestrionUnlocked(10));
                        DrawTableRowText("Lost In The Clouds", charaData.IsOrchestrionUnlocked(11));
                        DrawTableRowText("Imagination", charaData.IsOrchestrionUnlocked(24));
                        DrawTableRowText("Down The Up Staircase", charaData.IsOrchestrionUnlocked(25));
                        DrawTableRowText("Wreck To The Seaman", charaData.IsOrchestrionUnlocked(68));
                        DrawTableRowText("Through The Maelstrom", charaData.IsOrchestrionUnlocked(69));
                        DrawTableRowText("Good King Moggle Mog XII", charaData.IsOrchestrionUnlocked(70));
                        DrawTableRowText("Revenge Of The Horde", charaData.IsOrchestrionUnlocked(71));
                        DrawTableRowText("Battle On The Big Bridge", charaData.IsOrchestrionUnlocked(72));
                        DrawTableRowText("Engage", charaData.IsOrchestrionUnlocked(74));
                        DrawTableRowText("Against The Wind", charaData.IsOrchestrionUnlocked(54));
                        DrawTableRowText("Landlords", charaData.IsOrchestrionUnlocked(55));
                        DrawTableRowText("Missing Pages", charaData.IsOrchestrionUnlocked(56));
                        DrawTableRowText("Footsteps In The Snow", charaData.IsOrchestrionUnlocked(104));
                        DrawTableRowText("Oblivion", charaData.IsOrchestrionUnlocked(105));
                        DrawTableRowText("Thunder Rolls", charaData.IsOrchestrionUnlocked(106));
                        DrawTableRowText("Equilibrium", charaData.IsOrchestrionUnlocked(107));
                        DrawTableRowText("Close To The Heavens", charaData.IsOrchestrionUnlocked(91));
                        DrawTableRowText("The Corpse Hall", charaData.IsOrchestrionUnlocked(133));
                        DrawTableRowText("Limitless Blue", charaData.IsOrchestrionUnlocked(134));
                        DrawTableRowText("Woe That Is Madness", charaData.IsOrchestrionUnlocked(135));
                        DrawTableRowText("The Hand That Gives The Rose", charaData.IsOrchestrionUnlocked(136));
                        DrawTableRowText("Unbending Steel", charaData.IsOrchestrionUnlocked(137));
                        DrawTableRowText("Infinity", charaData.IsOrchestrionUnlocked(138));
                        DrawTableRowText("Revelation", charaData.IsOrchestrionUnlocked(157));
                        DrawTableRowText("Beauty's Wicked Wiles", charaData.IsOrchestrionUnlocked(158));
                        DrawTableRowText("Skylords", charaData.IsOrchestrionUnlocked(159));
                        DrawTableRowText("The Silent Regard Of Stars", charaData.IsOrchestrionUnlocked(160));
                        DrawTableRowText("The Worm's Head", charaData.IsOrchestrionUnlocked(184));
                        DrawTableRowText("The Worm's Tail", charaData.IsOrchestrionUnlocked(185));
                        DrawTableRowText("On High", charaData.IsOrchestrionUnlocked(176));
                        DrawTableRowText("Answer On High", charaData.IsOrchestrionUnlocked(215));
                        DrawTableRowText("Amatsu Kaze", charaData.IsOrchestrionUnlocked(216));
                        DrawTableRowText("Ambient Abyss", charaData.IsOrchestrionUnlocked(222));
                        DrawTableRowText("Nightbloom", charaData.IsOrchestrionUnlocked(240));
                        DrawTableRowText("Wayward Daughter", charaData.IsOrchestrionUnlocked(241));
                        DrawTableRowText("Black And White", charaData.IsOrchestrionUnlocked(230));
                        DrawTableRowText("Sunrise", charaData.IsOrchestrionUnlocked(252));
                        DrawTableRowText("From The Dragon's Wake", charaData.IsOrchestrionUnlocked(268));
                        DrawTableRowText("Afterglow", charaData.IsOrchestrionUnlocked(283));
                        DrawTableRowText("Harmony", charaData.IsOrchestrionUnlocked(287));
                        DrawTableRowText("What Angel Wakes Me", charaData.IsOrchestrionUnlocked(313));
                        DrawTableRowText("Insanity", charaData.IsOrchestrionUnlocked(314));
                        DrawTableRowText("Invincible", charaData.IsOrchestrionUnlocked(343));
                        DrawTableRowText("Ultima (The Primals)", charaData.IsOrchestrionUnlocked(366));
                        DrawTableRowText("To The Edge", charaData.IsOrchestrionUnlocked(386));
                        DrawTableRowText("Eternal Wind (Shadowbringers)", charaData.IsOrchestrionUnlocked(385));
                        DrawTableRowText("The Black Wolf Stalks Again", charaData.IsOrchestrionUnlocked(411));
                        DrawTableRowText("In The Arms Of War", charaData.IsOrchestrionUnlocked(437));
                        DrawTableRowText("Endcaller", charaData.IsOrchestrionUnlocked(482));
                        DrawTableRowText("Your Answer", charaData.IsOrchestrionUnlocked(483));
                        DrawTableRowText("The Final Day", charaData.IsOrchestrionUnlocked(507));
                        DrawTableRowText("With Hearts Aligned", charaData.IsOrchestrionUnlocked(508));
                        DrawTableRowText("Battle With The Four Fiends (Buried Memory)", charaData.IsOrchestrionUnlocked(536));
                        DrawTableRowText("Forged In Crimson", charaData.IsOrchestrionUnlocked(565));

                        ImGui.EndTable();
                    }
                    ImGui.TreePop();
                }
                if (ImGui.TreeNode("Deep Dungeon"))
                {
                    if (ImGui.BeginTable("OrchestrionDeep", 2))
                    {
                        SetUpTableColumns();

                        DrawTableRowText("A Light In The Storm", charaData.IsOrchestrionUnlocked(23));
                        DrawTableRowText("The Scars Of Battle", charaData.IsOrchestrionUnlocked(26));
                        DrawTableRowText("Dark Vows", charaData.IsOrchestrionUnlocked(21));
                        DrawTableRowText("Riptide", charaData.IsOrchestrionUnlocked(20));
                        DrawTableRowText("Down The Up Staircase", charaData.IsOrchestrionUnlocked(25));
                        DrawTableRowText("Horizons Calling", charaData.IsOrchestrionUnlocked(67));
                        DrawTableRowText("Ink Long Dry", charaData.IsOrchestrionUnlocked(64));
                        DrawTableRowText("Blackbosom", charaData.IsOrchestrionUnlocked(97));
                        DrawTableRowText("Fog Of Phantom", charaData.IsOrchestrionUnlocked(98));
                        DrawTableRowText("Blasphemous Experiment", charaData.IsOrchestrionUnlocked(99));
                        DrawTableRowText("Notice Of Death", charaData.IsOrchestrionUnlocked(100));
                        DrawTableRowText("Bibliophobia", charaData.IsOrchestrionUnlocked(156));
                        DrawTableRowText("Far From Home", charaData.IsOrchestrionUnlocked(183));
                        DrawTableRowText("Unbreakable (Duality)", charaData.IsOrchestrionUnlocked(211));
                        DrawTableRowText("Earth, Wind, And Water", charaData.IsOrchestrionUnlocked(229));
                        DrawTableRowText("Far East Of Eorzea", charaData.IsOrchestrionUnlocked(224));
                        DrawTableRowText("Parting Ways", charaData.IsOrchestrionUnlocked(225));
                        DrawTableRowText("A Land Long Dead", charaData.IsOrchestrionUnlocked(251));
                        DrawTableRowText("From Mud", charaData.IsOrchestrionUnlocked(250));
                        DrawTableRowText("To Fire And Sword", charaData.IsOrchestrionUnlocked(317));
                        DrawTableRowText("Figments", charaData.IsOrchestrionUnlocked(318));
                        DrawTableRowText("Unwound", charaData.IsOrchestrionUnlocked(319));
                        DrawTableRowText("Deep Down", charaData.IsOrchestrionUnlocked(320));
                        DrawTableRowText("In The Belly Of The Beast", charaData.IsOrchestrionUnlocked(321));
                        DrawTableRowText("Mortal Instants", charaData.IsOrchestrionUnlocked(322));
                        DrawTableRowText("A Long Fall", charaData.IsOrchestrionUnlocked(324));
                        DrawTableRowText("Shadows Withal", charaData.IsOrchestrionUnlocked(323));
                        DrawTableRowText("The Grand Cosmos", charaData.IsOrchestrionUnlocked(344));
                        DrawTableRowText("Where All Roads Lead", charaData.IsOrchestrionUnlocked(393));
                        DrawTableRowText("Freshly Glazed Porxie", charaData.IsOrchestrionUnlocked(416));
                        DrawTableRowText("Tower Of Zot (Endwalker)", charaData.IsOrchestrionUnlocked(475));
                        DrawTableRowText("Garlemald Express", charaData.IsOrchestrionUnlocked(476));
                        DrawTableRowText("As The Sky Burns", charaData.IsOrchestrionUnlocked(477));
                        DrawTableRowText("Miracle Works", charaData.IsOrchestrionUnlocked(478));
                        DrawTableRowText("The Aetherial Sea", charaData.IsOrchestrionUnlocked(479));
                        DrawTableRowText("Of Countless Stars", charaData.IsOrchestrionUnlocked(480));
                        DrawTableRowText("Carrots Of Happiness", charaData.IsOrchestrionUnlocked(481));
                        DrawTableRowText("The Map Unfolds", charaData.IsOrchestrionUnlocked(506));
                        DrawTableRowText("Troian Beauty (Endwalker)", charaData.IsOrchestrionUnlocked(537));
                        DrawTableRowText("Forbidden Land (Endwalker)", charaData.IsOrchestrionUnlocked(568));
                        DrawTableRowText("The Promise Of Plunder", charaData.IsOrchestrionUnlocked(583));
                        DrawTableRowText("Crystal Rain", charaData.IsOrchestrionUnlocked(584));

                        ImGui.EndTable();
                    }
                    ImGui.TreePop();
                }
                if (ImGui.TreeNode("Dungeon"))
                {
                    if (ImGui.BeginTable("OrchestrionDungeon", 2))
                    {
                        SetUpTableColumns();

                        DrawTableRowText("Horizons Calling", charaData.IsOrchestrionUnlocked(67));
                        DrawTableRowText("The Warrens", charaData.IsOrchestrionUnlocked(62));
                        DrawTableRowText("Ink Long Dry", charaData.IsOrchestrionUnlocked(64));
                        DrawTableRowText("Unbreakable", charaData.IsOrchestrionUnlocked(65));
                        DrawTableRowText("Apologies", charaData.IsOrchestrionUnlocked(66));
                        DrawTableRowText("Silver Tears", charaData.IsOrchestrionUnlocked(102));
                        DrawTableRowText("Slumber Eternal", charaData.IsOrchestrionUnlocked(101));
                        DrawTableRowText("Hallowed Halls", charaData.IsOrchestrionUnlocked(130));
                        DrawTableRowText("Poison Ivy", charaData.IsOrchestrionUnlocked(155));
                        DrawTableRowText("Bibliophobia", charaData.IsOrchestrionUnlocked(156));
                        DrawTableRowText("The Open Box", charaData.IsOrchestrionUnlocked(180));
                        DrawTableRowText("Most Unworthy", charaData.IsOrchestrionUnlocked(181));
                        DrawTableRowText("Deception", charaData.IsOrchestrionUnlocked(182));
                        DrawTableRowText("Far From Home", charaData.IsOrchestrionUnlocked(183));
                        DrawTableRowText("Liberty Or Death", charaData.IsOrchestrionUnlocked(213));
                        DrawTableRowText("Their Deadly Mission", charaData.IsOrchestrionUnlocked(212));
                        DrawTableRowText("Down Where Daemons Dwell", charaData.IsOrchestrionUnlocked(210));
                        DrawTableRowText("Unbreakable (Duality)", charaData.IsOrchestrionUnlocked(211));
                        DrawTableRowText("The Ancient City", charaData.IsOrchestrionUnlocked(227));
                        DrawTableRowText("Gates Of The Moon", charaData.IsOrchestrionUnlocked(228));
                        DrawTableRowText("Earth, Wind, And Water", charaData.IsOrchestrionUnlocked(229));
                        DrawTableRowText("Beneath Bloodied Banners", charaData.IsOrchestrionUnlocked(249));
                        DrawTableRowText("Tricksome", charaData.IsOrchestrionUnlocked(248));
                        DrawTableRowText("Upon The Rocks", charaData.IsOrchestrionUnlocked(247));
                        DrawTableRowText("A Land Long Dead", charaData.IsOrchestrionUnlocked(251));
                        DrawTableRowText("From Mud", charaData.IsOrchestrionUnlocked(250));
                        DrawTableRowText("A Pall Most Murderous", charaData.IsOrchestrionUnlocked(269));
                        DrawTableRowText("To Fire And Sword", charaData.IsOrchestrionUnlocked(317));
                        DrawTableRowText("Figments", charaData.IsOrchestrionUnlocked(318));
                        DrawTableRowText("Unwound", charaData.IsOrchestrionUnlocked(319));
                        DrawTableRowText("Deep Down", charaData.IsOrchestrionUnlocked(320));
                        DrawTableRowText("In The Belly Of The Beast", charaData.IsOrchestrionUnlocked(321));
                        DrawTableRowText("Mortal Instants", charaData.IsOrchestrionUnlocked(322));
                        DrawTableRowText("A Long Fall", charaData.IsOrchestrionUnlocked(324));
                        DrawTableRowText("Shadows Withal", charaData.IsOrchestrionUnlocked(323));
                        DrawTableRowText("Fury", charaData.IsOrchestrionUnlocked(326));
                        DrawTableRowText("Alienus", charaData.IsOrchestrionUnlocked(325));
                        DrawTableRowText("The Grand Cosmos", charaData.IsOrchestrionUnlocked(344));
                        DrawTableRowText("The Maiden's Lament", charaData.IsOrchestrionUnlocked(368));
                        DrawTableRowText("The Darkhold", charaData.IsOrchestrionUnlocked(369));
                        DrawTableRowText("Floundering In The Depths", charaData.IsOrchestrionUnlocked(370));
                        DrawTableRowText("Abomination", charaData.IsOrchestrionUnlocked(396));
                        DrawTableRowText("A Tonberry's Tears", charaData.IsOrchestrionUnlocked(395));
                        DrawTableRowText("Where All Roads Lead", charaData.IsOrchestrionUnlocked(393));
                        DrawTableRowText("Below", charaData.IsOrchestrionUnlocked(431));
                        DrawTableRowText("The Ludus", charaData.IsOrchestrionUnlocked(426));
                        DrawTableRowText("Freshly Glazed Porxie", charaData.IsOrchestrionUnlocked(416));
                        DrawTableRowText("Dancing Calcabrina", charaData.IsOrchestrionUnlocked(432));
                        DrawTableRowText("Seven Flames", charaData.IsOrchestrionUnlocked(439));
                        DrawTableRowText("From The Depths", charaData.IsOrchestrionUnlocked(502));
                        DrawTableRowText("Tower Of Zot (Endwalker)", charaData.IsOrchestrionUnlocked(475));
                        DrawTableRowText("Garlemald Express", charaData.IsOrchestrionUnlocked(476));
                        DrawTableRowText("As The Sky Burns", charaData.IsOrchestrionUnlocked(477));
                        DrawTableRowText("Miracle Works", charaData.IsOrchestrionUnlocked(478));
                        DrawTableRowText("The Aetherial Sea", charaData.IsOrchestrionUnlocked(479));
                        DrawTableRowText("Of Countless Stars", charaData.IsOrchestrionUnlocked(480));
                        DrawTableRowText("Carrots Of Happiness", charaData.IsOrchestrionUnlocked(481));
                        DrawTableRowText("Roar Of The Wyrm", charaData.IsOrchestrionUnlocked(501));
                        DrawTableRowText("Dawnbound", charaData.IsOrchestrionUnlocked(500));
                        DrawTableRowText("The Map Unfolds", charaData.IsOrchestrionUnlocked(506));
                        DrawTableRowText("Aftermath", charaData.IsOrchestrionUnlocked(530));
                        DrawTableRowText("Descent", charaData.IsOrchestrionUnlocked(529));
                        DrawTableRowText("Like A Summer Rain", charaData.IsOrchestrionUnlocked(528));
                        DrawTableRowText("A Thousand Screams", charaData.IsOrchestrionUnlocked(559));
                        DrawTableRowText("Lipflaps On Longstops", charaData.IsOrchestrionUnlocked(560));
                        DrawTableRowText("Troian Beauty (Endwalker)", charaData.IsOrchestrionUnlocked(537));
                        DrawTableRowText("FINAL FANTASY IV: Battle 2 (Endwalker)", charaData.IsOrchestrionUnlocked(538));
                        DrawTableRowText("Toll Of The Bells", charaData.IsOrchestrionUnlocked(555));
                        DrawTableRowText("Stigma", charaData.IsOrchestrionUnlocked(556));
                        DrawTableRowText("Deep Blue", charaData.IsOrchestrionUnlocked(567));
                        DrawTableRowText("Echoes Of Ages Past", charaData.IsOrchestrionUnlocked(575));
                        DrawTableRowText("Cold Salvation", charaData.IsOrchestrionUnlocked(576));
                        DrawTableRowText("Miser's Folly", charaData.IsOrchestrionUnlocked(577));
                        DrawTableRowText("Cracks In The Wall", charaData.IsOrchestrionUnlocked(574));
                        DrawTableRowText("Forgotten By The Sun", charaData.IsOrchestrionUnlocked(578));
                        DrawTableRowText("Holy Consult", charaData.IsOrchestrionUnlocked(579));

                        ImGui.EndTable();
                    }
                    ImGui.TreePop();
                }
                if (ImGui.TreeNode("Eureka"))
                {
                    if (ImGui.BeginTable("OrchestrionEureka", 2))
                    {
                        SetUpTableColumns();

                        DrawTableRowText("Wicked Winds Whisper", charaData.IsOrchestrionUnlocked(208));
                        DrawTableRowText("No Quarter", charaData.IsOrchestrionUnlocked(209));
                        DrawTableRowText("Gates Of Paradise - The Garden Of Ru'Hmet", charaData.IsOrchestrionUnlocked(288));
                        DrawTableRowText("Onslaught", charaData.IsOrchestrionUnlocked(289));
                        DrawTableRowText("Turmoil", charaData.IsOrchestrionUnlocked(290));

                        ImGui.EndTable();
                    }
                    ImGui.TreePop();
                }
                if (ImGui.TreeNode("FATE"))
                {
                    if (ImGui.BeginTable("OrchestrionFate", 2))
                    {
                        SetUpTableColumns();

                        DrawTableRowText("Fleeting Rays", charaData.IsOrchestrionUnlocked(120));
                        DrawTableRowText("Beyond The Wall", charaData.IsOrchestrionUnlocked(161));
                        DrawTableRowText("Liquid Flame", charaData.IsOrchestrionUnlocked(162));
                        DrawTableRowText("The Dark Which Illuminates The World", charaData.IsOrchestrionUnlocked(331));
                        DrawTableRowText("Indulgence", charaData.IsOrchestrionUnlocked(332));
                        DrawTableRowText("The Source", charaData.IsOrchestrionUnlocked(307));
                        DrawTableRowText("A World Divided", charaData.IsOrchestrionUnlocked(308));
                        DrawTableRowText("Sands Of Amber", charaData.IsOrchestrionUnlocked(309));
                        DrawTableRowText("Fierce And Free", charaData.IsOrchestrionUnlocked(310));
                        DrawTableRowText("Civilizations", charaData.IsOrchestrionUnlocked(311));
                        DrawTableRowText("Full Fathom Five", charaData.IsOrchestrionUnlocked(312));
                        DrawTableRowText("Knowledge Never Sleeps", charaData.IsOrchestrionUnlocked(334));
                        DrawTableRowText("Masquerade", charaData.IsOrchestrionUnlocked(335));
                        DrawTableRowText("Unchanging, Everchanging", charaData.IsOrchestrionUnlocked(336));
                        DrawTableRowText("The Quick Way", charaData.IsOrchestrionUnlocked(337));
                        DrawTableRowText("Sands Of Blood", charaData.IsOrchestrionUnlocked(338));
                        DrawTableRowText("The Faerie Ring", charaData.IsOrchestrionUnlocked(339));
                        DrawTableRowText("A Hopeless Race", charaData.IsOrchestrionUnlocked(340));
                        DrawTableRowText("Neath Dark Waters", charaData.IsOrchestrionUnlocked(341));
                        DrawTableRowText("A Reason To Live", charaData.IsOrchestrionUnlocked(379));
                        DrawTableRowText("No Greater Sorrow", charaData.IsOrchestrionUnlocked(380));
                        DrawTableRowText("Bedlam's Brink", charaData.IsOrchestrionUnlocked(378));
                        DrawTableRowText("The Ewer Brimmeth", charaData.IsOrchestrionUnlocked(487));
                        DrawTableRowText("Twilit Terraces", charaData.IsOrchestrionUnlocked(488));
                        DrawTableRowText("The Labyrinth", charaData.IsOrchestrionUnlocked(489));
                        DrawTableRowText("Divine Words", charaData.IsOrchestrionUnlocked(490));
                        DrawTableRowText("White Snow, Black Steel", charaData.IsOrchestrionUnlocked(491));
                        DrawTableRowText("One Small Step", charaData.IsOrchestrionUnlocked(492));
                        DrawTableRowText("Sky Unsundered", charaData.IsOrchestrionUnlocked(493));
                        DrawTableRowText("Close In The Distance", charaData.IsOrchestrionUnlocked(494));
                        DrawTableRowText("The Nautilus Knoweth", charaData.IsOrchestrionUnlocked(515));
                        DrawTableRowText("The Day Will Come (Endwalker)", charaData.IsOrchestrionUnlocked(516));
                        DrawTableRowText("Vibrant Voices", charaData.IsOrchestrionUnlocked(517));
                        DrawTableRowText("Perfumed Eves", charaData.IsOrchestrionUnlocked(518));
                        DrawTableRowText("Dreams Of Man", charaData.IsOrchestrionUnlocked(519));
                        DrawTableRowText("Prayers Repeated", charaData.IsOrchestrionUnlocked(520));
                        DrawTableRowText("Black Steel, Cold Embers", charaData.IsOrchestrionUnlocked(521));
                        DrawTableRowText("Stars Long Dead", charaData.IsOrchestrionUnlocked(523));
                        DrawTableRowText("Welcome To Our Town! (Endwalker)", charaData.IsOrchestrionUnlocked(524));
                        DrawTableRowText("Home Beyond The Horizon", charaData.IsOrchestrionUnlocked(522));
                        DrawTableRowText("The Emperor's Wont", charaData.IsOrchestrionUnlocked(557));
                        DrawTableRowText("Penitus", charaData.IsOrchestrionUnlocked(558));

                        ImGui.EndTable();
                    }
                    ImGui.TreePop();
                }
                if (ImGui.TreeNode("Gathering"))
                {
                    if (ImGui.BeginTable("OrchestrionGather", 2))
                    {
                        SetUpTableColumns();

                        DrawTableRowText("Songs Of Salt And Suffering", charaData.IsOrchestrionUnlocked(177));
                        DrawTableRowText("Hope Forgotten", charaData.IsOrchestrionUnlocked(284));
                        DrawTableRowText("The Stone Remembers", charaData.IsOrchestrionUnlocked(285));
                        DrawTableRowText("Old Wounds", charaData.IsOrchestrionUnlocked(286));
                        DrawTableRowText("Freedom", charaData.IsOrchestrionUnlocked(443));

                        ImGui.EndTable();
                    }
                    ImGui.TreePop();
                }
                if (ImGui.TreeNode("Gold Saucer"))
                {
                    if (ImGui.BeginTable("OrchestrionSaucer", 2))
                    {
                        SetUpTableColumns();

                        DrawTableRowText("Torn From The Heavens", charaData.IsOrchestrionUnlocked(27));
                        DrawTableRowText("Agent Of Inquiry", charaData.IsOrchestrionUnlocked(13));
                        DrawTableRowText("Sport Of Kings", charaData.IsOrchestrionUnlocked(8));
                        DrawTableRowText("Four-sided Circle", charaData.IsOrchestrionUnlocked(7));
                        DrawTableRowText("A Cold Wind", charaData.IsOrchestrionUnlocked(1));
                        DrawTableRowText("Battle To The Death - Heavensward", charaData.IsOrchestrionUnlocked(73));
                        DrawTableRowText("Battle Theme 1.x", charaData.IsOrchestrionUnlocked(96));
                        DrawTableRowText("Spiral", charaData.IsOrchestrionUnlocked(140));
                        DrawTableRowText("Tempest", charaData.IsOrchestrionUnlocked(139));
                        DrawTableRowText("Daring Dalliances", charaData.IsOrchestrionUnlocked(200));
                        DrawTableRowText("Revenge Twofold", charaData.IsOrchestrionUnlocked(217));
                        DrawTableRowText("Triumph", charaData.IsOrchestrionUnlocked(214));
                        DrawTableRowText("Game Theory", charaData.IsOrchestrionUnlocked(270));
                        DrawTableRowText("Rise Of Heroes (Chiptune Version)", charaData.IsOrchestrionUnlocked(276));
                        DrawTableRowText("Vamo' Alla Flamenco (Shadowbringers)", charaData.IsOrchestrionUnlocked(373));
                        DrawTableRowText("A Fine Death", charaData.IsOrchestrionUnlocked(430));
                        DrawTableRowText("Gateway To Paradise", charaData.IsOrchestrionUnlocked(531));
                        DrawTableRowText("Shuffle Or Boogie", charaData.IsOrchestrionUnlocked(561));

                        ImGui.EndTable();
                    }
                    ImGui.TreePop();
                }
                if (ImGui.TreeNode("Hunts"))
                {
                    if (ImGui.BeginTable("OrchestrionHunt", 2))
                    {
                        SetUpTableColumns();

                        DrawTableRowText("Thicker Than A Knife's Blade", charaData.IsOrchestrionUnlocked(122));
                        DrawTableRowText("Drowning In The Horizon", charaData.IsOrchestrionUnlocked(163));
                        DrawTableRowText("Rencounter", charaData.IsOrchestrionUnlocked(329));
                        DrawTableRowText("Nail Of The Heavens", charaData.IsOrchestrionUnlocked(360));
                        DrawTableRowText("Imperium", charaData.IsOrchestrionUnlocked(361));
                        DrawTableRowText("Gogo's Theme", charaData.IsOrchestrionUnlocked(412));
                        DrawTableRowText("Unbowed", charaData.IsOrchestrionUnlocked(495));

                        ImGui.EndTable();
                    }
                    ImGui.TreePop();
                }
                if (ImGui.TreeNode("Island Sanctuary"))
                {
                    if (ImGui.BeginTable("OrchestrionSanctuary", 2))
                    {
                        SetUpTableColumns();

                        DrawTableRowText("A Quiet Moment", charaData.IsOrchestrionUnlocked(544));
                        DrawTableRowText("Island Paradise", charaData.IsOrchestrionUnlocked(545));

                        ImGui.EndTable();
                    }
                    ImGui.TreePop();
                }
                if (ImGui.TreeNode("Other"))
                {
                    if (ImGui.BeginTable("OrchestrionOther", 2))
                    {
                        SetUpTableColumns();

                        DrawTableRowText("Tenacity", charaData.IsOrchestrionUnlocked(17));
                        DrawTableRowText("When A Tree Falls", charaData.IsOrchestrionUnlocked(47));

                        ImGui.EndTable();
                    }
                    ImGui.TreePop();
                }
                if (ImGui.TreeNode("Mog Station"))
                {
                    if (ImGui.BeginTable("OrchestrionMog", 2))
                    {
                        SetUpTableColumns();

                        DrawTableRowText("Pa-Paya", charaData.IsOrchestrionUnlocked(16));
                        DrawTableRowText("Moonfire Faire", charaData.IsOrchestrionUnlocked(60));
                        DrawTableRowText("Heavensward", charaData.IsOrchestrionUnlocked(61));
                        DrawTableRowText("All Saints' Wake", charaData.IsOrchestrionUnlocked(80));
                        DrawTableRowText("Up At Dawn", charaData.IsOrchestrionUnlocked(81));
                        DrawTableRowText("Starlight Celebration", charaData.IsOrchestrionUnlocked(82));
                        DrawTableRowText("Heavensturn", charaData.IsOrchestrionUnlocked(83));
                        DrawTableRowText("Borderless (Duality)", charaData.IsOrchestrionUnlocked(114));
                        DrawTableRowText("Unbending Steel (Duality)", charaData.IsOrchestrionUnlocked(115));
                        DrawTableRowText("The Kiss", charaData.IsOrchestrionUnlocked(116));
                        DrawTableRowText("Hyper Rainbow Z", charaData.IsOrchestrionUnlocked(148));
                        DrawTableRowText("Answers - Reprise", charaData.IsOrchestrionUnlocked(149));
                        DrawTableRowText("Stormblood", charaData.IsOrchestrionUnlocked(150));
                        DrawTableRowText("Ultima (Orchestral Version)", charaData.IsOrchestrionUnlocked(191));
                        DrawTableRowText("Heroes (Orchestral Version)", charaData.IsOrchestrionUnlocked(192));
                        DrawTableRowText("Starlit Gateway", charaData.IsOrchestrionUnlocked(193));
                        DrawTableRowText("Siren Song", charaData.IsOrchestrionUnlocked(220));
                        DrawTableRowText("Rise Of The White Raven (Orchestral Version)", charaData.IsOrchestrionUnlocked(242));
                        DrawTableRowText("Revenge Twofold (Orchestral Version)", charaData.IsOrchestrionUnlocked(243));
                        DrawTableRowText("Oblivion (Orchestral Version)", charaData.IsOrchestrionUnlocked(244));
                        DrawTableRowText("Revolutions", charaData.IsOrchestrionUnlocked(226));
                        DrawTableRowText("Starlight, Starbright", charaData.IsOrchestrionUnlocked(245));
                        DrawTableRowText("Serenity (Orchestral Version)", charaData.IsOrchestrionUnlocked(272));
                        DrawTableRowText("Calamity Unbound (Orchestral Version)", charaData.IsOrchestrionUnlocked(273));
                        DrawTableRowText("Ominous Prognisticks (Orchestral Version)", charaData.IsOrchestrionUnlocked(274));
                        DrawTableRowText("Wayward Daughter (Chiptune Version)", charaData.IsOrchestrionUnlocked(277));
                        DrawTableRowText("The Worm's Tail (Chiptune Version)", charaData.IsOrchestrionUnlocked(278));
                        DrawTableRowText("Rise (The Primals)", charaData.IsOrchestrionUnlocked(279));
                        DrawTableRowText("Oblivion (GUNN Vocals)", charaData.IsOrchestrionUnlocked(280));
                        DrawTableRowText("Painted Foothills (Orchestral Version)", charaData.IsOrchestrionUnlocked(281));
                        DrawTableRowText("Moebius (Orchestral Version)", charaData.IsOrchestrionUnlocked(282));
                        DrawTableRowText("The Worm's Tail (Journeys Version)", charaData.IsOrchestrionUnlocked(305));
                        DrawTableRowText("EScape (Journeys Version)", charaData.IsOrchestrionUnlocked(306));
                        DrawTableRowText("Starlight De Chocobo", charaData.IsOrchestrionUnlocked(348));
                        DrawTableRowText("Tsukuyomi's Pain (Orchestral Version)", charaData.IsOrchestrionUnlocked(358));
                        DrawTableRowText("The Worm's Tail (Orchestral Version)", charaData.IsOrchestrionUnlocked(359));
                        DrawTableRowText("A New Hope (Piano Collections)", charaData.IsOrchestrionUnlocked(407));
                        DrawTableRowText("Wailers And Waterwheels (Piano Collections)", charaData.IsOrchestrionUnlocked(408));
                        DrawTableRowText("I Am The Sea (Piano Collections)", charaData.IsOrchestrionUnlocked(409));
                        DrawTableRowText("Neath Dark Waters (Scions & Sinners)", charaData.IsOrchestrionUnlocked(405));
                        DrawTableRowText("A Long Fall (Scions & Sinners: Band)", charaData.IsOrchestrionUnlocked(406));
                        DrawTableRowText("Ominous Prognisticks (Piano Collections)", charaData.IsOrchestrionUnlocked(433));
                        DrawTableRowText("Night In The Brume (Piano Collections)", charaData.IsOrchestrionUnlocked(434));
                        DrawTableRowText("Painted Foothills (Piano Collections)", charaData.IsOrchestrionUnlocked(435));
                        DrawTableRowText("On Westerly Winds (Piano Collections)", charaData.IsOrchestrionUnlocked(445));
                        DrawTableRowText("Serenity (Piano Collections)", charaData.IsOrchestrionUnlocked(446));
                        DrawTableRowText("To The Sun (Piano Collections)", charaData.IsOrchestrionUnlocked(447));
                        DrawTableRowText("Invincible (Scions & Sinners: Piano)", charaData.IsOrchestrionUnlocked(448));
                        DrawTableRowText("Tomorrow And Tomorrow (Scions & Sinners: Amanda Achen Vocals)", charaData.IsOrchestrionUnlocked(449));
                        DrawTableRowText("Return To Oblivion (Scions & Sinners: Amanda Achen Vocals)", charaData.IsOrchestrionUnlocked(450));
                        DrawTableRowText("What Angel Wakes Me (Scions & Sinners: Amanda Achen Vocals)", charaData.IsOrchestrionUnlocked(451));
                        DrawTableRowText("A Long Fall (Scions & Sinners: Piano)", charaData.IsOrchestrionUnlocked(452));
                        DrawTableRowText("Equilibrium (Scions & Sinners: Band)", charaData.IsOrchestrionUnlocked(453));
                        DrawTableRowText("What Angel Wakes Me (Scions & Sinners: Band)", charaData.IsOrchestrionUnlocked(454));
                        DrawTableRowText("Shadowbringers (Scions & Sinners: Band)", charaData.IsOrchestrionUnlocked(455));
                        DrawTableRowText("Blinding Indigo (Scions & Sinners: Band)", charaData.IsOrchestrionUnlocked(456));
                        DrawTableRowText("Insatiable (Scions & Sinners: Band)", charaData.IsOrchestrionUnlocked(457));
                        DrawTableRowText("Rise (Pulse)", charaData.IsOrchestrionUnlocked(458));
                        DrawTableRowText("Through The Maelstrom (Pulse)", charaData.IsOrchestrionUnlocked(459));
                        DrawTableRowText("Neath Dark Waters (Pulse)", charaData.IsOrchestrionUnlocked(460));
                        DrawTableRowText("What Angel Wakes Me (Pulse)", charaData.IsOrchestrionUnlocked(461));
                        DrawTableRowText("Sunrise (Pulse)", charaData.IsOrchestrionUnlocked(462));
                        DrawTableRowText("Ink Long Dry (Piano Collections)", charaData.IsOrchestrionUnlocked(503));
                        DrawTableRowText("Heroes (Piano Collections)", charaData.IsOrchestrionUnlocked(504));
                        DrawTableRowText("Old Wounds (Piano Collections)", charaData.IsOrchestrionUnlocked(505));
                        DrawTableRowText("Westward Tide (Piano Collections)", charaData.IsOrchestrionUnlocked(533));
                        DrawTableRowText("Imagination (Piano Collections)", charaData.IsOrchestrionUnlocked(534));
                        DrawTableRowText("Crimson Sunset (Piano Collections)", charaData.IsOrchestrionUnlocked(535));
                        DrawTableRowText("Close In The Distance (Beyond The Shadow)", charaData.IsOrchestrionUnlocked(562));
                        DrawTableRowText("Hic Svnt Leones (Beyond The Shadow)", charaData.IsOrchestrionUnlocked(563));
                        DrawTableRowText("To The Edge (Orchestral Version)", charaData.IsOrchestrionUnlocked(588));
                        DrawTableRowText("Flow (Orchestral Version)", charaData.IsOrchestrionUnlocked(589));

                        ImGui.EndTable();
                    }
                    ImGui.TreePop();
                }
                if (ImGui.TreeNode("Shop"))
                {
                    if (ImGui.BeginTable("OrchestrionShop", 2))
                    {
                        SetUpTableColumns();

                        DrawTableRowText("Wailers And Waterwheels", charaData.IsOrchestrionUnlocked(2));
                        DrawTableRowText("I Am The Sea", charaData.IsOrchestrionUnlocked(3));
                        DrawTableRowText("A New Hope", charaData.IsOrchestrionUnlocked(4));
                        DrawTableRowText("The Waking Sands", charaData.IsOrchestrionUnlocked(6));
                        DrawTableRowText("Contention", charaData.IsOrchestrionUnlocked(46));
                        DrawTableRowText("Solid", charaData.IsOrchestrionUnlocked(5));
                        DrawTableRowText("A Sailor Never Sleeps", charaData.IsOrchestrionUnlocked(49));
                        DrawTableRowText("Dance Of The Fireflies", charaData.IsOrchestrionUnlocked(50));
                        DrawTableRowText("Sultana Dreaming", charaData.IsOrchestrionUnlocked(48));
                        DrawTableRowText("On Westerly Winds", charaData.IsOrchestrionUnlocked(58));
                        DrawTableRowText("Serenity", charaData.IsOrchestrionUnlocked(59));
                        DrawTableRowText("To The Sun", charaData.IsOrchestrionUnlocked(57));
                        DrawTableRowText("Nobility Obliges", charaData.IsOrchestrionUnlocked(51));
                        DrawTableRowText("The Mushroomery", charaData.IsOrchestrionUnlocked(52));
                        DrawTableRowText("Shelter", charaData.IsOrchestrionUnlocked(53));
                        DrawTableRowText("Ominous Prognisticks", charaData.IsOrchestrionUnlocked(63));
                        DrawTableRowText("Behind Closed Doors", charaData.IsOrchestrionUnlocked(89));
                        DrawTableRowText("Where The Heart Is", charaData.IsOrchestrionUnlocked(93));
                        DrawTableRowText("Reflections", charaData.IsOrchestrionUnlocked(90));
                        DrawTableRowText("Nobility Sleeps", charaData.IsOrchestrionUnlocked(87));
                        DrawTableRowText("Night In The Brume", charaData.IsOrchestrionUnlocked(88));
                        DrawTableRowText("Homestead", charaData.IsOrchestrionUnlocked(94));
                        DrawTableRowText("Canticle", charaData.IsOrchestrionUnlocked(127));
                        DrawTableRowText("Aetherosphere", charaData.IsOrchestrionUnlocked(142));
                        DrawTableRowText("Six Fulms Under", charaData.IsOrchestrionUnlocked(143));
                        DrawTableRowText("Teardrops In The Rain", charaData.IsOrchestrionUnlocked(144));
                        DrawTableRowText("A Thousand Faces", charaData.IsOrchestrionUnlocked(145));
                        DrawTableRowText("Frontiers Within", charaData.IsOrchestrionUnlocked(119));
                        DrawTableRowText("Saltswept", charaData.IsOrchestrionUnlocked(121));
                        DrawTableRowText("Ambient Birdsong", charaData.IsOrchestrionUnlocked(152));
                        DrawTableRowText("Ambient Waves", charaData.IsOrchestrionUnlocked(151));
                        DrawTableRowText("Ambient Rainfall", charaData.IsOrchestrionUnlocked(153));
                        DrawTableRowText("Ambient Cricketsong", charaData.IsOrchestrionUnlocked(154));
                        DrawTableRowText("The Edge", charaData.IsOrchestrionUnlocked(164));
                        DrawTableRowText("Ambient Insects", charaData.IsOrchestrionUnlocked(168));
                        DrawTableRowText("Ambient Bonfire", charaData.IsOrchestrionUnlocked(169));
                        DrawTableRowText("Ambient Kitchen", charaData.IsOrchestrionUnlocked(170));
                        DrawTableRowText("Impact", charaData.IsOrchestrionUnlocked(174));
                        DrawTableRowText("Babbling Brook", charaData.IsOrchestrionUnlocked(194));
                        DrawTableRowText("Bustling Boulevard", charaData.IsOrchestrionUnlocked(195));
                        DrawTableRowText("Temple Bell", charaData.IsOrchestrionUnlocked(196));
                        DrawTableRowText("Chapel Bell", charaData.IsOrchestrionUnlocked(197));
                        DrawTableRowText("Fragments Of Forever", charaData.IsOrchestrionUnlocked(219));
                        DrawTableRowText("Westward Tide", charaData.IsOrchestrionUnlocked(204));
                        DrawTableRowText("He Rises Above", charaData.IsOrchestrionUnlocked(206));
                        DrawTableRowText("Ambient Wind Chime", charaData.IsOrchestrionUnlocked(221));
                        DrawTableRowText("Victory Or Death", charaData.IsOrchestrionUnlocked(223));
                        DrawTableRowText("Cradle", charaData.IsOrchestrionUnlocked(246));
                        DrawTableRowText("Starlight And Sellswords", charaData.IsOrchestrionUnlocked(532));
                        DrawTableRowText("Born To Ride", charaData.IsOrchestrionUnlocked(547));
                        DrawTableRowText("Dewdrops & Moonbeams", charaData.IsOrchestrionUnlocked(551));
                        DrawTableRowText("Ripples In The Sea", charaData.IsOrchestrionUnlocked(552));
                        DrawTableRowText("The Sands' Secrets", charaData.IsOrchestrionUnlocked(553));
                        DrawTableRowText("Silence", charaData.IsOrchestrionUnlocked(564));
                        DrawTableRowText("Into The Adder's Den", charaData.IsOrchestrionUnlocked(548));
                        DrawTableRowText("Maelstrom Command", charaData.IsOrchestrionUnlocked(549));
                        DrawTableRowText("The Hall Of Flames", charaData.IsOrchestrionUnlocked(550));
                        DrawTableRowText("Bliss", charaData.IsOrchestrionUnlocked(585));
                        DrawTableRowText("Sacred Bonds", charaData.IsOrchestrionUnlocked(586));

                        ImGui.EndTable();
                    }
                    ImGui.TreePop();
                }
                if (ImGui.TreeNode("PvP"))
                {
                    if (ImGui.BeginTable("OrchestrionPvP", 2))
                    {
                        SetUpTableColumns();

                        DrawTableRowText("Birds Of Prey", charaData.IsOrchestrionUnlocked(171));
                        DrawTableRowText("Rival Wings", charaData.IsOrchestrionUnlocked(202));
                        DrawTableRowText("A Fierce Air Forceth", charaData.IsOrchestrionUnlocked(346));
                        DrawTableRowText("A Fine Air Forbiddeth", charaData.IsOrchestrionUnlocked(347));
                        DrawTableRowText("Warming Up", charaData.IsOrchestrionUnlocked(525));
                        DrawTableRowText("Festival Of The Hunt (Endwalker)", charaData.IsOrchestrionUnlocked(526));
                        DrawTableRowText("Run! (Endwalker)", charaData.IsOrchestrionUnlocked(527));

                        ImGui.EndTable();
                    }
                    ImGui.TreePop();
                }
                if (ImGui.TreeNode("Quests"))
                {
                    if (ImGui.BeginTable("OrchestrionSidequest", 2))
                    {
                        SetUpTableColumns();

                        DrawTableRowText("Dragonsong", charaData.IsOrchestrionUnlocked(79));
                        DrawTableRowText("Sins Of The Father, Sins Of The Son", charaData.IsOrchestrionUnlocked(108));
                        DrawTableRowText("Locus", charaData.IsOrchestrionUnlocked(109));
                        DrawTableRowText("Metal", charaData.IsOrchestrionUnlocked(110));
                        DrawTableRowText("Metal - Brute Justice Mode", charaData.IsOrchestrionUnlocked(111));
                        DrawTableRowText("Exponential Entropy", charaData.IsOrchestrionUnlocked(112));
                        DrawTableRowText("Rise", charaData.IsOrchestrionUnlocked(113));
                        DrawTableRowText("Grounded", charaData.IsOrchestrionUnlocked(103));
                        DrawTableRowText("Forever Lost", charaData.IsOrchestrionUnlocked(128));
                        DrawTableRowText("Promises", charaData.IsOrchestrionUnlocked(146));
                        DrawTableRowText("Shadow Of The Body", charaData.IsOrchestrionUnlocked(147));
                        DrawTableRowText("Another Brick", charaData.IsOrchestrionUnlocked(132));
                        DrawTableRowText("Quicksand", charaData.IsOrchestrionUnlocked(131));
                        DrawTableRowText("Steel Reason", charaData.IsOrchestrionUnlocked(126));
                        DrawTableRowText("Imperial Will", charaData.IsOrchestrionUnlocked(125));
                        DrawTableRowText("He Who Continues The Attack", charaData.IsOrchestrionUnlocked(124));
                        DrawTableRowText("The Measure Of His Reach", charaData.IsOrchestrionUnlocked(172));
                        DrawTableRowText("The Measure Of Our Reach", charaData.IsOrchestrionUnlocked(173));
                        DrawTableRowText("Protagonist's Theme", charaData.IsOrchestrionUnlocked(189));
                        DrawTableRowText("Background Story", charaData.IsOrchestrionUnlocked(190));
                        DrawTableRowText("Cyan's Theme", charaData.IsOrchestrionUnlocked(198));
                        DrawTableRowText("Iroha", charaData.IsOrchestrionUnlocked(199));
                        DrawTableRowText("World Map", charaData.IsOrchestrionUnlocked(232));
                        DrawTableRowText("A Chapel", charaData.IsOrchestrionUnlocked(233));
                        DrawTableRowText("A Dream In Flight", charaData.IsOrchestrionUnlocked(266));
                        DrawTableRowText("Ending", charaData.IsOrchestrionUnlocked(267));
                        DrawTableRowText("Deltascape", charaData.IsOrchestrionUnlocked(265));
                        DrawTableRowText("Staff Credits", charaData.IsOrchestrionUnlocked(292));
                        DrawTableRowText("Alma's Theme", charaData.IsOrchestrionUnlocked(293));
                        DrawTableRowText("Shadowbringers", charaData.IsOrchestrionUnlocked(315));
                        DrawTableRowText("Tomorrow And Tomorrow", charaData.IsOrchestrionUnlocked(316));
                        DrawTableRowText("Significance (Nothing)", charaData.IsOrchestrionUnlocked(350));
                        DrawTableRowText("Pain In Pleasure", charaData.IsOrchestrionUnlocked(342));
                        DrawTableRowText("Voice Of No Return (Guitar)", charaData.IsOrchestrionUnlocked(353));
                        DrawTableRowText("Crumbling Lies (Front)", charaData.IsOrchestrionUnlocked(372));
                        DrawTableRowText("Blue Fields (Shadowbringers)", charaData.IsOrchestrionUnlocked(362));
                        DrawTableRowText("Broken Heart", charaData.IsOrchestrionUnlocked(399));
                        DrawTableRowText("Amusement Park", charaData.IsOrchestrionUnlocked(400));
                        DrawTableRowText("New Foundations", charaData.IsOrchestrionUnlocked(410));
                        DrawTableRowText("Voice Of No Return (Normal)", charaData.IsOrchestrionUnlocked(470));
                        DrawTableRowText("The Color Of Depression", charaData.IsOrchestrionUnlocked(471));
                        DrawTableRowText("Widespread Illness", charaData.IsOrchestrionUnlocked(472));
                        DrawTableRowText("Possessed By Disease", charaData.IsOrchestrionUnlocked(473));
                        DrawTableRowText("Faltering Prayer (Dawn Breeze)", charaData.IsOrchestrionUnlocked(474));
                        DrawTableRowText("And Love You Shall Find", charaData.IsOrchestrionUnlocked(440));
                        DrawTableRowText("Weight Of The World (Instrumental)", charaData.IsOrchestrionUnlocked(469));
                        DrawTableRowText("Endwalker – Footfalls", charaData.IsOrchestrionUnlocked(498));
                        DrawTableRowText("Flow", charaData.IsOrchestrionUnlocked(499));
                        DrawTableRowText("Flow Together", charaData.IsOrchestrionUnlocked(509));
                        DrawTableRowText("Somewhere In The World (Ambitions Writhe)", charaData.IsOrchestrionUnlocked(590));

                        ImGui.EndTable();
                    }
                    ImGui.TreePop();
                }
                if (ImGui.TreeNode("Raids"))
                {
                    if (ImGui.BeginTable("OrchestrionRaid", 2))
                    {
                        SetUpTableColumns();

                        DrawTableRowText("Moebius", charaData.IsOrchestrionUnlocked(141));
                        DrawTableRowText("Trisection", charaData.IsOrchestrionUnlocked(186));
                        DrawTableRowText("Precipitous Combat", charaData.IsOrchestrionUnlocked(187));
                        DrawTableRowText("Ultima's Transformation", charaData.IsOrchestrionUnlocked(188));
                        DrawTableRowText("Shattered", charaData.IsOrchestrionUnlocked(218));
                        DrawTableRowText("The Mystery Of Giruvegan", charaData.IsOrchestrionUnlocked(234));
                        DrawTableRowText("Apoplexy", charaData.IsOrchestrionUnlocked(235));
                        DrawTableRowText("Flash Of Steel", charaData.IsOrchestrionUnlocked(236));
                        DrawTableRowText("Omega Squared", charaData.IsOrchestrionUnlocked(253));
                        DrawTableRowText("Decisions (Omega)", charaData.IsOrchestrionUnlocked(254));
                        DrawTableRowText("Final, Not Final", charaData.IsOrchestrionUnlocked(255));
                        DrawTableRowText("A Battle Decisively", charaData.IsOrchestrionUnlocked(256));
                        DrawTableRowText("Dancing Mad - Movement I", charaData.IsOrchestrionUnlocked(257));
                        DrawTableRowText("Dancing Mad - Movement II", charaData.IsOrchestrionUnlocked(258));
                        DrawTableRowText("Dancing Mad - Movement III", charaData.IsOrchestrionUnlocked(259));
                        DrawTableRowText("Dancing Mad - Movement IV", charaData.IsOrchestrionUnlocked(260));
                        DrawTableRowText("Battle", charaData.IsOrchestrionUnlocked(261));
                        DrawTableRowText("Primogenitor", charaData.IsOrchestrionUnlocked(262));
                        DrawTableRowText("EScape", charaData.IsOrchestrionUnlocked(263));
                        DrawTableRowText("Heartless", charaData.IsOrchestrionUnlocked(264));
                        DrawTableRowText("From The Heavens", charaData.IsOrchestrionUnlocked(275));
                        DrawTableRowText("Under The Stars", charaData.IsOrchestrionUnlocked(294));
                        DrawTableRowText("Pressure (No. 1)", charaData.IsOrchestrionUnlocked(295));
                        DrawTableRowText("Antipyretic", charaData.IsOrchestrionUnlocked(296));
                        DrawTableRowText("A Man Consumed", charaData.IsOrchestrionUnlocked(297));
                        DrawTableRowText("Ultima's Perfection", charaData.IsOrchestrionUnlocked(298));
                        DrawTableRowText("Force Your Way (Shadowbringers)", charaData.IsOrchestrionUnlocked(327));
                        DrawTableRowText("Blinding Indigo", charaData.IsOrchestrionUnlocked(333));
                        DrawTableRowText("Landslide", charaData.IsOrchestrionUnlocked(328));
                        DrawTableRowText("City Ruins (Rays Of Light)", charaData.IsOrchestrionUnlocked(351));
                        DrawTableRowText("Alien Manifestation", charaData.IsOrchestrionUnlocked(354));
                        DrawTableRowText("Song Of The Ancients (Atonement)", charaData.IsOrchestrionUnlocked(355));
                        DrawTableRowText("Bipolar Nightmare", charaData.IsOrchestrionUnlocked(356));
                        DrawTableRowText("Weight Of The World (Prelude Version)", charaData.IsOrchestrionUnlocked(357));
                        DrawTableRowText("Twice Stricken", charaData.IsOrchestrionUnlocked(363));
                        DrawTableRowText("Primal Angel", charaData.IsOrchestrionUnlocked(364));
                        DrawTableRowText("Return To Oblivion", charaData.IsOrchestrionUnlocked(365));
                        DrawTableRowText("Fortress Of Lies", charaData.IsOrchestrionUnlocked(401));
                        DrawTableRowText("Grandma (Destruction)", charaData.IsOrchestrionUnlocked(402));
                        DrawTableRowText("End Of The Unknown", charaData.IsOrchestrionUnlocked(403));
                        DrawTableRowText("Torn From The Heavens／The Dark Colossus Destroys All (Medley Version)", charaData.IsOrchestrionUnlocked(404));
                        DrawTableRowText("Don't Be Afraid (Shadowbringers)", charaData.IsOrchestrionUnlocked(417));
                        DrawTableRowText("The Legendary Beast (Shadowbringers)", charaData.IsOrchestrionUnlocked(418));
                        DrawTableRowText("Promises To Keep", charaData.IsOrchestrionUnlocked(419));
                        DrawTableRowText("The Extreme (Shadowbringers)", charaData.IsOrchestrionUnlocked(420));
                        DrawTableRowText("Mourning", charaData.IsOrchestrionUnlocked(464));
                        DrawTableRowText("Emil (Despair)", charaData.IsOrchestrionUnlocked(465));
                        DrawTableRowText("The Sound Of The End", charaData.IsOrchestrionUnlocked(352));
                        DrawTableRowText("The Sound Of The End: 8bit", charaData.IsOrchestrionUnlocked(467));
                        DrawTableRowText("Kainé (Final Fantasy Main Theme Version)", charaData.IsOrchestrionUnlocked(468));
                        DrawTableRowText("Ancient Shackles", charaData.IsOrchestrionUnlocked(485));
                        DrawTableRowText("Hic Svnt Leones", charaData.IsOrchestrionUnlocked(486));
                        DrawTableRowText("Pilgrimage", charaData.IsOrchestrionUnlocked(511));
                        DrawTableRowText("Radiance", charaData.IsOrchestrionUnlocked(512));
                        DrawTableRowText("In The Balance", charaData.IsOrchestrionUnlocked(513));
                        DrawTableRowText("Silent Scream", charaData.IsOrchestrionUnlocked(540));
                        DrawTableRowText("Scream", charaData.IsOrchestrionUnlocked(541));
                        DrawTableRowText("Embers", charaData.IsOrchestrionUnlocked(542));
                        DrawTableRowText("White Stone Black", charaData.IsOrchestrionUnlocked(543));
                        DrawTableRowText("Favor", charaData.IsOrchestrionUnlocked(569));
                        DrawTableRowText("Rhythm Of The Realm", charaData.IsOrchestrionUnlocked(570));
                        DrawTableRowText("Dedicated To Moonlight", charaData.IsOrchestrionUnlocked(571));

                        ImGui.EndTable();
                    }
                    ImGui.TreePop();
                }
                if (ImGui.TreeNode("Ishgardian Restoration"))
                {
                    if (ImGui.BeginTable("OrchestrionResto", 2))
                    {
                        SetUpTableColumns();

                        DrawTableRowText("Jewel", charaData.IsOrchestrionUnlocked(123));
                        DrawTableRowText("Navigator's Glory - The Theme Of Limsa Lominsa", charaData.IsOrchestrionUnlocked(165));
                        DrawTableRowText("Born Of The Boughs - The Theme Of Gridania", charaData.IsOrchestrionUnlocked(166));
                        DrawTableRowText("The Twin Faces Of Fate - The Theme Of Ul'dah", charaData.IsOrchestrionUnlocked(167));
                        DrawTableRowText("Tricksome", charaData.IsOrchestrionUnlocked(248));
                        DrawTableRowText("Upon The Rocks", charaData.IsOrchestrionUnlocked(247));
                        DrawTableRowText("Safety In Numbers", charaData.IsOrchestrionUnlocked(349));
                        DrawTableRowText("Stone And Steel", charaData.IsOrchestrionUnlocked(376));
                        DrawTableRowText("The Mendicant's Relish", charaData.IsOrchestrionUnlocked(377));
                        DrawTableRowText("Order Yet Undeciphered", charaData.IsOrchestrionUnlocked(382));
                        DrawTableRowText("Paradise Found", charaData.IsOrchestrionUnlocked(374));
                        DrawTableRowText("Fealty", charaData.IsOrchestrionUnlocked(375));
                        DrawTableRowText("The Heavens' Ward", charaData.IsOrchestrionUnlocked(398));
                        DrawTableRowText("Freefall", charaData.IsOrchestrionUnlocked(397));
                        DrawTableRowText("Hearthward", charaData.IsOrchestrionUnlocked(428));
                        DrawTableRowText("Faith In Her Fury", charaData.IsOrchestrionUnlocked(427));
                        DrawTableRowText("Painted Skies", charaData.IsOrchestrionUnlocked(429));
                        DrawTableRowText("Skyrise", charaData.IsOrchestrionUnlocked(463));
                        DrawTableRowText("What Is Love?", charaData.IsOrchestrionUnlocked(441));
                        DrawTableRowText("Unworthy", charaData.IsOrchestrionUnlocked(554));

                        ImGui.EndTable();
                    }
                    ImGui.TreePop();
                }
                if (ImGui.TreeNode("Treasure Maps"))
                {
                    if (ImGui.BeginTable("OrchestrionTreasure", 2))
                    {
                        SetUpTableColumns();

                        DrawTableRowText("On Windy Meadows", charaData.IsOrchestrionUnlocked(76));
                        DrawTableRowText("Whisper Of The Land", charaData.IsOrchestrionUnlocked(77));
                        DrawTableRowText("Twilight Over Thanalan", charaData.IsOrchestrionUnlocked(78));
                        DrawTableRowText("Calamity Unbound", charaData.IsOrchestrionUnlocked(95));
                        DrawTableRowText("Unspoken", charaData.IsOrchestrionUnlocked(92));
                        DrawTableRowText("Breaking Boundaries", charaData.IsOrchestrionUnlocked(129));
                        DrawTableRowText("Navigator's Glory - The Theme Of Limsa Lominsa", charaData.IsOrchestrionUnlocked(165));
                        DrawTableRowText("Born Of The Boughs - The Theme Of Gridania", charaData.IsOrchestrionUnlocked(166));
                        DrawTableRowText("The Twin Faces Of Fate - The Theme Of Ul'dah", charaData.IsOrchestrionUnlocked(167));
                        DrawTableRowText("Crimson Sunrise", charaData.IsOrchestrionUnlocked(175));
                        DrawTableRowText("A Father's Pride", charaData.IsOrchestrionUnlocked(178));
                        DrawTableRowText("Crimson Sunset", charaData.IsOrchestrionUnlocked(203));
                        DrawTableRowText("A Mother's Pride", charaData.IsOrchestrionUnlocked(205));
                        DrawTableRowText("Insatiable", charaData.IsOrchestrionUnlocked(330));
                        DrawTableRowText("On Our Fates Alight", charaData.IsOrchestrionUnlocked(381));
                        DrawTableRowText("Unmatching Pieces", charaData.IsOrchestrionUnlocked(425));
                        DrawTableRowText("Everywhere And Nowhere", charaData.IsOrchestrionUnlocked(422));
                        DrawTableRowText("Tomorrow And Tomorrow - Reprise", charaData.IsOrchestrionUnlocked(423));
                        DrawTableRowText("Dangerous Words", charaData.IsOrchestrionUnlocked(424));
                        DrawTableRowText("A Better Tomorrow", charaData.IsOrchestrionUnlocked(444));
                        DrawTableRowText("On Blade's Edge", charaData.IsOrchestrionUnlocked(496));
                        DrawTableRowText("Finality", charaData.IsOrchestrionUnlocked(497));
                        DrawTableRowText("A Victory Fanfare Reborn", charaData.IsOrchestrionUnlocked(572));
                        DrawTableRowText("Dangertek", charaData.IsOrchestrionUnlocked(573));

                        ImGui.EndTable();
                    }
                    ImGui.TreePop();
                }
                if (ImGui.TreeNode("Trials"))
                {
                    if (ImGui.BeginTable("OrchestrionTrial", 2))
                    {
                        SetUpTableColumns();

                        DrawTableRowText("Cornerstone Of The New World - Astera", charaData.IsOrchestrionUnlocked(237));
                        DrawTableRowText("Savage Of The Ancient Forest", charaData.IsOrchestrionUnlocked(238));
                        DrawTableRowText("Proof Of A Hero - Monster Hunter: World Version", charaData.IsOrchestrionUnlocked(239));

                        ImGui.EndTable();
                    }
                    ImGui.TreePop();
                }
                if (ImGui.TreeNode("Beast Tribes"))
                {
                    if (ImGui.BeginTable("OrchestrionTribe", 2))
                    {
                        SetUpTableColumns();

                        DrawTableRowText("Smoulder", charaData.IsOrchestrionUnlocked(85));
                        DrawTableRowText("Coming Home", charaData.IsOrchestrionUnlocked(86));
                        DrawTableRowText("Flibbertigibbet", charaData.IsOrchestrionUnlocked(117));
                        DrawTableRowText("Piece Of Mind", charaData.IsOrchestrionUnlocked(118));
                        DrawTableRowText("Indomitable", charaData.IsOrchestrionUnlocked(179));
                        DrawTableRowText("Keepers Of The Lock", charaData.IsOrchestrionUnlocked(207));
                        DrawTableRowText("Seven Hundred Seventy-Seven Whiskers", charaData.IsOrchestrionUnlocked(231));
                        DrawTableRowText("The Garden's Gates", charaData.IsOrchestrionUnlocked(345));
                        DrawTableRowText("Hopl's Dropple", charaData.IsOrchestrionUnlocked(371));
                        DrawTableRowText("Watts's Anvil", charaData.IsOrchestrionUnlocked(383));
                        DrawTableRowText("Hippo Ridin'", charaData.IsOrchestrionUnlocked(514));
                        DrawTableRowText("Cradle Of Hope", charaData.IsOrchestrionUnlocked(546));
                        DrawTableRowText("Dreamwalker", charaData.IsOrchestrionUnlocked(566));
                        DrawTableRowText("Battle 1 From FINAL FANTASY IV", charaData.IsOrchestrionUnlocked(582));

                        ImGui.EndTable();
                    }
                    ImGui.TreePop();
                }
                if (ImGui.TreeNode("Variant/Criterion"))
                {
                    if (ImGui.BeginTable("OrchestrionVandC", 2))
                    {
                        SetUpTableColumns();

                        DrawTableRowText("Desert Sun", charaData.IsOrchestrionUnlocked(539));

                        ImGui.EndTable();
                    }
                    ImGui.TreePop();
                }
                if (ImGui.TreeNode("Voyages"))
                {
                    if (ImGui.BeginTable("OrchestrionVoyage", 2))
                    {
                        SetUpTableColumns();

                        DrawTableRowText("Hard To Miss", charaData.IsOrchestrionUnlocked(394));
                        DrawTableRowText("Nemesis", charaData.IsOrchestrionUnlocked(421));
                        DrawTableRowText("By Design", charaData.IsOrchestrionUnlocked(442));
                        DrawTableRowText("Dreams Aloft", charaData.IsOrchestrionUnlocked(587));

                        ImGui.EndTable();
                    }
                    ImGui.TreePop();
                }
                ImGui.TreePop();
            }
        }
    }
}
