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

    /// <summary>
    /// Called at initialization.
    /// </summary>
    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        int count = Enum.GetValues(typeof(CombatInputs)).Length;
        AttackInputs = new bool[count];
        cam = Camera.main;
    }

    /// <summary>
    /// Defines values of movement input.
    /// </summary>
    /// <param name="context">Retrieved Unity Event input.</param>
    public void OnMoveInput(InputAction.CallbackContext context)
    {
        RawMovementInput = context.ReadValue<Vector2>();
        NormInputX = Mathf.RoundToInt(RawMovementInput.x);
        NormInputY = Mathf.RoundToInt(RawMovementInput.y);
    }

    /// <summary>
    /// Defines values of primary attack input.
    /// </summary>
    /// <param name="context">Retrieved Unity Event input.</param>
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

    /// <summary>
    /// Defines values of secondary attack input.
    /// </summary>
    /// <param name="context">Retrieved Unity Event input.</param>
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

    /// <summary>
    /// Defines values of aim input.
    /// </summary>
    /// <param name="context">Retrieved Unity Event input.</param>
    public void OnAimInput(InputAction.CallbackContext context)
    {
        RawLookInput = context.ReadValue<Vector2>();
        NormLookInput = new Vector2(Mathf.RoundToInt(RawLookInput.x), Mathf.RoundToInt(RawLookInput.y));
    }

    /// <summary>
    /// Defines values of pause input.
    /// </summary>
    /// <param name="context">Retrieved Unity Event input.</param>
    public void OnPauseInput(InputAction.CallbackContext context)
    {
        Paused = !Paused;
        Debug.Log("Paused: " + Paused);
    }

    /// <summary>
    /// Identifies what control scheme the player is using and returns true or false.
    /// </summary>
    /// <returns>True for gamepad, false for mouse and keyboard.</returns>
    public bool ControlScheme()
    {
        return playerInput.currentControlScheme.Equals("Gamepad");
    }
}

public enum CombatInputs
{
    primary,
    secondary
}
