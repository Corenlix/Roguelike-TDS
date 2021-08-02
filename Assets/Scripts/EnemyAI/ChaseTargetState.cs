using System;
using System.Runtime.CompilerServices;
using EnemyAI;
using UnityEngine;

[RequireComponent(typeof(IMovePosition))]
public class ChaseTargetState : EnemyState
{
    [SerializeField] private Transform target;
    private IMovePosition _movePosition;
    private float _time = 2f;
    
    public override void Enter()
    {
        _movePosition = GetComponent<IMovePosition>();
    }
    
    private void Update()
    {
        _time -= Time.deltaTime;
        if (_time > 0)
            return;
        
        _movePosition.SetMovePoint(target.position);
        GetComponent<IAttack>().Attack(target.position);

        _time = 2;
    }

    public override void Exit()
    {
    }
}
