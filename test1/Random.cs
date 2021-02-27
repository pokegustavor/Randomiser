using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randomizer
{
    class Random
    {
        static public void random(PLShipInfoBase ship, bool previewStats)
        {
            if (PhotonNetwork.isMasterClient || previewStats)
            {
                PLShipStats myStats = ship.MyStats;
                EShipType shiptype = myStats.Ship.ShipTypeID;
                List<PLShipComponent> AllShipComponents = myStats.AllComponents;
                myStats.SetSlot_IsLocked(ESlotType.E_COMP_CAPTAINS_CHAIR, true);
                if (shiptype == EShipType.E_STARGAZER || shiptype == EShipType.E_CARRIER || shiptype == EShipType.OLDWARS_SYLVASSI)
                {
                    myStats.SetSlot_IsLocked(ESlotType.E_COMP_CLOAKING_SYS, true);
                }
                myStats.SetSlot_IsLocked(ESlotType.E_COMP_HULL, true);
                myStats.SetSlot_IsLocked(ESlotType.E_COMP_INERTIA_THRUSTER, true);
                myStats.SetSlot_IsLocked(ESlotType.E_COMP_MAINTURRET, true);
                myStats.SetSlot_IsLocked(ESlotType.E_COMP_MANEUVER_THRUSTER, true);
                myStats.SetSlot_IsLocked(ESlotType.E_COMP_O2, true);
                myStats.SetSlot_IsLocked(ESlotType.E_COMP_REACTOR, true);
                if (shiptype != EShipType.E_WDCRUISER && shiptype != EShipType.E_DESTROYER)
                {
                    myStats.SetSlot_IsLocked(ESlotType.E_COMP_SALVAGE_SYSTEM, true);
                }
                if (shiptype != EShipType.OLDWARS_HUMAN)
                {
                    myStats.SetSlot_IsLocked(ESlotType.E_COMP_SHLD, true);
                }
                myStats.SetSlot_IsLocked(ESlotType.E_COMP_THRUSTER, true);
                myStats.SetSlot_IsLocked(ESlotType.E_COMP_TRACKERMISSILE, true);
                myStats.SetSlot_IsLocked(ESlotType.E_COMP_TURRET, true);
                myStats.SetSlot_IsLocked(ESlotType.E_COMP_WARP, true);

                if (ship.ShouldCreateDefaultComponents)
                {
                    for (int i = AllShipComponents.Count - 1; i > -1; i--)
                    {
                        if (AllShipComponents[i].SlotType == ESlotType.E_COMP_CAPTAINS_CHAIR)
                        {
                            myStats.RemoveShipComponent(AllShipComponents[i]);

                        }
                        else if (AllShipComponents[i].SlotType == ESlotType.E_COMP_CLOAKING_SYS)
                        {
                            myStats.RemoveShipComponent(AllShipComponents[i]);

                        }
                        else if (AllShipComponents[i].SlotType == ESlotType.E_COMP_HULL)
                        {
                            myStats.RemoveShipComponent(AllShipComponents[i]);

                        }
                        else if (AllShipComponents[i].SlotType == ESlotType.E_COMP_INERTIA_THRUSTER)
                        {
                            myStats.RemoveShipComponent(AllShipComponents[i]);

                        }
                        else if (AllShipComponents[i].SlotType == ESlotType.E_COMP_MAINTURRET)
                        {
                            myStats.RemoveShipComponent(AllShipComponents[i]);

                        }
                        else if (AllShipComponents[i].SlotType == ESlotType.E_COMP_MANEUVER_THRUSTER)
                        {
                            myStats.RemoveShipComponent(AllShipComponents[i]);

                        }
                        else if (AllShipComponents[i].SlotType == ESlotType.E_COMP_O2)
                        {
                            myStats.RemoveShipComponent(AllShipComponents[i]);

                        }
                        else if (AllShipComponents[i].SlotType == ESlotType.E_COMP_REACTOR)
                        {
                            myStats.RemoveShipComponent(AllShipComponents[i]);

                        }
                        else if (AllShipComponents[i].SlotType == ESlotType.E_COMP_SALVAGE_SYSTEM)
                        {
                            myStats.RemoveShipComponent(AllShipComponents[i]);

                        }
                        else if (AllShipComponents[i].SlotType == ESlotType.E_COMP_SHLD)
                        {
                            myStats.RemoveShipComponent(AllShipComponents[i]);

                        }
                        else if (AllShipComponents[i].SlotType == ESlotType.E_COMP_THRUSTER)
                        {
                            myStats.RemoveShipComponent(AllShipComponents[i]);

                        }
                        else if (AllShipComponents[i].SlotType == ESlotType.E_COMP_TRACKERMISSILE)
                        {
                            myStats.RemoveShipComponent(AllShipComponents[i]);

                        }
                        else if (AllShipComponents[i].SlotType == ESlotType.E_COMP_TURRET)
                        {
                            myStats.RemoveShipComponent(AllShipComponents[i]);

                        }
                        else if (AllShipComponents[i].SlotType == ESlotType.E_COMP_WARP)
                        {
                            myStats.RemoveShipComponent(AllShipComponents[i]);

                        }
                    }
                    if (shiptype != EShipType.OLDWARS_HUMAN)
                    {
                        myStats.AddShipComponent(PLShipComponent.CreateShipComponentFromHash((int)PLShipComponent.createHashFromInfo(1, Randomic.Shield(), 0, 0, 12), null), 14, ESlotType.E_COMP_SHLD);
                    }
                    if (shiptype != EShipType.E_WDCRUISER && shiptype != EShipType.E_DESTROYER)
                    {
                        myStats.AddShipComponent(PLShipComponent.CreateShipComponentFromHash((int)PLShipComponent.createHashFromInfo(28, Randomic.Extractor(), 0, 0, 12), null), 19, ESlotType.E_COMP_SALVAGE_SYSTEM);
                    }
                    if (shiptype == EShipType.E_STARGAZER || shiptype == EShipType.E_CARRIER || shiptype == EShipType.OLDWARS_SYLVASSI)
                    {
                        myStats.AddShipComponent(PLShipComponent.CreateShipComponentFromHash((int)PLShipComponent.createHashFromInfo(33, Randomic.Cloak(), 0, 0, 12), null), 21, ESlotType.E_COMP_CLOAKING_SYS);
                    }
                    if (shiptype != EShipType.E_OUTRIDER && shiptype != EShipType.E_DESTROYER && shiptype != EShipType.OLDWARS_SYLVASSI && shiptype != EShipType.E_CIVILIAN_STARTING_SHIP && shiptype != EShipType.E_CORRUPTED_DRONE)
                    {
                        myStats.AddShipComponent(PLShipComponent.CreateShipComponentFromHash((int)PLShipComponent.createHashFromInfo(10, Randomic.Turret(), 0, 0, 12), null), 17, ESlotType.E_COMP_TURRET);
                        myStats.AddShipComponent(PLShipComponent.CreateShipComponentFromHash((int)PLShipComponent.createHashFromInfo(10, Randomic.Turret2(), 0, 0, 12), null), 18, ESlotType.E_COMP_TURRET);
                    }
                    else if (shiptype == EShipType.E_CORRUPTED_DRONE)
                    {
                        for (int i = 0; i < 10; i++)
                        {
                            myStats.AddShipComponent(PLShipComponent.CreateShipComponentFromHash((int)PLShipComponent.createHashFromInfo(10, Randomic.Turret(), 0, 0, 12), null), 17, ESlotType.E_COMP_TURRET);
                            myStats.AddShipComponent(PLShipComponent.CreateShipComponentFromHash((int)PLShipComponent.createHashFromInfo(10, Randomic.Turret2(), 0, 0, 12), null), 18, ESlotType.E_COMP_TURRET);
                        }
                    }
                    else if (shiptype == EShipType.E_GUARDIAN)
                    {
                        myStats.AddShipComponent(PLShipComponent.CreateShipComponentFromHash((int)PLShipComponent.createHashFromInfo(10, Randomic.Turret(), 0, 0, 12), null), 17, ESlotType.E_COMP_TURRET);
                        myStats.AddShipComponent(PLShipComponent.CreateShipComponentFromHash((int)PLShipComponent.createHashFromInfo(10, Randomic.Turret2(), 0, 0, 12), null), 18, ESlotType.E_COMP_TURRET);
                        myStats.AddShipComponent(PLShipComponent.CreateShipComponentFromHash((int)PLShipComponent.createHashFromInfo(10, Randomic.Turret2(), 0, 0, 12), null), 18, ESlotType.E_COMP_TURRET);
                    }
                    else
                    {
                        myStats.AddShipComponent(PLShipComponent.CreateShipComponentFromHash((int)PLShipComponent.createHashFromInfo(10, Randomic.Turret(), 0, 0, 12), null), 17, ESlotType.E_COMP_TURRET);
                    }
                    if (shiptype == EShipType.E_ROLAND || shiptype == EShipType.E_DEATHSEEKER_DRONE || shiptype == EShipType.E_DEATHSEEKER_DRONE_SC)
                    {
                        myStats.AddShipComponent(PLShipComponent.CreateShipComponentFromHash((int)PLShipComponent.createHashFromInfo(9, Randomic.Thruster(), 0, 0, 12), null), 15, ESlotType.E_COMP_THRUSTER);
                        myStats.AddShipComponent(PLShipComponent.CreateShipComponentFromHash((int)PLShipComponent.createHashFromInfo(9, Randomic.Thruster2(), 0, 0, 12), null), 16, ESlotType.E_COMP_THRUSTER);
                        myStats.AddShipComponent(PLShipComponent.CreateShipComponentFromHash((int)PLShipComponent.createHashFromInfo(9, Randomic.Thruster3(), 0, 0, 12), null), 26, ESlotType.E_COMP_THRUSTER);
                        myStats.AddShipComponent(PLShipComponent.CreateShipComponentFromHash((int)PLShipComponent.createHashFromInfo(9, Randomic.Thruster4(), 0, 0, 12), null), 27, ESlotType.E_COMP_THRUSTER);

                    }
                    else
                    {
                        myStats.AddShipComponent(PLShipComponent.CreateShipComponentFromHash((int)PLShipComponent.createHashFromInfo(9, Randomic.Thruster(), 0, 0, 12), null), 15, ESlotType.E_COMP_THRUSTER);
                        myStats.AddShipComponent(PLShipComponent.CreateShipComponentFromHash((int)PLShipComponent.createHashFromInfo(9, Randomic.Thruster4(), 0, 0, 12), null), 16, ESlotType.E_COMP_THRUSTER);
                    }
                    if (shiptype == EShipType.E_ROLAND || shiptype == EShipType.E_STARGAZER)
                    {
                        myStats.AddShipComponent(PLShipComponent.CreateShipComponentFromHash((int)PLShipComponent.createHashFromInfo(25, Randomic.Inertia(), 0, 0, 12), null), 22, ESlotType.E_COMP_INERTIA_THRUSTER);
                        myStats.AddShipComponent(PLShipComponent.CreateShipComponentFromHash((int)PLShipComponent.createHashFromInfo(25, Randomic.Inertia2(), 0, 0, 12), null), 28, ESlotType.E_COMP_INERTIA_THRUSTER);
                    }
                    else if (shiptype == EShipType.E_DEATHSEEKER_DRONE || shiptype == EShipType.E_DEATHSEEKER_DRONE_SC)
                    {
                        myStats.AddShipComponent(PLShipComponent.CreateShipComponentFromHash((int)PLShipComponent.createHashFromInfo(25, Randomic.Inertia(), 0, 0, 12), null), 22, ESlotType.E_COMP_INERTIA_THRUSTER);
                        myStats.AddShipComponent(PLShipComponent.CreateShipComponentFromHash((int)PLShipComponent.createHashFromInfo(25, Randomic.Inertia2(), 0, 0, 12), null), 28, ESlotType.E_COMP_INERTIA_THRUSTER);
                        myStats.AddShipComponent(PLShipComponent.CreateShipComponentFromHash((int)PLShipComponent.createHashFromInfo(25, Randomic.Inertia(), 0, 0, 12), null), 22, ESlotType.E_COMP_INERTIA_THRUSTER);
                        myStats.AddShipComponent(PLShipComponent.CreateShipComponentFromHash((int)PLShipComponent.createHashFromInfo(25, Randomic.Inertia2(), 0, 0, 12), null), 28, ESlotType.E_COMP_INERTIA_THRUSTER);
                        myStats.AddShipComponent(PLShipComponent.CreateShipComponentFromHash((int)PLShipComponent.createHashFromInfo(25, Randomic.Inertia(), 0, 0, 12), null), 22, ESlotType.E_COMP_INERTIA_THRUSTER);
                        myStats.AddShipComponent(PLShipComponent.CreateShipComponentFromHash((int)PLShipComponent.createHashFromInfo(25, Randomic.Inertia2(), 0, 0, 12), null), 28, ESlotType.E_COMP_INERTIA_THRUSTER);
                        myStats.AddShipComponent(PLShipComponent.CreateShipComponentFromHash((int)PLShipComponent.createHashFromInfo(25, Randomic.Inertia(), 0, 0, 12), null), 22, ESlotType.E_COMP_INERTIA_THRUSTER);
                        myStats.AddShipComponent(PLShipComponent.CreateShipComponentFromHash((int)PLShipComponent.createHashFromInfo(25, Randomic.Inertia2(), 0, 0, 12), null), 28, ESlotType.E_COMP_INERTIA_THRUSTER);
                    }
                    else
                    {
                        myStats.AddShipComponent(PLShipComponent.CreateShipComponentFromHash((int)PLShipComponent.createHashFromInfo(25, Randomic.Inertia(), 0, 0, 12), null), 22, ESlotType.E_COMP_INERTIA_THRUSTER);
                    }
                    if (shiptype == EShipType.E_INTREPID || shiptype == EShipType.E_ROLAND || shiptype == EShipType.E_OUTRIDER || shiptype == EShipType.E_FLUFFY_DELIVERY)
                    {
                        myStats.AddShipComponent(PLShipComponent.CreateShipComponentFromHash((int)PLShipComponent.createHashFromInfo(20, Randomic.Missile(), 0, 0, 12), null), 25, ESlotType.E_COMP_TRACKERMISSILE);
                        myStats.AddShipComponent(PLShipComponent.CreateShipComponentFromHash((int)PLShipComponent.createHashFromInfo(20, Randomic.Missile2(), 0, 0, 12), null), 29, ESlotType.E_COMP_TRACKERMISSILE);
                    }
                    else if (shiptype == EShipType.E_ANNIHILATOR || shiptype == EShipType.E_WDCRUISER || shiptype == EShipType.E_DESTROYER)
                    {
                        myStats.AddShipComponent(PLShipComponent.CreateShipComponentFromHash((int)PLShipComponent.createHashFromInfo(20, Randomic.Missile(), 0, 0, 12), null), 25, ESlotType.E_COMP_TRACKERMISSILE);
                        myStats.AddShipComponent(PLShipComponent.CreateShipComponentFromHash((int)PLShipComponent.createHashFromInfo(20, Randomic.Missile2(), 0, 0, 12), null), 29, ESlotType.E_COMP_TRACKERMISSILE);
                        myStats.AddShipComponent(PLShipComponent.CreateShipComponentFromHash((int)PLShipComponent.createHashFromInfo(20, Randomic.Missile3(), 0, 0, 12), null), 30, ESlotType.E_COMP_TRACKERMISSILE);
                    }
                    else
                    {
                        myStats.AddShipComponent(PLShipComponent.CreateShipComponentFromHash((int)PLShipComponent.createHashFromInfo(20, Randomic.Missile(), 0, 0, 12), null), 25, ESlotType.E_COMP_TRACKERMISSILE);
                    }
                    myStats.AddShipComponent(PLShipComponent.CreateShipComponentFromHash((int)PLShipComponent.createHashFromInfo(8, Randomic.O2(), 0, 0, 12), null), 31, ESlotType.E_COMP_O2);
                    myStats.AddShipComponent(PLShipComponent.CreateShipComponentFromHash((int)PLShipComponent.createHashFromInfo(26, Randomic.Maneuver(), 0, 0, 12), null), 24, ESlotType.E_COMP_MANEUVER_THRUSTER);
                    myStats.AddShipComponent(PLShipComponent.CreateShipComponentFromHash((int)PLShipComponent.createHashFromInfo(11, Randomic.MainTurret(), 0, 0, 12), null), 23, ESlotType.E_COMP_MAINTURRET);
                    myStats.AddShipComponent(PLShipComponent.CreateShipComponentFromHash((int)PLShipComponent.createHashFromInfo(27, Randomic.Chair(), 0, 0, 12), null), 20, ESlotType.E_COMP_CAPTAINS_CHAIR);
                    myStats.AddShipComponent(PLShipComponent.CreateShipComponentFromHash((int)PLShipComponent.createHashFromInfo(6, Randomic.Hull(), 0, 0, 12), null), 11, ESlotType.E_COMP_HULL);
                    myStats.AddShipComponent(PLShipComponent.CreateShipComponentFromHash((int)PLShipComponent.createHashFromInfo(3, Randomic.Reactor(), 0, 0, 12), null), 13, ESlotType.E_COMP_REACTOR);
                    myStats.AddShipComponent(PLShipComponent.CreateShipComponentFromHash((int)PLShipComponent.createHashFromInfo(2, Randomic.Jump(), 0, 0, 12), null), 12, ESlotType.E_COMP_WARP);


                }
            }
        }

    }
}
