using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class DamageOnCollision : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private LayerMask damageLayers;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (DamageHelper.IsTargetInteractable(other, damageLayers, out var targetHealth) && targetHealth)
        {
            targetHealth.DealDamage(damage);
        }
    }
}
