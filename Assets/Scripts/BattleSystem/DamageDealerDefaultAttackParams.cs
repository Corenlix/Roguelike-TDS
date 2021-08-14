using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DamageDealer))]
public class DamageDealerDefaultAttackParams : MonoBehaviour
{
    [SerializeField] private AttackParams attackParams;
    
    private void Start()
    {
        GetComponent<DamageDealer>().SetAttackParams(attackParams);
    }
}
