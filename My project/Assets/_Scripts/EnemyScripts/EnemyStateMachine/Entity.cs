using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Entity super class that defines the framework for entity subclasses.
/// </summary>
public class Entity : MonoBehaviour
{
    // Instances of the state machine and entity data.
    public EnemyStateMachine stateMachine;
    public D_Entity entityData;

    // Instances of the entity game objects and transform information.
    public int facingDirection { get; private set; }
    public Rigidbody2D rb { get; private set; }
    public Animator anim { get; private set; }
    public GameObject aliveGO { get; private set; }
    public AnimationToStateMachine atsm { get; private set; }

    // Variables that can be set fro the Unity Editor.
    [SerializeField]
    private Transform wallCheck;
    [SerializeField]
    private Transform playerCheck;

    // Additional entity physics variables.
    private Vector2 velocityWorkspace;
    private Collider2D lastPlayerLocation;
    // private Transform target;
    private int[] directions = {-1,1};

    /// <summary>
    /// Method that initializes the entity on scene entry.
    /// </summary>
    public virtual void Start()
    {
        // Randomly spawn facing right or left.
        facingDirection = directions[Random.Range(0,2)];

        // Initialize and define each component.
        aliveGO = transform.Find("Alive").gameObject;
        rb = aliveGO.GetComponent<Rigidbody2D>();
        anim = aliveGO.GetComponent<Animator>();
        atsm = aliveGO.GetComponent<AnimationToStateMachine>();
        
        stateMachine = new EnemyStateMachine();

        if(facingDirection == -1)
        {
            aliveGO.transform.Rotate(0f, 180f, 0);
        }
    }

    /// <summary>
    /// Method that updates per frame.
    /// </summary>
    public virtual void Update()
    {
        stateMachine.CurrentState.LogicUpdate();
    }

    /// <summary>
    /// Method that updates on set intervals.
    /// </summary>
    public virtual void FixedUpdate()
    {
        stateMachine.CurrentState.PhysicsUpdate();
    }

    /// <summary>
    /// Method to set and change entity velocity.
    /// </summary>
    /// <param name="velocityX">Floating point value used to set new velocity.</param>
    public virtual void SetVelocity(float velocityX)
    {
        // Temporarily store velocity data
        velocityWorkspace.Set(facingDirection * velocityX, rb.velocity.y); 
        // Set entity velocity to the temporary store value
        rb.velocity = velocityWorkspace;
    }

    /// <summary>
    /// Method to detect player within the minimum aggression distance.
    /// </summary>
    /// <returns>Returns true or false.</returns>
    public virtual bool CheckPlayerInMinAgroRange()
    {
        return Physics2D.OverlapCircle(playerCheck.position, entityData.minAgroDistance, entityData.whatIsPlayer);
    }

    /// <summary>
    /// Method to detect player within the maximum aggression distance.
    /// </summary>
    /// <returns>Returns true or false.</returns>
    public virtual bool CheckPlayerInMaxAgroRange()
    {
        return Physics2D.OverlapCircle(playerCheck.position, entityData.maxAgroDistance, entityData.whatIsPlayer);
    }

    /// <summary>
    /// Method to detect player within the entity attacking distance.
    /// </summary>
    /// <returns>Returns true or false.</returns>
    public virtual bool CheckPlayerInCloseRangeAction()
    {
        return Physics2D.OverlapCircle(playerCheck.position, entityData.closeRangeActionDistance, entityData.whatIsPlayer);
    }

    /// <summary>
    /// Method used to detect if the entity is approaching a wall.
    /// </summary>
    /// <returns>Returns true or false.</returns>
    public virtual bool CheckWall()
    {
       return Physics2D.Raycast(wallCheck.position, aliveGO.transform.right, entityData.wallCheckDistance, entityData.whatIsWall);
    }

    /// <summary>
    /// Method used to locate the player transform, then navigate to the player.
    /// </summary>
    public virtual void FindPlayer(float speed)
    {
        // Check if player is within aggression range
        if(CheckPlayerInMaxAgroRange())
        {
            // Temporarily store the player collider location
            lastPlayerLocation = Physics2D.OverlapCircle(playerCheck.position, entityData.maxAgroDistance, entityData.whatIsPlayer);
            // Determine whether the player is to the right or the left
            if((aliveGO.transform.position.x - lastPlayerLocation.transform.position.x) * facingDirection > 0)
            {
                // Flip the entity to face the player
                Flip();
            }
            // Navigate to the last known player location            
            aliveGO.transform.position = Vector2.MoveTowards(aliveGO.transform.position, lastPlayerLocation.transform.position, speed * Time.deltaTime);
        }
    }

    /// <summary>
    /// Method used to flip the entity.
    /// </summary>
    public virtual void Flip()
    {
        facingDirection *= -1;
        aliveGO.transform.Rotate(0f, 180f, 0);
    }

    /// <summary>
    /// Method used to generate tooltips within Unity Editor to assist with visualization and testing.
    /// </summary>
    public virtual void OnDrawGizmos()
    {
        Gizmos.DrawLine(wallCheck.position, wallCheck.position + (Vector3)(Vector2.right * facingDirection * entityData.wallCheckDistance));
        Gizmos.DrawWireSphere(playerCheck.position, entityData.minAgroDistance);
        Gizmos.DrawWireSphere(playerCheck.position, entityData.maxAgroDistance);
        Gizmos.DrawWireSphere(playerCheck.position, entityData.closeRangeActionDistance);
        // Gizmos.DrawWireSphere(playerCheck.position + (Vector3)(Vector2.right * entityData.closeRangeActionDistance), 0.2f);
    }
}
