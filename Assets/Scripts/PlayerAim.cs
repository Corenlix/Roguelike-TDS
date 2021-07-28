using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : EntityAim
{
    private Camera _mainCamera;
    [SerializeField] private PlayerWeaponsControl playerWeaponsControl;
    private void Awake()
    {
        _mainCamera = Camera.main;
    }

    private void OnEnable()
    {
        playerWeaponsControl.onWeaponChanged?.AddListener(ChangeWeapon);
    }

    private void OnDisable()
    {
        playerWeaponsControl.onWeaponChanged?.RemoveListener(ChangeWeapon);
    }

    private void Update()
    {
        Vector3 mousePosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        RotateToPosition(mousePosition);
    }
}
