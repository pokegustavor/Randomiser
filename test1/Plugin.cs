using System.Collections;
using System.IO;
using HarmonyLib;
using PulsarModLoader;
using UnityEngine;

namespace Randomizer
{
    public class Mod : PulsarMod
    {
        public override string Version => "7.0";

        public override string Author => "pokegustavo + badryuiner's custom save";

        public override string ShortDescription => "Makes all ship have random items";

        public override string Name => "Randomiser";

        public override string HarmonyIdentifier()
        {
            return "pokegustavo.Randomiser";
        }
        internal static Mod plugin;
        public Mod()
        {
            SaveManager.instance.RegisterReader(this, AuxReader);
            SaveManager.instance.RegisterWriter(this, AuxWriter);
            config = new Config { level = false, bossitem = false, shouldlevel = true, limit = -1, times = 0, randomship = false, shouldrandomship = true, randomjump = false, currentjump = 0, jumpmax = -1 };
            plugin = this;
        }

        private void AuxReader(BinaryReader reader)
        {
            config.level = reader.ReadBoolean();
            config.bossitem = reader.ReadBoolean();
            config.shouldlevel = reader.ReadBoolean();
            config.times = reader.ReadInt32();
            config.limit = reader.ReadInt32();
            config.randomship = reader.ReadBoolean();
            config.shouldrandomship = reader.ReadBoolean();
            config.randomjump = reader.ReadBoolean();
            config.currentjump = reader.ReadInt32();
            config.jumpmax = reader.ReadInt32();
        }
        private void AuxWriter(BinaryWriter writer)
        {
            writer.Write(Configs.level);
            writer.Write(Configs.bossitem);
            writer.Write(Configs.shouldlevel);
            writer.Write(Configs.times);
            writer.Write(Configs.limit);
            writer.Write(Configs.randomship);
            writer.Write(Configs.shouldrandomship);
            writer.Write(Configs.randomjump);
            writer.Write(Configs.currentjump);
            writer.Write(Configs.jumpmax);
        }

        internal static Config config;

        internal struct Config
        {
            public bool level, bossitem, shouldlevel, randomship, shouldrandomship, randomjump;
            public int times, limit, currentjump, jumpmax;
        }
        internal IEnumerator SetupConfigs()
        {
            while (PLEncounterManager.Instance?.PlayerShip?.AuxConfig == null) yield return new WaitForEndOfFrame();
            if (Mod.config.shouldlevel) Configs.shouldlevel = true;
            yield return new WaitForEndOfFrame();
            if (Mod.config.level) Configs.level = true;
            yield return new WaitForEndOfFrame();
            if (!Mod.config.bossitem) Configs.bossitem = false;
            yield return new WaitForEndOfFrame();
            Configs.times = Mod.config.times;
            yield return new WaitForEndOfFrame();
            Configs.limit = Mod.config.limit;
            yield return new WaitForEndOfFrame();
            if (Mod.config.randomship) Configs.randomship = true;
            yield return new WaitForEndOfFrame();
            if (!Mod.config.shouldrandomship) Configs.shouldrandomship = false;
            yield return new WaitForEndOfFrame();
            if (Mod.config.randomjump) Configs.randomjump = true;
            yield return new WaitForEndOfFrame();
            Configs.currentjump = Mod.config.currentjump;
            yield return new WaitForEndOfFrame();
            Configs.jumpmax = Mod.config.jumpmax;
            yield return new WaitForEndOfFrame();
            Random.setlock(PLEncounterManager.Instance.PlayerShip, Configs.randomjump);

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
                    Configs.shouldrandomship = true;
                    Configs.randomjump = false;
                    Configs.jumpmax = -1;
                    Configs.currentjump = 0;
                    PLServer.Instance.StartCoroutine(Mod.plugin.SetupConfigs());
                }
            }
        }
    }
}
