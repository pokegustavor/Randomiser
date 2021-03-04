using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randomizer
{
    class Random
    {
        static public void random(PLShipInfoBase ship, bool previewStats, bool Iscomand)
        {
            if (PhotonNetwork.isMasterClient || previewStats)
            {
                PLShipStats myStats = ship.MyStats;
                EShipType shiptype = myStats.Ship.ShipTypeID;              
                int HullLv = 0;
                int InertiaLv = 0;
                int MainTLv = 0;
                int ManuvLv = 0;
                int ReactorLv = 0;
                int ShildLv = 0;
                int ThrustLv = 0;
                int MisselLv = 0;
                int TurretLv = 0;
                int WarpLv = 0;
                int Hull = 0;
                int Inertias = 0;
                int MainT = 0;
                int Manuv = 0;
                int Thrust = 0;
                int Missel = 0;
                int Turret = 0;
                int Shld = 0;
                int reactor = 0;
                int Chair = 0;
                int Cloak = 0;
                int Salvage = 0;
                int CPU = 0;
                int Program = 0;
                int warp = 0;
                List<PLShipComponent> AllShipComponents = myStats.AllComponents;
                if (ship.ShouldCreateDefaultComponents)
                {
                    
                    for (int i = AllShipComponents.Count - 1; i > -1; i--)
                    {
                        if (AllShipComponents[i].SlotType == ESlotType.E_COMP_CAPTAINS_CHAIR)
                        {
                            myStats.RemoveShipComponent(AllShipComponents[i]);
                            Chair++;
                        }
                        else if (AllShipComponents[i].SlotType == ESlotType.E_COMP_CLOAKING_SYS)
                        {
                            myStats.RemoveShipComponent(AllShipComponents[i]);
                            Cloak++;
                        }
                        else if (AllShipComponents[i].SlotType == ESlotType.E_COMP_HULL && shiptype != EShipType.E_GUARDIAN)
                        {
                            HullLv = AllShipComponents[i].Level;
                            myStats.RemoveShipComponent(AllShipComponents[i]);
                            Hull++;
                        }
                        else if (AllShipComponents[i].SlotType == ESlotType.E_COMP_INERTIA_THRUSTER)
                        {
                            InertiaLv = AllShipComponents[i].Level;
                            myStats.RemoveShipComponent(AllShipComponents[i]);
                            Inertias++;
                        }
                        else if (AllShipComponents[i].SlotType == ESlotType.E_COMP_MAINTURRET)
                        {
                            MainTLv = AllShipComponents[i].Level;
                            myStats.RemoveShipComponent(AllShipComponents[i]);
                            MainT++;
                        }
                        else if (AllShipComponents[i].SlotType == ESlotType.E_COMP_MANEUVER_THRUSTER)
                        {
                            ManuvLv = AllShipComponents[i].Level;
                            myStats.RemoveShipComponent(AllShipComponents[i]);
                            Manuv++;
                        }
                        else if (AllShipComponents[i].SlotType == ESlotType.E_COMP_O2)
                        {
                            myStats.RemoveShipComponent(AllShipComponents[i]);
                           
                        }
                        else if (AllShipComponents[i].SlotType == ESlotType.E_COMP_REACTOR)
                        {
                            ReactorLv = AllShipComponents[i].Level;
                            myStats.RemoveShipComponent(AllShipComponents[i]);
                            reactor++;
                        }
                        else if (AllShipComponents[i].SlotType == ESlotType.E_COMP_SALVAGE_SYSTEM)
                        {
                            myStats.RemoveShipComponent(AllShipComponents[i]);
                            Salvage++;
                        }
                        else if (AllShipComponents[i].SlotType == ESlotType.E_COMP_SHLD)
                        {
                            ShildLv = AllShipComponents[i].Level;
                            myStats.RemoveShipComponent(AllShipComponents[i]);
                            Shld++;
                        }
                        else if (AllShipComponents[i].SlotType == ESlotType.E_COMP_THRUSTER)
                        {
                            ThrustLv = AllShipComponents[i].Level;
                            myStats.RemoveShipComponent(AllShipComponents[i]);
                            Thrust++;
                        }
                        else if (AllShipComponents[i].SlotType == ESlotType.E_COMP_TRACKERMISSILE)
                        {
                            MisselLv = AllShipComponents[i].Level;
                            myStats.RemoveShipComponent(AllShipComponents[i]);
                            Missel++;
                        }
                        else if (AllShipComponents[i].SlotType == ESlotType.E_COMP_TURRET)
                        {
                            TurretLv = AllShipComponents[i].Level;
                            myStats.RemoveShipComponent(AllShipComponents[i]);
                            Turret++;
                        }
                        else if (AllShipComponents[i].SlotType == ESlotType.E_COMP_WARP)
                        {
                            WarpLv = AllShipComponents[i].Level;
                            myStats.RemoveShipComponent(AllShipComponents[i]);
                            warp++;
                        }
                        else if(AllShipComponents[i].SlotType == ESlotType.E_COMP_CARGO || AllShipComponents[i].SlotType == ESlotType.E_COMP_HIDDENCARGO)
                        {
                            myStats.RemoveShipComponent(AllShipComponents[i]);
                        }
                        else if (AllShipComponents[i].SlotType == ESlotType.E_COMP_CPU)
                        {
                            myStats.RemoveShipComponent(AllShipComponents[i]);
                            CPU++;
                        }
                        else if (AllShipComponents[i].SlotType == ESlotType.E_COMP_PROGRAM)
                        {
                            myStats.RemoveShipComponent(AllShipComponents[i]);
                            Program++;
                        }
                        if (Iscomand)
                        {
                            HullLv = 0;
                            InertiaLv = 0;
                            MainTLv = 0;
                            ManuvLv = 0;
                            ReactorLv = 0;
                            ShildLv = 0;
                            ThrustLv = 0;
                            MisselLv = 0;
                            TurretLv = 0;
                            WarpLv = 0;
                        }
                    }
                    myStats.AddShipComponent(PLShipComponent.CreateShipComponentFromHash((int)PLShipComponent.createHashFromInfo(8, Randomic.O2(), 0, 0, 12), null), -1, ESlotType.E_COMP_O2);
                    for (int i = 0; i < Hull; i++)
                    {
                        myStats.AddShipComponent(PLShipComponent.CreateShipComponentFromHash((int)PLShipComponent.createHashFromInfo(6, Randomic.Hull(), HullLv, 0, 12), null), -1, ESlotType.E_COMP_HULL);
                    }
                    for (int i = 0; i < Shld; i++)
                    {
                        myStats.AddShipComponent(PLShipComponent.CreateShipComponentFromHash((int)PLShipComponent.createHashFromInfo(1, Randomic.Shield(), ShildLv, 0, 12), null), -1, ESlotType.E_COMP_SHLD);
                    }
                    for (int i = 0; i < Salvage; i++)
                    {
                        myStats.AddShipComponent(PLShipComponent.CreateShipComponentFromHash((int)PLShipComponent.createHashFromInfo(28, Randomic.Extractor(), 0, 0, 12), null), -1, ESlotType.E_COMP_SALVAGE_SYSTEM);
                    }
                    for (int i = 0; i < Cloak; i++)
                    {
                        myStats.AddShipComponent(PLShipComponent.CreateShipComponentFromHash((int)PLShipComponent.createHashFromInfo(33, Randomic.Cloak(), 0, 0, 12), null), -1, ESlotType.E_COMP_CLOAKING_SYS);
                    }
                    for (int i = 0; i < Turret; i++)
                    {
                        myStats.AddShipComponent(PLShipComponent.CreateShipComponentFromHash((int)PLShipComponent.createHashFromInfo(10, Randomic.Turret((i + 1) * 24), TurretLv, 0, 12), null), -1, ESlotType.E_COMP_TURRET);
                    }
                    for (int i = 0; i < Thrust; i++)
                    {
                        myStats.AddShipComponent(PLShipComponent.CreateShipComponentFromHash((int)PLShipComponent.createHashFromInfo(9, Randomic.Thruster((i + 1) * 16), ThrustLv, 0, 12), null), -1, ESlotType.E_COMP_THRUSTER);
                    }
                    for (int i = 0; i < Inertias; i++)
                    {
                        myStats.AddShipComponent(PLShipComponent.CreateShipComponentFromHash((int)PLShipComponent.createHashFromInfo(25, Randomic.Inertia((i + 1) * 12), InertiaLv, 0, 12), null), -1, ESlotType.E_COMP_INERTIA_THRUSTER);
                    }
                    for (int i = 0; i < Missel; i++)
                    {
                        myStats.AddShipComponent(PLShipComponent.CreateShipComponentFromHash((int)PLShipComponent.createHashFromInfo(20, Randomic.Missile((i + 1) * 75), MisselLv, 0, 12), null), -1, ESlotType.E_COMP_TRACKERMISSILE);
                    }
                    myStats.AddShipComponent(PLShipComponent.CreateShipComponentFromHash((int)PLShipComponent.createHashFromInfo(7, 0, 0, 0, 12), null), -1, ESlotType.E_COMP_CPU);
                    for (int i = 0; i < CPU - 1; i++)
                    {
                        myStats.AddShipComponent(PLShipComponent.CreateShipComponentFromHash((int)PLShipComponent.createHashFromInfo(7, Randomic.Processor((i + 1) * 8), 0, 0, 12), null), -1, ESlotType.E_COMP_CPU);
                    }
                    for (int i = 0; i < Program; i++)
                    {
                        myStats.AddShipComponent(PLShipComponent.CreateShipComponentFromHash((int)PLShipComponent.createHashFromInfo(17, Randomic.Program((i + 1) * 3), 0, 0, 12), null), -1, ESlotType.E_COMP_PROGRAM);
                    }
                    for (int i = 0; i < Manuv; i++)
                    {
                        myStats.AddShipComponent(PLShipComponent.CreateShipComponentFromHash((int)PLShipComponent.createHashFromInfo(26, Randomic.Maneuver((i + 1) * 14), ManuvLv, 0, 12), null), -1, ESlotType.E_COMP_MANEUVER_THRUSTER);
                    }
                    for (int i = 0; i < MainT; i++)
                    {
                        myStats.AddShipComponent(PLShipComponent.CreateShipComponentFromHash((int)PLShipComponent.createHashFromInfo(11, Randomic.MainTurret(), MainTLv, 0, 12), null), -1, ESlotType.E_COMP_MAINTURRET);
                    }
                    for (int i = 0; i < Chair; i++)
                    {
                        myStats.AddShipComponent(PLShipComponent.CreateShipComponentFromHash((int)PLShipComponent.createHashFromInfo(27, Randomic.Chair(), 0, 0, 12), null), -1, ESlotType.E_COMP_CAPTAINS_CHAIR);
                    }
                    for (int i = 0; i < reactor; i++)
                    {
                        myStats.AddShipComponent(PLShipComponent.CreateShipComponentFromHash((int)PLShipComponent.createHashFromInfo(3, Randomic.Reactor(), ReactorLv, 0, 12), null), -1, ESlotType.E_COMP_REACTOR);
                    }
                    for (int i = 0; i < warp; i++)
                    {
                        myStats.AddShipComponent(PLShipComponent.CreateShipComponentFromHash((int)PLShipComponent.createHashFromInfo(2, Randomic.Jump(), WarpLv, 0, 12), null), -1, ESlotType.E_COMP_WARP);
                    }
                }
            }
        }

    }
}
