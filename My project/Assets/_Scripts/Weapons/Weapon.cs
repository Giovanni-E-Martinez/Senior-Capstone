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
    
    public float pointerAngle;
    public WeaponDataSO data;
    //TODO: Create projectile class in order to utilize projectile data from weapon data.
    //TODO: Create attack
    
    public void Enter() 
    {
        // print($"{transform.name} enter");
        gameObject.SetActive(true);
        weaponRenderer.sprite = data.weaponSprite;
    }

    public void Exit()
    {
        gameObject.SetActive(false);
        // print($"{transform.name} exit");
    }

    public void Awake()
    {
        gameObject.SetActive(false);
        baseGameObject = transform.Find("Weapon").gameObject;
        projectileOrigin = transform.Find("ProjectileOrigin").transform;
        projectileOrigin.position = baseGameObject.transform.position + data.projectileOrigin;
        anim = baseGameObject.GetComponent<Animator>();
        weaponRenderer = baseGameObject.GetComponent<SpriteRenderer>();
        characterRenderer = baseGameObject.GetComponentInParent<SpriteRenderer>();
    }

    public void Update()
    {
        RotateWeapon();
    }

    public void FixedUpdate()
    {
        
    }

    public void Attack()
    {
        
    }

    public void RotateWeapon()
    {
        baseGameObject.transform.rotation = Quaternion.Euler(0f, 0f, pointerAngle);
        
        // Vector2 distance = (PointerPosition - (Vector2)baseGameObject.transform.position).normalized;
        // baseGameObject.transform.eulerAngles = new Vector3(0, 0, Mathf.Atan2(distance.y, distance.x) * Mathf.Rad2Deg);

        // Vector2 distance = (PointerPosition - (Vector2)baseGameObject.transform.position).normalized;
        // float rotation = Mathf.Atan2(distance.y, distance.x) * Mathf.Rad2Deg;
        // baseGameObject.transform.rotation = Quaternion.Euler(0f, 0f, rotation);

        // Vector2 distance = (PointerPosition - (Vector2)baseGameObject.transform.position).normalized;
        // baseGameObject.transform.right = distance;

        Vector2 scale = baseGameObject.transform.localScale;
        if(pointerAngle < 90 && pointerAngle > -90)
            scale.y = 1;
        else
            scale.y = -1;
        baseGameObject.transform.localScale = scale;
    }
}
