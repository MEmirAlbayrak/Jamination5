using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHoleSun : MonoBehaviour
{
    public List<GameObject> Enemies = new List<GameObject>();
    float timer, maxtimer;
    void Start()
    {
        maxtimer = 2;
        timer = maxtimer;
    }


    void Update()
    {
        foreach (GameObject enemy in Enemies)
        {
            Vector3 distance = transform.position - enemy.transform.position;
            enemy.gameObject.GetComponent<Rigidbody2D>().AddForceAtPosition(distance.normalized * 5f, transform.position);

        }

        timer -= Time.deltaTime;
        if (timer < 0)
        {
            foreach(GameObject enemy in Enemies)
            {
                enemy.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            }
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Enemies.Add(collision.gameObject);
            //collision.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.position - collision.gameObject.transform.position, ForceMode2D.Impulse);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Enemies.Remove(collision.gameObject);
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }
}
