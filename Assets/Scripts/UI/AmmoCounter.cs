using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class AmmoCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI countText;
    [SerializeField] private AmmoType ammoType;
    [SerializeField] private AmmoController ammoController;

    private void OnEnable()
    {
        ammoController.onAmmoCountChanged?.AddListener(UpdateAmmo);
    }

    private void OnDisable()
    {
        ammoController.onAmmoCountChanged?.RemoveListener(UpdateAmmo);
    }

    private void UpdateAmmo(AmmoType eventAmmoType, int count)
    {
        if (eventAmmoType == ammoType)
            countText.text = count.ToString();
    }
}
