using System.Collections;
using System.Collections.Generic;
using EnemyAI;
using UnityEngine;

public class ReturnFalseCondition : StateCondition
{
    public override bool ConditionMet()
    {
        return false;
    }
}
