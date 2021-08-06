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
        tipText.gameObject.SetActive(true);
        tipText.text = $"[E] {item.ItemName}";
        tipText.transform.position = item.transform.position;
    }

    public void HideTip()
    {
        tipText.gameObject.SetActive(false);
    }

    private void Awake()
    {
        HideTip();
    }
}
