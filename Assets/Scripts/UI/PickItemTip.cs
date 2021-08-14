using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PickItemTip : MonoBehaviour
{
    [SerializeField] private TextMeshPro tipText;
    public void ShowTip(Item item)
    {
        gameObject.SetActive(true);
        tipText.text = $"[E] {item.ItemName}";
        tipText.transform.position = item.transform.position;
    }

    public void HideTip()
    {
        gameObject.SetActive(false);
    }

    private void Start()
    {
        HideTip();
    }
}
