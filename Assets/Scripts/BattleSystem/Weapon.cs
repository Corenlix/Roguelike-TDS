using System;
using BattleSystem.BulletShoots;
using Helpers;
using UnityEngine;


[Serializable]
public class Weapon : MonoBehaviour
{
    public virtual bool ReadyToShot => _reloadTimeRemain <= 0;
    
    [SerializeField] protected Transform shootPoint;
    [SerializeField] private Animator weaponAnimator;
    [SerializeField] private SpriteRenderer weaponSpriteRenderer;
    [SerializeField] private WeaponStats weaponStats;
    

    private static readonly int ShootTriggerId = Animator.StringToHash("Shoot");
    private float _reloadTimeRemain;

    private WeaponShoot weaponShoot;
    
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

    public void ChangeWeaponStats(WeaponStats stats)
    {
        weaponStats = stats;
        Init();
    }
    
    private void Init()
    {
        weaponShoot = WeaponShootCreator.CreateWeaponShooter(weaponStats.WeaponShooterType);
        weaponSpriteRenderer.sprite = weaponStats.Sprite;
        _reloadTimeRemain = weaponStats.ReloadTime;
    }

    private void Update()
    {
        _reloadTimeRemain -= Time.deltaTime;
    }
    
    private void Shoot(Vector2 direction)
    {
        weaponShoot.Shoot(shootPoint, direction, weaponStats.BulletTemplate, weaponStats.AttackParams);
    }

    private void Reload()
    {
        _reloadTimeRemain = weaponStats.ReloadTime;
    }
}
