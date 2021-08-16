using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemies
{
    public class SpawnEnemiesTimer : MonoBehaviour
    {
        [SerializeField] private float minSpawnPeriod;
        [SerializeField] private float maxSpawnPeriod;
        [SerializeField] private GameObject player;
        [SerializeField] private float spawnDistance;
        [SerializeField] private EnemyFactory enemyFactory;
    
        private float _remainTime;

        private void Update()
        {
            _remainTime -= Time.deltaTime;
            if (_remainTime <= 0)
            {
                _remainTime = Random.Range(minSpawnPeriod, maxSpawnPeriod);
                Vector2 spawnPoint = (Vector2)player.transform.position +
                                     new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized * Random.Range(spawnDistance/2, spawnDistance);
                enemyFactory.CreateEnemy(spawnPoint);
            }
        }
    }
}
