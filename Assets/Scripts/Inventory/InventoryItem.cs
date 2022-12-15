using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInventoryItem
{
    string Name { get; }

    Sprite Image { get; }

    void OnPickUp();

    void OnConsume();
    
}


public class InventoryEventArgs : EventArgs
{
    public InventoryEventArgs(IInventoryItem item)
    {
        Item = item;
       
    }
    
    public IInventoryItem Item;
}