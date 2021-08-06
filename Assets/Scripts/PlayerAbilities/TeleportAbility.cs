using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportAbility : PlayerAbility
{
    [SerializeField] private float distance;
    [SerializeField] private LayerMask obstaclesLayers;
    [SerializeField] private Rigidbody2D rigidbody;
    protected override void ApplyAbility(Vector2 aimPosition)
    {
        var direction = aimPosition - (Vector2) transform.position;
        var hit = Physics2D.Raycast(transform.position, direction, distance, obstaclesLayers);
        if(hit)
        {
            Teleport(hit.point);
        }
        else Teleport((Vector2)transform.position + direction.normalized*distance);
    }

    private void Teleport(Vector2 position)
    {
        rigidbody.MovePosition(position);
    }
}
