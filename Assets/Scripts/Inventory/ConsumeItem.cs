using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConsumeItem : MonoBehaviour
{
    public Inventory Inventory;
    int itemToUse;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            itemToUse = 0;
            onItemConsumed(itemToUse);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            itemToUse = 1;
            onItemConsumed(itemToUse);

        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            itemToUse = 2;
            onItemConsumed(itemToUse);

        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            itemToUse = 3;
            onItemConsumed(itemToUse);

        }


    }

    
    private void onItemConsumed(int itemToUse)
    {
        if (Inventory.mItems != null)
        {

            GameObject inventoryPanel = GameObject.FindGameObjectWithTag("Inventory");
            //IInventoryItem item = inventoryPanel.GetChild(itemToUse).GetChild(0).GetComponent<IInventoryItem>();
            //Debug.Log("itemToUse " + inventoryPanel.transform.GetChild(itemToUse).gameObject.name);
            //Debug.Log("child0 " + inventoryPanel.transform.GetChild(itemToUse).GetChild(0).gameObject.name);
            IInventoryItem item = inventoryPanel.transform.GetChild(itemToUse).GetChild(0).GetComponent<IInventoryItem>();
            if (item != null)
            {
                Inventory.RemoveItem(item, itemToUse);
            }
        }
    }
}

    