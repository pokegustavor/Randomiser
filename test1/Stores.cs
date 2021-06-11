using HarmonyLib;
using UnityEngine;

namespace Randomizer
{
    [HarmonyPatch(typeof(PLShipComponent), "CreateRandom")]
    class Stores
    {
        static PLShipComponent Postfix(PLShipComponent __result)
        {
			int num = UnityEngine.Random.Range(0, 5000000) % 25;
			PLShipComponent plshipComponent = null;
			float inRarity = 4f;
			int seed = UnityEngine.Random.Range(0, 50000000);
			PLRand plrand = new PLRand(seed);
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
					plshipComponent = PLHullPlating.CreateRandom(inRarity, UnityEngine.Random.Range(0, 50000000));
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
					plshipComponent = PLAutoTurret.CreateRandom(inRarity, UnityEngine.Random.Range(0, 50000000));
					break;
				case 22:
					plshipComponent = PLCaptainsChair.CreateRandom(inRarity, UnityEngine.Random.Range(0, 50000000));
					break;
				case 23:
					plshipComponent = new PLExtractor((EExtractorType)Randomic.Extractor(seed), 0, 0);
					break;
				case 24:
					plshipComponent = new PLNuclearDevice((ENuclearDeviceType)Randomic.Nuclear(seed), 0);
					break;
			}
			plshipComponent.Level += Mathf.RoundToInt((PLServer.Instance != null) ? (PLServer.Instance.ChaosLevel * 0.2f) : 0f);
            if (Command.level)
			{
				plshipComponent.Level = Randomic.Level(plrand.Next(), plshipComponent.ActualSlotType);
			}
			__result = plshipComponent;
			return __result;
		}
		
		
	}
}
