using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerMaskChecker : TargetDamageableChecker
{
    public override bool IsTargetDamageable(Collider2D target, AttackParams attackParams)
    {
        return (attackParams.InteractiveLayers.value & (1 << target.gameObject.layer)) != 0;
    }
}
