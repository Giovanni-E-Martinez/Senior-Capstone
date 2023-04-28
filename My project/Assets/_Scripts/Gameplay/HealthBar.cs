using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Class used to modify the values of the HUD health bar.
/// </summary>
public class HealthBar : MonoBehaviour
{
    public Slider slider;

    /// <summary>
    /// Defines the max health value based on player health.
    /// </summary>
    /// <param name="health">Maximum health value.</param>
    public void SetMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    /// <summary>
    /// Modifies the value of the health bar on updated.
    /// </summary>
    /// <param name="health">Current health value.</param>
    public void SetHealth(float health)
    {
        slider.value = health;
    }
}
