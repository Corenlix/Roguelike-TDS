using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(WeaponsControl))]
public class PlayerDefaultWeapon : MonoBehaviour
{
    [SerializeField] private Weapon defaultWeapon;
    private void Start()
    {
        GetComponent<WeaponsControl>().AddWeapon(defaultWeapon);
    }
}
