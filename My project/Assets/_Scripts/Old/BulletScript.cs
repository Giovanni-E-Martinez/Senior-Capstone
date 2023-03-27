using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script for controlling the behavior of each Bullet game object instance.
/// </summary>
public class BulletScript : MonoBehaviour
{
    private Vector3 pointerPos;
    private Camera mainCam;
    private Rigidbody2D rb;
    [SerializeField]
    private float force;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
        pointerPos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = pointerPos - transform.position;
        Vector3 rotation = transform.position - pointerPos;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);
    }

    /// <summary>
    /// Method for triggering an event when Bullet collider hits another collider.
    /// </summary>
    /// <param name="collision">Detected collision data.</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
