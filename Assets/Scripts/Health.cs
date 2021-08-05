using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public UnityEvent<int, int> onHealthChanged;
    public UnityEvent<int> onDamaged;
    public UnityEvent onDied;
        
    [SerializeField] private int maxHealth;
    private int _health;

    public bool DealDamage(int damage)
    {
        _health -= damage;
        onDamaged?.Invoke(damage);
        onHealthChanged?.Invoke(_health, maxHealth);
        PopupsSpawner.Instance.SpawnDamagePopup(transform.position, damage);
        if(_health <= 0)
            OnDied();

        return true;
    }
    private void ResetHealth()
    {
        _health = maxHealth;
        onHealthChanged?.Invoke(_health, maxHealth);
    }
    private void OnDied()
    {
        onDied?.Invoke();
        Destroy(gameObject);
    }

    private void Start()
    {
        ResetHealth();
    }
}
