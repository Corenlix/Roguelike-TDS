using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Items;
using TMPro;
using UI;
using UnityEngine;
using UnityEngine.Serialization;

public class ItemPicker : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private PickItemTip pickItemTip;
    [FormerlySerializedAs("pickedItemPopup")] [SerializeField] private PopupSpawner pickedItemPopupSpawner;
    
    private readonly List<Item> _itemsToPick = new List<Item>();

    private void OnTriggerEnter2D(Collider2D other)
    {
        var item = other.GetComponent<Item>();
        if (item)
        {
            if (item.NeedPressPickButton)
            {
                if (item.NeedPressPickButton && _itemsToPick.Count == 0)
                    pickItemTip.ShowTip(item);
                _itemsToPick.Add(item);
            }
            else PickItem(item);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        var item = other.GetComponent<Item>();
        if (item)
        {
            pickItemTip.HideTip();
            _itemsToPick.Remove(item);
        }

        if(_itemsToPick.Count > 0)
            pickItemTip.ShowTip(_itemsToPick[0]);
    }

    private void PickItem(Item item)
    {
        item.OnPick(player);
        pickedItemPopupSpawner.SpawnPopup(transform.position, item.PickText);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && _itemsToPick.Count > 0)
        {
            PickItem(_itemsToPick[0]);
        }
    }
}
