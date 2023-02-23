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
using Microsoft.Extensions.Logging;
using System.Runtime.InteropServices;
using Dalamud.Logging;
using System.Diagnostics;
using System.Threading;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.ComponentModel;
using XivCommon.Functions;
using System.IO;
using FFXIVClientStructs.FFXIV.Client.System.Framework;
using FFXIVClientStructs.FFXIV.Client.Game.MJI;
using Microsoft.VisualBasic.ApplicationServices;

namespace FFXIVCharaTracker.DB
{
	internal class CharaContext : DbContext
	{
		internal DbSet<Chara> Charas { get; set; }
		internal DbSet<Team> Teams { get; set; }
		internal DbSet<Retainer> Retainers { get; set; }
		internal DbSet<InventorySlot> InventorySlots { get; set; }
		internal DbSet<RecipeList> RecipeLists { get; set; }

		public unsafe string DbPath { get; } = Framework.Instance()->UserPath.Replace('/', '\\');
		//public string DbPath { get; } = "";

		public CharaContext()
		{
			Database.Migrate();
		}


		internal void AddNewDataToCharacterArrays()
		{
			foreach (var c in Charas)
			{
				if (c.PluginDataVersion == "0.1.0.0")
				{
					c.IncompleteQuestsSet.Add(65970);
					c.IncompleteQuestsSet.Add(66967);
					c.IncompleteQuestsSet.Add(66746);
					c.IncompleteQuests = JsonSerializer.Serialize(c.IncompleteQuestsSet);
					c.UncollectedMinerItemsSet = new HashSet<uint>(Data.RetainerMinerItemIDs);
					c.UncollectedBotanistItemsSet = new HashSet<uint>(Data.RetainerBotanistItemIDs);
					c.UncollectedFisherItemsSet = new HashSet<uint>(Data.RetainerFisherItemIDs);
					c.UncollectedSpearfisherItemsSet = new HashSet<uint>(Data.RetainerSpearfisherItemIDs);
					c.UncollectedMinerItems = JsonSerializer.Serialize(c.UncollectedMinerItemsSet);
					c.UncollectedBotanistItems = JsonSerializer.Serialize(c.UncollectedBotanistItemsSet);
					c.UncollectedFisherItems = JsonSerializer.Serialize(c.UncollectedFisherItemsSet);
					c.UncollectedSpearfisherItems = JsonSerializer.Serialize(c.UncollectedSpearfisherItemsSet);
					c.PluginDataVersion = "0.2.0.0";
				}
			}
			Plugin.CurCharaData!.AddNewDataToCharacterArrays();
		}

		internal void ResetRetainerGatherGear()
		{
			foreach (var r in Retainers)
			{
				if (r.ClassID == 16 || r.ClassID == 17 || r.ClassID == 18)
				{
					r.Gear = false;
				}
			}
		}

		internal void ResetRetainerCombatGear()
		{
			foreach (var r in Retainers)
			{
				if (!(r.ClassID == 16) && !(r.ClassID == 17) && !(r.ClassID == 18))
				{
					r.Gear = false;
				}
			}
		}

		internal void ResetPlayerCombatGear()
		{
			foreach (var c in Charas)
			{
				c.CurGear = false;
			}
		}

		internal void ResetPlayerGatherGear()
		{
			foreach (var c in Charas)
			{
				c.GatherGear = false;
			}
		}

		internal void ResetRetainerItems()
		{
			foreach (var c in Charas)
			{
				c.UncollectedMinerItemsSet = new HashSet<uint>(Data.RetainerMinerItemIDs);
				c.UncollectedBotanistItemsSet = new HashSet<uint>(Data.RetainerBotanistItemIDs);
				c.UncollectedFisherItemsSet = new HashSet<uint>(Data.RetainerFisherItemIDs);
				c.UncollectedSpearfisherItemsSet = new HashSet<uint>(Data.RetainerSpearfisherItemIDs);

				c.UncollectedMinerItems = JsonSerializer.Serialize(c.UncollectedMinerItemsSet);
				c.UncollectedBotanistItems = JsonSerializer.Serialize(c.UncollectedBotanistItemsSet);
				c.UncollectedFisherItems = JsonSerializer.Serialize(c.UncollectedFisherItemsSet);
				c.UncollectedSpearfisherItems = JsonSerializer.Serialize(c.UncollectedSpearfisherItemsSet);

			}
			Plugin.CurCharaData!.PluginDataVersion = "0.1.0.0";
			Plugin.CurCharaData.AddNewDataToCharacterArrays();
		}

		internal List<InventorySlot> GetSlotsByItemID(ulong itemId)
		{
			return InventorySlots.Where(inv => inv.ItemID == Plugin.ItemIDToSortID[(uint)itemId] &&
			inv.Quantity > 0 && !new InventoryType[] { InventoryType.ArmoryBody, InventoryType.ArmoryEar,
				InventoryType.ArmoryFeets, InventoryType.ArmoryHands, InventoryType.ArmoryHead,
				InventoryType.ArmoryLegs, InventoryType.ArmoryMainHand, InventoryType.ArmoryNeck,
				InventoryType.ArmoryOffHand, InventoryType.ArmoryRings, InventoryType.ArmoryWrist,
				InventoryType.EquippedItems, InventoryType.RetainerEquippedItems}.Contains(inv.Inventory)).Include(inv => inv.Retainer).ThenInclude(r => r!.Owner)
			.Include(inv => inv.Chara).AsNoTracking().ToList()
			.OrderBy(inv => inv.Chara?.CharaID ?? inv.Retainer!.Owner.CharaID)
			.ThenBy(inv => inv.Retainer?.RetainerID ?? 0).ToList();
		}

		internal int GetQuantityByItemID(ulong itemId)
		{
			return (int)GetSlotsByItemID(itemId).Sum(inv => inv.Quantity);
		}

		internal static void LogToWarning(string message)
		{
			PluginLog.Warning(message);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Chara>()
				.HasMany(c => c.Inventory)
				.WithOne(inv => inv.Chara)
				.OnDelete(DeleteBehavior.Cascade);

			modelBuilder.Entity<Chara>()
				.HasMany(c => c.Retainers)
				.WithOne(r => r.Owner)
				.OnDelete(DeleteBehavior.Cascade);

			modelBuilder.Entity<Retainer>()
				.HasMany(r => r.Inventory)
				.WithOne(inv => inv.Retainer)
				.OnDelete(DeleteBehavior.Cascade);

			modelBuilder.Entity<Chara>()
				.HasOne(c => c.Tank)
				.WithOne(t => t.TankA)
				.OnDelete(DeleteBehavior.SetNull);

			modelBuilder.Entity<Chara>()
				.HasOne(c => c.Dps1)
				.WithOne(t => t.Dps1A)
				.OnDelete(DeleteBehavior.SetNull);

			modelBuilder.Entity<Chara>()
				.HasOne(c => c.Dps2)
				.WithOne(t => t.Dps2A)
				.OnDelete(DeleteBehavior.SetNull);

			modelBuilder.Entity<Chara>()
				.HasOne(c => c.Healer)
				.WithOne(t => t.HealerA)
				.OnDelete(DeleteBehavior.SetNull);


		}


		protected override void OnConfiguring(DbContextOptionsBuilder options)
				=> options.UseSqlite($@"Data Source={DbPath}\charaData.sqlite")
						  .EnableThreadSafetyChecks(false)
						  //.EnableSensitiveDataLogging(true)
					//.LogTo(LogToWarning, LogLevel.Information)
					;
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
		public List<Retainer> Retainers { get; set; } = new List<Retainer>();
		public int GCRank { get; set; }
		public string LockedDuties { get; set; }
		[NotMapped]
		public HashSet<uint> LockedDutiesSet { get; set; } = new HashSet<uint>();
		public string LockedCustomDeliveries { get; set; }
		[NotMapped]
		public HashSet<uint> LockedCustomDeliveriesSet { get; set; } = new HashSet<uint>();
		public int ChocoboLevel { get; set; }
		public int RaceChocoboRank { get; set; }
		public int RaceChocoboPedigree { get; set; }
		public int IslandSanctuaryLevel { get; set; }
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
		public string UncollectedMinerItems { get; set; }
		[NotMapped]
		public HashSet<uint> UncollectedMinerItemsSet { get; set; } = new HashSet<uint>();
		public string UncollectedBotanistItems { get; set; }
		[NotMapped]
		public HashSet<uint> UncollectedBotanistItemsSet { get; set; } = new HashSet<uint>();
		public string UncollectedFisherItems { get; set; }
		[NotMapped]
		public HashSet<uint> UncollectedFisherItemsSet { get; set; } = new HashSet<uint>();
		public string UncollectedSpearfisherItems { get; set; }
		[NotMapped]
		public HashSet<uint> UncollectedSpearfisherItemsSet { get; set; } = new HashSet<uint>();
		[InverseProperty(nameof(InventorySlot.Chara))]
		public List<InventorySlot> Inventory { get; set; } = new List<InventorySlot>();
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
			string unobtainedMounts = "[]", string uncollectedMinerItems = "[]", string uncollectedBotanistItems = "[]",
			string uncollectedFisherItems = "[]", string uncollectedSpearfisherItems = "[]")
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
			UncollectedMinerItems = uncollectedMinerItems;
			UncollectedBotanistItems = uncollectedBotanistItems;
			UncollectedFisherItems = uncollectedFisherItems;
			UncollectedSpearfisherItems = uncollectedSpearfisherItems;


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
			UncollectedMinerItemsSet = JsonSerializer.Deserialize<HashSet<uint>>(UncollectedMinerItems)!;
			UncollectedBotanistItemsSet = JsonSerializer.Deserialize<HashSet<uint>>(UncollectedBotanistItems)!;
			UncollectedFisherItemsSet = JsonSerializer.Deserialize<HashSet<uint>>(UncollectedFisherItems)!;
			UncollectedSpearfisherItemsSet = JsonSerializer.Deserialize<HashSet<uint>>(UncollectedSpearfisherItems)!;
		}

		public override bool Equals(object? obj)
		{
			if (obj is null)
			{
				return false;
			}
			var other = (Chara)obj;
			if (other is null)
			{
				return false;
			}
			return CharaID == other.CharaID;
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
			UncollectedMinerItemsSet = new HashSet<uint>(Data.RetainerMinerItemIDs);
			UncollectedBotanistItemsSet = new HashSet<uint>(Data.RetainerBotanistItemIDs);
			UncollectedFisherItemsSet = new HashSet<uint>(Data.RetainerFisherItemIDs);
			UncollectedSpearfisherItemsSet = new HashSet<uint>(Data.RetainerSpearfisherItemIDs);
		}

		internal void AddNewDataToCharacterArrays()
		{
			if (PluginDataVersion == "0.1.0.0")
			{
				IncompleteQuestsSet.Add(65970);
				IncompleteQuestsSet.Add(66967);
				IncompleteQuestsSet.Add(66746);
				IncompleteQuests = JsonSerializer.Serialize(IncompleteQuestsSet);
				UncollectedMinerItemsSet = new HashSet<uint>(Data.RetainerMinerItemIDs);
				UncollectedBotanistItemsSet = new HashSet<uint>(Data.RetainerBotanistItemIDs);
				UncollectedFisherItemsSet = new HashSet<uint>(Data.RetainerFisherItemIDs);
				UncollectedSpearfisherItemsSet = new HashSet<uint>(Data.RetainerSpearfisherItemIDs);
				UncollectedMinerItems = JsonSerializer.Serialize(UncollectedMinerItemsSet);
				UncollectedBotanistItems = JsonSerializer.Serialize(UncollectedBotanistItemsSet);
				UncollectedFisherItems = JsonSerializer.Serialize(UncollectedFisherItemsSet);
				UncollectedSpearfisherItems = JsonSerializer.Serialize(UncollectedSpearfisherItemsSet);
				PluginDataVersion = "0.2.0.0";
			}
		}

		internal unsafe void UpdateIslandSanctuaryData()
		{
			var currentRank = MJIManager.Instance()->IslandState.CurrentRank;
			if (currentRank > 0)
			{
				IslandSanctuaryLevel = currentRank;
			}
		}

		internal unsafe void UpdateRaceChocoboData()
		{
			var manager = RaceChocoboManager.Instance();

			if (manager->Rank > 0)
			{
				RaceChocoboRank = manager->Rank;
			}
			if (manager->Parameters > 0)
			{
				RaceChocoboPedigree = manager->Parameters & (1 << 4) - 1;
			}
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
			LockedDuties = JsonSerializer.Serialize(LockedDutiesSet);
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
			IncompleteFolkloreBooks = JsonSerializer.Serialize(IncompleteFolkloreBooksSet);
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
			IncompleteSecretRecipeBooks = JsonSerializer.Serialize(IncompleteSecretRecipeBooksSet);
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
			UnobtainedHairstyles = JsonSerializer.Serialize(UnobtainedHairstylesSet);
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
			UnobtainedEmotes = JsonSerializer.Serialize(UnobtainedEmotesSet);
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
				else if (item.LevelEquip >= 25)
				{
					var classJobCategory = item.ClassJobCategory.Value;
					if (classJobCategory != null)
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
			UnobtainedMinions = JsonSerializer.Serialize(UnobtainedMinionsSet);
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
			UnobtainedMounts = JsonSerializer.Serialize(UnobtainedMountsSet);
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
				var cdInstance = CustomDeliveryState.Instance();
				CustomDeliveryRanksSet[(int)i - 1] = cdInstance->Rank[i - 1];
			}
			LockedCustomDeliveries = JsonSerializer.Serialize(LockedCustomDeliveriesSet);
			CustomDeliveryRanks = JsonSerializer.Serialize(CustomDeliveryRanksSet);
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
			IncompleteQuests = JsonSerializer.Serialize(IncompleteQuestsSet);
		}

		internal unsafe void UpdateRetainerArrays()
		{
			UpdateRetainerArray(Gathering.GatheringData, UncollectedBotanistItemsSet);
			UpdateRetainerArray(Gathering.GatheringData, UncollectedMinerItemsSet);
			UpdateRetainerArray(Gathering.FishingData, UncollectedFisherItemsSet);
			UpdateRetainerArray(Gathering.SpearfishingData, UncollectedSpearfisherItemsSet);

			UncollectedMinerItems = JsonSerializer.Serialize(UncollectedMinerItemsSet);
			UncollectedBotanistItems = JsonSerializer.Serialize(UncollectedBotanistItemsSet);
			UncollectedFisherItems = JsonSerializer.Serialize(UncollectedFisherItemsSet);
			UncollectedSpearfisherItems = JsonSerializer.Serialize(UncollectedSpearfisherItemsSet);
		}

		internal unsafe void UpdateRetainerArray(byte* array, HashSet<uint> itemIDs)
		{
			foreach (var id in itemIDs)
			{
				var offset = id / 8;
				var bit = (byte)id % 8;
				if (((array[offset] >> bit) & 1) == 1)
				{
					itemIDs.Remove(id);
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

		internal List<string> GetMissingMinerItems()
		{
			var list = new List<string>();

			foreach (var id in UncollectedMinerItemsSet)
			{
				list.Add(Plugin.ItemCache[Plugin.ItemIDToSortID[(uint)Plugin.GatheringItems!.GetRow(id)!.Item]].Item1.Name);
			}

			return list;
		}

		internal List<string> GetMissingBotanistItems()
		{
			var list = new List<string>();

			foreach (var id in UncollectedBotanistItemsSet)
			{
				list.Add(Plugin.ItemCache[Plugin.ItemIDToSortID[(uint)Plugin.GatheringItems!.GetRow(id)!.Item]].Item1.Name);
			}

			return list;
		}

		internal List<string> GetMissingFisherItems()
		{
			var list = new List<string>();

			foreach (var id in UncollectedFisherItemsSet)
			{
				list.Add(Plugin.ItemCache[Plugin.ItemIDToSortID[(uint)Plugin.FishParameters!.GetRow(id)!.Item]].Item1.Name);
			}

			foreach (var id in UncollectedSpearfisherItemsSet)
			{
				list.Add(Plugin.SpearfishingItems.GetRow(id)!.Item.Value!.Name);
			}

			return list;
		}

		public override int GetHashCode()
		{
			return (int)CharaID;
		}
	}

	internal class Team
	{
		[Key]
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

	internal class Retainer : IComparable<Retainer>
	{
		[Key]
		public ulong RetainerID { get; set; }
		public string Name { get; set; } = "";
		public uint ClassID { get; set; }
		public int Level { get; set; }
		public bool Gear { get; set; }
		public Chara Owner { get; set; }
		public List<InventorySlot> Inventory { get; set; } = new List<InventorySlot>();

		// This exists because EF can't map the other constructor
		internal Retainer()
		{
			Owner = new Chara(0,0);
		}

		internal Retainer(Chara owner, ulong retainerID)
		{
			Owner = owner;
			RetainerID = retainerID;
		}

		internal static unsafe void UpdateRetainer(CharaContext context, Chara chara)
		{
			if (Plugin.Retainers.ActiveRetainer == 0)
			{
				return;
			}

			var retainerManager = RetainerManager.Instance();

			for (int i = 0; i < retainerManager->GetRetainerCount(); i++)
			{
				var retainer = retainerManager->Retainer[i];
				var retainerID = retainer->RetainerID;
				if (retainerID == Plugin.Retainers.ActiveRetainer)
				{
					if (!retainer->Available)
					{
						return;
					}

					var retainerData = chara.Retainers.Where(r => r.RetainerID == retainerID).SingleOrDefault();

					if (retainerData == null)
					{
						retainerData = new Retainer(chara, retainer->RetainerID);
						context.Retainers.Add(retainerData);
					}

					retainerData.Level = retainer->Level;
					retainerData.ClassID = retainer->ClassJob;
					retainerData.Name = Marshal.PtrToStringUTF8((IntPtr)retainer->Name)!;
					InventorySlot.StoreInventories(context, retainerData);

					if (!retainerData.Gear)
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
						if (Plugin.ClassJobs.GetRow(retainerData.ClassID)!.ClassJobCategory.Value!.RowId == 32 &&
							item.LevelItem.Row == Data.RetainerGatherILvl)
						{
							retainerData.Gear = true;
						}
						else if (new HashSet<uint> { 30, 31 }.Contains(Plugin.ClassJobs.GetRow(retainerData.ClassID)!.ClassJobCategory.Value!.RowId) &&
							item.LevelItem.Row == Data.RetainerCombatILvl)
						{
							retainerData.Gear = true;
						}
					}
					return;
				}
			}
		}

		public int CompareTo(Retainer? other)
		{
			if (other == null)
			{
				return 1;
			}

			return RetainerID.CompareTo(other.RetainerID);
		}
	}

	[Microsoft.EntityFrameworkCore.Index(nameof(CharaID), nameof(Inventory), nameof(Slot))]
	[Microsoft.EntityFrameworkCore.Index(nameof(RetainerID), nameof(Inventory), nameof(Slot))]
	[Microsoft.EntityFrameworkCore.Index(nameof(CharaID), nameof(RetainerID), nameof(Inventory), nameof(Slot), IsUnique = true)]
	[Microsoft.EntityFrameworkCore.Index(nameof(ItemID), nameof(CharaID), nameof(Quantity))]
	[Microsoft.EntityFrameworkCore.Index(nameof(ItemID), nameof(RetainerID), nameof(Quantity))]
	[Microsoft.EntityFrameworkCore.Index(nameof(ItemCategory), nameof(ItemID), nameof(CharaID), nameof(Quantity))]
	[Microsoft.EntityFrameworkCore.Index(nameof(ItemCategory), nameof(ItemID), nameof(RetainerID), nameof(Quantity))]
	internal class InventorySlot
	{
		[Key]
		public ulong InventorySlotID { get; set; }
		public ulong ItemID { get; set; }
		public uint ItemCategory { get; set; }
		public uint Quantity { get; set; }
		public InventoryType Inventory { get; set; }
		public int Slot { get; set; }
		private ulong? RetainerID { get; set; }
		[ForeignKey(nameof(DB.Retainer.RetainerID))]
		public Retainer? Retainer { get; set; }
		private ulong? CharaID { get; set; }
		[ForeignKey(nameof(DB.Chara.CharaID))]
		public Chara? Chara { get; set; }

		internal static unsafe void StoreInventories(CharaContext context, Chara chara)
		{
			InventoryType[] inventories =
			{
				InventoryType.Inventory1,
				InventoryType.Inventory2,
				InventoryType.Inventory3,
				InventoryType.Inventory4,
				InventoryType.EquippedItems,
				InventoryType.Currency,
				InventoryType.Crystals,
				InventoryType.ArmoryOffHand,
				InventoryType.ArmoryHead,
				InventoryType.ArmoryBody,
				InventoryType.ArmoryHands,
				InventoryType.ArmoryLegs,
				InventoryType.ArmoryFeets,
				InventoryType.ArmoryEar,
				InventoryType.ArmoryNeck,
				InventoryType.ArmoryWrist,
				InventoryType.ArmoryRings,
				InventoryType.ArmoryMainHand,
				InventoryType.SaddleBag1,
				InventoryType.SaddleBag2,
				InventoryType.PremiumSaddleBag1,
				InventoryType.PremiumSaddleBag2
			};
			StoreInventory(inventories, context, chara: chara);
		}

		internal static unsafe void StoreInventories(CharaContext context, Retainer retainer)
		{
			InventoryType[] inventories =
			{
				InventoryType.RetainerPage1,
				InventoryType.RetainerPage2,
				InventoryType.RetainerPage3,
				InventoryType.RetainerPage4,
				InventoryType.RetainerPage5,
				InventoryType.RetainerPage6,
				InventoryType.RetainerPage7,
				InventoryType.RetainerEquippedItems,
				InventoryType.RetainerGil,
				InventoryType.RetainerCrystals,
				InventoryType.RetainerMarket
			};
			StoreInventory(inventories, context, retainer: retainer);
		}

		internal static unsafe void StoreInventory(InventoryType[] types, CharaContext context, Chara? chara = null, Retainer? retainer = null)
		{
			if (chara == null && retainer == null)
			{
				return;
			}

			List<InventorySlot> storedSlots;

			if (chara != null)
			{
				storedSlots = context.InventorySlots.Where(sl => sl.Chara == chara).ToList();
			}
			else
			{
				storedSlots = context.InventorySlots.Where(sl => sl.Retainer == retainer).ToList();
			}

			var slotIndex = 0; 

			foreach (var type in types)
			{
				var container = InventoryManager.Instance()->GetInventoryContainer(type);

				if (container == null)
				{
					while (storedSlots[slotIndex].Inventory == type)
					{
						slotIndex++;
					}
					continue;
				}

				var invSize = container->Size;
				var invType = container->Type;

				if (IsInventoryEmpty(container) && (invType == InventoryType.SaddleBag1 ||
					invType == InventoryType.SaddleBag2 || invType == InventoryType.PremiumSaddleBag1 ||
					invType == InventoryType.PremiumSaddleBag2))
				{
					if (slotIndex < storedSlots.Count && storedSlots[slotIndex].Inventory == invType)
					{
						slotIndex += (int)invSize;
					}
					continue;
				}


				var invItems = container->Items;

				for (var i = 0; i < invSize; i++)
				{
					if (slotIndex == storedSlots.Count || storedSlots[slotIndex].Inventory != invType)
					{
						for (var j = i; j < invSize; j++)
						{
							var slot = new InventorySlot { Inventory = invType, Slot = j, Chara = chara, Retainer = retainer };
							context.InventorySlots.Add(slot);
						}
						context.SaveChanges();
						if (chara != null)
						{
							storedSlots = context.InventorySlots.Where(sl => sl.Chara == chara).ToList();
						}
						else
						{
							storedSlots = context.InventorySlots.Where(sl => sl.Retainer == retainer).ToList();
						}
					}

					var gameSlot = invItems[i];
					var dbSlot = storedSlots[slotIndex];

					if (dbSlot.Slot != i)
					{
						PluginLog.Warning($"Inventory slot does not match database slot: {dbSlot.Slot}, {i}!");
					}


					if (!Plugin.ItemCache.TryGetValue(Plugin.ItemIDToSortID[gameSlot.ItemID], out var itemData) ||
						!Plugin.ItemIDToSortID.TryGetValue(gameSlot.ItemID, out var sortID))
					{
						slotIndex++;
						continue;
					}

					dbSlot.Quantity = gameSlot.Quantity;

					dbSlot.ItemCategory = itemData.Item2.RowId;

					dbSlot.ItemID = sortID;

					slotIndex++;
				}
			}
		}

		internal static unsafe bool IsInventoryEmpty(InventoryContainer* container)
		{
			var invItems = container->Items;
			var invSize = container->Size;

			for (var i = 0; i < invSize; i++)
			{
				if (invItems[i].ItemID != 0)
				{
					return false;
				}
			}

			return true;
		}
	}

	[Microsoft.EntityFrameworkCore.Index(nameof(SubcategoryName), nameof(Name), nameof(ListData))]
	internal class RecipeList
	{
		[Key]
		public string Name { get; set; }
		public string SubcategoryName { get; set; }
		public string ListData { get; set; }
		[NotMapped]
		public IDictionary<uint, uint> ListDataDict { get; private set; }

		public RecipeList(string name, string subcategoryName, IDictionary<uint, uint> listData)
		{
			Name = name;
			SubcategoryName = subcategoryName;
			ListDataDict = listData;

			ListData = JsonSerializer.Serialize(ListDataDict);
		}

		public RecipeList(string listData, string name, string subcategoryName)
		{
			Name = name;
			SubcategoryName = subcategoryName;
			ListData = listData;
			ListDataDict = JsonSerializer.Deserialize<Dictionary<uint, uint>>(ListData)!;
		}

		internal void UpdateRecipeList(IDictionary<uint, uint> listData)
		{
			ListDataDict = listData;
			ListData = JsonSerializer.Serialize(ListDataDict);
		}
	}
}
