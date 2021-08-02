using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class VelocityMove : MonoBehaviour, IMoveVelocity
{
    [SerializeField] private float movementSpeed;
    
    private Vector2 _velocityDirection;
    
    [SerializeField] private Animator bodyAnimator;
    
    private Rigidbody2D _rigidbody;
    
    private static readonly int IsRunningAnimationId = Animator.StringToHash("IsRunning");

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        _rigidbody.velocity = _velocityDirection * movementSpeed;
        bodyAnimator.SetBool(IsRunningAnimationId, _rigidbody.velocity.sqrMagnitude > 0);
    }
    
    public void SetVelocityDirection(Vector2 direction)
    {
        _velocityDirection = direction.normalized;
    }
}
