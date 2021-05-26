using PulsarPluginLoader.Chat.Commands;
using PulsarPluginLoader.Utilities;
using System.Collections.Generic;

namespace Randomizer
{
    class Command : IChatCommand
    {
        int times = 3;
        int limit = -1;
        public static bool level = false;
        public static bool shouldlevel = true;

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
                    PLServer.Instance.AddNotification("Subcommands: Limit (value or off), roll", PLNetworkManager.Instance.LocalPlayerID, PLServer.Instance.GetEstimatedServerMs() + 6000, false);
                    break;
                case "roll":
                    if ((times < limit || limit <= -1))
                    {
                        Random.random(PLEncounterManager.Instance.PlayerShip, false, true);
                        PLServer.Instance.ChaosLevel += 0.5f;
                        PLServer.Instance.AddNotification("Items Randomised", PLNetworkManager.Instance.LocalPlayerID, PLServer.Instance.GetEstimatedServerMs() + 6000, false);
                        times++;
                    }
                    else
                    {
                        PLServer.Instance.AddNotification("You can no longer use this command! Set a new limit or set limit to off for no limit", PLNetworkManager.Instance.LocalPlayerID, PLServer.Instance.GetEstimatedServerMs() + 8000, false);
                    }
                    break;
                case "limit":
                    
                    if (ArgConvertSuccess)
                    {
                        limit = CommandArg;
                        times = 0;
                        PLServer.Instance.AddNotification("New limit: " + limit, PLNetworkManager.Instance.LocalPlayerID, PLServer.Instance.GetEstimatedServerMs() + 4000, false);
                    }
                    else if (subcommand[1].ToLower() == "off")
                    {
                        limit = -1;
                        Messaging.Notification("Limit disabled!", PLNetworkManager.Instance.LocalPlayer, default, 3000);
                    }
                    else
                    {
                        PLServer.Instance.AddNotification("Invalid limit value (Must be 1 or higher) or off", PLNetworkManager.Instance.LocalPlayerID, PLServer.Instance.GetEstimatedServerMs() + 6000, false);
                    }

                    break;
                case "level":
                    level = !level;
                    foreach(PLShipComponent component in PLEncounterManager.Instance.PlayerShip.MyStats.AllComponents)
                    {
                        if(component.Level > 9)
                        {
                            shouldlevel = false;
                        }
                    }
                    if (shouldlevel)
                    {
                        Random.randomlevel(PLEncounterManager.Instance.PlayerShip);
                    }
                    shouldlevel = false;
                    Messaging.Notification("Random Levels " + (level ? "enabled":"disabled"), PLNetworkManager.Instance.LocalPlayer, default, 3000);
                    break;
            }
            return false;
        }
        public string Description()
        {
            if (limit <= -1)
            {
                return "Randomises your ship loadout(components level 1 and chaos+ 0.5)";
            }
            if (limit - times == 1)
            {
                return $"Randomises your ship loadout(components level 1 and chaos+ 0.5), can only be used {1} more time!";
            }
            else if (times == limit)
            {
                return $"Randomises your ship loadout(components level 1 and chaos+ 0.5), but it can no longer be used (reset the limit or remove it)";
            }
            return $"Randomises your ship loadout(components level 1 and chaos+ 0.5), can only be used {limit - times} more times";
        }
        public string UsageExample()
        {
            return "/" + this.CommandAliases()[0] + " (Limit + (value or off)";
        }
        public bool PublicCommand()
        {
            return false;
        }
    }
}
