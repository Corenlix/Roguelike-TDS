using UnityEngine;

namespace BattleSystem.Bullet.Attackers
{
    public abstract class Attacker
    {
        public abstract bool TryAttack(Transform attacker, Collider2D target, AttackParams attackParams);

        protected bool DealDamage(Transform attacker, Collider2D target, AttackParams attackParams)
        {
            if (target.TryGetComponent(out Health targetHealth) && targetHealth.DealDamage(attackParams.Damage))
            {
                Knockback(attacker, target, attackParams.KnockbackForce, attackParams.KnockbackTime);
                if(attackParams.PopupSpawner)
                    attackParams.PopupSpawner.SpawnPopup(target.transform.position, attackParams.Damage.ToString());
                return true;
            }

            return false;
        }
        private void Knockback(Transform attacker, Collider2D target, float knockbackForce, float knockbackTime)
        {
            if(target.TryGetComponent(out Knockback knockback))
            {
                var direction = attacker.right;
                knockback.AddKnockback(direction * knockbackForce, knockbackTime);
            }
        }
    }
}