using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class DoubleSpeed : MonoBehaviour
{
    
    [SerializeField] private BoxCollider2D bxcollider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "") //Player name
        {
            //play sound
            other.gameObject.GetComponent<PlayerMovement>().Movespeed *= 2;//Double the speed
            Destroy(this);
        }
    }
}
