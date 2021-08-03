using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesTarget : MonoBehaviour
{
    public static EnemiesTarget Instance;
    [SerializeField] private Transform playerTransform;

    public Vector2 GetTargetPosition()
    {
        return playerTransform.transform.position;
    }

    private void Awake()
    {
        if (!Instance)
            Instance = this;
        else Destroy(gameObject);
    }
}
