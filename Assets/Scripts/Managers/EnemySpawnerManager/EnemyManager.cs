using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public int enemyCounterToNextWave;
    [SerializeField] GoldKeyCollectable goldKey;
    Vector3 lastEnemyPosition;
    public List<SpawnableEnemy> enemiesToSpawn  = new List<SpawnableEnemy>();
    void OnEnable()
    {
        SpawnableEnemy.OnEnemyDefeated += ManageEnemies;
    }
    void Start()
    {
        for (int i = 0; i < enemiesToSpawn.Count; i++)
        {
            enemiesToSpawn[i].Init(this);
        }
        
    }
    void OnDisable()
    {
        SpawnableEnemy.OnEnemyDefeated -= ManageEnemies;
    }

    private void ManageEnemies()
    {
        Debug.Log(enemiesToSpawn.Count);
        if (enemiesToSpawn.Count <= enemyCounterToNextWave)
        {
            for (int i = 0; i < enemiesToSpawn.Count; i++)
            {
                if (i == 0)
                    lastEnemyPosition = enemiesToSpawn[i].gameObject.transform.position;
                enemiesToSpawn[i].gameObject.SetActive(true);
            }
        }
        if (enemiesToSpawn.Count <= 0)
        {
            goldKey.gameObject.SetActive(true);
            goldKey.transform.position = lastEnemyPosition + Vector3.up * 1.1f;
        }
    }
}
