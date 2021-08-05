using UnityEngine;

namespace EnemyAI
{
    public class DistanceNearCondition : StateCondition
    {
        [SerializeField] private float maxDistance;
        public override bool ConditionMet()
        {
            return Vector2.Distance(transform.position, EnemiesTarget.Instance.GetTargetPosition()) < maxDistance;
        }
    }
}
