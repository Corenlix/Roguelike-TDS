using System;
using UnityEngine;

[RequireComponent(typeof(VelocityMove))]
public class MoveByKeys : MonoBehaviour
{
    private VelocityMove _moveVelocity;

    private void Awake()
    {
        _moveVelocity = GetComponent<VelocityMove>();
    }

    private void Update()
    {
        Vector2 moveDir = Vector2.zero;
        if (Input.GetKey(KeyCode.A))
            moveDir.x -= 1;
        if (Input.GetKey(KeyCode.D))
            moveDir.x += 1;
        if (Input.GetKey(KeyCode.W))
            moveDir.y += 1;
        if (Input.GetKey(KeyCode.S))
            moveDir.y -= 1;
        
        _moveVelocity.SetVelocityDirection(moveDir);
    }
}
