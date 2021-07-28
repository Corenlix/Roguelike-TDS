using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : EntityMove
{
    void Update()
        {
            MoveDirection = Vector2.zero;
            if (Input.GetKey(KeyCode.W))
                MoveDirection.y += 1; 
            if (Input.GetKey(KeyCode.S))
                MoveDirection.y -= 1; 
            if (Input.GetKey(KeyCode.A))
                MoveDirection.x -= 1; 
            if (Input.GetKey(KeyCode.D))
                MoveDirection.x += 1;
        }
}
