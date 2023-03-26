using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Abstract class used to define Detect method.
/// </summary>
public abstract class Detector : MonoBehaviour
{
    /// <summary>
    /// Detect colliders.
    /// </summary>
    /// <param name="aiData">Provided data.</param>
    public abstract void Detect(AIData aiData);
}
