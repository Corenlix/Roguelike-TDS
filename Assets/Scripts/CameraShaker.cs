using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

[RequireComponent(typeof(CinemachineVirtualCamera))]
public class CameraShaker : MonoBehaviour
{
    public static CameraShaker Instance;
    
    private CinemachineFramingTransposer _cinemachineFramingTransposer;
    private CinemachineBasicMultiChannelPerlin _cinemachinePerlin;
    private float _shakeTime;
    private float _remainShakeTime;
    private float _intensity;
    private Vector2 _direction;
    
    private void Awake()
    {
        if(Instance)
            Destroy(Instance.gameObject);
        Instance = this;
        
        var cinemachine = GetComponent<CinemachineVirtualCamera>();
        _cinemachineFramingTransposer = cinemachine.GetCinemachineComponent<CinemachineFramingTransposer>();
        _cinemachinePerlin = cinemachine.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    public void Shake(float intensity, float time, Vector2 direction)
    {
        _remainShakeTime = time;
        _shakeTime = time;
        _intensity = intensity;
        _direction = direction.normalized;
    }
    private void Update()
    {
        if (_remainShakeTime > 0)
        {
            _remainShakeTime -= Time.deltaTime;
            var currentIntensity = Mathf.Lerp(_intensity, 0f, 1 - (_remainShakeTime / _shakeTime));;
            _cinemachineFramingTransposer.m_ScreenX = _direction.x * currentIntensity + 0.5f;
            _cinemachineFramingTransposer.m_ScreenY = - _direction.y * currentIntensity + 0.5f;
            _cinemachinePerlin.m_AmplitudeGain = currentIntensity * 25;
        }
    }
}
