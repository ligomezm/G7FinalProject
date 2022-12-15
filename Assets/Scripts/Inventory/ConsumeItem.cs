using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConsumeItem : MonoBehaviour
{
    public Inventory Inventory;
    public int itemToUse;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            itemToUse = 0;
            onItemConsumed();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
            itemToUse = 1;
        if (Input.GetKeyDown(KeyCode.Alpha3))
            itemToUse = 2;
        if (Input.GetKeyDown(KeyCode.Alpha4))
            itemToUse = 3;


    }

    
    private void onItemConsumed()
    {
        if (Inventory.mItems != null)
        {

            GameObject inventoryPanel = GameObject.FindGameObjectWithTag("Inventory");
            //IInventoryItem item = inventoryPanel.GetChild(itemToUse).GetChild(0).GetComponent<IInventoryItem>();
            //Debug.Log("itemToUse " + inventoryPanel.transform.GetChild(itemToUse).gameObject.name);
            //Debug.Log("child0 " + inventoryPanel.transform.GetChild(itemToUse).GetChild(0).gameObject.name);
            IInventoryItem item = inventoryPanel.transform.GetChild(itemToUse).GetChild(0).GetComponent<IInventoryItem>();
            //Debug.Log(item);
            if (item != null)
            {
                Inventory.RemoveItem(item);
            }
        }
    }
}

    