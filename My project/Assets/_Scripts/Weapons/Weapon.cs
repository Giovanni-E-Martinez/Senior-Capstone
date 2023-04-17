using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private Animator anim;
    private GameObject baseGameObject;
    private Transform projectileOrigin;
    private SpriteRenderer weaponRenderer;
    private SpriteRenderer characterRenderer;
    private bool canAttack;
    
    public float pointerAngle;
    public WeaponDataSO weaponData;
    
    public void Enter() 
    {
        // print($"{transform.name} enter");
        gameObject.SetActive(true);
        canAttack = true;
    }

    public void Exit()
    {
        // print($"{transform.name} exit");
        gameObject.SetActive(false);
        canAttack = false;
    }

    public void Awake()
    {
        gameObject.SetActive(false);
        baseGameObject = transform.Find("Weapon").gameObject;
        projectileOrigin = transform.Find("ProjectileOrigin").transform;
        projectileOrigin.position = baseGameObject.transform.position + weaponData.projectileOrigin;
        anim = baseGameObject.GetComponent<Animator>();
        weaponRenderer = baseGameObject.GetComponent<SpriteRenderer>();
        weaponRenderer.sprite = weaponData.weaponSprite;
        characterRenderer = baseGameObject.GetComponentInParent<SpriteRenderer>();

        weaponData.projectile.GetComponent<Projectile>().damage = weaponData.damage;
        weaponData.projectile.GetComponent<Projectile>().speed = weaponData.projectileSpeed;
        weaponData.projectile.GetComponent<Projectile>().range = weaponData.projectileRange;
    }

    public void Update()
    {
        RotateWeapon();
        Attack();
    }

    public void FixedUpdate()
    {
        
    }

    public void Attack()
    {
        if(!canAttack)
            return;
        canAttack = false;
        Instantiate(weaponData.projectile, projectileOrigin.position, transform.rotation);
        StartCoroutine(DelayAttack());
    }

    public void RotateWeapon()
    {
        transform.rotation = Quaternion.Euler(0f, 0f, pointerAngle);

        Vector2 scale = transform.localScale;
        if(pointerAngle < 90 && pointerAngle > -90)
            scale.y = 1;
        else
            scale.y = -1;
        transform.localScale = scale;
    }

    /// <summary>
    /// Coroutine used to delay next attack.
    /// </summary>
    /// <returns>Returns coroutine.</returns>
    private IEnumerator DelayAttack()
    {
        yield return new WaitForSeconds(weaponData.attackDelay);
        canAttack = true;
        Debug.Log("Ready to fire");
    }

    void OnDrawGizmos()
    {
        // Gizmos.DrawWireSphere(projectileOrigin.transform.position, .2f);
    }
}
