using System;
using System.Collections;
using System.Collections.Generic;
using Helpers;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PhysicsBullet : Bullet
{
    [SerializeField] float moveSpeed;
    protected override void Shoot(Vector2 shootPoint)
    {
        Vector2 shootDirection = shootPoint - (Vector2)transform.position;
        transform.rotation = RotateHelper.GetAngleFromDirection(shootDirection);
        var rb = GetComponent<Rigidbody2D>();
        rb.AddForce(shootDirection.normalized * moveSpeed, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((AttackParams.InteractiveLayers.value & (1 << other.gameObject.layer)) != 0)
        {
            var health = other.GetComponent<Health>();
            if (!health || health.Damage(AttackParams.Damage))
            {
                SpawnParticles = !health;
                var knockback = other.GetComponent<Knockback>();
                if (knockback)
                {
                    var direction = transform.right;
                    knockback.AddKnockback(direction * AttackParams.KnockbackForce, AttackParams.KnockbackTime);
                }

                Destroy(gameObject);
            }
        }
    }
}
