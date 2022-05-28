using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ShieldCharacterScript : MonoBehaviour
{

    [SerializeField] float maxShield;
    float shield;
    [SerializeField] int shieldInt;


    public float axeSpeed, axeDistance;


    bool wallHit;
    bool onetime;



    [SerializeField] int maxAxeCount;
    public int axeCount;



    

    [SerializeField] Transform axeTip;
    [SerializeField] GameObject Axe;
    [SerializeField] GameObject AxeGameObject;

    [SerializeField] List<GameObject> Axes = new List<GameObject>();

    public float testtimer = 1f;

    Vector2 diraction;
    float angle;


    public float shootTimer;
    public float maxShootTimer;

 public   bool shootBool;
    bool specialAttack;




    PlayerMovement pm;
   
    void Start()
    {

        shootTimer =maxShootTimer;

        pm = GetComponent<PlayerMovement>();
        axeDistance = pm.particleDistance;
      
        axeCount = maxAxeCount;
       
        
    }

    private void FixedUpdate()
    {


        
    }
    void Update()
    {
        diraction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        angle = Mathf.Atan2(diraction.y, diraction.x) * Mathf.Rad2Deg;
        axeTip.transform.rotation = Quaternion.Euler(0f, 0f, angle - 90);
        axeCount = pm.bulletCount;
        maxAxeCount = pm.maxBulletCount;
        IncreaseShield();
       
        
        if(shootBool)
        {
           
            shootTimer -= Time.deltaTime;
            if(shootTimer<=0)
            {
                shootTimer = maxShootTimer;
                shootBool = false;
            }
        }
        
        


       
            if (Input.GetMouseButtonDown(0))
            {

                onetime = true;

                if(shootTimer==maxShootTimer)
                {

                ShootAxe(axeSpeed, axeDistance);
                }
            }
           
                
               
            onetime = false;
                    
                    
                

            
        
        

      
     
        //DestroyAxe();


    }
    void IncreaseShield()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        if (shield <= maxShield && !wallHit)
        {

            float plusShield = Mathf.Abs(v + h) / 10;

            shield += plusShield;
            shieldInt = (int)Math.Round(shield);

        }

    }
   
    void ShootAxe(float speed, float distance)
    {
       
        AxeGameObject = Instantiate(Axe, axeTip.position, Quaternion.identity);
        AxeGameObject.GetComponent<Rigidbody2D>().velocity = axeTip.up * speed;
        Axes.Add(AxeGameObject);
        pm.bulletCount--;
        

        shootBool = true;
        
        
        
    }
    public void DestroyAxe()
    {
        if (Axes.Count > 0)
        {
            foreach (GameObject Axe in Axes.ToArray())
            {

                if (Vector2.Distance(gameObject.transform.position, Axe.transform.position) >= axeDistance)
                {
                    Axes.RemoveAt(0);
                    
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            wallHit = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            wallHit = false;
        }
    }




}
