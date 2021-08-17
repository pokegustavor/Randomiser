using PulsarPluginLoader.Chat.Commands;
using PulsarPluginLoader.Utilities;
using System.Collections.Generic;

namespace Randomizer
{
    class Command : IChatCommand
    {
        public string[] CommandAliases()
        {
            return new string[]
            {
                "rd",
                "random",
                "randomizer"
            };
        }
        public bool Execute(string arguments, int SenderID)
        {
            if (!PhotonNetwork.isMasterClient)
            {
                PLServer.Instance.AddNotification("You Must be host to use this command", PLNetworkManager.Instance.LocalPlayerID, PLServer.Instance.GetEstimatedServerMs() + 6000, false);
                return false;
            }
            string[] subcommand = arguments.Split(' ');
            bool ArgConvertSuccess = false;
            int CommandArg = 0;
            if (subcommand.Length > 1)
            {
                ArgConvertSuccess = int.TryParse(subcommand[1], out CommandArg);
            }
            switch (subcommand[0].ToLower())
            {
                default:
                    PLServer.Instance.AddNotification("Subcommands: roll, (limit + (value or off), level, vannila, jumprandom, jumplimit", PLNetworkManager.Instance.LocalPlayerID, PLServer.Instance.GetEstimatedServerMs() + 6000, false);
                    break;
                case "roll":
                    if ((Configs.times < Configs.limit || Configs.limit <= -1))
                    {
                        Random.random(PLEncounterManager.Instance.PlayerShip, false, true);
                        PLServer.Instance.ChaosLevel += 0.5f;
                        PLServer.Instance.AddNotification("Items Randomised", PLNetworkManager.Instance.LocalPlayerID, PLServer.Instance.GetEstimatedServerMs() + 6000, false);
                        Configs.times++;
                    }
                    else
                    {
                        PLServer.Instance.AddNotification("You can no longer use this command! Set a new limit or set limit to off for no limit", PLNetworkManager.Instance.LocalPlayerID, PLServer.Instance.GetEstimatedServerMs() + 8000, false);
                    }
                    break;
                case "limit":
                    if (ArgConvertSuccess && CommandArg > 0)
                    {
                        Configs.limit = CommandArg;
                        Configs.times = 0;
                        PLServer.Instance.AddNotification("New limit: " + Configs.limit, PLNetworkManager.Instance.LocalPlayerID, PLServer.Instance.GetEstimatedServerMs() + 4000, false);
                    }
                    else if (subcommand[1].ToLower() == "off")
                    {
                        Configs.limit = -1;
                        Messaging.Notification("limit disabled!", PLNetworkManager.Instance.LocalPlayer, default, 3000);
                    }
                    else
                    {
                        PLServer.Instance.AddNotification("Invalid limit value (Must be 1 or higher) or off", PLNetworkManager.Instance.LocalPlayerID, PLServer.Instance.GetEstimatedServerMs() + 6000, false);
                    }
                    break;
                case "level":
                case "lv":
                    Configs.level = !Configs.level;
                    if (Configs.shouldlevel && Configs.level)
                    {
                        Random.randomlevel(PLEncounterManager.Instance.PlayerShip);
                    }
                    Configs.shouldlevel = false;
                    Messaging.Notification("Random Levels " + (Configs.level ? "enabled" : "disabled"), PLNetworkManager.Instance.LocalPlayer, default, 3000);
                    break;
                case "vannila":
                case "vn":
                    Configs.bossitem = !Configs.bossitem;
                    Messaging.Notification("Not obtanable items " + (Configs.bossitem ? "enabled" : "disabled"), PLNetworkManager.Instance.LocalPlayer, default, 3000);
                    break;
                case "Rships":
                case "Rs":
                    Configs.randomship = !Configs.randomship;
                    Messaging.Notification("Random ship types " + (Configs.randomship ? "enabled" : "disabled"), PLNetworkManager.Instance.LocalPlayer, default, 3000);
                    if (Configs.shouldrandomship)
                    {
                        foreach (PLPersistantShipInfo ship in PLServer.Instance.AllPSIs)
                        {
                            Random.randomship(ship);
                        }
                        Configs.shouldrandomship = false;
                    }
                    break;
                case "jumprandom":
                case "jr":
                case "jumprandomizer":
                    Configs.randomjump = !Configs.randomjump;
                    Configs.jumpmax = Configs.randomjump ? 5 : -1;
                    Messaging.Notification("Jump Randomizer " + (Configs.randomjump ? "enabled" : "disabled"), PLNetworkManager.Instance.LocalPlayer, default, 3000);
                    Random.setlock(PLEncounterManager.Instance.PlayerShip, Configs.randomjump);
                    break;
                case "jumplimit":
                case "jl":
                    if (ArgConvertSuccess && CommandArg > 0)
                    {
                        Configs.jumpmax = CommandArg;
                        Configs.currentjump = 0;
                        PLServer.Instance.AddNotification("New jump limit: " + Configs.jumpmax, PLNetworkManager.Instance.LocalPlayerID, PLServer.Instance.GetEstimatedServerMs() + 4000, false);
                    }
                    else
                    {
                        PLServer.Instance.AddNotification("Invalid limit value (Must be 1 or higher)", PLNetworkManager.Instance.LocalPlayerID, PLServer.Instance.GetEstimatedServerMs() + 6000, false);
                    }
                    break;
            }
            return false;
        }
        public string Description()
        {
            if (Configs.limit <= -1)
            {
                return "Randomises your ship loadout(components level 1 and chaos+ 0.5)";
            }
            if (Configs.limit - Configs.times == 1)
            {
                return $"Randomises your ship loadout(components level 1 and chaos+ 0.5), can only be used {1} more time!";
            }
            else if (Configs.times == Configs.limit)
            {
                return $"Randomises your ship loadout(components level 1 and chaos+ 0.5), but it can no longer be used (reset the limit or remove it)";
            }
            return $"Randomises your ship loadout(components level 1 and chaos+ 0.5), can only be used {Configs.limit - Configs.times} more Configs.times";
        }
        public string UsageExample()
        {
            return "/" + this.CommandAliases()[0] + " roll, (limit + (value or off), level, vannila";
        }
        public bool PublicCommand()
        {
            return false;
        }
    }
}
