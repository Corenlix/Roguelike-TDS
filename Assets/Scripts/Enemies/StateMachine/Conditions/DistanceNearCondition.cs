using System;
using UnityEngine;

namespace Enemies.StateMachine.Conditions
{
    public class DistanceNearCondition : Condition
    {
        private Func<Vector2> _positionFunc;
        private Func<Vector2> _targetPositionFunc;
        private float _maxDistanceSquare;
    
        public DistanceNearCondition(Func<Vector2> positionFunc, Func<Vector2> targetPositionFunc, float maxDistance)
        {
            _targetPositionFunc = targetPositionFunc;
            _positionFunc = positionFunc;
            _maxDistanceSquare = maxDistance*maxDistance;
        }
        public override bool IsConditionMet()
        {
            return Vector2.SqrMagnitude(_positionFunc() - _targetPositionFunc()) <= _maxDistanceSquare;
        }
    }
}
