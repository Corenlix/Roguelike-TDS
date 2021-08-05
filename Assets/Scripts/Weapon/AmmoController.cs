using System;
using System.Collections.Generic;
using UnityEngine;

public class AmmoController : MonoBehaviour
{
    private readonly Dictionary<Weapon.AmmoTypes, int> _ammoCounts = new Dictionary<Weapon.AmmoTypes, int>();

    private void ResetAmmoCount()
    {
        foreach (Weapon.AmmoTypes ammoType in Enum.GetValues(typeof(Weapon.AmmoTypes)))
        {
            _ammoCounts.Add(ammoType, 0);
        }
    }

    private void Awake()
    {
        ResetAmmoCount();
        _ammoCounts[Weapon.AmmoTypes.Pistol] = 20;
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
    }

    public void AddAmmo(Weapon.AmmoTypes ammoType, int count)
    {
        _ammoCounts[ammoType] += count;
    }

}
