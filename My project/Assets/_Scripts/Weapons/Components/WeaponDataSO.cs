using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Scriptable object used to create weapon data for the player weapons.
/// </summary>
[CreateAssetMenu(fileName ="newWeaponData", menuName ="Data/Weapon Data")]
public class WeaponDataSO : ScriptableObject
{
    public float damage = 10f;
    public float attackDelay = 1f;
    public Sprite weaponSprite;
    public Animation weaponAttackAnimation;
    public Vector3 projectileOrigin;
    //TODO: Experiment with projectile data class to incorporate projectile component
}
