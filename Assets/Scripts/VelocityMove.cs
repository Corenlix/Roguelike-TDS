using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class VelocityMove : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private Animator bodyAnimator;
    
    private Vector2 _velocityDirection;
    private Vector2 _outsideForces;
    private Rigidbody2D _rigidbody;
    private static readonly int IsRunningBool = Animator.StringToHash("IsRunning");

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        var velocity = movementSpeed * _velocityDirection;
        _rigidbody.velocity = velocity + _outsideForces;
        bodyAnimator.SetBool(IsRunningBool, velocity != Vector2.zero);
    }
    
    public void SetVelocityDirection(Vector2 direction)
    {
        _velocityDirection = direction.normalized;
    }

    public void AddForce(Vector2 force, float time)
    {
        _outsideForces += force;
        StartCoroutine(RemoveForce(force, time));
    }

    private IEnumerator RemoveForce(Vector2 force, float time)
    {
        yield return new WaitForSeconds(time);
        _outsideForces -= force;
    }
}
