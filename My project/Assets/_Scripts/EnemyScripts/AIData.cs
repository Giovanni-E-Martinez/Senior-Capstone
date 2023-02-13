using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script to contain detected targets and obstacles.
/// </summary>
public class AIData : MonoBehaviour
{
    public List<Transform> targets = null;
    public Collider2D[] obstacles = null;
    public Transform currentTarget;

    /// <summary>
    /// Determine if targets are in target list.
    /// </summary>
    /// <returns>Target list count.</returns>
    public int GetTargetsCount() => targets == null ? 0 : targets.Count;
}
