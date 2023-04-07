using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Class used to determine and retrieve inputs made by the player.
/// </summary>
public class PlayerInputHandler : MonoBehaviour
{
    public Vector2 RawMovementInput { get; private set; }
    public Vector2 RawLookInput { get; private set; }
    public int NormInputX { get; private set; }
    public int NormInputY { get; private set; }
    // public bool DashInput { get; private set; }
    // public bool DashInputStop { get; private set; }

    // private float dashInputStartTime;

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        RawMovementInput = context.ReadValue<Vector2>();
        NormInputX = Mathf.RoundToInt(RawMovementInput.x);
        NormInputY = Mathf.RoundToInt(RawMovementInput.y);
    }

    public void OnAttackInput(InputAction.CallbackContext context)
    {

    }

    public void OnAimInput(InputAction.CallbackContext context)
    {
        RawLookInput = context.ReadValue<Vector2>();
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
