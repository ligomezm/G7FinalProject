using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueGemCollectible : MonoBehaviour, IInventoryItem
{
    public bool rotate;
    public float rotationSpeed;

    public AudioClip collectSound;

    public GameObject collectEffect;

    private LifeBar lifeBarPlayer;
    private float life = 10;
    //private bool isLifeFull;
    
    //public Inventory Inventory;

    //Dictionary<int, IInventoryItem> itemsDict;
    //public int itemPosition;
    

    private void Start()
    {

        lifeBarPlayer = FindObjectOfType<LifeBar>();

        Debug.Log("Vida al iniciar: " + lifeBarPlayer.currentValue);

        /*if (lifeBarPlayer.currentValue < 100)
        {
            isLifeFull = false;
        }
        
        if (lifeBarPlayer.currentValue >= 100)
        {
            isLifeFull = true;
        }*/

    }

    void Update()
    {

        if (rotate)
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime, Space.World);

    }

    public void OnPickUp()
    {
        if (collectSound)
            AudioSource.PlayClipAtPoint(collectSound, transform.position);
        if (collectEffect)
            Instantiate(collectEffect, transform.position, Quaternion.identity);

        /*if (!isLifeFull)
        { 
            lifeBarPlayer.IncreaseLife(life);
            
            //Revisar por que no actualiza
            //lifeBarPlayer.UpdateLifeBar();
           
            GetKeyFromValue(this);
            
            gameObject.SetActive(false);
            
            Inventory.RemoveItem(this, itemPosition);
            
        }*/

        gameObject.SetActive(false);
    }

    /*public void GetKeyFromValue(IInventoryItem item)
    {
        itemsDict = Inventory.itemsDict;
                
        foreach (int keyVar in itemsDict.Keys)
        {
            if (itemsDict[keyVar] == item)
            {
                itemPosition =  keyVar;
            }
        }
    }*/

    public void OnConsume()
    {
        lifeBarPlayer.IncreaseLife(life);
        lifeBarPlayer.UpdateLifeBar();
        gameObject.SetActive(false);
        //Destroy(gameObject);
    }
    public string Name
    {
        get
        {
            return "BlueGem";
        }
    }

    public Sprite _Image = null;

    public Sprite Image
    {
        get
        {
            return _Image;
        }
    }
}
