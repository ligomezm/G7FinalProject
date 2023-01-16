using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldKeyCollectable : MonoBehaviour, IInventoryItem
{
    public bool rotate;

    public float rotationSpeed;

    public AudioClip collectSound;

    public GameObject collectEffect;

    public string Name
    {
        get
        {
            return "GoldKey";
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
        gameObject.SetActive(false);
        //Destroy(gameObject);
    }
}
