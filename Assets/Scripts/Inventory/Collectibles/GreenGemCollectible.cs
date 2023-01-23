using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenGemCollectible : MonoBehaviour, IInventoryItem
{
    public bool rotate;
    public float rotationSpeed;

    public AudioClip collectSound;

    public GameObject collectEffect;

    private LifeBar lifeBarPlayer;
    private float life = 20;

    FeedbackCanvas feedbackCanvas;

    private void Start()
    {

        lifeBarPlayer = FindObjectOfType<LifeBar>();
    
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

        gameObject.SetActive(false);
    }

    

    public void OnConsume()
    {
        lifeBarPlayer.IncreaseLife(life);
        lifeBarPlayer.UpdateLifeBar();
        gameObject.SetActive(false);

        if (feedbackCanvas == null)
            TryGetFeedbackCanvas();

        feedbackCanvas.ShowItemConsumed(this);

        //Set and Show canvas "You consumed"

        //Destroy(gameObject);
    }

    public string Name
    {
        get
        {
            return "GreenGem";
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
