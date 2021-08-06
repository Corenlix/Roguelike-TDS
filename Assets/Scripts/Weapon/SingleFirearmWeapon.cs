using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleFirearmWeapon : Weapon
{
    protected override void Shoot(Vector2 direction)
    {
        Bullet newBullet = Instantiate(bullet, shootPoint.transform.position, Quaternion.identity);
        newBullet.Init(direction, attackParams);
    }
}
