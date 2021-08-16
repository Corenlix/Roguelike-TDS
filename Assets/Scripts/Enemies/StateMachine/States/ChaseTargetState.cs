using Helpers;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemies.StateMachine.States
{
    public class ChaseTargetState : State
    {
        private float _minWalkPeriod;
        private float _maxWalkPeriod;
        private float _timeRemainToWalk;
    
        private MoverToPosition _moverToPosition;
        private EnemyAbility _ability;
        private Transform _transform;

        public ChaseTargetState(Transform transform, MoverToPosition moverToPosition, EnemyAbility enemyAbility, float minWalkPeriod, float maxWalkPeriod)
        {
            _transform = transform;
            _moverToPosition = moverToPosition;
            _ability = enemyAbility;
            _minWalkPeriod = minWalkPeriod;
            _maxWalkPeriod = maxWalkPeriod;
        }

        public override void Enter()
        {
        
        }
    
        public override void Tick()
        {
            TryMove();
            TryAttack();
        }

        private void TryMove()
        {
            _timeRemainToWalk -= Time.deltaTime;
            if (_timeRemainToWalk > 0)
                return;
        
            _moverToPosition.SetMovePoint(GetNewPoint());
            _timeRemainToWalk = Random.Range(_minWalkPeriod, _maxWalkPeriod);
        }

        private void TryAttack()
        {
            var targetPos = EnemiesTarget.Instance.GetTargetPosition();
            RotateHelper.FlipBodyToPosition(_transform, targetPos);

            if (_ability.IsReadyToShoot())
            {
                if(Physics2D.Raycast(_transform.position, targetPos, _ability.LayersToDamage))
                    _ability.Shoot(targetPos);
            }
        }
        private Vector2 GetNewPoint()
        {
            var currentPosition = _transform.position;
            var targetPosition = EnemiesTarget.Instance.GetTargetPosition();
            return new Vector2(Random.Range(Mathf.Min(currentPosition.x, targetPosition.x) - 3, Mathf.Max(currentPosition.x, targetPosition.x) + 3),
                Random.Range(Mathf.Min(currentPosition.y, targetPosition.y) - 3, Mathf.Max(currentPosition.y, targetPosition.y) + 3));
        }
    
        public override void Exit()
        {
            _moverToPosition.Reset();
        }
    }
}
