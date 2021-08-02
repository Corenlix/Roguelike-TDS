using System;
using System.Collections.Generic;
using UnityEngine;

public class AmmoController : MonoBehaviour
{
    private readonly Dictionary<WeaponStats.AmmoTypes, int> _ammoCounts = new Dictionary<WeaponStats.AmmoTypes, int>();
    
    private void ResetAmmoCount()
    {
        foreach (WeaponStats.AmmoTypes ammoType in Enum.GetValues(typeof(WeaponStats.AmmoTypes)))
        {
            _ammoCounts.Add(ammoType, 0);
        }
    }
    private void Awake()
    {
        ResetAmmoCount();
        _ammoCounts[WeaponStats.AmmoTypes.Pistol] = 20;
    }

    public int GetAmmoCount(WeaponStats.AmmoTypes ammoType)
    {
        return _ammoCounts[ammoType];
    }

    public void SubtractAmmo(WeaponStats.AmmoTypes ammoType)
    {
        _ammoCounts[ammoType] -= 1;
        if (_ammoCounts[ammoType] < 0)
            _ammoCounts[ammoType] = 0;
    }
}