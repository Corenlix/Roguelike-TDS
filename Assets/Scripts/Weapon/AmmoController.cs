using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AmmoController : MonoBehaviour
{
    public UnityEvent<AmmoType, int> onAmmoCountChanged;
    
    private readonly Dictionary<AmmoType, int> _ammoCounts = new Dictionary<AmmoType, int>();

    private void ResetAmmoCount()
    {
        foreach (AmmoType ammoType in Enum.GetValues(typeof(AmmoType)))
        {
            _ammoCounts.Add(ammoType, 0);
            onAmmoCountChanged?.Invoke(ammoType, 0);
        }
    }

    private void Awake()
    {
        ResetAmmoCount();
        AddAmmo(AmmoType.Pistol, 50);
        AddAmmo(AmmoType.Rifle, 20);
    }

    public int GetAmmoCount(AmmoType ammoType)
    {
        return _ammoCounts[ammoType];
    }

    public void SubtractAmmo(AmmoType ammoType)
    {
        _ammoCounts[ammoType] -= 1;
        if (_ammoCounts[ammoType] < 0)
            _ammoCounts[ammoType] = 0;
        
        onAmmoCountChanged?.Invoke(ammoType, _ammoCounts[ammoType]);
    }

    public void AddAmmo(AmmoType ammoType, int count)
    {
        _ammoCounts[ammoType] += count;
        
        onAmmoCountChanged?.Invoke(ammoType, _ammoCounts[ammoType]);
    }
}
[Serializable]
public enum AmmoType
{
    Pistol = 0,
    Rifle = 1,
}
