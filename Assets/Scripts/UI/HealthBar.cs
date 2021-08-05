using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health healthOwner;
    [SerializeField] private Image healthBar;
    [SerializeField] private TextMeshProUGUI healthText;
    
    private void OnEnable()
    {
        healthOwner.onHealthChanged?.AddListener(UpdateHealthBar);
    }

    private void OnDisable()
    {
        healthOwner.onHealthChanged?.RemoveListener(UpdateHealthBar);
    }

    private void UpdateHealthBar(int health, int maxHealth)
    {
        healthBar.fillAmount = (float)health / maxHealth;
        healthText.text = $"{health}/{maxHealth}";
    }
}
