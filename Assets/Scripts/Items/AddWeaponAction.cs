using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddWeaponAction : ItemAction
{
    [SerializeField] private WeaponStats weapon;
    public override void Activate(Player player)
    {
        player.AddWeapon(weapon);
    }
}
