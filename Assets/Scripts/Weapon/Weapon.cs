using System;
using Helpers;
using UnityEngine;


[Serializable]
public abstract class Weapon : MonoBehaviour
{
    public virtual bool ReadyToShot => _reloadTimeRemain <= 0;

    [SerializeField] protected Transform shootPoint;
    [SerializeField] private Animator weaponAnimator;
    [SerializeField] private AmmoTypes ammoType;
    public AmmoTypes AmmoType => ammoType;
    [SerializeField] private WeaponTypes weaponType;
    public WeaponTypes WeaponType => weaponType;
    [SerializeField] private float reloadTime;
    [SerializeField] protected Bullet bullet;
    [SerializeField] protected AttackParams attackParams;
    public float ShakeCamTime => shakeCamTime;
    [SerializeField] private float shakeCamTime;
    public float ShakeCamForce => shakeCamForce;
    [SerializeField] private float shakeCamForce;
    
    [Serializable]
    public enum AmmoTypes
    {
        Pistol = 0,
        Rifle = 1,
    }

    public enum WeaponTypes
    {
        Pistol = 0,
        HeavyPistol = 1,
    }
    
    private static readonly int ShootTriggerId = Animator.StringToHash("Shoot");
    private float _reloadTimeRemain;
    
    public bool TryShoot(Vector2 targetPosition)
    {
        if (ReadyToShot)
        {
            weaponAnimator.SetTrigger(ShootTriggerId);
            Shoot(targetPosition);
            Reload();
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

    protected abstract void Shoot(Vector2 direction);

    private void Reload()
    {
        _reloadTimeRemain = reloadTime;
    }
    private void Update()
    {
        _reloadTimeRemain -= Time.deltaTime;
    }
}
