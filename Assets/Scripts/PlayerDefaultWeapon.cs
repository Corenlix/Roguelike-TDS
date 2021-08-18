using System.Collections;
using System.Collections.Generic;
using BattleSystem;
using UnityEngine;

[RequireComponent(typeof(WeaponsControl))]
public class PlayerDefaultWeapon : MonoBehaviour
{
    [SerializeField] private WeaponStats defaultWeapon;
    private void Start()
    {
        GetComponent<WeaponsControl>().AddWeapon(defaultWeapon);
    }
}
