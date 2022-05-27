using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float  normalSpeed, nextDash;
    float speed;
    DungeonManager dm;
    float shield;

    void Start()
    {
        speed = normalSpeed;
        dm = GameObject.Find("Dungeon Manager").GetComponent<DungeonManager>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        transform.position = new Vector3(dm.minX, dm.minY, transform.position.z);
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
            rb.transform.localScale = new Vector3(4f, 4f, 4f);
        }
        if (Input.GetAxisRaw("Horizontal") < -.1f)
        {

            rb.transform.localScale = new Vector3(-4f, 4f, 4f);
        }
    }
    void Dash()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && Time.time > nextDash)
        {
            nextDash = Time.time + 2;

            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");
            speed *= 6;
            rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized * speed;
        }
        else
        {
            speed = normalSpeed;
        }



    }
    void IncreaseShield()
    {

    }
}
