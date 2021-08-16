using BattleSystem;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace UI
{
    public class AmmoCounter : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI countText;
        [SerializeField] private AmmoType ammoType;
        [SerializeField] private AmmoBelt ammoBelt;

        private void OnEnable()
        {
            ammoBelt.AmmoCountChanged += UpdateAmmo;
        }

        private void OnDisable()
        {
            ammoBelt.AmmoCountChanged -= UpdateAmmo;
        }

        private void UpdateAmmo(AmmoType eventAmmoType, int count)
        {
            if (eventAmmoType == ammoType)
                countText.text = count.ToString();
        }
    }
}
