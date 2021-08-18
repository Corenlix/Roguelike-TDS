using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticCoroutine : MonoBehaviour
{
    private static StaticCoroutine _instance;
    public static StaticCoroutine Instance{
        get
        {
            if (!_instance)
            {
                var newInstance = new GameObject();
                _instance = newInstance.AddComponent<StaticCoroutine>();
            }
            
            return _instance;
        }
    }
    
    public Coroutine StartRoutine(IEnumerator routine)
    {
        return StartCoroutine(routine);
    }

    private void Awake()
    {
        if (!_instance)
            _instance = this;
        else Destroy(this);
    }
}
