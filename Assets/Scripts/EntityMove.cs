using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EntityMove : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    
    protected Vector2 MoveDirection;
    
    [SerializeField] private Animator bodyAnimator;
    
    private Rigidbody2D _rigidbody;
    
    private static readonly int IsRunningAnimationId = Animator.StringToHash("IsRunning");

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    
    private void FixedUpdate()
    {
        _rigidbody.velocity = MoveDirection.normalized * movementSpeed;
        bodyAnimator.SetBool(IsRunningAnimationId, _rigidbody.velocity.sqrMagnitude > 0);
    }
}
