using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.VFX;

public class EnemyDamage : MonoBehaviour
{
    public VisualEffect _AttackEffect;


    public float hp;
    public int swordDamage = 35;

    public LinearIndicator linearIndicator;
    public float maxValue = 100;
    public float minValue = 0;

    public GameObject sword;

    public AudioSource sound_Slash;
    public AudioSource sound_Death;


    public bool flag = false;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        maxValue = hp;
        linearIndicator.maxValue = maxValue;
        animator = gameObject.GetComponent<Animator>();

        //shapeEmitter = gameObject.GetComponent<ShapeEmitter>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (hp <= 0 && flag== false)
        {
            flag = true;
            animator.SetInteger("State", 5);
            sound_Death.Play();

        }
        hp = Mathf.Clamp(hp, minValue, maxValue);

        linearIndicator.SetValue(hp);
    }

    public void ActiveColliderSwordAttack()
    {
        sword.gameObject.GetComponent<BoxCollider>().enabled = true;
    }
    public void DesactiveColliderSwordAttack()
    {
        sword.gameObject.GetComponent<BoxCollider>().enabled = false;
    }

    public void ActiveSlashSwordEnemy()
    {
        sound_Slash.Play();
        _AttackEffect.Play();
    }

    public void DeactiveEnemy()
    {
        gameObject.SetActive(false);

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

    public void DamageByEnvironment()
    {
        hp -= 0.2f;
    }
}
