using System;
using Helpers;
using UnityEngine;

[RequireComponent(typeof(VelocityMove))]
public class Player : MonoBehaviour
{
    [SerializeField] private PlayerAbility activeAbility;
    [SerializeField] private WeaponsControl weaponsControl;
    [SerializeField] private AmmoController ammoController;
    private Camera _mainCamera;

    public void AddAmmo(AmmoType ammoType, int ammoCount)
    {
        ammoController.AddAmmo(ammoType, ammoCount);
    }

    public void AddWeapon(WeaponStats weaponStats)
    {
        weaponsControl.AddWeapon(weaponStats);
    }
    
    private void Update()
    {
        InputControls();
    }

    private void InputControls()
    {
        var mouseWorldPosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        RotateHelper.FlipBodyToPosition(transform, mouseWorldPosition);
        weaponsControl.RotateSelectedWeaponToTarget(mouseWorldPosition);

        if (Input.GetMouseButton(0))
        {
            weaponsControl.Attack(mouseWorldPosition);
        }

        if (Input.GetKeyDown(KeyCode.Q) || Input.GetAxis("Mouse ScrollWheel") != 0)
            weaponsControl.SwapWeapon();
        
        if(Input.GetMouseButton(1))
            activeAbility.TryApplyAbility(mouseWorldPosition);
    }
    private void Awake()
    {
        _mainCamera = Camera.main;
    }

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
        ShakeCamera.Instance.Shake(weapon.ShakeCamForce, weapon.ShakeCamTime, direction);
    }
}
