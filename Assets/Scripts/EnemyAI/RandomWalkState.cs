using UnityEngine;

namespace EnemyAI
{
    [RequireComponent(typeof(IMovePosition))]
    public class RandomWalkState : EnemyState
    {
        private IMovePosition movePosition;
        [SerializeField] private Rect walkingArea; 
        
        public override void Enter()
        {
            movePosition = GetComponent<IMovePosition>();
            movePosition.MovingEnded += MoveToNewPoint;
            MoveToNewPoint();
        }

        private void MoveToNewPoint()
        {
            var newPoint = new Vector2(Random.Range(walkingArea.x, walkingArea.xMax), Random.Range(walkingArea.y, walkingArea.yMax));
            movePosition.SetMovePoint(newPoint);
        }
        public override void Exit()
        {
            movePosition.MovingEnded -= MoveToNewPoint;
        }
    }
}