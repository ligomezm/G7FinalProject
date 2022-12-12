using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TakeSword : MonoBehaviour
{
    public GameObject swordsContainer;
    public GameObject swordsInHand;


    List<GameObject> swords  = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
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
        for (int i = 0; i < swordsContainer.transform.childCount; i++)
        {
           swordsContainer.transform.GetChild(i).gameObject.SetActive(true);
        }
    }
}
