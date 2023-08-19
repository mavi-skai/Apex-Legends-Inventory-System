using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiInventory : MonoBehaviour
{
    public Transform InventoryParent;
    public InventorySlot[] slots;
    public Transform GearParent;
    InventorySlot[] gearslots;
    public static UiInventory instance;
    private void Awake()
    {
        if (instance != null)
            return;

        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        //get all inventory slot from parent
        slots = InventoryParent.GetComponentsInChildren<InventorySlot>();
        gearslots = GearParent.GetComponentsInChildren<InventorySlot>();
       
        Inventory.instance.ItemChangeCallback += UpdateUI;
        Inventory.instance.ItemChangeCallback += GearUpdateUI;
        //Inventory.instance.ItemChangeCallback += UpdateHowManySlots;
        //Inventory.instance.inventorySpaceCallback += UpdateHowManySlots;


    }

    

    private void Update()
    {
        slots = InventoryParent.GetComponentsInChildren<InventorySlot>();
       
    }
    public void UpdateHowManySlots()
    {
        slots = InventoryParent.GetComponentsInChildren<InventorySlot>();
        Debug.Log("How many Slots: " + slots.Length);
    }

   //Update is called once per frame
    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            //adding UI item
            if (i < Inventory.instance.items.Count)
            {
                slots[i].AddItem(Inventory.instance.items[i]);
            }
            else
            {
                //item empty
                slots[i].ClearSlot();
            }
        }
       

    }

    void GearUpdateUI()
    {
        for (int i = 0; i < gearslots.Length; i++)
        {
            //add gear UI
            if(GearManager.instance.gear[i]!=null)
            {
                gearslots[i].AddGear(GearManager.instance.gear[i]);
            }
            else
            {
                //clear gear UI
                gearslots[i].ClearSlot();
            }
        }
    }
}
