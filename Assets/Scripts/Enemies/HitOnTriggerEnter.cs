using System;
using BattleSystem.Bullet.TargetInteractiveCheckers;
using UnityEngine;

namespace Enemies
{
    public class HitOnTriggerEnter : MonoBehaviour
    {
        [SerializeField] private AttackParams attackParams;
        [SerializeField] private float reloadTime;

        private float _remainReloadTime;

        private void Update()
        {
            _remainReloadTime -= Time.deltaTime;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if(_remainReloadTime <= 0 && new LayersChecker(attackParams.InteractiveLayers).IsTargetInteractive(other.gameObject))
                DealDamage(other);
        }
        private void DealDamage(Collider2D target)
        {
            if (target.TryGetComponent(out Health targetHealth) && targetHealth.DealDamage(attackParams.Damage))
            {
                Knockback(target);
                _remainReloadTime = reloadTime;
            }
        }
        private void Knockback(Collider2D target)
        {
            if(target.TryGetComponent(out Knockback knockback))
            {
                var direction = (target.transform.position - transform.position).normalized;
                knockback.AddKnockback(direction * attackParams.KnockbackForce, attackParams.KnockbackTime);
            }
        }
    }
}
