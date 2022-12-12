using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public GameObject weapons;
    List<BoxCollider> colliderWeapon = new List<BoxCollider>();

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < weapons.transform.childCount; i++)
        {
            colliderWeapon.Add(weapons.transform.GetChild(i).gameObject.GetComponent<BoxCollider>());    
        }
        DesactiveColliders();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActiveColliders()
    {
        for(int j = 0; j < colliderWeapon.Count; j++)
        {
            colliderWeapon[j].enabled = true;
        }
    }

    public void DesactiveColliders()
    {
        for (int j = 0; j < colliderWeapon.Count; j++)
        {
            colliderWeapon[j].enabled = false;
        }
    }
}
