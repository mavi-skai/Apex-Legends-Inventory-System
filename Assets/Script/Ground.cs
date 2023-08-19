using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Ground : MonoBehaviour , IDropHandler
{
    public void OnDrop(PointerEventData eventData) {
       // Debug.Log("OnDrop");
        if (eventData.pointerDrag != null) 
        {
            eventData.pointerDrag.GetComponent<InventorySlot>().DropAll();
        }
    }
}
