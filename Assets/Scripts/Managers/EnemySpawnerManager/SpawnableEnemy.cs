using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class SpawnableEnemy : MonoBehaviour
{
    public bool appearInactive = false;
    public static Action OnEnemyDefeated;
    private EnemyManager _manager;

    public void Init(EnemyManager manager)
    {
        _manager = manager;
    }


    void OnDisable()
    {
            _manager.enemiesToSpawn.Remove(this);
            OnEnemyDefeated?.Invoke();
    }
}
