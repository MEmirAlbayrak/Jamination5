using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = System.Object;

public class ArrowBehaviour : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private int damage;

    public void ActivateProjectile()
    {
        gameObject.SetActive(true);
        transform.rotation = gameObject.GetComponentInParent<Transform>().rotation;
    }

    private void Update()
    {
        float movementSpeed = speed * Time.deltaTime;
        transform.Translate(movementSpeed, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            Debug.Log("Hit Wall.");
            //Destroy(gameObject);
            gameObject.SetActive(false);    // deactivate on hit
            
        }
        else if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Hit PLayer.");
            //other.gameObject.GetComponent<>().health -= damage;
            //Destroy(gameObject);
            gameObject.SetActive(false);    // deactivate on hit
            
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Hit Enemy.");
            //other.gameObject.GetComponent<EnemyBehavior>().health -= damage;
            //Destroy(gameObject);
            gameObject.SetActive(false);    // deactivate on hit
        }
    }
}