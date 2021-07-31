using UnityEngine;

namespace EnemyAI
{
    public abstract class StateCondition : MonoBehaviour
    {
        [SerializeField] private bool invertedCondition;
        public abstract bool ConditionMet();
    }
}
