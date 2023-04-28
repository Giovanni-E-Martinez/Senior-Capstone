using System.Net.WebSockets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class used to define projectile object properties and methods.
/// </summary>
public class Projectile : MonoBehaviour
{
    public float damage;
    public float speed;
    public float range;
    public float radius;

    private Rigidbody2D rb;
    private Transform hitbox;

    [SerializeField]
    private LayerMask whatIsEnemy;
    [SerializeField]
    private LayerMask whatIsWall;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        hitbox = transform.Find("Hitbox");
        FireProjectile(damage, speed, range);
    }

    /// <summary>
    /// Called on fixed intervals to perform physics calculations and updates.
    /// </summary>
    private void FixedUpdate()
    {
        Collider2D enemy = Physics2D.OverlapCircle(hitbox.position, radius, whatIsEnemy);
        Collider2D wall = Physics2D.OverlapCircle(hitbox.position, radius, whatIsWall);

        if (enemy)
        {
            //TODO: Test if this works against enemy entities.
            // For each collider found, send the "Damage" message to each object
            IDamageable damageable = enemy.GetComponentInChildren<IDamageable>();

            if (damageable != null)
            {
                damageable.Damage(damage);
            }

            Destroy(gameObject);
        }
        else if (wall)
            Destroy(gameObject);
    }

    /// <summary>
    /// Method used to define properties of a fired projectile.
    /// </summary>
    /// <param name="damage">Defined amount of damage to be dealt on strike.</param>
    /// <param name="speed">Defined projectile flight speed.</param>
    /// <param name="range">Defined projectile total range.</param>
    public void FireProjectile(float damage, float speed, float range)
    {
        rb.velocity = transform.right * speed;
    }

    /// <summary>
    /// Method used to draw helper visuals in editor when running.
    /// </summary>
    public void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(hitbox.position, radius);
    }
}
