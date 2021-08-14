using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(VelocityMover))]
public class MoverToPosition : MonoBehaviour, IMoverToPosition
{
    private VelocityMover moverVelocity;
    private Vector2? _movePoint;


    public event UnityAction MovingEnded;

    public void SetMovePoint(Vector2 position)
    {
        _movePoint = position;
    }
    
    private void Awake()
    {
        moverVelocity = GetComponent<VelocityMover>();
        _movePoint = transform.position;
    }

    private void Update()
    {
        if (_movePoint == null)
            return;
        
        var direction = (Vector2)_movePoint - (Vector2) transform.position;
        if (direction.sqrMagnitude < 0.1f)
        {
            direction = Vector2.zero;
            _movePoint = null;
            MovingEnded?.Invoke();
        }

        moverVelocity.SetVelocityDirection(direction);
    }

    public void Reset()
    {
        _movePoint = null;
        moverVelocity.SetVelocityDirection(Vector2.zero);
    }
}
