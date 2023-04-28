using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class used to define Weapon object properties and methods.
/// </summary>
public class Weapon : MonoBehaviour
{
    private Animator anim;
    private GameObject baseGameObject;
    private AudioSource weaponAudio;
    private Transform projectileOrigin;
    private SpriteRenderer weaponRenderer;
    private SpriteRenderer characterRenderer;
    
    public bool canAttack;
    public bool attackInput;
    public float pointerAngle;
    public WeaponDataSO weaponData;

    /// <summary>
    /// Called on initialization to initialize properties.
    /// </summary>    
    public void Enter() 
    {
        // print($"{transform.name} enter");
        gameObject.SetActive(true);

        weaponData.projectile.GetComponent<Projectile>().damage = weaponData.damage;
        weaponData.projectile.GetComponent<Projectile>().speed = weaponData.projectileSpeed;
        weaponData.projectile.GetComponent<Projectile>().range = weaponData.projectileRange;
        weaponData.projectile.GetComponent<Projectile>().radius = weaponData.range;

        StopAllCoroutines();
        
        canAttack = true;
    }

    /// <summary>
    /// Called on deactivation.
    /// </summary>
    public void Exit()
    {
        // print($"{transform.name} exit");
        
        StartCoroutine(DelayHolster());
    }

    /// <summary>
    /// Called on creation within environment in order to define and assign components.
    /// </summary>
    public void Awake()
    {
        gameObject.SetActive(false);
        baseGameObject = transform.Find("Weapon").gameObject;
        weaponAudio = transform.Find("AudioSource").GetComponent<AudioSource>();
        weaponAudio.clip = weaponData.weaponSound;
        projectileOrigin = transform.Find("ProjectileOrigin").transform;
        projectileOrigin.position = baseGameObject.transform.position + weaponData.projectileOrigin;
        anim = baseGameObject.GetComponent<Animator>();
        weaponRenderer = baseGameObject.GetComponent<SpriteRenderer>();
        weaponRenderer.sprite = weaponData.weaponSprite;
        characterRenderer = baseGameObject.GetComponentInParent<SpriteRenderer>();

        canAttack = true;
    }

    /// <summary>
    /// Called before each frame to perform logic updates.
    /// </summary>
    public void Update()
    {
        RotateWeapon();
        if(attackInput)
            Attack();
    }

    /// <summary>
    /// Called on fixed intervals to perform physics updates.
    /// </summary>
    public void FixedUpdate()
    {
        
    }

    /// <summary>
    /// Method used to define and perform an attack action.
    /// </summary>
    public void Attack()
    {
        if(!canAttack)
            return;
        canAttack = false;
        weaponAudio.Play();
        Instantiate(weaponData.projectile, projectileOrigin.position, transform.rotation);
        StartCoroutine(DelayAttack());
    }

    /// <summary>
    /// Method used to locate cursor position then rotate the weapon towards the located cursor.
    /// </summary>
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

    /// <summary>
    /// Coroutine used to delay weapon holstering.
    /// </summary>
    /// <returns>Returns coroutine.</returns>
    private IEnumerator DelayHolster()
    {
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }

    /// <summary>
    /// Method used to draw helper visuals within the editor.
    /// </summary>
    void OnDrawGizmos()
    {
        // Gizmos.DrawWireSphere(projectileOrigin.transform.position, .2f);
    }
}
