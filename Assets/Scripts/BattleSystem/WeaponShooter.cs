using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponShooter
{
    public abstract void Shoot(Transform shootPoint, Vector2 direction, Bullet bulletTemplate, AttackParams attackParams);
}
