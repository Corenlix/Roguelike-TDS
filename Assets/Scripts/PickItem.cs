using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickItem : MonoBehaviour
{
    [SerializeField] private Player player;
    
    private readonly List<Item> _itemsToPick = new List<Item>();
    private void OnTriggerEnter2D(Collider2D other)
    {
        var item = other.GetComponent<Item>();
        if(item)
            _itemsToPick.Add(item);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        var item = other.GetComponent<Item>();
        if (item)
            _itemsToPick.Remove(item);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _itemsToPick.Count > 0)
        {
            _itemsToPick[0].OnPick(player);
        }
    }
}
