using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class OnDestroySpawner : MonoBehaviour
{
    [SerializeField] private GameObject newObject;

    private void OnDestroy()
    {
        Instantiate(newObject, transform.position, transform.rotation);
    }
}