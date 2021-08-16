using System;
using System.Collections.Generic;
using UnityEngine;

namespace BattleSystem
{
    public class AmmoBelt : MonoBehaviour
    {
        public event Action<AmmoType, int> AmmoCountChanged;
    
        private readonly Dictionary<AmmoType, int> _ammoCounts = new Dictionary<AmmoType, int>();

        private void ResetAmmoCount()
        {
            foreach (AmmoType ammoType in Enum.GetValues(typeof(AmmoType)))
            {
                _ammoCounts.Add(ammoType, 0);
                AmmoCountChanged?.Invoke(ammoType, 0);
            }
        }

        private void Awake()
        {
            ResetAmmoCount();
            AddAmmo(AmmoType.Pistol, 50);
        }

        public int GetAmmoCount(AmmoType ammoType)
        {
            return _ammoCounts[ammoType];
        }

        public void SubtractAmmo(AmmoType ammoType, int count = 1)
        {
            _ammoCounts[ammoType] -= count;
            if (_ammoCounts[ammoType] < 0)
                _ammoCounts[ammoType] = 0;
        
            AmmoCountChanged?.Invoke(ammoType, _ammoCounts[ammoType]);
        }

        public void AddAmmo(AmmoType ammoType, int count)
        {
            _ammoCounts[ammoType] += count;
        
            AmmoCountChanged?.Invoke(ammoType, _ammoCounts[ammoType]);
        }
    }
    
    [Serializable]
    public enum AmmoType
    {
        Pistol = 0,
        Rifle = 1,
    }
}