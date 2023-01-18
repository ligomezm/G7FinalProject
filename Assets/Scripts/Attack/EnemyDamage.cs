using CurlNoiseParticleSystem.Emitter;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.VFX;

public class EnemyDamage : MonoBehaviour
{
    public VisualEffect _AttackEffect;


    public float hp = 100;
    public int swordDamage = 35;

    public LinearIndicator linearIndicator;
    public float maxValue = 100;
    public float minValue = 0;

    public GameObject sword;

    // Start is called before the first frame update
    void Start()
    {
        //shapeEmitter = gameObject.GetComponent<ShapeEmitter>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (hp < 0)
        {
            gameObject.SetActive(false);
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
        _AttackEffect.Play();
    }
}
