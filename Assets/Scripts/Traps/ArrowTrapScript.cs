using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTrapScript : MonoBehaviour
{

    [SerializeField] private CapsuleCollider2D _capsuleCollider2D;
    [SerializeField] private int damage;
    [SerializeField] private float speed;
    [SerializeField] private float maxRange;
    //[SerializeField] private int maxArrowCount;
    //public int arrowCount;
    [SerializeField] private float fireRate;
    [SerializeField] private GameObject Arrow;
    [SerializeField] private GameObject ArrowGameObject;
    [SerializeField] private List<GameObject> Arrows = new List<GameObject>();
    private Vector2 direction;
    private float timer;

    private bool wallHit;

    private void ShootArrow(float speed, float distance, float fireRate)
    {
        timer = Time.deltaTime;
        if (timer >= fireRate)
        {
            ArrowGameObject = Instantiate(Arrow, direction, Quaternion.identity);
            ArrowGameObject.GetComponent<Rigidbody2D>().velocity = (direction * speed);
            Arrows.Add(ArrowGameObject);
            timer = 0;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "") //Player name
        {
            //Hurt player
            Destroy(this);
        }

        else if (other.gameObject.name == "Wall")
        {
            Destroy(this);
        }
    }

}
