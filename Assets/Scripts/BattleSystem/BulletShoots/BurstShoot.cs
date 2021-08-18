using System.Collections;
using Helpers;
using UnityEngine;
using Random = UnityEngine.Random;

namespace BattleSystem.BulletShoots
{
    public class BurstShoot : WeaponShoot
    {
        private const float TimeBetweenShoots = 0.05f;
        private const int ShootsCount = 3;
        
        public override void Shoot(Transform shootPoint, Vector2 targetPosition, Bullet.Bullet bulletTemplate, AttackParams attackParams)
        {
            Vector2 shootPointPosition = shootPoint.position;
            Vector2 distanceToDirectionPoint = targetPosition - shootPointPosition;
            
            for (int i = 0; i < ShootsCount; i++)
            {
                Vector2 newDirection =
                    shootPointPosition + distanceToDirectionPoint.RotateVector(Random.Range(-2f, 2f));
                StaticCoroutine.Instance.StartRoutine(SpawnBulletCoroutine(shootPointPosition, newDirection, bulletTemplate, attackParams,
                    TimeBetweenShoots * i));
            }
        }

        private IEnumerator SpawnBulletCoroutine(Vector2 shootPoint, Vector2 targetPosition, Bullet.Bullet bulletTemplate, AttackParams attackParams, float time)
        {
            yield return new WaitForSeconds(time);
            CreateBullet(bulletTemplate, shootPoint, targetPosition, attackParams);
        }
    }
}
