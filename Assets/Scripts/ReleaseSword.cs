using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReleaseSword : MonoBehaviour
{
    EnemyDamage enemyDamage;
    public GameObject newSword;


    private void Start()
    {
        enemyDamage = GetComponent<EnemyDamage>();
    }

    
    void OnDisable()
    {
        newSword.SetActive(true);
        newSword.transform.position = transform.position + new Vector3(0, 0.5f, 0);
    }
}
