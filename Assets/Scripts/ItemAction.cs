using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Item))]
public abstract class ItemAction : MonoBehaviour
{
    public abstract void Activate(Player player);
}
