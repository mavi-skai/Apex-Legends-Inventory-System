using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearManager : MonoBehaviour
{
    public static GearManager instance;

    private void Awake()
    {
        if (instance != null)
            return;

        instance=this;
    }

    public Gear[] gear;
    // Start is called before the first frame update
    void Start()
    {
        gear = new Gear[4];
    }

    

    public bool AddGear(Gear Gear)
    {
        
        //getting gear number
        int geartype = (int)Gear.geartype;
        Debug.Log(geartype);
        if(gear[geartype]!=null)
        {
            //checking grade of old gear
            int oldgeargrade = (int)gear[geartype].grade;
            //Debug.Log("old gear Grade: " + (int)gear[geartype].grade);
            //checking grade of new gear
            int newgeargrade = (int)Gear.grade;
            //check if newgear grade is much higher
            if (oldgeargrade > newgeargrade)
            {
                //Dropping old gear
                //Gear gear = gear[geartype];
                gear[geartype] = Gear;
                Inventory.instance.ItemChangeCallback.Invoke();
                //Inventory.instance.inventorySpaceCallback.Invoke();
                return true;
            }
            else
            {
                Inventory.instance.ItemChangeCallback.Invoke();
                return false;
            }

        }
        else
        {
            gear[geartype] = Gear;
            Inventory.instance.ItemChangeCallback.Invoke();
            //Inventory.instance.inventorySpaceCallback.Invoke();
            return true;
        }
      
    }
}
