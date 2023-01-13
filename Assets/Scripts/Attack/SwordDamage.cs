using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordDamage : MonoBehaviour
{
    public float swordDamage =  30;
    public bool isSpecialAttack;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // If it is special Attack the sword damage increased 10% 
        if (isSpecialAttack)
        {
            swordDamage = swordDamage + swordDamage * 0.1f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            EnemyDamage enemyDamage = other.gameObject.GetComponent<EnemyDamage>();
            enemyDamage.hp -= swordDamage;
        }
    }

    public void ActiveSpecialAttack()
    {
        isSpecialAttack = true;
    }

    public void DesativeSpecialAttack()
    {
        isSpecialAttack = true;
    }
}
