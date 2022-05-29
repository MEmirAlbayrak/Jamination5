using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowableAxeScript : MonoBehaviour
{
   PlayerMovement scs;

    public float damage;
    void Start()
    {
        scs = GameObject.FindObjectOfType<PlayerMovement>();
        damage = 20;
    }

    
    void FixedUpdate()
    {
        transform.Rotate(Vector3.forward * 50);

        scs = GameObject.FindObjectOfType<PlayerMovement>();
        if (Vector2.Distance(scs.transform.position,transform.position) >= scs.particleDistance)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            collision.GetComponent<EnemyBehavior>().TakeDamage(damage);
        }
        Destroy(gameObject, 0.1f);
    }


}
