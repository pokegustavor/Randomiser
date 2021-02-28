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
                "roll",
                "random",
                "randomizer"
            };
        }
        public bool Execute(string arguments, int SenderID)
        {
            if (!string.IsNullOrEmpty(arguments))
            {
                string[] subcommand = new string[2];
                subcommand = arguments.Split(' ');
                string command1 = subcommand[0].ToLower();
                string command2 = subcommand[1];
                int command3 = 0;
                int.TryParse(subcommand[2], out command3);

                if (command1 == "limit")
                {
                    if (command2 == "off")
                    {
                        limit = -1;
                        PLServer.Instance.AddNotification("Limit disabled!", PLNetworkManager.Instance.LocalPlayerID, PLServer.Instance.GetEstimatedServerMs() + 4000, false);
                    }
                    else if (command3 >= 1)
                    {
                        limit = command3;
                        times = 0;
                        PLServer.Instance.AddNotification("New limit: " + command3, PLNetworkManager.Instance.LocalPlayerID, PLServer.Instance.GetEstimatedServerMs() + 4000, false);
                    }
                    else
                    {
                        PLServer.Instance.AddNotification("Invalid limit value (Must be 1 or higher)", PLNetworkManager.Instance.LocalPlayerID, PLServer.Instance.GetEstimatedServerMs() + 6000, false);
                    }
                }
                else
                {
                    PLServer.Instance.AddNotification("Invalid command", PLNetworkManager.Instance.LocalPlayerID, PLServer.Instance.GetEstimatedServerMs() + 6000, false);
                }
            }
            if (times < limit || limit <= -1)
            {
                bool flag = !PhotonNetwork.isMasterClient;
                if (flag)
                {
                    PLServer.Instance.AddNotification("You Must be host to use this command", PLNetworkManager.Instance.LocalPlayerID, PLServer.Instance.GetEstimatedServerMs() + 6000, false);
                    return false;
                }
                Random.random(PLEncounterManager.Instance.PlayerShip,false, true);
                

                PLServer.Instance.AddNotification("Items Randomised", PLNetworkManager.Instance.LocalPlayerID, PLServer.Instance.GetEstimatedServerMs() + 6000, false);
                times++;
            }
            else
            {
                PLServer.Instance.AddNotification("You can no longer use this command! Set a new limit or set limit to off for no limit", PLNetworkManager.Instance.LocalPlayerID, PLServer.Instance.GetEstimatedServerMs() + 8000, false);
            }
            return false;
        }
        public string Description()
        {
            if (limit <= -1)
            {
                return "Randomises your ship loadout";
            }
            if (limit - times == 1)
            {
                return $"Randomises your ship loadout, can only be used {1} more time!";
            }
            else if (times == limit)
            {
                return $"Randomises your ship loadout, but it can no longer be used (reset the limit or remove it)";
            }
            return $"Randomises your ship loadout, can only be used {limit - times} more times";
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
