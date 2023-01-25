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

    private void Update()
    {
        RealeasingSword();
    }

    void RealeasingSword()
    {
        if (enemyDamage.flag == true)
        {
            newSword.SetActive(true);
            newSword.transform.position = transform.position;
        }
    }
}
