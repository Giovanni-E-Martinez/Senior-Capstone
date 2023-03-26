using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Script used to define and perform player look actions.
/// </summary>
public class PlayerLook : MonoBehaviour
{
    private PlayerControls playerControls;
    private InputAction look;
    private WeaponRotate weaponRotate;
    private Vector2 pointerInput;

    // Instantiate variables as game loads
    private void Awake()
    {
        weaponRotate = GetComponentInChildren<WeaponRotate>();
        playerControls = new PlayerControls();
    }

    // Enable player input
    private void OnEnable()
    {
        look = playerControls.Player.Look;
        look.Enable();
    }

    // Disable player input
    private void OnDisable()
    {
        look.Disable();
    }
    
    // Update is called once per frame
    private void Update()
    {
        pointerInput = GetPointerInput();
        weaponRotate.PointerPosition = pointerInput;
    }

    // Get input from mouse/look location
    private Vector2 GetPointerInput()
    {
        Vector3 pointerPos = look.ReadValue<Vector2>();
        pointerPos.z = Camera.main.nearClipPlane;
        return Camera.main.ScreenToWorldPoint(pointerPos);
    }
}
