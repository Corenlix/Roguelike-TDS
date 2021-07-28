using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private CameraFollow cameraFollow;
    [SerializeField] private Vector3 offset;

    [SerializeField] private float cursorWeight = 1;
    [SerializeField] private float playerWeight = 2;

    private void Start()
    {
        cameraFollow.SetGetFollowPointFunc((() =>
        {
            var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            return (mousePosition * cursorWeight + player.position * playerWeight) / (playerWeight + cursorWeight);
        }));
    }
    
    
}
