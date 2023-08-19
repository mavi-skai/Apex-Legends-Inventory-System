using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public Image PlayerUI;
    public Image InventoryUI;
    public GameObject[] ground;
    public GameObject[] UnlockbackpackUI;
    public GameObject[] lockbackpackUI;

    public static UIManager instance;
    // Start is called before the first frame update
    private void Awake()
    {
        if(instance!=null)
        {
            return;
        }
        instance = this;

        
    }

    private void Start()
    {
        Inventory.instance.ItemChangeCallback += BagSpaceUI;
    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            PlayerUI.gameObject.SetActive(!PlayerUI.gameObject.activeSelf);
            InventoryUI.gameObject.SetActive(!InventoryUI.gameObject.activeSelf);

          // Debug.Log(InventoryUI.gameObject.GetComponent<UiInventory>().slots.Length);
        }

        if (Input.GetKeyDown(KeyCode.Escape)&&InventoryUI.gameObject.activeSelf)
        {
            PlayerUI.gameObject.SetActive(!PlayerUI.gameObject.activeSelf);
            InventoryUI.gameObject.SetActive(!InventoryUI.gameObject.activeSelf);
           // Debug.Log(InventoryUI.gameObject.GetComponent<UiInventory>().slots.Length);
        }

        //if(ground[0].activeSelf==true)
        //HideGroundUI();
    }

    public void ShowGroundUI()
    {
        //Showing Grounde UI 
        for (int i = 0; i < ground.Length; i++)
        {
            ground[i].SetActive(true);
        }
    }

    public void HideGroundUI()
    {
        //Hiding Ground UI
        for (int i = 0; i < ground.Length; i++)
        {
            ground[i].SetActive(false);
        }
    }

    public void BagSpaceUI()
    {
        //showing UI
        if(GearManager.instance.gear[3]!=null)
        {
            int bagspace = GearManager.instance.gear[3].BagSpace;
            for (int i = 0; i < bagspace; i++)
            {
                UnlockbackpackUI[i].SetActive(true);
            }

            for (int i = 0; i < bagspace; i++)
            {
                lockbackpackUI[i].SetActive(false);
            }
        }
        else
        {
            //showing UI
            for (int i = 0; i < UnlockbackpackUI.Length; i++)
            {
                UnlockbackpackUI[i].SetActive(false);
            }
            for (int i = 0; i < lockbackpackUI.Length; i++)
            {
                lockbackpackUI[i].SetActive(true);
            }
        }
        
    }

    
}
