using CurlNoiseParticleSystem.Emitter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentalDamage : MonoBehaviour
{
    private LifeBar lifeBarPlayer;
    private float damage = 3;

    bool receiveDamage;

    GameObject player;
    Animator playerAnimator;

    private void Start()
    {
        lifeBarPlayer = FindObjectOfType<LifeBar>();
        //lifeBarPlayer = GameObject.FindGameObjectWithTag("lifeBarPlayer").GetComponent<LifeBar>();

        player = GameObject.FindGameObjectWithTag("Player");
        playerAnimator = player.GetComponent<Animator>();
    }

    void OnEnable()
    {
        ManageScenes.OnSceneLoaded += GetReferences;
    }
    void OnDisable()
    {
        ManageScenes.OnSceneLoaded -= GetReferences;
    }
    private void GetReferences()
    {
        //lifeBarPlayer = FindObjectOfType<LifeBar>();
        lifeBarPlayer = GameObject.FindGameObjectWithTag("lifeBarPlayer").GetComponent<LifeBar>();

        player = GameObject.FindGameObjectWithTag("Player");
        playerAnimator = player.GetComponent<Animator>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "PlayerArmature")
        {
            //other.GetComponent<EnemyDamage>().hp -= 30;
            receiveDamage = true;
            StartCoroutine(ConstantDamage());
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            EnemyDamage enemyDamage = other.gameObject.GetComponent<EnemyDamage>();
            //ShapeEmitter shapeEmitter = other.gameObject.GetComponent<ShapeEmitter>();
            try
            {
                enemyDamage.hp -= 0.1f;
                //shapeEmitter.Emit();
            }
            catch (System.Exception)
            {
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "PlayerArmature")
        {
            playerAnimator.SetBool("Pain", false);
            receiveDamage = false;
            StopCoroutine(ConstantDamage());
        }
    }

    IEnumerator ConstantDamage()
    {
        while (receiveDamage)
        {
            playerAnimator.SetBool("Pain", true);
            lifeBarPlayer.TakeDamage(damage);
            lifeBarPlayer.UpdateLifeBar();
            
            yield return new WaitForSeconds(1f);
        }
    }
}
