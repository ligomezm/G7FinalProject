using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private const int SLOTS = 4;
    public List<IInventoryItem> mItems = new List<IInventoryItem>();
    public static Dictionary<int, IInventoryItem> itemsDict = new Dictionary<int, IInventoryItem>(); 
    
    public event EventHandler<InventoryEventArgs> ItemAdded;
    public event EventHandler<InventoryEventArgs> ItemRemoved;
    public static event Action<int> OnItemRemoved;

    int itemKey;

    FeedbackCanvas feedbackCanvas;

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
        else
        {
            if (feedbackCanvas == null)
                TryGetFeedbackCanvas();

            feedbackCanvas.ShowCanvasInventoryFull();

            // Show canvas "Inventory full"
        }
    }

    public void RemoveItem(IInventoryItem item, int itemPosition)
    {
        if (!itemsDict.ContainsKey(itemPosition)) return;

        if (mItems.Contains(itemsDict[itemPosition]))
        {
            if (ItemRemoved != null)
            {
                OnItemRemoved?.Invoke(itemPosition);
                ItemRemoved(this, new InventoryEventArgs(itemsDict[itemPosition]));
                //itemsDict.Remove(itemPosition);
                mItems.Remove(itemsDict[itemPosition]);
                item.OnConsume();
            }
            
        }
    }

    public bool ItemInInventory(IInventoryItem item)
    {
        return itemsDict.ContainsValue(item) ? true : false;
    }

    public int GetKeyFromValue(IInventoryItem item)
    {
        foreach (var itemD in itemsDict)
        {
            if (itemD.Value == item)
            {
                itemKey =  itemD.Key;
            }
        }
        return itemKey;
    }

    void TryGetFeedbackCanvas()
    {
        try
        {
            feedbackCanvas = GameObject.FindGameObjectWithTag("FeedbackCanvas").GetComponent<FeedbackCanvas>();
        }
        catch (System.Exception)
        {
            return;
        }
    }
}
