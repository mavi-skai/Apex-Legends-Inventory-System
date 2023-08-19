using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory instance;
    public delegate void ItemChange();
    public ItemChange ItemChangeCallback;
    public delegate void InventorySpaceChange();
    public InventorySpaceChange inventorySpaceCallback;
    public int InventorySpace = 10;
    int DefaultInventorySpace;
    public List<ItemData> items = new List<ItemData>();
    List<ItemData> dropitemlist = new List<ItemData>();
    public ItemData dropall;
    

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance found");
            return;
        }
       
        instance = this;
        ItemChangeCallback += GradeSort;
        ItemChangeCallback += UpdateInventorySpace;
        DefaultInventorySpace = InventorySpace;
    }
    #endregion

    

    public bool Add(ItemData item)
    {
        //add stackable item
        if(item.consumables.isStackable())
        {
            bool itemAlreadyInInventory = false;
            //checking if item is inventory
            foreach (ItemData inventoryItem in items)
            {
                //checking if items is equal and if less than maxamount
                if(inventoryItem.consumables.typeofconsumables==item.consumables.typeofconsumables&&
                    inventoryItem.amount<item.consumables.Maxamount)
                {
                    //increanse amount
                 //  Debug.Log("Increase amount");
                    inventoryItem.amount += item.amount;
                    itemAlreadyInInventory = true;
                    //GradeSort();
                    //refreshing inventory
                    if (ItemChangeCallback != null)
                        ItemChangeCallback.Invoke();
                    //inventorySpaceCallback.Invoke();
                    //return true for destroy
                    return true;
                } 
            }
                //stackable item  not in inventory
            if (itemAlreadyInInventory==false)
            {
                //check if inventory is full
                if (items.Count >= InventorySpace)
                {
                    //inventory is full
                   // Debug.Log("Not Enough Space");
                    return false;
                }
                //add inventory
               // Debug.Log("Not In inventory");
                items.Add(item);
                //GradeSort();
                //refresh inventory
                if (ItemChangeCallback != null)
                    ItemChangeCallback.Invoke();
                //inventorySpaceCallback.Invoke();
                return true;
            }
        }
        else
        {
            //not stackable item not in inventory
            if (items.Count >= InventorySpace)
            {
                //inventory full
               // Debug.Log("Not Enough Space");
                return false;
            }
            //add not stackable item
           // Debug.Log("Not Stackable Inventory added");
            items.Add(item);
            //GradeSort();
            //Refresh inventory
            if (ItemChangeCallback != null)
                ItemChangeCallback.Invoke();
            //inventorySpaceCallback.Invoke();
            //return true to destroy item
            return true;
        }


        //items.Add(item);
        //GradeSort();
        //if (ItemChangeCallback != null)
        //    ItemChangeCallback.Invoke();
        //Debug.Log("Not Added");
        return false;
    }

    public void DropItem(ItemData item)
    {

        //finding in list what item you dropping
        dropitemlist = items.FindAll(e => e.consumables.typeofconsumables == item.consumables.typeofconsumables);
        //removing all similar items
        items.RemoveAll(x => x.consumables.typeofconsumables == item.consumables.typeofconsumables);
        //get lastindex to reduce or drop all item
        int lastindex = dropitemlist.Count;
        if(dropitemlist[lastindex-1]!=null)
        {
            //reduce one item
            dropitemlist[lastindex-1].amount--;
            //creating item drop
            Instantiate(ItemAsset.instance.GetConsumablesPrefab(dropitemlist[lastindex - 1]),
                PlayerManager.instance.GetPlayerTransform(),
                Quaternion.identity);
            //removing item if amount is less than 0
            if (dropitemlist[lastindex-1].amount<=0)
            {
                dropitemlist.RemoveAt(lastindex-1);
            }

        }
        //add all item again
        items.AddRange(dropitemlist);
        //refresh  inventory
        ItemChangeCallback.Invoke();

    }

    public void DropAll(ItemData item)
    {
        
        dropall = item;
        //creatine item you drop
        GameObject instanceobject= Instantiate(ItemAsset.instance.GetConsumablesPrefab(dropall),
                PlayerManager.instance.GetPlayerTransform(),
                Quaternion.identity);
        instanceobject.GetComponentInChildren<ItemPickUp>().item.amount = dropall.amount;
        //remove all item in inventory
        items.Remove(item);
        //refresh inventory
        ItemChangeCallback.Invoke();

    }

    void GradeSort()
    {
        //Apex legends inventory
        //sorting item by grade
        items = items.OrderBy(e => e.consumables.grade).ToList();
    }


    void UpdateInventorySpace()
    {
        if (GearManager.instance.gear[3] != null)
        {
            //Debug.Log(GearManager.instance.gear[3].BagSpace);
           // Debug.Log(InventorySpace);
           //increasing inventory space when you got a backpack
            InventorySpace = DefaultInventorySpace +GearManager.instance.gear[3].BagSpace;
        }
        
        //Debug.Log(InventorySpace);
        
    }
}
