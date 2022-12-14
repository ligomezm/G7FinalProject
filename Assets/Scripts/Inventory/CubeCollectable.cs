using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeCollectable : MonoBehaviour, IInventoryItem
{
    public string Name
    { 
        get
        {
            return "Cube";
        }
    }

    public Sprite _Image =null;

    public Sprite Image
    {
        get
        {
            return _Image;
        }
    }

    public void OnPickUp()
    {
        gameObject.SetActive(false);
    }

    public void OnConsume()
    {
        Destroy(gameObject);
    }
}
