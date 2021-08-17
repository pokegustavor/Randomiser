using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using PulsarPluginLoader.Utilities;


namespace Randomizer
{
    [HarmonyPatch(typeof(PLCarrierInfo), "SetupShipStats")]
    class CarrierPatch
    {
        static void Postfix(PLCarrierInfo __instance, bool previewStats)
        {
            Random.random(__instance, previewStats);
            Logger.Info("local");
        }
    }
    [HarmonyPatch(typeof(PLIntrepidInfo), "SetupShipStats")]
    class IntrepidPatch
    {
        static void Postfix(PLIntrepidInfo __instance, bool previewStats)
        {
            Random.random(__instance, previewStats);
            Logger.Info("local");
        }
    }
    [HarmonyPatch(typeof(PLCivilianStartingShipInfo), "SetupShipStats")]
    class CivilianPatch
    {
        static void Postfix(PLCivilianStartingShipInfo __instance, bool previewStats)
        {
            Random.random(__instance, previewStats);
            Logger.Info("local");
        }
    }
    [HarmonyPatch(typeof(PLCruiserInfo), "SetupShipStats")]
    class CruiserPatch
    {
        static void Postfix(PLCruiserInfo __instance, bool previewStats)
        {
            Random.random(__instance, previewStats);
            Logger.Info("local");
        }
    }
    [HarmonyPatch(typeof(PLFluffyShipInfo), "SetupShipStats")]
    class FluffyPatch
    {
        static void Postfix(PLFluffyShipInfo __instance, bool previewStats)
        {
            Random.random(__instance, previewStats);
            Logger.Info("local");
        }
    }
    [HarmonyPatch(typeof(PLOldWarsShip_Human), "SetupShipStats")]
    class InterceptorPatch
    {
        static void Postfix(PLOldWarsShip_Human __instance, bool previewStats)
        {
            Random.random(__instance, previewStats);
            Logger.Info("local");
        }
    }
    [HarmonyPatch(typeof(PLOutriderInfo), "SetupShipStats")]
    class OutriderPatch
    {
        static void Postfix(PLOutriderInfo __instance, bool previewStats)
        {
            Random.random(__instance, previewStats);
            Logger.Info("local");
        }
    }
    [HarmonyPatch(typeof(PLRolandInfo), "SetupShipStats")]
    class RolandPatch
    {
        static void Postfix(PLRolandInfo __instance, bool previewStats)
        {
            Random.random(__instance, previewStats);
            Logger.Info("local");
        }
    }
    [HarmonyPatch(typeof(PLWDDestroyerInfo), "SetupShipStats")]
    class DestroyerPatch
    {
        static void Postfix(PLWDDestroyerInfo __instance, bool previewStats)
        {
            Random.random(__instance, previewStats);
            Logger.Info("local");
        }
    }
    [HarmonyPatch(typeof(PLWDAnnihilatorInfo), "SetupShipStats")]
    class AnnihilatorPatch
    {
        static void Postfix(PLWDAnnihilatorInfo __instance, bool previewStats)
        {
            Random.random(__instance, previewStats);
            Logger.Info("local");
        }
    }
    [HarmonyPatch(typeof(PLStarGazerInfo), "SetupShipStats")]
    class StarGazerPatch
    {
        static void Postfix(PLStarGazerInfo __instance, bool previewStats)
        {
            Random.random(__instance, previewStats);
            Logger.Info("local");
        }
    }
    [HarmonyPatch(typeof(PLOldWarsShip_Sylvassi), "SetupShipStats")]
    class SwordShipPatch
    {
        static void Postfix(PLOldWarsShip_Sylvassi __instance, bool previewStats)
        {
            Random.random(__instance, previewStats);
            Logger.Info("local");
        }
    }
    [HarmonyPatch(typeof(PLIntrepidCommanderInfo), "SetupShipStats")]
    class GrimCutlassPatch
    {
        static void Postfix(PLIntrepidCommanderInfo __instance, bool previewStats)
        {
            Random.random(__instance, previewStats);
            Logger.Info("local");
        }
    }
    [HarmonyPatch(typeof(PLAlchemistShipInfo), "SetupShipStats")]
    class CausticCorsairPatch
    {
        static void Postfix(PLAlchemistShipInfo __instance, bool previewStats)
        {
            Random.random(__instance, previewStats);
            Logger.Info("local");
        }
    }
    [HarmonyPatch(typeof(PLDeathseekerDrone), "SetupShipStats")]
    class DeathseekerPatch
    {
        static void Postfix(PLDeathseekerDrone __instance, bool previewStats)
        {
            Random.random(__instance, previewStats);
            Logger.Info("local");
        }
    }
    [HarmonyPatch(typeof(PLInfectedFighterInfo), "SetupShipStats")]
    class InfectedDronePatch
    {
        static void Postfix(PLInfectedFighterInfo __instance, bool previewStats)
        {
            Random.random(__instance, previewStats);
            Logger.Info("local");
        }
    }
    [HarmonyPatch(typeof(PLInfectedHeavyFighterInfo), "SetupShipStats")]
    class InfectedfighterPatch
    {
        static void Postfix(PLInfectedHeavyFighterInfo __instance, bool previewStats)
        {
            Random.random(__instance, previewStats);
            Logger.Info("local");
        }
    }
    [HarmonyPatch(typeof(PLSwarmCommanderInfo), "SetupShipStats")]
    class SwarmPatch
    {
        static void Postfix(PLSwarmCommanderInfo __instance, bool previewStats)
        {
            Random.random(__instance, previewStats);
            Logger.Info("local");
        }
    }
    [HarmonyPatch(typeof(PLTriCorpShockDrone), "SetupShipStats")]
    class ShockDronePatch
    {
        static void Postfix(PLTriCorpShockDrone __instance, bool previewStats)
        {
            Random.random(__instance, previewStats);
            Logger.Info("local");
        }
    }
    [HarmonyPatch(typeof(PLWDDroneInfo02), "SetupShipStats")]
    class WDdrone2Patch
    {
        static void Postfix(PLWDDroneInfo02 __instance, bool previewStats)
        {
            Random.random(__instance, previewStats);
            Logger.Info("local");
        }
    }
    [HarmonyPatch(typeof(PLWDDroneInfo03), "SetupShipStats")]
    class WDdrone3Patch
    {
        static void Postfix(PLWDDroneInfo03 __instance, bool previewStats)
        {
            Random.random(__instance, previewStats);
            Logger.Info("local");
        }
    }
    [HarmonyPatch(typeof(PLWDDroneInfo), "SetupShipStats")]
    class WDdronePatch
    {
        static void Postfix(PLWDDroneInfo __instance, bool previewStats)
        {
            Random.random(__instance, previewStats);
            Logger.Info("local");
        }
    }
    [HarmonyPatch(typeof(PLSwarmKeeperShipInfo), "SetupShipStats")]
    class KeeperPatch
    {
        static void Postfix(PLSwarmKeeperShipInfo __instance, bool previewStats)
        {
            Random.random(__instance, previewStats);
            Logger.Info("local");
        }
    }
    [HarmonyPatch(typeof(PLRepairDroneInfo), "SetupShipStats")]
    class RepairDronePatch
    {
        static void Postfix(PLRepairDroneInfo __instance, bool previewStats)
        {
            Random.random(__instance, previewStats);
            Logger.Info("local");
        }
    }
    [HarmonyPatch(typeof(PLInfectedCarrier), "SetupShipStats")]
    class InfectedCarrierPatch
    {
        static void Postfix(PLInfectedCarrier __instance, bool previewStats)
        {
            Random.random(__instance, previewStats);
            Logger.Info("local");
        }
    }
    [HarmonyPatch(typeof(PLFighterDroneInfo), "SetupShipStats")]
    class FighterDronePatch
    {
        static void Postfix(PLFighterDroneInfo __instance, bool previewStats)
        {
            Random.random(__instance, previewStats);
            Logger.Info("local");
        }
    }
    [HarmonyPatch(typeof(PLDeathseekerCommanderDrone), "SetupShipStats")]
    class DeathWardenPatch
    {
        static void Postfix(PLDeathseekerCommanderDrone __instance, bool previewStats)
        {
            Random.random(__instance, previewStats);
            Logger.Info("local");
        }
    }
    [HarmonyPatch(typeof(PLCorruptedDroneShipInfo), "SetupShipStats")]
    class AncientPatch
    {
        static void Postfix(PLCorruptedDroneShipInfo __instance, bool previewStats)
        {
            Random.random(__instance, previewStats);
            Logger.Info("local");
        }
    }
    [HarmonyPatch(typeof(PLCivilianFuelShipInfo), "SetupShipStats")]
    class FuelPatch
    {
        static void Postfix(PLCivilianFuelShipInfo __instance, bool previewStats)
        {
            Random.random(__instance, previewStats);
            Logger.Info("local");
        }
    }
    [HarmonyPatch(typeof(PLBountyHunterShipInfo), "SetupShipStats")]
    class BountyPatch
    {
        static void Postfix(PLBountyHunterShipInfo __instance, bool previewStats)
        {
            Random.random(__instance, previewStats);
            Logger.Info("local");
        }
    }
    [HarmonyPatch(typeof(PLAcademyShipInfo), "SetupShipStats")]
    class AcademyPatch
    {
        static void Postfix(PLAcademyShipInfo __instance, bool previewStats)
        {
            Random.random(__instance, previewStats);
            Logger.Info("local");
        }
    }
    [HarmonyPatch(typeof(PLWarpGuardian), "SetupShipStats")]
    class GuardianPatch
    {
        static void Postfix(PLWarpGuardian __instance, bool previewStats)
        {
            Random.random(__instance, previewStats);
            Logger.Info("local");           
        }
    }
    [HarmonyPatch(typeof(PLPolytechShipInfo), "SetupShipStats")]
    class PolytechPatch
    {
        static void Postfix(PLPolytechShipInfo __instance, bool previewStats)
        {
            Random.random(__instance, previewStats);
            Logger.Info("local");
        }
    }
    [HarmonyPatch(typeof(PLPTDrone), "SetupShipStats")]
    class PTDronePatch
    {
        static void Postfix(PLPTDrone __instance, bool previewStats)
        {
            Random.random(__instance, previewStats);
            Logger.Info("local");
        }
    }
    [HarmonyPatch(typeof(PLUnseenFighterShipInfo), "SetupShipStats")]
    class UnseenFighterPatch
    {
        static void Postfix(PLUnseenFighterShipInfo __instance, bool previewStats)
        {
            Random.random(__instance, previewStats);
            Logger.Info("local");
        }
    }
    [HarmonyPatch(typeof(PLFluffyShipInfo2), "SetupShipStats")]
    class FluffyTwoPatch 
    {
        static void Postfix(PLFluffyShipInfo2 __instance, bool previewStats)
        {
            Random.random(__instance, previewStats);
            Logger.Info("local");
        }
    }
    [HarmonyPatch(typeof(PLPersistantShipInfo), MethodType.Constructor, new Type[] { typeof(EShipType), typeof(int),typeof(PLSectorInfo),typeof(int),typeof(bool),typeof(bool),typeof(bool),typeof(int),typeof(int) })]
    class RandomShips 
    { 
        static void Postfix(PLPersistantShipInfo __instance) 
        {
            if (Configs.randomship) 
            {
                Random.randomship(__instance);
                Logger.Info("local");
            }
        }
    }

    [HarmonyPatch(typeof(PLServerClassInfo),"Update")]
    class RandomItems
    {
        static void Prefix(bool ___CreatedStartingItems, out bool __state) 
        {
            __state = ___CreatedStartingItems;
        }

        static void Postfix(bool __state, PLServerClassInfo __instance) 
        { 
            if(!__state && PhotonNetwork.isMasterClient && PLServer.Instance != null && PLEncounterManager.Instance.PlayerShip != null) 
            {
                int place = 0;
                PLPawnInventoryBase classLockerInventory = __instance.ClassLockerInventory;
                PLServer instance = PLServer.Instance;
                int pawnInvItemIDCounter = instance.PawnInvItemIDCounter;
                classLockerInventory.Clear();
                while(place < 4) 
                {
                    pawnInvItemIDCounter++;
                    classLockerInventory.UpdateItem(pawnInvItemIDCounter, Randomic.Item(pawnInvItemIDCounter), 0, Configs.level? Randomic.ItemLevel(pawnInvItemIDCounter) :0, -1);
                    place++;
                }
            }
        }
    }
    [HarmonyPatch(typeof(PLShipInfo), "CreateDefaultItemsForEnemyBotPlayer")]
    class RandomItemsEnemys 
    { 
        static void Postfix(PLPlayer inPlayer) 
        {
            if (PhotonNetwork.isMasterClient)
            {
                int place = 0;
                PLPawnInventoryBase myInventory = inPlayer.MyInventory;
                PLServer instance = PLServer.Instance;
                int pawnInvItemIDCounter = instance.PawnInvItemIDCounter;
                myInventory.Clear();
                while (place < 4)
                {
                    pawnInvItemIDCounter++;
                    myInventory.UpdateItem(pawnInvItemIDCounter, Randomic.Item(pawnInvItemIDCounter), 0, Configs.level ? Randomic.ItemLevel(pawnInvItemIDCounter) : 0, -1);
                    place++;
                }
            }
        }
    }
    [HarmonyPatch(typeof(PLAlchemistShipInfo), "CreateDefaultItemsForEnemyBotPlayer")]
    class RandomItemsEnemysAlchemy
    {
        static void Postfix(PLPlayer inPlayer)
        {
            if (PhotonNetwork.isMasterClient)
            {
                int place = 0;
                PLPawnInventoryBase myInventory = inPlayer.MyInventory;
                PLServer instance = PLServer.Instance;
                int pawnInvItemIDCounter = instance.PawnInvItemIDCounter;
                myInventory.Clear();
                while (place < 4)
                {
                    pawnInvItemIDCounter++;
                    myInventory.UpdateItem(pawnInvItemIDCounter, Randomic.Item(pawnInvItemIDCounter), 0, Configs.level ? Randomic.ItemLevel(pawnInvItemIDCounter) : 0, -1);
                    place++;
                }
            }
        }
    }
    [HarmonyPatch(typeof(PLIntrepidCommanderInfo), "CreateDefaultItemsForEnemyBotPlayer")]
    class RandomItemsEnemysGrim
    {
        static void Postfix(PLPlayer inPlayer)
        {
            if (PhotonNetwork.isMasterClient)
            {
                int place = 0;
                PLPawnInventoryBase myInventory = inPlayer.MyInventory;
                PLServer instance = PLServer.Instance;
                int pawnInvItemIDCounter = instance.PawnInvItemIDCounter;
                myInventory.Clear();
                while (place < 4)
                {
                    pawnInvItemIDCounter++;
                    myInventory.UpdateItem(pawnInvItemIDCounter, Randomic.Item(pawnInvItemIDCounter), 0, Configs.level ? Randomic.ItemLevel(pawnInvItemIDCounter) : 0, -1);
                    place++;
                }
            }
        }
    }
    [HarmonyPatch(typeof(PLServer), "NetworkBeginWarp")]
    class Jump 
    { 
        static void Postfix() 
        { 
            if(Configs.jumpmax > 0 && PhotonNetwork.isMasterClient) 
            {
                Configs.currentjump++;
                if(Configs.currentjump >= Configs.jumpmax) 
                {
                    Random.random(PLEncounterManager.Instance.PlayerShip, false);
                    Configs.currentjump = 0;
                    Messaging.Notification("Loadout randomized ", PhotonTargets.All, 0, 4000, false);
                }
                else 
                {
                    Messaging.Notification("Jumps until next randomization: " + (Configs.jumpmax - Configs.currentjump), PhotonTargets.All, 0, 4000, false);
                }
            }    
        }
    }
    [HarmonyPatch(typeof(PLServer), "AttemptBlindJump")]
    class Blindjump
    {
        static void Postfix()
        {
            if (Configs.jumpmax > 0 && PhotonNetwork.isMasterClient)
            {
                Configs.currentjump++;
                if (Configs.currentjump >= Configs.jumpmax)
                {
                    Random.random(PLEncounterManager.Instance.PlayerShip, false);
                    Configs.currentjump = 0;
                    Messaging.Notification("Loadout randomized ", PhotonTargets.All, 0, 4000, false);
                }
                else
                {
                    Messaging.Notification("Jumps until next randomization: " + (Configs.jumpmax - Configs.currentjump), PhotonTargets.All, 0, 4000, false);
                }
            }
        }
    }
}
