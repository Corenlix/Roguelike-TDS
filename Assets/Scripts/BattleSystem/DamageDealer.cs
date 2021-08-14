using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] private TargetDamageableChecker targetDamageableChecker;
    private AttackParams _attackParams;

    public void SetAttackParams(AttackParams newAttackParams)
    {
        _attackParams = newAttackParams;
    }
    public void DealDamage(Collider2D target)
    {
        if (!targetDamageableChecker.IsTargetDamageable(target, _attackParams))
            return;
        
        if (target.TryGetComponent<Health>(out var targetHealth) && targetHealth.DealDamage(_attackParams.Damage))
            DamageDealt?.Invoke(target, _attackParams);
    }

    public event Action<Collider2D, AttackParams> DamageDealt;
}
