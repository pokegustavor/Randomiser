using PulsarPluginLoader.Chat.Commands;
using System.Collections.Generic;
namespace Randomizer
{
    class Command : IChatCommand
    {
        int times = 3;
        int limit = -1;

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
            if (string.IsNullOrEmpty(arguments))
            {
                PLServer.Instance.AddNotification("Subcommands: Limit (value or off), roll", PLNetworkManager.Instance.LocalPlayerID, PLServer.Instance.GetEstimatedServerMs() + 6000, false);
                return false;
            }
            string[] subcommand = new string[2] { "place","holder"};
            subcommand = arguments.Split(' ');
            if (subcommand[0].ToLower() != "roll")
            {

                if (subcommand[0].ToLower() == "limit")
                {
                    int value = 0;

                    if (subcommand.Length > 1 && subcommand[1].ToLower() == "off")
                    {
                        limit = -1;
                        PLServer.Instance.AddNotification("Limit disabled!", PLNetworkManager.Instance.LocalPlayerID, PLServer.Instance.GetEstimatedServerMs() + 4000, false);
                    }
                    else if (subcommand.Length > 1 && int.TryParse(subcommand[1],out value)) 
                    {
                        limit = value;
                        times = 0;
                        PLServer.Instance.AddNotification("New limit: " + value, PLNetworkManager.Instance.LocalPlayerID, PLServer.Instance.GetEstimatedServerMs() + 4000, false);
                    }
                    else
                    {
                        PLServer.Instance.AddNotification("Invalid limit value (Must be 1 or higher) or off", PLNetworkManager.Instance.LocalPlayerID, PLServer.Instance.GetEstimatedServerMs() + 6000, false);
                    }
                }
                else
                {
                    PLServer.Instance.AddNotification("Invalid subcommand", PLNetworkManager.Instance.LocalPlayerID, PLServer.Instance.GetEstimatedServerMs() + 6000, false);
                }
            }
            else if ((times < limit || limit <= -1) && subcommand[0].ToLower() == "roll")
            {
                bool flag = !PhotonNetwork.isMasterClient;
                if (flag)
                {
                    PLServer.Instance.AddNotification("You Must be host to use this command", PLNetworkManager.Instance.LocalPlayerID, PLServer.Instance.GetEstimatedServerMs() + 6000, false);
                    return false;
                }
                Random.random(PLEncounterManager.Instance.PlayerShip,false, true);
                PLServer.Instance.ChaosLevel += 0.5f;
                
                PLServer.Instance.AddNotification("Items Randomised", PLNetworkManager.Instance.LocalPlayerID, PLServer.Instance.GetEstimatedServerMs() + 6000, false);              
                times++;
            }
            else if (times >= limit)
            {
                PLServer.Instance.AddNotification("You can no longer use this command! Set a new limit or set limit to off for no limit", PLNetworkManager.Instance.LocalPlayerID, PLServer.Instance.GetEstimatedServerMs() + 8000, false);
            }
            else
            {
                PLServer.Instance.AddNotification("wrong subcommand", PLNetworkManager.Instance.LocalPlayerID, PLServer.Instance.GetEstimatedServerMs() + 8000, false);
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
