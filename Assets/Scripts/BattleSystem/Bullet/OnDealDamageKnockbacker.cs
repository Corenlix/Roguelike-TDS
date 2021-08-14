using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using UnityEngine;

[RequireComponent(typeof(DamageDealer))]
public class OnDealDamageKnockbacker : MonoBehaviour
{
    private void OnEnable()
    {
        var damageDealer = GetComponent<DamageDealer>();
        damageDealer.DamageDealt += Knockback;
    }

    private void OnDisable()
    {
        var damageDealer = GetComponent<DamageDealer>();
        damageDealer.DamageDealt -= Knockback;
    }

    private void Knockback(Collider2D target, AttackParams attackParams)
    {
        var knockback = target.GetComponent<Knockback>();
        if (knockback)
        {
            var direction = (target.ClosestPoint(transform.position) - (Vector2)transform.position).normalized;
            knockback.AddKnockback(direction * attackParams.KnockbackForce, attackParams.KnockbackTime);
        }
    }
}
