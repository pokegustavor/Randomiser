using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using CustomSaves;
using HarmonyLib;
using PulsarModLoader;
using PulsarModLoader.Patches;
using PulsarModLoader.Utilities;

namespace Randomizer
{
    class SaveManager
    {
        internal struct ShieldStruct
        {
            internal string modname;

            internal long writedsize;
        }
		[HarmonyPatch(typeof(PLSaveGameIO))]
		internal class PLSaveGameIOHook
		{
			[HarmonyPatch("LoadFromFile")]
			[HarmonyTranspiler]
			private static IEnumerable<CodeInstruction> ReadSave(IEnumerable<CodeInstruction> Instructions, ILGenerator generator)
			{
				List<CodeInstruction> list = new List<CodeInstruction>();
				list.Add(new CodeInstruction(OpCodes.Ldloc_1));
				list.Add(new CodeInstruction(OpCodes.Callvirt, AccessTools.Method(typeof(BinaryReader), "Close")));
				IEnumerable<CodeInstruction> enumerable = list;
				list = new List<CodeInstruction>();
				list.Add(new CodeInstruction(OpCodes.Call, AccessTools.PropertyGetter(typeof(SaveManager), "instance")));
				list.Add(new CodeInstruction(OpCodes.Ldloca_S, (byte)1));
				list.Add(new CodeInstruction(OpCodes.Ldarg_3));
				list.Add(new CodeInstruction(OpCodes.Callvirt, AccessTools.Method(typeof(SaveManager), "HookHelperR")));
				IEnumerable<CodeInstruction> enumerable2 = list;
				return HarmonyHelpers.PatchBySequence(Instructions, enumerable, enumerable2, HarmonyHelpers.PatchMode.BEFORE, HarmonyHelpers.CheckMode.ALWAYS, false);
			}

			[HarmonyPatch("SaveToFile")]
			[HarmonyTranspiler]
			private static IEnumerable<CodeInstruction> WriteSave(IEnumerable<CodeInstruction> Instructions, ILGenerator generator)
			{
				List<CodeInstruction> list = new List<CodeInstruction>();
				list.Add(new CodeInstruction(OpCodes.Ldloc_3));
				list.Add(new CodeInstruction(OpCodes.Callvirt, AccessTools.Method(typeof(BinaryWriter), "Close")));
				IEnumerable<CodeInstruction> enumerable = list;
				list = new List<CodeInstruction>();
				list.Add(new CodeInstruction(OpCodes.Call, AccessTools.PropertyGetter(typeof(SaveManager), "instance")));
				list.Add(new CodeInstruction(OpCodes.Ldloca_S, (byte)3));
				list.Add(new CodeInstruction(OpCodes.Callvirt, AccessTools.Method(typeof(SaveManager), "HookHelperW")));
				IEnumerable<CodeInstruction> enumerable2 = list;
				return HarmonyHelpers.PatchBySequence(Instructions, enumerable, enumerable2, HarmonyHelpers.PatchMode.BEFORE, HarmonyHelpers.CheckMode.ALWAYS, false);
			}
		}
		private static SaveManager _instance;

		internal List<ShieldStruct> shield = new List<ShieldStruct>();

		internal Dictionary<PulsarMod, Action<BinaryWriter>> Writers;

		internal Dictionary<PulsarMod, Action<BinaryReader>> Readers;

		public static SaveManager instance
		{
			get
			{
				if (_instance != null)
				{
					return _instance;
				}
				_instance = new SaveManager();
				return _instance;
			}
			set
			{
				_instance = value;
			}
		}
		internal SaveManager()
		{
			Writers = new Dictionary<PulsarMod, Action<BinaryWriter>>();
			Readers = new Dictionary<PulsarMod, Action<BinaryReader>>();
		}
		public void RegisterReader(PulsarMod plugin, Action<BinaryReader> reader)
		{
			Readers.Add(plugin, reader);
		}
		public void RegisterWriter(PulsarMod plugin, Action<BinaryWriter> writer)
		{
			Writers.Add(plugin, writer);
		}
		internal void HookHelperW(ref BinaryWriter writer)
		{
			shield.Clear();
			foreach (KeyValuePair<PulsarMod, Action<BinaryWriter>> writer2 in Writers)
			{
				writer.Write(writer2.Key.Name);
				long position = writer.BaseStream.Position;
				try
				{
					writer2.Value(writer);
					AddToShieldList(writer2.Key.Name, position, writer.BaseStream.Position);
					Logger.Info($"{writer2.Key.Name}, {position}, {writer.BaseStream.Position}");
				}
				catch (Exception ex)
				{
					Logger.Info("[SaveManager : Exception] Plugin " + writer2.Key.Name + " invoke exception in BinaryReader! \n" + ex.Message);
					throw;
				}
			}
			WriteShield(writer);
		}
		internal void HookHelperR(ref BinaryReader reader, bool safe)
		{
			Dictionary<string, long> dictionary = null;
			long RealEnd = reader.BaseStream.Length;
			if (safe && reader.BaseStream.Position != reader.BaseStream.Length)
			{
				dictionary = ReadShield(reader, out RealEnd);
			}
			while (safe && reader.BaseStream.Position != RealEnd)
			{
				string text = reader.ReadString();
				Action<BinaryReader> action = Who(text);
				if (action != null)
				{
					action(reader);
					continue;
				}
				Logger.Info("[SaveManager : Error] No any BinaryReader from plugin with name - " + text);
				try
				{
					if (dictionary.TryGetValue(text, out var value))
					{
						reader.BaseStream.Position += value;
					}
				}
				catch (Exception ex)
				{
					Logger.Info(ex.ToString());
				}
			}
		}
		internal Dictionary<string, long> ReadShield(BinaryReader reader, out long RealEnd)
		{
			shield.Clear();
			long position = reader.BaseStream.Position;
			reader.BaseStream.Position = reader.BaseStream.Length - 8;
			long num = reader.ReadInt64();
			reader.BaseStream.Position = num;
			Dictionary<string, long> dictionary = new Dictionary<string, long>();
			string[] array = reader.ReadString().Split('\n');
			foreach (string text in array)
			{
				Logger.Info(text);
				string[] source = text.Split('╜');
				dictionary.Add(source.First(), long.Parse(source.Last()));
			}
			reader.BaseStream.Position = position;
			RealEnd = num;
			return dictionary;
		}
		internal void WriteShield(BinaryWriter writer)
		{
			long position = writer.BaseStream.Position;
			writer.Write(CreateShieldSting());
			writer.Write(position);
		}
		internal string CreateShieldSting()
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (ShieldStruct item in shield)
			{
				stringBuilder.Append($"{item.modname}╜{item.writedsize}\n");
			}
			string text = stringBuilder.ToString();
			return text.Remove(text.Length - 1);
		}
		internal void AddToShieldList(string Modname, long firstpos, long secondpos)
		{
			shield.Add(new ShieldStruct
			{
				modname = Modname,
				writedsize = secondpos - firstpos
			});
		}
		internal Action<BinaryReader> Who(string mod)
		{
			IEnumerable<KeyValuePair<PulsarMod, Action<BinaryReader>>> source = Readers.Where(delegate (KeyValuePair<PulsarMod, Action<BinaryReader>> reader)
			{
				KeyValuePair<PulsarMod, Action<BinaryReader>> keyValuePair = reader;
				return keyValuePair.Key.Name == mod;
			});
			if (source.Any())
			{
				return source.First().Value;
			}
			return null;
		}
	}
}
