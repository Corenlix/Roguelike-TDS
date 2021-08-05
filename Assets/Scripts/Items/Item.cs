using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
[RequireComponent(typeof(ItemAction))]
[RequireComponent(typeof(Collider2D))]
public class Item : MonoBehaviour
{
    [SerializeField] private Sprite sprite;
    [SerializeField] private string itemName;
    [SerializeField] private string description;

    public void OnPick(Player player)
    {
        foreach (var itemAction in GetComponents<ItemAction>())
        {
            itemAction.Activate(player);
        }
        Destroy(gameObject);
    }
}
