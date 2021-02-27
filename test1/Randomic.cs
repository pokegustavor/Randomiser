using System;
using HarmonyLib;

namespace Randomizer
{
    class Randomic
    {

        public static int Hull()
        {
            System.Random random = new System.Random();
            int value = random.Next(0, Enum.GetValues(typeof(EHullType)).Length - 2);
            if (value == 4)
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
        public static int Thruster()
        {
            System.Random random = new System.Random();
            int value = random.Next(0, Enum.GetValues(typeof(EThrusterType)).Length);
            return value;
        }
        public static int Thruster2()
        {
            System.Random random = new System.Random();
            int value = random.Next(1, Enum.GetValues(typeof(EThrusterType)).Length);
            return value;
        }
        public static int Thruster3()
        {
            System.Random random = new System.Random();
            int value = random.Next(1, Enum.GetValues(typeof(EThrusterType)).Length - 1);
            return value;
        }
        public static int Thruster4()
        {
            System.Random random = new System.Random();
            int value = random.Next(0, Enum.GetValues(typeof(EThrusterType)).Length - 1);
            return value;
        }
        public static int Inertia()
        {
            System.Random random = new System.Random();
            int value = random.Next(0, Enum.GetValues(typeof(EInertiaThrusterType)).Length);
            if(value == 1)
            {
                value = 0;
            }
            return value;
        }
        public static int Inertia2()
        {
            System.Random random = new System.Random();
            int value = random.Next(0, Enum.GetValues(typeof(EInertiaThrusterType)).Length - 1);
            if (value == 1)
            {
                value = 0;
            }
            return value;
        }
        public static int Maneuver()
        {
            System.Random random = new System.Random();
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
        public static int Turret()
        {
            System.Random random = new System.Random();
            int value = random.Next(0, Enum.GetValues(typeof(ETurretType)).Length);
            return value;
        }
        public static int Turret2()
        {
            System.Random random = new System.Random();
            int value = random.Next(0, Enum.GetValues(typeof(ETurretType)).Length - 1);
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

        public static int Missile()
        {
            System.Random random = new System.Random();
            int value = random.Next(0, Enum.GetValues(typeof(ETrackerMissileType)).Length);
            if (value == 3)
            {
                value = 0;
            }
            return value;
        }
        public static int Missile2()
        {
            System.Random random = new System.Random();
            int value = random.Next(0, Enum.GetValues(typeof(ETrackerMissileType)).Length - 1);
            if (value == 3)
            {
                value = 0;
            }
            return value;
        }
        public static int Missile3()
        {
            System.Random random = new System.Random();
            int value = random.Next(1, Enum.GetValues(typeof(ETrackerMissileType)).Length);
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
    }
    
}

