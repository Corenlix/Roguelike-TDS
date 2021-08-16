using System.Collections.Generic;
using System.Linq;
using Enemies.StateMachine.Conditions;

namespace Enemies.StateMachine.States
{
    public abstract class State
    {
        private List<Condition> _conditionsToEnter;
        private List<Condition> _conditionsToExit;
        
        public bool IsReadyToEnter => _conditionsToEnter?.All(condition => condition.IsConditionMet()) ?? true;
        public bool IsReadyToExit => _conditionsToExit?.All(condition => condition.IsConditionMet()) ?? true;

        public void SetConditions(List<Condition> conditionsToEnter, List<Condition> conditionsToExit)
        {
            _conditionsToEnter = conditionsToEnter;
            _conditionsToExit = conditionsToExit;
        }
        
        public abstract void Enter();
        public abstract void Tick();
        public abstract void Exit();
    }
}
