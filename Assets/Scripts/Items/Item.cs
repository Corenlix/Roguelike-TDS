using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
[RequireComponent(typeof(ItemAction))]
[RequireComponent(typeof(Collider2D))]
public class Item : MonoBehaviour
{
    public string ItemName => itemName;
    [SerializeField] private string itemName;
    public string PickText => pickText;
    [SerializeField] private string pickText;
    public bool NeedPressPickButton => needPressPickButton;
    [SerializeField] private bool needPressPickButton = false;
    
    public void OnPick(Player player)
    {
        foreach (var itemAction in GetComponents<ItemAction>())
        {
            itemAction.Activate(player);
        }
        Destroy(gameObject);
    }
}
