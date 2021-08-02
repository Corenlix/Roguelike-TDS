using UnityEngine;

namespace EnemyAI
{
    public abstract class StateCondition : MonoBehaviour
    {
        public abstract bool ConditionMet();
    }
}
