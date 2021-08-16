using System.Collections;
using System.Collections.Generic;
using BattleSystem.Bullet;
using UnityEngine;

public class SingleBulletShooter : WeaponShooter
{
    public override void Shoot(Transform shootPoint, Vector2 direction, Bullet bulletTemplate, AttackParams attackParams)
    {
        Bullet newBullet = Object.Instantiate(bulletTemplate, shootPoint.transform.position, Quaternion.identity);
        newBullet.Init(direction, attackParams);
    }
}
