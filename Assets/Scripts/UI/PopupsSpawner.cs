using TMPro;
using Unity.Mathematics;
using UnityEngine;

namespace UI
{
    public class PopupsSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject damagePopupPrefab;
        [SerializeField] private GameObject itemPickedPrefab;
        public static PopupsSpawner Instance;

        private void Awake()
        {
            if(Instance)
                Destroy(Instance.gameObject);
            Instance = this;
        }
        public void SpawnDamagePopup(Vector2 position, int damage)
        {
            var spawnedPopup = Instantiate(damagePopupPrefab,  position, quaternion.identity, transform);
            spawnedPopup.GetComponentInChildren<TextMeshPro>().text = damage.ToString();
        }

        public void SpawnItemPickPopup(Vector2 position, string text)
        {
            var spawnedPopup = Instantiate(itemPickedPrefab,  position, quaternion.identity, transform);
            spawnedPopup.GetComponentInChildren<TextMeshPro>().text = text;

        }
    }
}
