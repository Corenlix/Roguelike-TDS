using System;
using Helpers;
using UnityEngine;


[Serializable]
public class Weapon : MonoBehaviour
{
    public virtual bool ReadyToShot => _reloadTimeRemain <= 0;

    [SerializeField] private Transform shootPoint;
    [SerializeField] private Animator weaponAnimator;
    
    [SerializeField] private AmmoTypes ammoType;
    public AmmoTypes AmmoType => ammoType;
    [SerializeField] private float reloadTime;
    [SerializeField] private Bullet bullet;
    [SerializeField] private int damage;
    [SerializeField] private LayerMask layersToDamage; 
    
    [Serializable]
    public enum AmmoTypes
    {
        Pistol = 0,
    }
    private static readonly int ShootAnimationId = Animator.StringToHash("Shoot");
    private DateTime _lastShootDate = DateTime.MinValue;
    private float _reloadTimeRemain;
    
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
        Bullet newBullet = Instantiate(bullet, shootPoint.transform.position, Quaternion.identity);
        newBullet.Init(direction, damage, layersToDamage);
        _reloadTimeRemain = reloadTime;
    }
    
    private void Update()
    {
        _reloadTimeRemain -= Time.deltaTime;
    }
}
