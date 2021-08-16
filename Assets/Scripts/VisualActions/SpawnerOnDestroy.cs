using UnityEngine;

namespace VisualActions
{
    public class SpawnerOnDestroy : MonoBehaviour
    {
        [SerializeField] private GameObject newObject;

        private void OnDestroy()
        {
            Instantiate(newObject, transform.position, transform.rotation);
        }
    }
}
