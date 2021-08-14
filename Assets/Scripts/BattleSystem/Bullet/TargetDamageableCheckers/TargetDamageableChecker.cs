using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TargetDamageableChecker : MonoBehaviour
{
    public abstract bool IsTargetDamageable(Collider2D target, AttackParams attackParams);
}
