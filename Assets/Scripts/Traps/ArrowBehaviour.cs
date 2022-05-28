using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBehaviour : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private int damage;
    
    public void ActivateProjectile()
    {
        gameObject.SetActive(true);
    }

    private void Update()
    {
        float movementSpeed = speed * Time.deltaTime;
        transform.Translate(movementSpeed, 0, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            Destroy(this);
        }
        else if (other.gameObject.CompareTag("Player"))
        {
            //other.gameObject.GetComponent<>().health -= damage;
            Destroy(this);
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            //other.gameObject.GetComponent<EnemyBehavior>().health -= damage;
            Destroy(this);
        }
        
    }
}
