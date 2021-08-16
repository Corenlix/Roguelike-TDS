using System;
using System.Collections.Generic;
using UnityEngine;

namespace Enemies.StateMachine.Conditions
{
    public class DistanceFarCondition : Condition
    {
        private Func<Vector2> _positionFunc;
        private Func<Vector2> _targetPositionFunc;
        private float _minDistanceSquare;
    
        public DistanceFarCondition(Func<Vector2> positionFunc, Func<Vector2> targetPositionFunc, float minDistance)
        {
            _targetPositionFunc = targetPositionFunc;
            _positionFunc = positionFunc;
            _minDistanceSquare = minDistance*minDistance;
        }
        public override bool IsConditionMet()
        {
            return Vector2.SqrMagnitude(_positionFunc() - _targetPositionFunc()) > _minDistanceSquare;
        }
    }
}
