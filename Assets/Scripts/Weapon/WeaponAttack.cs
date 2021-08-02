using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAttack : MonoBehaviour, IAttack
{
    [SerializeField] private List<Weapon> weapons;
    public void Attack(Vector2 targetPosition)
    {
        weapons.ForEach(x=>x.TryShoot(targetPosition));
    }
}
