using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapSpikes : MonoBehaviour
{

    private LifeBar lifeBarPlayer;
    private float damage = 5;

    bool spikesReloaded = true;
    bool receiveDamage;

    GameObject player;
    Animator playerAnimator;

    public Animation spikeAnimation;

    void OnEnable()
    {
        
        lifeBarPlayer = FindObjectOfType<LifeBar>();
        //lifeBarPlayer = GameObject.FindGameObjectWithTag("lifeBarPlayer").GetComponent<LifeBar>();
        Debug.Log("Lifebar from trapspikes: " + lifeBarPlayer);
        spikesReloaded = true;

        player = GameObject.FindGameObjectWithTag("Player");
        playerAnimator = player.GetComponent<Animator>();
    }

    private void Start()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "PlayerArmature" && spikesReloaded)
        {
            if (other.gameObject.GetComponent<Attack>().isRoll)
            {
                //Debug.Log("Inmune");
                return;
            }
            receiveDamage = true;
            
            StartCoroutine(ConstantDamage());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "PlayerArmature")
        {
            //if (other.gameObject.GetComponent<Attack>().isRoll)
            //{
            //    Debug.Log("Inmune");
            //    return;
            //}
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
            
            if (spikesReloaded)
            {
            spikeAnimation.Play();
            }

            spikesReloaded = false;
            lifeBarPlayer.TakeDamage(damage);
            lifeBarPlayer.UpdateLifeBar();
            yield return new WaitForSeconds(1f);
            spikesReloaded = true;
        }
    }
}
