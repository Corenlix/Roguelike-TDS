using System.Collections.Generic;
using Enemies.StateMachine.Conditions;
using Enemies.StateMachine.States;
using UnityEngine;

namespace Enemies.StateMachine
{
    public class RangeEnemy : EnemyStateMachine
    {
        [Header("Random Walk State")]
        [SerializeField] private int randomWalkDistance;
        [SerializeField] private float randomWalkPeriod;

        [Header("Chase State")] 
        [SerializeField] private float enterChaseStateDistance;
        [SerializeField] private float chaseMinPeriod;
        [SerializeField] private float chaseMaxPeriod;
        [SerializeField] private EnemyAbility enemyAbility;
        [SerializeField] private float exitChaseStateDistance;
        
        [SerializeReference] private MoverToPosition moverToPosition;
        
        private void Awake()
        {
            var randomWalkState = new RandomWalkState(transform, moverToPosition, randomWalkDistance, randomWalkPeriod);
            var farCondition = new DistanceFarCondition(() => transform.position,
                EnemiesTarget.Instance.GetTargetPosition, exitChaseStateDistance);
            
            var chaseState = new ChaseTargetState(transform, EnemiesTarget.Instance.GetTargetPosition, moverToPosition, enemyAbility, chaseMinPeriod, chaseMaxPeriod);
            var nearCondition = new DistanceNearCondition(() => transform.position,
                EnemiesTarget.Instance.GetTargetPosition, enterChaseStateDistance);
            
            randomWalkState.SetTransitions(new Transition(chaseState, nearCondition));
            chaseState.SetTransitions(new Transition(randomWalkState, farCondition));

            Init(randomWalkState);
        }
    }
}
