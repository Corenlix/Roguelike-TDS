using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AmmoController))]
public class WeaponsControl : MonoBehaviour
{
    public UnityEvent<Weapon> onWeaponChanged;
    public UnityEvent<Weapon, Vector2> onShoot;
    
    [SerializeField] private int maxWeaponsCount;
    private int _selectedWeaponNumber;
    
    private List<Weapon> weapons = new List<Weapon>();
    private Weapon SelectedWeapon => weapons[_selectedWeaponNumber];
    private AmmoController playerAmmoController;


    public void RotateSelectedWeaponToTarget(Vector2 target)
    {
        SelectedWeapon.RotateWeapon(target);
    }
    
    public bool Attack(Vector2 targetPosition)
    { 
        var selectedWeaponAmmoType = SelectedWeapon.AmmoType;
        if (playerAmmoController.GetAmmoCount(selectedWeaponAmmoType) > 0)
        {
            if (SelectedWeapon.TryShoot(targetPosition))
            {
                playerAmmoController.SubtractAmmo(selectedWeaponAmmoType);
                onShoot?.Invoke(SelectedWeapon, targetPosition - (Vector2)transform.position);
                return true;
            }
        }

        return false;
    }

    private void Awake()
    {
        ResetWeapons();
        playerAmmoController = GetComponent<AmmoController>();
    }
    
    private void ResetWeapons()
    {
        foreach (var weapon in weapons)
        {
            weapon.gameObject.SetActive(false);
        }
        if(weapons.Count > 0)
            SelectWeapon(0);
    }

    public void SwapWeapon()
    {
        if (weapons.Count <= 1)
            return;

        SelectWeapon((_selectedWeaponNumber + 1) % weapons.Count);
    }

    private void SelectWeapon(int weaponNumber)
    {
        var currentWeapon = SelectedWeapon;
        currentWeapon.gameObject.SetActive(false);

        _selectedWeaponNumber = weaponNumber;

        var nextWeapon = SelectedWeapon;
        nextWeapon.transform.rotation = currentWeapon.transform.rotation;
        nextWeapon.gameObject.SetActive(true);
        
        onWeaponChanged?.Invoke(nextWeapon);
    }

    private void RemoveWeapon(Weapon weapon)
    {
        var selectedWeapon = SelectedWeapon;
        
        weapons.Remove(weapon);
        Destroy(weapon.gameObject);

        if (selectedWeapon == weapon)
            SelectWeapon(0);
        else _selectedWeaponNumber = weapons.IndexOf(selectedWeapon);
    }
    public void AddWeapon(Weapon weapon)
    {
        var oldWeaponSameType = weapons.FirstOrDefault(x => x.WeaponType == weapon.WeaponType);

        var newWeapon = Instantiate(weapon, transform.position, Quaternion.identity, transform);
        newWeapon.transform.position = transform.position;
        weapons.Add(newWeapon);
        
        SelectWeapon(weapons.IndexOf(newWeapon));
        
        if (oldWeaponSameType)
            RemoveWeapon(oldWeaponSameType);
        if (weapons.Count > maxWeaponsCount)
        {
            RemoveWeapon(SelectedWeapon);
        }
    }
}
