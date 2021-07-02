namespace Randomizer
{
    class Randomic
    {
        public static int Random()
        {
            System.Random random = new System.Random();
            int value = random.Next(0, 21052003);
            return value;
        }
        public static int Random2()
        {
            System.Random random = new System.Random(Random());
            int value = random.Next(0, 69);
            return value;
        }
        public static int Random3()
        {
            System.Random random = new System.Random(Random2());
            int value = random.Next(1542, 500397);
            return value;
        }
        public static int Random4()
        {
            System.Random random = new System.Random(Random3());
            int value = random.Next(10000, 32727);
            return value;
        }
        public static int Hull(int seed = 1)
        {
            System.Random random = new System.Random(Random4() * seed);
            int value = random.Next(0, 16);
            if (value == 4 || value == 15)
            {
                value = 0;
            }
            if (!Configs.bossitem && (value == 5 || value == 6 || value == 8 || value == 10 || value == 11 || value == 12 || value == 13)) 
            {
                value += 8;             
            }
            return value;
        }
        public static int Shield(int seed = 1)
        {
            System.Random random = new System.Random(Random4() * seed);
            int value = random.Next(0, 20);
            if (value == 10)
            {
                value = 0;
            }
            return value;
        }
        public static int Reactor(int seed = 1)
        {
            System.Random random = new System.Random(Random4()*seed);
            int value = random.Next(0, 15);
            if (value == 7)
            {
                value = 0;
            }
            if (!Configs.bossitem && (value == 9 || value == 15))
            {
                value += 1;
            }
            return value;
        }
        public static int Jump(int seed = 1)
        {
            System.Random random = new System.Random(Random4() * seed);
            int value = random.Next(0, 14);
            if (value == 4)
            {
                value = 0;
            }
            return value;
        }
        public static int Thruster(int seed = 1)
        {
            System.Random random = new System.Random(Random4()*seed);
            int value = random.Next(0, 4);
            return value;
        }
        public static int Inertia(int seed = 1)
        {
            System.Random random = new System.Random(Random4()*seed);
            int value = random.Next(0, 5);
            if(value == 1)
            {
                value = 0;
            }
            if (!Configs.bossitem && (value == 2 || value == 3))
            {
                value += 2;
            }
            return value;
        }
        public static int Maneuver(int seed = 1)
        {
            System.Random random = new System.Random(Random4()*seed);
            int value = random.Next(0, 2);
            return value;
        }
        public static int Chair(int seed = 1)
        {
            System.Random random = new System.Random(Random4() * seed);
            int value = random.Next(0, 2);
            return value;
        }
        public static int Extractor(int seed = 1)
        {
            System.Random random = new System.Random(Random4() * seed);
            int value = random.Next(0, 5);
            if(value == 2)
            {
                value = 0;
            }
            return value;
        }
        public static int Turret(int seed = 1)
        {
            System.Random random = new System.Random(Random4()*seed);
            int value = random.Next(0, 18);
            if (value == 5)
            {
                value = 7;
            }
            if (!Configs.bossitem && (value == 7 || value == 8 || value == 18))
            {
                value += 2;
            }
            return value;
        }
        public static int MainTurret(int seed = 1)
        {
            System.Random random = new System.Random(Random4() * seed);
            int value = random.Next(0, 6);
            return value;
        }
        public static int Cloak(int seed = 1)
        {
            System.Random random = new System.Random(Random4() * seed);
            int value = random.Next(0, 1);
            return value;
        }

        public static int Missile(int seed = 1)
        {
            System.Random random = new System.Random(Random4()*seed);
            int value = random.Next(0, 9);
            if (value == 3)
            {
                value = 0;
            }
            if (!Configs.bossitem && (value == 5))
            {
                value += 1;
            }
            return value;
        }
        public static int O2(int seed = 1)
        {
            System.Random random = new System.Random(Random4() * seed);
            int value = random.Next(0, 1);           
            return value;
        }
        public static int Processor(int seed = 1)
        {
            System.Random random = new System.Random(Random4()*seed);
            int value = random.Next(1, 29);
            return value;
        }
        public static int Program(int seed = 1)
        {
            System.Random random = new System.Random(Random4()*seed);
            int value = random.Next(0, 35);
            if (value == 8)
            {
                value = 18;
            }
            return value;
        }
        public static int Nuclear(int seed = 1)
        {
            System.Random random = new System.Random(Random4() * seed);
            int value = random.Next(0, 6);
            if (value == 3)
            {
                value = 0;
            }
            return value;
        }
        public static int Polytech(int seed = 1)
        {
            System.Random random = new System.Random(Random4() * seed);
            int value = random.Next(0, 5);           
            return value;
        }
        public static int SOS(int seed = 1) 
        {
            System.Random random = new System.Random(Random4() * seed);
            int value = random.Next(0, 2);
            return value;
        }
        public static int Mission(int seed = 1) 
        {
            System.Random random = new System.Random(Random4() * seed);
            int value = random.Next(0, 12);
            return value;
        }
        public static int Recipe(int seed = 1) 
        {
            System.Random random = new System.Random(Random4() * seed);
            int value = random.Next(0, 16);
            return value;
        }

        public static int Level(int seed = 1, ESlotType type = ESlotType.E_COMP_ID_MAX) 
        {
            System.Random random = new System.Random(Random4() * seed);
            int value = type == ESlotType.E_COMP_WARP ? random.Next(0,9) : random.Next(0, 31);
            return value;
        }
        
        public static int ItemLevel(int seed = 1) 
        {
            System.Random random = new System.Random(Random4() * seed);
            int value = random.Next(0, 15);
            return value;
        }

        public static EShipType Type(int seed = 1) 
        {
            System.Random random = new System.Random(Random4() * seed);
            int value = random.Next(0, 58);
            if(value == 5 || value == 7 || value == 8 || value == 18 || value == 19 || value == 20 || value == 21 || value == 22 || value == 24 || value == 37 || (value >= 38 && value <=43) || value == 48 || value == 49 || value == 54 || value == 55 || value == 57) 
            {
                value = 52;
            }
            return (EShipType)value;
        }
        public static int Item(int seed = 1) 
        {
            System.Random random = new System.Random(Random4() * seed);
            int value = random.Next(0, 33);
            if(value == 32 || value == 31 || value == 18 || value == 17 || value == 15 || value == 14 || value == 13 || value == 6 || value == 5 || value == 1 || value == 0) 
            {
                value += 6;
                if(value > 33) 
                {
                    value -= 10;
                }
                else if (value == 6) 
                {
                    value = 7;
                }
            }
            return value;
        }
        public static PLShipComponent Comp(int seed = 1, int level = 0) 
        {
            System.Random random = new System.Random(Random4() * seed);
            int type = random.Next(1, 34);
            PLShipComponent component;
            if (type == 4 || (type >= 12 && type <= 15) || type == 18 || type == 29)
            {
                type++;
                if (type >= 12 && type <= 15)
                {
                    type += 10;
                }
            }
            switch (type) 
            {
                default:
                case 1:
                    component = new PLShieldGenerator((EShieldGeneratorType)Randomic.Shield(seed), level);
                    break;
                case 2:
                    component = new PLWarpDrive((EWarpDriveType)Randomic.Jump(seed), level);
                    break;
                case 3:
                    component = new PLReactor((EReactorType)Randomic.Reactor(seed), level);
                    break;
                case 5:
                    component = new PLSensor();
                    break;
                case 6:
                    component = new PLHull((EHullType)Randomic.Hull(seed), level);
                    break;
                case 7:
                    component = new PLCPU((ECPUClass)Randomic.Processor(seed), level);
                    break;
                case 8:
                    component = new PLOxygenGenerator((EO2GeneratorType)Randomic.O2(seed),level);
                    break;
                case 9:
                    component = new PLThruster((EThrusterType)Randomic.Thruster(seed), level);
                    break;
                case 10:
                    component = PLShipComponent.CreateShipComponentFromHash((int)PLShipComponent.createHashFromInfo(10, Randomic.Turret(seed), level, 0, 12), null);
                    break;
                case 11:
                    component = PLShipComponent.CreateShipComponentFromHash((int)PLShipComponent.createHashFromInfo(11, Randomic.MainTurret(seed), level, 0, 12), null);
                    break;
                case 16:
                    component = new PLHullPlating(EHullPlatingType.E_HULLPLATING_CCGE, level);
                    break;
                case 17:
                    component = new PLWarpDriveProgram((EWarpDriveProgramType)Randomic.Program(seed), level);
                    break;
                case 19:
                    component = new PLNuclearDevice((ENuclearDeviceType)Randomic.Nuclear(seed), level);
                    break;
                case 20:
                    component = new PLTrackerMissile((ETrackerMissileType)Randomic.Missile(seed), level);
                    break;
                case 22:
                    component = new PLDistressSignal((EDistressSignalType)Randomic.SOS(seed), level);
                    break;
                case 23:
                    component = new PLMissionShipComponent(Randomic.Mission(seed), level);
                    break;
                case 25:
                    component = new PLInertiaThruster((EInertiaThrusterType)Randomic.Inertia(seed), level);
                    break;
                case 26:
                    component = new PLManeuverThruster((EManeuverThrusterType)Randomic.Maneuver(seed), level);
                    break;
                case 27:
                    component = new PLCaptainsChair((ECaptainsChairType)Randomic.Chair(seed), level);
                    break;
                case 28:
                    component = new PLExtractor((EExtractorType)Randomic.Extractor(seed), level);
                    break;
                case 30:
                    component = new PLFBRecipeModule((FBRecipe)Randomic.Recipe(seed), level);
                    break;
                case 33:
                    component = new PLCloakingSystem((ECloakingSystemType)Randomic.Cloak(seed), level);
                    break;
                case 34:
                    component = new PLPolytechModule((EPolytechModuleType)Randomic.Polytech(seed), level);
                    break;
            }
            return component;
        }


    }
    
}

