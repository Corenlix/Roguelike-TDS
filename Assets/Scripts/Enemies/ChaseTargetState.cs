using System;
using EnemyAI;
using Helpers;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(IMovePosition))]
public class ChaseTargetState : EnemyState
{
    [SerializeField] private float minWalkPeriod;
    [SerializeField] private float maxWalkPeriod;
    
    private IMovePosition _movePosition;
    private EnemyAbility ability;
    
    private float _timeRemainToWalk;

    private void Awake()
    {
        _movePosition = GetComponent<IMovePosition>();
        ability = GetComponentInChildren<EnemyAbility>();
    }

    public override void Enter()
    {
        
    }
    
    private void Update()
    {
        TryMove();
        TryAttack();
    }

    private void TryMove()
    {
        _timeRemainToWalk -= Time.deltaTime;
        if (_timeRemainToWalk > 0)
            return;
        
        _movePosition.SetMovePoint(GetNewPoint());
        _timeRemainToWalk = Random.Range(minWalkPeriod, maxWalkPeriod);
    }

    private void TryAttack()
    {
        var targetPos = EnemiesTarget.Instance.GetTargetPosition();
        RotateHelper.FlipBodyToPosition(transform, targetPos);

        if (ability.IsReadyToShoot())
        {
            if(Physics2D.Raycast(transform.position, targetPos, ability.LayersToDamage))
                ability.Shoot(targetPos);
        }
    }
    private Vector2 GetNewPoint()
    {
        var currentPosition = transform.position;
        var targetPosition = EnemiesTarget.Instance.GetTargetPosition();
        return new Vector2(Random.Range(Mathf.Min(currentPosition.x, targetPosition.x) - 3, Mathf.Max(currentPosition.x, targetPosition.x) + 3),
            Random.Range(Mathf.Min(currentPosition.y, targetPosition.y) - 3, Mathf.Max(currentPosition.y, targetPosition.y) + 3));
    }
    
    public override void Exit()
    {
    }
}
