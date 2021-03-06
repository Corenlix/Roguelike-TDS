using System;

namespace BattleSystem.BulletShoots
{
    public static class WeaponShootCreator
    {
        public static WeaponShoot CreateWeaponShooter(WeaponShooterType weaponShooterType)
        {
            return weaponShooterType switch
            {
                WeaponShooterType.SingleBulletShooter => new SingleBulletShoot(),
                WeaponShooterType.ShotgunShooter => new ShotgunShoot(),
                WeaponShooterType.BurstShoot => new BurstShoot(),
                _ => throw new ArgumentOutOfRangeException(weaponShooterType.ToString())
            };
        }
    }

    public enum WeaponShooterType
    {
        SingleBulletShooter,
        ShotgunShooter,
        BurstShoot
    }
}