using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Script used to define and perform player attack actions.
/// </summary>
public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    private PlayerControls playerControls;
    private InputAction attack;
    private WeaponRotate weapon;

    // Instantiate variables as game loads
    private void Awake()
    {
        playerControls = new PlayerControls();
        weapon = GetComponentInChildren<WeaponRotate>();
    }

    // Enable player input
    private void OnEnable()
    {
        attack = playerControls.Player.Fire;
        attack.Enable();
        attack.performed += Attack;
    }

    // Disable player input
    private void OnDisable()
    {
        attack.Disable();
    }

    // Perform attack when receiving player input
    private void Attack(InputAction.CallbackContext context)
    {
        Debug.Log("Weapon fired");
        weapon.Attack();
    }
}
