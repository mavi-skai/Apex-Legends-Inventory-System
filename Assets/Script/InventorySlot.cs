using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour  , IPointerDownHandler, IBeginDragHandler,IEndDragHandler,IDragHandler
{
    ItemData item;
   public Gear gear;
    public Image icon;
    #region DRAG ICON
    private RectTransform rectTransform;
    [SerializeField]
    private Canvas canvas;
    private CanvasGroup canvasGroup;
    #endregion

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    #region DRAG ICON
    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("OnDrag");
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        UIManager.instance.ShowGroundUI();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        //Debug.Log("OnBeginDrag");
        UIManager.instance.ShowGroundUI();
        canvasGroup.blocksRaycasts = false;

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //Debug.Log("OnEndDrag");
        UIManager.instance.HideGroundUI();
        rectTransform.transform.localPosition = new Vector3(0, 0, 0);
        canvasGroup.blocksRaycasts = true;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //Debug.Log("OnPointerDown");
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            DropItem();
        }
        else if (eventData.button == PointerEventData.InputButton.Middle)
        {
            return;
        }


    }
    #endregion

    //public void OnPointerClick(PointerEventData eventData)
    //{

    //}



    public void AddItem(ItemData newItem)
    {
        item = newItem;
        icon.enabled = true;
        icon.sprite = item.consumables.Sprite(item.amount);
    }

    public void AddGear(Gear newGear)
    {
        gear = newGear;
        icon.enabled = true;
        icon.sprite = gear.Sprite(1);
    }

    

    public void DropItem()
    {
       
        if(item!=null)
        {
            Inventory.instance.DropItem(item);
        }
    }

    public void DropAll()
    {
        if(item!=null)
        {
            Debug.Log("Dropping All");
            Inventory.instance.DropAll(item);
        }
    }

    public void ClearSlot()
    {

        item = null;
        icon.enabled = false;
        icon.sprite = null;
    }
}
