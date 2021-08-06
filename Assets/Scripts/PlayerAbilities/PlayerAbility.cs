using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerAbility : MonoBehaviour
{
    [SerializeField] private float reloadTime;
    private float _remainReloadTime;

    public void TryApplyAbility(Vector2 aimPosition)
    {
        if (_remainReloadTime <= 0)
        {
            ApplyAbility(aimPosition);
            _remainReloadTime = reloadTime;
        }
    }

    private void Update()
    {
        _remainReloadTime -= Time.deltaTime;
    }

    protected abstract void ApplyAbility(Vector2 aimPosition);
}
