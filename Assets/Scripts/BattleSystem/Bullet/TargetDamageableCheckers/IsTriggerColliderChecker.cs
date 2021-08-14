using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsTriggerColliderChecker : TargetDamageableChecker
{
    public override bool IsTargetDamageable(Collider2D target, AttackParams attackParams)
    {
        return target.isTrigger;
    }
}
