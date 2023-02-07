using System;
using PulsarModLoader.Content.Components;
using PulsarModLoader.Content.Components.Hull;
using PulsarModLoader.Content.Components.InertiaThruster;
using PulsarModLoader.Content.Components.ManeuverThruster;
using PulsarModLoader.Content.Components.MegaTurret;
using PulsarModLoader.Content.Components.Reactor;
using PulsarModLoader.Content.Components.Shield;
using PulsarModLoader.Content.Components.Thruster;

namespace Randomizer
{
    class Randomic
    {
        public static int RandomSeed()
        {
            System.Random random = new System.Random(PLServer.GetCurrentSector().ID * PLEncounterManager.Instance.PlayerShip.ShipID);
            int value = random.Next(540, 2584);
            return value;
        }
        public static int Hull(int seed = 1)
        {
            bool exotic = PulsarModLoader.ModManager.Instance.GetMod("Exotic Components") != null;
            System.Random random = new System.Random(RandomSeed() * seed);
            int value = random.Next(0, Enum.GetNames(typeof(EHullType)).Length + HullModManager.Instance.HullTypes.Count);
            while (value == 4 || value == 15 || (exotic && value == HullModManager.Instance.GetHullIDFromName("Flagship Hull")))
            {
                value = random.Next(0, Enum.GetNames(typeof(EHullType)).Length + HullModManager.Instance.HullTypes.Count);
            }
            while (!Configs.bossitem && (value == 5 || value == 6 || value == 8 || value == 10 || value == 11 || value == 12 || value == 13 || value == 18))
            {
                value = random.Next(0, Enum.GetNames(typeof(EHullType)).Length + HullModManager.Instance.HullTypes.Count);
            }
            return value;
        }
        public static int Shield(int seed = 1)
        {
            bool exotic = PulsarModLoader.ModManager.Instance.GetMod("Exotic Components") != null;
            System.Random random = new System.Random(RandomSeed() * seed);
            int value = random.Next(0, Enum.GetNames(typeof(EShieldGeneratorType)).Length + PulsarModLoader.Content.Components.Shield.ShieldModManager.Instance.ShieldTypes.Count);
            while (value == 10 || (exotic && value == ShieldModManager.Instance.GetShieldIDFromName("Flagship Shield")))
            {
                value = random.Next(0, Enum.GetNames(typeof(EShieldGeneratorType)).Length + PulsarModLoader.Content.Components.Shield.ShieldModManager.Instance.ShieldTypes.Count);
            }
            return value;
        }
        public static int Reactor(int seed = 1)
        {
            bool exotic = PulsarModLoader.ModManager.Instance.GetMod("Exotic Components") != null;
            System.Random random = new System.Random(RandomSeed() * seed);
            int value = random.Next(0, Enum.GetNames(typeof(EReactorType)).Length + PulsarModLoader.Content.Components.Reactor.ReactorModManager.Instance.ReactorTypes.Count);
            while (value == 7 || (exotic && value == ReactorModManager.Instance.GetReactorIDFromName("Flagship Reactor")))
            {
                value = random.Next(0, Enum.GetNames(typeof(EReactorType)).Length + PulsarModLoader.Content.Components.Reactor.ReactorModManager.Instance.ReactorTypes.Count);
            }
            if (!Configs.bossitem && (value == 9 || value == 15))
            {
                value += 1;
            }
            return value;
        }
        public static int Jump(int seed = 1)
        {
            System.Random random = new System.Random(RandomSeed() * seed);
            int value = random.Next(0, Enum.GetNames(typeof(EWarpDriveType)).Length + PulsarModLoader.Content.Components.WarpDrive.WarpDriveModManager.Instance.WarpDriveTypes.Count);
            while (value == 4 || value == 16)
            {
                value = random.Next(0, Enum.GetNames(typeof(EWarpDriveType)).Length + PulsarModLoader.Content.Components.WarpDrive.WarpDriveModManager.Instance.WarpDriveTypes.Count);
            }
            return value;
        }
        public static int Thruster(int seed = 1)
        {
            bool exotic = PulsarModLoader.ModManager.Instance.GetMod("Exotic Components") != null;
            System.Random random = new System.Random(RandomSeed() * seed);
            int value = random.Next(0, Enum.GetNames(typeof(EThrusterType)).Length + PulsarModLoader.Content.Components.Thruster.ThrusterModManager.Instance.ThrusterTypes.Count);
            while (exotic && value == ThrusterModManager.Instance.GetThrusterIDFromName("Flagship Thruster"))
            {
                value = random.Next(0, Enum.GetNames(typeof(EThrusterType)).Length + PulsarModLoader.Content.Components.Thruster.ThrusterModManager.Instance.ThrusterTypes.Count);
            }
            return value;
        }
        public static int Inertia(int seed = 1)
        {
            bool exotic = PulsarModLoader.ModManager.Instance.GetMod("Exotic Components") != null;
            System.Random random = new System.Random(RandomSeed() * seed);
            int value = random.Next(0, Enum.GetNames(typeof(EInertiaThrusterType)).Length + PulsarModLoader.Content.Components.InertiaThruster.InertiaThrusterModManager.Instance.InertiaThrusterTypes.Count);
            while (value == 1 || (exotic && value == InertiaThrusterModManager.Instance.GetInertiaThrusterIDFromName("Flagship Inertia Thruster")))
            {
                value = random.Next(0, Enum.GetNames(typeof(EInertiaThrusterType)).Length + PulsarModLoader.Content.Components.InertiaThruster.InertiaThrusterModManager.Instance.InertiaThrusterTypes.Count);
            }
            while (!Configs.bossitem && (value == 2 || value == 3))
            {
                value = random.Next(0, Enum.GetNames(typeof(EInertiaThrusterType)).Length + PulsarModLoader.Content.Components.InertiaThruster.InertiaThrusterModManager.Instance.InertiaThrusterTypes.Count);
            }
            return value;
        }
        public static int Maneuver(int seed = 1)
        {
            bool exotic = PulsarModLoader.ModManager.Instance.GetMod("Exotic Components") != null;
            System.Random random = new System.Random(RandomSeed() * seed);
            int value = random.Next(0, Enum.GetNames(typeof(EManeuverThrusterType)).Length + PulsarModLoader.Content.Components.ManeuverThruster.ManeuverThrusterModManager.Instance.ManeuverThrusterTypes.Count);
            while (exotic && value == ManeuverThrusterModManager.Instance.GetManeuverThrusterIDFromName("Flagship Maneuvering Thruster"))
            {
                value = random.Next(0, Enum.GetNames(typeof(EManeuverThrusterType)).Length + PulsarModLoader.Content.Components.ManeuverThruster.ManeuverThrusterModManager.Instance.ManeuverThrusterTypes.Count);
            }
            return value;
        }
        public static int Chair(int seed = 1)
        {
            System.Random random = new System.Random(RandomSeed() * seed);
            int value = random.Next(0, Enum.GetNames(typeof(ECaptainsChairType)).Length + PulsarModLoader.Content.Components.CaptainsChair.CaptainsChairModManager.Instance.CaptainsChairTypes.Count);
            return value;
        }
        public static int Extractor(int seed = 1)
        {
            System.Random random = new System.Random(RandomSeed() * seed);
            int value = random.Next(0, Enum.GetNames(typeof(EExtractorType)).Length + PulsarModLoader.Content.Components.Extractor.ExtractorModManager.Instance.ExtractorTypes.Count);
            while (value == 2)
            {
                value = random.Next(0, Enum.GetNames(typeof(EExtractorType)).Length + PulsarModLoader.Content.Components.Extractor.ExtractorModManager.Instance.ExtractorTypes.Count);
            }
            return value;
        }
        public static int Turret(int seed = 1)
        {
            System.Random random = new System.Random(RandomSeed() * seed);
            int value = random.Next(0, Enum.GetNames(typeof(ETurretType)).Length + PulsarModLoader.Content.Components.Turret.TurretModManager.Instance.TurretTypes.Count);
            while (value == 5)
            {
                value = random.Next(0, Enum.GetNames(typeof(ETurretType)).Length + PulsarModLoader.Content.Components.Turret.TurretModManager.Instance.TurretTypes.Count);
            }
            while (!Configs.bossitem && (value == 7 || value == 8 || value == 18))
            {
                value = random.Next(0, Enum.GetNames(typeof(ETurretType)).Length + PulsarModLoader.Content.Components.Turret.TurretModManager.Instance.TurretTypes.Count);
            }
            return value;
        }
        public static int MainTurret(int seed = 1)
        {
            bool exotic = PulsarModLoader.ModManager.Instance.GetMod("Exotic Components") != null;
            System.Random random = new System.Random(RandomSeed() * seed);
            int value = random.Next(0, PulsarModLoader.Content.Components.MegaTurret.MegaTurretModManager.Instance.VanillaMegaTurretMaxType + PulsarModLoader.Content.Components.MegaTurret.MegaTurretModManager.Instance.MegaTurretTypes.Count);
            while(value == 7 || (exotic && value == MegaTurretModManager.Instance.GetMegaTurretIDFromName("FlagShipMainTurret"))) 
            {
                value = random.Next(0, PulsarModLoader.Content.Components.MegaTurret.MegaTurretModManager.Instance.VanillaMegaTurretMaxType + PulsarModLoader.Content.Components.MegaTurret.MegaTurretModManager.Instance.MegaTurretTypes.Count);
            }
            return value;
        }
        public static int Cloak(int seed = 1)
        {
            System.Random random = new System.Random(RandomSeed() * seed);
            int value = random.Next(0, 1);
            return value;
        }

        public static int Missile(int seed = 1)
        {
            System.Random random = new System.Random(RandomSeed() * seed);
            int value = random.Next(0, Enum.GetNames(typeof(ETrackerMissileType)).Length + PulsarModLoader.Content.Components.Missile.MissileModManager.Instance.MissileTypes.Count);
            while (value == 3 || value == 11)
            {
                value = random.Next(0, Enum.GetNames(typeof(ETrackerMissileType)).Length + PulsarModLoader.Content.Components.Missile.MissileModManager.Instance.MissileTypes.Count);
            }
            while (!Configs.bossitem && (value == 5))
            {
                value = random.Next(0, Enum.GetNames(typeof(ETrackerMissileType)).Length + PulsarModLoader.Content.Components.Missile.MissileModManager.Instance.MissileTypes.Count);
            }
            return value;
        }
        public static int O2(int seed = 1)
        {
            System.Random random = new System.Random(RandomSeed() * seed);
            int value = random.Next(0, 1);
            return value;
        }
        public static int Processor(int seed = 1)
        {
            System.Random random = new System.Random(RandomSeed() * seed);
            int value = random.Next(1, Enum.GetNames(typeof(ECPUClass)).Length + PulsarModLoader.Content.Components.CPU.CPUModManager.Instance.CPUTypes.Count);
            return value;
        }
        public static int Program(int seed = 1)
        {
            System.Random random = new System.Random(RandomSeed() * seed);
            int value = random.Next(0, Enum.GetNames(typeof(EWarpDriveProgramType)).Length + PulsarModLoader.Content.Components.WarpDriveProgram.WarpDriveProgramModManager.Instance.WarpDriveProgramTypes.Count);
            while (value == 8)
            {
                value = random.Next(0, Enum.GetNames(typeof(EWarpDriveProgramType)).Length + PulsarModLoader.Content.Components.WarpDriveProgram.WarpDriveProgramModManager.Instance.WarpDriveProgramTypes.Count);
            }
            return value;
        }
        public static int Nuclear(int seed = 1)
        {
            System.Random random = new System.Random(RandomSeed() * seed);
            int value = random.Next(0, Enum.GetNames(typeof(ENuclearDeviceType)).Length + PulsarModLoader.Content.Components.NuclearDevice.NuclearDeviceModManager.Instance.NuclearDeviceTypes.Count);
            while (value == 3)
            {
                value = random.Next(0, Enum.GetNames(typeof(ENuclearDeviceType)).Length + PulsarModLoader.Content.Components.NuclearDevice.NuclearDeviceModManager.Instance.NuclearDeviceTypes.Count);
            }
            return value;
        }
        public static int Polytech(int seed = 1)
        {
            System.Random random = new System.Random(RandomSeed() * seed);
            int value = random.Next(0, Enum.GetNames(typeof(EPolytechModuleType)).Length + PulsarModLoader.Content.Components.PolytechModule.PolytechModuleModManager.Instance.PolytechModuleTypes.Count);
            return value;
        }
        public static int SOS(int seed = 1)
        {
            System.Random random = new System.Random(RandomSeed() * seed);
            int value = random.Next(0, 2);
            return value;
        }
        public static int Mission(int seed = 1)
        {
            System.Random random = new System.Random(RandomSeed() * seed);
            int value = random.Next(0, PulsarModLoader.Content.Components.MissionShipComponent.MissionShipComponentModManager.Instance.VanillaMissionShipComponentMaxType + PulsarModLoader.Content.Components.MissionShipComponent.MissionShipComponentModManager.Instance.MissionShipComponentTypes.Count);
            return value;
        }
        public static int Recipe(int seed = 1)
        {
            System.Random random = new System.Random(RandomSeed() * seed);
            int value = random.Next(0, PulsarModLoader.Content.Components.FBRecipeModule.FBRecipeModuleModManager.Instance.VanillaFBRecipeModuleMaxType + PulsarModLoader.Content.Components.FBRecipeModule.FBRecipeModuleModManager.Instance.FBRecipeModuleTypes.Count);
            return value;
        }

        public static int AutoTurret(int seed = 1) 
        {
            System.Random random = new System.Random(RandomSeed() * seed);
            int value = random.Next(0, Enum.GetNames(typeof(EAutoTurretType)).Length + PulsarModLoader.Content.Components.AutoTurret.AutoTurretModManager.Instance.AutoTurretTypes.Count);
            return value;
        }

        public static int HullPlating(int seed = 1)
        {
            System.Random random = new System.Random(RandomSeed() * seed);
            int value = random.Next(0, Enum.GetNames(typeof(EHullPlatingType)).Length + PulsarModLoader.Content.Components.HullPlating.HullPlatingModManager.Instance.HullPlatingTypes.Count);
            return value;
        }

        public static int Level(int seed = 1, ESlotType type = ESlotType.E_COMP_ID_MAX)
        {
            System.Random random = new System.Random(RandomSeed() * seed);
            int value = type == ESlotType.E_COMP_WARP ? random.Next(0, 9) : random.Next(0, 31);
            return value;
        }

        public static int ItemLevel(int seed = 1)
        {
            System.Random random = new System.Random(RandomSeed() * seed);
            int value = random.Next(0, 15);
            return value;
        }

        public static EShipType Type(int seed = 1)
        {
            System.Random random = new System.Random(RandomSeed() * seed);
            int value = random.Next(0, 63);
            while (value == 7 || value == 8 || value == 25 || value == 35 || (value >= 37 && value <= 43) || value == 48 || value == 49 || value == 59)
            {
                value = random.Next(0, 63);
            }
            return (EShipType)value;
        }
        public static int Item(int seed = 1)
        {
            System.Random random = new System.Random(RandomSeed() * seed);
            int value = random.Next(0, 33);
            while (value == 32 || value == 31 || value == 18 || value == 17 || value == 15 || value == 14 || value == 13 || value == 6 || value == 5 || value == 1 || value == 0)
            {
                value = random.Next(0, 33);
            }
            return value;
        }
        public static PLShipComponent Comp(int seed = 1, int level = 0)
        {
            System.Random random = new System.Random(RandomSeed() * seed);
            int type = random.Next(1, 34);
            PLShipComponent component;
            while (type == 4 || (type >= 12 && type <= 15) || type == 18 || type == 29)
            {
                type = random.Next(1, 34);
            }
            switch (type)
            {
                default:
                case 1:
                    component = new PLShieldGenerator((EShieldGeneratorType)Shield(seed), level);
                    break;
                case 2:
                    component = new PLWarpDrive((EWarpDriveType)Jump(seed), level);
                    break;
                case 3:
                    component = new PLReactor((EReactorType)Reactor(seed), level);
                    break;
                case 5:
                    component = new PLSensor();
                    break;
                case 6:
                    component = new PLHull((EHullType)Hull(seed), level);
                    break;
                case 7:
                    component = new PLCPU((ECPUClass)Processor(seed), level);
                    break;
                case 8:
                    component = new PLOxygenGenerator((EO2GeneratorType)O2(seed), level);
                    break;
                case 9:
                    component = new PLThruster((EThrusterType)Thruster(seed), level);
                    break;
                case 10:
                    component = PLShipComponent.CreateShipComponentFromHash((int)PLShipComponent.createHashFromInfo(10, Turret(seed), level, 0, 12), null);
                    break;
                case 11:
                    component = PLShipComponent.CreateShipComponentFromHash((int)PLShipComponent.createHashFromInfo(11, MainTurret(seed), level, 0, 12), null);
                    break;
                case 16:
                    component = new PLHullPlating((EHullPlatingType)HullPlating(seed), level);
                    break;
                case 17:
                    component = new PLWarpDriveProgram((EWarpDriveProgramType)Program(seed), level);
                    break;
                case 19:
                    component = new PLNuclearDevice((ENuclearDeviceType)Nuclear(seed), level);
                    break;
                case 20:
                    component = new PLTrackerMissile((ETrackerMissileType)Missile(seed), level);
                    break;
                case 21:
                    component = new PLScrapCargo(level);
                    break;
                case 22:
                    component = new PLDistressSignal((EDistressSignalType)SOS(seed), level);
                    break;
                case 23:
                    component = new PLMissionShipComponent(Mission(seed), level);
                    break;
                case 24:
                    component = PLAutoTurret.CreateAutoTurretFromHash(AutoTurret(seed),level,0);
                    break;
                case 25:
                    component = new PLInertiaThruster((EInertiaThrusterType)Inertia(seed), level);
                    break;
                case 26:
                    component = new PLManeuverThruster((EManeuverThrusterType)Maneuver(seed), level);
                    break;
                case 27:
                    component = new PLCaptainsChair((ECaptainsChairType)Chair(seed), level);
                    break;
                case 28:
                    component = new PLExtractor((EExtractorType)Extractor(seed), level);
                    break;
                case 30:
                    component = new PLFBRecipeModule((FBRecipe)Recipe(seed), level);
                    break;
                case 32:
                    component = new PLSensorDish(ESensorDishType.E_NORMAL, level);
                    break;
                case 33:
                    component = new PLCloakingSystem((ECloakingSystemType)Cloak(seed), level);
                    break;
                case 34:
                    component = new PLPolytechModule((EPolytechModuleType)Polytech(seed), level);
                    break;
            }
            return component;
        }


    }

}

