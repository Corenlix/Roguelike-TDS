using System;
using System.Collections.Generic;
using Enemies.StateMachine.States;
using UnityEngine;

namespace Enemies.StateMachine
{
    public abstract class EnemyStateMachine : MonoBehaviour
    {
        private State _defaultState;
        private List<State> _states;
        private State _currentState;

        protected void Init(State defaultState, List<State> states)
        {
            _defaultState = defaultState;
            _states = states;
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
            
            if (!_currentState.IsReadyToExit)
                return;
            
            foreach (var state in _states)
            {
                if (state != _currentState && state.IsReadyToEnter)
                {
                    SetActiveState(state);
                    return;
                }
            }
        }

        private void SetActiveState(State state)
        {
            if (_currentState != null)
            {
                _currentState.Exit();
            }

            _currentState = state;
            _currentState.Enter();
        }
    }
}
