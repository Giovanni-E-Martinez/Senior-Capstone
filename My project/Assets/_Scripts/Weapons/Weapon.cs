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
    
    public Vector2 PointerPosition;
    public WeaponDataSO data;
    //TODO: Create projectile class in order to utilize projectile data from weapon data.
    
    public void Enter() 
    {
        print($"{transform.name} enter");
        gameObject.SetActive(true);
        weaponRenderer.sprite = data.weaponSprite;
    }

    public void Exit()
    {
        gameObject.SetActive(false);
        print($"{transform.name} exit");
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
        Vector2 distance = (PointerPosition - (Vector2)baseGameObject.transform.position).normalized;
        baseGameObject.transform.right = distance;

        Vector2 scale = baseGameObject.transform.localScale;
        if(distance.x < 0)
            scale.y = -1;
        else if(distance.x > 0)
            scale.y = 1;
        baseGameObject.transform.localScale = scale;
    }
}
