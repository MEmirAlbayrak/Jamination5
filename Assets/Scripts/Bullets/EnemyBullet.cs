using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 1f;
    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * bulletSpeed * 5, ForceMode2D.Impulse);
        Destroy(gameObject, 5);
    }



    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<PlayerMovement>().TakeDamage(10);
        }
        Destroy(gameObject, 0.1f);
    }
}
