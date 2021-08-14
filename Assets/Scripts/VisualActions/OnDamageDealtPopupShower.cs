using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DamageDealer))]
public class OnDamageDealtPopupShower : MonoBehaviour
{
    private void OnEnable()
    {
        GetComponent<DamageDealer>().DamageDealt += OnDamageDealt;
    }

    private void OnDisable()
    {
        GetComponent<DamageDealer>().DamageDealt += OnDamageDealt;
    }

    private void OnDamageDealt(Collider2D target, AttackParams attackParams)
    {
        ShowPopup(attackParams.Damage);
    }
    private void ShowPopup(int damage)
    {
        PopupsSpawner.Instance.SpawnDamagePopup(transform.position, damage);
    }
}
