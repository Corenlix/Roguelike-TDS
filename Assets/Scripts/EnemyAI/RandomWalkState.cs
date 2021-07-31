using UnityEngine;

namespace EnemyAI
{
    public class RandomWalkState : EnemyState
    {
        public override void Enter()
        {
            //play walk animation
        }

        private void Update()
        {
            transform.Translate(0, Time.deltaTime * 2, 0);
        }
        public override void Exit()
        {
        }
    }
}