using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class powerup : MonoBehaviour
{
    
    private Transform boyut;
    private void Start()
    {
        boyut = GetComponent<Transform>();
    }

    private void OnTriggerEnter(Collider obje)
    {
        if (obje.gameObject.CompareTag("reward"))
        {
            boyut.localScale =boyut.localScale*1.2f;
            Destroy(obje.gameObject);

        }
        
        if (obje.gameObject.CompareTag("Enemy"))
        {
            boyut.localScale =boyut.localScale/1.2f;
            Destroy(obje.gameObject);

        }
    }
    
}
