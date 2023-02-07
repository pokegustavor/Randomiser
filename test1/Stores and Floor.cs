using HarmonyLib;
using System.Reflection.Emit;
using UnityEngine;

namespace Randomizer
{
    [HarmonyPatch(typeof(PLShipComponent), "CreateRandom")]
    class Stores
    {
        static PLShipComponent Postfix(PLShipComponent __result)
        {
            int seed = PLServer.GetCurrentSector().ID * PLEncounterManager.Instance.PlayerShip.ShipID + PLServer.Instance.GetLowestAvailablePlayerID();
            PLRand plrand = new PLRand(seed);
            int num = plrand.Next() % 25;
			PLShipComponent plshipComponent = null;
			float inRarity = 4f;
			switch (num)
			{
				case 0:
				case 1:
				case 2:
					plshipComponent = new PLReactor((EReactorType)Randomic.Reactor(seed), Mathf.RoundToInt(Mathf.Pow((float)plrand.NextDouble(), inRarity) * 4.21f));
					break;
				case 3:
				case 4:
					plshipComponent = new PLShieldGenerator((EShieldGeneratorType)Randomic.Shield(seed), Mathf.RoundToInt(Mathf.Pow((float)plrand.NextDouble(), inRarity) * 4.7f));
					break;
				case 5:
				case 6:
					plshipComponent = new PLWarpDrive((EWarpDriveType)Randomic.Jump(seed), Mathf.RoundToInt(Mathf.Pow((float)plrand.NextDouble(), inRarity) * 2.7f), 0);
					break;
				case 7:
				case 8:
					plshipComponent = new PLHull((EHullType)Randomic.Hull(seed), Mathf.RoundToInt(Mathf.Pow((float)plrand.NextDouble(), inRarity) * 3.7f));
					break;
				case 9:
				case 10:
					plshipComponent = new PLCPU((ECPUClass)Randomic.Processor(seed),0);
					break;
				case 11:
				case 12:
					plshipComponent = new PLWarpDriveProgram((EWarpDriveProgramType)Randomic.Program(seed));
					break;
				case 13:
					plshipComponent = PLHullPlating.CreateHullPlatingFromHash(Randomic.HullPlating(seed), Mathf.RoundToInt(Mathf.Pow((float)plrand.NextDouble(), inRarity) * 4.51f), 0);
                    break;
				case 14:
				case 15:
					plshipComponent = new PLThruster((EThrusterType)Randomic.Thruster(seed), Mathf.RoundToInt(Mathf.Pow((float)plrand.NextDouble(), inRarity) * 4.7f));
					break;
				case 16:
				case 17:
					plshipComponent = PLShipComponent.CreateShipComponentFromHash((int)PLShipComponent.createHashFromInfo(10, Randomic.Turret(seed), Mathf.RoundToInt(Mathf.Pow((float)plrand.NextDouble(), inRarity) * 4.51f), 0, 12), null);
					break;
				case 18:
					plshipComponent = new PLTrackerMissile((ETrackerMissileType)Randomic.Missile(seed),0);
					break;
				case 19:
					plshipComponent = new PLInertiaThruster((EInertiaThrusterType)Randomic.Inertia(seed), Mathf.RoundToInt(Mathf.Pow((float)plrand.NextDouble(), inRarity) * 2.7f));
					break;
				case 20:
					plshipComponent = new PLManeuverThruster((EManeuverThrusterType)Randomic.Maneuver(seed), Mathf.RoundToInt(Mathf.Pow((float)plrand.NextDouble(), inRarity) * 2.7f));
					break;
				case 21:
					plshipComponent = PLAutoTurret.CreateAutoTurretFromHash(Randomic.AutoTurret(seed), Mathf.RoundToInt(Mathf.Pow((float)plrand.NextDouble(), inRarity) * 4.51f), 0);
                    break;
				case 22:
					plshipComponent = PLCaptainsChair.CreateCaptainsChairFromHash(Randomic.Chair(seed), Mathf.RoundToInt(Mathf.Pow((float)plrand.NextDouble(), inRarity) * 4.51f), 0);
                    break;
				case 23:
					plshipComponent = new PLExtractor((EExtractorType)Randomic.Extractor(seed), 0, 0);
					break;
				case 24:
					plshipComponent = new PLNuclearDevice((ENuclearDeviceType)Randomic.Nuclear(seed), 0);
					break;
			}
			plshipComponent.Level += Mathf.RoundToInt((PLServer.Instance != null) ? (PLServer.Instance.ChaosLevel * 0.2f) : 0f);
            if (Configs.level)
			{
				plshipComponent.Level = Randomic.Level(plrand.Next(), plshipComponent.ActualSlotType);
			}
			__result = plshipComponent;
			return __result;
		}		
	}
	[HarmonyPatch(typeof(PLPawnItem),"CreateRandom")]
	class Item_store 
	{ 
	  static PLWare Postfix(PLWare __result) 
		{
            int seed = PLServer.GetCurrentSector().ID * PLEncounterManager.Instance.PlayerShip.ShipID + PLServer.Instance.GetLowestAvailablePlayerID();
            PLRand plrand = new PLRand(seed);
            int num = plrand.Next() % 31;
			float inRarity = 7f - Mathf.Clamp(PLServer.Instance.ChaosLevel, 0f, 6f);
			PLWare plware;
			switch (num)
			{
				case 0:
					plware = new PLPawnItem_BurstPistol();
					break;
				case 1:
					plware = new PLPawnItem_FireGun();
					break;
				case 2:
					plware = new PLPawnItem_PhasePistol();
					break;
				case 3:
					plware = new PLPawnItem_Ranger();
					break;
				case 4:
					plware = new PLPawnItem_RepairGun();
					break;
				case 5:
					plware = new PLPawnItem_PierceLaserPistol();
					break;
				case 6:
					plware = new PLPawnItem_SmugglersPistol();
					break;
				case 7:
					plware = new PLPawnItem_Scanner();
					break;
				case 8:
					plware = new PLPawnItem_HandShotgun();
					break;
				case 9:					
				case 10:
				case 11:
					plware = new PLPawnItem_AmmoClip();
					break;
				case 12:
					plware = new PLPawnItem_AntiFireGrenade();
					break;
				case 13:
					plware = new PLPawnItem_FBSellTool();
					break;
				case 14:
					plware = new PLPawnItem_Syringe(ESyringeType.HEAL_HEALTH_BONUS);
					break;
				case 15:
					plware = new PLPawnItem_HealGrenade();
					break;
				case 16:
					plware = new PLPawnItem_HeavyPistol();
					break;
				case 17:
					plware = new PLPawnItem_RepairGrenade();
					break;
				case 18:
					plware = new PLPawnItem_HeldBeamPistol();
					break;
				case 19:
					plware = new PLPawnItem_IceSpikes(0);
					break;
				case 20:
					plware = new PLPawnItem_WDHeavy();
					break;
				case 21:
					plware = new PLPawnItem_StunGrenade();
					break;
				case 22:
					plware = new PLPawnItem_PulseGrenade();
					break;
				case 23:
					plware = new PLPawnItem_MiniGrenade();
					break;
				case 24:
					plware = new PLPawnItem_VortexGrenade();
					break;
				default:
					plware = PLPawnItem_Food.CreateRandom(inRarity, UnityEngine.Random.Range(0, 50000));
					break;
			}
			PLPawnItem plpawnItem = plware as PLPawnItem;
			if (plpawnItem != null)
			{
				plpawnItem.Level = Mathf.RoundToInt(Mathf.Pow((float)plrand.NextDouble(), inRarity) * 3f);
				plpawnItem.Level += Mathf.RoundToInt((PLServer.Instance != null) ? (PLServer.Instance.ChaosLevel * 0.2f) : 0f);
                if (Configs.level) 
				{
					plpawnItem.Level = Randomic.ItemLevel(plrand.Next());
				}
			}
			__result = plpawnItem;
			return __result;
		}
	}
	[HarmonyPatch(typeof(PLPickupRandomComponent), "SetupRandComp")]
	class FloorItems 
	{ 
		static void Postfix(PLPickupRandomComponent __instance) 
		{
            if (__instance.RandCompSetup) 
			{
				__instance.RandComp = (int)Randomic.Comp(__instance.GetHashCode(), Configs.level? Randomic.Level(__instance.GetHashCode()): UnityEngine.Random.Range(0, 2)).getHash();
			}
		}
	}
}
