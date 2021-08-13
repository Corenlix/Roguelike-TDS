using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShooterCreator
{
    public static WeaponShooter CreateWeaponShooter(WeaponShooterType weaponShooterType)
    {
        return weaponShooterType switch
        {
            WeaponShooterType.SingleBulletShooter => new SingleBulletShooter(),
            _ => throw new ArgumentOutOfRangeException(weaponShooterType.ToString())
        };
    }
}

public enum WeaponShooterType
{
    SingleBulletShooter,
}
