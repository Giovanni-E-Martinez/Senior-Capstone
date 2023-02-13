using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script used to define and perform rotation of player weapon.
/// </summary>
public class WeaponRotate : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer characterRenderer, weaponRenderer;
    public Vector2 PointerPosition { get; set; }
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private Transform bulletDirection;

    private bool canAttack = true;
    private float timer;
    private float attackDelay = .2f;

    // Called on each frame.
    private void Update()
    {
        Vector2 distance = (PointerPosition - (Vector2)transform.position).normalized;
        transform.right = distance;

        Vector2 scale = transform.localScale;
        if(distance.x < 0)
            scale.y = -1;
        else if(distance.x > 0)
            scale.y = 1;
        transform.localScale = scale;

        if(transform.eulerAngles.z > 0 && transform.eulerAngles.z < 180)
        {
            weaponRenderer.sortingOrder = characterRenderer.sortingOrder - 1;
        }
        else 
        {
            weaponRenderer.sortingOrder = characterRenderer.sortingOrder + 1;
        }
    }

    /// <summary>
    /// Method used to perform attack.
    /// </summary>
    public void Attack()
    {
        if(!canAttack)
            return;
        Debug.Log("Attack attempt");
        canAttack = false;
        Instantiate(bullet, bulletDirection.position, Quaternion.identity);
        StartCoroutine(DelayAttack());
    }

    /// <summary>
    /// Coroutine used to delay next attack.
    /// </summary>
    /// <returns>Returns coroutine.</returns>
    private IEnumerator DelayAttack()
    {
        yield return new WaitForSeconds(attackDelay);
        canAttack = true;
        Debug.Log("Ready to fire");
    }
}
