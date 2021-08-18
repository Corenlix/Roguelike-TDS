using Helpers;
using UnityEngine;

namespace BattleSystem.BulletShoots
{
    public class SingleBulletShoot : WeaponShoot
    {
        public override void Shoot(Transform shootPoint, Vector2 targetPosition, Bullet.Bullet bulletTemplate, AttackParams attackParams)
        {
            CreateBullet(bulletTemplate, shootPoint.transform.position, targetPosition, attackParams);
        }
    }
}
