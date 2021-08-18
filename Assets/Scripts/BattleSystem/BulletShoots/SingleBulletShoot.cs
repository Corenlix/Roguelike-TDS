using UnityEngine;

namespace BattleSystem.BulletShoots
{
    public class SingleBulletShoot : WeaponShoot
    {
        public override void Shoot(Transform shootPoint, Vector2 direction, Bullet.Bullet bulletTemplate, AttackParams attackParams)
        {
            Bullet.Bullet newBullet = Object.Instantiate(bulletTemplate, shootPoint.transform.position, Quaternion.identity);
            newBullet.Init(direction, attackParams);
        }
    }
}
