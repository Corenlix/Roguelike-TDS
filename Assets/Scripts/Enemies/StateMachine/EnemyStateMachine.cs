using Enemies.StateMachine.States;
using UnityEngine;

namespace Enemies.StateMachine
{
    public abstract class EnemyStateMachine : MonoBehaviour
    {
        private State _defaultState;
        private State _currentState;

        protected void Init(State defaultState)
        {
            _defaultState = defaultState;
        }
        
        private void OnEnable()
        {
            SetActiveState(_defaultState);
        }
        private void OnDisable()
        {
            _defaultState.Exit();
        }

        private void Update()
        {
            _currentState.Tick();

            if (_currentState.IsReadyToTransit(out State nextState))
            {
                SetActiveState(nextState);
            }
        }

        private void SetActiveState(State state)
        {
            if (state == null) return;
            _currentState?.Exit();
            _currentState = state;
            _currentState.Enter();
        }
    }
}
