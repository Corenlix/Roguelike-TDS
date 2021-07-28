using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public abstract class Weapon : MonoBehaviour
{
    public SpriteRenderer WeaponSpriteRenderer;
    
    [SerializeField] protected Transform shootPoint;
    [SerializeField] protected float reloadTime;
    [SerializeField] private Animator weaponAnimator;

    [SerializeField] private AmmoTypes ammoType;
    public AmmoTypes AmmoType => ammoType;
    
    private DateTime _lastShootDate = DateTime.MinValue;
    private static readonly int ShootAnimationId = Animator.StringToHash("Shoot");

    public bool TryShoot()
    {
        if (DateTime.UtcNow.Subtract(_lastShootDate).TotalSeconds > reloadTime)
        {
            _lastShootDate = DateTime.UtcNow;
            weaponAnimator.SetTrigger(ShootAnimationId);
            Shoot();
            return true;
        }

        return false;
    }

    protected abstract void Shoot();
    
    [Serializable]
    public enum AmmoTypes
    {
        Pistol = 0,
    }
}
