using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private const int SLOTS = 4;
    public List<IInventoryItem> mItems = new List<IInventoryItem>();
    
    public event EventHandler<InventoryEventArgs> ItemAdded;
    public event EventHandler<InventoryEventArgs> ItemRemoved;

    public void AddItem(IInventoryItem item)
    {
        if (mItems.Count < SLOTS)
        {
            Collider collider = (item as MonoBehaviour).GetComponent<Collider>();

            if (collider.enabled)
            {
                collider.enabled = false;
                mItems.Add(item);
                item.OnPickUp();

                if (ItemAdded != null)
                {
                    ItemAdded(this, new InventoryEventArgs(item));
                }
            }
        }
    }

    public void RemoveItem(IInventoryItem item)
    {
        mItems.ForEach(delegate(IInventoryItem x) { Debug.Log("Item lista " + x); });
        Debug.Log("item parametro" + item);
        if (mItems.Contains(item))
        {
            if (ItemRemoved != null)
            {
                ItemRemoved(this, new InventoryEventArgs(item));
                mItems.Remove(item);
                item.OnConsume();
            }
            
            
        }
    }

}
