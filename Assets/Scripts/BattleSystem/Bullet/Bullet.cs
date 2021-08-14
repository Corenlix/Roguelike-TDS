using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(DamageDealer))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private BulletBehavior bulletBehavior;
    public void Init(Vector2 targetPoint, AttackParams attackParams)
    {
        bulletBehavior.Init(targetPoint);
        GetComponent<DamageDealer>().SetAttackParams(attackParams);
    }
}
