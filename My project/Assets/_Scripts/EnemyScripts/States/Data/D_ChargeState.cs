using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Scriptable object used to define ChargeState variables.
/// </summary>
[CreateAssetMenu(fileName ="newChargeStateData", menuName ="Data/State Data/Charge State")]
public class D_ChargeState : ScriptableObject
{
    public float chargeSpeed = 6f;
    public float chargeTime = 2f;
}