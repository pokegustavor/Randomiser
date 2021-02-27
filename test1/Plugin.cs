using PulsarPluginLoader;
using System;

namespace Randomizer
{
    public class Plugin : PulsarPlugin
    {
        private void test()
        {
            System.Random random = new System.Random();
            int oi = random.Next();
        }
        public override string Version => "2.0";

        public override string Author => "pokegustavo";

        public override string ShortDescription => "Makes the start ship have random items";

        public override string Name => "Randomiser";

        public override string HarmonyIdentifier()
        {
            return "pokegustavo.Randomiser";
        }
    }
}
