using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Scriptable object used to define Entity variables.
/// </summary>
[CreateAssetMenu(fileName ="newEntityData", menuName ="Data/Entity Data/Base Data")]
public class D_Entity : ScriptableObject
{
    public float wallCheckDistance = 0.2f;
    public float maxAgroDistance = 4f;
    public float minAgroDistance = 3f;
    public float closeRangeActionDistance = 1f;
    public LayerMask whatIsWall;
    public LayerMask whatIsPlayer;
}
