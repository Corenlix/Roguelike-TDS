using System.Collections;
using System.Collections.Generic;
using Helpers;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(WeaponsControl))]
[RequireComponent(typeof(EntityMove))]
public class PlayerControls : MonoBehaviour
{
    public static PlayerControls Instance;
    
    private WeaponsControl weaponsControl;
    private EntityMove moveControl;
    private Camera _mainCamera;
    
    private void Update()
    {
        var mouseWorldPosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        RotateHelper.FlipBodyToPosition(transform, mouseWorldPosition);
        weaponsControl.RotateSelectedWeaponToTarget(mouseWorldPosition);

        Vector2 moveDir = Vector2.zero;
        if (Input.GetKey(KeyCode.A))
            moveDir.x -= 1;
        if (Input.GetKey(KeyCode.D))
            moveDir.x += 1;
        if (Input.GetKey(KeyCode.W))
            moveDir.y += 1;
        if (Input.GetKey(KeyCode.S))
            moveDir.y -= 1;
        
        if(Input.GetMouseButton(0))
            weaponsControl.TryShoot(mouseWorldPosition);

        if (Input.GetKeyDown(KeyCode.Q))
            weaponsControl.SwapWeapon();
        
        moveControl.SetMoveDirection(moveDir);
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
        moveControl = GetComponent<EntityMove>();
        _mainCamera = Camera.main;
    }
}
