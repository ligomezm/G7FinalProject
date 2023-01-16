using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConsumeItem : MonoBehaviour
{
    public Inventory Inventory;
    int itemToUse;
    GameObject itemToConsume;

    GreenGemCollectible greenGemCollectible;
    BlueGemCollectible blueGemCollectible;
    GoldKeyCollectable goldKeyCollectable;

    private void Start()
    {
        greenGemCollectible = FindObjectOfType<GreenGemCollectible>();
        blueGemCollectible = FindObjectOfType<BlueGemCollectible>();
        goldKeyCollectable = FindObjectOfType<GoldKeyCollectable>();
    }
    void OnEnable()
    {
        ManageScenes.OnSceneLoaded += GetReferences;
    }

    void OnDisable()
    {
        ManageScenes.OnSceneLoaded -= GetReferences;
        
    }
    private void GetReferences()
    {
        greenGemCollectible = FindObjectOfType<GreenGemCollectible>();
        blueGemCollectible = FindObjectOfType<BlueGemCollectible>();
        goldKeyCollectable = FindObjectOfType<GoldKeyCollectable>();
        Inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();

    }


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

    
    public void onItemConsumed(int itemToUse)
    {

        if (Inventory == null) TryGetInventory();
        if (Inventory.mItems != null)
        {

            GameObject inventoryPanel = GameObject.FindGameObjectWithTag("Inventory");
            //IInventoryItem item = inventoryPanel.GetChild(itemToUse).GetChild(0).GetComponent<IInventoryItem>();
            //Debug.Log("itemToUse " + inventoryPanel.transform.GetChild(itemToUse).gameObject.name);
            //Debug.Log("child0 " + inventoryPanel.transform.GetChild(itemToUse).GetChild(0).gameObject.name);
            IInventoryItem item = inventoryPanel.transform.GetChild(itemToUse).GetChild(0).GetComponent<IInventoryItem>();
            Sprite itemSprite = inventoryPanel.transform.GetChild(itemToUse).GetChild(0).GetChild(0).GetComponent<Image>().sprite;
            Debug.Log("itemsprite: " + itemSprite);

            if (itemSprite.name == "GreenGem")
            {
                greenGemCollectible.OnConsume();
            }
            
            if (itemSprite.name == "BlueGem")
            {
                blueGemCollectible.OnConsume();
            }
            
            if (itemSprite.name == "GoldKey")
            {
                goldKeyCollectable.OnConsume();
            }


            
            if (item != null)
            {
                item.OnConsume();
                Inventory.RemoveItem(item, itemToUse);
            }
        }
    }

    


    void TryGetInventory()
    {
        try
        {
            Inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
        }
        catch (System.Exception)
        {
            
            return;
        }
    }
}

    