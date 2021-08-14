using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AmmoController))]
[RequireComponent(typeof(Weapon))]
public class WeaponsControl : MonoBehaviour
{
    public UnityEvent<WeaponStats> onWeaponChanged;
    public UnityEvent<WeaponStats, Vector2> onShoot;

    [SerializeField] private int maxWeaponsCount;
    
    private WeaponStats SelectedWeaponStats => _weaponsStats[_selectedWeaponNumber];
    private Weapon weapon;
    private int _selectedWeaponNumber;
    private readonly List<WeaponStats> _weaponsStats = new List<WeaponStats>();
    private AmmoController playerAmmoController;

    public void RotateSelectedWeaponToTarget(Vector2 target)
    {
        weapon.RotateWeapon(target);
    }
    
    public bool Attack(Vector2 targetPosition)
    { 
        var selectedWeaponAmmoType = SelectedWeaponStats.AmmoType;
        if (playerAmmoController.GetAmmoCount(selectedWeaponAmmoType) > 0)
        {
            if (weapon.TryShoot(targetPosition))
            {
                playerAmmoController.SubtractAmmo(selectedWeaponAmmoType);
                onShoot?.Invoke(SelectedWeaponStats, targetPosition - (Vector2)transform.position);
                return true;
            }
        }

        return false;
    }

    private void Awake()
    {
        weapon = GetComponent<Weapon>();
        playerAmmoController = GetComponent<AmmoController>();
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

        onWeaponChanged?.Invoke(SelectedWeaponStats);
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
        
        _weaponsStats.Add(weaponStats);
        SelectWeapon(_weaponsStats.IndexOf(weaponStats));
    }
}
