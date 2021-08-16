using Helpers;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemies.StateMachine.States
{
    public class RandomWalkState : State
    {
        private MoverToPosition _moverToPosition;
        private Transform _transform;
        private int _walkDistance;
        private float _walkPeriod;
        private float _timeToWalk;

        public RandomWalkState(Transform transform, MoverToPosition moverToPosition, int walkDistance, float walkPeriod)
        {
            _transform = transform;
            _moverToPosition = moverToPosition;
            _walkDistance = walkDistance;
            _walkPeriod = walkPeriod;
        }
        
        public override void Enter()
        {
            MoveToNewPoint();
            _timeToWalk = _walkPeriod;
        }

        public override void Tick()
        {
            
            _timeToWalk -= Time.deltaTime;
            if (_timeToWalk > 0)
                return;

            MoveToNewPoint();
            _timeToWalk = _walkPeriod;
        }

        private void MoveToNewPoint()
        {
            Vector2 newPoint = _transform.position; 
            newPoint += new Vector2(Random.Range(-_walkDistance, _walkDistance), Random.Range(-_walkDistance, _walkDistance));
            _moverToPosition.SetMovePoint(newPoint);
            RotateHelper.FlipBodyToPosition(_transform, newPoint);
        }
        public override void Exit()
        {
            _moverToPosition.Reset();
        }
    }
}