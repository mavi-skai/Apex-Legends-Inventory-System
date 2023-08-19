using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Item",menuName ="Inventory/Gear")]
public class Gear : Items
{
    
    public enum GearType { Helmet,BodyShield,KnockdownShield, Backpack }
    public GearType geartype;

    public float bodyshield;
    public float reduceheadshot;
    public int knockdownshield;
    public int BagSpace;

}
