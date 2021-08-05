using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddWeaponAction : ItemAction
{
    [SerializeField] private Weapon weapon;
    public override void Activate(Player player)
    {
        player.AddWeapon(weapon);
    }
}
