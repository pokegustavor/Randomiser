using PulsarPluginLoader;
using System;
using System.Collections;
using System.IO;
using PulsarPluginLoader.Utilities;
using UnityEngine;

namespace Randomizer
{
    public class Plugin : PulsarPlugin
    {
        public override string Version => "5.0";

        public override string Author => "pokegustavo";

        public override string ShortDescription => "Makes all ship have random items";

        public override string Name => "Randomiser";

        public override string HarmonyIdentifier()
        {
            return "pokegustavo.Randomiser";
        }

	}
}
