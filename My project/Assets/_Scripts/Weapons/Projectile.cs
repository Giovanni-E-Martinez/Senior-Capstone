using System.Net.WebSockets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public void FireProjectile(float damage, float speed, float range)
    {
        rb.velocity = transform.right * speed;
    }

    public void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(hitbox.position, radius);
    }
}
