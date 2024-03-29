﻿using System.Collections.Generic;

namespace Randomizer
{
    class Random
    {
        static public void random(PLShipInfoBase ship, bool previewStats, bool Iscomand = false)
        {
            if (((PhotonNetwork.isMasterClient && ship.ShouldCreateDefaultComponents || (previewStats && ship.ShouldCreateDefaultComponents)) && PLServer.Instance != null) || Iscomand )
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
                int CPULv = 0;
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
                int Polytech = 0;
                int seed = ship.ShipID * (PLServer.GetCurrentSector().ID + 3) + (((int)PLServer.Instance.ChaosLevel * PLServer.Instance.GalaxySeed)+5);
                List<PLShipComponent> AllShipComponents = myStats.AllComponents;
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
                    else if (AllShipComponents[i].SlotType == ESlotType.E_COMP_HULL && (shiptype != EShipType.E_GUARDIAN && shiptype != EShipType.E_DEATHSEEKER_DRONE_SC && shiptype != EShipType.E_CORRUPTED_DRONE && shiptype != EShipType.E_SWARM_CMDR))
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
                    else if ((AllShipComponents[i].SlotType == ESlotType.E_COMP_CARGO || AllShipComponents[i].SlotType == ESlotType.E_COMP_HIDDENCARGO) && AllShipComponents[i].ActualSlotType != ESlotType.E_COMP_MISSION_COMPONENT)
                    {
                        myStats.RemoveShipComponent(AllShipComponents[i]);
                    }
                    else if (AllShipComponents[i].SlotType == ESlotType.E_COMP_CPU)
                    {
                        CPULv = AllShipComponents[i].Level;
                        myStats.RemoveShipComponent(AllShipComponents[i]);
                        CPU++;
                    }
                    else if (AllShipComponents[i].SlotType == ESlotType.E_COMP_PROGRAM)
                    {
                        myStats.RemoveShipComponent(AllShipComponents[i]);
                        Program++;
                    }
                    else if (AllShipComponents[i].SlotType == ESlotType.E_COMP_POLYTECH_MODULE)
                    {
                        myStats.RemoveShipComponent(AllShipComponents[i]);
                        Polytech++;
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
                        CPULv = 0;
                    }
                }
                    if(shiptype != EShipType.E_POLYTECH_SHIP)
                    {
                        myStats.AddShipComponent(PLShipComponent.CreateShipComponentFromHash((int)PLShipComponent.createHashFromInfo(8, Randomic.O2(seed), 0, 0, 12), null), -1, ESlotType.E_COMP_O2);
                    }                  
                    for (int i = 0; i < Hull; i++)
                    {
                        if(Configs.level) 
                        {
                        HullLv = Randomic.Level(i + seed);
                        }
                        myStats.AddShipComponent(PLShipComponent.CreateShipComponentFromHash((int)PLShipComponent.createHashFromInfo(6, Randomic.Hull(seed), HullLv, 0, 12), null), -1, ESlotType.E_COMP_HULL);
                    }
                    for (int i = 0; i < Shld; i++)
                    {
                        if (Configs.level)
                        {
                            ShildLv = Randomic.Level(i + seed);
                        }
                        myStats.AddShipComponent(PLShipComponent.CreateShipComponentFromHash((int)PLShipComponent.createHashFromInfo(1, Randomic.Shield(seed), ShildLv, 0, 12), null), -1, ESlotType.E_COMP_SHLD);
                    }
                    for (int i = 0; i < Salvage; i++)
                    {
                        myStats.AddShipComponent(PLShipComponent.CreateShipComponentFromHash((int)PLShipComponent.createHashFromInfo(28, Randomic.Extractor(seed), 0, 0, 12), null), -1, ESlotType.E_COMP_SALVAGE_SYSTEM);
                    }
                    for (int i = 0; i < Cloak; i++)
                    {
                        myStats.AddShipComponent(PLShipComponent.CreateShipComponentFromHash((int)PLShipComponent.createHashFromInfo(33, Randomic.Cloak(seed), 0, 0, 12), null), -1, ESlotType.E_COMP_CLOAKING_SYS);
                    }
                    for (int i = 0; i < Turret; i++)
                    {
                        if (Configs.level)
                        {
                            TurretLv = Randomic.Level(i + seed);
                        }
                        myStats.AddShipComponent(PLShipComponent.CreateShipComponentFromHash((int)PLShipComponent.createHashFromInfo(10, Randomic.Turret((i + 1) * seed), TurretLv, 0, 12), null), -1, ESlotType.E_COMP_TURRET);
                    }
                    for (int i = 0; i < Thrust; i++)
                    {
                    if (Configs.level)
                    {
                        ThrustLv = Randomic.Level(i + seed);
                    }
                    myStats.AddShipComponent(PLShipComponent.CreateShipComponentFromHash((int)PLShipComponent.createHashFromInfo(9, Randomic.Thruster((i + 5) * seed), ThrustLv, 0, 12), null), -1, ESlotType.E_COMP_THRUSTER);
                    }
                    for (int i = 0; i < Inertias; i++)
                    {
                    if (Configs.level)
                    {
                        InertiaLv = Randomic.Level(i + seed);
                    }
                    myStats.AddShipComponent(PLShipComponent.CreateShipComponentFromHash((int)PLShipComponent.createHashFromInfo(25, Randomic.Inertia((i + 9) * seed), InertiaLv, 0, 12), null), -1, ESlotType.E_COMP_INERTIA_THRUSTER);
                    }
                    for (int i = 0; i < Missel; i++)
                    {
                    if (Configs.level)
                    {
                        MisselLv = Randomic.Level(i + seed);
                    }
                    myStats.AddShipComponent(PLShipComponent.CreateShipComponentFromHash((int)PLShipComponent.createHashFromInfo(20, Randomic.Missile((i + 74) * seed), MisselLv, 0, 12), null), -1, ESlotType.E_COMP_TRACKERMISSILE);
                    }
                    myStats.AddShipComponent(PLShipComponent.CreateShipComponentFromHash((int)PLShipComponent.createHashFromInfo(7, 0, 0, 0, 12), null), -1, ESlotType.E_COMP_CPU);
                    for (int i = 0; i < CPU - 1; i++)
                    {
                    if (Configs.level)
                    {
                        CPULv = Randomic.Level(i + seed);
                    }
                    //myStats.AddShipComponent(new PLCPU((ECPUClass)Randomic.Processor((i + 4) * seed), CPULv), -1, ESlotType.E_COMP_CPU);
                    myStats.AddShipComponent(PLShipComponent.CreateShipComponentFromHash((int)PLShipComponent.createHashFromInfo(7, Randomic.Processor((i + 4) * seed), CPULv, 0, 12), null), -1, ESlotType.E_COMP_CPU);
                    }
                    for (int i = 0; i < Program; i++)
                    {
                        myStats.AddShipComponent(PLShipComponent.CreateShipComponentFromHash((int)PLShipComponent.createHashFromInfo(17, Randomic.Program((i + 69) * seed), 0, 0, 12), null), -1, ESlotType.E_COMP_PROGRAM);
                    }
                    for (int i = 0; i < Manuv; i++)
                    {
                    if (Configs.level)
                    {
                        ManuvLv = Randomic.Level(i + seed);
                    }
                    myStats.AddShipComponent(PLShipComponent.CreateShipComponentFromHash((int)PLShipComponent.createHashFromInfo(26, Randomic.Maneuver((i + 420) * seed), ManuvLv, 0, 12), null), -1, ESlotType.E_COMP_MANEUVER_THRUSTER);
                    }
                    for (int i = 0; i < MainT; i++)
                    {
                    if (Configs.level)
                    {
                        MainTLv = Randomic.Level(i + seed);
                    }
                    myStats.AddShipComponent(PLShipComponent.CreateShipComponentFromHash((int)PLShipComponent.createHashFromInfo(11, Randomic.MainTurret(seed), MainTLv, 0, 12), null), -1, ESlotType.E_COMP_MAINTURRET);
                    }
                    for (int i = 0; i < Chair; i++)
                    {
                        myStats.AddShipComponent(PLShipComponent.CreateShipComponentFromHash((int)PLShipComponent.createHashFromInfo(27, Randomic.Chair(seed), 0, 0, 12), null), -1, ESlotType.E_COMP_CAPTAINS_CHAIR);
                    }
                    for (int i = 0; i < reactor; i++)
                    {
                    if (Configs.level)
                    {
                        ReactorLv = Randomic.Level(i + seed);
                    }
                    myStats.AddShipComponent(PLShipComponent.CreateShipComponentFromHash((int)PLShipComponent.createHashFromInfo(3, Randomic.Reactor(seed), ReactorLv, 0, 12), null), -1, ESlotType.E_COMP_REACTOR);
                    }
                    for (int i = 0; i < warp; i++)
                    {
                    if (Configs.level)
                    {
                        WarpLv = Randomic.Level(i + seed);
                    }
                    myStats.AddShipComponent(PLShipComponent.CreateShipComponentFromHash((int)PLShipComponent.createHashFromInfo(2, Randomic.Jump(seed), WarpLv, 0, 12), null), -1, ESlotType.E_COMP_WARP);
                    }
                    for (int i = 0; i < Polytech; i++)
                    {
                        myStats.AddShipComponent(PLShipComponent.CreateShipComponentFromHash((int)PLShipComponent.createHashFromInfo(34, Randomic.Polytech((i + 50) * seed), 0, 0, 12), null), -1, ESlotType.E_COMP_CARGO);
                    }
            }
        }
        static public void randomlevel(PLShipInfoBase ship) 
        {
            foreach(PLShipComponent component in ship.MyStats.AllComponents)
            {
                component.Level = Randomic.Level(component.GetHashCode(), component.ActualSlotType);                
            }
            PLServer.Instance.ServerRepairHull(ship.ShipID, 500000, 0);

        }

        static public void randomship(PLPersistantShipInfo ship) 
        {
            if (Configs.randomship && ship != null &&(ship.CompOverrides == null || ship.CompOverrides.Count == 0) && ship.ShipName == "")
            {
                ship.Type = Randomic.Type(ship.GetHashCode() * PLServer.Instance.GalaxySeed);
            }
        }

        static public void setlock(PLShipInfoBase ship,bool locks) 
        {
            PLShipStats myStats = ship.MyStats;
            foreach(PLSlotItem slot in myStats.AllSlotItems) 
            { 
                if(slot.ActualSlotType != ESlotType.E_COMP_CARGO && slot.ActualSlotType != ESlotType.E_COMP_HIDDENCARGO) 
                {
                    myStats.SetSlot_IsLocked(slot.ActualSlotType, locks);
                }
            }
            if (ship.ShipTypeID == EShipType.OLDWARS_HUMAN || ship.ShipTypeID == EShipType.E_POLYTECH_SHIP) 
            {
                myStats.SetSlot_IsLocked(ESlotType.E_COMP_HULL, true);
            }
            if(ship.ShipTypeID == EShipType.OLDWARS_SYLVASSI || ship.ShipTypeID == EShipType.E_POLYTECH_SHIP) 
            { 
                myStats.SetSlot_IsLocked(ESlotType.E_COMP_SHLD, true);
                myStats.SetSlot_IsLocked(ESlotType.E_COMP_CLOAKING_SYS, true);
            }
        }
    }
}
