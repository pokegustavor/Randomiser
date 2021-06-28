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
            }
            return value;
        }
    }
    
}

