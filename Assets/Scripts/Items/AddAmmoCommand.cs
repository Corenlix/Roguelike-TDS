using System;
using System.Collections;
using System.Collections.Generic;
using BattleSystem;
using Items;
using UnityEngine;

public class AddAmmoCommand : ItemCommand
{
    [SerializeField] private int ammoCount;
    [SerializeField] private AmmoType ammoType;
    public override void Execute(Player player)
    {
        player.AddAmmo(ammoType, ammoCount);
    }
}
