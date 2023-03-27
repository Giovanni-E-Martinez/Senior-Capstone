using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Scriptable object used to define MoveState variables.
/// </summary>
[CreateAssetMenu(fileName ="newMoveStateData", menuName ="Data/State Data/Move State")]
public class D_MoveState : ScriptableObject
{
    public float movementSpeed = 3f;
    public float minWalkTime = 1f;
    public float maxWalkTime = 3f;
}
