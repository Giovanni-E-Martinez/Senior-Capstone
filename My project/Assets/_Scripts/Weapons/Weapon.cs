using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private Animator anim;
    private GameObject baseGameObject;
    
    public void Enter() 
    {
        print($"{transform.name} enter");
    }

    private void Exit()
    {
        
    }

    public void Awake()
    {
        baseGameObject = transform.Find("Weapon").gameObject;
        anim = baseGameObject.GetComponent<Animator>();
    }
}
