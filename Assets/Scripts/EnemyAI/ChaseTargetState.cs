using System;
using EnemyAI;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(IMovePosition))]
public class ChaseTargetState : EnemyState
{
    [SerializeField] private float minShootPeriod;
    [SerializeField] private float maxShootPeriod;

    [SerializeField] private float minWalkPeriod;
    [SerializeField] private float maxWalkPeriod;
    
    private IMovePosition _movePosition;
    private IAttack _attack;
    
    private float _timeRemainToShoot;
    private float _timeRemainToWalk;

    private void Awake()
    {
        _movePosition = GetComponent<IMovePosition>();
        _attack = GetComponent<IAttack>();
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
        _timeRemainToShoot -= Time.deltaTime;
        if (_timeRemainToShoot > 0)
            return;
        
        _attack.Attack(EnemiesTarget.Instance.GetTargetPosition());
        _timeRemainToShoot = Random.Range(minShootPeriod, maxShootPeriod);
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
