using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class CollectItem : MonoBehaviour
{
    public Inventory inventory;
    public static Action<IInventoryItem> OnitemPickup;
    void Start()
    {
        //Debug.Log("This is happening");
        
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (inventory == null)
            TryGetInventory();
        IInventoryItem item = hit.collider.GetComponent<IInventoryItem>();
        if (item != null)
        {
            Debug.Log("item added");
            OnitemPickup?.Invoke(item);
            inventory.AddItem(item);
        }
    }


    void TryGetInventory()
    {
        try
        {
            inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
        }
        catch (System.Exception)
        {
            
            return;
        }
    }
}
