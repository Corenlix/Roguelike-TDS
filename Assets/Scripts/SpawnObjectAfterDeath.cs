using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class SpawnObjectAfterDeath : MonoBehaviour
{
    [SerializeField] private GameObject newObject;
    
    private void OnEnable()
    {
        GetComponent<Health>().onDied?.AddListener(Spawn);
    }

    private void Spawn()
    {
        Instantiate(newObject, transform.position, transform.rotation);
    }
}
