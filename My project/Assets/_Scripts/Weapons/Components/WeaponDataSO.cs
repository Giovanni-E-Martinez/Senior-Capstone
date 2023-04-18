using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Scriptable object used to create weapon data for the player weapons.
/// </summary>
[CreateAssetMenu(fileName ="newWeaponData", menuName ="Data/Weapon Data")]
public class WeaponDataSO : ScriptableObject
{
    public Animation weaponAttackAnimation;
    public float attackDelay = 1f;
    public float damage = 10f;
    public float projectileSpeed = 10f;
    public float projectileRange = 10f;
    public float range = .2f;
    public GameObject projectile;
    public Sprite weaponSprite;
    public Vector3 projectileOrigin;
}
