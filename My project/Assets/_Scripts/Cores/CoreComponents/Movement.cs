using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Core subclass responsible for handling the general movement related methods of enemies and player objects.
/// </summary>
public class Movement : CoreComponent
{
    #region Public Components
    public Rigidbody2D RB { get; private set; }
    public int FacingDirection { get; private set; }
    public Vector2 CurrentVelocity { get; private set; }
    #endregion
    
    #region Private Components
    private Vector2 workSpace;
    #endregion
    
    #region Unity Callback Methods
    /// <summary>
    /// Called on instantiation.
    /// </summary>
    protected override void Awake()
    {
        base.Awake();

        RB = GetComponentInParent<Rigidbody2D>();
        FacingDirection = 1;
    }

    /// <summary>
    /// Called once per frame.
    /// </summary>
    public void LogicUpdate()
    {
        CurrentVelocity = RB.velocity;
    }
    #endregion

    #region Set Methods
    /// <summary>
    /// Method used to set the velocity of the player object.
    /// </summary>
    /// <param name="velocityX">X axis velocity.</param>
    /// <param name="velocityY">Y axis velocity.</param>
    public void SetVelocity(float velocity, Vector2 direction)
    {
        workSpace = velocity * direction;
        RB.velocity = workSpace;
        CurrentVelocity = workSpace;
    }
    #endregion

    #region Check Methods
    /// <summary>
    /// Method used to determine if player should flip.
    /// </summary>
    /// <param name="xInput">X axis input.</param>
    public void CheckIfShouldFlip(int xInput)
    {
        if(xInput != 0 && xInput != FacingDirection)
        {
            Flip();
        }
    }
    #endregion

    #region Other Methods
    /// <summary>
    /// Method used to fip the player object.
    /// </summary>
    private void Flip()
    {
        FacingDirection *= -1;
        // transform.Rotate(0.0f, 180.0f, 0.0f);
        GetComponentInParent<SpriteRenderer>().flipX = !GetComponentInParent<SpriteRenderer>().flipX;
    }
    #endregion
}
