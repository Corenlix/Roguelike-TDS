using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(VelocityMove))]
public class Knockback : MonoBehaviour
{
    [SerializeField] private float knockbackResistance;
    private VelocityMove _velocityMove;
    
    private void Awake()
    {
        _velocityMove = GetComponent<VelocityMove>();
    }
    public void AddKnockback(Vector2 force, float time)
    {
        _velocityMove.AddForce(force / (1+knockbackResistance), time);
    }
}
