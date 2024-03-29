﻿using Dalamud.Data;
using Dalamud.Game;
using Dalamud.Game.ClientState;
using Dalamud.Game.Command;
using Dalamud.Game.Gui;
using Dalamud.IoC;
using Dalamud.Plugin;
using FFXIVCharaTracker.DB;
using FFXIVClientStructs.FFXIV.Client.Game;
using FFXIVClientStructs.FFXIV.Client.Game.UI;
using FFXIVClientStructs.Interop;
using Lumina.Excel.GeneratedSheets;
using System.Diagnostics;
using XivCommon;
using Microsoft.EntityFrameworkCore;


namespace FFXIVCharaTracker
{
    internal class Plugin : IDalamudPlugin
    {
        public string Name => "FFXIVCharaTracker";
        public static string DataVersion => "0.3.0.0";

        [PluginService]
        internal static DalamudPluginInterface PluginInterface { get; private set; } = null!;

        [PluginService]
        internal static CommandManager CommandManager { get; private set; } = null!;

        [PluginService]
        internal static ClientState ClientState { get; private set; } = null!;

        [PluginService]
        internal static DataManager DataManager { get; private set; } = null!;

        [PluginService]
        internal static Framework FrameworkInst { get; private set; } = null!;
        [PluginService]
        internal static GameGui Gui { get; private set; } = null!;
		[PluginService]
		internal static ChatGui Chat { get; private set; } = null!;
		[PluginService]
        internal static SigScanner SigScanner { get; private set; } = null!;
        internal static XivCommonBase Common { get; private set; } = null!;
        internal Configuration Configuration { get; }
        internal PluginUI UI { get; }
        private Commands Commands { get; }
        internal static ActiveRetainerManager Retainers { get; set; } = null!;
        internal static DB.Chara? CurCharaData { get; set; }
        internal DB.CharaContext Context { get; private set; }

        internal bool CharaLoaded = false;
        internal bool WaitingOnRetainer = false;
        internal Task? DatabaseSave;

        internal readonly Stopwatch SwUpdate = new();
        internal const int UpdateTime = 1000;

        internal static Lumina.Excel.ExcelSheet<Item> ItemSheet = null!;
        internal Lumina.Excel.ExcelSheet<ClassJobCategory> ClassJobCategories;
        internal static Lumina.Excel.ExcelSheet<ClassJob> ClassJobs = null!;
        internal static Lumina.Excel.ExcelSheet<Emote> Emotes = null!;
        internal static Lumina.Excel.ExcelSheet<SatisfactionNpc> SatisfactionNpcs = null!;
        internal Lumina.Excel.ExcelSheet<ENpcResident> ENpcResidents;
        internal Lumina.Excel.ExcelSheet<World> Worlds;
        internal Lumina.Excel.ExcelSheet<SecretRecipeBook> SecretRecipeBooks;
		internal static Lumina.Excel.ExcelSheet<GatheringItem> GatheringItems = null!;
		internal static Lumina.Excel.ExcelSheet<FishParameter> FishParameters = null!;
		internal static Lumina.Excel.ExcelSheet<SpearfishingItem> SpearfishingItems = null!;
		internal static Lumina.Excel.ExcelSheet<Recipe> Recipes = null!;
		internal static Lumina.Excel.ExcelSheet<CompanyCraftSequence> CompanyCraftSequences = null!;
		internal static Lumina.Excel.ExcelSheet<CompanyCraftProcess> CompanyCraftProcesses = null!;
		internal static Lumina.Excel.ExcelSheet<CompanyCraftSupplyItem> CompanyCraftSupplyItems = null!;
        internal static Lumina.Excel.ExcelSheet<BeastTribe> BeastTribes = null!;

        internal static readonly Dictionary<ulong, (Item, ItemUICategory)> ItemCache = new();
		internal static readonly Dictionary<uint, Recipe> RecipeCache = new();
		internal static readonly Dictionary<uint, CompanyCraftProcess> WorkshopCache = new();
		internal static readonly Dictionary<int, Recipe> ItemIDToRecipe = new();
		internal static readonly Dictionary<uint, ulong> ItemIDToSortID = new();

        internal readonly Queue<System.Action> queuedChanges = new();


        public Plugin()
        {
			Resolver.GetInstance.SetupSearchSpace(SigScanner.SearchBase);
			Resolver.GetInstance.Resolve();

            Gathering.Initialise();

			Common = new XivCommonBase();
			
            Configuration = PluginInterface.GetPluginConfig() as Configuration ?? new Configuration();
            Configuration.Initialize(PluginInterface);

			Context = new DB.CharaContext();
            UI = new PluginUI(this);
            Commands = new Commands(this);
            ClientState.Login += OnLogIn;
            ClientState.Logout += OnLogOut;
            FrameworkInst.Update += OnUpdate;
            Retainers = new ActiveRetainerManager();
            ItemSheet = DataManager.Excel.GetSheet<Item>()!;
            ClassJobCategories = DataManager.Excel.GetSheet<ClassJobCategory>()!;
            ClassJobs = DataManager.Excel.GetSheet<ClassJob>()!;
            Emotes = DataManager.Excel.GetSheet<Emote>()!;
			SatisfactionNpcs = DataManager.Excel.GetSheet<SatisfactionNpc>()!;
			ENpcResidents = DataManager.Excel.GetSheet<ENpcResident>()!;
			Worlds = DataManager.Excel.GetSheet<World>()!;
			SecretRecipeBooks = DataManager.Excel.GetSheet<SecretRecipeBook>()!;
			GatheringItems = DataManager.Excel.GetSheet<GatheringItem>()!;
			FishParameters = DataManager.Excel.GetSheet<FishParameter>()!;
			SpearfishingItems = DataManager.Excel.GetSheet<SpearfishingItem>()!;
			Recipes = DataManager.Excel.GetSheet<Recipe>()!;
			CompanyCraftSequences = DataManager.Excel.GetSheet<CompanyCraftSequence>()!;
			CompanyCraftProcesses = DataManager.Excel.GetSheet<CompanyCraftProcess>()!;
			CompanyCraftSupplyItems = DataManager.Excel.GetSheet<CompanyCraftSupplyItem>()!;
            BeastTribes = DataManager.Excel.GetSheet<BeastTribe>()!;

            _ = Task.Run(PopulateItemCache);

            SwUpdate.Start();
        }

        private void PopulateItemCache()
        {
            foreach (var row in ItemSheet)
            {
                if (row.Name == "")
                {
                    continue;
                }

                var uiSortData = row.ItemUICategory.Value!;

                var sortID = GetSortID(uiSortData, row.RowId);

				ItemIDToSortID[row.RowId] = sortID;
                ItemCache[sortID] = (row, row.ItemUICategory.Value!);
			}
            ItemIDToSortID[0] = 0;
            var zeroItem = ItemSheet.Where(it => it.RowId == 0).Single();
            ItemCache[0] = (zeroItem, zeroItem.ItemUICategory.Value!);

			foreach (var row in Recipes)
			{
				if (row.ItemResult.Value!.RowId == 0)
				{
					continue;
				}

				RecipeCache[row.RowId] = row;
                ItemIDToRecipe[(int)row.ItemResult.Value!.RowId] = row;
			}

			foreach (var row in CompanyCraftProcesses)
			{
				if (row.UnkData0[0].SupplyItem == 0)
				{
					continue;
				}

				WorkshopCache[row.RowId] = row;
			}
		}

		internal static ulong GetSortID(ItemUICategory uiSortData, uint rowID)
        {
            return ((ulong)uiSortData.OrderMajor << 40) | ((ulong)uiSortData.OrderMinor << 32) | rowID;
		}

        private unsafe void OnUpdate(Framework framework)
        {
            if (!CharaLoaded)
            {
                GetCharacterData();
            }

            Retainers.CheckRetainerId(framework.LastUpdate);

			if (CurCharaData == null)
            {
                return;
            }

            if (DatabaseSave != null && !DatabaseSave.IsCompleted)
            {
                return;
			}

            while (queuedChanges.Count > 0)
            {
                queuedChanges.Dequeue()();
            }


			if (SwUpdate.ElapsedMilliseconds > UpdateTime)
            {
                CurCharaData!.UpdateCharacterData();
                Retainer.UpdateRetainer(Context, CurCharaData);
//				PluginLog.Warning($"UpdateRetainer: {timer.ElapsedTicks * (1f / Stopwatch.Frequency) * 1000} ms");
				InventorySlot.StoreInventories(Context, CurCharaData);
//				PluginLog.Warning($"UpdateInventories: {timer.ElapsedTicks * (1f / Stopwatch.Frequency) * 1000} ms");
                SwUpdate.Restart();
			}

			DatabaseSave = Task.Run(Context.SaveChanges);
		}

		private void OnLogIn(object? sender, EventArgs e)
        {
            GetCharacterData();
        }

        private void OnLogOut(object? sender, EventArgs e)
        {
            CurCharaData = null;
            CharaLoaded = false;
		}

		internal unsafe void GetCharacterData()
        {
            var CurrentChara = ClientState.LocalPlayer;

            if (CurrentChara != null)
            {
                CurCharaData = Context.Charas.Where(c => c.CharaID == ClientState.LocalContentId).Include(c => c.Retainers).SingleOrDefault();

                CharaLoaded = true;

				if (CurCharaData != null)
				{
                    if (CurCharaData.PluginDataVersion != DataVersion)
                    {
                        Context.AddNewDataToCharacterArrays();
                    }
                    CurCharaData.UpdateCharacterPersonals(UIState.Instance());
                    CurCharaData.UpdateCharacterData();
                }

            }
        }

		public void Dispose()
        {
            Commands.Dispose();
            UI.Dispose();
            Context.Dispose();
            ClientState.Login -= OnLogIn;
            ClientState.Logout -= OnLogOut;
            FrameworkInst.Update -= OnUpdate;
            Common.Dispose();
        }
    }
}
