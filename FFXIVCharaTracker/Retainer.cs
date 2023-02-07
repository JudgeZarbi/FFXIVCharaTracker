using FFXIVClientStructs.FFXIV.Client.System.Framework;
using Dalamud.Logging;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FFXIVCharaTracker
{
	[StructLayout(LayoutKind.Explicit, Size = 45896)]
	public unsafe struct ItemOrderModule
	{
		public static ItemOrderModule* Instance()
		{
			return (ItemOrderModule*)Framework.Instance()->GetUiModule()->GetItemOrderModule();
		}

		[FieldOffset(0)] public void* vtbl;
		[FieldOffset(48)] public fixed byte ModuleName[16];
		[FieldOffset(64)] public ItemOrderContainer* PlayerInventory;
		[FieldOffset(72)] public ItemOrderArmoury Armoury;

		[FieldOffset(176)] public ulong RetainerID;
		[FieldOffset(184)] public OrderRetainerWrapper* Retainers;
		[FieldOffset(192)] public uint RetainerCount;

		[FieldOffset(200)] public ItemOrderContainer* SaddleBagNormal;
		[FieldOffset(208)] public ItemOrderContainer* SaddleBagPremium;

		[StructLayout(LayoutKind.Sequential, Size = 104)]
		public unsafe struct ItemOrderArmoury
		{
			public ItemOrderContainer* MainHand;
			public ItemOrderContainer* Head;
			public ItemOrderContainer* Body;
			public ItemOrderContainer* Hands;
			public ItemOrderContainer* Legs;
			public ItemOrderContainer* Feet;
			public ItemOrderContainer* OffHand;
			public ItemOrderContainer* Ears;
			public ItemOrderContainer* Neck;
			public ItemOrderContainer* Wrists;
			public ItemOrderContainer* Rings;
			public ItemOrderContainer* SoulCrystal;
		}

		[StructLayout(LayoutKind.Explicit, Size = 96)]
		public unsafe struct ItemOrderContainer
		{
			[FieldOffset(0)] public uint containerId;
			[FieldOffset(4)] public uint Unk04;
			[FieldOffset(8)] public ItemOrderContainerSlot** Slots;
			[FieldOffset(16)] public void* Unk10;
			[FieldOffset(24)] public void* Unk18;
			[FieldOffset(32)] public void* Unk20;
			[FieldOffset(40)] public uint SlotPerContainer;
			[FieldOffset(44)] public uint Unk2C;
			[FieldOffset(48)] public void* Unk30;
			[FieldOffset(56)] public int Unk38;
			[FieldOffset(60)] public int Unk3C;
			[FieldOffset(64)] public void* Unk40;
			[FieldOffset(72)] public void* Unk48;
			[FieldOffset(80)] public void* Unk50;
			[FieldOffset(88)] public int Unk58;
			[FieldOffset(92)] public int Unk5C;
		}

		[StructLayout(LayoutKind.Explicit, Size = 4)]
		public unsafe struct ItemOrderContainerSlot
		{
			[FieldOffset(0)] public ushort ContainerIndex;
			[FieldOffset(2)] public ushort SlotIndex;
		}

		[StructLayout(LayoutKind.Explicit, Size = 8)]
		public struct OrderRetainerWrapper
		{
			[FieldOffset(0)] public OrderRetainerSort* SortOrders;
		}

		[StructLayout(LayoutKind.Explicit, Size = 40 * 64 * 9 + 8)]
		public struct OrderRetainerSort
		{
			[FieldOffset(0)] public void* Unk00;
			[FieldOffset(8)] public void* Unk08;
			[FieldOffset(16)] public void* Unk10;
			[FieldOffset(24)] public void* Unk18;
			[FieldOffset(32)] public ulong Retainer1Id;
			[FieldOffset(40)] public ItemOrderContainer* Retainer1Bag;
			[FieldOffset(32 + 64 * 1)] public ulong Retainer2Id;
			[FieldOffset(40 + 64 * 1)] public ItemOrderContainer* Retainer2Bag;
			[FieldOffset(32 + 64 * 2)] public ulong Retainer3Id;
			[FieldOffset(40 + 64 * 2)] public ItemOrderContainer* Retainer3Bag;
			[FieldOffset(32 + 64 * 3)] public ulong Retainer4Id;
			[FieldOffset(40 + 64 * 3)] public ItemOrderContainer* Retainer4Bag;
			[FieldOffset(32 + 64 * 4)] public ulong Retainer5Id;
			[FieldOffset(40 + 64 * 4)] public ItemOrderContainer* Retainer5Bag;
			[FieldOffset(32 + 64 * 5)] public ulong Retainer6Id;
			[FieldOffset(40 + 64 * 5)] public ItemOrderContainer* Retainer6Bag;
			[FieldOffset(32 + 64 * 6)] public ulong Retainer7Id;
			[FieldOffset(40 + 64 * 6)] public ItemOrderContainer* Retainer7Bag;
			[FieldOffset(32 + 64 * 7)] public ulong Retainer8Id;
			[FieldOffset(40 + 64 * 7)] public ItemOrderContainer* Retainer8Bag;
			[FieldOffset(32 + 64 * 8)] public ulong Retainer9Id;
			[FieldOffset(40 + 64 * 8)] public ItemOrderContainer* Retainer9Bag;
			[FieldOffset(32 + 64 * 9)] public ulong Retainer10Id;
			[FieldOffset(40 + 64 * 9)] public ItemOrderContainer* Retainer10Bag;
		}
	}


	internal class ActiveRetainerManager
	{
		public delegate void ActiveRetainerChangedDelegate(ulong retainerId);
		public event ActiveRetainerChangedDelegate? OnActiveRetainerLoaded;

		private ulong InternalRetainerId
		{
			get
			{
				unsafe
				{
					var clientInterfaceUiModule = (ItemOrderModule*)FFXIVClientStructs.FFXIV.Client.System.Framework.Framework
						.Instance()->UIModule->GetItemOrderModule();
					var module = clientInterfaceUiModule;
					if (module != null)
					{
						return module->RetainerID;
					}
					return 0;
				}
			}
		}

		private ulong _activeRetainer;
		public DateTime? _lastRetainerSwap;
		private bool _isRetainerLoaded = false;
		public ulong ActiveRetainer => _activeRetainer;

		internal void CheckRetainerId(DateTime lastUpdate)
		{
			var retainerId = this.InternalRetainerId;
			if (ActiveRetainer != retainerId)
			{
				if (_lastRetainerSwap == null)
				{
					_isRetainerLoaded = false;
					_activeRetainer = retainerId;
					_lastRetainerSwap = lastUpdate;
					return;
				}
			}
			var waitTime = retainerId == 0 ? 1 : 2;
			//This is the best I can come up with due it the retainer ID changing but the inventory takes almost a second to loate(I assume as it loads in from the network). This won't really take bad network conditions into account but until I can come up with a more reliable way it'll have to do
			if (_lastRetainerSwap != null && _lastRetainerSwap.Value.AddSeconds(waitTime) <= lastUpdate)
			{
				_lastRetainerSwap = null;
				//Make sure the retainer is fully loaded before firing the event
				if (retainerId != 0)
				{
					_activeRetainer = retainerId;
					_isRetainerLoaded = true;
					OnActiveRetainerLoaded?.Invoke(ActiveRetainer);
				}
			}

			if (_lastRetainerSwap == null && ActiveRetainer != 0 && !_isRetainerLoaded)
			{
				_isRetainerLoaded = true;
			}
		}
	}
}
