using System;
using System.Collections;
using System.Collections.Generic;
using Enemies;
using UnityEngine;
using UnityEngine.Events;

public class SpawnEnemiesRune : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoints;
    private EnemyFactory _enemyFactory;
    
    public void SetEnemyFactory(EnemyFactory enemyFactory)
    {
        _enemyFactory = enemyFactory;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Player>())
        {
            foreach (var spawnPoint in spawnPoints)
            {
                _enemyFactory.CreateEnemy(spawnPoint.position);
            }

            Destroy(gameObject);
        }
    }
}
