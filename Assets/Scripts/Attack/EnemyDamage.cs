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

    public AudioSource sound_Slash;
    public AudioSource sound_Death;

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
            sound_Death.Play();
            StartCoroutine("WaitUntilDeathSound");
        }

        hp = Mathf.Clamp(hp, minValue, maxValue);
        linearIndicator.SetValue(hp);
    }

    IEnumerator WaitUntilDeathSound()
    {
        yield return new WaitForSeconds(1.0f);
        gameObject.SetActive(false);
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
}
