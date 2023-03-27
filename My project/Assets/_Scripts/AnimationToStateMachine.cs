using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class used to define unity events from within an animation.
/// </summary>
public class AnimationToStateMachine : MonoBehaviour
{
    public AttackState attackState;

    /// <summary>
    /// Method used to define attack trigger event.
    /// </summary>
    private void TriggerAttack()
    {
        attackState.TriggerAttack();
    }

    /// <summary>
    /// Method used to define attack end event.
    /// </summary>
    private void FinishAttack()
    {
        attackState.FinishAttack();
    }
}
