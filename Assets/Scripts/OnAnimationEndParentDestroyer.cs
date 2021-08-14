using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnAnimationEndParentDestroyer : StateMachineBehaviour
{
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Destroy(animator.transform.parent.gameObject);
    }
}
