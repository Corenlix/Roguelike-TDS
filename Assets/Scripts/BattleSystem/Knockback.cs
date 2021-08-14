using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(VelocityMover))]
public class Knockback : MonoBehaviour
{
    [SerializeField] private float knockbackResistance;
    private VelocityMover velocityMover;
    
    private void Awake()
    {
        velocityMover = GetComponent<VelocityMover>();
    }
    public void AddKnockback(Vector2 force, float time)
    {
        velocityMover.AddForce(force / (1+knockbackResistance), time);
    }
}
