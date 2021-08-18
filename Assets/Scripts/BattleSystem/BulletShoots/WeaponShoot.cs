using UnityEngine;

namespace BattleSystem.BulletShoots
{
    public abstract class WeaponShoot
    {
        public abstract void Shoot(Transform shootPoint, Vector2 direction, Bullet.Bullet bulletTemplate, AttackParams attackParams);
    }
}
