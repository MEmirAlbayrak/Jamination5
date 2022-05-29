using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowableBowScript : MonoBehaviour
{

    PlayerMovement scs;
    public TrailRenderer arrowTrail;
    public float lifeTime;
    public float speed;
    public float damage;
    public bool destroyBool;
    private void Awake()
    {
        damage = 10f;
        arrowTrail = GetComponentInChildren<TrailRenderer>();
    }
    void Start()
    {
        scs = GameObject.FindObjectOfType<PlayerMovement>();
    }

    void Update()
    {
        
        if (Vector2.Distance(scs.transform.position, transform.position) >= lifeTime)
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
        DestroyBow();
    }

    public void DestroyBow()
    {
        if(destroyBool)
        {
        Destroy(gameObject, 0.1f);

        }
    }
}
