using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class Health : MonoBehaviour
{
    public event Action<int,int> HealthChanged;
    public event Action<int> Damaged;
    public event Action Died;
        
    [SerializeField] private int maxHealth;
    private int _health;

    public bool DealDamage(int damage)
    {
        _health -= damage;
        
        Damaged?.Invoke(damage);
        HealthChanged?.Invoke(_health, maxHealth);
        
        if(_health <= 0)
            OnDied();

        return true;
    }
    private void ResetHealth()
    {
        _health = maxHealth;
        HealthChanged?.Invoke(_health, maxHealth);
    }
    private void OnDied()
    {
        Died?.Invoke();
        Destroy(gameObject);
    }

    private void Start()
    {
        ResetHealth();
    }
}
