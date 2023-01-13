using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestInteraction : MonoBehaviour
{
    public Animation chestAnimation;

    bool isOpen;

    public GameObject collectible;

    private void Start()
    {

        //chestAnimation = GetComponent<Animation>();

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "PlayerArmature" && !isOpen)
        {
            chestAnimation.Play();
            Invoke("ShowCollectible", .5f);
        }
            isOpen = true;
    }

    void ShowCollectible()
    {
        collectible.SetActive(true);
    }
}
