using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodingTrap : MonoBehaviour
{

    [SerializeField] private BoxCollider2D bxcollider;
    [SerializeField] private int damage;
    [SerializeField] private float radius;
    
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
        if (other.gameObject.name == "") //Player bullet
        {
            Destroy(this);
            //Play explode animaton, hurt everyone in the radius
        }
            
    }
}
