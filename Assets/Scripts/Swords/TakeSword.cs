using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TakeSword : MonoBehaviour
{
    public GameObject swordsContainer;
    public GameObject swordsInHand;

    public bool playerHasSword;


    List<GameObject> swords  = new List<GameObject>();

    void Start()
    {
        playerHasSword = false;
       
        try
        {
            swordsContainer = GameObject.FindGameObjectWithTag("Swords");
        }
        catch(UnityException)
        {
            return;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("SwordsInScene"))
        {
            int index = int.Parse(other.gameObject.tag);
            ActiveSwords();
            DesactiveSwordsInHand();

            other.gameObject.SetActive(false);
            swordsInHand.transform.GetChild(index).gameObject.SetActive(true);
            playerHasSword = true;
        }
    }

    void DesactiveSwordsInHand()
    {
        for(int i = 0; i < swordsInHand.transform.childCount; i++)
        {
            swordsInHand.transform.GetChild(i).gameObject.SetActive(false);

        }
    }

    void ActiveSwords()
    {
        if (swordsContainer == null) TryGetSwords();
        for (int i = 0; i < swordsContainer.transform.childCount; i++)
        {
           swordsContainer.transform.GetChild(i).gameObject.SetActive(true);
        }
    }

    void TryGetSwords()
    {
        try
        {
            swordsContainer = GameObject.FindGameObjectWithTag("Swords");
        }
        catch (System.Exception)
        {
            return;
        }
    }
}
