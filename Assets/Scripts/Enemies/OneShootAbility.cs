using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneShootAbility : EnemyAbility
{
    [SerializeField] private float reloadTime;
    [SerializeField] private AttackParams attackParams;
    [SerializeField] private Bullet bullet;
    [SerializeField] private Transform shootPoint;
    
    private float remainReloadTime;
    
    private void Awake()
    {
        remainReloadTime = reloadTime;
    }

    public override void Shoot(Vector2 targetPosition)
    {
        if (!IsReadyToShoot())
            return;
        Bullet createdBullet = Instantiate(bullet, shootPoint.position, Quaternion.identity);
        createdBullet.Init(targetPosition, attackParams);
        remainReloadTime = reloadTime;
    }

    public override bool IsReadyToShoot()
    {
        return remainReloadTime <= 0;
    }

    private void Update()
    {
        remainReloadTime -= Time.deltaTime;
    }
}
