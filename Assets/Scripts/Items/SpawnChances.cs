using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

[CreateAssetMenu]
public class SpawnChances : ScriptableObject
{
    [SerializeField] private List<SpawnChance> dropChances;

    public GameObject TrySpawn(Vector2 position)
    {
        foreach (var spawnChance in dropChances)
        {
            var newObject = spawnChance.TrySpawn(position);
            if (newObject)
                return newObject;
        }

        return null;
    }

    [Serializable]
    class SpawnChance
    {
        [SerializeField] private GameObject obj;
        [SerializeField] private float chance;

        public GameObject TrySpawn(Vector2 position)
        {
            if (Random.Range(0, 100f) < chance)
            {
                return Instantiate(obj, position, Quaternion.identity);
            }
            return null;
        }
    }
}

