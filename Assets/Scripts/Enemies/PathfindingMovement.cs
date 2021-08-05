using System.Collections.Generic;
using LevelGeneration;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(VelocityMove))]
public class PathfindingMovement : MonoBehaviour, IMovePosition
{
    private VelocityMove _moveVelocity;
    private List<Vector2Int> _pathPoints;

    public event UnityAction MovingEnded;

    private void Awake()
    {
        _moveVelocity = GetComponent<VelocityMove>();
    }

    private void Update()
    {
        UpdateVelocity();
    }

    public Vector2 curPoint;
    public void SetMovePoint(Vector2 position)
    {
        curPoint = position;
        if(!_moveVelocity)
            _moveVelocity = GetComponent<VelocityMove>();
        _pathPoints = LevelHandler.Instance.Pathfinder.FindPath(transform.position, position);
        if(_pathPoints == null)
            Reset();
        else _moveVelocity.SetVelocityDirection(GetMoveDirection());
    }

    public void Reset()
    {
        MovingEnded?.Invoke();
        _moveVelocity.SetVelocityDirection(Vector2.zero);
        _pathPoints = null;
    }
    private void UpdateVelocity()
    {
        if (_pathPoints == null || _pathPoints.Count == 0) return;
        var direction = GetMoveDirection();
        if (direction.sqrMagnitude < 0.1f)
        {
            _pathPoints.RemoveAt(0);
            if (_pathPoints.Count > 0)
            {
                direction = GetMoveDirection();
                _moveVelocity.SetVelocityDirection(direction);
            }
            else
                Reset();
        }
    }

    private Vector2 GetMoveDirection()
    {
        return _pathPoints[0] - (Vector2) transform.position;
    }
}
