using System;
using System.Collections;
using System.Collections.Generic;
using Helpers;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PhysicsBullet : Bullet
{
    [SerializeField] float moveSpeed;
    public override void Init(Vector2 shootPoint)
    {
        Vector2 shootDirection = shootPoint - (Vector2)transform.position;
        
        transform.rotation = RotateHelper.GetAngleFromDirection(shootDirection);
        var rgb = GetComponent<Rigidbody2D>();
        rgb.AddForce(shootDirection.normalized * moveSpeed, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
    }
}
