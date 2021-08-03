using System;
using UnityEngine;

namespace CameraControllers
{
    [RequireComponent(typeof(Camera))]
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private float moveSpeed;
    
        private Func<Vector3> _getFollowPoint;

        private void Update()
        {
            Vector3 followPoint = _getFollowPoint();
            followPoint.z = transform.position.z;

            Vector3 moveVector = Vector3.Lerp(transform.position, followPoint, moveSpeed * Time.deltaTime);
            transform.position = moveVector;
        }

        public void SetGetFollowPointFunc(Func<Vector3> func)
        {
            _getFollowPoint = func;
        }

        public void FollowTransform(Transform target, Vector3 offset)
        {
            _getFollowPoint = () => target.position + offset;
        }
    }
}
