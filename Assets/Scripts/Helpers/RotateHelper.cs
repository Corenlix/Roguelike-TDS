using Unity.Mathematics;
using UnityEngine;

namespace Helpers
{
    public static class RotateHelper
    {
        public static Quaternion LookAt2D(Vector2 objectPosition, Vector2 targetPosition)
        {
            Vector2 direction = targetPosition - objectPosition;

            return GetAngleFromDirection(direction);
        }

        public static Quaternion GetAngleFromDirection(Vector2 direction)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            return Quaternion.Euler(0, 0, angle);
        }

        public static Vector2 RotateVector(this Vector2 vector, float degrees)
        {
            degrees *= Mathf.Deg2Rad;
            float angleCos = Mathf.Cos(degrees);
            float angleSin = Mathf.Sin(degrees);
            return new Vector2(vector.x * angleCos - vector.y * angleSin, 
                vector.y * angleCos + vector.x * angleSin);
        }
        
        public static void FlipBodyToPosition(Transform transform, Vector2 targetPosition)
        {
            var aimDirection = targetPosition - (Vector2)transform.position;
            Vector3 playerRotation = transform.rotation.eulerAngles;
            int xScaleModifier = aimDirection.x < 0 ? -1 : 1;
            transform.localScale = new Vector3(xScaleModifier * Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            transform.rotation = Quaternion.Euler(playerRotation);
        }
        
    }
}
