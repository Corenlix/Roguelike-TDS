using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    [SerializeField] private ParticleSystem destructionParticle;
    [SerializeField] private bool destroyAfterDealingDamage = true;
    protected AttackParams AttackParams;
    

    public void Init(Vector2 shootPoint, AttackParams attackParams)
    {
        AttackParams = attackParams;
        Shoot(shootPoint);
    }

    protected abstract void Shoot(Vector2 shootPoint);

    protected bool DealDamage(Health damageTaker)
    {
        if (!damageTaker)
            return false;
        
        if (damageTaker.DealDamage(AttackParams.Damage))
        {
            var knockback = damageTaker.GetComponent<Knockback>();
            if (knockback)
            {
                var direction = transform.right;
                knockback.AddKnockback(direction * AttackParams.KnockbackForce, AttackParams.KnockbackTime);
            }
            
            return true;
        }
        return false;
    }

    protected void Attack(Collider2D target)
    {
        if (DamageHelper.IsTargetInteractable(target, AttackParams.InteractiveLayers, out var targetHealth))
        {
            if (DealDamage(targetHealth))
            {
                if (destroyAfterDealingDamage)
                    Destroy(gameObject);
            }
            else
            {
                SpawnParticles();
                Destroy(gameObject);
            }
        }
    }
    private void SpawnParticles()
    {
        if(destructionParticle)
            Instantiate(destructionParticle, transform.position, Quaternion.identity);
    }
}
