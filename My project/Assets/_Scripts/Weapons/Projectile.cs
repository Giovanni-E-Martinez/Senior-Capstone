using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float damage;
    public float speed;
    public float range;

    private Rigidbody2D rb;

    [SerializeField]
    private LayerMask whatIsEnemy;
    [SerializeField]
    private LayerMask whatIsWall;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        FireProjectile(damage, speed, range);
    }

    //TODO: Figure out collision and damage using either fixed update or onTriggerEnter2d

    public void FireProjectile(float damage, float speed, float range)
    {
        rb.velocity = transform.right * speed;
    }
}
