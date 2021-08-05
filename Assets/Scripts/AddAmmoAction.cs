using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddAmmoAction : ItemAction
{
    [SerializeField] private int ammoCount;
    [SerializeField] private Weapon.AmmoTypes ammoType;
    public override void Activate(Player player)
    {
        player.AddAmmo(ammoType, ammoCount);
    }
}
