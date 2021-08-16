using UnityEngine;

namespace Items
{
    [RequireComponent(typeof(Health))]
    public class ChanceSpawnOnDeath : MonoBehaviour
    {
        [SerializeField]
        private SpawnChances spawnChances;

        private void OnEnable()
        {
            GetComponent<Health>().Died += SpawnItem;
        }

        private void OnDisable()
        {
            GetComponent<Health>().Died -= SpawnItem;   
        }

        private void SpawnItem()
        {
            spawnChances.TrySpawn(transform.position);
        }
    }
}
