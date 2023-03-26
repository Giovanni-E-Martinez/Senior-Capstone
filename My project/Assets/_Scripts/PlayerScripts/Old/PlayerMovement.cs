using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Script used to define and perform player movement actions
/// </summary>
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private float moveSpeed = 5f;
    [SerializeField]
    private PlayerControls playerControls;
    private InputAction move;
    private InputAction dash;
    private bool canDash = true;
    private bool isDashing = false;
    private float dashPower = 20f;
    private float dashTime =  0.2f;
    private float dashCooldown = 1f;

    private Vector2 moveDirection = Vector2.zero;

    // Instantiate variables as game loads
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerControls = new PlayerControls();
    }

    // Enable player input
    private void OnEnable()
    {
        move = playerControls.Player.Move;
        move.Enable();

        dash = playerControls.Player.Dash;
        dash.Enable();
        dash.performed += Dash;
    }

    // Disable player input
    private void OnDisable()
    {
        move.Disable();
        dash.Disable();
    }

    // Update is called once per frame
    private void Update()
    {
        if(isDashing == true)
            return;
        moveDirection = move.ReadValue<Vector2>();
    }

    // FixedUpdate is called at a fixed rate
    private void FixedUpdate()
    {
        if(isDashing == true)
            return;
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

    /// <summary>
    /// Method used to perform dash action.
    /// </summary>
    /// <param name="context">Player dash input.</param>
    private void Dash(InputAction.CallbackContext context)
    {
        if(canDash == true)
        {
            Debug.Log("Dashing!");
            StartCoroutine(DashCoroutine());
        }
    }

    /// <summary>
    /// Coroutine used to delay next dash.
    /// </summary>
    /// <returns>Return coroutine.</returns>
    private IEnumerator DashCoroutine()
    {
        Debug.Log("Starting dash coroutine");
        canDash = false;
        isDashing = true;
        rb.velocity = new Vector2(moveDirection.x * dashPower, moveDirection.y * dashPower);
        yield return new WaitForSeconds(dashTime);
        isDashing = false;
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }
}
