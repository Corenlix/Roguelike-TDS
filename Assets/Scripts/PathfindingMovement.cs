using System.Collections.Generic;
using LevelGeneration;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(IMoveVelocity))]
public class PathfindingMovement : MonoBehaviour, IMovePosition
{
    private IMoveVelocity _moveVelocity;
    private List<Vector2Int> _pathPoints;

    public event UnityAction MovingEnded;

    private void Awake()
    {
        _moveVelocity = GetComponent<IMoveVelocity>();
    }

    private void Update()
    {
        if (_pathPoints?.Count > 0)
        {
            var direction = _pathPoints[0] - (Vector2)transform.position;
            if (direction.sqrMagnitude < 0.1f)
            {
                _pathPoints.RemoveAt(0);
                if (_pathPoints.Count > 0)
                    direction = _pathPoints[0] - (Vector2) transform.position;
                else
                {
                    direction = Vector2.zero;
                    MovingEnded?.Invoke();
                }
            }

            _moveVelocity.SetVelocityDirection(direction);
        }
    }

    public void SetMovePoint(Vector2 position)
    {
        _pathPoints = LevelHandler.Instance.Pathfinder.FindPath(transform.position, position);
        if(_pathPoints == null)
            MovingEnded?.Invoke();
    }
}
