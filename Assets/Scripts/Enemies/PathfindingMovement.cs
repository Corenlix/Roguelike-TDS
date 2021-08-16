using System;
using System.Collections.Generic;
using LevelGeneration;
using UnityEngine;

[RequireComponent(typeof(VelocityMover))]
public class PathfindingMovement : MoverToPosition
{
    private VelocityMover moverVelocity;
    private List<Vector2Int> _pathPoints;

    public override event Action MovingEnded;

    private void Awake()
    {
        moverVelocity = GetComponent<VelocityMover>();
    }

    private void Update()
    {
        UpdateVelocity();
    }

    public override void SetMovePoint(Vector2 position)
    {
        if(!moverVelocity)
            moverVelocity = GetComponent<VelocityMover>();
        _pathPoints = LevelHandler.Instance.Pathfinder.FindPath(transform.position, position);
        if(_pathPoints == null)
            Reset();
        else moverVelocity.SetVelocityDirection(GetMoveDirection());
    }

    public override void Reset()
    {
        MovingEnded?.Invoke();
        moverVelocity.SetVelocityDirection(Vector2.zero);
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
                moverVelocity.SetVelocityDirection(direction);
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
