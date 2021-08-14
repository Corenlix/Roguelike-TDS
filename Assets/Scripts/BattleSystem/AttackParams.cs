using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class AttackParams
{
    [SerializeField] private int damage;
    [SerializeField] private float knockbackTime;
    [SerializeField] private float knockbackForce;
    [SerializeField] private LayerMask interactiveLayers;
    
    public int Damage => damage;
    public float KnockbackTime => knockbackTime;
    public float KnockbackForce => knockbackForce;
    public LayerMask InteractiveLayers => interactiveLayers;
}
