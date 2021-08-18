using System.Collections;
using System.Collections.Generic;
using Items;
using UnityEngine;

public class AddWeaponCommand : ItemCommand
{
    [SerializeField] private WeaponStats weapon;
    public override void Execute(Player player)
    {
        player.AddWeapon(weapon);
    }
}
