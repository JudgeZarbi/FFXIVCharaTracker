using Dalamud.Interface.Colors;
using Dalamud.Logging;
using FFXIVCharaTracker.DB;
using FFXIVClientStructs.FFXIV.Client.Game;
using FFXIVClientStructs.FFXIV.Client.Game.UI;
using ImGuiNET;
using Lumina.Data.Parsing.Layer;
using Lumina.Excel.GeneratedSheets;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Channels;
using System.Xml.Linq;
using static FFXIVClientStructs.FFXIV.Client.Game.QuestManager.QuestListArray;
using static Lumina.Data.Parsing.Layer.LayerCommon;
using static System.Net.Mime.MediaTypeNames;

namespace FFXIVCharaTracker
{
	internal class PluginUI : IDisposable
	{
        private Plugin Plugin { get; }

        internal bool Show;

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
		private static float Scale = ImGui.GetIO().FontGlobalScale;

		internal PluginUI(Plugin plugin)
        {
            this.Plugin = plugin;

            Plugin.PluginInterface.UiBuilder.Draw += this.Draw;
        }

        public void Dispose()
		{
            Plugin.PluginInterface.UiBuilder.Draw -= this.Draw;
        }

		private void DrawTableRowText(string name, bool have, Vector4? colour = null, string? value = null)
		{
			ImGui.TableNextRow();
			ImGui.TableNextColumn();
			ImGui.PushItemWidth(ImGui.GetContentRegionAvail().X);
			ImGui.Text(name);
			ImGui.TableNextColumn();
			ImGui.PushItemWidth(ImGui.GetContentRegionAvail().X);
			if (have)
			{
				ImGui.TextColored(colour ?? Green, value ?? "Yes");
			}
			else
			{
				ImGui.TextColored(colour ?? Red, value ?? "No");
			}
		}

		private static void SetUpTableColumns()
		{
			ImGui.TableSetupColumn("", ImGuiTableColumnFlags.WidthStretch, 4.0f);
			ImGui.TableSetupColumn("", ImGuiTableColumnFlags.WidthStretch, 6.0f);
		}

		private static void SetCellBackground(Vector4 colour)
		{
			ImGui.TableNextColumn();
			ImGui.TableSetBgColor(ImGuiTableBgTarget.CellBg, ImGui.GetColorU32(colour));
		}

		private void SetCellBackgroundWithText(Vector4 colour, string text, Vector4? textColour = null)
		{
			ImGui.TableNextColumn();
			ImGui.TableSetBgColor(ImGuiTableBgTarget.CellBg, ImGui.GetColorU32(colour));
			ImGui.TextColored(textColour ?? Black, text);
		}

		private static void SetUpSquadTableHeaders(float width, params string[] objects)
		{
			ImGui.TableSetupScrollFreeze(1, 0);

			ImGui.TableSetupColumn("Name", ImGuiTableColumnFlags.WidthFixed, 100 * Scale);
			foreach (var title in objects)
			{
				ImGui.TableSetupColumn(title, ImGuiTableColumnFlags.WidthFixed, width * Scale);
			}
			ImGui.TableHeadersRow();
		}

		internal void Draw()
        {
            if (!Show)
            {
                return;
            }

			ImGui.SetNextWindowSize(new Vector2(700, 500), ImGuiCond.FirstUseEver);

            var windowFlags = ImGuiWindowFlags.NoCollapse;
            ImGui.Begin($"FFXIV Character Tracker", ref Show, windowFlags);

            var flags = ImGuiTabBarFlags.AutoSelectNewTabs;
            if (ImGui.BeginTabBar("showTypeTabBar", flags))
            {
                if (ImGui.BeginTabItem("Personal"))
                {
					var charaData = Plugin.CurCharaData!;
					if (Plugin.CurCharaData == null)
					{
						ImGui.Text("This character is not registered in the database.");
						if (ImGui.Button("Register character"))
						{
							Plugin.AddNewCharacter();
						}
					}
					else
					{
						if (ImGui.TreeNode($"Character"))
						{
							if (ImGui.BeginTable("tablePersonal", 2))
							{
								SetUpTableColumns();

								ImGui.TableNextRow();
								ImGui.TableNextColumn();
								var account = charaData.Account;
								var oldAccount = account;
								ImGui.AlignTextToFramePadding();
								ImGui.PushItemWidth(ImGui.GetContentRegionAvail().X);
								ImGui.Text("Account");
								ImGui.TableNextColumn();
								ImGui.PushItemWidth(ImGui.GetContentRegionAvail().X);
								ImGui.Combo("###Account", ref account, new string[] { "1", "2", "3", "4", "5", "6", "7", "8" }, 8);
								if (oldAccount != account)
								{
									charaData.Account = account;
									Plugin.Context.SaveChanges();
								}
								ImGui.TableNextRow();
								ImGui.TableNextColumn();
								ImGui.AlignTextToFramePadding();
								ImGui.Text("Class");
								ImGui.TableNextColumn();
								var dropdownID = (int)ClassIDToDropdown[charaData.ClassID];
								ImGui.Combo("###Class", ref dropdownID, new string[] { "AST", "BLM", "BRD", "DNC", "DRG", "DRK",
									"GNB", "MCH", "MNK", "NIN", "PLD", "RDM", "RPR", "SAM", "SCH", "SGE", "SMN", "WAR", "WHM" }, 19);
								if (charaData.ClassID != DropdownToClassID[(uint)dropdownID])
								{
									charaData.ClassID = DropdownToClassID[(uint)dropdownID];
									Plugin.Context.SaveChanges();
								}

								DrawTableRowText("Home World", true, White, Plugin.Worlds.GetRow(charaData.WorldID)!.Name);

								var chocoLevel = charaData.ChocoboLevel;
								DrawTableRowText("Chocobo level", true, chocoLevel == Data.MaxChocoboLevel ? Green : (chocoLevel > 0 ? Yellow : Red),
									chocoLevel.ToString());

								var gcRank = charaData.GCRank;
								DrawTableRowText("Grand Company rank", true, gcRank == Data.MaxGCLevel ? Green : (gcRank > 0 ? Yellow : Red),
									GCRankToString[gcRank]);

								ImGui.EndTable();
							}
							if (ImGui.TreeNode("Retainers"))
							{
								if (ImGui.BeginTable("tableRetainer", 2))
								{
									SetUpTableColumns();

									DrawTableRowText("Retainer class", true, White,
										Plugin.ClassJobs.GetRow(charaData.RetainerClass)!.Name);

									ImGui.TableNextRow();
									ImGui.TableNextColumn();
									ImGui.Text("Storing");
									ImGui.TableNextColumn();
									var input = charaData.RetainersStoringDescription;
									ImGui.InputText("", ref input, 10000);
									if (input != charaData.RetainersStoringDescription)
									{
										charaData.RetainersStoringDescription = input;
										Plugin.Context.SaveChanges();
									}
									ImGui.EndTable();
								}
								if (ImGui.TreeNode("Retainer 1"))
								{
									if (ImGui.BeginTable("tableRetainer1", 2))
									{
										SetUpTableColumns();

										var level = charaData.LevelRetainer1;
										DrawTableRowText("Level", true, level == Data.MaxLevel ? Green : (level > 0 ? Yellow : Red),
											level.ToString());

										DrawTableRowText("Gear", charaData.GearRetainer1, null);

										ImGui.EndTable();
									}
									ImGui.TreePop();
								}
								if (ImGui.TreeNode("Retainer 2"))
								{
									if (ImGui.BeginTable("tableRetainer2", 2))
									{
										SetUpTableColumns();

										var level = charaData.LevelRetainer2;
										DrawTableRowText("Level", true, level == Data.MaxLevel ? Green : (level > 0 ? Yellow : Red),
											level.ToString());

										DrawTableRowText("Gear", charaData.GearRetainer2, null);
										ImGui.EndTable();
									}
									ImGui.TreePop();
								}

								ImGui.TreePop();
							}

							ImGui.TreePop();
						}
						if (ImGui.TreeNode("DoW/DoM"))
						{
							if (ImGui.BeginTable("tableDoMDoW", 2))
							{
								SetUpTableColumns();

								var level = charaData.ClassLevel;
								DrawTableRowText("Level", true, level == Data.MaxLevel ? Green : (level > 0 ? Yellow : Red),
									level.ToString());

								var story = charaData.GetStoryProgress();
								DrawTableRowText("Story", true, story == Data.MaxStoryLevel ? Green : (level > 0 ? Yellow : Red),
									StoryProgressToString[story]);

								ImGui.EndTable();

								if (ImGui.TreeNode("Gear"))
								{
									if (ImGui.BeginTable("tableDoMDoWGear", 2))
									{
										SetUpTableColumns();

										var lowGear = charaData.LowGear || level == Data.MaxLevel;
										DrawTableRowText("Low level", lowGear);

										DrawTableRowText("Current level", charaData.CurGear);

										ImGui.EndTable();
									}
									ImGui.TreePop();
								}
							}
							ImGui.TreePop();

						}
						if (ImGui.TreeNode("DoH/DoL"))
						{
							if (ImGui.BeginTable("tableDoHDoL", 2))
							{
								SetUpTableColumns();

								var level = charaData.LevelCrp;
								DrawTableRowText("CRP", true, level == Data.MaxLevel ? Green : (level > 0 ? Yellow : Red),
									level.ToString());

								level = charaData.LevelBsm;
								DrawTableRowText("BSM", true, level == Data.MaxLevel ? Green : (level > 0 ? Yellow : Red),
									level.ToString());

								level = charaData.LevelArm;
								DrawTableRowText("ARM", true, level == Data.MaxLevel ? Green : (level > 0 ? Yellow : Red),
									level.ToString());

								level = charaData.LevelGsm;
								DrawTableRowText("GSM", true, level == Data.MaxLevel ? Green : (level > 0 ? Yellow : Red),
									level.ToString());

								level = charaData.LevelLtw;
								DrawTableRowText("LTW", true, level == Data.MaxLevel ? Green : (level > 0 ? Yellow : Red),
									level.ToString());

								level = charaData.LevelWvr;
								DrawTableRowText("WVR", true, level == Data.MaxLevel ? Green : (level > 0 ? Yellow : Red),
									level.ToString());

								level = charaData.LevelAlc;
								DrawTableRowText("ALC", true, level == Data.MaxLevel ? Green : (level > 0 ? Yellow : Red),
									level.ToString());

								level = charaData.LevelCul;
								DrawTableRowText("CUL", true, level == Data.MaxLevel ? Green : (level > 0 ? Yellow : Red),
									level.ToString());

								level = charaData.LevelMin;
								DrawTableRowText("MIN", true, level == Data.MaxLevel ? Green : (level > 0 ? Yellow : Red),
									level.ToString());

								level = charaData.LevelBtn;
								DrawTableRowText("BTN", true, level == Data.MaxLevel ? Green : (level > 0 ? Yellow : Red),
									level.ToString());

								level = charaData.LevelFsh;
								DrawTableRowText("FSH", true, level == Data.MaxLevel ? Green : (level > 0 ? Yellow : Red),
									level.ToString());

								var colour = White;
								var text = "";
								if (charaData.LevelCrp >= 80 && charaData.LevelBsm >= 80 &&
									charaData.LevelArm >= 80 && charaData.LevelGsm >= 80 &&
									charaData.LevelLtw >= 80 && charaData.LevelWvr >= 80 &&
									charaData.LevelAlc >= 80 && charaData.LevelCul >= 80 &&
									charaData.LevelMin >= 80 && charaData.LevelBtn >= 80)
								{
									colour = Green;
									text = "Complete!";
								}
								else if (charaData.LevelCrp >= 10 && charaData.LevelBsm >= 10 &&
									charaData.LevelArm >= 10 && charaData.LevelGsm >= 10 &&
									charaData.LevelLtw >= 10 && charaData.LevelWvr >= 10 &&
									charaData.LevelAlc >= 10 && charaData.LevelCul >= 10 &&
									charaData.LevelMin >= 10 && charaData.LevelBtn >= 10 &&
									charaData.IsQuestComplete(69208))
								{
									colour = Yellow;
									text = "Available and incomplete!";
								}
								else
								{
									colour = Red;
									text = "Unavailable!";
								}
								DrawTableRowText("Ishgardian Restoration", true, colour, text);

								var missingCrafterQuests = charaData.GetMissingCrafterQuests();

								colour = missingCrafterQuests.Count == 8 ? Green :
									(missingCrafterQuests.Count == 0 ? Red : Yellow);
								text = missingCrafterQuests.Count == 8 ? "Complete!" :
									(missingCrafterQuests.Count == 0 ? "None complete!" :
									"Missing: " + String.Join(", ", missingCrafterQuests));

								DrawTableRowText("Crafter quests", true, colour, text);

								colour = charaData.IncompleteSecretRecipeBooksSet.Count == Data.RecipeBookIDs.Length ? Red :
									(charaData.IncompleteSecretRecipeBooksSet.Count == 0 ? Green : Yellow);
								text = charaData.IncompleteSecretRecipeBooksSet.Count == Data.RecipeBookIDs.Length ? "None!" :
									(charaData.IncompleteSecretRecipeBooksSet.Count == 0 ? "Complete!" :
									"Missing:\n" + String.Join("\n", charaData.IncompleteSecretRecipeBooksSet.Select(i => Plugin.SecretRecipeBooks.GetRow(i)!.Name)));

								PluginLog.Warning($"{charaData.IncompleteSecretRecipeBooksSet.Count}, {Data.RecipeBookIDs.Length}");

								DrawTableRowText("Secret recipe books", true, colour, text);

								DrawTableRowText("Gathering gear", charaData.GatherGear);

								var missingGathererQuests = charaData.GetMissingGathererQuests();
								colour = missingGathererQuests.Count == 3 ? Green :
									(missingGathererQuests.Count == 0 ? Red : Yellow);
								text = missingGathererQuests.Count == 3 ? "Complete!" :
									(missingGathererQuests.Count == 0 ? "None complete!" :
									"Missing: " + String.Join(", ", missingGathererQuests));


								DrawTableRowText("Gatherer quests", true, colour, text);

								colour = charaData.IncompleteFolkloreBooksSet.Count == Data.FolkloreIDs.Length ? Red :
									(charaData.IncompleteFolkloreBooksSet.Count == 0 ? Green : Yellow);
								text = charaData.IncompleteFolkloreBooksSet.Count == Data.FolkloreIDs.Length ? "None!" :
									(charaData.IncompleteFolkloreBooksSet.Count == 0 ? "Complete!" :
									"Missing:\n" + String.Join("\n", charaData.IncompleteFolkloreBooksSet.Select(i => Plugin.ItemSheet.GetRow(i)!.Name)));

								DrawTableRowText("Folklore books", true, colour, text);

#if DEBUG || RELEASE_DEV
								DrawTableRowText("Money leves", charaData.LevelCrp >= 84 && charaData.GetStoryProgress() > Data.QuestComplete555);
#endif
								ImGui.EndTable();
							}
							if (ImGui.TreeNode("Custom Deliveries"))
							{
								if (ImGui.BeginTable("tableSatisfaction", 2))
								{
									SetUpTableColumns();

									for (int i = 1; i < Plugin.SatisfactionNpcs.RowCount; i++)
									{
										var locked = charaData.LockedCustomDeliveriesSet.Contains(Plugin.SatisfactionNpcs.GetRow((uint)i)!.Npc.Value!.RowId);
										DrawTableRowText(Plugin.SatisfactionNpcs.GetRow((uint)i)!.Npc.Value!.Singular, true,
											locked ? Red : (charaData.CustomDeliveryRanksSet[i - 1] == Data.MaxCustomDeliveryRank) ? Green : Yellow,
											locked ? "Locked" : $"Rank {charaData.CustomDeliveryRanksSet[i - 1]}");
									}
									ImGui.EndTable();
								}
								ImGui.TreePop();
							}
							ImGui.TreePop();
						}
						if (ImGui.TreeNode("Emotes"))
						{
							if (ImGui.TreeNode("Sidequests"))
							{
								if (ImGui.BeginTable("emotesSidequest", 2))
								{
									SetUpTableColumns();

									DrawTableRowText("Throw", charaData.IsEmoteUnlocked(85));
									DrawTableRowText("Step Dance", charaData.IsEmoteUnlocked(101));
									DrawTableRowText("Harvest Dance", charaData.IsEmoteUnlocked(102));
									DrawTableRowText("Ball Dance", charaData.IsEmoteUnlocked(103));
									DrawTableRowText("Manderville Dance", charaData.IsEmoteUnlocked(104));
									DrawTableRowText("Most Gentlemanly", charaData.IsEmoteUnlocked(114));
									DrawTableRowText("Spectacles", charaData.IsEmoteUnlocked(148));
									DrawTableRowText("Manderville Mambo", charaData.IsEmoteUnlocked(198));
									DrawTableRowText("Lali-ho", charaData.IsEmoteUnlocked(199));

									ImGui.EndTable();
								}
								ImGui.TreePop();
							}
							if (ImGui.TreeNode("Tribe"))
							{
								if (ImGui.BeginTable("emotesTribe", 2))
								{
									SetUpTableColumns();

									DrawTableRowText("Sundrop Dance", charaData.IsEmoteUnlocked(120));
									DrawTableRowText("Moogle Dance", charaData.IsEmoteUnlocked(126));
									DrawTableRowText("Moonlift Dance", charaData.IsEmoteUnlocked(145));
									DrawTableRowText("Ritual Prayer", charaData.IsEmoteUnlocked(167));
									DrawTableRowText("Charmed", charaData.IsEmoteUnlocked(64));
									DrawTableRowText("Yol Dance", charaData.IsEmoteUnlocked(176));
									DrawTableRowText("Gratuity", charaData.IsEmoteUnlocked(194));
									DrawTableRowText("Lali Hop", charaData.IsEmoteUnlocked(217));

									ImGui.EndTable();
								}
								ImGui.TreePop();

							}
							if (ImGui.TreeNode("Gold Saucer"))
							{
								if (ImGui.BeginTable("emotesSaucer", 2))
								{
									SetUpTableColumns();

									DrawTableRowText("Thavnairian Dance", charaData.IsEmoteUnlocked(118));
									DrawTableRowText("Gold Dance", charaData.IsEmoteUnlocked(119));
									DrawTableRowText("Aback", charaData.IsEmoteUnlocked(171));
									DrawTableRowText("Big Grin", charaData.IsEmoteUnlocked(81));
									DrawTableRowText("Bee's Knees", charaData.IsEmoteUnlocked(216));
									DrawTableRowText("Sheathe Weapon", charaData.IsEmoteUnlocked(237));
									DrawTableRowText("Draw Weapon", charaData.IsEmoteUnlocked(238));

									ImGui.EndTable();
								}
								ImGui.TreePop();

							}
							if (ImGui.TreeNode("Squadron"))
							{
								if (ImGui.BeginTable("emotesSquadron", 2))
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
							if (ImGui.TreeNode("GC Seals"))
							{
								if (ImGui.BeginTable("emotesGC", 2))
								{
									SetUpTableColumns();

									DrawTableRowText("Attention", charaData.IsEmoteUnlocked(164));
									DrawTableRowText("At Ease", charaData.IsEmoteUnlocked(165));
									DrawTableRowText("Reflect", charaData.IsEmoteUnlocked(82));

									ImGui.EndTable();
								}
								ImGui.TreePop();

							}
							if (ImGui.TreeNode("Hunts"))
							{
								if (ImGui.BeginTable("emotesHunts", 2))
								{
									SetUpTableColumns();

									DrawTableRowText("Winded", charaData.IsEmoteUnlocked(170));
									DrawTableRowText("Tremble", charaData.IsEmoteUnlocked(169));

									ImGui.EndTable();
								}
								ImGui.TreePop();

							}
							if (ImGui.TreeNode("PvP"))
							{
								if (ImGui.BeginTable("emotesPvP", 2))
								{
									SetUpTableColumns();

									DrawTableRowText("Elucidate", charaData.IsEmoteUnlocked(182));
									DrawTableRowText("Reprimand", charaData.IsEmoteUnlocked(196));

									ImGui.EndTable();
								}
								ImGui.TreePop();

							}
							if (ImGui.TreeNode("Deep/Variant Dungeon"))
							{
								if (ImGui.BeginTable("emotesDeep", 2))
								{
									SetUpTableColumns();

									DrawTableRowText("Sweat", charaData.IsEmoteUnlocked(180));
									DrawTableRowText("Wow", charaData.IsEmoteUnlocked(246));

									ImGui.EndTable();
								}
								ImGui.TreePop();

							}
							if (ImGui.TreeNode("Eureka"))
							{
								if (ImGui.BeginTable("emotesEureka", 2))
								{
									SetUpTableColumns();

									DrawTableRowText("Shiver", charaData.IsEmoteUnlocked(181));
									DrawTableRowText("Scheme", charaData.IsEmoteUnlocked(189));
									DrawTableRowText("Fist Pump", charaData.IsEmoteUnlocked(195));

									ImGui.EndTable();
								}
								ImGui.TreePop();

							}
							if (ImGui.TreeNode("Bozja"))
							{
								if (ImGui.BeginTable("emotesBozja", 2))
								{
									SetUpTableColumns();

									DrawTableRowText("Guard", charaData.IsEmoteUnlocked(214));
									DrawTableRowText("Malevolence", charaData.IsEmoteUnlocked(215));
									DrawTableRowText("Wring Hands", charaData.IsEmoteUnlocked(222));

									ImGui.EndTable();
								}
								ImGui.TreePop();

							}
							if (ImGui.TreeNode("Treasure Hunts"))
							{
								if (ImGui.BeginTable("emotesTreasure", 2))
								{
									SetUpTableColumns();

									DrawTableRowText("Confirm", charaData.IsEmoteUnlocked(188));
									DrawTableRowText("Paint it Black", charaData.IsEmoteUnlocked(224));
									DrawTableRowText("Paint it Red", charaData.IsEmoteUnlocked(225));
									DrawTableRowText("Paint it Yellow", charaData.IsEmoteUnlocked(226));
									DrawTableRowText("Paint it Blue", charaData.IsEmoteUnlocked(227));

									ImGui.EndTable();
								}
								ImGui.TreePop();

							}
							if (ImGui.TreeNode("Ishgardian Restoration"))
							{
								if (ImGui.BeginTable("emotesResto", 2))
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
							if (ImGui.TreeNode("Mog Station"))
							{
								if (ImGui.BeginTable("emotesMog", 2))
								{
									SetUpTableColumns();

									DrawTableRowText("Bomb Dance", charaData.IsEmoteUnlocked(109));
									DrawTableRowText("Huzzah", charaData.IsEmoteUnlocked(110));
									DrawTableRowText("Eureka", charaData.IsEmoteUnlocked(125));
									DrawTableRowText("Black Ranger Pose A", charaData.IsEmoteUnlocked(131));
									DrawTableRowText("Black Ranger Pose B", charaData.IsEmoteUnlocked(135));
									DrawTableRowText("Yellow Ranger Pose A", charaData.IsEmoteUnlocked(132));
									DrawTableRowText("Yellow Ranger Pose B", charaData.IsEmoteUnlocked(136));
									DrawTableRowText("Red Ranger Pose A", charaData.IsEmoteUnlocked(130));
									DrawTableRowText("Red Ranger Pose B", charaData.IsEmoteUnlocked(134));
									DrawTableRowText("Eastern Greeting", charaData.IsEmoteUnlocked(124));
									DrawTableRowText("Dote", charaData.IsEmoteUnlocked(146));
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
									DrawTableRowText("Pantomime", charaData.IsEmoteUnlocked(229));
									DrawTableRowText("Vexed", charaData.IsEmoteUnlocked(230));
									DrawTableRowText("Drink Tea", charaData.IsEmoteUnlocked(239));
									DrawTableRowText("Deride", charaData.IsEmoteUnlocked(245));

									ImGui.EndTable();
								}
								ImGui.TreePop();

							}
							ImGui.TreePop();
							if (ImGui.TreeNode("Other"))
							{
								if (ImGui.BeginTable("emotesOther", 2))
								{
									SetUpTableColumns();

									DrawTableRowText("Headache", charaData.IsEmoteUnlocked(204));
									DrawTableRowText("Embrace", charaData.IsEmoteUnlocked(113));

									ImGui.EndTable();
								}
								ImGui.TreePop();

							}
							ImGui.TreePop();
						}
						if (ImGui.TreeNode("Hairstyles"))
						{
							if (ImGui.TreeNode("Gold Saucer"))
							{
								if (ImGui.BeginTable("hairstylesSaucer", 2))
								{
									SetUpTableColumns();

									DrawTableRowText("Great Lengths", charaData.IsHairstyleUnlocked(27970));
									DrawTableRowText("Lexen-tails", charaData.IsHairstyleUnlocked(24801));
									DrawTableRowText("Styled for Hire", charaData.IsHairstyleUnlocked(24234));
									DrawTableRowText("Fashionably Feathered", charaData.IsHairstyleUnlocked(23370));
									DrawTableRowText("Rainmaker", charaData.IsHairstyleUnlocked(17471));
									DrawTableRowText("Curls", charaData.IsHairstyleUnlocked(13704));
									DrawTableRowText("Adventure", charaData.IsHairstyleUnlocked(13705));
									DrawTableRowText("Ponytails", charaData.IsHairstyleUnlocked(10084));

									ImGui.EndTable();
								}
								ImGui.TreePop();

							}
							if (ImGui.TreeNode("Eureka"))
							{
								if (ImGui.BeginTable("hairstylesEureka", 2))
								{
									SetUpTableColumns();

									DrawTableRowText("Form and Function", charaData.IsHairstyleUnlocked(24233));

									ImGui.EndTable();
								}
								ImGui.TreePop();
							}
							if (ImGui.TreeNode("Bozja"))
							{
								if (ImGui.BeginTable("hairstylesBozja", 2))
								{
									SetUpTableColumns();

									DrawTableRowText("Both Ways", charaData.IsHairstyleUnlocked(33706));
									DrawTableRowText("Early to Rise", charaData.IsHairstyleUnlocked(32835));
									DrawTableRowText("Wind Caller", charaData.IsHairstyleUnlocked(31407));

									ImGui.EndTable();
								}
								ImGui.TreePop();
							}
							if (ImGui.TreeNode("Deep Dungeon"))
							{
								if (ImGui.BeginTable("hairstylesDeep", 2))
								{
									SetUpTableColumns();

									DrawTableRowText("Gyr Abanian Plait", charaData.IsHairstyleUnlocked(23369));
									DrawTableRowText("Samsonian Locks", charaData.IsHairstyleUnlocked(16703));

									ImGui.EndTable();
								}
								ImGui.TreePop();
							}
							if (ImGui.TreeNode("Ishgardian Restoration"))
							{
								if (ImGui.BeginTable("hairstylesResto", 2))
								{
									SetUpTableColumns();

									DrawTableRowText("Saintly Style", charaData.IsHairstyleUnlocked(31406));
									DrawTableRowText("Controlled Chaos", charaData.IsHairstyleUnlocked(30113));
									DrawTableRowText("Modern Legend", charaData.IsHairstyleUnlocked(28615));

									ImGui.EndTable();
								}
								ImGui.TreePop();
							}
							if (ImGui.TreeNode("Alliance Raids"))
							{
								if (ImGui.BeginTable("hairstylesAlliance", 2))
								{
									SetUpTableColumns();

									DrawTableRowText("Scanning for Style", charaData.IsHairstyleUnlocked(33708));
									DrawTableRowText("Battle-ready Bobs", charaData.IsHairstyleUnlocked(33707));

									ImGui.EndTable();
								}
								ImGui.TreePop();
							}
							if (ImGui.TreeNode("Island Sanctuary"))
							{
								if (ImGui.BeginTable("hairstylesAlliance", 2))
								{
									SetUpTableColumns();

									DrawTableRowText("Practical Ponytails", charaData.IsHairstyleUnlocked(38443));
									DrawTableRowText("Tall Tails", charaData.IsHairstyleUnlocked(38442));

									ImGui.EndTable();
								}
								ImGui.TreePop();
							}
							if (ImGui.TreeNode("Mog Station"))
							{
								if (ImGui.BeginTable("hairstylesMog", 2))
								{
									SetUpTableColumns();

									DrawTableRowText("Sharlayan Rebellion", charaData.IsHairstyleUnlocked(39472));
									DrawTableRowText("Sharlayan Studies", charaData.IsHairstyleUnlocked(32836));
									DrawTableRowText("Master & Commander", charaData.IsHairstyleUnlocked(17472));
									DrawTableRowText("Scion Special Issue", charaData.IsHairstyleUnlocked(13703));
									DrawTableRowText("Scion Special Issue II", charaData.IsHairstyleUnlocked(15612));
									DrawTableRowText("Scion Special Issue III", charaData.IsHairstyleUnlocked(15613));
									DrawTableRowText("Pulse", charaData.IsHairstyleUnlocked(14970));
									DrawTableRowText("Liberating Locks", charaData.IsHairstyleUnlocked(36812));
									DrawTableRowText("Clowning Around", charaData.IsHairstyleUnlocked(36618));
									DrawTableRowText("A Wicked Wake", charaData.IsHairstyleUnlocked(28614));

									ImGui.EndTable();
								}
								ImGui.TreePop();

							}
							ImGui.TreePop();
						}
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
									DrawTableRowText("Mudpie (Southern Front Lockbox, Zadnor Lockbox, Saint Mocianne's Arboretum", charaData.IsMinionUnlocked(312));
									DrawTableRowText("Scarlet Peacock", charaData.IsMinionUnlocked(303));
									DrawTableRowText("Abroader Otter", charaData.IsMinionUnlocked(329));
									DrawTableRowText("Seitei", charaData.IsMinionUnlocked(327));
									DrawTableRowText("Wind-up Weapon", charaData.IsMinionUnlocked(321));
									DrawTableRowText("Chameleon", charaData.IsMinionUnlocked(334));
									DrawTableRowText("Sharksucker-class Insubmersible", charaData.IsMinionUnlocked(348));
									DrawTableRowText("Magitek Helldiver F1", charaData.IsMinionUnlocked(383));
									DrawTableRowText("Dáinsleif F1", charaData.IsMinionUnlocked(389));
									DrawTableRowText("Save the Princess (Delubrum Reginae", charaData.IsMinionUnlocked(404));
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
						if (ImGui.TreeNode("Optional Content"))
						{
							if (ImGui.TreeNode("General"))
							{
								if (ImGui.BeginTable("optionalGeneral", 2))
								{
									SetUpTableColumns();

									DrawTableRowText("Mist", charaData.IsQuestComplete(66750));
									DrawTableRowText("Lavender Beds", charaData.IsQuestComplete(66748));
									DrawTableRowText("The Goblet", charaData.IsQuestComplete(66749));
									DrawTableRowText("Shirogane", charaData.IsQuestComplete(68167));
									DrawTableRowText("Empyreum", charaData.IsQuestComplete(69708));
									DrawTableRowText("Crystalline Conflict", charaData.IsQuestComplete(66640) || charaData.IsQuestComplete(66640) || charaData.IsQuestComplete(66640));
									DrawTableRowText("Frontlines", charaData.IsQuestComplete(67063) || charaData.IsQuestComplete(67064) || charaData.IsQuestComplete(67065));
									DrawTableRowText("Rival Wings", charaData.IsQuestComplete(68583));
									DrawTableRowText("Wondrous Tails", charaData.IsQuestComplete(67928));
									DrawTableRowText("Faux Hollows", charaData.IsQuestComplete(69501));

									ImGui.EndTable();
								}
								ImGui.TreePop();
							}
							if (ImGui.TreeNode("A Realm Reborn"))
							{
								if (ImGui.TreeNode("Dungeons"))
								{
									if (ImGui.BeginTable("DungeonsArr", 2))
									{
										SetUpTableColumns();

										DrawTableRowText("Halatali", charaData.IsInstanceUnlocked(7));
										DrawTableRowText("The Sunken Temple of Qarn", charaData.IsInstanceUnlocked(9));
										DrawTableRowText("Cutter's Cry", charaData.IsInstanceUnlocked(12));
										DrawTableRowText("Dzemael Darkhold", charaData.IsInstanceUnlocked(13));
										DrawTableRowText("The Aurum Vale", charaData.IsInstanceUnlocked(5));
										DrawTableRowText("Amdapor Keep", charaData.IsInstanceUnlocked(14));
										DrawTableRowText("The Wanderer's Palace", charaData.IsInstanceUnlocked(7));
										DrawTableRowText("Copperbell Mines (Hard)", charaData.IsInstanceUnlocked(18));
										DrawTableRowText("Haukke Manor (Hard)", charaData.IsInstanceUnlocked(19));
										DrawTableRowText("Pharos Sirius", charaData.IsInstanceUnlocked(17));
										DrawTableRowText("Brayflox's Longstop (Hard)", charaData.IsInstanceUnlocked(20));
										DrawTableRowText("Halatali (Hard)", charaData.IsInstanceUnlocked(21));
										DrawTableRowText("The Lost City of Amdapor (Hard)", charaData.IsInstanceUnlocked(22));
										DrawTableRowText("Hullbreaker Isle", charaData.IsInstanceUnlocked(23));
										DrawTableRowText("The Stone Vigil (Hard)", charaData.IsInstanceUnlocked(25));
										DrawTableRowText("The Tam-Tara Deepcroft (Hard)", charaData.IsInstanceUnlocked(24));
										DrawTableRowText("Sastasha (Hard)", charaData.IsInstanceUnlocked(28));
										DrawTableRowText("The Sunken Temple of Qarn (Hard)", charaData.IsInstanceUnlocked(26));
										DrawTableRowText("Amdapor Keep (Hard)", charaData.IsInstanceUnlocked(29));
										DrawTableRowText("The Wanderer's Palace (Hard)", charaData.IsInstanceUnlocked(30));

										ImGui.EndTable();
									}
									ImGui.TreePop();
								}
								if (ImGui.TreeNode("Trials"))
								{
									if (ImGui.BeginTable("TrialsArr", 2))
									{
										SetUpTableColumns();

										DrawTableRowText("Battle on the Big Bridge", charaData.IsInstanceUnlocked(20021));
										DrawTableRowText("A Relic Reborn: The Chimera", charaData.IsInstanceUnlocked(20019));
										DrawTableRowText("A Relic Reborn: The Hydra", charaData.IsInstanceUnlocked(20020));
										DrawTableRowText("The Minstrel's Ballad: Ultima's Bane", charaData.IsInstanceUnlocked(20013));
										DrawTableRowText("The Howling Eye (Extreme)", charaData.IsInstanceUnlocked(20010));
										DrawTableRowText("The Navel (Extreme)", charaData.IsInstanceUnlocked(20009));
										DrawTableRowText("The Bowl of Embers (Extreme)", charaData.IsInstanceUnlocked(20008));
										DrawTableRowText("The Dragon's Neck", charaData.IsInstanceUnlocked(20026));
										DrawTableRowText("The Whorleater (Extreme)", charaData.IsInstanceUnlocked(20018));
										DrawTableRowText("Thornmarch (Extreme)", charaData.IsInstanceUnlocked(20012));
										DrawTableRowText("The Striking Tree (Extreme)", charaData.IsInstanceUnlocked(20023));
										DrawTableRowText("Battle in the Big Keep", charaData.IsInstanceUnlocked(20030));
										DrawTableRowText("Akh Afah Amphitheatre (Extreme)", charaData.IsInstanceUnlocked(20025));
										DrawTableRowText("Urth's Fount", charaData.IsInstanceUnlocked(20027));

										ImGui.EndTable();
									}
									ImGui.TreePop();
								}
								if (ImGui.TreeNode("Raids"))
								{
									if (ImGui.BeginTable("RaidsArr", 2))
									{
										SetUpTableColumns();

										DrawTableRowText("The Binding Coil of Bahamut - Turn 1", charaData.IsInstanceUnlocked(30002));
										DrawTableRowText("The Binding Coil of Bahamut - Turn 2", charaData.IsInstanceUnlocked(30003));
										DrawTableRowText("The Binding Coil of Bahamut - Turn 3", charaData.IsInstanceUnlocked(30004));
										DrawTableRowText("The Binding Coil of Bahamut - Turn 4", charaData.IsInstanceUnlocked(30005));
										DrawTableRowText("The Binding Coil of Bahamut - Turn 5", charaData.IsInstanceUnlocked(30006));
										DrawTableRowText("The Second Coil of Bahamut - Turn 1", charaData.IsInstanceUnlocked(30007));
										DrawTableRowText("The Second Coil of Bahamut - Turn 2", charaData.IsInstanceUnlocked(30008));
										DrawTableRowText("The Second Coil of Bahamut - Turn 3", charaData.IsInstanceUnlocked(30009));
										DrawTableRowText("The Second Coil of Bahamut - Turn 4", charaData.IsInstanceUnlocked(30010));
										DrawTableRowText("The Second Coil of Bahamut - Turn 1 (Savage)", charaData.IsInstanceUnlocked(30012));
										DrawTableRowText("The Second Coil of Bahamut - Turn 2 (Savage)", charaData.IsInstanceUnlocked(30013));
										DrawTableRowText("The Second Coil of Bahamut - Turn 3 (Savage)", charaData.IsInstanceUnlocked(30014));
										DrawTableRowText("The Second Coil of Bahamut - Turn 4 (Savage)", charaData.IsInstanceUnlocked(30015));
										DrawTableRowText("The Final Coil of Bahamut - Turn 1", charaData.IsInstanceUnlocked(30016));
										DrawTableRowText("The Final Coil of Bahamut - Turn 2", charaData.IsInstanceUnlocked(30017));
										DrawTableRowText("The Final Coil of Bahamut - Turn 3", charaData.IsInstanceUnlocked(30018));
										DrawTableRowText("The Final Coil of Bahamut - Turn 4", charaData.IsInstanceUnlocked(30019));

										ImGui.EndTable();
									}
									ImGui.TreePop();
								}
								ImGui.TreePop();
							}
							if (ImGui.TreeNode("Heavensward"))
							{
								if (ImGui.TreeNode("Dungeons"))
								{
									if (ImGui.BeginTable("DungeonsHw", 2))
									{
										SetUpTableColumns();

										DrawTableRowText("The Dusk Vigil", charaData.IsInstanceUnlocked(36));
										DrawTableRowText("Neverreap", charaData.IsInstanceUnlocked(33));
										DrawTableRowText("The Fractal Continuum", charaData.IsInstanceUnlocked(35));
										DrawTableRowText("Saint Mocianne's Arboretum", charaData.IsInstanceUnlocked(41));
										DrawTableRowText("Pharos Sirius (Hard)", charaData.IsInstanceUnlocked(40));
										DrawTableRowText("The Lost City of Amdapor (Hard)", charaData.IsInstanceUnlocked(42));
										DrawTableRowText("Hullbreaker Isle (Hard)", charaData.IsInstanceUnlocked(45));
										DrawTableRowText("The Great Gubal Library (Hard)", charaData.IsInstanceUnlocked(47));
										DrawTableRowText("Sohm Al (Hard)", charaData.IsInstanceUnlocked(49));
										DrawTableRowText("The Palace of the Dead", charaData.IsQuestComplete(67092));

										ImGui.EndTable();
									}
									ImGui.TreePop();
								}
								if (ImGui.TreeNode("Trials"))
								{
									if (ImGui.BeginTable("TrialsHw", 2))
									{
										SetUpTableColumns();

										DrawTableRowText("The Limitless Blue (Extreme)", charaData.IsInstanceUnlocked(20034));
										DrawTableRowText("Thok ast Thok (Extreme)", charaData.IsInstanceUnlocked(20032));
										DrawTableRowText("Containment Bay S1T7", charaData.IsInstanceUnlocked(20037));
										DrawTableRowText("The Minstrel's Ballad: Thordan's Reign", charaData.IsInstanceUnlocked(20036));
										DrawTableRowText("Containment Bay S1T7 (Extreme)", charaData.IsInstanceUnlocked(20038));
										DrawTableRowText("Containment Bay P1T6", charaData.IsInstanceUnlocked(20041));
										DrawTableRowText("The Minstrel's Ballad: Nidhogg's Rage", charaData.IsInstanceUnlocked(20040));
										DrawTableRowText("Containment Bay P1T6 (Extreme)", charaData.IsInstanceUnlocked(20042));
										DrawTableRowText("Containment Bay Z1T9", charaData.IsInstanceUnlocked(20043));
										DrawTableRowText("Containment Bay Z1T9 (Extreme)", charaData.IsInstanceUnlocked(20044));

										ImGui.EndTable();
									}
									ImGui.TreePop();
								}
								if (ImGui.TreeNode("Raids"))
								{
									if (ImGui.TreeNode("Normal Raids"))
									{
										if (ImGui.BeginTable("NormalRaidsHw", 2))
										{
											SetUpTableColumns();

											DrawTableRowText("Alexander - The Fist of the Father", charaData.IsInstanceUnlocked(30021));
											DrawTableRowText("Alexander - The Cuff of the Father", charaData.IsInstanceUnlocked(30022));
											DrawTableRowText("Alexander - The Arm of the Father", charaData.IsInstanceUnlocked(30023));
											DrawTableRowText("Alexander - The Burden of the Father", charaData.IsInstanceUnlocked(30024));
											DrawTableRowText("Alexander - The Fist of the Father (Savage)", charaData.IsInstanceUnlocked(30025));
											DrawTableRowText("Alexander - The Cuff of the Father (Savage)", charaData.IsInstanceUnlocked(30026));
											DrawTableRowText("Alexander - The Arm of the Father (Savage)", charaData.IsInstanceUnlocked(30027));
											DrawTableRowText("Alexander - The Burden of the Father (Savage)", charaData.IsInstanceUnlocked(30028));
											DrawTableRowText("Alexander - The Fist of the Son", charaData.IsInstanceUnlocked(30030));
											DrawTableRowText("Alexander - The Cuff of the Son", charaData.IsInstanceUnlocked(30031));
											DrawTableRowText("Alexander - The Arm of the Son", charaData.IsInstanceUnlocked(30032));
											DrawTableRowText("Alexander - The Burden of the Son (Savage)", charaData.IsInstanceUnlocked(30033));
											DrawTableRowText("Alexander - The Fist of the Son (Savage)", charaData.IsInstanceUnlocked(30034));
											DrawTableRowText("Alexander - The Cuff of the Son (Savage)", charaData.IsInstanceUnlocked(30035));
											DrawTableRowText("Alexander - The Arm of the Son (Savage)", charaData.IsInstanceUnlocked(30036));
											DrawTableRowText("Alexander - The Burden of the Son (Savage)", charaData.IsInstanceUnlocked(30037));
											DrawTableRowText("Alexander - The Eyes of the Creator", charaData.IsInstanceUnlocked(30039));
											DrawTableRowText("Alexander - The Breath of the Creator", charaData.IsInstanceUnlocked(30040));
											DrawTableRowText("Alexander - The Heart of the Creator", charaData.IsInstanceUnlocked(30041));
											DrawTableRowText("Alexander - The Soul of the Creator", charaData.IsInstanceUnlocked(30042));
											DrawTableRowText("Alexander - The Eyes of the Creator (Savage)", charaData.IsInstanceUnlocked(30043));
											DrawTableRowText("Alexander - The Breath of the Creator (Savage)", charaData.IsInstanceUnlocked(30044));
											DrawTableRowText("Alexander - The Heart of the Creator (Savage)", charaData.IsInstanceUnlocked(30045));
											DrawTableRowText("Alexander - The Soul of the Creator (Savage)", charaData.IsInstanceUnlocked(30046));

											ImGui.EndTable();
										}
										ImGui.TreePop();
									}
									if (ImGui.TreeNode("Alliance Raids"))
									{
										if (ImGui.BeginTable("AllianceRaidsHw", 2))
										{
											SetUpTableColumns();

											DrawTableRowText("The Void Ark", charaData.IsInstanceUnlocked(30029));
											DrawTableRowText("The Weeping City of Mhach", charaData.IsInstanceUnlocked(30038));
											DrawTableRowText("Dun Scaith", charaData.IsInstanceUnlocked(30047));

											ImGui.EndTable();
										}
										ImGui.TreePop();
									}
									ImGui.TreePop();
								}
								ImGui.TreePop();
							}
							if (ImGui.TreeNode("Stormblood"))
							{
								if (ImGui.TreeNode("Dungeons"))
								{
									if (ImGui.BeginTable("DungeonsSb", 2))
									{
										SetUpTableColumns();

										DrawTableRowText("Shisui of the Violet Tides", charaData.IsInstanceUnlocked(50));
										DrawTableRowText("Kugane Castle", charaData.IsInstanceUnlocked(57));
										DrawTableRowText("The Temple of the Fist", charaData.IsInstanceUnlocked(51));
										DrawTableRowText("Hell's Lid", charaData.IsInstanceUnlocked(59));
										DrawTableRowText("The Fractal Continuum (Hard)", charaData.IsInstanceUnlocked(60));
										DrawTableRowText("The Swallow's Compass", charaData.IsInstanceUnlocked(61));
										DrawTableRowText("Saint Mocianne's Arboretum (Hard)", charaData.IsInstanceUnlocked(62));
										DrawTableRowText("Heaven-on-High", charaData.IsQuestComplete(68667));

										ImGui.EndTable();
									}
									ImGui.TreePop();
								}
								if (ImGui.TreeNode("Trials"))
								{
									if (ImGui.BeginTable("TrialsSb", 2))
									{
										SetUpTableColumns();

										DrawTableRowText("Emanation (Extreme)", charaData.IsInstanceUnlocked(20049));
										DrawTableRowText("The Pool of Tribute (Extreme)", charaData.IsInstanceUnlocked(20047));
										DrawTableRowText("The Great Hunt", charaData.IsInstanceUnlocked(20053));
										DrawTableRowText("The Minstrel's Ballad: Shinryu's Domain", charaData.IsInstanceUnlocked(20050));
										DrawTableRowText("The Jade Stoa", charaData.IsInstanceUnlocked(20051));
										DrawTableRowText("The Jade Stoa (Extreme)", charaData.IsInstanceUnlocked(20052));
										DrawTableRowText("The Great Hunt (Extreme)", charaData.IsInstanceUnlocked(20054));
										DrawTableRowText("The Minstrel's Ballad: Tsukuyomi's Pain", charaData.IsInstanceUnlocked(20056));
										DrawTableRowText("Hells' Kier", charaData.IsInstanceUnlocked(20057));
										DrawTableRowText("Kugane Ohashi", charaData.IsInstanceUnlocked(20059));
										DrawTableRowText("The Wreath of Snakes", charaData.IsInstanceUnlocked(20060));
										DrawTableRowText("Hells' Kier (Extreme)", charaData.IsInstanceUnlocked(20058));
										DrawTableRowText("The Wreath of Snakes (Extreme)", charaData.IsInstanceUnlocked(20061));

										ImGui.EndTable();
									}
									ImGui.TreePop();
								}
								if (ImGui.TreeNode("Raids"))
								{
									if (ImGui.TreeNode("Normal Raids"))
									{
										if (ImGui.BeginTable("NormalRaidsSb", 2))
										{
											SetUpTableColumns();

											DrawTableRowText("Deltascape V1.0", charaData.IsInstanceUnlocked(30049));
											DrawTableRowText("Deltascape V2.0", charaData.IsInstanceUnlocked(30050));
											DrawTableRowText("Deltascape V3.0", charaData.IsInstanceUnlocked(30051));
											DrawTableRowText("Deltascape V4.0", charaData.IsInstanceUnlocked(30052));
											DrawTableRowText("Deltascape V1.0 (Savage)", charaData.IsInstanceUnlocked(30053));
											DrawTableRowText("Deltascape V2.0 (Savage)", charaData.IsInstanceUnlocked(30054));
											DrawTableRowText("Deltascape V3.0 (Savage)", charaData.IsInstanceUnlocked(30055));
											DrawTableRowText("Deltascape V4.0 (Savage)", charaData.IsInstanceUnlocked(30056));
											DrawTableRowText("Sigmascape V1.0", charaData.IsInstanceUnlocked(30059));
											DrawTableRowText("Sigmascape V2.0", charaData.IsInstanceUnlocked(30060));
											DrawTableRowText("Sigmascape V3.0", charaData.IsInstanceUnlocked(30061));
											DrawTableRowText("Sigmascape V4.0", charaData.IsInstanceUnlocked(30062));
											DrawTableRowText("Sigmascape V1.0 (Savage)", charaData.IsInstanceUnlocked(30063));
											DrawTableRowText("Sigmascape V2.0 (Savage)", charaData.IsInstanceUnlocked(30064));
											DrawTableRowText("Sigmascape V3.0 (Savage)", charaData.IsInstanceUnlocked(30065));
											DrawTableRowText("Sigmascape V4.0 (Savage)", charaData.IsInstanceUnlocked(30066));
											DrawTableRowText("Alphascape V1.0", charaData.IsInstanceUnlocked(30069));
											DrawTableRowText("Alphascape V2.0", charaData.IsInstanceUnlocked(30070));
											DrawTableRowText("Alphascape V3.0", charaData.IsInstanceUnlocked(30071));
											DrawTableRowText("Alphascape V4.0", charaData.IsInstanceUnlocked(30072));
											DrawTableRowText("Alphascape V1.0 (Savage)", charaData.IsInstanceUnlocked(30073));
											DrawTableRowText("Alphascape V2.0 (Savage)", charaData.IsInstanceUnlocked(30074));
											DrawTableRowText("Alphascape V3.0 (Savage)", charaData.IsInstanceUnlocked(30075));
											DrawTableRowText("Alphascape V4.0 (Savage)", charaData.IsInstanceUnlocked(30076));

											ImGui.EndTable();
										}
										ImGui.TreePop();
									}
									if (ImGui.TreeNode("Alliance Raids"))
									{
										if (ImGui.BeginTable("AllianceRaidsSb", 2))
										{
											SetUpTableColumns();

											DrawTableRowText("The Royal City of Rabanastre", charaData.IsInstanceUnlocked(30058));
											DrawTableRowText("The Ridorana Lighthouse", charaData.IsInstanceUnlocked(30068));
											DrawTableRowText("The Orbonne Monastery", charaData.IsInstanceUnlocked(30077));

											ImGui.EndTable();
										}
										ImGui.TreePop();
									}
									ImGui.TreePop();
								}
								if (ImGui.TreeNode("Eureka"))
								{
									if (ImGui.BeginTable("EurekaSb", 2))
									{
										SetUpTableColumns();

										DrawTableRowText("The Forbidden Land, Eureka Anemos", charaData.IsQuestComplete(68614));
										DrawTableRowText("The Forbidden Land, Eureka Pagos", charaData.IsQuestComplete(68478));
										DrawTableRowText("The Forbidden Land, Eureka Pyros", charaData.IsQuestComplete(68148));
										DrawTableRowText("The Forbidden Land, Eureka Hydatos", charaData.IsQuestComplete(68149));

										ImGui.EndTable();
									}
									ImGui.TreePop();
								}
								ImGui.TreePop();
							}
							if (ImGui.TreeNode("Shadowbringers"))
							{
								if (ImGui.TreeNode("Dungeons"))
								{
									if (ImGui.BeginTable("DungeonsShb", 2))
									{
										SetUpTableColumns();

										DrawTableRowText("Akadaemia Anyder", charaData.IsInstanceUnlocked(71));
										DrawTableRowText("The Twinning", charaData.IsInstanceUnlocked(20013));

										ImGui.EndTable();
									}
									ImGui.TreePop();
								}
								if (ImGui.TreeNode("Trials"))
								{
									if (ImGui.BeginTable("TrialsShb", 2))
									{
										SetUpTableColumns();

										DrawTableRowText("The Crown of the Immaculate (Extreme)", charaData.IsInstanceUnlocked(20065));
										DrawTableRowText("The Minstrel's Ballad: Hades' Elegy", charaData.IsInstanceUnlocked(20067));
										DrawTableRowText("Cinder Drift", charaData.IsInstanceUnlocked(20068));
										DrawTableRowText("Cinder Drift (Extreme)", charaData.IsInstanceUnlocked(20069));
										DrawTableRowText("Memoria Misera (Extreme)", charaData.IsInstanceUnlocked(20070));
										DrawTableRowText("The Seat of Sacrifice (Extreme)", charaData.IsInstanceUnlocked(20072));
										DrawTableRowText("Castrum Marinum", charaData.IsInstanceUnlocked(20073));
										DrawTableRowText("The Cloud Deck", charaData.IsInstanceUnlocked(20075));
										DrawTableRowText("Castrum Marinum (Extreme)", charaData.IsInstanceUnlocked(20074));
										DrawTableRowText("The Cloud Deck (Extreme)", charaData.IsInstanceUnlocked(20076));

										ImGui.EndTable();
									}
									ImGui.TreePop();
								}
								if (ImGui.TreeNode("Raids"))
								{
									if (ImGui.TreeNode("Normal Raids"))
									{
										if (ImGui.BeginTable("NormalRaidsShb", 2))
										{
											SetUpTableColumns();

											DrawTableRowText("Eden's Gate: Resurrection", charaData.IsInstanceUnlocked(30078));
											DrawTableRowText("Eden's Gate: Descent", charaData.IsInstanceUnlocked(30082));
											DrawTableRowText("Eden's Gate: Inundation", charaData.IsInstanceUnlocked(30080));
											DrawTableRowText("Eden's Gate: Sepulture", charaData.IsInstanceUnlocked(30084));
											DrawTableRowText("Eden's Gate: Resurrection (Savage)", charaData.IsInstanceUnlocked(30079));
											DrawTableRowText("Eden's Gate: Descent (Savage)", charaData.IsInstanceUnlocked(30083));
											DrawTableRowText("Eden's Gate: Inundation (Savage)", charaData.IsInstanceUnlocked(30081));
											DrawTableRowText("Eden's Gate: Sepulture (Savage)", charaData.IsInstanceUnlocked(30085));
											DrawTableRowText("Eden's Verse: Fulmination", charaData.IsInstanceUnlocked(30088));
											DrawTableRowText("Eden's Verse: Furor", charaData.IsInstanceUnlocked(30090));
											DrawTableRowText("Eden's Verse: Iconoclasm", charaData.IsInstanceUnlocked(30092));
											DrawTableRowText("Eden's Verse: Refulgence", charaData.IsInstanceUnlocked(30094));
											DrawTableRowText("Eden's Verse: Fulmination (Savage)", charaData.IsInstanceUnlocked(30089));
											DrawTableRowText("Eden's Verse: Furor (Savage)", charaData.IsInstanceUnlocked(30091));
											DrawTableRowText("Eden's Verse: Iconoclasm (Savage)", charaData.IsInstanceUnlocked(30093));
											DrawTableRowText("Eden's Verse: Refulgence (Savage)", charaData.IsInstanceUnlocked(30095));
											DrawTableRowText("Eden's Promise: Umbra", charaData.IsInstanceUnlocked(30097));
											DrawTableRowText("Eden's Promise: Litany", charaData.IsInstanceUnlocked(30099));
											DrawTableRowText("Eden's Promise: Anamorphosis", charaData.IsInstanceUnlocked(30101));
											DrawTableRowText("Eden's Promise: Eternity", charaData.IsInstanceUnlocked(30103));
											DrawTableRowText("Eden's Promise: Umbra (Savage)", charaData.IsInstanceUnlocked(30098));
											DrawTableRowText("Eden's Promise: Litany (Savage)", charaData.IsInstanceUnlocked(30100));
											DrawTableRowText("Eden's Promise: Anamorphosis (Savage)", charaData.IsInstanceUnlocked(30102));
											DrawTableRowText("Eden's Promise: Eternity (Savage)", charaData.IsInstanceUnlocked(30104));

											ImGui.EndTable();
										}
										ImGui.TreePop();
									}
									if (ImGui.TreeNode("Alliance Raids"))
									{
										if (ImGui.BeginTable("AllianceRaidsShb", 2))
										{
											SetUpTableColumns();

											DrawTableRowText("The Copied Factory", charaData.IsInstanceUnlocked(30087));
											DrawTableRowText("The Puppets' Bunker", charaData.IsInstanceUnlocked(30096));
											DrawTableRowText("The Tower at Paradigm's Breach", charaData.IsInstanceUnlocked(30105));

											ImGui.EndTable();
										}
										ImGui.TreePop();
									}
									ImGui.TreePop();
								}
								if (ImGui.TreeNode("Bozja"))
								{
									if (ImGui.BeginTable("BozjaShb", 2))
									{
										SetUpTableColumns();

										DrawTableRowText("The Bozjan Southern Front", charaData.IsQuestComplete(69477));
										DrawTableRowText("Castrum Lacus Litore", charaData.IsQuestComplete(69487) || QuestManager.GetQuestSequence(69487) > 0);
										DrawTableRowText("Delubrum Reginae", charaData.IsQuestComplete(68148) || QuestManager.GetQuestSequence(68148) > 0);
										DrawTableRowText("Zadnor", charaData.IsQuestComplete(69620));
										DrawTableRowText("The Dalriada", charaData.IsQuestComplete(69624) || QuestManager.GetQuestSequence(69624) > 0);
										DrawTableRowText("Bozja complete", charaData.IsQuestComplete(69624));

										ImGui.EndTable();
									}
									ImGui.TreePop();
								}
								ImGui.TreePop();
							}
							if (ImGui.TreeNode("Endwalker"))
							{
								if (ImGui.TreeNode("Dungeons"))
								{
									if (ImGui.BeginTable("DungeonsEw", 2))
									{
										SetUpTableColumns();

										DrawTableRowText("Smileton", charaData.IsInstanceUnlocked(20030));
										DrawTableRowText("The Stigma Dreamscape", charaData.IsInstanceUnlocked(79));

										ImGui.EndTable();
									}
									ImGui.TreePop();
								}
								if (ImGui.TreeNode("Trials"))
								{
									if (ImGui.BeginTable("TrialsEw", 2))
									{
										SetUpTableColumns();

										DrawTableRowText("The Minstrel's Ballad: Hydaelyn's Call", charaData.IsInstanceUnlocked(20078));
										DrawTableRowText("The Minstrel's Ballad: Zodiark's Fall", charaData.IsInstanceUnlocked(20081));
										DrawTableRowText("The Minstrel's Ballad: Endsinger's Aria", charaData.IsInstanceUnlocked(20083));
										DrawTableRowText("Storm's Crown (Extreme)", charaData.IsInstanceUnlocked(20085));
										DrawTableRowText("Mount Ordeals (Extreme)", charaData.IsInstanceUnlocked(20087));

										ImGui.EndTable();
									}
									ImGui.TreePop();
								}
								if (ImGui.TreeNode("Raids"))
								{
									if (ImGui.TreeNode("Normal Raids"))
									{
										if (ImGui.BeginTable("NormalRaidsEw", 2))
										{
											SetUpTableColumns();

											DrawTableRowText("Asphodelos: The First Circle", charaData.IsInstanceUnlocked(30111));
											DrawTableRowText("Asphodelos: The Second Circle", charaData.IsInstanceUnlocked(30113));
											DrawTableRowText("Asphodelos: The Third Circle", charaData.IsInstanceUnlocked(30109));
											DrawTableRowText("Asphodelos: The Fourth Circle", charaData.IsInstanceUnlocked(30107));
											DrawTableRowText("Asphodelos: The First Circle (Savage)", charaData.IsInstanceUnlocked(30112));
											DrawTableRowText("Asphodelos: The Second Circle (Savage)", charaData.IsInstanceUnlocked(30114));
											DrawTableRowText("Asphodelos: The Third Circle (Savage)", charaData.IsInstanceUnlocked(30110));
											DrawTableRowText("Asphodelos: The Fourth Circle (Savage)", charaData.IsInstanceUnlocked(30108));
											DrawTableRowText("Abyssos: The Fifth Circle", charaData.IsInstanceUnlocked(30116));
											DrawTableRowText("Abyssos: The Sixth Circle", charaData.IsInstanceUnlocked(30120));
											DrawTableRowText("Abyssos: The Seventh Circle", charaData.IsInstanceUnlocked(30118));
											DrawTableRowText("Abyssos: The Eighth Circle", charaData.IsInstanceUnlocked(30122));
											DrawTableRowText("Abyssos: The Fifth Circle (Savage)", charaData.IsInstanceUnlocked(30117));
											DrawTableRowText("Abyssos: The Sixth Circle (Savage)", charaData.IsInstanceUnlocked(30121));
											DrawTableRowText("Abyssos: The Seventh Circle (Savage)", charaData.IsInstanceUnlocked(30119));
											DrawTableRowText("Abyssos: The Eighth Circle (Savage)", charaData.IsInstanceUnlocked(30123));

											ImGui.EndTable();
										}
										ImGui.TreePop();
									}
									if (ImGui.TreeNode("Alliance Raids"))
									{
										if (ImGui.BeginTable("AllianceRaidsEw", 2))
										{
											SetUpTableColumns();

											DrawTableRowText("Aglaia", charaData.IsInstanceUnlocked(30115));
											DrawTableRowText("Euphrosyne", charaData.IsInstanceUnlocked(30125));

											ImGui.EndTable();
										}
										ImGui.TreePop();
									}
									ImGui.TreePop();
								}
								ImGui.TreePop();
							}
							ImGui.TreePop();
						}
					}
					ImGui.EndTabItem();
				}
				if (Plugin.Context.Charas.Count() > 1)
				{
					if (ImGui.BeginTabItem("Squad"))
					{
						var charas = Plugin.Context.Charas.FromSql($"SELECT * FROM Charas ORDER BY Account ASC, WorldID ASC, CharaID ASC").AsNoTracking();
						Scale = ImGui.GetIO().FontGlobalScale;
						ImGui.Indent();
						if (ImGui.BeginTabBar("squadSubtypes"))
						{
							if (ImGui.BeginTabItem("Character"))
							{
								if (ImGui.BeginTable("squadChara", 9, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
								{
									ImGui.TableSetupScrollFreeze(1, 0);

									ImGui.TableSetupColumn("Name", ImGuiTableColumnFlags.WidthFixed, 100 * Scale);
									ImGui.TableSetupColumn("Chocobo level", ImGuiTableColumnFlags.WidthFixed, 100 * Scale);
									ImGui.TableSetupColumn("Grand Company rank", ImGuiTableColumnFlags.WidthFixed, 125 * Scale);
									ImGui.TableSetupColumn("Retainer class", ImGuiTableColumnFlags.WidthFixed, 100 * Scale);
									ImGui.TableSetupColumn("Retainer storing", ImGuiTableColumnFlags.WidthFixed, 200 * Scale);
									ImGui.TableSetupColumn("Retainer 1 level", ImGuiTableColumnFlags.WidthFixed, 100 * Scale);
									ImGui.TableSetupColumn("Retainer 1 gear", ImGuiTableColumnFlags.WidthFixed, 100 * Scale);
									ImGui.TableSetupColumn("Retainer 2 level", ImGuiTableColumnFlags.WidthFixed, 100 * Scale);
									ImGui.TableSetupColumn("Retainer 2 gear", ImGuiTableColumnFlags.WidthFixed, 100 * Scale);
									ImGui.TableHeadersRow();

									foreach (var c in charas)
									{
										SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
										var chocoLevel = c.ChocoboLevel;
										SetCellBackgroundWithText(chocoLevel == Data.MaxChocoboLevel ? Green : (chocoLevel > 0 ? Yellow : Red), chocoLevel.ToString(), Black);
										var gcRank = c.GCRank;
										SetCellBackgroundWithText(default, GCRankToString[gcRank], gcRank == Data.MaxGCLevel ? Green : (gcRank > 0 ? Yellow : Red));
										SetCellBackgroundWithText(default, CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Plugin.ClassJobs.GetRow(c.RetainerClass)!.Name), White);
										SetCellBackgroundWithText(default, c.RetainersStoringDescription, White);
										var level = c.LevelRetainer1;
										SetCellBackgroundWithText(level == Data.MaxLevel ? Green : (level > 0 ? Yellow : Red), level.ToString(), Black);
										SetCellBackground(c.GearRetainer1 ? Green : Red);
										level = c.LevelRetainer2;
										SetCellBackgroundWithText(level == Data.MaxLevel ? Green : (level > 0 ? Yellow : Red), level.ToString(), Black);
										SetCellBackground(c.GearRetainer2 ? Green : Red);
									}
									ImGui.EndTable();
								}
								ImGui.EndTabItem();
							}
							if (ImGui.BeginTabItem("DoW/DoM"))
							{
								if (ImGui.BeginTable("squadDoWDoM", 6, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
								{
									SetUpSquadTableHeaders(100, "Class", "Level", "Story completion", "Low level gear", "Current level gear");

									foreach (var c in charas)
									{
										SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
										SetCellBackgroundWithText(default, CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Plugin.ClassJobs.GetRow(c.ClassID)!.Name), White);
										var level = c.ClassLevel;
										SetCellBackgroundWithText(level == Data.MaxLevel ? Green : (level > 0 ? Yellow : Red), level.ToString(), Black);
										var storyProgress = c.GetStoryProgress();
										SetCellBackgroundWithText(storyProgress == Data.MaxStoryLevel ? Green : (storyProgress > 0 ? Yellow : Red), StoryProgressToString[storyProgress], Black);
										SetCellBackground(c.LowGear || c.ClassLevel == Data.MaxLevel ? Green : Red);
										SetCellBackground(c.CurGear ? Green : Red);
									}
									ImGui.EndTable();
								}
								ImGui.EndTabItem();
							}
							if (ImGui.BeginTabItem("DoH/DoL"))
							{
								if (ImGui.BeginTable("squadDoHDoL", 28, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
								{
									ImGui.TableSetupScrollFreeze(1, 0);

									ImGui.TableSetupColumn("Name", ImGuiTableColumnFlags.WidthFixed, 100 * Scale);
									ImGui.TableSetupColumn("Carpenter", ImGuiTableColumnFlags.WidthFixed, 100 * Scale);
									ImGui.TableSetupColumn("Blacksmith", ImGuiTableColumnFlags.WidthFixed, 100 * Scale);
									ImGui.TableSetupColumn("Armourer", ImGuiTableColumnFlags.WidthFixed, 100 * Scale);
									ImGui.TableSetupColumn("Goldsmith", ImGuiTableColumnFlags.WidthFixed, 100 * Scale);
									ImGui.TableSetupColumn("Leatherworker", ImGuiTableColumnFlags.WidthFixed, 100 * Scale);
									ImGui.TableSetupColumn("Weaver", ImGuiTableColumnFlags.WidthFixed, 100 * Scale);
									ImGui.TableSetupColumn("Alchemist", ImGuiTableColumnFlags.WidthFixed, 100 * Scale);
									ImGui.TableSetupColumn("Culinarian", ImGuiTableColumnFlags.WidthFixed, 100 * Scale);
									ImGui.TableSetupColumn("Miner", ImGuiTableColumnFlags.WidthFixed, 100 * Scale);
									ImGui.TableSetupColumn("Botanist", ImGuiTableColumnFlags.WidthFixed, 100 * Scale);
									ImGui.TableSetupColumn("Fisher", ImGuiTableColumnFlags.WidthFixed, 100 * Scale);
									ImGui.TableSetupColumn("Ishgardian restoration", ImGuiTableColumnFlags.WidthFixed, 150 * Scale);
									ImGui.TableSetupColumn("Crafter quests", ImGuiTableColumnFlags.WidthFixed, 100 * Scale);
									ImGui.TableSetupColumn("Recipe books", ImGuiTableColumnFlags.WidthFixed, 100 * Scale);
									ImGui.TableSetupColumn("Gathering gear", ImGuiTableColumnFlags.WidthFixed, 100 * Scale);
									ImGui.TableSetupColumn("Gatherer quests", ImGuiTableColumnFlags.WidthFixed, 100 * Scale);
									ImGui.TableSetupColumn("Folklore books", ImGuiTableColumnFlags.WidthFixed, 100 * Scale);
#if DEBUG || RELEASE_DEV
									ImGui.TableSetupColumn("Money leves", ImGuiTableColumnFlags.WidthFixed, 100 * Scale);
#endif
									for (int i = 1; i < Plugin.SatisfactionNpcs.RowCount; i++)
									{
										ImGui.TableSetupColumn($"Delivery - {Plugin.SatisfactionNpcs.GetRow((uint)i)!.Npc.Value!.Singular}", ImGuiTableColumnFlags.WidthFixed, 150 * Scale);
									}
									ImGui.TableHeadersRow();

									foreach (var c in charas)
									{
										SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
										var level = c.LevelCrp;
										SetCellBackgroundWithText(level == Data.MaxLevel ? Green : (level > 0 ? Yellow : Red), level.ToString(), Black);
										level = c.LevelBsm;
										SetCellBackgroundWithText(level == Data.MaxLevel ? Green : (level > 0 ? Yellow : Red), level.ToString(), Black);
										level = c.LevelArm;
										SetCellBackgroundWithText(level == Data.MaxLevel ? Green : (level > 0 ? Yellow : Red), level.ToString(), Black);
										level = c.LevelGsm;
										SetCellBackgroundWithText(level == Data.MaxLevel ? Green : (level > 0 ? Yellow : Red), level.ToString(), Black);
										level = c.LevelLtw;
										SetCellBackgroundWithText(level == Data.MaxLevel ? Green : (level > 0 ? Yellow : Red), level.ToString(), Black);
										level = c.LevelWvr;
										SetCellBackgroundWithText(level == Data.MaxLevel ? Green : (level > 0 ? Yellow : Red), level.ToString(), Black);
										level = c.LevelArm;
										SetCellBackgroundWithText(level == Data.MaxLevel ? Green : (level > 0 ? Yellow : Red), level.ToString(), Black);
										level = c.LevelCul;
										SetCellBackgroundWithText(level == Data.MaxLevel ? Green : (level > 0 ? Yellow : Red), level.ToString(), Black);
										level = c.LevelMin;
										SetCellBackgroundWithText(level == Data.MaxLevel ? Green : (level > 0 ? Yellow : Red), level.ToString(), Black);
										level = c.LevelBtn;
										SetCellBackgroundWithText(level == Data.MaxLevel ? Green : (level > 0 ? Yellow : Red), level.ToString(), Black);
										level = c.LevelFsh;
										SetCellBackgroundWithText(level == Data.MaxLevel ? Green : (level > 0 ? Yellow : Red), level.ToString(), Black);
										Vector4 colour = default;
										if (c.LevelCrp >= 80 && c.LevelBsm >= 80 &&
											c.LevelArm >= 80 && c.LevelGsm >= 80 &&
											c.LevelLtw >= 80 && c.LevelWvr >= 80 &&
											c.LevelAlc >= 80 && c.LevelCul >= 80 &&
											c.LevelMin >= 80 && c.LevelBtn >= 80)
										{
											colour = Green;
										}
										else if (c.LevelCrp >= 10 && c.LevelBsm >= 10 &&
											c.LevelArm >= 10 && c.LevelGsm >= 10 &&
											c.LevelLtw >= 10 && c.LevelWvr >= 10 &&
											c.LevelAlc >= 10 && c.LevelCul >= 10 &&
											c.LevelMin >= 10 && c.LevelBtn >= 10 &&
											c.IsQuestComplete(69208))
										{
											colour = Yellow;
										}
										else
										{
											colour = Red;
										}
										SetCellBackground(colour);

										var missingCrafterQuests = c.GetMissingCrafterQuests();
										SetCellBackgroundWithText(missingCrafterQuests.Count == 8 ? Red : (missingCrafterQuests.Count == 0 ? Green : Yellow), string.Join(", ", missingCrafterQuests));

										SetCellBackgroundWithText(c.IncompleteSecretRecipeBooksSet.Count == Data.RecipeBookIDs.Length ? Red : (c.IncompleteSecretRecipeBooksSet.Count == 0 ? Green : Yellow), c.IncompleteSecretRecipeBooksSet.Count > 0 && c.IncompleteSecretRecipeBooksSet.Count < Data.RecipeBookIDs.Length ? c.IncompleteSecretRecipeBooksSet.Count.ToString() : "", Black);

										SetCellBackground(c.GatherGear ? Green : Red);

										var missingGathererQuests = c.GetMissingGathererQuests();
										SetCellBackgroundWithText(missingGathererQuests.Count == 3 ? Red : (missingGathererQuests.Count == 0 ? Green : Yellow), string.Join(", ", missingGathererQuests));

										SetCellBackgroundWithText(c.IncompleteFolkloreBooksSet.Count == Data.FolkloreIDs.Length ? Red : (c.IncompleteFolkloreBooksSet.Count == 0 ? Green : Yellow), c.IncompleteFolkloreBooksSet.Count > 0 && c.IncompleteFolkloreBooksSet.Count < Data.FolkloreIDs.Length ? c.IncompleteFolkloreBooksSet.Count.ToString() : "", Black);

#if DEBUG || RELEASE_DEV
										SetCellBackground(c.LevelCrp >= 84 && c.GetStoryProgress() > Data.QuestComplete555 ? Green : Red);
#endif

										for (int i = 1; i < Plugin.SatisfactionNpcs.RowCount; i++)
										{
											var locked = c.LockedCustomDeliveriesSet.Contains(Plugin.SatisfactionNpcs.GetRow((uint)i)!.Npc.Value!.RowId);
											SetCellBackgroundWithText(locked ? Red : (c.CustomDeliveryRanksSet[i - 1] == Data.MaxCustomDeliveryRank) ? Green : Yellow, locked ? "Locked" : $"Rank {c.CustomDeliveryRanksSet[i - 1]}", Black);
										}
									}
									ImGui.EndTable();
								}
								ImGui.EndTabItem();
							}
							if (ImGui.BeginTabItem("Emote"))
							{
								ImGui.Indent();
								if (ImGui.BeginTabBar("squadEmotes"))
								{
									if (ImGui.BeginTabItem("Sidequests"))
									{
										if (ImGui.BeginTable("squadEmotesSidequest", 10, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
										{
											SetUpSquadTableHeaders(125, "Throw", "Step Dance", "Harvest Dance", "Ball Dance", "Manderville Dance", "Most Gentlemanly", "Spectacles", "Manderville Mambo", "Lali-ho");

											foreach (var c in charas)
											{
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
										if (ImGui.BeginTable("squadEmotesTribe", 9, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
										{
											SetUpSquadTableHeaders(125, "Sundrop Dance", "Moogle Dance", "Moonlift Dance", "Ritual Prayer", "Charmed", "Yol Dance", "Gratuity", "Lali Hop");

											foreach (var c in charas)
											{
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
										if (ImGui.BeginTable("squadEmotesSaucer", 8, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
										{
											SetUpSquadTableHeaders(125, "Thavnairian Dance", "Gold Dance", "Aback", "Big Grin", "Bee's Knees", "Sheathe Weapon", "Draw Weapon");

											foreach (var c in charas)
											{
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
										if (ImGui.BeginTable("squadEmotesSquadron", 5, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
										{
											SetUpSquadTableHeaders(125, "Squats", "Push-ups", "Sit-ups", "Breath Control");

											foreach (var c in charas)
											{
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
										if (ImGui.BeginTable("squadEmotesGC", 4, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
										{
											SetUpSquadTableHeaders(125, "Attention", "At Ease", "Reflect");

											foreach (var c in charas)
											{
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
										if (ImGui.BeginTable("squadEmotesHunts", 3, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
										{
											SetUpSquadTableHeaders(125, "Winded", "Tremble");

											foreach (var c in charas)
											{
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
										if (ImGui.BeginTable("squadEmotesPvP", 3, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
										{
											SetUpSquadTableHeaders(125, "Elucidate", "Reprimand");

											foreach (var c in charas)
											{
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
										if (ImGui.BeginTable("squadEmotesDeep", 3, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
										{
											SetUpSquadTableHeaders(125, "Sweat", "Wow");

											foreach (var c in charas)
											{
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
										if (ImGui.BeginTable("squadEmotesEureka", 4, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
										{
											SetUpSquadTableHeaders(125, "Shiver", "Scheme", "Fist Pump");

											foreach (var c in charas)
											{
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
										if (ImGui.BeginTable("squadEmotesBozja", 4, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
										{
											SetUpSquadTableHeaders(125, "Guard", "Malevolence", "Wring Hands");

											foreach (var c in charas)
											{
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
										if (ImGui.BeginTable("squadEmotesTreasure", 6, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
										{
											SetUpSquadTableHeaders(125, "Confirm", "Paint it Black", "Paint it Red", "Paint it Yellow", "Paint it Blue");

											foreach (var c in charas)
											{
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
										if (ImGui.BeginTable("squadEmotesResto", 9, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
										{
											SetUpSquadTableHeaders(125, "Lean", "Insist", "Break Fast", "Read", "High Five", "Eat Rice Ball", "Eat Apple", "Sweep Up");

											foreach (var c in charas)
											{
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
										if (ImGui.BeginTable("squadEmotesMog", 41, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
										{
											SetUpSquadTableHeaders(125, "Bomb Dance", "Huzzah", "Eureka", "Black Ranger Pose A", "Black Ranger Pose B", "Yellow Ranger Pose A", "Yellow Ranger Pose B", "Red Ranger Pose A", "Red Ranger Pose B", "Eastern Greeting", "Dote", "Songbird", "Play Dead", "Eastern Stretch", "Eastern Dance", "Pretty Please", "Power Up", "Cheer On", "Cheer Wave", "Cheer Jump", "Megaflare", "Splash", "Crimson Lotus", "Box Step", "Side Step", "Senor Sabotender", "Get Fantasy", "Popoto Step", "Toast", "Heel Toe", "Goobbue Do", "Consider", "Flame Dance", "Wasshoi", "Flower Shower", "Pantomime", "Vexed", "Drink Tea", "Deride");

											foreach (var c in charas)
											{
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
											if (ImGui.BeginTable("squadEmotesOther", 2, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
											{
												SetUpSquadTableHeaders(125, "Headache", "Embrace");

												foreach (var c in charas)
												{
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
							if (ImGui.BeginTabItem("Hairstyles"))
							{
								ImGui.Indent();
								if (ImGui.BeginTabBar("squadHairstyles"))
								{
									if (ImGui.BeginTabItem("Gold Saucer"))
									{
										if (ImGui.BeginTable("squadhairstylesSaucer", 9, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
										{
											SetUpSquadTableHeaders(125, "Great Lengths", "Lexen-tails", "Styled for Hire", "Fashionably Feathered", "Rainmaker", "Curls", "Adventure", "Ponytails");

											foreach (var c in charas)
											{
												SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
												SetCellBackground(c.IsHairstyleUnlocked(27970) ? Green : Red);
												SetCellBackground(c.IsHairstyleUnlocked(24801) ? Green : Red);
												SetCellBackground(c.IsHairstyleUnlocked(24234) ? Green : Red);
												SetCellBackground(c.IsHairstyleUnlocked(23370) ? Green : Red);
												SetCellBackground(c.IsHairstyleUnlocked(17471) ? Green : Red);
												SetCellBackground(c.IsHairstyleUnlocked(13704) ? Green : Red);
												SetCellBackground(c.IsHairstyleUnlocked(13705) ? Green : Red);
												SetCellBackground(c.IsHairstyleUnlocked(10084) ? Green : Red);
											}
											ImGui.EndTable();
										}
										ImGui.EndTabItem();
									}
									if (ImGui.BeginTabItem("Eureka"))
									{
										if (ImGui.BeginTable("squadhairstylesEureka", 2, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
										{
											SetUpSquadTableHeaders(125, "Form and Function");

											foreach (var c in charas)
											{
												SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
												SetCellBackground(c.IsHairstyleUnlocked(24233) ? Green : Red);
											}
											ImGui.EndTable();
										}
										ImGui.EndTabItem();
									}
									if (ImGui.BeginTabItem("Bozja"))
									{
										if (ImGui.BeginTable("squadhairstylesBozja", 4, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
										{
											SetUpSquadTableHeaders(125, "Both Ways", "Early to Rise", "Wind Caller");

											foreach (var c in charas)
											{
												SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
												SetCellBackground(c.IsHairstyleUnlocked(33706) ? Green : Red);
												SetCellBackground(c.IsHairstyleUnlocked(32835) ? Green : Red);
												SetCellBackground(c.IsHairstyleUnlocked(31407) ? Green : Red);
											}
											ImGui.EndTable();
										}
										ImGui.EndTabItem();
									}
									if (ImGui.BeginTabItem("Deep Dungeon"))
									{
										if (ImGui.BeginTable("squadhairstylesDeep", 3, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
										{
											SetUpSquadTableHeaders(125, "Gyr Abanian Plait", "Samsonian Locks");

											foreach (var c in charas)
											{
												SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
												SetCellBackground(c.IsHairstyleUnlocked(23369) ? Green : Red);
												SetCellBackground(c.IsHairstyleUnlocked(16703) ? Green : Red);
											}
											ImGui.EndTable();
										}
										ImGui.EndTabItem();
									}
									if (ImGui.BeginTabItem("Ishgardian Restoration"))
									{
										if (ImGui.BeginTable("squadhairstylesResto", 4, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
										{
											SetUpSquadTableHeaders(125, "Saintly Style", "Controlled Chaos", "Modern Legend");

											foreach (var c in charas)
											{
												SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
												SetCellBackground(c.IsHairstyleUnlocked(31406) ? Green : Red);
												SetCellBackground(c.IsHairstyleUnlocked(30113) ? Green : Red);
												SetCellBackground(c.IsHairstyleUnlocked(28615) ? Green : Red);
											}
											ImGui.EndTable();
										}
										ImGui.EndTabItem();
									}
									if (ImGui.BeginTabItem("Alliance Raids"))
									{
										if (ImGui.BeginTable("squadhairstylesAlliance", 3, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
										{
											SetUpSquadTableHeaders(125, "Scanning for Style", "Battle-ready Bobs");

											foreach (var c in charas)
											{
												SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
												SetCellBackground(c.IsHairstyleUnlocked(33708) ? Green : Red);
												SetCellBackground(c.IsHairstyleUnlocked(33707) ? Green : Red);
											}
											ImGui.EndTable();
										}
										ImGui.EndTabItem();
									}
									if (ImGui.BeginTabItem("Island Sanctuary"))
									{
										if (ImGui.BeginTable("squadhairstylesAlliance", 3, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
										{
											SetUpSquadTableHeaders(125, "Practical Ponytails", "Tall Tails");

											foreach (var c in charas)
											{
												SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
												SetCellBackground(c.IsHairstyleUnlocked(38443) ? Green : Red);
												SetCellBackground(c.IsHairstyleUnlocked(38442) ? Green : Red);
											}
											ImGui.EndTable();
										}
										ImGui.EndTabItem();
									}
									if (ImGui.BeginTabItem("Mog Station"))
									{
										if (ImGui.BeginTable("squadhairstylesMog", 11, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
										{
											SetUpSquadTableHeaders(125, "Sharlayan Rebellion", "Sharlayan Studies", "Master & Commander", "Scion Special Issue", "Scion Special Issue II", "Scion Special Issue III", "Pulse", "Liberating Locks", "Clowning Around", "A Wicked Wake");

											foreach (var c in charas)
											{
												SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
												SetCellBackground(c.IsHairstyleUnlocked(39472) ? Green : Red);
												SetCellBackground(c.IsHairstyleUnlocked(32836) ? Green : Red);
												SetCellBackground(c.IsHairstyleUnlocked(17472) ? Green : Red);
												SetCellBackground(c.IsHairstyleUnlocked(13703) ? Green : Red);
												SetCellBackground(c.IsHairstyleUnlocked(15612) ? Green : Red);
												SetCellBackground(c.IsHairstyleUnlocked(15613) ? Green : Red);
												SetCellBackground(c.IsHairstyleUnlocked(14970) ? Green : Red);
												SetCellBackground(c.IsHairstyleUnlocked(36812) ? Green : Red);
												SetCellBackground(c.IsHairstyleUnlocked(36618) ? Green : Red);
												SetCellBackground(c.IsHairstyleUnlocked(28614) ? Green : Red);
											}
											ImGui.EndTable();
										}
										ImGui.EndTabItem();
									}
									ImGui.EndTabBar();
								}
								ImGui.EndTabItem();
							}
							if (ImGui.BeginTabItem("Minions"))
							{
								ImGui.Indent();
								if (ImGui.BeginTabBar("squadMinions"))
								{
									if (ImGui.BeginTabItem("Achievements"))
									{
										if (ImGui.BeginTable("squadminionsAchievement", 30, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
										{
											SetUpSquadTableHeaders(125, "Black Chocobo Chick", "Beady Eye", "Wind-up Cursor", "Wind-up Leader", "Minion of Light", "Wind-up Odin", "Wind-up Warrior of Light ", "Wind-up Goblin", "Wind-up Gilgamesh", "Wind-up Nanamo", "Wind-up Firion", "Komainu", "Mammet #003L", "Mammet #003G", "Mammet #003U", "Princely Hatchling", "Fledgling Apkallu", "Wind-up Louisoix", "Shalloweye", "Clockwork Twintania", "Penguin Prince", "Hellpup", "Faepup", "The Major-General", "Malone", "Laladile", "Much-coveted Mora", "Dolphin Calf", "Gull");

											foreach (var c in charas)
											{
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
										if (ImGui.BeginTable("squadminionsTribe", 29, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
										{
											SetUpSquadTableHeaders(125, "Wind-up Sylph", "Wind-up Violet", "Wind-up Amalj'aa", "Wind-up Founder", "Wind-up Kobold", "Wind-up Kobolder", "Wind-up Sahagin", "Wind-up Sea Devil", "Wind-up Dezul Qualan", "Wind-up Ixal", "Wind-up Gundu Warrior", "Wind-up Zundu Warrior", "Wind-up Vath", "Wind-up Gnath", "Wind-up Dragonet", "Wind-up Ohl Deeh", "Wind-up Kojin", "Wind-up Redback", "Zephyrous Zabuton", "Wind-up Ananta", "Wind-up Qalyana", "Attendee #777", "Wind-up Pixie", "The Behelmeted Serpent of Ronka", "The Behatted Serpent of Ronka", "Lalinator 5.H0", "Wind-up Arkasodara", "Lumini");

											foreach (var c in charas)
											{
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
										if (ImGui.BeginTable("squadminionsBozja", 24, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
										{
											SetUpSquadTableHeaders(125, "Mameshiba", "Koala Joey", "Salt & Pepper Seal", "Axolotl Eft", "Wind-up Ravana", "Wind-up Shinryu", "Tengu Doll", "White Whittret", "Aurelia Polyp", "Byakko Cub", "Private Moai", "Monkey King", "Mudpie (Southern Front Lockbox, Zadnor Lockbox, Saint Mocianne's Arboretum", "Scarlet Peacock", "Abroader Otter", "Seitei", "Wind-up Weapon", "Chameleon", "Sharksucker-class Insubmersible", "Magitek Helldiver F1", "DÃ¡insleif F1", "Save the Princess (Delubrum Reginae", "Wind-up Gunnhildr");

											foreach (var c in charas)
											{
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
										if (ImGui.BeginTable("squadminionsCrafted", 35, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
										{
											SetUpSquadTableHeaders(125, "Magic Broom", "Clockwork Barrow", "Model Magitek Bit", "Private Moai", "Wind-up Dullahan", "Steam-powered Gobwalker G-VII", "Bantam Train", "Gravel Golem", "Model Vanguard", "Wind-up Aldgoat", "Wind-up Qiqirn", "Plush Cushion", "Nana Bear", "Wind-up Illuminatus", "Wind-up Chimera", "Wind-up Sadu", "Wind-up Magnai", "Adventurer's Basket", "Wind-up Ifrit", "Wind-up Garuda", "Wind-up Titan", "Wind-up Leviathan", "Wind-up Ramuh", "Wind-up Shiva", "Wind-up Bismarck", "Wind-up Susano", "Wind-up Lakshmi", "Wind-up Ravana", "Wind-up Shinryu", "Byakko Cub", "Scarlet Peacock", "Seitei", "Atrophied Atomos", "Wanderer's Campfire");

											foreach (var c in charas)
											{
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
										if (ImGui.BeginTable("squadminionsDeep", 44, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
										{
											SetUpSquadTableHeaders(125, "Wind-up Tonberry", "Tiny Bulb", "Bluebird", "Minute Mindflayer", "Baby Opo-opo", "Nutkin", "Miniature Minecart", "Mummy's Little Mummy", "Gaelikitten", "Page 63", "Unicolt", "Lesser Panda", "Gestahl", "Owlet", "Ugly Duckling", "Paissa Brat", "Korpokkur Kid", "Hunting Hawk", "Wind-up Ifrit", "Morpho", "Wind-up Garuda", "Wind-up Titan", "Wind-up Leviathan", "Dwarf Rabbit", "Wind-up Ramuh", "Wind-up Shiva", "Wind-up Sasquatch", "Hecteye", "Shaggy Shoat", "Wind-up Edda", "Baby Brachiosaur", "Castaway Chocobo Chick", "Tiny Tatsunoko", "Bombfish", "Bom Boko", "Odder Otter", "Ghido", "Road Sparrow", "Wind-up Bismarck", "Wind-up Susano", "Wind-up Lakshmi", "Wind-up Ravana", "Frilled Dragon");

											foreach (var c in charas)
											{
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
										if (ImGui.BeginTable("squadminionsDungeon", 59, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
										{
											SetUpSquadTableHeaders(125, "Morbol Seedling", "Bite-sized Pudding", "Demon Brick", "Slime Puddle", "Baby Opo-opo", "Naughty Nanka", "Tight-beaked Parrot", "Mummy's Little Mummy", "Gaelikitten", "Page 63", "Unicolt", "Lesser Panda", "Owlet", "Ugly Duckling", "Korpokkur Kid", "Calca", "Brina", "Morpho", "Calamari", "Shaggy Shoat", "Bullpup", "Bombfish", "Ivon Coeurlfist Doll", "Ghido", "Road Sparrow", "Dress-up Yugiri", "Mock-up Grynewaht", "Magitek Avenger F1", "Salt & Pepper Seal", "White Whittret", "Monkey King", "Mudpie", "Wind-up Weapon", "Armadillo Bowler", "Clionid Larva", "Tiny Echevore", "Forgiven Hate", "Black Hayate", "Chameleon", "Shoebill", "Little Leannan", "Ancient One", "Ephemeral Necromancer", "Drippy", "Magitek Predator F1", "Prince Lunatender", "Tiny Troll", "Wind-up Magus Sisters", "Wind-up Anima", "Hippo Calf", "Caduceus", "Starbird", "Optimus Omicron", "Teacup Kapikulu", "Wind-up Scarmiglione", "Sponge Silkie", "Sewer Skink", "Wind-up Cagnazzo");

											foreach (var c in charas)
											{
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
										if (ImGui.BeginTable("squadminionsEureka", 11, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
										{
											SetUpSquadTableHeaders(125, "Calca", "Wind-up Fafnir", "The Prince Of Anemos", "Wind-up Mithra", "Copycat Bulb", "Wind-up Tarutaru", "Dhalmel Calf", "Wind-up Elvaan", "Conditional Virtue", "Yukinko Snowflake");

											foreach (var c in charas)
											{
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
										if (ImGui.BeginTable("squadminionsFate", 16, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
										{
											SetUpSquadTableHeaders(125, "Baby Bun", "Infant Imp", "Pudgy Puk", "Smallshell", "Gold Rush Minecart", "Fox Kit", "Wind-up Ixion", "Micro Gigantender", "Butterfly Effect", "Ironfrog Ambler", "Tinker's Bell", "Little Leafman", "Amaro Hatchling", "Wee Ea", "Wind-up Daivadipa");

											foreach (var c in charas)
											{
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
										if (ImGui.BeginTable("squadminionsGather", 8, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
										{
											SetUpSquadTableHeaders(125, "Tiny Tortoise", "Gigantpole", "Kidragora", "Coblyn Larva", "Magic Bucket", "Castaway Chocobo Chick", "Tiny Tatsunoko");

											foreach (var c in charas)
											{
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
										if (ImGui.BeginTable("squadminionsMog", 47, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
										{
											SetUpSquadTableHeaders(125, "Baby Behemoth", "Tender Lamb", "Wind-up Edvya", "Wind-up Shantotto", "Wind-up Moogle", "Wind-up Minfilia", "Wind-up Thancred", "Wind-up Y'shtola", "Wind-up Yda", "Wind-up Papalymo", "Wind-up Urianger", "Hoary The Snowman", "Wind-up Kain", "Wind-up Alisaie", "Wind-up Tataru", "Wind-up Iceheart", "Pumpkin Butler", "Wind-up Yugiri", "Panda Cub", "Doman Magpie", "Dress-up Y'shtola", "Wind-up Krile", "Continental Eye", "Wind-up Rikku", "Wind-up Lulu", "Angel Of Mercy", "Wind-up Yuna", "Wind-up Bartz", "Wind-up Lyse", "Wind-up Gosetsu", "Motley Egg", "Wind-up Cirina", "Little Yin", "Little Yang", "Wind-up Tifa", "Wind-up Cloud", "Wind-up Aerith", "Wind-up Fran", "Brave New Y'shtola", "Wind-up Ardbert", "Wind-up Edge", "Wind-up Rydia", "Wind-up Rosa", "Wind-up Rudy", "Squirrel Emperor", "Wind-up Porom");

											foreach (var c in charas)
											{
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
										if (ImGui.BeginTable("squadminionsPvp", 6, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
										{
											SetUpSquadTableHeaders(125, "Fenrir Pup", "Wind-up Cheerleader", "Clockwork Lantern", "Minitek Conveyor", "Protonaught");

											foreach (var c in charas)
											{
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
										if (ImGui.BeginTable("squadminionsQuest", 15, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
										{
											SetUpSquadTableHeaders(125, "Chigoe Larva", "Cactuar Cutting", "Goobbue Sproutling", "Coeurl Kitten", "Wolf Pup", "Mini Mole", "Wind-up Gentleman", "Accompaniment Node", "Gigi", "Anima", "Palico", "Wind-up Alpha", "The Great Serpent Of Ronka", "Golden Dhyata");

											foreach (var c in charas)
											{
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
										if (ImGui.BeginTable("squadminionsRaid", 26, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
										{
											SetUpSquadTableHeaders(125, "Wind-up Onion Knight", "Puff Of Darkness", "Wind-up Echidna", "Faustlet", "Wind-up Calofisteri", "Toy Alexander", "Wind-up Scathach", "Wind-up Exdeath", "Wind-up Kefka", "Construct 8", "OMG", "Wind-up Ramza", "Eden Minor", "Pod 054", "Pod 316", "Wind-up Ryne", "2B Automaton", "2P Automaton", "Wind-up Gaia", "Smaller Stubby", "9S Automaton", "Nosferatu", "Wind-up Azeyma", "Wind-up Erichthonios", "Wind-up Halone");

											foreach (var c in charas)
											{
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
										if (ImGui.BeginTable("squadminionsSkybuilder", 25, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
										{
											SetUpSquadTableHeaders(125, "Plush Cushion", "Nutkin", "Atrophied Atomos", "Gaelikitten", "Owlet", "Ugly Duckling", "Clockwork Barrow", "Paissa Brat", "Hunting Hawk", "Morpho", "Calamari", "Dwarf Rabbit", "Shaggy Shoat", "Bullpup", "Baby Brachiosaur", "Pegasus Colt", "Miniature White Knight", "Dress-up Estinien", "Paissa Patissier", "Paissa Threadpuller", "Cerberpup", "Weatherproof Gaelicat", "Petit Pteranodon", "Trike");

											foreach (var c in charas)
											{
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
										if (ImGui.BeginTable("squadminionsTreasure", 28, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
										{
											SetUpSquadTableHeaders(125, "Wind-up Tonberry", "Tiny Bulb", "Bluebird", "Minute Mindflayer", "Baby Opo-opo", "Nutkin", "Tight-beaked Parrot", "Mummy's Little Mummy", "Gaelikitten", "Page 63", "Unicolt", "Lesser Panda", "Owlet", "Ugly Duckling", "Paissa Brat", "Dwarf Rabbit", "Wind-up Namazu", "Wind-up Matanga", "The Gold Whisker", "Capybara Pup", "Hedgehoglet", "Wind-up Fuath", "Sungold Talos", "Golden Beaver", "Royal Lunatender", "Wind-up Aidoneus", "Wind-up Philos");

											foreach (var c in charas)
											{
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
										if (ImGui.BeginTable("squadminionsTrial", 5, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
										{
											SetUpSquadTableHeaders(125, "Wind-up Ultros", "Enkidu", "Poogie", "Giant Beaver");

											foreach (var c in charas)
											{
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
										if (ImGui.BeginTable("squadminionsVenture", 26, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
										{
											SetUpSquadTableHeaders(125, "Minute Mindflayer", "Tiny Tapir", "Miniature Minecart", "Littlefoot", "Fat Cat", "Gestahl", "Bom Boko", "Odder Otter", "Mameshiba", "Koala Joey", "Axolotl Eft", "Tengu Doll", "Bacon Bits", "Mystic Weapon", "Domakin", "Wind-up Hobgoblin", "Allagan Melon", "Greener Gleaner", "Flag", "Crabe De La Crabe", "Wind-up Grebuloff", "Wind-up Kangaroo", "Chewy", "Blue-footed Booby", "Clockwork Novus D");

											foreach (var c in charas)
											{
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
										if (ImGui.BeginTable("squadminionsVoyage", 9, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
										{
											SetUpSquadTableHeaders(125, "Aurelia Polyp", "Abroader Otter", "Sharksucker-class Insubmersible", "Meerkat", "Silver Dasher", "Syldrion-class Insubmersible", "Benben Stone", "Suzusaurus");

											foreach (var c in charas)
											{
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
										if (ImGui.BeginTable("squadminionsTails", 14, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
										{
											SetUpSquadTableHeaders(125, "Dress-up Thancred", "Dress-up Alisaie", "Wind-up Estinien", "Wind-up Khloe", "Wind-up Hien", "Wind-up Zhloe", "Wind-up Omega-M", "Wind-up Omega-F", "Sand Fox", "Anteater", "Brave New Urianger", "Pterosquirrel", "Corgi");

											foreach (var c in charas)
											{
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
												if (ImGui.BeginTable("squadminionsGil", 7, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
												{
													SetUpSquadTableHeaders(125, "Wayward Hatchling", "Cherry Bomb", "Tiny Rat", "Baby Raptor", "Baby Bat", "Mammet #001");

													foreach (var c in charas)
													{
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
												if (ImGui.BeginTable("squadminionsSaucer", 9, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
												{
													SetUpSquadTableHeaders(125, "Zu Hatchling", "Heavy Hatchling", "Black Coeurl", "Water Imp", "Wind-up Nero Tol Scaeva", "Piggy", "Wind-up Daivadipa", "Mama Automaton");

													foreach (var c in charas)
													{
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
												if (ImGui.BeginTable("squadminionsPoetics", 4, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
												{
													SetUpSquadTableHeaders(125, "Wide-eyed Fawn", "Dust Bunny", "Fledgling Dodo");

													foreach (var c in charas)
													{
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
												if (ImGui.BeginTable("squadminionsHunts", 11, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
												{
													SetUpSquadTableHeaders(125, "Wind-up Succubus", "Treasure Box", "Behemoth Heir", "Griffin Hatchling", "Tora-jiro", "Wind-up Meateater", "Bitty Duckbill", "Cute Justice", "Nagxian Cat", "Wind-up Nu Mou");

													foreach (var c in charas)
													{
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
												if (ImGui.BeginTable("squadminionsGc", 4, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
												{
													SetUpSquadTableHeaders(125, "Storm Hatchling", "Serpent Hatchling", "Flame Hatchling");

													foreach (var c in charas)
													{
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
												if (ImGui.BeginTable("squadminionsSanctuary", 3, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
												{
													SetUpSquadTableHeaders(125, "Felicitous Fuzzball", "Sky Blue Back");

													foreach (var c in charas)
													{
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
												if (ImGui.BeginTable("squadminionsOther", 3, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
												{
													SetUpSquadTableHeaders(125, "Wind-up Sun", "Wind-up Moon");

													foreach (var c in charas)
													{
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
							if (ImGui.BeginTabItem("Mounts"))
							{
								ImGui.Indent();
								if (ImGui.BeginTabBar("squadMounts"))
								{
									if (ImGui.BeginTabItem("Achievements"))
									{
										if (ImGui.BeginTable("squadmountsAchievement", 40, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
										{
											SetUpSquadTableHeaders(125, "Ahriman", "Behemoth", "Gilded Magitek Armor", "Warlion", "Warbear", "Storm Warsteed", "Serpent Warsteed", "Flame Warsteed", "Parade Chocobo", "Logistics System", "War Panther", "Gloria-class Airship", "Astrope", "Aerodynamics System", "Goten", "Ginga", "Raigo", "Battle Lion", "Battle Bear", "Battle Panther", "Centurio Tiger", "Magitek Avenger", "Magitek Death Claw", "Safeguard System", "Juedi", "Magitek Avenger A1", "Demi-Ozma", "War Tiger", "Triceratops", "Amaro", "Battle Tiger", "Morbol", "Construct VII", "Hybodus", "Pteranodon", "Cerberus", "Al-iklil", "Victor", "Silkie");

											foreach (var c in charas)
											{
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
										if (ImGui.BeginTable("squadmountsTribe", 18, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
										{
											SetUpSquadTableHeaders(125, "Cavalry Drake", "Laurel Goobbue", "Cavalry Elbst", "Bomb Palanquin", "Direwolf", "Sanuwa", "Kongamato", "Cloud Mallow", "Striped Ray", "Marid", "True Griffin", "Mikoshi", "Portly Porxie", "Great Vessel Of Ronka", "Rolling Tankard", "Hippo Cart", "Miw Miisv");

											foreach (var c in charas)
											{
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
										if (ImGui.BeginTable("squadmountsBozja", 5, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
										{
											SetUpSquadTableHeaders(125, "Construct 14", "Gabriel Î‘", "Gabriel Mark III", "Deinonychus");

											foreach (var c in charas)
											{
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
										if (ImGui.BeginTable("squadmountsCrafted", 3, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
										{
											SetUpSquadTableHeaders(125, "Flying Chair", "Magicked Bed");

											foreach (var c in charas)
											{
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
										if (ImGui.BeginTable("squadmountsDeep", 5, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
										{
											SetUpSquadTableHeaders(125, "Disembodied Head", "Black Pegasus", "Dodo", "Sil'dihn Throne");

											foreach (var c in charas)
											{
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
										if (ImGui.BeginTable("squadmountsDungeon", 2, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
										{
											SetUpSquadTableHeaders(125, "Magitek Predator");

											foreach (var c in charas)
											{
												SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
												SetCellBackground(c.IsMountUnlocked(121) ? Green : Red);
											}
											ImGui.EndTable();
										}
										ImGui.EndTabItem();
									}
									if (ImGui.BeginTabItem("Eureka"))
									{
										if (ImGui.BeginTable("squadmountsEureka", 4, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
										{
											SetUpSquadTableHeaders(125, "Tyrannosaur", "Eldthurs", "Eurekan Petrel");

											foreach (var c in charas)
											{
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
										if (ImGui.BeginTable("squadmountsFate", 5, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
										{
											SetUpSquadTableHeaders(125, "Ixion", "Ironfrog Mover", "Level Checker", "Wivre");

											foreach (var c in charas)
											{
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
										if (ImGui.BeginTable("squadmountsMog", 49, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
										{
											SetUpSquadTableHeaders(125, "Coeurl", "Fat Chocobo", "Draught Chocobo", "Sleipnir", "Ceremony Chocobo", "Griffin", "Amber Draught Chocobo", "Twintania", "Witch's Broom", "White Devil", "Red Baron", "Original Fat Chocobo", "Bennu", "Fat Moogle", "Eggshilaration System", "Syldra", "Managarm", "Mystic Panda", "Starlight Bear", "Aquamarine Carbuncle", "Citrine Carbuncle", "Nezha Chariot", "Broken Heart", "Broken Heart", "Red Hare", "Indigo Whale", "SDS Fenrir", "Fatter Cat", "Fat Black Chocobo", "Magicked Carpet", "Grani", "Circus Ahriman", "Sunspun Cumulus", "Spriggan Stonecarrier", "Kingly Peacock", "Rubellite Carbuncle", "Chocobo Carriage", "Snowman", "Lunar Whale", "Polar Bear", "Cruise Chaser", "Arion", "Papa Paissa", "Megashiba", "Mechanical Lotus", "Magicked Umbrella", "Magicked Parasol", "Set Of Ceruleum Balloons");

											foreach (var c in charas)
											{
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
										if (ImGui.BeginTable("squadmountsPvp", 2, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
										{
											SetUpSquadTableHeaders(125, "Magitek Sky Armor", "Unicorn", "Kirin", "Firebird", "Kamuy Of The Nine Tails", "Ehll Tou", "Landerwaffe", "Magicked Card", "Argos", "Anden III");

											foreach (var c in charas)
											{
												SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
												SetCellBackground(c.IsMountUnlocked(15) ? Green : Red);
												SetCellBackground(c.IsMountUnlocked(47) ? Green : Red);
												SetCellBackground(c.IsMountUnlocked(105) ? Green : Red);
												SetCellBackground(c.IsMountUnlocked(181) ? Green : Red);
												SetCellBackground(c.IsMountUnlocked(230) ? Green : Red);
												SetCellBackground(c.IsMountUnlocked(245) ? Green : Red);
												SetCellBackground(c.IsMountUnlocked(254) ? Green : Red);
												SetCellBackground(c.IsMountUnlocked(263) ? Green : Red);
												SetCellBackground(c.IsMountUnlocked(311) ? Green : Red);
											}
											ImGui.EndTable();
										}
										ImGui.EndTabItem();
									}
									if (ImGui.BeginTabItem("Raid"))
									{
										if (ImGui.BeginTable("squadmountsRaid", 11, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
										{
											SetUpSquadTableHeaders(125, "Gobwalker", "Arrhidaeus", "Alte Roite", "Air Force", "Model O", "Skyslipper", "Ramuh", "Eden", "Demi-Phoinix", "Sunforged");

											foreach (var c in charas)
											{
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
										if (ImGui.BeginTable("squadmountsSkybuilder", 9, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
										{
											SetUpSquadTableHeaders(125, "Pegasus", "Ufiti", "Dhalmel", "Albino Karakul", "Megalotragus", "Big Shell", "Antelope Doe", "Antelope Stag");

											foreach (var c in charas)
											{
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
										if (ImGui.BeginTable("squadmountsTreasure", 4, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
										{
											SetUpSquadTableHeaders(125, "Alkonost", "Phaethon", "Pinky");

											foreach (var c in charas)
											{
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
										if (ImGui.BeginTable("squadmountsTrial", 35, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
										{
											SetUpSquadTableHeaders(125, "Nightmare", "Aithon", "Xanthos", "Gullfaxi", "Enbarr", "Markab", "Boreas", "White Lanner", "Rose Lanner", "Round Lanner", "Warring Lanner", "Dark Lanner", "Sophic Lanner", "Demonic Lanner", "Blissful Kamuy", "Reveling Kamuy", "Legendary Kamuy", "Auspicious Kamuy", "Lunar Kamuy", "Rathalos", "Euphonious Kamuy", "Hallowed Kamuy", "Fae Gwiber", "Innocent Gwiber", "Shadow Gwiber", "Ruby Gwiber", "Gwiber Of Light", "Emerald Gwiber", "Diamond Gwiber", "Lynx Of Eternal Darkness", "Lynx Of Divine Light", "Bluefeather Lynx", "Lynx Of Imperious Wind", "Lynx Of Righteous Fire");

											foreach (var c in charas)
											{
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
										if (ImGui.BeginTable("squadmountsVoyage", 2, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
										{
											SetUpSquadTableHeaders(125, "Zu");

											foreach (var c in charas)
											{
												SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
												SetCellBackground(c.IsMountUnlocked(73) ? Green : Red);
											}
											ImGui.EndTable();
										}
										ImGui.EndTabItem();
									}
									if (ImGui.BeginTabItem("Wondrous Tails/Faux Hollows"))
									{
										if (ImGui.BeginTable("squadmountsTails", 7, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
										{
											SetUpSquadTableHeaders(125, "Ixion", "Incitatus", "Construct VI-S", "Calydontis", "Troll", "Wondrous Lanner");

											foreach (var c in charas)
											{
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
												if (ImGui.BeginTable("squadmountsGil", 5, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
												{
													SetUpSquadTableHeaders(125, "Gilded Mikoshi", "Resplendent Vessel Of Ronka", "Magitek Avenger G1", "Chrysomallos");

													foreach (var c in charas)
													{
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
												if (ImGui.BeginTable("squadmountsSaucer", 9, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
												{
													SetUpSquadTableHeaders(125, "Adamantoise", "Fenrir", "Archon Throne", "Korpokkur Kolossus", "Typhon", "Sabotender Emperador", "Pod 602", "Blackjack");

													foreach (var c in charas)
													{
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
												if (ImGui.BeginTable("squadmountsHunts", 4, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
												{
													SetUpSquadTableHeaders(125, "Wyvern", "Forgiven Reticence", "Vinegaroon");

													foreach (var c in charas)
													{
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
												if (ImGui.BeginTable("squadmountsSanctuary", 6, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
												{
													SetUpSquadTableHeaders(125, "Garlond GL-II", "Island Mandragora", "Island Onion Prince", "Island Eggplant Knight", "Island Alligator");

													foreach (var c in charas)
													{
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
							if (ImGui.BeginTabItem("Optional Content"))
							{
								ImGui.Indent();
								if (ImGui.BeginTabBar("squadOptionalContent"))
								{
									if (ImGui.BeginTabItem("General"))
									{
										if (ImGui.BeginTable("squadoptionalGeneral", 11, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
										{
											SetUpSquadTableHeaders(300, "Mist", "Lavender Beds", "The Goblet", "Shirogane", "Empyreum", "Crystalline Conflict", "Frontlines", "Rival Wings", "Wondrous Tails", "Faux Hollows");

											foreach (var c in charas)
											{
												SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
												SetCellBackground(c.IsQuestComplete(66750) ? Green : Red);
												SetCellBackground(c.IsQuestComplete(66748) ? Green : Red);
												SetCellBackground(c.IsQuestComplete(66749) ? Green : Red);
												SetCellBackground(c.IsQuestComplete(68167) ? Green : Red);
												SetCellBackground(c.IsQuestComplete(69708) ? Green : Red);
												SetCellBackground(c.IsQuestComplete(66640) || c.IsQuestComplete(66640) || c.IsQuestComplete(66640) ? Green : Red);
												SetCellBackground(c.IsQuestComplete(67063) || c.IsQuestComplete(67064) || c.IsQuestComplete(67065) ? Green : Red);
												SetCellBackground(c.IsQuestComplete(68583) ? Green : Red);
												SetCellBackground(c.IsQuestComplete(67928) ? Green : Red);
												SetCellBackground(c.IsQuestComplete(69501) ? Green : Red);
											}
											ImGui.EndTable();
										}
										ImGui.EndTabItem();
									}
									if (ImGui.BeginTabItem("A Realm Reborn"))
									{
										ImGui.Indent();
										if (ImGui.BeginTabBar("squadARealmReborn"))
										{
											if (ImGui.BeginTabItem("Dungeons"))
											{
												if (ImGui.BeginTable("squadDungeonsArr", 21, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
												{
													SetUpSquadTableHeaders(300, "Halatali", "The Sunken Temple of Qarn", "Cutter's Cry", "Dzemael Darkhold", "The Aurum Vale", "Amdapor Keep", "The Wanderer's Palace", "Copperbell Mines (Hard)", "Haukke Manor (Hard)", "Pharos Sirius", "Brayflox's Longstop (Hard)", "Halatali (Hard)", "The Lost City of Amdapor (Hard)", "Hullbreaker Isle", "The Stone Vigil (Hard)", "The Tam-Tara Deepcroft (Hard)", "Sastasha (Hard)", "The Sunken Temple of Qarn (Hard)", "Amdapor Keep (Hard)", "The Wanderer's Palace (Hard)");

													foreach (var c in charas)
													{
														SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
														SetCellBackground(c.IsInstanceUnlocked(7) ? Green : Red);
														SetCellBackground(c.IsInstanceUnlocked(9) ? Green : Red);
														SetCellBackground(c.IsInstanceUnlocked(12) ? Green : Red);
														SetCellBackground(c.IsInstanceUnlocked(13) ? Green : Red);
														SetCellBackground(c.IsInstanceUnlocked(5) ? Green : Red);
														SetCellBackground(c.IsInstanceUnlocked(14) ? Green : Red);
														SetCellBackground(c.IsInstanceUnlocked(7) ? Green : Red);
														SetCellBackground(c.IsInstanceUnlocked(18) ? Green : Red);
														SetCellBackground(c.IsInstanceUnlocked(19) ? Green : Red);
														SetCellBackground(c.IsInstanceUnlocked(17) ? Green : Red);
														SetCellBackground(c.IsInstanceUnlocked(20) ? Green : Red);
														SetCellBackground(c.IsInstanceUnlocked(21) ? Green : Red);
														SetCellBackground(c.IsInstanceUnlocked(22) ? Green : Red);
														SetCellBackground(c.IsInstanceUnlocked(23) ? Green : Red);
														SetCellBackground(c.IsInstanceUnlocked(25) ? Green : Red);
														SetCellBackground(c.IsInstanceUnlocked(24) ? Green : Red);
														SetCellBackground(c.IsInstanceUnlocked(28) ? Green : Red);
														SetCellBackground(c.IsInstanceUnlocked(26) ? Green : Red);
														SetCellBackground(c.IsInstanceUnlocked(29) ? Green : Red);
														SetCellBackground(c.IsInstanceUnlocked(30) ? Green : Red);
													}
													ImGui.EndTable();
												}
												ImGui.EndTabItem();
											}
											if (ImGui.BeginTabItem("Trials"))
											{
												if (ImGui.BeginTable("squadTrialsArr", 15, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
												{
													SetUpSquadTableHeaders(300, "Battle on the Big Bridge", "A Relic Reborn: The Chimera", "A Relic Reborn: The Hydra", "The Minstrel's Ballad: Ultima's Bane", "The Howling Eye (Extreme)", "The Navel (Extreme)", "The Bowl of Embers (Extreme)", "The Dragon's Neck", "The Whorleater (Extreme)", "Thornmarch (Extreme)", "The Striking Tree (Extreme)", "Battle in the Big Keep", "Akh Afah Amphitheatre (Extreme)", "Urth's Fount");

													foreach (var c in charas)
													{
														SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
														SetCellBackground(c.IsInstanceUnlocked(20021) ? Green : Red);
														SetCellBackground(c.IsInstanceUnlocked(20019) ? Green : Red);
														SetCellBackground(c.IsInstanceUnlocked(20020) ? Green : Red);
														SetCellBackground(c.IsInstanceUnlocked(20013) ? Green : Red);
														SetCellBackground(c.IsInstanceUnlocked(20010) ? Green : Red);
														SetCellBackground(c.IsInstanceUnlocked(20009) ? Green : Red);
														SetCellBackground(c.IsInstanceUnlocked(20008) ? Green : Red);
														SetCellBackground(c.IsInstanceUnlocked(20026) ? Green : Red);
														SetCellBackground(c.IsInstanceUnlocked(20018) ? Green : Red);
														SetCellBackground(c.IsInstanceUnlocked(20012) ? Green : Red);
														SetCellBackground(c.IsInstanceUnlocked(20023) ? Green : Red);
														SetCellBackground(c.IsInstanceUnlocked(20030) ? Green : Red);
														SetCellBackground(c.IsInstanceUnlocked(20025) ? Green : Red);
														SetCellBackground(c.IsInstanceUnlocked(20027) ? Green : Red);
													}
													ImGui.EndTable();
												}
												ImGui.EndTabItem();
											}
											if (ImGui.BeginTabItem("Raids"))
											{
												if (ImGui.BeginTable("squadRaidsArr", 18, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
												{
													SetUpSquadTableHeaders(300, "The Binding Coil of Bahamut - Turn 1", "The Binding Coil of Bahamut - Turn 2", "The Binding Coil of Bahamut - Turn 3", "The Binding Coil of Bahamut - Turn 4", "The Binding Coil of Bahamut - Turn 5", "The Second Coil of Bahamut - Turn 1", "The Second Coil of Bahamut - Turn 2", "The Second Coil of Bahamut - Turn 3", "The Second Coil of Bahamut - Turn 4", "The Second Coil of Bahamut - Turn 1 (Savage)", "The Second Coil of Bahamut - Turn 2 (Savage)", "The Second Coil of Bahamut - Turn 3 (Savage)", "The Second Coil of Bahamut - Turn 4 (Savage)", "The Final Coil of Bahamut - Turn 1", "The Final Coil of Bahamut - Turn 2", "The Final Coil of Bahamut - Turn 3", "The Final Coil of Bahamut - Turn 4");

													foreach (var c in charas)
													{
														SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
														SetCellBackground(c.IsInstanceUnlocked(30002) ? Green : Red);
														SetCellBackground(c.IsInstanceUnlocked(30003) ? Green : Red);
														SetCellBackground(c.IsInstanceUnlocked(30004) ? Green : Red);
														SetCellBackground(c.IsInstanceUnlocked(30005) ? Green : Red);
														SetCellBackground(c.IsInstanceUnlocked(30006) ? Green : Red);
														SetCellBackground(c.IsInstanceUnlocked(30007) ? Green : Red);
														SetCellBackground(c.IsInstanceUnlocked(30008) ? Green : Red);
														SetCellBackground(c.IsInstanceUnlocked(30009) ? Green : Red);
														SetCellBackground(c.IsInstanceUnlocked(30010) ? Green : Red);
														SetCellBackground(c.IsInstanceUnlocked(30012) ? Green : Red);
														SetCellBackground(c.IsInstanceUnlocked(30013) ? Green : Red);
														SetCellBackground(c.IsInstanceUnlocked(30014) ? Green : Red);
														SetCellBackground(c.IsInstanceUnlocked(30015) ? Green : Red);
														SetCellBackground(c.IsInstanceUnlocked(30016) ? Green : Red);
														SetCellBackground(c.IsInstanceUnlocked(30017) ? Green : Red);
														SetCellBackground(c.IsInstanceUnlocked(30018) ? Green : Red);
														SetCellBackground(c.IsInstanceUnlocked(30019) ? Green : Red);
													}
													ImGui.EndTable();
												}
												ImGui.EndTabItem();
											}
											ImGui.EndTabBar();
											ImGui.Unindent();
										}
										ImGui.EndTabItem();
									}
									if (ImGui.BeginTabItem("Heavensward"))
									{
										ImGui.Indent();
										if (ImGui.BeginTabBar("squadHeavensward"))
										{
											if (ImGui.BeginTabItem("Dungeons"))
											{
												if (ImGui.BeginTable("squadDungeonsHw", 11, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
												{
													SetUpSquadTableHeaders(300, "The Dusk Vigil", "Neverreap", "The Fractal Continuum", "Saint Mocianne's Arboretum", "Pharos Sirius (Hard)", "The Lost City of Amdapor (Hard)", "Hullbreaker Isle (Hard)", "The Great Gubal Library (Hard)", "Sohm Al (Hard)", "The Palace of the Dead");

													foreach (var c in charas)
													{
														SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
														SetCellBackground(c.IsInstanceUnlocked(36) ? Green : Red);
														SetCellBackground(c.IsInstanceUnlocked(33) ? Green : Red);
														SetCellBackground(c.IsInstanceUnlocked(35) ? Green : Red);
														SetCellBackground(c.IsInstanceUnlocked(41) ? Green : Red);
														SetCellBackground(c.IsInstanceUnlocked(40) ? Green : Red);
														SetCellBackground(c.IsInstanceUnlocked(42) ? Green : Red);
														SetCellBackground(c.IsInstanceUnlocked(45) ? Green : Red);
														SetCellBackground(c.IsInstanceUnlocked(47) ? Green : Red);
														SetCellBackground(c.IsInstanceUnlocked(49) ? Green : Red);
														SetCellBackground(c.IsQuestComplete(67092) ? Green : Red);
													}
													ImGui.EndTable();
												}
												ImGui.EndTabItem();
											}
											if (ImGui.BeginTabItem("Trials"))
											{
												if (ImGui.BeginTable("squadTrialsHw", 11, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
												{
													SetUpSquadTableHeaders(300, "The Limitless Blue (Extreme)", "Thok ast Thok (Extreme)", "Containment Bay S1T7", "The Minstrel's Ballad: Thordan's Reign", "Containment Bay S1T7 (Extreme)", "Containment Bay P1T6", "The Minstrel's Ballad: Nidhogg's Rage", "Containment Bay P1T6 (Extreme)", "Containment Bay Z1T9", "Containment Bay Z1T9 (Extreme)");

													foreach (var c in charas)
													{
														SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
														SetCellBackground(c.IsInstanceUnlocked(20034) ? Green : Red);
														SetCellBackground(c.IsInstanceUnlocked(20032) ? Green : Red);
														SetCellBackground(c.IsInstanceUnlocked(20037) ? Green : Red);
														SetCellBackground(c.IsInstanceUnlocked(20036) ? Green : Red);
														SetCellBackground(c.IsInstanceUnlocked(20038) ? Green : Red);
														SetCellBackground(c.IsInstanceUnlocked(20041) ? Green : Red);
														SetCellBackground(c.IsInstanceUnlocked(20040) ? Green : Red);
														SetCellBackground(c.IsInstanceUnlocked(20042) ? Green : Red);
														SetCellBackground(c.IsInstanceUnlocked(20043) ? Green : Red);
														SetCellBackground(c.IsInstanceUnlocked(20044) ? Green : Red);
													}
													ImGui.EndTable();
												}
												ImGui.EndTabItem();
											}
											if (ImGui.BeginTabItem("Raids"))
											{
												ImGui.Indent();
												if (ImGui.BeginTabBar("squadRaids"))
												{
													if (ImGui.BeginTabItem("Normal Raids"))
													{
														if (ImGui.BeginTable("squadNormalRaidsHw", 25, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
														{
															SetUpSquadTableHeaders(300, "Alexander - The Fist of the Father", "Alexander - The Cuff of the Father", "Alexander - The Arm of the Father", "Alexander - The Burden of the Father", "Alexander - The Fist of the Father (Savage)", "Alexander - The Cuff of the Father (Savage)", "Alexander - The Arm of the Father (Savage)", "Alexander - The Burden of the Father (Savage)", "Alexander - The Fist of the Son", "Alexander - The Cuff of the Son", "Alexander - The Arm of the Son", "Alexander - The Burden of the Son (Savage)", "Alexander - The Fist of the Son (Savage)", "Alexander - The Cuff of the Son (Savage)", "Alexander - The Arm of the Son (Savage)", "Alexander - The Burden of the Son (Savage)", "Alexander - The Eyes of the Creator", "Alexander - The Breath of the Creator", "Alexander - The Heart of the Creator", "Alexander - The Soul of the Creator", "Alexander - The Eyes of the Creator (Savage)", "Alexander - The Breath of the Creator (Savage)", "Alexander - The Heart of the Creator (Savage)", "Alexander - The Soul of the Creator (Savage)");

															foreach (var c in charas)
															{
																SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
																SetCellBackground(c.IsInstanceUnlocked(30021) ? Green : Red);
																SetCellBackground(c.IsInstanceUnlocked(30022) ? Green : Red);
																SetCellBackground(c.IsInstanceUnlocked(30023) ? Green : Red);
																SetCellBackground(c.IsInstanceUnlocked(30024) ? Green : Red);
																SetCellBackground(c.IsInstanceUnlocked(30025) ? Green : Red);
																SetCellBackground(c.IsInstanceUnlocked(30026) ? Green : Red);
																SetCellBackground(c.IsInstanceUnlocked(30027) ? Green : Red);
																SetCellBackground(c.IsInstanceUnlocked(30028) ? Green : Red);
																SetCellBackground(c.IsInstanceUnlocked(30030) ? Green : Red);
																SetCellBackground(c.IsInstanceUnlocked(30031) ? Green : Red);
																SetCellBackground(c.IsInstanceUnlocked(30032) ? Green : Red);
																SetCellBackground(c.IsInstanceUnlocked(30033) ? Green : Red);
																SetCellBackground(c.IsInstanceUnlocked(30034) ? Green : Red);
																SetCellBackground(c.IsInstanceUnlocked(30035) ? Green : Red);
																SetCellBackground(c.IsInstanceUnlocked(30036) ? Green : Red);
																SetCellBackground(c.IsInstanceUnlocked(30037) ? Green : Red);
																SetCellBackground(c.IsInstanceUnlocked(30039) ? Green : Red);
																SetCellBackground(c.IsInstanceUnlocked(30040) ? Green : Red);
																SetCellBackground(c.IsInstanceUnlocked(30041) ? Green : Red);
																SetCellBackground(c.IsInstanceUnlocked(30042) ? Green : Red);
																SetCellBackground(c.IsInstanceUnlocked(30043) ? Green : Red);
																SetCellBackground(c.IsInstanceUnlocked(30044) ? Green : Red);
																SetCellBackground(c.IsInstanceUnlocked(30045) ? Green : Red);
																SetCellBackground(c.IsInstanceUnlocked(30046) ? Green : Red);
															}
															ImGui.EndTable();
														}
														ImGui.EndTabItem();
													}
													if (ImGui.BeginTabItem("Alliance Raids"))
													{
														if (ImGui.BeginTable("squadAllianceRaidsHw", 4, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
														{
															SetUpSquadTableHeaders(300, "The Void Ark", "The Weeping City of Mhach", "Dun Scaith");

															foreach (var c in charas)
															{
																SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
																SetCellBackground(c.IsInstanceUnlocked(30029) ? Green : Red);
																SetCellBackground(c.IsInstanceUnlocked(30038) ? Green : Red);
																SetCellBackground(c.IsInstanceUnlocked(30047) ? Green : Red);
															}
															ImGui.EndTable();
														}
														ImGui.EndTabItem();
													}
													ImGui.EndTabBar();
													ImGui.Unindent();
												}
												ImGui.EndTabItem();
											}
											ImGui.EndTabBar();
											ImGui.Unindent();
										}
										ImGui.EndTabItem();
									}
									if (ImGui.BeginTabItem("Stormblood"))
									{
										ImGui.Indent();
										if (ImGui.BeginTabBar("squadStormblood"))
										{
											if (ImGui.BeginTabItem("Dungeons"))
											{
												if (ImGui.BeginTable("squadDungeonsSb", 9, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
												{
													SetUpSquadTableHeaders(300, "Shisui of the Violet Tides", "Kugane Castle", "The Temple of the Fist", "Hell's Lid", "The Fractal Continuum (Hard)", "The Swallow's Compass", "Saint Mocianne's Arboretum (Hard)", "Heaven-on-High");

													foreach (var c in charas)
													{
														SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
														SetCellBackground(c.IsInstanceUnlocked(50) ? Green : Red);
														SetCellBackground(c.IsInstanceUnlocked(57) ? Green : Red);
														SetCellBackground(c.IsInstanceUnlocked(51) ? Green : Red);
														SetCellBackground(c.IsInstanceUnlocked(59) ? Green : Red);
														SetCellBackground(c.IsInstanceUnlocked(60) ? Green : Red);
														SetCellBackground(c.IsInstanceUnlocked(61) ? Green : Red);
														SetCellBackground(c.IsInstanceUnlocked(62) ? Green : Red);
														SetCellBackground(c.IsQuestComplete(68667) ? Green : Red);
													}
													ImGui.EndTable();
												}
												ImGui.EndTabItem();
											}
											if (ImGui.BeginTabItem("Trials"))
											{
												if (ImGui.BeginTable("squadTrialsSb", 14, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
												{
													SetUpSquadTableHeaders(300, "Emanation (Extreme)", "The Pool of Tribute (Extreme)", "The Great Hunt", "The Minstrel's Ballad: Shinryu's Domain", "The Jade Stoa", "The Jade Stoa (Extreme)", "The Great Hunt (Extreme)", "The Minstrel's Ballad: Tsukuyomi's Pain", "Hells' Kier", "Kugane Ohashi", "The Wreath of Snakes", "Hells' Kier (Extreme)", "The Wreath of Snakes (Extreme)");

													foreach (var c in charas)
													{
														SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
														SetCellBackground(c.IsInstanceUnlocked(20049) ? Green : Red);
														SetCellBackground(c.IsInstanceUnlocked(20047) ? Green : Red);
														SetCellBackground(c.IsInstanceUnlocked(20053) ? Green : Red);
														SetCellBackground(c.IsInstanceUnlocked(20050) ? Green : Red);
														SetCellBackground(c.IsInstanceUnlocked(20051) ? Green : Red);
														SetCellBackground(c.IsInstanceUnlocked(20052) ? Green : Red);
														SetCellBackground(c.IsInstanceUnlocked(20054) ? Green : Red);
														SetCellBackground(c.IsInstanceUnlocked(20056) ? Green : Red);
														SetCellBackground(c.IsInstanceUnlocked(20057) ? Green : Red);
														SetCellBackground(c.IsInstanceUnlocked(20059) ? Green : Red);
														SetCellBackground(c.IsInstanceUnlocked(20060) ? Green : Red);
														SetCellBackground(c.IsInstanceUnlocked(20058) ? Green : Red);
														SetCellBackground(c.IsInstanceUnlocked(20061) ? Green : Red);
													}
													ImGui.EndTable();
												}
												ImGui.EndTabItem();
											}
											if (ImGui.BeginTabItem("Raids"))
											{
												ImGui.Indent();
												if (ImGui.BeginTabBar("squadRaids"))
												{
													if (ImGui.BeginTabItem("Normal Raids"))
													{
														if (ImGui.BeginTable("squadNormalRaidsSb", 25, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
														{
															SetUpSquadTableHeaders(300, "Deltascape V1.0", "Deltascape V2.0", "Deltascape V3.0", "Deltascape V4.0", "Deltascape V1.0 (Savage)", "Deltascape V2.0 (Savage)", "Deltascape V3.0 (Savage)", "Deltascape V4.0 (Savage)", "Sigmascape V1.0", "Sigmascape V2.0", "Sigmascape V3.0", "Sigmascape V4.0", "Sigmascape V1.0 (Savage)", "Sigmascape V2.0 (Savage)", "Sigmascape V3.0 (Savage)", "Sigmascape V4.0 (Savage)", "Alphascape V1.0", "Alphascape V2.0", "Alphascape V3.0", "Alphascape V4.0", "Alphascape V1.0 (Savage)", "Alphascape V2.0 (Savage)", "Alphascape V3.0 (Savage)", "Alphascape V4.0 (Savage)");

															foreach (var c in charas)
															{
																SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
																SetCellBackground(c.IsInstanceUnlocked(30049) ? Green : Red);
																SetCellBackground(c.IsInstanceUnlocked(30050) ? Green : Red);
																SetCellBackground(c.IsInstanceUnlocked(30051) ? Green : Red);
																SetCellBackground(c.IsInstanceUnlocked(30052) ? Green : Red);
																SetCellBackground(c.IsInstanceUnlocked(30053) ? Green : Red);
																SetCellBackground(c.IsInstanceUnlocked(30054) ? Green : Red);
																SetCellBackground(c.IsInstanceUnlocked(30055) ? Green : Red);
																SetCellBackground(c.IsInstanceUnlocked(30056) ? Green : Red);
																SetCellBackground(c.IsInstanceUnlocked(30059) ? Green : Red);
																SetCellBackground(c.IsInstanceUnlocked(30060) ? Green : Red);
																SetCellBackground(c.IsInstanceUnlocked(30061) ? Green : Red);
																SetCellBackground(c.IsInstanceUnlocked(30062) ? Green : Red);
																SetCellBackground(c.IsInstanceUnlocked(30063) ? Green : Red);
																SetCellBackground(c.IsInstanceUnlocked(30064) ? Green : Red);
																SetCellBackground(c.IsInstanceUnlocked(30065) ? Green : Red);
																SetCellBackground(c.IsInstanceUnlocked(30066) ? Green : Red);
																SetCellBackground(c.IsInstanceUnlocked(30069) ? Green : Red);
																SetCellBackground(c.IsInstanceUnlocked(30070) ? Green : Red);
																SetCellBackground(c.IsInstanceUnlocked(30071) ? Green : Red);
																SetCellBackground(c.IsInstanceUnlocked(30072) ? Green : Red);
																SetCellBackground(c.IsInstanceUnlocked(30073) ? Green : Red);
																SetCellBackground(c.IsInstanceUnlocked(30074) ? Green : Red);
																SetCellBackground(c.IsInstanceUnlocked(30075) ? Green : Red);
																SetCellBackground(c.IsInstanceUnlocked(30076) ? Green : Red);
															}
															ImGui.EndTable();
														}
														ImGui.EndTabItem();
													}
													if (ImGui.BeginTabItem("Alliance Raids"))
													{
														if (ImGui.BeginTable("squadAllianceRaidsSb", 4, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
														{
															SetUpSquadTableHeaders(300, "The Royal City of Rabanastre", "The Ridorana Lighthouse", "The Orbonne Monastery");

															foreach (var c in charas)
															{
																SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
																SetCellBackground(c.IsInstanceUnlocked(30058) ? Green : Red);
																SetCellBackground(c.IsInstanceUnlocked(30068) ? Green : Red);
																SetCellBackground(c.IsInstanceUnlocked(30077) ? Green : Red);
															}
															ImGui.EndTable();
														}
														ImGui.EndTabItem();
													}
													ImGui.EndTabBar();
													ImGui.Unindent();
												}
												ImGui.EndTabItem();
											}
											if (ImGui.BeginTabItem("Eureka"))
											{
												if (ImGui.BeginTable("squadEurekaSb", 5, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
												{
													SetUpSquadTableHeaders(300, "The Forbidden Land, Eureka Anemos", "The Forbidden Land, Eureka Pagos", "The Forbidden Land, Eureka Pyros", "The Forbidden Land, Eureka Hydatos");

													foreach (var c in charas)
													{
														SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
														SetCellBackground(c.IsQuestComplete(68614) ? Green : Red);
														SetCellBackground(c.IsQuestComplete(68478) ? Green : Red);
														SetCellBackground(c.IsQuestComplete(68148) ? Green : Red);
														SetCellBackground(c.IsQuestComplete(68149) ? Green : Red);
													}
													ImGui.EndTable();
												}
												ImGui.EndTabItem();
											}
											ImGui.EndTabBar();
											ImGui.Unindent();
										}
										ImGui.EndTabItem();
									}
									if (ImGui.BeginTabItem("Shadowbringers"))
									{
										ImGui.Indent();
										if (ImGui.BeginTabBar("squadShadowbringers"))
										{
											if (ImGui.BeginTabItem("Dungeons"))
											{
												if (ImGui.BeginTable("squadDungeonsShb", 3, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
												{
													SetUpSquadTableHeaders(300, "Akadaemia Anyder", "The Twinning");

													foreach (var c in charas)
													{
														SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
														SetCellBackground(c.IsInstanceUnlocked(71) ? Green : Red);
														SetCellBackground(c.IsInstanceUnlocked(20013) ? Green : Red);
													}
													ImGui.EndTable();
												}
												ImGui.EndTabItem();
											}
											if (ImGui.BeginTabItem("Trials"))
											{
												if (ImGui.BeginTable("squadTrialsShb", 11, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
												{
													SetUpSquadTableHeaders(300, "The Crown of the Immaculate (Extreme)", "The Minstrel's Ballad: Hades' Elegy", "Cinder Drift", "Cinder Drift (Extreme)", "Memoria Misera (Extreme)", "The Seat of Sacrifice (Extreme)", "Castrum Marinum", "The Cloud Deck", "Castrum Marinum (Extreme)", "The Cloud Deck (Extreme)");

													foreach (var c in charas)
													{
														SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
														SetCellBackground(c.IsInstanceUnlocked(20065) ? Green : Red);
														SetCellBackground(c.IsInstanceUnlocked(20067) ? Green : Red);
														SetCellBackground(c.IsInstanceUnlocked(20068) ? Green : Red);
														SetCellBackground(c.IsInstanceUnlocked(20069) ? Green : Red);
														SetCellBackground(c.IsInstanceUnlocked(20070) ? Green : Red);
														SetCellBackground(c.IsInstanceUnlocked(20072) ? Green : Red);
														SetCellBackground(c.IsInstanceUnlocked(20073) ? Green : Red);
														SetCellBackground(c.IsInstanceUnlocked(20075) ? Green : Red);
														SetCellBackground(c.IsInstanceUnlocked(20074) ? Green : Red);
														SetCellBackground(c.IsInstanceUnlocked(20076) ? Green : Red);
													}
													ImGui.EndTable();
												}
												ImGui.EndTabItem();
											}
											if (ImGui.BeginTabItem("Raids"))
											{
												ImGui.Indent();
												if (ImGui.BeginTabBar("squadRaids"))
												{
													if (ImGui.BeginTabItem("Normal Raids"))
													{
														if (ImGui.BeginTable("squadNormalRaidsShb", 25, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
														{
															SetUpSquadTableHeaders(300, "Eden's Gate: Resurrection", "Eden's Gate: Descent", "Eden's Gate: Inundation", "Eden's Gate: Sepulture", "Eden's Gate: Resurrection (Savage)", "Eden's Gate: Descent (Savage)", "Eden's Gate: Inundation (Savage)", "Eden's Gate: Sepulture (Savage)", "Eden's Verse: Fulmination", "Eden's Verse: Furor", "Eden's Verse: Iconoclasm", "Eden's Verse: Refulgence", "Eden's Verse: Fulmination (Savage)", "Eden's Verse: Furor (Savage)", "Eden's Verse: Iconoclasm (Savage)", "Eden's Verse: Refulgence (Savage)", "Eden's Promise: Umbra", "Eden's Promise: Litany", "Eden's Promise: Anamorphosis", "Eden's Promise: Eternity", "Eden's Promise: Umbra (Savage)", "Eden's Promise: Litany (Savage)", "Eden's Promise: Anamorphosis (Savage)", "Eden's Promise: Eternity (Savage)");

															foreach (var c in charas)
															{
																SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
																SetCellBackground(c.IsInstanceUnlocked(30078) ? Green : Red);
																SetCellBackground(c.IsInstanceUnlocked(30082) ? Green : Red);
																SetCellBackground(c.IsInstanceUnlocked(30080) ? Green : Red);
																SetCellBackground(c.IsInstanceUnlocked(30084) ? Green : Red);
																SetCellBackground(c.IsInstanceUnlocked(30079) ? Green : Red);
																SetCellBackground(c.IsInstanceUnlocked(30083) ? Green : Red);
																SetCellBackground(c.IsInstanceUnlocked(30081) ? Green : Red);
																SetCellBackground(c.IsInstanceUnlocked(30085) ? Green : Red);
																SetCellBackground(c.IsInstanceUnlocked(30088) ? Green : Red);
																SetCellBackground(c.IsInstanceUnlocked(30090) ? Green : Red);
																SetCellBackground(c.IsInstanceUnlocked(30092) ? Green : Red);
																SetCellBackground(c.IsInstanceUnlocked(30094) ? Green : Red);
																SetCellBackground(c.IsInstanceUnlocked(30089) ? Green : Red);
																SetCellBackground(c.IsInstanceUnlocked(30091) ? Green : Red);
																SetCellBackground(c.IsInstanceUnlocked(30093) ? Green : Red);
																SetCellBackground(c.IsInstanceUnlocked(30095) ? Green : Red);
																SetCellBackground(c.IsInstanceUnlocked(30097) ? Green : Red);
																SetCellBackground(c.IsInstanceUnlocked(30099) ? Green : Red);
																SetCellBackground(c.IsInstanceUnlocked(30101) ? Green : Red);
																SetCellBackground(c.IsInstanceUnlocked(30103) ? Green : Red);
																SetCellBackground(c.IsInstanceUnlocked(30098) ? Green : Red);
																SetCellBackground(c.IsInstanceUnlocked(30100) ? Green : Red);
																SetCellBackground(c.IsInstanceUnlocked(30102) ? Green : Red);
																SetCellBackground(c.IsInstanceUnlocked(30104) ? Green : Red);
															}
															ImGui.EndTable();
														}
														ImGui.EndTabItem();
													}
													if (ImGui.BeginTabItem("Alliance Raids"))
													{
														if (ImGui.BeginTable("squadAllianceRaidsShb", 4, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
														{
															SetUpSquadTableHeaders(300, "The Copied Factory", "The Puppets' Bunker", "The Tower at Paradigm's Breach");

															foreach (var c in charas)
															{
																SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
																SetCellBackground(c.IsInstanceUnlocked(30087) ? Green : Red);
																SetCellBackground(c.IsInstanceUnlocked(30096) ? Green : Red);
																SetCellBackground(c.IsInstanceUnlocked(30105) ? Green : Red);
															}
															ImGui.EndTable();
														}
														ImGui.EndTabItem();
													}
													ImGui.EndTabBar();
													ImGui.Unindent();
												}
												ImGui.EndTabItem();
											}
											if (ImGui.BeginTabItem("Bozja"))
											{
												if (ImGui.BeginTable("squadBozjaShb", 4, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
												{
													SetUpSquadTableHeaders(300, "The Bozjan Southern Front", "Zadnor", "Bozja complete");

													foreach (var c in charas)
													{
														SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
														SetCellBackground(c.IsQuestComplete(69477) ? Green : Red);
														SetCellBackground(c.IsQuestComplete(69620) ? Green : Red);
														SetCellBackground(c.IsQuestComplete(69624) ? Green : Red);
													}
													ImGui.EndTable();
												}
												ImGui.EndTabItem();
											}
											ImGui.EndTabBar();
											ImGui.Unindent();
										}
										ImGui.EndTabItem();
									}
									if (ImGui.BeginTabItem("Endwalker"))
									{
										ImGui.Indent();
										if (ImGui.BeginTabBar("squadEndwalker"))
										{
											if (ImGui.BeginTabItem("Dungeons"))
											{
												if (ImGui.BeginTable("squadDungeonsEw", 3, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
												{
													SetUpSquadTableHeaders(300, "Smileton", "The Stigma Dreamscape");

													foreach (var c in charas)
													{
														SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
														SetCellBackground(c.IsInstanceUnlocked(20030) ? Green : Red);
														SetCellBackground(c.IsInstanceUnlocked(79) ? Green : Red);
													}
													ImGui.EndTable();
												}
												ImGui.EndTabItem();
											}
											if (ImGui.BeginTabItem("Trials"))
											{
												if (ImGui.BeginTable("squadTrialsEw", 6, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
												{
													SetUpSquadTableHeaders(300, "The Minstrel's Ballad: Hydaelyn's Call", "The Minstrel's Ballad: Zodiark's Fall", "The Minstrel's Ballad: Endsinger's Aria", "Storm's Crown (Extreme)", "Mount Ordeals (Extreme)");

													foreach (var c in charas)
													{
														SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
														SetCellBackground(c.IsInstanceUnlocked(20078) ? Green : Red);
														SetCellBackground(c.IsInstanceUnlocked(20081) ? Green : Red);
														SetCellBackground(c.IsInstanceUnlocked(20083) ? Green : Red);
														SetCellBackground(c.IsInstanceUnlocked(20085) ? Green : Red);
														SetCellBackground(c.IsInstanceUnlocked(20087) ? Green : Red);
													}
													ImGui.EndTable();
												}
												ImGui.EndTabItem();
											}
											if (ImGui.BeginTabItem("Raids"))
											{
												ImGui.Indent();
												if (ImGui.BeginTabBar("squadRaids"))
												{
													if (ImGui.BeginTabItem("Normal Raids"))
													{
														if (ImGui.BeginTable("squadNormalRaidsEw", 17, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
														{
															SetUpSquadTableHeaders(300, "Asphodelos: The First Circle", "Asphodelos: The Second Circle", "Asphodelos: The Third Circle", "Asphodelos: The Fourth Circle", "Asphodelos: The First Circle (Savage)", "Asphodelos: The Second Circle (Savage)", "Asphodelos: The Third Circle (Savage)", "Asphodelos: The Fourth Circle (Savage)", "Abyssos: The Fifth Circle", "Abyssos: The Sixth Circle", "Abyssos: The Seventh Circle", "Abyssos: The Eighth Circle", "Abyssos: The Fifth Circle (Savage)", "Abyssos: The Sixth Circle (Savage)", "Abyssos: The Seventh Circle (Savage)", "Abyssos: The Eighth Circle (Savage)");

															foreach (var c in charas)
															{
																SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
																SetCellBackground(c.IsInstanceUnlocked(30111) ? Green : Red);
																SetCellBackground(c.IsInstanceUnlocked(30113) ? Green : Red);
																SetCellBackground(c.IsInstanceUnlocked(30109) ? Green : Red);
																SetCellBackground(c.IsInstanceUnlocked(30107) ? Green : Red);
																SetCellBackground(c.IsInstanceUnlocked(30112) ? Green : Red);
																SetCellBackground(c.IsInstanceUnlocked(30114) ? Green : Red);
																SetCellBackground(c.IsInstanceUnlocked(30110) ? Green : Red);
																SetCellBackground(c.IsInstanceUnlocked(30108) ? Green : Red);
																SetCellBackground(c.IsInstanceUnlocked(30116) ? Green : Red);
																SetCellBackground(c.IsInstanceUnlocked(30120) ? Green : Red);
																SetCellBackground(c.IsInstanceUnlocked(30118) ? Green : Red);
																SetCellBackground(c.IsInstanceUnlocked(30122) ? Green : Red);
																SetCellBackground(c.IsInstanceUnlocked(30117) ? Green : Red);
																SetCellBackground(c.IsInstanceUnlocked(30121) ? Green : Red);
																SetCellBackground(c.IsInstanceUnlocked(30119) ? Green : Red);
																SetCellBackground(c.IsInstanceUnlocked(30123) ? Green : Red);
															}
															ImGui.EndTable();
														}
														ImGui.EndTabItem();
													}
													if (ImGui.BeginTabItem("Alliance Raids"))
													{
														if (ImGui.BeginTable("squadAllianceRaidsEw", 3, ImGuiTableFlags.ScrollX | ImGuiTableFlags.ScrollY))
														{
															SetUpSquadTableHeaders(300, "Aglaia", "Euphrosyne");

															foreach (var c in charas)
															{
																SetCellBackgroundWithText(default, $"{c.Forename} {c.Surname}", White);
																SetCellBackground(c.IsInstanceUnlocked(30115) ? Green : Red);
																SetCellBackground(c.IsInstanceUnlocked(30125) ? Green : Red);
															}
															ImGui.EndTable();
														}
														ImGui.EndTabItem();
													}
													ImGui.EndTabBar();
													ImGui.Unindent();
												}
												ImGui.EndTabItem();
											}
											ImGui.EndTabBar();
											ImGui.Unindent();
										}
										ImGui.EndTabItem();
									}
									ImGui.EndTabBar();
									ImGui.Unindent();
								}
								ImGui.EndTabItem();
							}
							ImGui.EndTabBar();
							ImGui.Unindent();
						}
						ImGui.EndTabItem();
					}
				}
#if DEBUG || RELEASE_DEV
				if (ImGui.BeginTabItem("Teams"))
				{
					var tankClasses = new uint[] { 19, 21, 32, 37 };
					var dpsClasses = new uint[] { 20, 22, 23, 25, 27, 30, 31, 34, 35, 38, 39 };
					var healerClasses = new uint[] { 24, 28, 33, 40 };

					if (ImGui.BeginTable("teams", 5))
					{
						ImGui.TableSetupColumn("Tank", ImGuiTableColumnFlags.WidthFixed, 200 * Scale);
						ImGui.TableSetupColumn("DPS 1", ImGuiTableColumnFlags.WidthFixed, 200 * Scale);
						ImGui.TableSetupColumn("DPS 2", ImGuiTableColumnFlags.WidthFixed, 200 * Scale);
						ImGui.TableSetupColumn("Healer", ImGuiTableColumnFlags.WidthFixed, 200 * Scale);
						ImGui.TableSetupColumn("", ImGuiTableColumnFlags.WidthFixed, 50 * Scale);
						ImGui.TableHeadersRow();

						foreach (var team in Plugin.Context.Teams)
						{
							var teamAccounts = new List<int> { team.TankA != null ? team.TankA.Account : -1,
								team.Dps1A != null ? team.Dps1A.Account : -1,
								team.Dps2A != null ? team.Dps2A.Account : -1,
								team.HealerA != null ? team.HealerA.Account : -1 };
							List<int> tankAccounts = teamAccounts;
							List<int> dps1Accounts = teamAccounts;
							List<int> dps2Accounts = teamAccounts;
							List<int> healerAccounts = teamAccounts;


							if (team.TankA is not null)
							{
								tankAccounts = teamAccounts.Where(a => a != team.TankA.Account).ToList();
							}
							if (team.Dps1A is not null)
							{
								dps1Accounts = teamAccounts.Where(a => a != team.Dps1A.Account).ToList();
							}
							if (team.Dps2A is not null)
							{
								dps2Accounts = teamAccounts.Where(a => a != team.Dps2A.Account).ToList();
							}
							if (team.HealerA is not null)
							{
								healerAccounts = teamAccounts.Where(a => a != team.HealerA.Account).ToList();
							}

							ImGui.TableNextRow();
							ImGui.TableNextColumn();
							ImGui.PushItemWidth(ImGui.GetContentRegionAvail().X);

							var tanks = Plugin.Context.Charas.Where(c => tankClasses.Contains(c.ClassID) && !tankAccounts.Contains(c.Account) &&
								(c.Tank == null && c.Dps1 == null && c.Dps2 == null && c.Healer == null || c.Tank == team)).ToArray();
							var currentTankName = team.TankA != null ? $"{team.TankA.Forename} {team.TankA.Surname}" : "";
							var curIndex = Array.IndexOf(tanks, team.TankA);
							var newIndex = curIndex;
							if (curIndex == -1 && team.TankA != null)
							{
								ImGui.PushStyleColor(ImGuiCol.Text, Red);
							}
							if (ImGui.BeginCombo("###TeamTank", currentTankName))
							{
								if (curIndex == -1 && team.TankA != null)
								{
									ImGui.PushStyleColor(ImGuiCol.Text, White);
								}
								for (int n = 0; n < tanks.Length; n++)
								{
									var is_selected = (curIndex == n);
									if (ImGui.Selectable($"{tanks[n].Forename} {tanks[n].Surname}", is_selected))
									{
										newIndex = n;
									}

									// Set the initial focus when opening the combo (scrolling + keyboard navigation focus)
									if (is_selected)
									{
										ImGui.SetItemDefaultFocus();
									}
								}
								ImGui.EndCombo();
								if (newIndex != curIndex)
								{
									team.TankA = tanks[newIndex];
									Plugin.Context.SaveChanges();
								}
								if (curIndex == -1 && team.TankA != null)
								{
									ImGui.PopStyleColor();
								}
							}
							if (curIndex == -1 && team.TankA != null)
							{
								ImGui.PopStyleColor();
							}

							ImGui.TableNextColumn();
							ImGui.PushItemWidth(ImGui.GetContentRegionAvail().X);

							var dps1s = Plugin.Context.Charas.Where(c => dpsClasses.Contains(c.ClassID) && !dps1Accounts.Contains(c.Account) &&
								(c.Tank == null && c.Dps1 == null && c.Dps2 == null && c.Healer == null || c.Dps1 == team)).ToArray();
							var currentDps1Name = team.Dps1A != null ? $"{team.Dps1A.Forename} {team.Dps1A.Surname}" : "";
							curIndex = Array.IndexOf(dps1s, team.Dps1A);
							newIndex = curIndex;
							if (curIndex == -1 && team.Dps1A != null)
							{
								ImGui.PushStyleColor(ImGuiCol.Text, Red);
							}
							if (ImGui.BeginCombo("###TeamDPS1", currentDps1Name))
							{
								if (curIndex == -1 && team.Dps1A != null)
								{
									ImGui.PushStyleColor(ImGuiCol.Text, White);
								}
								for (int n = 0; n < dps1s.Length; n++)
								{
									var is_selected = (curIndex == n);
									if (ImGui.Selectable($"{dps1s[n].Forename} {dps1s[n].Surname}", is_selected))
									{
										newIndex = n;
									}

									// Set the initial focus when opening the combo (scrolling + keyboard navigation focus)
									if (is_selected)
									{
										ImGui.SetItemDefaultFocus();
									}
								}
								ImGui.EndCombo();
								if (newIndex != curIndex)
								{
									team.Dps1A = dps1s[newIndex];
									Plugin.Context.SaveChanges();
								}
								if (curIndex == -1 && team.Dps1A != null)
								{
									ImGui.PopStyleColor();
								}
							}
							if (curIndex == -1 && team.Dps1A != null)
							{
								ImGui.PopStyleColor();
							}

							ImGui.TableNextColumn();
							ImGui.PushItemWidth(ImGui.GetContentRegionAvail().X);

							var dps2s = Plugin.Context.Charas.Where(c => dpsClasses.Contains(c.ClassID) && !dps2Accounts.Contains(c.Account) &&
								(c.Tank == null && c.Dps1 == null && c.Dps2 == null && c.Healer == null || c.Dps2 == team)).ToArray();
							var currentDps2Name = team.Dps2A != null ? $"{team.Dps2A.Forename} {team.Dps2A.Surname}" : "";
							curIndex = Array.IndexOf(dps2s, team.Dps2A);
							newIndex = curIndex;
							if (curIndex == -1 && team.Dps2A != null)
							{
								ImGui.PushStyleColor(ImGuiCol.Text, Red);
							}
							if (ImGui.BeginCombo("###TeamDPS2", currentDps2Name))
							{
								if (curIndex == -1 && team.Dps2A != null)
								{
									ImGui.PushStyleColor(ImGuiCol.Text, White);
								}
								for (int n = 0; n < dps2s.Length; n++)
								{
									var is_selected = (curIndex == n);
									if (ImGui.Selectable($"{dps2s[n].Forename} {dps2s[n].Surname}", is_selected))
									{
										newIndex = n;
									}

									// Set the initial focus when opening the combo (scrolling + keyboard navigation focus)
									if (is_selected)
									{
										ImGui.SetItemDefaultFocus();
									}
								}
								ImGui.EndCombo();
								if (newIndex != curIndex)
								{
									team.Dps2A = dps2s[newIndex];
									Plugin.Context.SaveChanges();
								}
								if (curIndex == -1 && team.Dps2A != null)
								{
									ImGui.PopStyleColor();
								}
							}
							if (curIndex == -1 && team.Dps2A != null)
							{
								ImGui.PopStyleColor();
							}

							ImGui.TableNextColumn();
							ImGui.PushItemWidth(ImGui.GetContentRegionAvail().X);

							var healers = Plugin.Context.Charas.Where(c => healerClasses.Contains(c.ClassID) && !healerAccounts.Contains(c.Account) &&
								(c.Tank == null && c.Dps1 == null && c.Dps2 == null && c.Healer == null || c.Healer == team)).ToArray();
							var currentHealerName = team.HealerA != null ? $"{team.HealerA.Forename} {team.HealerA.Surname}" : "";
							curIndex = Array.IndexOf(healers, team.HealerA);
							newIndex = curIndex;
							if (curIndex == -1 && team.HealerA != null)
							{
								ImGui.PushStyleColor(ImGuiCol.Text, Red);
							}
							if (ImGui.BeginCombo("###TeamHealer", currentHealerName))
							{
								if (curIndex == -1 && team.HealerA != null)
								{
									ImGui.PushStyleColor(ImGuiCol.Text, White);
								}
								for (int n = 0; n < healers.Length; n++)
								{
									var is_selected = (curIndex == n);
									if (ImGui.Selectable($"{healers[n].Forename} {healers[n].Surname}", is_selected))
									{
										newIndex = n;
									}

									// Set the initial focus when opening the combo (scrolling + keyboard navigation focus)
									if (is_selected)
									{
										ImGui.SetItemDefaultFocus();
									}
								}
								ImGui.EndCombo();
								if (newIndex != curIndex)
								{
									team.HealerA = healers[newIndex];
									Plugin.Context.SaveChanges();
								}
								if (curIndex == -1 && team.HealerA != null)
								{
									ImGui.PopStyleColor();
								}
							}
							if (curIndex == -1 && team.HealerA != null)
							{
								ImGui.PopStyleColor();
							}
							ImGui.TableNextColumn();
							ImGui.PushItemWidth(ImGui.GetContentRegionAvail().X);
							if (ImGui.Button($"X###{team.TeamID}"))
							{
								Plugin.Context.Teams.Remove(team);
								Plugin.Context.SaveChanges();
							}
						}
						ImGui.EndTable();
					}

					if (ImGui.Button("Add new team"))
					{
						var team = new Team();
						Plugin.Context.Teams.Add(team);
					}
					ImGui.EndTabItem();
				}
				if (ImGui.BeginTabItem("Leves"))
				{
					var count = Plugin.Context.Charas.Where(c => c.LevelCrp >= 84 && !c.IncompleteQuests.Contains("69602")).Count();

					// Per leve values
					var saigaHide = 4f;
					var earthCrystal = 8f;
					var eblanAlumen = 1f;
					var bismuthOre = 5f;
					var redPineLog = 10f;

					var totalSaigaHide = saigaHide * 6 * count;
					var totalEarthCrystal = earthCrystal * 6 * count;
					var totalEblanAlumen = eblanAlumen * 6 * count;
					var totalBismuthOre = bismuthOre * 6 * count;
					var totalRedPineLog = redPineLog * 6 * count;

					if (ImGui.BeginTable("leves", 3))
					{
						ImGui.TableSetupColumn("Item", ImGuiTableColumnFlags.WidthFixed, 100 * Scale);
						ImGui.TableSetupColumn("Daily total", ImGuiTableColumnFlags.WidthFixed, 100 * Scale);
						ImGui.TableSetupColumn("Retainers needed", ImGuiTableColumnFlags.WidthFixed, 100 * Scale);
						ImGui.TableHeadersRow();

						SetCellBackgroundWithText(default, "Saiga Hide", White);
						SetCellBackgroundWithText(default, totalSaigaHide.ToString(), White);
						SetCellBackgroundWithText(default, Math.Ceiling(totalSaigaHide / (Data.ItemsPerCombatRetainer * 5)).ToString(), White);

						SetCellBackgroundWithText(default, "Eblan Alumen", White);
						SetCellBackgroundWithText(default, totalEblanAlumen.ToString(), White);
						SetCellBackgroundWithText(default, Math.Ceiling(totalEblanAlumen / (Data.ItemsPerGatheringRetainer * 5)).ToString(), White);

						SetCellBackgroundWithText(default, "Earth Crystal", White);
						SetCellBackgroundWithText(default, totalEarthCrystal.ToString(), White);
						SetCellBackgroundWithText(default, Math.Ceiling(totalEarthCrystal / (Data.CrystalsPerGatheringRetainer * 5)).ToString(), White);

						SetCellBackgroundWithText(default, "Bismuth Ore", White);
						SetCellBackgroundWithText(default, totalBismuthOre.ToString(), White);
						SetCellBackgroundWithText(default, Math.Ceiling(totalBismuthOre / (Data.ItemsPerGatheringRetainer * 5)).ToString(), White);

						SetCellBackgroundWithText(default, "Red Pine Log", White);
						SetCellBackgroundWithText(default, totalRedPineLog.ToString(), White);
						SetCellBackgroundWithText(default, Math.Ceiling(totalRedPineLog / (Data.ItemsPerGatheringRetainer * 5)).ToString(), White);

						ImGui.EndTable();
					}

				}
#endif
				ImGui.EndTabBar();
			}
		}
    }
}
