using System.Collections;
using System.Collections.Generic;
using Enemies.StateMachine.Conditions;
using UnityEngine;

public class ReturnFalseCondition : Condition
{
    public override bool IsConditionMet()
    {
        return false;
    }
}
