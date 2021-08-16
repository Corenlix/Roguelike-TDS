using UnityEngine;

namespace BattleSystem.Bullet.TargetInteractiveCheckers
{
    public abstract class TargetInteractiveChecker
    {
        public abstract bool IsTargetInteractive(GameObject target);
    }
}