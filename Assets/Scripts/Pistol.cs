using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Weapon
{
    [SerializeField] private GameObject bullet;
    protected override void Shoot()
    {
        var newBullet = Instantiate(bullet, shootPoint.transform.position, transform.rotation);
        if(transform.parent.localScale.x < 0)
            newBullet.transform.Rotate(0, 180, 0);
    }
}
