using System.Collections;
using System.Collections.Generic;
using EnemyAI;
using UnityEngine;

public class DistanceFarCondition : StateCondition
{
    [SerializeField] private float minDistance;
    public override bool ConditionMet()
    {
        return Vector2.Distance(transform.position, PlayerControls.Instance.transform.position) > minDistance;
    }
}
