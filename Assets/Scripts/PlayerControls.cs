using System.Collections;
using System.Collections.Generic;
using Helpers;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(WeaponsControl))]
[RequireComponent(typeof(VelocityMove))]
public class PlayerControls : MonoBehaviour
{
    public static PlayerControls Instance;
    private WeaponsControl weaponsControl;
    private Camera _mainCamera;
    
    private void Update()
    {
        var mouseWorldPosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        RotateHelper.FlipBodyToPosition(transform, mouseWorldPosition);
        weaponsControl.RotateSelectedWeaponToTarget(mouseWorldPosition);
        
        if(Input.GetMouseButton(0))
            weaponsControl.Attack(mouseWorldPosition);

        if (Input.GetKeyDown(KeyCode.Q))
            weaponsControl.SwapWeapon();
    }

    private void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        
        weaponsControl = GetComponent<WeaponsControl>();
        _mainCamera = Camera.main;
    }
}
