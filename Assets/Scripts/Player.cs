using System;
using Helpers;
using UnityEngine;

[RequireComponent(typeof(WeaponsControl))]
[RequireComponent(typeof(AmmoController))]
[RequireComponent(typeof(VelocityMove))]
public class Player : MonoBehaviour
{
    private WeaponsControl _weaponsControl;
    private AmmoController _ammoController;
    private Camera _mainCamera;

    public void AddAmmo(Weapon.AmmoTypes ammoType, int ammoCount)
    {
        _ammoController.AddAmmo(ammoType, ammoCount);
    }
    
    private void Update()
    {
        InputControls();
    }

    private void InputControls()
    {
        var mouseWorldPosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        RotateHelper.FlipBodyToPosition(transform, mouseWorldPosition);
        _weaponsControl.RotateSelectedWeaponToTarget(mouseWorldPosition);

        if (Input.GetMouseButton(0))
        {
            _weaponsControl.Attack(mouseWorldPosition);
        }

        if (Input.GetKeyDown(KeyCode.Q))
            _weaponsControl.SwapWeapon();
    }
    private void Awake()
    {
        _weaponsControl = GetComponent<WeaponsControl>();
        _mainCamera = Camera.main;
        _ammoController = GetComponent<AmmoController>();
    }

    private void OnEnable()
    {
        _weaponsControl.onShoot.AddListener(ShakeCamOnShoot);
    }

    private void OnDisable()
    {
        _weaponsControl.onShoot.RemoveListener(ShakeCamOnShoot);
    }

    private void ShakeCamOnShoot(Weapon weapon, Vector2 direction)
    {
        ShakeCamera.Instance.Shake(weapon.ShakeCamForce, weapon.ShakeCamTime, direction);
    }
}
