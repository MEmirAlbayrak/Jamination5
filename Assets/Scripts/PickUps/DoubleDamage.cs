using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleDamage : MonoBehaviour
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
        if (other.gameObject.CompareTag("Player")) //Player name
        {
            //play sound
            //other.gameObject.GetComponent<GameObject>() //Double the damage
            Destroy(this);
        }
    }
}
