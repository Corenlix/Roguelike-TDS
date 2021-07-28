using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    private void Start()
    {
        GetComponent<Rigidbody2D>().velocity = transform.right * speed;
    }
}
