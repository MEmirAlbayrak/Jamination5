using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowableAxeScript : MonoBehaviour
{
   PlayerMovement scs;
    void Start()
    {
        scs = GameObject.FindObjectOfType<PlayerMovement>();
    }

    
    void Update()
    {
        scs = GameObject.FindObjectOfType<PlayerMovement>();
        if (Vector2.Distance(scs.transform.position,transform.position) >= scs.particleDistance)
        {
            Destroy(gameObject);
        }
    }

  
}
