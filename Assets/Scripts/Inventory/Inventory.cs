using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private const int SLOTS = 4;
    public List<IInventoryItem> mItems = new List<IInventoryItem>();
    public static Dictionary<int, IInventoryItem> itemsDict = new Dictionary<int, IInventoryItem>(); //
    
    public event EventHandler<InventoryEventArgs> ItemAdded;
    public event EventHandler<InventoryEventArgs> ItemRemoved;
    public static event Action<int> OnItemRemoved;

    public void AddItem(IInventoryItem item)
    {
        if (mItems.Count < SLOTS)
        {
            Collider collider = (item as MonoBehaviour).GetComponent<Collider>();

            if (collider.enabled)
            {
                
                collider.enabled = false;
                mItems.Add(item);
                itemsDict[mItems.IndexOf(item)] = item;
                item.OnPickUp();

                if (ItemAdded != null)
                {
                    ItemAdded(this, new InventoryEventArgs(item));
                }
            }
        }
    }

    public void RemoveItem(IInventoryItem item, int itemPosition)
    {
        if (!itemsDict.ContainsKey(itemPosition)) return;
        if (mItems.Contains(itemsDict[itemPosition]))
        {
            if (ItemRemoved != null)
            {
                Debug.Log(itemsDict[itemPosition]);
                OnItemRemoved?.Invoke(itemPosition);
                ItemRemoved(this, new InventoryEventArgs(itemsDict[itemPosition]));
                mItems.Remove(itemsDict[itemPosition]);
                item.OnConsume();
            }
            
            
        }
    }

}
