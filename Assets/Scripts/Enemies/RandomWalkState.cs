using System;
using Helpers;
using UnityEngine;
using Random = UnityEngine.Random;

namespace EnemyAI
{
    [RequireComponent(typeof(IMoverToPosition))]
    public class RandomWalkState : EnemyState
    {
        private IMoverToPosition moverToPosition;
        [SerializeField] private int walkDistance;
        private float time = 2;
        
        public override void Enter()
        {
            moverToPosition = GetComponent<IMoverToPosition>();
            MoveToNewPoint();
        }

        private void Update()
        {
            
            time -= Time.deltaTime;
            if (time > 0)
                return;

            MoveToNewPoint();
            time = 2;
        }

        private void MoveToNewPoint()
        {
            Vector2 newPoint = transform.position; 
            newPoint += new Vector2(Random.Range(-walkDistance, walkDistance), Random.Range(-walkDistance, walkDistance));
            moverToPosition.SetMovePoint(newPoint);
            RotateHelper.FlipBodyToPosition(transform, newPoint);
        }
        public override void Exit()
        {
            moverToPosition.Reset();
        }
    }
}