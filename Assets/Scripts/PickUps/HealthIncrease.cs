using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class HealthIncrease : MonoBehaviour
{
    [SerializeField] private BoxCollider2D bxcollider;
    [SerializeField] private int hpIncreaseValue;
    
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
            Destroy(this);
            //play sound
            //other.gameObject.GetComponent<GameObject>()  //health increase
        }
    }
}
