using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FeedbackCanvas : MonoBehaviour
{
    [SerializeField] GameObject feedbackCanvas;

    GameObject blueGemFeedback;
    GameObject greenGemFeedback;
    GameObject inventoryFull;
    GameObject itemConsumed;

    string itemConsumedName;


    private void Start()
    {
        blueGemFeedback = feedbackCanvas.gameObject.transform.GetChild(0).gameObject;
        greenGemFeedback = feedbackCanvas.gameObject.transform.GetChild(1).gameObject;
        inventoryFull = feedbackCanvas.gameObject.transform.GetChild(2).gameObject;
        itemConsumed = feedbackCanvas.gameObject.transform.GetChild(3).gameObject;

    }


    public void ShowCanvasOnPickUp(IInventoryItem item)
    {
        if (item.Name == "BlueGem")
        { 
            blueGemFeedback.SetActive(true);
            Invoke("HideFeedbackCanvasBlue", 5f);
        }
        
        if (item.Name == "GreenGem")
            greenGemFeedback.SetActive(true);
            Invoke("HideFeedbackCanvasGreen", 5f);

    }

    public void HideFeedbackCanvasBlue()
    {
        blueGemFeedback.SetActive(false);

    }
    
    public void HideFeedbackCanvasGreen()
    {
        greenGemFeedback.SetActive(false);

    }

    public void ShowCanvasInventoryFull()
    {
        inventoryFull.SetActive(true);
        Invoke("HideCanvasInvFull", 1f);
    }

    public void HideCanvasInvFull()
    {
        inventoryFull.SetActive(false);
    }

    public void ShowItemConsumed(IInventoryItem item)
    {
        TMP_Text txt = itemConsumed.transform.GetChild(0).GetComponent<TMP_Text>();
        if (item.Name == "BlueGem")
            itemConsumedName = "BLUE GEM";
        if (item.Name == "GreenGem")
            itemConsumedName = "GREEN GEM";

        txt.text = itemConsumedName + " consumed";

        itemConsumed.SetActive(true);
        Invoke("HideCanvasItemConsumed", 1f);
    }

    public void HideCanvasItemConsumed()
    {
        itemConsumed.SetActive(false);
    }
}
