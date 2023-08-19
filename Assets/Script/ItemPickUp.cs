using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor.Experimental.TerrainAPI;
using UnityEngine;
using UnityEngine.UI;

public class ItemPickUp : MonoBehaviour
{
    [SerializeField]
    GameObject ItemUI;

    public ItemData item;
    public Gear gear;
   

    

    private void Update()
    {
        //deactivating UI
        if (this.ItemUI.activeSelf == true)
        {
            DeaactiveCanvas();
        }
        
    }

    public void PickUP()
    {
        
        bool wasPickUp = false;
        if (item.consumables != null)
        {
            //check if item was pickup
            wasPickUp = Inventory.instance.Add(item);
        }

        if(gear!=null)
        {
            //check if gear was pickup
            wasPickUp = GearManager.instance.AddGear(gear);
        }
        if (wasPickUp)
        {
            //if pickup destroy item
           // Debug.Log("Pick Up Item " + item.consumables.name);
          //  Debug.Log("detroying");
            Destroy(transform.parent.gameObject);
        }
           
    }

    public void ActivateCanvas()
    {
       //activate UI
        this.ItemUI.SetActive(true);
    }

    public void DeaactiveCanvas()
    {
        //deactivate UI
        ItemUI.SetActive(false);
    }

}
