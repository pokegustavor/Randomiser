using System;
using HarmonyLib;

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
        public static int Hull()
        {
            System.Random random = new System.Random();
            int value = random.Next(0, Enum.GetValues(typeof(EHullType)).Length );
            if (value == 4 || value == 15)
            {
                value = 0;
            }
            return value;
        }
        public static int Shield()
        {
            System.Random random = new System.Random();
            int value = random.Next(0, Enum.GetValues(typeof(EShieldGeneratorType)).Length);
            if (value == 10)
            {
                value = 0;
            }
            return value;
        }
        public static int Reactor()
        {
            System.Random random = new System.Random();
            int value = random.Next(0, Enum.GetValues(typeof(EReactorType)).Length);
            if (value == 7)
            {
                value = 0;
            }
            return value;
        }
        public static int Jump()
        {
            System.Random random = new System.Random();
            int value = random.Next(0, Enum.GetValues(typeof(EWarpDriveType)).Length);
            if (value == 4)
            {
                value = 0;
            }
            return value;
        }
        public static int Thruster(int seed)
        {
            System.Random random = new System.Random(Random4()*seed);
            int value = random.Next(0, Enum.GetValues(typeof(EThrusterType)).Length);
            return value;
        }
        public static int Inertia(int seed)
        {
            System.Random random = new System.Random(Random4()*seed);
            int value = random.Next(0, Enum.GetValues(typeof(EInertiaThrusterType)).Length);
            if(value == 1)
            {
                value = 0;
            }
            return value;
        }
        public static int Maneuver(int seed)
        {
            System.Random random = new System.Random(Random4()*seed);
            int value = random.Next(0, Enum.GetValues(typeof(EManeuverThrusterType)).Length);
            return value;
        }
        public static int Chair()
        {
            System.Random random = new System.Random();
            int value = random.Next(0, Enum.GetValues(typeof(ECaptainsChairType)).Length);
            return value;
        }
        public static int Extractor()
        {
            System.Random random = new System.Random();
            int value = random.Next(0, Enum.GetValues(typeof(EExtractorType)).Length);
            if(value == 2)
            {
                value = 0;
            }
            return value;
        }
        public static int Turret(int seed)
        {
            System.Random random = new System.Random(Random4()*seed);
            int value = random.Next(0, Enum.GetValues(typeof(ETurretType)).Length);
            if (value == 5)
            {
                value = 7;
            }
            return value;
        }
        public static int MainTurret()
        {
            System.Random random = new System.Random();
            int value = random.Next(0, 6);
            return value;
        }
        public static int Cloak()
        {
            System.Random random = new System.Random();
            int value = random.Next(0, Enum.GetValues(typeof(ECloakingSystemType)).Length);
            return value;
        }

        public static int Missile(int seed)
        {
            System.Random random = new System.Random(Random4()*seed);
            int value = random.Next(0, Enum.GetValues(typeof(ETrackerMissileType)).Length);
            if (value == 3)
            {
                value = 0;
            }
            return value;
        }
        public static int O2()
        {
            System.Random random = new System.Random();
            int value = random.Next(0, Enum.GetValues(typeof(EO2GeneratorType)).Length);           
            return value;
        }
        public static int Processor(int seed)
        {
            System.Random random = new System.Random(Random4()*seed);
            int value = random.Next(1, Enum.GetValues(typeof(ECPUClass)).Length);
            return value;
        }
        public static int Program(int seed)
        {
            System.Random random = new System.Random(Random4()*seed);
            int value = random.Next(0, Enum.GetValues(typeof(EWarpDriveProgramType)).Length);
            if (value == 8)
            {
                value = 18;
            }
            return value;
        }
    }
    
}

