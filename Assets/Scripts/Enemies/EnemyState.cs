using System.Collections.Generic;
using UnityEngine;

namespace EnemyAI
{
    public abstract class EnemyState : MonoBehaviour
    {
        [SerializeField] private List<StateCondition> conditionsToEnter;

        public bool IsReadyToTransition()
        {
            foreach (var condition in conditionsToEnter)
            {
                if (!condition.ConditionMet())
                    return false;
            }

            return true;
        }

        public abstract void Enter();
        public abstract void Exit();
    }
}
