using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MultipleChecker : TargetDamageableChecker
{
    [SerializeField] private List<TargetDamageableChecker> checkers;

    public override bool IsTargetDamageable(Collider2D target, AttackParams attackParams)
    {
        if (checkers.Any(x => !x.IsTargetDamageable(target, attackParams)))
            return false;
        
        return true;
    }
}
