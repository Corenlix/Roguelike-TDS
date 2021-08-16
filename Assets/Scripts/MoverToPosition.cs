using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class MoverToPosition : MonoBehaviour
{
    public abstract event Action MovingEnded;
    public abstract void SetMovePoint(Vector2 position);
    public abstract void Reset();
}
