﻿using Dalamud.Game.ClientState;
using Dalamud.Logging;
using FFXIVClientStructs.FFXIV.Client.Game;
using FFXIVClientStructs.FFXIV.Client.Game.MJI;
using FFXIVClientStructs.FFXIV.Client.Game.UI;
using FFXIVClientStructs.FFXIV.Client.System.Framework;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;
using System.Text.Json;

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

        public CharaContext() => Database.Migrate();

        internal void AddNewDataToCharacterArrays()
		{
			foreach (var c in Charas)
			{
                c.AddNewDataToCharacterArrays();
            }
            Plugin.CurCharaData?.AddNewDataToCharacterArrays();
		}

		internal void ResetRetainerGatherGear()
		{
			foreach (var r in Retainers)
			{
				if (r.ClassID is 16 or 17 or 18)
				{
					r.Gear = false;
				}
			}
		}

		internal void ResetRetainerCombatGear()
		{
			foreach (var r in Retainers)
			{
				if (r.ClassID is not 16 and not 17 and not 18)
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
			Plugin.CurCharaData?.AddNewDataToCharacterArrays();
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
        {
            options.UseSqlite($@"Data Source={DbPath}\charaData.sqlite")
                                  .EnableThreadSafetyChecks(false)
                            //.EnableSensitiveDataLogging(true)
                            //.LogTo(LogToWarning, LogLevel.Information)
                            ;
        }
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
        public byte BirthDay { get; set; }
        public byte BirthMonth { get; set; }
        public byte GuardianDeity { get; set; }
        public byte Race { get; set; }
        public byte Sex { get; set; }
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
        public float DesynthesisLevelCrp { get; set; }
        public float DesynthesisLevelBsm { get; set; }
        public float DesynthesisLevelArm { get; set; }
        public float DesynthesisLevelGsm { get; set; }
        public float DesynthesisLevelLtw { get; set; }
        public float DesynthesisLevelWvr { get; set; }
        public float DesynthesisLevelAlc { get; set; }
        public float DesynthesisLevelCul { get; set; }
        public int LevelMin { get; set; }
		public int LevelBtn { get; set; }
		public int LevelFsh { get; set; }
		public bool GatherGear { get; set; }
		public string IncompleteFolkloreBooks { get; set; }
		[NotMapped]
		public ICollection<uint> IncompleteFolkloreBooksSet { get; set; } = new HashSet<uint>();
		public string IncompleteSecretRecipeBooks { get; set; }
		[NotMapped]
		public ICollection<uint> IncompleteSecretRecipeBooksSet { get; set; } = new HashSet<uint>();
		public string UnobtainedHairstyles { get; set; }
		[NotMapped]
		public ICollection<uint> UnobtainedHairstylesSet { get; set; } = new HashSet<uint>();
		public string UnobtainedEmotes { get; set; }
		[NotMapped]
		public ICollection<uint> UnobtainedEmotesSet { get; set; } = new HashSet<uint>();
		public string RetainersStoringDescription { get; set; } = "";
		public List<Retainer> Retainers { get; set; } = new List<Retainer>();
		public int GCRank { get; set; }
		public string LockedDuties { get; set; }
		[NotMapped]
		public ICollection<uint> LockedDutiesSet { get; set; } = new HashSet<uint>();
		public string LockedCustomDeliveries { get; set; }
		[NotMapped]
		public ICollection<uint> LockedCustomDeliveriesSet { get; set; } = new HashSet<uint>();
		public int ChocoboLevel { get; set; }
		public int RaceChocoboRank { get; set; }
		public int RaceChocoboPedigree { get; set; }
		public int IslandSanctuaryLevel { get; set; }
		public string IncompleteQuests { get; set; }
		[NotMapped]
		public ICollection<uint> IncompleteQuestsSet { get; set; } = new HashSet<uint>();
		public string CustomDeliveryRanks { get; set; }
		[NotMapped]
		public IList<uint> CustomDeliveryRanksList { get; set; } = new List<uint>();
        public string BeastTribeRanks { get; set; }
        [NotMapped]
        public IList<uint> BeastTribeRanksList { get; set; } = new List<uint>();
		public string UnobtainedMinions { get; set; }
		[NotMapped]
		public ICollection<uint> UnobtainedMinionsSet { get; set; } = new HashSet<uint>();
		public string UnobtainedMounts { get; set; }
		[NotMapped]
		public ICollection<uint> UnobtainedMountsSet { get; set; } = new HashSet<uint>();
        public string UnobtainedOrchestrion { get; set; }
        [NotMapped]
        public ICollection<uint> UnobtainedOrchestrionSet { get; set; } = new HashSet<uint>();
        public string UnobtainedBardings { get; set; }
        [NotMapped]
        public ICollection<uint> UnobtainedBardingsSet { get; set; } = new HashSet<uint>();
        public string UnobtainedFashionAccessories { get; set; }
        [NotMapped]
        public ICollection<uint> UnobtainedFashionAccessoriesSet { get; set; } = new HashSet<uint>();
        public string UncollectedMinerItems { get; set; }
        [NotMapped]
		public ICollection<uint> UncollectedMinerItemsSet { get; set; } = new HashSet<uint>();
		public string UncollectedBotanistItems { get; set; }
		[NotMapped]
		public ICollection<uint> UncollectedBotanistItemsSet { get; set; } = new HashSet<uint>();
		public string UncollectedFisherItems { get; set; }
		[NotMapped]
		public ICollection<uint> UncollectedFisherItemsSet { get; set; } = new HashSet<uint>();
		public string UncollectedSpearfisherItems { get; set; }
		[NotMapped]
		public ICollection<uint> UncollectedSpearfisherItemsSet { get; set; } = new HashSet<uint>();
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
			string uncollectedFisherItems = "[]", string uncollectedSpearfisherItems = "[]", string beastTribeRanks = "[]",
            string unobtainedOrchestrion = "[]", string unobtainedBardings = "[]", string unobtainedFashionAccessories = "[]")
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
            BeastTribeRanks = beastTribeRanks;
            UnobtainedOrchestrion = unobtainedOrchestrion;
            UnobtainedBardings = unobtainedBardings;
            UnobtainedFashionAccessories = unobtainedFashionAccessories;

			IncompleteFolkloreBooksSet = TryDeserialize<HashSet<uint>>(IncompleteFolkloreBooks, Data.FolkloreIDs);
            IncompleteSecretRecipeBooksSet = TryDeserialize<HashSet<uint>>(IncompleteSecretRecipeBooks, Data.RecipeBookIDs);
            UnobtainedHairstylesSet = TryDeserialize<HashSet<uint>>(UnobtainedHairstyles, Data.HairstyleIDs);
            LockedDutiesSet = TryDeserialize<HashSet<uint>>(LockedDuties, Data.OptionalContentIDs);
            UnobtainedEmotesSet = TryDeserialize<HashSet<uint>>(UnobtainedEmotes, Data.EmoteIDs);
            LockedCustomDeliveriesSet = TryDeserialize<HashSet<uint>>(LockedCustomDeliveries, Data.CustomDeliveryNpcIDs);
            IncompleteQuestsSet = TryDeserialize<HashSet<uint>>(IncompleteQuests, Data.QuestIDs);
            CustomDeliveryRanksList = TryDeserialize<List<uint>>(CustomDeliveryRanks, Array.Empty<uint>());
            UnobtainedMountsSet = TryDeserialize<HashSet<uint>>(UnobtainedMounts, Data.MountIDs);
            UnobtainedMinionsSet = TryDeserialize<HashSet<uint>>(UnobtainedMinions, Data.MinionIDs);
            UncollectedMinerItemsSet = TryDeserialize<HashSet<uint>>(UncollectedMinerItems, Data.RetainerMinerItemIDs);
            UncollectedBotanistItemsSet = TryDeserialize<HashSet<uint>>(UncollectedBotanistItems, Data.RetainerBotanistItemIDs);
            UncollectedFisherItemsSet = TryDeserialize<HashSet<uint>>(UncollectedFisherItems, Data.RetainerFisherItemIDs);
            UncollectedSpearfisherItemsSet = TryDeserialize<HashSet<uint>>(UncollectedSpearfisherItems, Data.RetainerSpearfisherItemIDs);
            BeastTribeRanksList = TryDeserialize<List<uint>>(BeastTribeRanks, Array.Empty<uint>());
            UnobtainedOrchestrionSet = TryDeserialize<HashSet<uint>>(UnobtainedOrchestrion, Data.OrchestrionIDs);
            UnobtainedBardingsSet = TryDeserialize<HashSet<uint>>(UnobtainedBardings, Data.BardingIDs);
            UnobtainedFashionAccessoriesSet = TryDeserialize<HashSet<uint>>(UnobtainedFashionAccessories, Data.FashionIDs);
            if (charaID == Plugin.ClientState.LocalContentId && BeastTribeRanksList.Count < Plugin.BeastTribes.RowCount - 1)
            {
                for (var i = BeastTribeRanksList.Count; i < Plugin.BeastTribes.RowCount - 1; i++)
                {
                    BeastTribeRanksList.Add(0);
                }
                BeastTribeRanks = JsonSerializer.Serialize(BeastTribeRanksList);
            }
            if (charaID == Plugin.ClientState.LocalContentId && CustomDeliveryRanksList.Count < Plugin.SatisfactionNpcs.RowCount - 1)
            {
                for (var i = CustomDeliveryRanksList.Count; i < Plugin.SatisfactionNpcs.RowCount - 1; i++)
                {
                    CustomDeliveryRanksList.Add(0);
                }
                CustomDeliveryRanks = JsonSerializer.Serialize(CustomDeliveryRanksList);
            }
        }

        private static TCollection TryDeserialize<TCollection>(string data, uint[] baseData) where TCollection : ICollection<uint>, new()
        {
            if (data == "")
            {
                data = "[]";
            }
            try
            {
                return JsonSerializer.Deserialize<TCollection>(data)!;
            }
            catch (Exception e)
            {
                PluginLog.Error(e, "Failed to load JSON data!");
                return (TCollection)Activator.CreateInstance(typeof(TCollection), new object[] { baseData })!;
            }
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

        internal static unsafe Chara? AddNewCharacter()
        {
            var currentChara = Plugin.ClientState.LocalPlayer;

            if (currentChara != null)
            {
                var chara = new Chara(Plugin.ClientState.LocalContentId, currentChara.HomeWorld.Id,
                    currentChara.Name.ToString().Split(' ')[0], currentChara.Name.ToString().Split(' ')[1])
                {
                    PluginDataVersion = Plugin.DataVersion
                };

                chara.SetDefaultArrays();

                chara.UpdateCharacterData();

                chara.UpdateCharacterPersonals(UIState.Instance());

                var chrDir = Path.Combine(FFXIVClientStructs.FFXIV.Client.System.Framework.Framework.Instance()->UserPath,
                    $"FFXIV_CHR{Plugin.ClientState.LocalContentId:X16}").Replace('/', '\\');
                File.Create(Path.Combine(chrDir, "_" + chara.Forename));

                return chara;
            }
            return null;
        }

        internal void UpdateCharacterData()
        {
            var CurrentChara = Plugin.ClientState.LocalPlayer;

            unsafe
            {
                var UiState = UIState.Instance();

                // Gear check
                if (!CurGear || !GatherGear)
                {
                    var invManager = InventoryManager.Instance();
                    var inventory = invManager->GetInventoryContainer(InventoryType.EquippedItems);
                    UpdateGearState(inventory);
                    inventory = invManager->GetInventoryContainer(InventoryType.ArmoryBody);
                    UpdateGearState(inventory);
                }

                UpdateOptionalInstanceUnlocks();
                UpdateFolkloreUnlocks(UiState);
                UpdateSecretRecipeUnlocks(UiState);
                UpdateHairstyleUnlocks(UiState);
                UpdateEmoteUnlocks(UiState);
                UpdateLevels(UiState);
                UpdateDesynthesisLevels(UiState);
                UpdateMinions(UiState);
                UpdateMounts(UiState);
                UpdateOrchestrions(UiState);
                UpdateBardings(UiState);

                UpdateGCRank(UiState);
                UpdateChocobo(UiState);
                UpdateRaceChocoboData();

                UpdateCustomDeliveries();
                UpdateBeastTribes();
                UpdateUnlockQuests(UiState);
                UpdateIslandSanctuaryData();
                UpdateRetainerArrays();
            }
        }

        internal unsafe void UpdateCharacterPersonals(UIState* UiState)
        {
            BirthDay = UiState->PlayerState.BirthDay;
            BirthMonth = UiState->PlayerState.BirthMonth;
            Race = UiState->PlayerState.Tribe;
            Sex = UiState->PlayerState.Sex;
            GuardianDeity = UiState->PlayerState.GuardianDeity;
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
			CustomDeliveryRanksList = new List<uint>();
			for (var i = 0; i < Data.CustomDeliveryNpcIDs.Length; i++)
			{
				CustomDeliveryRanksList.Add(0);
			}
			UnobtainedMinionsSet = new HashSet<uint>(Data.MinionIDs);
			UnobtainedMountsSet = new HashSet<uint>(Data.MountIDs);
			UncollectedMinerItemsSet = new HashSet<uint>(Data.RetainerMinerItemIDs);
			UncollectedBotanistItemsSet = new HashSet<uint>(Data.RetainerBotanistItemIDs);
			UncollectedFisherItemsSet = new HashSet<uint>(Data.RetainerFisherItemIDs);
			UncollectedSpearfisherItemsSet = new HashSet<uint>(Data.RetainerSpearfisherItemIDs);
            UnobtainedOrchestrionSet = new HashSet<uint>(Data.OrchestrionIDs);
            UnobtainedBardingsSet = new HashSet<uint>(Data.BardingIDs);
            UnobtainedFashionAccessoriesSet = new HashSet<uint>(Data.FashionIDs);

            UncollectedMinerItems = JsonSerializer.Serialize(UncollectedMinerItemsSet);
            UncollectedBotanistItems = JsonSerializer.Serialize(UncollectedBotanistItemsSet);
            UncollectedFisherItems = JsonSerializer.Serialize(UncollectedFisherItemsSet);
            UncollectedSpearfisherItems = JsonSerializer.Serialize(UncollectedSpearfisherItemsSet);
            LockedDuties = JsonSerializer.Serialize(LockedDutiesSet);
            IncompleteFolkloreBooks = JsonSerializer.Serialize(IncompleteFolkloreBooksSet);
            IncompleteSecretRecipeBooks = JsonSerializer.Serialize(IncompleteSecretRecipeBooksSet);
            UnobtainedHairstyles = JsonSerializer.Serialize(UnobtainedHairstylesSet);
            UnobtainedEmotes = JsonSerializer.Serialize(UnobtainedEmotesSet);
            UnobtainedMinions = JsonSerializer.Serialize(UnobtainedMinionsSet);
            LockedCustomDeliveries = JsonSerializer.Serialize(LockedCustomDeliveriesSet);
            CustomDeliveryRanks = JsonSerializer.Serialize(CustomDeliveryRanksList);
            IncompleteQuests = JsonSerializer.Serialize(IncompleteQuestsSet);
            UnobtainedOrchestrion = JsonSerializer.Serialize(UnobtainedOrchestrionSet);
            UnobtainedBardings = JsonSerializer.Serialize(UnobtainedBardingsSet);
            UnobtainedFashionAccessories = JsonSerializer.Serialize(UnobtainedFashionAccessoriesSet);
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
            if (PluginDataVersion == "0.2.0.0")
            {
                IncompleteQuestsSet.Add(66235);
                IncompleteQuestsSet.Add(68553);
                IncompleteQuests = JsonSerializer.Serialize(IncompleteQuestsSet);
                PluginDataVersion = "0.2.0.1";
            }
            if (PluginDataVersion == "0.2.0.1")
            {
                IncompleteQuestsSet.Add(66174);
                IncompleteQuestsSet.Add(66175);
                IncompleteQuestsSet.Add(66176);
                IncompleteQuestsSet.Add(65688);
                IncompleteQuestsSet.Add(66740);
                IncompleteQuestsSet.Add(66038);
                IncompleteQuestsSet.Add(67908);
                IncompleteQuestsSet.Add(68704);
                IncompleteQuestsSet.Add(70255);
                IncompleteQuestsSet.Add(67099);
                IncompleteQuestsSet.Add(67100);
                IncompleteQuestsSet.Add(67101);
                IncompleteQuestsSet.Add(67655);
                IncompleteQuestsSet.Add(67656);
                IncompleteQuestsSet.Add(67657);
                IncompleteQuestsSet.Add(67658);
                IncompleteQuestsSet.Add(68472);
                IncompleteQuestsSet.Add(68473);
                IncompleteQuestsSet.Add(68474);
                IncompleteQuestsSet.Add(68475);
                IncompleteQuestsSet.Add(69133);
                IncompleteQuestsSet.Add(69134);
                IncompleteQuestsSet.Add(69135);
                IncompleteQuestsSet.Add(69136);
                IncompleteQuestsSet.Add(69712);
                IncompleteQuestsSet.Add(69713);
                IncompleteQuestsSet.Add(69714);
                IncompleteQuestsSet.Add(69715);
                IncompleteQuestsSet.Add(66338);
                IncompleteQuestsSet.Add(66999);
                IncompleteQuestsSet.Add(67896);
                IncompleteQuestsSet.Add(67631);
                IncompleteQuestsSet.Add(67633);
                IncompleteQuestsSet.Add(67634);
                IncompleteQuestsSet.Add(68477);
                IncompleteQuestsSet.Add(69139);
                IncompleteQuestsSet.Add(69711);
                IncompleteQuestsSet.Add(66968);
                IncompleteQuestsSet.Add(66969);
                IncompleteQuestsSet.Add(66970);
                IncompleteQuestsSet.Add(65698);
                IncompleteQuestsSet.Add(68456);
                IncompleteQuestsSet.Add(67643);
                IncompleteQuestsSet.Add(69140);
                IncompleteQuestsSet.Add(69710);
                IncompleteQuestsSet.Add(66698);
                IncompleteQuestsSet.Add(67096);
                IncompleteQuestsSet.Add(66747);
                IncompleteQuestsSet.Add(66959);
                IncompleteQuestsSet.Add(67654);
                IncompleteQuestsSet.Add(68476);
                IncompleteQuestsSet.Add(69137);
                IncompleteQuestsSet.Add(69709);
                IncompleteQuestsSet.Add(70199);
                IncompleteQuests = JsonSerializer.Serialize(IncompleteQuestsSet);
                UnobtainedMinionsSet.Add(32);
                UnobtainedMinionsSet.Add(52);
                UnobtainedMinionsSet.Add(86);
                UnobtainedMinionsSet.Add(87);
                UnobtainedMinionsSet.Add(88);
                UnobtainedMinionsSet.Add(89);
                UnobtainedMinionsSet.Add(90);
                UnobtainedMinionsSet.Add(115);
                UnobtainedMinionsSet.Add(116);
                UnobtainedMinionsSet.Add(119);
                UnobtainedMinionsSet.Add(126);
                UnobtainedMinionsSet.Add(130);
                UnobtainedMinionsSet.Add(133);
                UnobtainedMinionsSet.Add(173);
                UnobtainedMinionsSet.Add(181);
                UnobtainedMinionsSet.Add(193);
                UnobtainedMinionsSet.Add(224);
                UnobtainedMinionsSet.Add(276);
                UnobtainedMinionsSet.Add(306);
                UnobtainedMinionsSet.Add(313);
                UnobtainedMinionsSet.Add(379);
                UnobtainedMinionsSet.Add(381);
                UnobtainedMinionsSet.Add(441);
                UnobtainedMinionsSet.Add(450);
                UnobtainedMinionsSet.Add(472);
                UnobtainedMinionsSet.Add(473);
                UnobtainedMinions = JsonSerializer.Serialize(UnobtainedMinionsSet);
                UnobtainedMountsSet.Add(1);
                UnobtainedMountsSet.Add(6);
                UnobtainedMountsSet.Add(45);
                UnobtainedMountsSet.Add(50);
                UnobtainedMountsSet.Add(55);
                UnobtainedMountsSet.Add(125);
                UnobtainedMountsSet.Add(185);
                UnobtainedMountsSet.Add(285);
                UnobtainedMountsSet.Add(292);
                UnobtainedMountsSet.Add(308);
                UnobtainedMountsSet.Add(316);
                UnobtainedMounts = JsonSerializer.Serialize(UnobtainedMountsSet);
                UnobtainedHairstylesSet.Add(39472);
                UnobtainedHairstylesSet.Add(39473);
                UnobtainedHairstyles = JsonSerializer.Serialize(UnobtainedHairstylesSet);
                UnobtainedEmotesSet.Add(59);
                UnobtainedEmotesSet.Add(115);
                UnobtainedEmotesSet.Add(121);
                UnobtainedEmotesSet.Add(122);
                UnobtainedEmotesSet.Add(154);
                UnobtainedEmotesSet.Add(166);
                UnobtainedEmotesSet.Add(172);
                UnobtainedEmotesSet.Add(183);
                UnobtainedEmotesSet.Add(190);
                UnobtainedEmotesSet.Add(191);
                UnobtainedEmotesSet.Add(235);
                UnobtainedEmotesSet.Add(252);
                UnobtainedEmotes = JsonSerializer.Serialize(UnobtainedEmotesSet);
                UnobtainedOrchestrionSet = new HashSet<uint>(Data.OrchestrionIDs);
                UnobtainedBardingsSet = new HashSet<uint>(Data.BardingIDs);
                UnobtainedFashionAccessoriesSet = new HashSet<uint>(Data.FashionIDs);
                UnobtainedOrchestrion = JsonSerializer.Serialize(UnobtainedOrchestrionSet);
                UnobtainedBardings = JsonSerializer.Serialize(UnobtainedBardingsSet);
                UnobtainedFashionAccessories = JsonSerializer.Serialize(UnobtainedFashionAccessoriesSet);
                PluginDataVersion = "0.3.0.0";
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
				RaceChocoboPedigree = (manager->Parameters & 0x1e) >> 1;
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

		internal unsafe void UpdateHairstyleUnlocks(UIState* UiState)
		{
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
			}
			UnobtainedHairstyles = JsonSerializer.Serialize(UnobtainedHairstylesSet);
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
			var playerState = UiState->PlayerState;
			ClassLevel = playerState.ClassJobLevelArray[Plugin.ClassJobs.GetRow(ClassID)!.ExpArrayIndex];

			LevelCrp = playerState.ClassJobLevelArray[7];
			LevelBsm = playerState.ClassJobLevelArray[8];
			LevelArm = playerState.ClassJobLevelArray[9];
			LevelGsm = playerState.ClassJobLevelArray[10];
			LevelLtw = playerState.ClassJobLevelArray[11];
			LevelWvr = playerState.ClassJobLevelArray[12];
			LevelAlc = playerState.ClassJobLevelArray[13];
			LevelCul = playerState.ClassJobLevelArray[14];
			LevelMin = playerState.ClassJobLevelArray[15];
			LevelBtn = playerState.ClassJobLevelArray[16];
			LevelFsh = playerState.ClassJobLevelArray[17];

		}

        internal unsafe void UpdateDesynthesisLevels(UIState* UiState)
        {
            var playerState = UiState->PlayerState;

            DesynthesisLevelCrp = playerState.GetDesynthesisLevel(7);
            DesynthesisLevelBsm = playerState.GetDesynthesisLevel(8);
            DesynthesisLevelArm = playerState.GetDesynthesisLevel(9);
            DesynthesisLevelGsm = playerState.GetDesynthesisLevel(10);
            DesynthesisLevelLtw = playerState.GetDesynthesisLevel(11);
            DesynthesisLevelWvr = playerState.GetDesynthesisLevel(12);
            DesynthesisLevelAlc = playerState.GetDesynthesisLevel(13);
            DesynthesisLevelCul = playerState.GetDesynthesisLevel(14);
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

        internal unsafe void UpdateOrchestrions(UIState* UiState)
        {
            foreach (var orchestrionId in UnobtainedOrchestrionSet)
            {
                if (UiState->PlayerState.IsOrchestrionRollUnlocked(orchestrionId)!)
                {
                    UnobtainedOrchestrionSet.Remove(orchestrionId);
                }
            }
            UnobtainedOrchestrion = JsonSerializer.Serialize(UnobtainedOrchestrionSet);
        }

        internal unsafe void UpdateBardings(UIState* UiState)
        {
            foreach (var bardingId in UnobtainedBardingsSet)
            {
                var itemPtr = FFXIVClientStructs.FFXIV.Component.Exd.ExdModule.GetItemRowById(bardingId);
                if (itemPtr != null)
                {
                    if (UiState->IsItemActionUnlocked(itemPtr) == 1)
                    {
                        UnobtainedBardingsSet.Remove(bardingId);
                    }
                }
            }
            UnobtainedBardings = JsonSerializer.Serialize(UnobtainedBardingsSet);
        }

        internal unsafe void UpdateFashionAccessories(UIState* UiState)
        {
            foreach (var fashionId in UnobtainedFashionAccessoriesSet)
            {
                if (UiState->PlayerState.IsOrnamentUnlocked(fashionId)!)
                {
                    UnobtainedFashionAccessoriesSet.Remove(fashionId);
                }
            }
            UnobtainedFashionAccessories = JsonSerializer.Serialize(UnobtainedFashionAccessoriesSet);
        }

        internal unsafe void UpdateCustomDeliveries()
		{
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
				CustomDeliveryRanksList[(int)i - 1] = cdInstance->Rank[i - 1];
			}
			LockedCustomDeliveries = JsonSerializer.Serialize(LockedCustomDeliveriesSet);
			CustomDeliveryRanks = JsonSerializer.Serialize(CustomDeliveryRanksList);
		}

        internal unsafe void UpdateBeastTribes()
        {
            for (byte i = 1; i < Plugin.BeastTribes.RowCount; i++)
            {
                BeastTribeRanksList[(int)i - 1] = UIState.Instance()->PlayerState.GetBeastTribeRank(i);
            }
            BeastTribeRanks = JsonSerializer.Serialize(BeastTribeRanksList);
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

		internal unsafe void UpdateRetainerArray(byte* array, ICollection<uint> itemIDs)
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

        internal bool IsOrchestrionUnlocked(uint orchestrionId)
        {
            return !UnobtainedOrchestrionSet.Contains(orchestrionId);
        }

        internal bool IsBardingUnlocked(uint bardingId)
        {
            return !UnobtainedBardingsSet.Contains(bardingId);
        }

        internal bool IsFashionUnlocked(uint fashionId)
        {
            return !UnobtainedFashionAccessoriesSet.Contains(fashionId);
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

        internal String GetHildibrandProgress()
        {
            if (IsQuestComplete(70255))
            {
                return "Complete";
            }
            else if (IsQuestComplete(68704))
            {
                return "Endwalker";
            }
            else if (IsQuestComplete(67908))
            {
                return "Stormblood";
            }
            else if (IsQuestComplete(66038))
            {
                return "Heavensward";
            }
            else if (IsQuestComplete(66740))
            {
                return "A Realm Reborn";
            }
            else
            {
                return "Not started";
            }
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
        internal Retainer() => Owner = new Chara(0, 0);

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

			for (var i = 0; i < retainerManager->GetRetainerCount(); i++)
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
					while (slotIndex < storedSlots.Count && storedSlots[slotIndex].Inventory == type)
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
