using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;

namespace UI
{
    public class PopupSpawner : MonoBehaviour
    {
        [SerializeField] private PopupView popupPrefab;

        public void SpawnPopup(Vector2 position, string popupDescription)
        {
            var spawnedPopup = Instantiate(popupPrefab,  position, quaternion.identity, transform);
            spawnedPopup.SetDescription(popupDescription);
        }
    }
}
