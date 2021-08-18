using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Items
{
    [CreateAssetMenu]
    public class SpawnChances : ScriptableObject
    {
        [SerializeField] private List<SpawnChance> dropChances;

        public GameObject TrySpawn(Vector2 position)
        {
            float random = Random.Range(0f, 100f);
            float currentDiapason = 0;
            foreach (var spawnChance in dropChances)
            {
                currentDiapason += spawnChance.Chance;
                if (random <= currentDiapason)
                {
                    return spawnChance.Spawn(position);
                }
            }

            return null;
        }

        [Serializable]
        class SpawnChance
        {
            [SerializeField] private GameObject obj;
            [SerializeField] private float chance;
            public float Chance => chance;

            public GameObject Spawn(Vector2 position)
            {
                return Instantiate(obj, position, Quaternion.identity);
            }
        }
    }
}

