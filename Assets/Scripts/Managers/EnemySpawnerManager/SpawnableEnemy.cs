using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class SpawnableEnemy : MonoBehaviour
{
    public static Action<Vector3> OnEnemyDefeated;
    private EnemyManager _manager;

    public void Init(EnemyManager manager)
    {
        _manager = manager;
    }


    void OnDisable()
    {
        Debug.Log("Enemies position: " + transform.position);
        _manager.enemiesToSpawn.Remove(this);
        OnEnemyDefeated?.Invoke(transform.position);
    }
}
