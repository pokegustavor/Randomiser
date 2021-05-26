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
        public static int Hull(int seed = 1)
        {
            System.Random random = new System.Random(Random4() * seed);
            int value = random.Next(0, 16);
            if (value == 4 || value == 15)
            {
                value = 0;
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
        public static int Level(int seed = 1) 
        {
            System.Random random = new System.Random(Random4() * seed);
            int value = random.Next(0, 31);
            return value;
        }

    }
    
}

