using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectItem : MonoBehaviour
{
    public Inventory inventory;
    void Start()
    {
        Debug.Log("This is happening");
        
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (inventory == null)
            TryGetInventory();
        IInventoryItem item = hit.collider.GetComponent<IInventoryItem>();
        if (item != null)
        {
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
