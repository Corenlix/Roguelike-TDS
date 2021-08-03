using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    protected const int IgnoreBulletsLayer = 3;
    public abstract void Init(Vector2 shootPoint, int damage, Health.HealthOwnerCategory bulletOwnerCategory);
}
