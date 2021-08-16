using UnityEngine;

namespace BattleSystem.Bullet.Attackers
{
    public class ThroughAttacker : Attacker
    {
        public override bool TryAttack(Transform attacker, Collider2D target, AttackParams attackParams)
        {
            return DealDamage(attacker, target, attackParams);
        }
    }
}