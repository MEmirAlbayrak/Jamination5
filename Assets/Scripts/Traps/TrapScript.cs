using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapScript : MonoBehaviour
{
    [SerializeField] private BoxCollider2D bxcollider;
    [SerializeField] private int damage;
    [SerializeField] private float activationTime;
    [SerializeField] private float animationTime;
    [SerializeField] private float timer;
    private bool trapState;


    // Start is called before the first frame update
    void Start()
    {
        trapState = false;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "") //Player name
        {
            trapState = true;
            timer += Time.deltaTime;
            if (timer >= activationTime && trapState)
            {
                timer = 0;
                while (true)
                {
                    timer += Time.deltaTime;
                    if (timer >= animationTime && trapState)
                    {
                        //Play animation,Hurt player
                        break;
                    }
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        trapState = false;
    }
}