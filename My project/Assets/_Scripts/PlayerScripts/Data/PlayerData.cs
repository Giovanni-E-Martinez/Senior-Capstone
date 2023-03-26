using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newPlayerData", menuName = "Data/Player Data/Base Data")]
public class PlayerData : ScriptableObject
{
    [Header("Move State")]
    public float movementVelocity = 3f;

    // [Header("Dash State")]
    // public float dashCooldown = 0.5f;
    // public float dashTime = .2f;
    // public float dashVelocity = 20f;
    // public float distanceBetweenAfterImages = 0.5f;
}
