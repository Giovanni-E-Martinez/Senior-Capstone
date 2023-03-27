using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Scriptable object used to define PlayerDetectedState variables.
/// </summary>
[CreateAssetMenu(fileName ="newPlayerDetectedStateData", menuName ="Data/State Data/Player Detected State")]
public class D_PlayerDetected : ScriptableObject
{
    public float longRangeActionTime = 1.5f;
}
