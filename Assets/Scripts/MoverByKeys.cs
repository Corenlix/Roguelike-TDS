using System;
using UnityEngine;

[RequireComponent(typeof(VelocityMover))]
public class MoverByKeys : MonoBehaviour
{
    private VelocityMover moverVelocity;

    private void Awake()
    {
        moverVelocity = GetComponent<VelocityMover>();
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
        
        moverVelocity.SetVelocityDirection(moveDir);
    }
}
