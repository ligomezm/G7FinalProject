using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class CollectItem : MonoBehaviour
{
    public Inventory inventory;
    public static Action<IInventoryItem> OnitemPickup;
    
    bool showTutorialBlue;
    bool showTutorialGreen;
    bool showTutorialGoldKey;


    FeedbackCanvas feedbackCanvas;

    void Start()
    {       
        showTutorialBlue = true;
        showTutorialGreen = true;
        showTutorialGoldKey = true;


        //Debug.Log("This is happening");
        
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (inventory == null)
            TryGetInventory();

        if (feedbackCanvas == null)
            TryGetFeedbackCanvas();

        IInventoryItem item = hit.collider.GetComponent<IInventoryItem>();
        if (item != null)
        {

            if (item.Name == "BlueGem")
            {
                if (showTutorialBlue)
                {
                    feedbackCanvas.ShowCanvasOnPickUp(item);
                    showTutorialBlue = false;
                }
            }

            if (item.Name == "GreenGem")
            {
                if (showTutorialGreen)
                {
                    feedbackCanvas.ShowCanvasOnPickUp(item);
                    showTutorialGreen = false;
                }
            }

            if (item.Name == "GoldKey")
            {
                if (showTutorialGoldKey)
                {
                    feedbackCanvas.ShowCanvasOnPickUp(item);
                    showTutorialGoldKey = false;
                }
            }


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
