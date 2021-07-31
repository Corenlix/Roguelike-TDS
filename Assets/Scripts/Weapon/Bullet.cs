using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    public abstract void Init(Vector2 shootPoint);
}
