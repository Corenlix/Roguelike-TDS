using UnityEngine;

namespace EnemyAI
{
    public class DistanceNearCondition : StateCondition
    {
        [SerializeField] private float maxDistance;
        public override bool ConditionMet()
        {
            return Vector2.Distance(transform.position, PlayerControls.Instance.transform.position) < maxDistance;
        }
    }
}
