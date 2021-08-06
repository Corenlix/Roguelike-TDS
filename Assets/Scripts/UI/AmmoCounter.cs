using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class AmmoCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI countText;
    [SerializeField] private Weapon.AmmoTypes ammoType;
    [SerializeField] private AmmoController ammoController;

    private void OnEnable()
    {
        ammoController.OnAmmoCountChanged?.AddListener(UpdateAmmo);
    }

    private void OnDisable()
    {
        ammoController.OnAmmoCountChanged?.RemoveListener(UpdateAmmo);
    }

    private void UpdateAmmo(Weapon.AmmoTypes eventAmmoType, int count)
    {
        if (eventAmmoType == ammoType)
            countText.text = count.ToString();
    }
}
