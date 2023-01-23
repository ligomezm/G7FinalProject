using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class CollectItem : MonoBehaviour
{
    public Inventory inventory;
    public static Action<IInventoryItem> OnitemPickup;
    bool showTutorial;
    
    bool showTutorialBlue;
    bool showTutorialGreen;


    FeedbackCanvas feedbackCanvas;

    void Start()
    {
        showTutorial = true;
        
        showTutorialBlue = true;
        showTutorialGreen = true;


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

            /*if (showTutorial)
            {
                if (feedbackCanvas == null)
                    TryGetFeedbackCanvas();

                feedbackCanvas.ShowCanvasOnPickUp(item);
            }*/

            OnitemPickup?.Invoke(item);
            inventory.AddItem(item);
            showTutorial = false;            
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
