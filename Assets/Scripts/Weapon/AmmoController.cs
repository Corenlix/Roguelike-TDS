using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AmmoController : MonoBehaviour
{
    public UnityEvent<Weapon.AmmoTypes, int> OnAmmoCountChanged;
    
    private readonly Dictionary<Weapon.AmmoTypes, int> _ammoCounts = new Dictionary<Weapon.AmmoTypes, int>();

    private void ResetAmmoCount()
    {
        foreach (Weapon.AmmoTypes ammoType in Enum.GetValues(typeof(Weapon.AmmoTypes)))
        {
            _ammoCounts.Add(ammoType, 0);
            OnAmmoCountChanged?.Invoke(ammoType, 0);
        }
    }

    private void Awake()
    {
        ResetAmmoCount();
        AddAmmo(Weapon.AmmoTypes.Pistol, 50);
        AddAmmo(Weapon.AmmoTypes.Rifle, 20);
    }

    public int GetAmmoCount(Weapon.AmmoTypes ammoType)
    {
        return _ammoCounts[ammoType];
    }

    public void SubtractAmmo(Weapon.AmmoTypes ammoType)
    {
        _ammoCounts[ammoType] -= 1;
        if (_ammoCounts[ammoType] < 0)
            _ammoCounts[ammoType] = 0;
        
        OnAmmoCountChanged?.Invoke(ammoType, _ammoCounts[ammoType]);
    }

    public void AddAmmo(Weapon.AmmoTypes ammoType, int count)
    {
        _ammoCounts[ammoType] += count;
        
        OnAmmoCountChanged?.Invoke(ammoType, _ammoCounts[ammoType]);
    }

}
