using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordDamage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
            Debug.Log("esta dañando");
        if (other.gameObject.layer == LayerMask.NameToLayer("EnemyLayer")){
            EnemyDamage enemyDamage = other.gameObject.GetComponent<EnemyDamage>();
            //enemyDamage.hp -= enemyDamage.swordDamage;
            Debug.Log(enemyDamage);
        }
    }
}
