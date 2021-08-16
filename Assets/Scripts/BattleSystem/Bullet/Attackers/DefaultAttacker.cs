using UnityEngine;

namespace BattleSystem.Bullet.Attackers
{
    public class DefaultAttacker : Attacker
    {
        public override bool Attack(Transform attacker, Collider2D target, AttackParams attackParams)
        {
            if (DealDamage(attacker, target, attackParams))
            {
                Object.Destroy(attacker.gameObject);
                return true;
            }

            return false;
        }
    }
}