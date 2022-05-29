using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapScript : MonoBehaviour
{
    [SerializeField] private BoxCollider2D bxcollider;
    [SerializeField] private int damage;
    [SerializeField] private float activationTime;
    [SerializeField] private float timer;
    private bool trapState;


    // Start is called before the first frame update
    void Start()
    {
        trapState = false;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("dsadasd");
        if (col.gameObject.CompareTag("Player")) //Player name
        {
            trapState = true;
            timer += Time.deltaTime;
            Debug.Log("Yup");
            
            if (timer >= activationTime && trapState)
            {
                timer = 0;
                //Play animation,Hurt player
                Debug.Log("Bruh");
            }
        }
    }
    

    private void OnTriggerExit2D(Collider2D other)
    {
        trapState = false;
    }
}