using Dalamud.Game;
using FFXIVClientStructs.Interop.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFXIVCharaTracker
{
	internal unsafe class Gathering
	{
		public static byte* GatheringData;
		public static byte* FishingData;
		public static byte* SpearfishingData;

		public static void Initialise()
		{
			Gathering.GatheringData = (byte*)Plugin.SigScanner.GetStaticAddressFromSig("4C 8D 05 ?? D8 ?? ?? 0F B6 41 01 42 88 04 02");
			Gathering.FishingData = (byte*)Plugin.SigScanner.GetStaticAddressFromSig("48 8D 0D ?? ?? ?? ?? 41 0F B6 0C 08 41 B0 01 84 D1 0F 95 C1");
			Gathering.SpearfishingData = (byte*)Plugin.SigScanner.GetStaticAddressFromSig("48 8D 0D ?? ?? ?? ?? 41 0F B6 0C 08 41 B0 01 84 D1 48 8B");
		}
	}
}
