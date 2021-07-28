using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class PlayerWeaponsControl : MonoBehaviour
{
    public UnityEvent<Weapon> onWeaponChanged;
    
    [SerializeField] private List<Weapon> weapons;

    private readonly Dictionary<Weapon.AmmoTypes, int> _ammoCounts = new Dictionary<Weapon.AmmoTypes, int>();
    private int _selectedWeaponNumber;

    private void ResetAmmoCount()
    {
        foreach(Weapon.AmmoTypes ammoType in Enum.GetValues(typeof(Weapon.AmmoTypes)) )
        {
            _ammoCounts.Add(ammoType, 0);
        }
    }
    private void Shoot()
    {
        var selectedWeapon = weapons[_selectedWeaponNumber];
        var selectedWeaponAmmoType = selectedWeapon.AmmoType;
        if (_ammoCounts[selectedWeaponAmmoType] > 0)
        {
            if (selectedWeapon.TryShoot())
                _ammoCounts[selectedWeaponAmmoType] -= 1;
        }
    }
    private void ChangeSelectedWeapon()
    {
        if (weapons.Count <= 1)
            return;

        var currentWeapon = weapons[_selectedWeaponNumber];
        currentWeapon.gameObject.SetActive(false);
        
        _selectedWeaponNumber = (_selectedWeaponNumber + 1) % weapons.Count;
        var nextWeapon = weapons[_selectedWeaponNumber];
        nextWeapon.gameObject.SetActive(true);

        onWeaponChanged?.Invoke(nextWeapon);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            ChangeSelectedWeapon();

        if(Input.GetMouseButtonDown(0))
            Shoot();
    }

    private void Start()
    {
        ResetAmmoCount();

        _ammoCounts[Weapon.AmmoTypes.Pistol] = 20;
    }
}
