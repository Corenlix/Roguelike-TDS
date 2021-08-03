using UnityEngine;

namespace CameraControllers
{
    public class PlayerCamera : MonoBehaviour
    {
        private Camera _mainCamera;
        [SerializeField] private Transform player;
        [SerializeField] private CameraFollow cameraFollow;

        [SerializeField] private float cursorWeight = 1;
        [SerializeField] private float playerWeight = 2;

        private void Start()
        {
            _mainCamera = Camera.main;
            cameraFollow.SetGetFollowPointFunc((() =>
            {
                var mousePosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
                return (mousePosition * cursorWeight + player.position * playerWeight) / (playerWeight + cursorWeight);
            }));
        }
    
    }
}
