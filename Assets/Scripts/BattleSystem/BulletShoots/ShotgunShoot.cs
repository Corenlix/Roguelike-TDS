using Helpers;
using UnityEngine;
using Random = UnityEngine.Random;

namespace BattleSystem.BulletShoots
{
    public class ShotgunShoot : WeaponShoot
    {
        private const int BulletsCount = 6;
        private const float DeltaAngle = 5;
        
        public override void Shoot(Transform shootPoint, Vector2 targetPosition, Bullet.Bullet bulletTemplate, AttackParams attackParams)
        {
            float offsetAngle = BulletsCount / 2f * DeltaAngle;
            Vector2 shootPointPosition = shootPoint.position;
            Vector2 distanceToDirectionPoint = targetPosition - shootPointPosition;
                
            for (int i = 0; i < BulletsCount; i++)
            {
                float bulletAngleDelta = DeltaAngle*i - offsetAngle;
                var newDirection = shootPointPosition + distanceToDirectionPoint.RotateVector(bulletAngleDelta);

                CreateBullet(bulletTemplate, shootPointPosition, newDirection, attackParams);
            }
        }
    }
}
