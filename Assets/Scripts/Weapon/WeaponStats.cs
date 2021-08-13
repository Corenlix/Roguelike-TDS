using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class WeaponStats : ScriptableObject
{
    [SerializeField] private Sprite sprite;
    public Sprite Sprite => sprite;
        
    [SerializeField] private AmmoType ammoType;
    public AmmoType AmmoType => ammoType;

    [SerializeField] private WeaponShooterType weaponShooterType;
    public WeaponShooterType WeaponShooterType => weaponShooterType;
    
    [SerializeField] private float reloadTime;
    public float ReloadTime => reloadTime;

    [SerializeField] private Bullet bulletTemplate;
    public Bullet BulletTemplate => bulletTemplate;
    
    [SerializeField] private AttackParams attackParams;
    public AttackParams AttackParams => attackParams;
    
    [SerializeField] private float shakeCamTime;
    public float ShakeCamTime => shakeCamTime;
    
    [SerializeField] private float shakeCamForce;
    public float ShakeCamForce => shakeCamForce;
}
