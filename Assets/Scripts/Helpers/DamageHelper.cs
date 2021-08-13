using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DamageHelper
{
    public static bool IsTargetInteractable(Collider2D target, LayerMask interactiveLayers, out Health targetHealth)
    {
        if((interactiveLayers.value & (1 << target.gameObject.layer)) != 0)
        {
            targetHealth = target.GetComponent<Health>();
            if (!targetHealth || target.isTrigger)
            {
                return true;
            }
        }

        targetHealth = null;
        return false;
    }
}
