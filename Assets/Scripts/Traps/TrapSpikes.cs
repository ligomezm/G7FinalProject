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


    private void Start()
    {
        lifeBarPlayer = FindObjectOfType<LifeBar>();
        spikesReloaded = true;

        player = GameObject.FindGameObjectsWithTag("Player")[1];
        playerAnimator = player.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {

            if (other.gameObject.name == "PlayerArmature" && spikesReloaded)
        {
            receiveDamage = true;
            
            StartCoroutine(ConstantDamage());
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
