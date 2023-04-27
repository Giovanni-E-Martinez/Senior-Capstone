using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Class used to determine and retrieve inputs made by the player.
/// </summary>
public class PlayerInputHandler : MonoBehaviour
{
    private PlayerInput playerInput;
    private Camera cam;

    public Vector2 RawMovementInput { get; private set; }
    public Vector2 RawLookInput { get; private set; }
    public Vector2 NormLookInput { get; private set; }
    public int NormInputX { get; private set; }
    public int NormInputY { get; private set; }
    public bool[] AttackInputs { get; private set; }
    public bool Paused { get; set; }
    // public bool DashInput { get; private set; }
    // public bool DashInputStop { get; private set; }

    // private float dashInputStartTime;

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        int count = Enum.GetValues(typeof(CombatInputs)).Length;
        AttackInputs = new bool[count];
        cam = Camera.main;
    }

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        RawMovementInput = context.ReadValue<Vector2>();
        NormInputX = Mathf.RoundToInt(RawMovementInput.x);
        NormInputY = Mathf.RoundToInt(RawMovementInput.y);
    }

    public void OnPrimaryAttackInput(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            AttackInputs[(int)CombatInputs.primary] = true;
        }

        if(context.canceled)
        {
            AttackInputs[(int)CombatInputs.primary] = false;
        }
    }

    public void OnSecondaryAttackInput(InputAction.CallbackContext context)
    {
        
        if(context.started)
        {
            AttackInputs[(int)CombatInputs.secondary] = true;
        }

        if(context.canceled)
        {
            AttackInputs[(int)CombatInputs.secondary] = false;
        }
    }

    public void OnAimInput(InputAction.CallbackContext context)
    {
        RawLookInput = context.ReadValue<Vector2>();
        NormLookInput = new Vector2(Mathf.RoundToInt(RawLookInput.x), Mathf.RoundToInt(RawLookInput.y));
    }

    public void OnPauseInput(InputAction.CallbackContext context)
    {
        Paused = !Paused;
        Debug.Log("Paused: " + Paused);
    }

    public bool ControlScheme()
    {
        return playerInput.currentControlScheme.Equals("Gamepad");
    }

    // public void OnDashInput(InputAction.CallbackContext context)
    // {
    //     if(context.started)
    //     {
    //         DashInput = true;
    //         DashInputStop = false;
    //         dashInputStartTime = Time.time;
    //     }
    //     else if(context.canceled)
    //     {
    //         DashInputStop = true;
    //     }
    // }

    // public void UseDashInput() => DashInput = false;
}

public enum CombatInputs
{
    primary,
    secondary
}
