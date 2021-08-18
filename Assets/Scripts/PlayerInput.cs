using System.Collections;
using System.Collections.Generic;
using BattleSystem;
using Helpers;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private WeaponsControl weaponsControl;
    [SerializeField] private PlayerAbility activeAbility;
    private Camera _mainCamera;
    
    private void Awake()
    {
        _mainCamera = Camera.main;
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
}
