using System;

namespace BattleSystem.Bullet.Attackers
{
    public class AttackerCreator
    {
        public static Attacker Create(AttackerType attackerType)
        {
            return attackerType switch
            {
                (AttackerType.Default) => new DefaultAttacker(),
                AttackerType.Through => new ThroughAttacker(),
                _ => throw new ArgumentOutOfRangeException(attackerType.ToString())
            };
        }
    }

    public enum AttackerType
    {
        Default,
        Through,
    }
}