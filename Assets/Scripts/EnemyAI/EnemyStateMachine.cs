using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace EnemyAI
{
    [RequireComponent(typeof(EnemyState))]
    public class EnemyStateMachine : MonoBehaviour
    {
        [SerializeField] private EnemyState defaultEnemyState;
        private List<EnemyState> _states;
        private EnemyState _currentState;
    
        private void OnEnable()
        {
            _states = GetComponents<EnemyState>().ToList();
            _states.ForEach(x=>x.enabled = false);
            SetActiveState(defaultEnemyState);
        }
        private void OnDisable()
        {
            defaultEnemyState.Exit();
        }

        private void Update()
        {
            foreach (var state in _states)
            {
                if (state != _currentState && state.IsReadyToTransition())
                {
                    SetActiveState(state);
                    return;
                }
            }
        }

        private void SetActiveState(EnemyState state)
        {
            if (_currentState)
            {
                _currentState.Exit();
                _currentState.enabled = false;
            }

            _currentState = state;
            _currentState.enabled = true;
            _currentState.Enter();
        }
    }
}
