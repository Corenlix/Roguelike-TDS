using Enemies.StateMachine.Conditions;
using Enemies.StateMachine.States;
using UnityEngine;

namespace Enemies.StateMachine
{
    public class MeleeEnemy : EnemyStateMachine
    {
        [Header("Random Walk State")]
        [SerializeField] private int randomWalkDistance;
        [SerializeField] private float randomWalkPeriod;

        [Header("Chase State")] 
        [SerializeField] private float enterChaseStateDistance;
        [SerializeField] private float exitChaseStateDistance;
    
        [SerializeReference] private MoverToPosition moverToPosition;
    
        private void Awake()
        {
            var randomWalkState = new RandomWalkState(transform, moverToPosition, randomWalkDistance, randomWalkPeriod);
            var nearCondition = new DistanceNearCondition(() => transform.position,
                EnemiesTarget.Instance.GetTargetPosition, enterChaseStateDistance);
            
            
            var chaseState = new MeleeTargetChaseState(transform, moverToPosition, EnemiesTarget.Instance.GetTargetPosition);
            var farCondition = new DistanceFarCondition(() => transform.position,
                EnemiesTarget.Instance.GetTargetPosition, exitChaseStateDistance);
            
            randomWalkState.SetTransitions(new Transition(chaseState, nearCondition));
            chaseState.SetTransitions(new Transition(randomWalkState, farCondition));
        
            Init(randomWalkState);
        }
    }
}
