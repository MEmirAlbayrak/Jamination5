using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float  normalSpeed, nextDash;
    float speed;
   [SerializeField] Transform Spriterenderer;  

    void Start()
    {
       
        speed = normalSpeed;
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Movement();
        Dash();
       
    }
    void Movement()
    {

        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized * speed;

        if (Input.GetAxisRaw("Horizontal") > .1f)
        {
          Spriterenderer.localScale = new Vector3(1f, 1f, 1f);
        }
        if (Input.GetAxisRaw("Horizontal") < -.1f)
        {

            Spriterenderer.localScale = new Vector3(-1f, 1f, 1f);
        }
       
    }
    void Dash()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && Time.time > nextDash)
        {
            nextDash = Time.time + 2;

            
            speed *= 6;
            rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized * speed;
        }
        else
        {
            speed = normalSpeed;
        }



    }
   
}
