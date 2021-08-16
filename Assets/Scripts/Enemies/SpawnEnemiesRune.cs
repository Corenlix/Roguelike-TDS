using System;
using System.Collections;
using System.Collections.Generic;
using Enemies;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class SpawnEnemiesRune : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private Animator animator;
    private EnemyFactory _enemyFactory;
    private static readonly int Spawned = Animator.StringToHash("Spawned");
    private bool _activated;
    
    public void SetEnemyFactory(EnemyFactory enemyFactory)
    {
        _enemyFactory = enemyFactory;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!_activated && other.TryGetComponent(out Player player))
        {
            _activated = true;
            foreach (var spawnPoint in spawnPoints)
            {
                StartCoroutine(SpawnEnemy(spawnPoint.position, Random.Range(1, 3f)));
            }

            animator.SetTrigger(Spawned);
        }
    }

    private IEnumerator SpawnEnemy(Vector2 position, float delay)
    {
        yield return new WaitForSeconds(delay);
        _enemyFactory.CreateEnemy(position);
    }
}
