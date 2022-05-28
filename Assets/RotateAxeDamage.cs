using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAxeDamage : MonoBehaviour
{

    float damage;
    // Start is called before the first frame update
    void Start()
    {
        damage = 20;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            collision.GetComponent<EnemyBehavior>().TakeDamage(20);
        }
    }
}
