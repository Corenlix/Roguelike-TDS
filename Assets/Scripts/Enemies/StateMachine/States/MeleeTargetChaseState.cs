using System;
using Helpers;
using TMPro;
using UnityEngine;

namespace Enemies.StateMachine.States
{
    public class MeleeTargetChaseState : State
    {
        private Transform _transform;
        private MoverToPosition _moverToPosition;
        private Func<Vector2> _targetPositionFunc;
        
        public MeleeTargetChaseState(Transform transform, MoverToPosition moverToPosition, Func<Vector2> targetPositionFunc)
        {
            _transform = transform;
            _moverToPosition = moverToPosition;
            _targetPositionFunc = targetPositionFunc;
        }

        public override void Enter()
        {
        
        }
    
        public override void Tick()
        {
            TryMove();
        }

        private void TryMove()
        {
            Vector2 targetPoint = _targetPositionFunc();
            _moverToPosition.SetMovePoint(targetPoint);
            RotateHelper.FlipBodyToPosition(_transform,targetPoint);
        }
        
        public override void Exit()
        {
            _moverToPosition.Reset();
        }
    }
}