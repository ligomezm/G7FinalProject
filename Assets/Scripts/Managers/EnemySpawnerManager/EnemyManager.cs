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
        InitEnemiesList();
    }
    void Start()
    {
    }
    void OnDisable()
    {
        SpawnableEnemy.OnEnemyDefeated -= ManageEnemies;
        //ClearEnemiesList();
    }

    void InitEnemiesList()
    {
        for (int i = 0; i < enemiesToSpawn.Count; i++)
        {
            enemiesToSpawn[i].Init(this);
        }
    }

    void ClearEnemiesList()
    {
        enemiesToSpawn.Clear();
    }

    private void ManageEnemies(Vector3 enemyPosition)
    {
        if (enemiesToSpawn.Count <= 0)
        {
            goldKey.gameObject.SetActive(true);
            goldKey.transform.position = enemyPosition;
            return;
        }

        if (enemiesToSpawn.Count <= enemyCounterToNextWave)
        {
            for (int i = 0; i < enemiesToSpawn.Count; i++)
            {
                enemiesToSpawn[i].gameObject.SetActive(true);
            }
        }
    }
}
