using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Health))]
public class ChanceSpawnOnDeath : MonoBehaviour
{
    [SerializeField]
    private SpawnChances spawnChances;

    private void OnEnable()
    {
        GetComponent<Health>().onDied?.AddListener(SpawnItem);
    }

    private void OnDisable()
    {
        GetComponent<Health>().onDied?.RemoveListener(SpawnItem);   
    }

    private void SpawnItem()
    {
        spawnChances.TrySpawn(transform.position);
    }
}
