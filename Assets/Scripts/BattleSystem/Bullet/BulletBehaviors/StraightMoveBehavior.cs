using System.Collections;
using System.Collections.Generic;
using Helpers;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class StraightMoveBehavior : BulletBehavior
{
    [SerializeField] private float moveSpeed;
    
    public override void Init(Vector2 targetPoint)
    {
        Vector2 shootDirection = targetPoint - (Vector2)transform.position;
        transform.rotation = RotateHelper.GetAngleFromDirection(shootDirection);
        var rb = GetComponent<Rigidbody2D>();
        rb.AddForce(shootDirection.normalized * moveSpeed, ForceMode2D.Impulse);
    }
}