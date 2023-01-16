using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Dalamud.Game.ClientState.Resolvers;
using Lumina.Excel.GeneratedSheets;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using FFXIVClientStructs.FFXIV.Client.Game.UI;
using FFXIVClientStructs.FFXIV.Client.Game;
using Lumina.Data.Parsing;
using static FFXIVClientStructs.FFXIV.Client.Game.QuestManager.QuestListArray;

namespace FFXIVCharaTracker.DB
{
	internal class CharaContext : DbContext
	{
		internal DbSet<Chara> Charas { get; set; }
		internal DbSet<Team> Teams { get; set; }

		public string DbPath { get; }

		public CharaContext()
		{
			var folder = Environment.SpecialFolder.MyDocuments;
			var path = Environment.GetFolderPath(folder);
			DbPath = System.IO.Path.Join(path, @"\My Games\FINAL FANTASY XIV - A Realm Reborn\");
			Database.Migrate();
		}

		private void PreSave()
		{
			foreach (var entry in ChangeTracker.Entries())
			{
				var entity = entry.Entity;
				switch (entity)
				{
					case Chara:
						((Chara)entity).SerialiseData();
						break;
					case Team:
						break;
				}
			}
		}

		public override int SaveChanges()
		{
			PreSave();
			return base.SaveChanges();
		}

		internal void SetDefaultArraysForAllCharas()
		{
			foreach (var c in Charas)
			{
				c.SetDefaultArrays();
			}
		}

		protected override void OnConfiguring(DbContextOptionsBuilder options)
				=> options.UseSqlite($@"Data Source={DbPath}\charaData.sqlite");
	}

	internal class Chara
	{
		[Key]
		public ulong CharaID { get; set; }
		public uint WorldID { get; set; }
		public int Account { get; set; }
		public uint ClassID { get; set; }
		public string Forename { get; set; }
		public string Surname { get; set; }
		public short ClassLevel { get; set; }
		public bool LowGear { get; set; }
		public bool CurGear { get; set; }
		public int LevelCrp { get; set; }
		public int LevelBsm { get; set; }
		public int LevelArm { get; set; }
		public int LevelGsm { get; set; }
		public int LevelLtw { get; set; }
		public int LevelWvr { get; set; }
		public int LevelAlc { get; set; }
		public int LevelCul { get; set; }
		public int LevelMin { get; set; }
		public int LevelBtn { get; set; }
		public int LevelFsh { get; set; }
		public bool GatherGear { get; set; }
		public string IncompleteFolkloreBooks { get; set; }
		[NotMapped]
		public HashSet<uint> IncompleteFolkloreBooksSet { get; set; } = new HashSet<uint>();
		public string IncompleteSecretRecipeBooks { get; set; }
		[NotMapped]
		public HashSet<uint> IncompleteSecretRecipeBooksSet { get; set; } = new HashSet<uint>();
		public string UnobtainedHairstyles { get; set; }
		[NotMapped]
		public HashSet<uint> UnobtainedHairstylesSet { get; set; } = new HashSet<uint>();
		public string UnobtainedEmotes { get; set; }
		[NotMapped]
		public HashSet<uint> UnobtainedEmotesSet { get; set; } = new HashSet<uint>();
		public string RetainersStoringDescription { get; set; } = "";
		public uint RetainerClass { get; set; }
		public int LevelRetainer1 { get; set; }
		public bool GearRetainer1 { get; set; }
		public int LevelRetainer2 { get; set; }
		public bool GearRetainer2 { get; set; }
		public int GCRank { get; set; }
		public string LockedDuties { get; set; }
		[NotMapped]
		public HashSet<uint> LockedDutiesSet { get; set; } = new HashSet<uint>();
		public string LockedCustomDeliveries { get; set; }
		[NotMapped]
		public HashSet<uint> LockedCustomDeliveriesSet { get; set; } = new HashSet<uint>();
		public int ChocoboLevel { get; set; }
		public string IncompleteQuests { get; set; }
		[NotMapped]
		public HashSet<uint> IncompleteQuestsSet { get; set; } = new HashSet<uint>();
		public string CustomDeliveryRanks { get; set; }
		[NotMapped]
		public List<uint> CustomDeliveryRanksSet { get; set; } = new List<uint>();
		public string UnobtainedMinions { get; set; }
		[NotMapped]
		public HashSet<uint> UnobtainedMinionsSet { get; set; } = new HashSet<uint>();
		public string UnobtainedMounts { get; set; }
		[NotMapped]
		public HashSet<uint> UnobtainedMountsSet { get; set; } = new HashSet<uint>();
		public string PluginDataVersion { get; set; } = "";

		[InverseProperty(nameof(Team.TankA))]
		public Team? Tank { get; set; }
		[InverseProperty(nameof(Team.Dps1A))]
		public Team? Dps1 { get; set; }
		[InverseProperty(nameof(Team.Dps2A))]
		public Team? Dps2 { get; set; }
		[InverseProperty(nameof(Team.HealerA))]
		public Team? Healer { get; set; }


		internal Chara(ulong charaID, uint worldID, string forename = "[]", string surname = "[]",
			string incompleteFolkloreBooks = "[]",	string incompleteSecretRecipeBooks = "[]", string unobtainedHairstyles = "[]",
			string lockedDuties = "[]", string unobtainedEmotes = "[]", string lockedCustomDeliveries = "[]",
			string incompleteQuests = "[]", string customDeliveryRanks = "[]", string unobtainedMinions = "[]",
			string unobtainedMounts = "[]")
		{
			CharaID = charaID;
			WorldID = worldID;
			Forename = forename;
			Surname = surname;
			IncompleteFolkloreBooks = incompleteFolkloreBooks;
			IncompleteSecretRecipeBooks = incompleteSecretRecipeBooks;
			UnobtainedHairstyles = unobtainedHairstyles;
			LockedDuties = lockedDuties;
			UnobtainedEmotes = unobtainedEmotes;
			LockedCustomDeliveries = lockedCustomDeliveries;
			IncompleteQuests = incompleteQuests;
			CustomDeliveryRanks = customDeliveryRanks;
			UnobtainedMinions = unobtainedMinions;
			UnobtainedMounts = unobtainedMounts;

			IncompleteFolkloreBooksSet = JsonSerializer.Deserialize<HashSet<uint>>(IncompleteFolkloreBooks)!;
			IncompleteSecretRecipeBooksSet = JsonSerializer.Deserialize<HashSet<uint>>(IncompleteSecretRecipeBooks)!;
			UnobtainedHairstylesSet = JsonSerializer.Deserialize<HashSet<uint>>(UnobtainedHairstyles)!;
			LockedDutiesSet = JsonSerializer.Deserialize<HashSet<uint>>(LockedDuties)!;
			UnobtainedEmotesSet = JsonSerializer.Deserialize<HashSet<uint>>(UnobtainedEmotes)!;
			LockedCustomDeliveriesSet = JsonSerializer.Deserialize<HashSet<uint>>(LockedCustomDeliveries)!;
			IncompleteQuestsSet = JsonSerializer.Deserialize<HashSet<uint>>(IncompleteQuests)!;
			CustomDeliveryRanksSet = JsonSerializer.Deserialize<List<uint>>(CustomDeliveryRanks)!;
			UnobtainedMinionsSet = JsonSerializer.Deserialize<HashSet<uint>>(UnobtainedMinions)!;
			UnobtainedMountsSet = JsonSerializer.Deserialize<HashSet<uint>>(UnobtainedMounts)!;
		}

		internal static Chara MakeDefaultChara()
		{
			return new Chara(0, 0);
		}

		internal void SerialiseData()
		{
			IncompleteFolkloreBooks = JsonSerializer.Serialize(IncompleteFolkloreBooksSet);
			IncompleteSecretRecipeBooks = JsonSerializer.Serialize(IncompleteSecretRecipeBooksSet);
			UnobtainedHairstyles = JsonSerializer.Serialize(UnobtainedHairstylesSet);
			LockedDuties = JsonSerializer.Serialize(LockedDutiesSet);
			UnobtainedEmotes = JsonSerializer.Serialize(UnobtainedEmotesSet);
			LockedCustomDeliveries = JsonSerializer.Serialize(LockedCustomDeliveriesSet);
			IncompleteQuests = JsonSerializer.Serialize(IncompleteQuestsSet);
			CustomDeliveryRanks = JsonSerializer.Serialize(CustomDeliveryRanksSet);
			UnobtainedMinions = JsonSerializer.Serialize(UnobtainedMinionsSet);
			UnobtainedMounts = JsonSerializer.Serialize(UnobtainedMountsSet);
		}

		internal void SetDefaultArrays()
		{
			LockedDutiesSet = new HashSet<uint>(Data.OptionalContentIDs);
			IncompleteFolkloreBooksSet = new HashSet<uint>(Data.FolkloreIDs);
			IncompleteSecretRecipeBooksSet = new HashSet<uint>(Data.RecipeBookIDs);
			UnobtainedHairstylesSet = new HashSet<uint>(Data.HairstyleIDs);
			UnobtainedEmotesSet = new HashSet<uint>(Data.EmoteIDs);
			LockedCustomDeliveriesSet = new HashSet<uint>(Data.CustomDeliveryNpcIDs);
			IncompleteQuestsSet = new HashSet<uint>(Data.QuestIDs);
			CustomDeliveryRanksSet = new List<uint>();
			for (int i = 0; i < Data.CustomDeliveryNpcIDs.Length; i++)
			{
				CustomDeliveryRanksSet.Add(0);
			}
			UnobtainedMinionsSet = new HashSet<uint>(Data.MinionIDs);
			UnobtainedMountsSet = new HashSet<uint>(Data.MountIDs);
		}

		internal void UpdateOptionalInstanceUnlocks()
		{
			foreach (var dutyId in LockedDutiesSet)
			{
				if (UIState.IsInstanceContentUnlocked(dutyId))
				{
					LockedDutiesSet.Remove(dutyId);
				}
			}
		}

		internal unsafe void UpdateFolkloreUnlocks(UIState* UiState)
		{
			foreach (var folkloreId in IncompleteFolkloreBooksSet)
			{
				if (UiState->PlayerState.IsFolkloreBookUnlocked(folkloreId))
				{
					IncompleteFolkloreBooksSet.Remove(folkloreId);
				}
			}
		}

		internal unsafe void UpdateSecretRecipeUnlocks(UIState* UiState)
		{
			foreach (var recipeBookId in IncompleteSecretRecipeBooksSet)
			{
				if (UiState->PlayerState.IsSecretRecipeBookUnlocked(recipeBookId))
				{
					IncompleteSecretRecipeBooksSet.Remove(recipeBookId);
				}
			}
		}

		internal unsafe bool UpdateHairstyleUnlocks(UIState* UiState)
		{
			var waitingOnHairstyles = false;
			foreach (var hairstyleId in UnobtainedHairstylesSet)
			{
				var itemPtr = FFXIVClientStructs.FFXIV.Component.Exd.ExdModule.GetItemRowById(hairstyleId);
				if (itemPtr != null)
				{
					if (UiState->IsItemActionUnlocked(itemPtr) == 1)
					{
						UnobtainedHairstylesSet.Remove(hairstyleId);
					}
				}
				else
				{
					waitingOnHairstyles = true;
				}
			}
			return waitingOnHairstyles;
		}

		internal unsafe void UpdateEmoteUnlocks(UIState* UiState)
		{
			foreach (var emoteId in UnobtainedEmotesSet)
			{
				if (UiState->IsUnlockLinkUnlockedOrQuestCompleted(Plugin.Emotes.GetRow(emoteId)!.UnlockLink))
				{
					UnobtainedEmotesSet.Remove(emoteId);
				}
			}
		}

		internal unsafe void UpdateLevels(UIState* UiState)
		{
			var PlayerState = UiState->PlayerState;
			ClassLevel = PlayerState.ClassJobLevelArray[Plugin.ClassJobs.GetRow(ClassID)!.ExpArrayIndex];

			LevelCrp = PlayerState.ClassJobLevelArray[7];
			LevelBsm = PlayerState.ClassJobLevelArray[8];
			LevelArm = PlayerState.ClassJobLevelArray[9];
			LevelGsm = PlayerState.ClassJobLevelArray[10];
			LevelLtw = PlayerState.ClassJobLevelArray[11];
			LevelWvr = PlayerState.ClassJobLevelArray[12];
			LevelAlc = PlayerState.ClassJobLevelArray[13];
			LevelCul = PlayerState.ClassJobLevelArray[14];
			LevelMin = PlayerState.ClassJobLevelArray[15];
			LevelBtn = PlayerState.ClassJobLevelArray[16];
			LevelFsh = PlayerState.ClassJobLevelArray[17];

		}

		internal unsafe void UpdateGCRank(UIState* UiState)
		{
			GCRank = UiState->PlayerState.GetGrandCompanyRank();
		}

		internal unsafe void UpdateChocobo(UIState* UiState)
		{
			ChocoboLevel = UiState->Buddy.Rank;
		}

		internal unsafe void UpdateGearState(InventoryContainer* inventory)
		{
			var invSize = inventory->Size;
			// Combat gear
			for (var i = 0; i < invSize; i++)
			{
				var slot = inventory->GetInventorySlot(i);
				if (slot->ItemID == 0 || slot->Quantity == 0)
				{
					continue;
				}
				var item = Plugin.ItemSheet!.GetRow(slot->ItemID);
				if (item == null)
				{
					continue;
				}
				if (item.LevelItem.Row == Data.CraftedCombatILvl)
				{
					var classJobCategory = item.ClassJobCategory.Value;
					if (classJobCategory != null &&
						(bool)classJobCategory.GetType().GetProperty(Plugin.ClassJobs.GetRow(ClassID)!.Abbreviation)!.GetValue(classJobCategory)!)
					{
						LowGear = true;
						CurGear = true;
						continue;
					}
				}
				else if (item.LevelItem.Row == Data.CraftedGatherILvl)
				{
					var classJobCategory = item.ClassJobCategory.Value;
					if (classJobCategory != null && classJobCategory.MIN)
					{
						GatherGear = true;
						continue;
					}
				}
				else if (item.LevelEquip >= 20)
				{
					var classJobCategory = item.ClassJobCategory.Value;
					if (classJobCategory != null &&
						(bool)classJobCategory.GetType().GetProperty(Plugin.ClassJobs.GetRow(ClassID)!.Abbreviation)!.GetValue(classJobCategory)!)
					{
						LowGear = true;
					}
				}
			}
		}

		internal unsafe void UpdateMinions(UIState* UiState)
		{
			foreach (var minionId in UnobtainedMinionsSet)
			{
				if (UiState->IsCompanionUnlocked(minionId)!)
				{
					UnobtainedMinionsSet.Remove(minionId);
				}
			}
		}

		internal unsafe void UpdateMounts(UIState* UiState)
		{
			foreach (var mountId in UnobtainedMountsSet)
			{
				if (UiState->PlayerState.IsMountUnlocked(mountId)!)
				{
					UnobtainedMountsSet.Remove(mountId);
				}
			}
		}

		internal unsafe void UpdateCustomDeliveries()
		{
			if (LockedCustomDeliveriesSet.Count == 0)
			{
				return;
			}
			for (uint i = 1; i < Plugin.SatisfactionNpcs.RowCount; i++)
			{
				var row = Plugin.SatisfactionNpcs.GetRow(i)!;

				if (LockedCustomDeliveriesSet.Contains(row.Npc.Row))
				{
					var quest = Plugin.SatisfactionNpcs.GetRow(i)!.QuestRequired;
					if (Plugin.Common.Functions.Journal.IsQuestCompleted(quest.Row))
					{
						LockedCustomDeliveriesSet.Remove(row.Npc.Row);
					}
				}
				CustomDeliveryRanksSet[(int)i - 1] = CustomDeliveryState.Instance()->Rank[i - 1];
			}

		}

		internal unsafe void UpdateUnlockQuests(UIState* UiState)
		{
			foreach (var questId in IncompleteQuestsSet)
			{
				if (UiState->IsUnlockLinkUnlockedOrQuestCompleted(questId)!)
				{
					IncompleteQuestsSet.Remove(questId);
				}
			}
		}
		internal void UpdateRetainers()
		{
			if (Plugin.Retainers.ActiveRetainer == 0)
			{
				return;
			}

			unsafe
			{
				var retainerManager = RetainerManager.Instance();

				for (int i = 0; i < retainerManager->RetainerCount; i++)
				{
					var retainer = retainerManager->Retainer[i];
					if (retainer->RetainerID == Plugin.Retainers.ActiveRetainer)
					{
						if (!retainer->Available)
						{
							return;
						}
						//PluginLog.Warning(inventory->GetInventorySlot(3)->ItemID.ToString());
						if (i == 0)
						{
							LevelRetainer1 = retainer->Level;
							RetainerClass = retainer->ClassJob;


							if (!GearRetainer1)
							{
								var invManager = InventoryManager.Instance();
								var inventory = invManager->GetInventoryContainer(InventoryType.RetainerEquippedItems);
								var invSize = inventory->Size;
								// Combat gear
								var slot = inventory->GetInventorySlot(3);
								if (slot->ItemID == 0 || slot->Quantity == 0)
								{
									return;
								}
								var item = Plugin.ItemSheet?.GetRow(slot->ItemID);
								if (item == null)
								{
									return;
								}
								if (Plugin.ClassJobs.GetRow(RetainerClass)!.ClassJobCategory.Value!.RowId == 32 &&
									item.LevelItem.Row == Data.RetainerGatherILvl)
								{
									GearRetainer1 = true;
								}
								else if (new HashSet<uint> { 30, 31 }.Contains(Plugin.ClassJobs.GetRow(RetainerClass)!.ClassJobCategory.Value!.RowId) &&
									item.LevelItem.Row == Data.RetainerCombatILvl)
								{
									GearRetainer1 = true;
								}
							}
						}
						else if (i == 1)
						{
							LevelRetainer2 = retainer->Level;

							if (!GearRetainer2)
							{
								var invManager = InventoryManager.Instance();
								var inventory = invManager->GetInventoryContainer(InventoryType.RetainerEquippedItems);
								var invSize = inventory->Size;
								// Combat gear
								var slot = inventory->GetInventorySlot(3);
								if (slot->ItemID == 0 || slot->Quantity == 0)
								{
									return;
								}
								var item = Plugin.ItemSheet?.GetRow(slot->ItemID);
								if (item == null)
								{
									return;
								}
								if (Plugin.ClassJobs.GetRow(RetainerClass)!.ClassJobCategory.Value!.RowId == 32 &&
									item.LevelItem.Row == Data.RetainerGatherILvl)
								{
									GearRetainer2 = true;
								}
								else if (new HashSet<uint> { 30, 31 }.Contains(Plugin.ClassJobs.GetRow(RetainerClass)!.ClassJobCategory.Value!.RowId) &&
									item.LevelItem.Row == Data.RetainerCombatILvl)
								{
									GearRetainer2 = true;
								}
							}
						}
					}
				}
			}
		}

		internal bool IsQuestComplete(uint questId)
		{
			return !IncompleteQuestsSet.Contains(questId);
		}

		internal bool IsMinionUnlocked(uint minionId)
		{
			return !UnobtainedMinionsSet.Contains(minionId);
		}

		internal bool IsMountUnlocked(uint mountId)
		{
			return !UnobtainedMountsSet.Contains(mountId);
		}

		internal bool IsInstanceUnlocked(uint instanceId)
		{
			return !LockedDutiesSet.Contains(instanceId);
		}

		internal bool IsHairstyleUnlocked(uint hairstyleItemId)
		{
			return !UnobtainedHairstylesSet.Contains(hairstyleItemId);
		}

		internal bool IsEmoteUnlocked(uint emoteId)
		{
			return !UnobtainedEmotesSet.Contains(emoteId);
		}

		internal int GetStoryProgress()
		{
			if (IsQuestComplete(70214))
			{
				return Data.QuestComplete63;
			}
			else if (IsQuestComplete(70136))
			{
				return Data.QuestComplete62;
			}
			else if (IsQuestComplete(70071))
			{
				return Data.QuestComplete61;
			}
			else if (IsQuestComplete(70000))
			{
				return Data.QuestComplete60;
			}
			else if (IsQuestComplete(69602))
			{
				return Data.QuestComplete555;
			}
			else if (IsQuestComplete(69552))
			{
				return Data.QuestComplete54;
			}
			else if (IsQuestComplete(69318))
			{
				return Data.QuestComplete53;
			}
			else if (IsQuestComplete(69306))
			{
				return Data.QuestComplete52;
			}
			else if (IsQuestComplete(69218))
			{
				return Data.QuestComplete51;
			}
			else if (IsQuestComplete(69190))
			{
				return Data.QuestComplete50;
			}
			else if (IsQuestComplete(68721))
			{
				return Data.QuestComplete455;
			}
			else if (IsQuestComplete(68685))
			{
				return Data.QuestComplete44;
			}
			else if (IsQuestComplete(68612))
			{
				return Data.QuestComplete43;
			}
			else if (IsQuestComplete(68565))
			{
				return Data.QuestComplete42;
			}
			else if (IsQuestComplete(68508))
			{
				return Data.QuestComplete41;
			}
			else if (IsQuestComplete(68089))
			{
				return Data.QuestComplete40;
			}
			else if (IsQuestComplete(67895))
			{
				return Data.QuestComplete355;
			}
			else if (IsQuestComplete(67886))
			{
				return Data.QuestComplete34;
			}
			else if (IsQuestComplete(67783))
			{
				return Data.QuestComplete33;
			}
			else if (IsQuestComplete(67777))
			{
				return Data.QuestComplete32;
			}
			else if (IsQuestComplete(67699))
			{
				return Data.QuestComplete31;
			}
			else if (IsQuestComplete(67205))
			{
				return Data.QuestComplete30;
			}
			else if (IsQuestComplete(65964))
			{
				return Data.QuestComplete255;
			}
			else if (IsQuestComplete(65625))
			{
				return Data.QuestComplete24;
			}
			else if (IsQuestComplete(66996))
			{
				return Data.QuestComplete23;
			}
			else if (IsQuestComplete(66899))
			{
				return Data.QuestComplete22;
			}
			else if (IsQuestComplete(66729))
			{
				return Data.QuestComplete21;
			}
			else if (IsQuestComplete(66060))
			{
				return Data.QuestComplete20;
			}
			else if (IsQuestComplete(66045))
			{
				return Data.QuestCompleteRetainer;
			}
			else if (IsQuestComplete(66043) || IsQuestComplete(66064) || IsQuestComplete(66082))
			{
				return Data.QuestCompleteOrigin;
			}
			return 0;
		}

		internal List<string> GetMissingCrafterQuests()
		{
			var list = new List<string>();

			if (!IsQuestComplete(67979))
			{
				list.Add("CRP");
			}
			if (!IsQuestComplete(68153))
			{
				list.Add("BSM");
			}
			if (!IsQuestComplete(68132))
			{
				list.Add("ARM");
			}
			if (!IsQuestComplete(68137))
			{
				list.Add("GSM");
			}
			if (!IsQuestComplete(68147))
			{
				list.Add("LTW");
			}
			if (!IsQuestComplete(67969))
			{
				list.Add("WVR");
			}
			if (!IsQuestComplete(67974))
			{
				list.Add("ALC");
			}
			if (!IsQuestComplete(68142))
			{
				list.Add("CUL");
			}

			return list;
		}

		internal List<string> GetMissingGathererQuests()
		{
			var list = new List<string>();

			if (!IsQuestComplete(68093))
			{
				list.Add("MIN");
			}
			if (!IsQuestComplete(68159))
			{
				list.Add("BTN");
			}
			if (!IsQuestComplete(68433))
			{
				list.Add("FSH");
			}

			return list;
		}

	}

	internal class Team
	{
		public int TeamID { get; set; }
		[ForeignKey(nameof(Chara.Tank))]
		public Chara? TankA { get; set; }
		[ForeignKey(nameof(Chara.Dps1))]
		public Chara? Dps1A { get; set; }
		[ForeignKey(nameof(Chara.Dps2))]
		public Chara? Dps2A { get; set; }
		[ForeignKey(nameof(Chara.Healer))]
		public Chara? HealerA { get; set; }
	}
}
