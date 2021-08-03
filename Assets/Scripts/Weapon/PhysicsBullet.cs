using System;
using System.Collections;
using System.Collections.Generic;
using Helpers;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PhysicsBullet : Bullet
{
    [SerializeField] float moveSpeed;
    private Health.HealthOwnerCategory _bulletOwnerCategory;
    private int _damage;
    
    public override void Init(Vector2 shootPoint, int damage, Health.HealthOwnerCategory bulletOwnerCategory)
    {
        Vector2 shootDirection = shootPoint - (Vector2)transform.position;
        
        transform.rotation = RotateHelper.GetAngleFromDirection(shootDirection);
        var rb = GetComponent<Rigidbody2D>();
        rb.AddForce(shootDirection.normalized * moveSpeed, ForceMode2D.Impulse);
        _damage = damage;
        _bulletOwnerCategory = bulletOwnerCategory;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer != IgnoreBulletsLayer)
        {
            var health = other.GetComponent<Health>();
            if (!health || health.Damage(_damage, _bulletOwnerCategory))
            {
                Destroy(gameObject);
            }
        }
    }
}
