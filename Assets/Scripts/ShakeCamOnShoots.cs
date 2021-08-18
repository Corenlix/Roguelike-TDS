using System;
using System.Collections;
using System.Collections.Generic;
using BattleSystem;
using UnityEngine;

public class ShakeCamOnShoots : MonoBehaviour
{
    [SerializeField] private CameraShaker cameraShaker;
    [SerializeField] private WeaponsControl weaponsControl;

    private void OnEnable()
    {
        weaponsControl.Shot += ShakeCamOnShoot;
    }

    private void OnDisable()
    {
        weaponsControl.Shot -= ShakeCamOnShoot;
    }
    
    private void ShakeCamOnShoot(WeaponStats weapon, Vector2 direction)
    {
        cameraShaker.Shake(weapon.ShakeCamForce, weapon.ShakeCamTime, direction);
    }
}
