using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapon", order = 1)]
[Serializable]
public class WeaponStats : ScriptableObject
{
    [SerializeField] private AmmoTypes ammoType;
    public AmmoTypes AmmoType => ammoType;
    
    [SerializeField] private float reloadTime;
    public float ReloadTime => reloadTime;
    
    [SerializeField] private Bullet bullet;
    public Bullet Bullet => bullet;

    [SerializeField] private float damage;
    public float Damage => damage;

    [SerializeField] private Sprite weaponSprite;
    public Sprite WeaponSprite => weaponSprite;

    [Serializable]
    public enum AmmoTypes
    {
        Pistol = 0,
    }
}
