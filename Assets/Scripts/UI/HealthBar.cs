using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Health healthOwner;
        [SerializeField] private Image healthBar;
        [SerializeField] private TextMeshProUGUI healthText;
    
        private void OnEnable()
        {
            healthOwner.HealthChanged += UpdateHealthBar;
        }

        private void OnDisable()
        {
            healthOwner.HealthChanged -= UpdateHealthBar;
        }

        private void UpdateHealthBar(int health, int maxHealth)
        {
            healthBar.fillAmount = (float)health / maxHealth;
            healthText.text = $"{health}/{maxHealth}";
        }
    }
}
