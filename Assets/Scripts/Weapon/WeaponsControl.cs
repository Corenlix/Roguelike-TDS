using System.Collections.Generic;
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
        _selectedWeaponNumber = 0;
        SwapWeapon();
    }

    public void SwapWeapon()
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

    public void AddWeapon(Weapon weapon)
    {
        if (weapons.Count < maxWeaponsCount)
        {
            var newWeapon = Instantiate(weapon, transform.position, Quaternion.identity, transform);
            newWeapon.transform.position = transform.position;
            weapons.Add(newWeapon);
            SwapWeapon();
        }
    }
}
