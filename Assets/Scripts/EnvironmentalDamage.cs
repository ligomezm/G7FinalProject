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
        player = GameObject.FindWithTag("Player");
        playerAnimator = player.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "PlayerArmature")
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
            lifeBarPlayer.TakeDamage(damage);
            lifeBarPlayer.UpdateLifeBar();
            
            yield return new WaitForSeconds(1f);
        }
    }
}
