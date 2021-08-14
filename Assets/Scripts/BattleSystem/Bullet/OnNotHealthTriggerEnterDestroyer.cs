using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class OnNotHealthTriggerEnterDestroyer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(!other.GetComponent<Health>() && !other.isTrigger)
            Destroy(gameObject);
    }
}