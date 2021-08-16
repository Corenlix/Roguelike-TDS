using UnityEngine;

namespace BattleSystem.Bullet.Attackers
{
    public abstract class Attacker
    {
        public abstract bool Attack(Transform attacker, Collider2D target, AttackParams attackParams);

        protected bool DealDamage(Transform attacker, Collider2D target, AttackParams attackParams)
        {
            if (target.TryGetComponent(out Health targetHealth) && targetHealth.DealDamage(attackParams.Damage))
            {
                Knockback(attacker.position, target, attackParams.KnockbackForce, attackParams.KnockbackTime);
                return true;
            }

            return false;
        }
        private void Knockback(Vector2 attackerPosition, Collider2D target, float knockbackForce, float knockbackTime)
        {
            if(target.TryGetComponent(out Knockback knockback))
            {
                var direction = (target.ClosestPoint(attackerPosition) - attackerPosition).normalized;
                knockback.AddKnockback(direction * knockbackForce, knockbackTime);
            }
        }
    }
}