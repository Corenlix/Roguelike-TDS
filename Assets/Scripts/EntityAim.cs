using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public abstract class EntityAim : MonoBehaviour
{ 
    [SerializeField] private Transform weaponOwner;
    [SerializeField] private Weapon weapon;

    private void Awake()
    {
        ChangeWeapon(weapon);
    }

    protected void RotateToPosition(Vector3 targetPosition)
    {
        Vector3 aimDirection = targetPosition - weapon.transform.position;
        
        float angle = Mathf.Atan2(aimDirection.y, Mathf.Abs(aimDirection.x)) * Mathf.Rad2Deg;
        var weaponRotation = new Vector3(0, 0, angle);
        weapon.transform.localRotation = Quaternion.Euler(weaponRotation);
        weapon.WeaponSpriteRenderer.sortingOrder = aimDirection.y > 0 ? 0 : 2;
        
        Vector3 playerRotation = weaponOwner.rotation.eulerAngles;
        int xScaleModifier = aimDirection.x < 0 ? -1 : 1;
        weaponOwner.localScale = new Vector3(xScaleModifier * Mathf.Abs(weaponOwner.localScale.x), weaponOwner.localScale.y, weaponOwner.localScale.z);
        weaponOwner.rotation = Quaternion.Euler(playerRotation);
    }
    
    public void ChangeWeapon(Weapon newWeapon)
    {
        weapon = newWeapon;
    }
}
