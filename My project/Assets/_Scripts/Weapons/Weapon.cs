using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private Animator anim;
    private GameObject baseGameObject;
    
    public WeaponDataSO data;
    //TODO: Create projectile class in order to utilize projectile data from weapon data.
    
    public void Enter() 
    {
        print($"{transform.name} enter");
        //TODO: Set active
    }

    private void Exit()
    {
        //TODO: Set inactive
    }

    public void Awake()
    {
        baseGameObject = transform.Find("Weapon").gameObject;
        anim = baseGameObject.GetComponent<Animator>();
    }

    public void Update()
    {
        //TODO: Follow mouse
    }

    public void FixedUpdate()
    {
        
    }
}
