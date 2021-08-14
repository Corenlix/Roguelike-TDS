using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DamageDealer))]
public class OnDealDamageDestroyer : MonoBehaviour
{
    private void OnEnable()
    {
        GetComponent<DamageDealer>().DamageDealt += OnDamageDealt;
    }

    private void OnDisable()
    {
        GetComponent<DamageDealer>().DamageDealt -= OnDamageDealt;
    }

    private void OnDamageDealt(Collider2D target, AttackParams attackParams)
    {
        Destroy(gameObject);
    }
}
