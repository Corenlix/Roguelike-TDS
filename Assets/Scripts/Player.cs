using System;
using BattleSystem;
using Helpers;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(VelocityMover))]
public class Player : MonoBehaviour
{
    [SerializeField] private WeaponsControl weaponsControl;
    [SerializeField] private AmmoBelt ammoBelt;
    

    public void AddAmmo(AmmoType ammoType, int ammoCount)
    {
        ammoBelt.AddAmmo(ammoType, ammoCount);
    }

    public void AddWeapon(WeaponStats weaponStats)
    {
        weaponsControl.AddWeapon(weaponStats);
    }

    
}
