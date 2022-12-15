using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class InventoryCanvas : MonoBehaviour
{
    public Inventory Inventory;
    public int itemToUse;

    void OnEnable()
    {
        
    }
    void OnDisable()
    {
        Inventory.OnItemRemoved -= Inventory_RemoveImage;
        
    }
    private void Start()
    {
        Inventory.OnItemRemoved += Inventory_RemoveImage;
        Inventory.ItemAdded += InventoryScript_ItemAdded;
        Inventory.ItemRemoved += Inventory_ItemRemoved;
    }

    private void InventoryScript_ItemAdded(object sender, InventoryEventArgs e)
    {
        Transform inventoryPanel = transform.Find("Inventory Panel");
        int i = 0;
        foreach (Transform slot in inventoryPanel)
        {
            //Border image

            Image image = slot.GetChild(0).GetChild(0).GetComponent<Image>();

            //Find the empty slot
            if (!image.enabled)
            {
                image.enabled = true;
                image.sprite = e.Item.Image;
                break;
            }
            i++;
        }
    }

    private void Inventory_ItemRemoved(object sender, InventoryEventArgs e)
    {
       return;
      
    }

    private void Inventory_RemoveImage(int position)
    {
        Transform inventoryPanel = transform.Find("Inventory Panel");
        Transform slot = inventoryPanel.GetChild(position);
        Transform imageTransform = slot.GetChild(itemToUse).GetChild(0);
        Image image = imageTransform.GetComponent<Image>();

        image.enabled = false;
        image.sprite = null;
    }
}
