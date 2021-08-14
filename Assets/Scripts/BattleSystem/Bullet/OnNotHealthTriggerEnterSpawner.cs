using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnNotHealthTriggerEnterSpawner : MonoBehaviour
{
    [SerializeField] private GameObject objectTemplate;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.GetComponent<Health>() && !other.isTrigger)
            Instantiate(objectTemplate, transform.position, transform.rotation);
    }
}
