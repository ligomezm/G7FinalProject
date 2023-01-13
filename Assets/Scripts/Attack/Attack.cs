using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public GameObject weapons;
    List<BoxCollider> colliderWeapon = new List<BoxCollider>();
    Animator animator;

    int countClicks;
    bool canClick;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        countClicks = 0;
        canClick = false;


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

    public void DesactiveRootMotion()
    {
        //Debug.Log("Entro a desactivar Root Motion");
        animator.applyRootMotion = false;
    }
    public void ActiveRootMotion()
    {
        //Debug.Log("Entro ha activar Root Motion");
        animator.applyRootMotion = true;
    }


}
