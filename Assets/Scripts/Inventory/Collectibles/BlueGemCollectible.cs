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
    

    private void Start()
    {

        lifeBarPlayer = FindObjectOfType<LifeBar>();

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
            SoundManager.GetInstance().PlayClipAtPointRef(collectSound, transform.position);
            //AudioSource.PlayClipAtPoint(collectSound, transform.position);
        if (collectEffect)
            Instantiate(collectEffect, transform.position, Quaternion.identity);

       
        gameObject.SetActive(false);
    }

   
    public void OnConsume()
    {
        lifeBarPlayer.IncreaseLife(life);
        lifeBarPlayer.UpdateLifeBar();
        gameObject.SetActive(false);
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
