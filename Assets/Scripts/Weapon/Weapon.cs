using System;
using System.Collections;
using System.Collections.Generic;
using Helpers;
using UnityEngine;
using UnityEngine.Serialization;


[Serializable]
public class Weapon : MonoBehaviour
{
    public AmmoTypes AmmoType => ammoType;
    public virtual bool ReadyToShot => DateTime.UtcNow.Subtract(_lastShootDate).TotalSeconds > reloadTime;
    private DateTime _lastShootDate = DateTime.MinValue;
    
    [SerializeField] private Transform shootPoint;
    [SerializeField] private float reloadTime;
    [SerializeField] private Animator weaponAnimator;
    [SerializeField] private AmmoTypes ammoType;
    [SerializeField] private Bullet bullet;

    private static readonly int ShootAnimationId = Animator.StringToHash("Shoot");
    
    public bool TryShoot(Vector2 targetPosition)
    {
        if (ReadyToShot)
        {
            _lastShootDate = DateTime.UtcNow;
            weaponAnimator.SetTrigger(ShootAnimationId);
            Shoot(targetPosition);
            return true;
        }

        return false;
    }

    public void RotateWeapon(Vector2 targetPosition)
    {
        var direction = targetPosition - (Vector2)transform.position;
        if (transform.lossyScale.x < 0)
        {
            direction *= -1;
        }

        transform.rotation = RotateHelper.GetAngleFromDirection(direction);
        
    }
    private void Shoot(Vector2 direction)
    {
        var newBullet = Instantiate(bullet, shootPoint.transform.position, Quaternion.identity);
        newBullet.GetComponent<Bullet>().Init(direction);
    }
    
    [Serializable]
    public enum AmmoTypes
    {
        Pistol = 0,
    }
}
