using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Items : ScriptableObject
{
    public new string name = "New Item";
    public bool Stackable;
    public Sprite[] sprite;
    public enum Grade { Legendary, Epic, Rare,Rare1, Common,Common1 }
    public Grade grade;
    public enum ItemType { Gear,Consumables}
    public ItemType itemtype;
    

    public virtual void Use()
    {
        Debug.Log("Using " + name);
    }

   
    public bool isStackable()
    {
        return Stackable;
    }


    public Sprite Sprite(int currentamount)
    {
        switch (currentamount)
        {
            default:
            case 0: return sprite[currentamount-1];
            case 1: return sprite[currentamount - 1];
            case 2: return sprite[currentamount - 1];
            case 3: return sprite[currentamount - 1];
        }
    }
    

    
}
