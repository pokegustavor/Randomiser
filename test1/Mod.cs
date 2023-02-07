using System.Collections;
using System.IO;
using HarmonyLib;
using PulsarModLoader;
using UnityEngine;

namespace Randomizer
{
    public class Mod : PulsarMod
    {
        public override string Version => "7.2";

        public override string Author => "pokegustavo";

        public override string ShortDescription => "Makes all ship have random items";

        public override string Name => "Randomiser";

        public override string HarmonyIdentifier()
        {
            return "pokegustavo.Randomiser";
        }
        [HarmonyPatch(typeof(PLServer), nameof(PLServer.SpawnPlayerShipFromSaveData))]
        internal class Patch
        {
            static void Prefix()
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
            }
        }
    }
}
