using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveItem : MonoBehaviour, IInventoryItem
{
    public string Name => throw new System.NotImplementedException();

    public Sprite Image => throw new System.NotImplementedException();

    public void OnConsume()
    {
        Debug.Log("item has been consumed");
    }

    public void OnPickUp()
    {
        throw new System.NotImplementedException();
    }
}
