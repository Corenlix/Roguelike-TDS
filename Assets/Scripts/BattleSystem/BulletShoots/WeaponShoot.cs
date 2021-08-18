using UnityEngine;

namespace BattleSystem.BulletShoots
{
    public abstract class WeaponShoot
    {
        public abstract void Shoot(Transform shootPoint, Vector2 targetPosition, Bullet.Bullet bulletTemplate, AttackParams attackParams);

        protected void CreateBullet(Bullet.Bullet bulletTemplate, Vector2 position, Vector2 targetPosition, AttackParams attackParams)
        {
            Bullet.Bullet newBullet = Object.Instantiate(bulletTemplate, position, Quaternion.identity);
            newBullet.Init(targetPosition, attackParams);
        }
    }
}
