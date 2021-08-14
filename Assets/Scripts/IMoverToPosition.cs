using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IMoverToPosition
{
    public event UnityAction MovingEnded;
    public void SetMovePoint(Vector2 position);
    public void Reset();
}