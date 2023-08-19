using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class ItemAsset : MonoBehaviour
{

    [SerializeField]
    GameObject[] PrefabConsumables;
    //[SerializeField]
    //Consumables[] ConsumablesTemplate;

    public static ItemAsset instance;


    private void Awake()
    {
        if (instance != null)
            return;

        instance = this;
        

    }

    public GameObject GetConsumablesPrefab(ItemData item)
    {
        switch (item.consumables.typeofconsumables)
        {

            case Consumables.TypeOfConsumables.PhoenixKit: return PrefabConsumables[0];
            case Consumables.TypeOfConsumables.ShieldBattery: return PrefabConsumables[1];
            case Consumables.TypeOfConsumables.Medkit: return PrefabConsumables[2];
            case Consumables.TypeOfConsumables.ShieldCell: return PrefabConsumables[3];
            case Consumables.TypeOfConsumables.Syringe: return PrefabConsumables[4];
            default:
                return null;

        }
    }


    //public Consumables GetConsumableTemplate(Consumables item)
    //{
    //    switch (item.typeofconsumables)
    //    {

    //        case Consumables.TypeOfConsumables.PhoenixKit: return ConsumablesTemplate[0];
    //        case Consumables.TypeOfConsumables.ShieldBattery: return ConsumablesTemplate[1];
    //        case Consumables.TypeOfConsumables.Medkit: return ConsumablesTemplate[2];
    //        case Consumables.TypeOfConsumables.ShieldCell: return ConsumablesTemplate[3];
    //        case Consumables.TypeOfConsumables.Syringe: return ConsumablesTemplate[4];
    //        default:
    //            return null;

    //    }

    //}
}
