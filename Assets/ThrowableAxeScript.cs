using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowableAxeScript : MonoBehaviour
{
    ShieldCharacterScript scs;
    void Start()
    {
        scs = GameObject.FindObjectOfType<ShieldCharacterScript>();
    }

    
    void Update()
    {
        if(Vector2.Distance(scs.transform.position,transform.position) >= scs.axeDistance)
        {
            Destroy(gameObject);
        }
    }
}
