using Dalamud.Game.Command;
using Dalamud.IoC;
using Dalamud.Plugin;
using Dalamud.Game.Gui;
using Dalamud.Game.ClientState;
using Dalamud.Data;
using Dalamud.Game;
using Dalamud;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using Dalamud.Game.Text;
using Dalamud.Game.Text.SeStringHandling;
using Dalamud.Logging;
using System;
using System.Text;
using System.Text.RegularExpressions;
using XivCommon;
using Microsoft.EntityFrameworkCore;
using Dalamud.Game.ClientState.Objects.SubKinds;
using System.Linq;
using FFXIVClientStructs.FFXIV.Client.Game.Character;
using FFXIVClientStructs.FFXIV.Client.Game;
using Lumina.Excel.GeneratedSheets;
using FFXIVClientStructs.FFXIV.Client.UI.Agent;
using FFXIVClientStructs;
using FFXIVClientStructs.FFXIV.Client.Game.UI;
using FFXIVClientStructs.FFXIV.Component.Excel;
using System.Collections;
using System.Runtime.InteropServices;
using System.Diagnostics;
using FFXIVClientStructs.FFXIV.Component.GUI;
using FFXIVCharaTracker.DB;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Sqlite;
using FFXIVClientStructs.Interop;

namespace FFXIVCharaTracker
{
    internal class Plugin : IDalamudPlugin
    {
        public string Name => "FFXIVCharaTracker";
		public static string DataVersion => "0.1.0.0";

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
		internal static SigScanner SigScanner { get; private set; } = null!;
        internal static XivCommonBase Common { get; private set; } = null!;
        internal Configuration Configuration { get; }
        internal PluginUI UI { get; }
        private Commands Commands { get; }
        internal static ActiveRetainerManager Retainers { get; set; } = null!;
        internal DB.Chara? CurCharaData { get; private set; }
        internal DB.CharaContext Context { get; private set; }

        internal bool CharaLoaded = false;
        internal bool WaitingOnRetainer = false;
        internal bool WaitingOnHairstyles = false;

        internal readonly Stopwatch SwUpdate = new();
        internal readonly Stopwatch SwRetainer = new();
        internal const int UpdateTime = 10 * 60 * 1000;
		internal const int UpdateRetainersTime = 1000;

		internal static Lumina.Excel.ExcelSheet<Item> ItemSheet = null!;
        internal Lumina.Excel.ExcelSheet<ClassJobCategory> ClassJobCategories;
        internal static Lumina.Excel.ExcelSheet<ClassJob> ClassJobs = null!;
        internal static Lumina.Excel.ExcelSheet<Emote> Emotes = null!;
        internal static Lumina.Excel.ExcelSheet<SatisfactionNpc> SatisfactionNpcs = null!;
        internal Lumina.Excel.ExcelSheet<ENpcResident> ENpcResidents;
		internal Lumina.Excel.ExcelSheet<World> Worlds;
		internal Lumina.Excel.ExcelSheet<ContentFinderCondition> ContentFinderConditions;
        internal Lumina.Excel.ExcelSheet<SecretRecipeBook> SecretRecipeBooks;

		public Plugin()
        {
			Resolver.GetInstance.SetupSearchSpace(SigScanner.SearchBase);
			Resolver.GetInstance.Resolve();

			Common = new XivCommonBase();
			
            this.Configuration = PluginInterface.GetPluginConfig() as Configuration ?? new Configuration();
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
			ContentFinderConditions = DataManager.Excel.GetSheet<ContentFinderCondition>()!;
            SecretRecipeBooks = DataManager.Excel.GetSheet<SecretRecipeBook>()!;

			SwUpdate.Start();
            SwRetainer.Start();
        }

        private void OnUpdate(Framework framework)
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

            if (SwUpdate.ElapsedMilliseconds > UpdateTime)
            {
                UpdateCharacterData();
                SwUpdate.Restart();
            }

            if (SwRetainer.ElapsedMilliseconds > UpdateRetainersTime)
            {
                CurCharaData.UpdateRetainers();
                SwRetainer.Restart();
				Context.SaveChanges();
			}

			if (WaitingOnHairstyles)
            {
                unsafe
                {
					var UiState = UIState.Instance();
					CurCharaData.UpdateHairstyleUnlocks(UiState);
				}
			}
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

		internal void AddNewCharacter()
        {
			var CurrentChara = ClientState.LocalPlayer;

            if (CurrentChara != null)
            {
				CurCharaData = new Chara(ClientState.LocalContentId, CurrentChara.HomeWorld.Id,
					CurrentChara.Name.ToString().Split(' ')[0], CurrentChara.Name.ToString().Split(' ')[1])
				{
					PluginDataVersion = DataVersion
				};

				CurCharaData.SetDefaultArrays();

                Context.Add(CurCharaData);

                UpdateCharacterData();
            }

		}

		internal unsafe void GetCharacterData()
        {
            var CurrentChara = ClientState.LocalPlayer;

            if (CurrentChara != null)
            {
                CurCharaData = Context.Charas.SingleOrDefault(o => o.CharaID == ClientState.LocalContentId);

                CharaLoaded = true;

				if (CurCharaData != null &&
					CurCharaData.PluginDataVersion != DataVersion)
				{
					CurCharaData.PluginDataVersion = DataVersion;

					Context.SetDefaultArraysForAllCharas();
				}

				UpdateCharacterData();
            }
        }

        internal void UpdateCharacterData()
        {
            if (CurCharaData == null)
            {
                return;
            }

			var CurrentChara = ClientState.LocalPlayer;

            unsafe
            {
				var UiState = UIState.Instance();

                // Gear check
                if (!CurCharaData!.CurGear || !CurCharaData.GatherGear)
                {
                    var invManager = InventoryManager.Instance();
                    var inventory = invManager->GetInventoryContainer(InventoryType.EquippedItems);
					CurCharaData.UpdateGearState(inventory);
                    inventory = invManager->GetInventoryContainer(InventoryType.ArmoryBody);
					CurCharaData.UpdateGearState(inventory);
                }

				CurCharaData.UpdateOptionalInstanceUnlocks();
				CurCharaData.UpdateFolkloreUnlocks(UiState);
				CurCharaData.UpdateSecretRecipeUnlocks(UiState);
				CurCharaData.UpdateHairstyleUnlocks(UiState);
				CurCharaData.UpdateEmoteUnlocks(UiState);
				CurCharaData.UpdateLevels(UiState);
				CurCharaData.UpdateMinions(UiState);
                CurCharaData.UpdateMounts(UiState);

				CurCharaData.UpdateGCRank(UiState);
				CurCharaData.UpdateChocobo(UiState);

				CurCharaData.UpdateCustomDeliveries();
				CurCharaData.UpdateUnlockQuests(UiState);

                Context.SaveChanges();
            }

        }

		public void Dispose()
        {
            this.Commands.Dispose();
            this.UI.Dispose();
            Context.Dispose();
            ClientState.Login -= OnLogIn;
            ClientState.Logout -= OnLogOut;
            FrameworkInst.Update -= OnUpdate;
        }
    }
}
