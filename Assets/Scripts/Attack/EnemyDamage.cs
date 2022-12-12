using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int hp = 100;
    public int swordDamage = 35;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (hp < 0)
        {
            Destroy(gameObject);
        }
    }

    //void OnTriggerEnter(Collider other)
    //{
    //    Debug.Log("Entro" + other.gameObject.name);
    //    if (other.gameObject.layer == LayerMask.NameToLayer("SwordInHand"))
    //    {
    //        hp = -swordDamage;
    //    }

    //}
}
