using System.Collections;
using System.IO;
using HarmonyLib;
using PulsarPluginLoader;
using UnityEngine;

namespace Randomizer
{
    public class Plugin : PulsarPlugin
    {
        public override string Version => "5.2";

        public override string Author => "pokegustavo + badryuiner's custom save";

        public override string ShortDescription => "Makes all ship have random items";

        public override string Name => "Randomiser";

        public override string HarmonyIdentifier()
        {
            return "pokegustavo.Randomiser";
        }

        internal static Plugin plugin;
        public Plugin()
        {            
            CustomSaves.SaveManager.instance.RegisterReader(this, AuxReader);
            CustomSaves.SaveManager.instance.RegisterWriter(this, AuxWriter);
            config = new Config { level = false, bossitem = false, shouldlevel = true, limit = -1, times = 0 };
            plugin = this;
        }

        private void AuxReader(BinaryReader reader)
        {
            config.level = reader.ReadBoolean();
            config.bossitem = reader.ReadBoolean();
            config.shouldlevel = reader.ReadBoolean();
            config.times = reader.ReadInt32();
            config.limit = reader.ReadInt32();
        }
        private void AuxWriter(BinaryWriter writer)
        {
            writer.Write(Configs.level);
            writer.Write(Configs.bossitem);
            writer.Write(Configs.shouldlevel);
            writer.Write(Configs.times);
            writer.Write(Configs.limit);
        }

        internal static Config config;

        internal struct Config
        {
            public bool level, bossitem, shouldlevel;
            public int times, limit;
        }
        internal IEnumerator SetupConfigs()
        {
            while (PLEncounterManager.Instance?.PlayerShip?.AuxConfig == null) yield return new WaitForEndOfFrame();
            if (Plugin.config.shouldlevel) Configs.shouldlevel = true;
            yield return new WaitForEndOfFrame();
            if (Plugin.config.level) Configs.level = true;
            yield return new WaitForEndOfFrame();
            if (!Plugin.config.bossitem) Configs.bossitem = false;
            yield return new WaitForEndOfFrame();
            Configs.times = Plugin.config.times;
            yield return new WaitForEndOfFrame();
            Configs.limit = Plugin.config.limit;
        }

        [HarmonyPatch(typeof(PLServer), nameof(PLServer.SpawnPlayerShipFromSaveData))]
        internal class Patch
        {
            static void Postfix()
            {
                if (PhotonNetwork.isMasterClient)
                {
                    Configs.times = 0;
                    Configs.limit = -1;
                    Configs.level = false;
                    Configs.bossitem = true;
                    Configs.shouldlevel = true;
                    PLServer.Instance.StartCoroutine(Plugin.plugin.SetupConfigs());
                }
            }
        }
    }
}
