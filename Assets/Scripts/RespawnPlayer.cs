using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPlayer : MonoBehaviour
{
    [SerializeField] private Transform respawnPoint;
    GameObject player;
    Animator animator;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        animator = player.GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {       
        if (other.CompareTag("Damage"))
        {
            Invoke("Respawn", 3);
        }
    }

    void Respawn()
    {
        animator.SetBool("Pain", false);
        transform.position = respawnPoint.transform.position;
        Physics.SyncTransforms();
        
    }
}
