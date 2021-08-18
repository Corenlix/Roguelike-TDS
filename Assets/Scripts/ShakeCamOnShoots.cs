using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeCamOnShoots : MonoBehaviour
{
    [SerializeField] private CameraShaker cameraShaker;
    [SerializeField] private WeaponsControl weaponsControl;

    private void OnEnable()
    {
        weaponsControl.onShoot.AddListener(ShakeCamOnShoot);
    }

    private void OnDisable()
    {
        weaponsControl.onShoot.RemoveListener(ShakeCamOnShoot);
    }
    
    private void ShakeCamOnShoot(WeaponStats weapon, Vector2 direction)
    {
        cameraShaker.Shake(weapon.ShakeCamForce, weapon.ShakeCamTime, direction);
    }
}
