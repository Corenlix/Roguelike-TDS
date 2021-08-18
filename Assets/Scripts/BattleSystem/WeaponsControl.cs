using System;
using System.Collections.Generic;
using System.Linq;
using UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace BattleSystem
{
    [RequireComponent(typeof(AmmoBelt))]
    [RequireComponent(typeof(Weapon))]
    public class WeaponsControl : MonoBehaviour
    {
        public event Action<WeaponStats> WeaponChanged;
        public event Action<WeaponStats, Vector2> Shot;

        [SerializeField] private int maxWeaponsCount;
        [SerializeField] private PopupSpawner damagePopupSpawner;
    
        private WeaponStats SelectedWeaponStats => _weaponsStats[_selectedWeaponNumber];
        private Weapon weapon;
        private int _selectedWeaponNumber;
        private readonly List<WeaponStats> _weaponsStats = new List<WeaponStats>();
        private AmmoBelt playerAmmoBelt;

        public void RotateSelectedWeaponToTarget(Vector2 target)
        {
            weapon.RotateWeapon(target);
        }
    
        public bool Attack(Vector2 targetPosition)
        { 
            var selectedWeaponAmmoType = SelectedWeaponStats.AmmoType;
            if (playerAmmoBelt.GetAmmoCount(selectedWeaponAmmoType) > 0)
            {
                if (weapon.TryShoot(targetPosition))
                {
                    playerAmmoBelt.SubtractAmmo(selectedWeaponAmmoType);
                    Shot?.Invoke(SelectedWeaponStats, targetPosition - (Vector2)transform.position);
                    return true;
                }
            }

            return false;
        }

        private void Awake()
        {
            weapon = GetComponent<Weapon>();
            playerAmmoBelt = GetComponent<AmmoBelt>();
            ResetWeapons();
        }
    
        private void ResetWeapons()
        {
            if(_weaponsStats.Count > 0)
                SelectWeapon(0);
        }

        public void SwapWeapon()
        {
            if (_weaponsStats.Count <= 1)
                return;

            SelectWeapon((_selectedWeaponNumber + 1) % _weaponsStats.Count);
        }

        private void SelectWeapon(int weaponNumber)
        {
            _selectedWeaponNumber = weaponNumber;
            weapon.ChangeWeaponStats(SelectedWeaponStats);

            WeaponChanged?.Invoke(SelectedWeaponStats);
        }

        private void RemoveWeapon(WeaponStats removingWeaponStats)
        {
            WeaponStats selectedWeaponStats = SelectedWeaponStats;
        
            _weaponsStats.Remove(removingWeaponStats);

            int newWeaponNumber = selectedWeaponStats == removingWeaponStats ? 0 : _weaponsStats.IndexOf(selectedWeaponStats);
            SelectWeapon(newWeaponNumber);
        }

        public void AddWeapon(WeaponStats weaponStats)
        {
            var oldWeaponSameType = _weaponsStats.FirstOrDefault(x => x == weaponStats);
            if (oldWeaponSameType)
                return;

            if (_weaponsStats.Count == maxWeaponsCount)
                RemoveWeapon(SelectedWeaponStats);
        
            weaponStats.AttackParams.SetPopupSpawner(damagePopupSpawner);
            _weaponsStats.Add(weaponStats);
            SelectWeapon(_weaponsStats.IndexOf(weaponStats));
        }
    }
}
