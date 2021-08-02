using System;
using Helpers;
using UnityEngine;


[Serializable]
public class Weapon : MonoBehaviour
{
    public WeaponStats.AmmoTypes AmmoType => weaponStats.AmmoType;
    public virtual bool ReadyToShot => DateTime.UtcNow.Subtract(_lastShootDate).TotalSeconds > weaponStats.ReloadTime;

    [SerializeField] private SpriteRenderer weaponRenderer;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private Animator weaponAnimator;
    [SerializeField] private WeaponStats weaponStats;

    private static readonly int ShootAnimationId = Animator.StringToHash("Shoot");
    private DateTime _lastShootDate = DateTime.MinValue;
    
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
        Bullet newBullet = Instantiate(weaponStats.Bullet, shootPoint.transform.position, Quaternion.identity);
        newBullet.Init(direction);
    }
    
    
}
