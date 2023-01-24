using System;
using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditorInternal;
#endif
using UnityEngine;

public class SwordDamage : MonoBehaviour
{
    public float swordDamage =  30;
    public Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // If it is special Attack the sword damage increased 10% 
        if (IsSpecialAttack())
        {
            swordDamage = swordDamage + swordDamage * 0.1f;
        }
        else
        {
            swordDamage = 30;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            EnemyDamage enemyDamage     = other.gameObject.GetComponent<EnemyDamage>();
            //ShapeEmitter shapeEmitter   = other.gameObject.GetComponent<ShapeEmitter>();
            try
            {
                enemyDamage.hp -= swordDamage;
                //shapeEmitter.Emit();
            }
            catch (System.Exception)
            {
            }
        }
    }

    private bool IsSpecialAttack()
    {
        return animator.GetBool("Attack_B");
    }
}
