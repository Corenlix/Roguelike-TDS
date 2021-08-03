using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    [SerializeField] private HealthOwnerCategory ownerCategory;
    public HealthOwnerCategory OwnerCategory => ownerCategory;
    private int _health;

    public bool Damage(int damage, HealthOwnerCategory bulletOwnerCategory)
    {
        if (bulletOwnerCategory == ownerCategory)
            return false;
        
        _health -= damage;
        if(_health <= 0)
            OnDied();

        return true;
    }
    private void ResetHealth()
    {
        _health = maxHealth;
    }
    private void OnDied()
    {
        Destroy(gameObject);
    }

    private void Awake()
    {
        ResetHealth();
    }

    public enum HealthOwnerCategory
    {
        Enemy = 0,
        Player = 1,
    }
}
