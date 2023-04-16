using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float speed;
    private float range;
    private Rigidbody2D rb;

    [SerializeField]
    private LayerMask whatIsPlayer;
    [SerializeField]
    private LayerMask whatIsWall;

    // Start is called before the first frame update
    private void Start()
    {
        //TODO: Figure out how to initialize and fire projectile
    }

    // Update is called once per frame
    private void Update()
    {

    }

    private void FixedUpdate()
    {
        
    }

    public void FireProjectile(float speed, float range, float damage)
    {
        this.speed = speed;
        this.range = range;
    }
}
