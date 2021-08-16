using UnityEngine;

namespace VisualActions
{
    [RequireComponent(typeof(Health))]
    public class SpawnerOnTakeDamage : MonoBehaviour
    {
        [SerializeField] private GameObject newObject;
        private void OnEnable()
        {
            GetComponent<Health>().Damaged -= SpawnObject;
        }

        private void OnDisable()
        {
            GetComponent<Health>().Damaged -= SpawnObject;
        }

        private void SpawnObject(int damage)
        {
            Instantiate(newObject, transform.position, Quaternion.identity);
        }
    }
}
