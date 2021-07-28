using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerControls : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    
    private Vector2 _moveDirection;
    private Animator _animator;
    private Rigidbody2D _rigidbody;
    
    private static readonly int IsRunning = Animator.StringToHash("IsRunning");

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _moveDirection = Vector2.zero;
        if (Input.GetKey(KeyCode.W))
            _moveDirection.y += 1; 
        if (Input.GetKey(KeyCode.S))
            _moveDirection.y -= 1; 
        if (Input.GetKey(KeyCode.A))
            _moveDirection.x -= 1; 
        if (Input.GetKey(KeyCode.D))
            _moveDirection.x += 1;
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = _moveDirection.normalized * movementSpeed;
        _animator.SetBool(IsRunning, _rigidbody.velocity.sqrMagnitude > 0);
    }
}
