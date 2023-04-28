using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Interface used to define damageable objects.
/// </summary>
public interface IDamageable
{
    void Damage(float amount);
}