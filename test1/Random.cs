using System.Collections.Generic;

namespace Randomizer
{
    class Random
    {
        static public void random(PLShipInfoBase ship, bool previewStats, bool Iscomand = false)
        {
            if (((PhotonNetwork.isMasterClient && ship.ShouldCreateDefaultComponents || (previewStats && ship.ShouldCreateDefaultComponents)) && PLServer.Instance != null) || Iscomand)
            {
                PLShipStats myStats = ship.MyStats;
                EShipType shiptype = myStats.Ship.ShipTypeID;
                Dictionary<ESlotType, List<int>> Components = new Dictionary<ESlotType, List<int>>();
                Dictionary<ESlotType, List<int>> Cargo = new Dictionary<ESlotType, List<int>>();
                int seed = ship.ShipID + (PLServer.GetCurrentSector().ID + 3) + (((int)PLServer.Instance.ChaosLevel + PLServer.Instance.GalaxySeed) + 5);
                List<PLShipComponent> AllShipComponents = myStats.AllComponents;
                for (int i = AllShipComponents.Count - 1; i > -1; i--) //get level of components that are equipped
                {
                    if (AllShipComponents[i].SlotType != ESlotType.E_COMP_CARGO && AllShipComponents[i].SlotType != ESlotType.E_COMP_HIDDENCARGO && (AllShipComponents[i].SlotType != ESlotType.E_COMP_HULL || (shiptype != EShipType.E_GUARDIAN && shiptype != EShipType.E_DEATHSEEKER_DRONE_SC && shiptype != EShipType.E_CORRUPTED_DRONE && shiptype != EShipType.E_SWARM_CMDR)))
                    {
                        if (!Components.ContainsKey(AllShipComponents[i].SlotType))
                        {
                            Components.Add(AllShipComponents[i].SlotType, new List<int> { AllShipComponents[i].Level });
                        }
                        else
                        {
                            Components[AllShipComponents[i].SlotType].Add(AllShipComponents[i].Level);
                        }
                        myStats.RemoveShipComponent(AllShipComponents[i]);
                    }
                }
                for (int i = AllShipComponents.Count - 1; i > -1; i--) //get level of components that are in cargo
                {
                    if (AllShipComponents[i].SlotType == ESlotType.E_COMP_CARGO || AllShipComponents[i].SlotType == ESlotType.E_COMP_HIDDENCARGO && AllShipComponents[i].ActualSlotType != ESlotType.E_COMP_MISSION_COMPONENT)
                    {
                        if (!Cargo.ContainsKey(AllShipComponents[i].ActualSlotType))
                        {
                            Cargo.Add(AllShipComponents[i].ActualSlotType, new List<int> { AllShipComponents[i].Level});
                        }
                        else
                        {
                            Cargo[AllShipComponents[i].ActualSlotType].Add(AllShipComponents[i].Level);
                        }
                        myStats.RemoveShipComponent(AllShipComponents[i]);
                    }

                }
                int cont = 0;
                if (Iscomand || Configs.level)
                {
                    foreach (ESlotType type in Components.Keys) 
                    {
                        List<int> levels = Components[type];
                        for (int i = 0; i < levels.Count; i++) 
                        {
                            if (Configs.level)
                            {
                                levels[i] = Randomic.Level(cont + seed,type);
                                cont++;
                            }
                            else 
                            {
                                levels[i] = 0;
                            }
                        }
                    }
                    foreach (ESlotType type in Cargo.Keys)
                    {
                        List<int> levels = Components[type];
                        for (int i = 0; i < levels.Count; i++)
                        {
                            if (Configs.level)
                            {
                                levels[i] = Randomic.Level(cont + seed,type);
                                cont++;
                            }
                            else
                            {
                                levels[i] = 0;
                            }
                        }
                    }
                }
                cont = 0;
                foreach (ESlotType type in Components.Keys)
                {
                    List<int> levels = Components[type];
                    for (int i = 0; i < levels.Count; i++)
                    {
                        myStats.AddShipComponent(PLShipComponent.CreateShipComponentFromHash((int)PLShipComponent.createHashFromInfo((int)type, Randomic.GeneralRandomComp((int)type,seed + cont + i * (int)type), levels[i], 0, 12), null), -1, type);
                    }
                }
                foreach (ESlotType type in Cargo.Keys)
                {
                    List<int> levels = Cargo[type];
                    for (int i = 0; i < levels.Count; i++)
                    {
                        myStats.AddShipComponent(PLShipComponent.CreateShipComponentFromHash((int)PLShipComponent.createHashFromInfo((int)type, Randomic.GeneralRandomComp((int)type, seed + cont + i * (int)type), levels[i], 0, 12), null), -1, (myStats.GetSlot(ESlotType.E_COMP_CARGO).MaxItems > i ? ESlotType.E_COMP_CARGO : ESlotType.E_COMP_HIDDENCARGO));
                    }
                }
            }
        }
        static public void randomlevel(PLShipInfoBase ship)
        {
            foreach (PLShipComponent component in ship.MyStats.AllComponents)
            {
                component.Level = Randomic.Level(component.GetHashCode(), component.ActualSlotType);
            }
            PLServer.Instance.ServerRepairHull(ship.ShipID, 500000, 0);

        }

        static public void randomship(PLPersistantShipInfo ship)
        {
            if (Configs.randomship && ship != null && (ship.CompOverrides == null || ship.CompOverrides.Count == 0) && ship.ShipName == "")
            {
                ship.Type = Randomic.Type(ship.GetHashCode() * PLServer.Instance.GalaxySeed);
            }
        }

        static public void setlock(PLShipInfoBase ship, bool locks)
        {
            PLShipStats myStats = ship.MyStats;
            foreach (PLSlotItem slot in myStats.AllSlotItems)
            {
                if (slot.ActualSlotType != ESlotType.E_COMP_CARGO && slot.ActualSlotType != ESlotType.E_COMP_HIDDENCARGO)
                {
                    myStats.SetSlot_IsLocked(slot.ActualSlotType, locks);
                }
            }
            if (ship.ShipTypeID == EShipType.OLDWARS_HUMAN || ship.ShipTypeID == EShipType.E_POLYTECH_SHIP)
            {
                myStats.SetSlot_IsLocked(ESlotType.E_COMP_HULL, true);
            }
            if (ship.ShipTypeID == EShipType.OLDWARS_SYLVASSI || ship.ShipTypeID == EShipType.E_POLYTECH_SHIP)
            {
                myStats.SetSlot_IsLocked(ESlotType.E_COMP_SHLD, true);
                myStats.SetSlot_IsLocked(ESlotType.E_COMP_CLOAKING_SYS, true);
            }
        }
    }
}
