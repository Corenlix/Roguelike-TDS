using System;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemies
{
    [CreateAssetMenu]
    public class EnemyFactory : ScriptableObject
    {
        [SerializeField] private EnemySpawnWeight[] enemies;

        public GameObject CreateEnemy(Vector2 position)
        {
            int weightsSum = enemies.Sum(x => x.Weight);
            int currentWeightDiapason = 0;
            int random = Random.Range(0, weightsSum + 1);
            
            foreach (var enemy in enemies)
            {
                currentWeightDiapason += enemy.Weight;
                if (random <= currentWeightDiapason)
                {
                    return Instantiate(enemy.EnemyTemplate, position, Quaternion.identity);
                }
            }

            throw new Exception();
        }
    }

    [Serializable]
    internal class EnemySpawnWeight
    {
        [SerializeField] private GameObject enemyTemplate;
        public GameObject EnemyTemplate => enemyTemplate;
        
        [Range(0, 100)]
        [SerializeField] private int weight;
        public int Weight => weight;
    }
}