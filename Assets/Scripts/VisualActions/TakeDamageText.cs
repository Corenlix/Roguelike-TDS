using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class TakeDamageText : MonoBehaviour
{
    private void OnEnable()
        {
            GetComponent<Health>().onDamaged?.AddListener(ShowPopup);
        }
    
        private void OnDisable()
        {
            GetComponent<Health>().onDamaged?.RemoveListener(ShowPopup);
        }
    
        private void ShowPopup(int damage)
        {
            DamagePopupSpawner.Instance.SpawnDamagePopup(transform.position, damage);
        }
}
