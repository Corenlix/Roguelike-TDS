using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyAbility : MonoBehaviour
{
    [SerializeField] private LayerMask layersToDamage;
    public LayerMask LayersToDamage => layersToDamage;
    
    public abstract void Shoot(Vector2 targetPosition);
    public abstract bool IsReadyToShoot();
}
