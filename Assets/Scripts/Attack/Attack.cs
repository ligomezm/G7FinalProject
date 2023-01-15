using CurlNoiseParticleSystem.Emitter;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public GameObject weapons;
    List<BoxCollider> colliderWeapon = new List<BoxCollider>();
    Animator animator;

    //private List<ShapeEmitter> _emitter = new List<ShapeEmitter>();

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        for (int i = 0; i < weapons.transform.childCount; i++)
        {
            colliderWeapon.Add(weapons.transform.GetChild(i).gameObject.GetComponent<BoxCollider>());
                  //_emitter.Add(weapons.transform.GetChild(i).gameObject.GetComponent<ShapeEmitter>());
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
            try
            {
                //_emitter[j].Emit();
                colliderWeapon[j].enabled = true;
            }
            catch (System.Exception)
            {
            }
        }
    }

    public void DesactiveColliders()
    {
        for (int j = 0; j < colliderWeapon.Count; j++)
        {
            try
            {
                //_emitter[j].Stop();
                colliderWeapon[j].enabled = false;
            }
            catch (System.Exception)
            {
            }
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
