using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float normalSpeed, nextDash;
    float speed;
    [SerializeField] Transform Spriterenderer;
    public int bulletCount;
    public int maxBulletCount;

    public bool AxePlayerActive, BowPlayerActive;
    public bool reloading;

    public float reloadTimer;
    [SerializeField] float reloadMaxTimer;
    [SerializeField] GameObject BowPlayer, AxePlayer;

    public float particleDistance;


    [SerializeField] float turningSpeed;
    [SerializeField] float RotateAxeDistance;
    public List<GameObject> RotatingAxes = new List<GameObject>(2);


   public bool specialAttackBool;
    public float specialAttackTimer;
    [SerializeField] float maxSpecialAttackTimer;

    [SerializeField] ShieldCharacterScript scs;
    [SerializeField] BowCharacterScript bcs;
    bool playerswitch;
    bool bowChar, AxeChar;


    public TrailRenderer charTrail;
    private void Awake()
    {
        bowChar =false;
        AxeChar = true;
        scs = GetComponent<ShieldCharacterScript>();
        bcs = GetComponent<BowCharacterScript>();
    }
    void Start()
    {
       
        specialAttackTimer = maxSpecialAttackTimer;

        speed = normalSpeed;
        rb = gameObject.GetComponent<Rigidbody2D>();
        reloadTimer = reloadMaxTimer;
        bulletCount = maxBulletCount;

        foreach (GameObject axe in RotatingAxes)
        {
            axe.SetActive(false);
        }
        RotatingAxes[0].transform.position = new Vector3(transform.position.x - RotateAxeDistance, transform.position.y, transform.position.z);
        RotatingAxes[1].transform.position = new Vector3(transform.position.x + RotateAxeDistance, transform.position.y, transform.position.z);

        if (gameObject.name == "AxePlayer")
        {
            bcs.enabled = false;
        }
        else
        {
            scs.enabled = false;
        }


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Movement();
        Dash();

    }
    private void Update()
    {

        scs = GetComponent<ShieldCharacterScript>();
        bcs = GetComponent<BowCharacterScript>();

       
        if (bulletCount == 4 && Input.GetMouseButtonDown(0) && AxeChar)
        {
            Debug.Log("first");
            specialAttackBool = true;
        }

        if(bulletCount ==7 && Input.GetMouseButtonDown(0)&& bowChar)
        {
            specialAttackBool = true;
        }
        if (bulletCount > 0)
        {

            if (Input.GetKeyDown(KeyCode.R))
            {
                reloading = true;
            }
        }


        //if (reloading)
        //{
        //    ReloadBullet();
        //}

        if (bulletCount <= 0)
        {
           
            playerswitch = true;
            reloading = true;
        }
        if (scs.enabled)
        {

            CastAxeSpecialAttack();
        }
        else
        {
            CastBowSpecialAttack();
        }




        
        if (scs.enabled)
        {
            if (playerswitch)
            {
                charTrail.enabled = true;
                bcs.enabled = true;
                maxBulletCount = 7;
                bulletCount = maxBulletCount;
                bcs.shootTimer = bcs.maxShootTimer;
                scs.enabled = false;
                playerswitch = false;
                bowChar = true;
                AxeChar = false;
                reloadTimer = reloadMaxTimer;
            }
        }
        if (bcs.enabled)
        {
            if (playerswitch)
            {

                charTrail.enabled =false;
                scs.shootBool = false;
                scs.enabled = true;
                bcs.enabled = false;
                maxBulletCount = 4;
                bulletCount = maxBulletCount;
                playerswitch = false;
                scs.shootTimer = scs.maxShootTimer;
                bowChar = false;
                AxeChar = true;
                reloadTimer = reloadMaxTimer;
            }
        }




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


            speed *= 10;
            rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized * speed;
        }
        else
        {
            speed = normalSpeed;
        }



    }
    void ReloadBullet()
    {

        reloadTimer -= Time.deltaTime;



        if (reloadTimer <= 0)
        {
            bulletCount = maxBulletCount;
            reloadTimer = reloadMaxTimer;
            reloading = false;
        }

    }
    void CastAxeSpecialAttack()
    {
        if (specialAttackBool)
        {
            specialAttackTimer -= Time.deltaTime;
            foreach (GameObject axe in RotatingAxes)
            {

                axe.SetActive(true);
                axe.transform.RotateAround(transform.position, new Vector3(0f, 0f, 1f), -turningSpeed);


            }
        }
        if (specialAttackTimer <= 0.9)
        {
            specialAttackBool = false;
            foreach (GameObject axe in RotatingAxes)
            {

                RotatingAxes[0].transform.position = new Vector3(transform.position.x - RotateAxeDistance, transform.position.y, transform.position.z);
                RotatingAxes[1].transform.position = new Vector3(transform.position.x + RotateAxeDistance, transform.position.y, transform.position.z);
                axe.transform.eulerAngles = new Vector3(0f, 0f, 0f);
                axe.SetActive(false);

                
            }
            specialAttackTimer = maxSpecialAttackTimer;
        }
    }
  public  void CastBowSpecialAttack()
    {
        if(specialAttackBool)
        {
            bcs.bowDistance += 40f;

        }
    }
    public void AxeDashSkill()
    {
        if(AxeChar)
        {
            Vector3 curPos = transform.position;
            if(Time.time < nextDash)
            {
                if(Input.GetKeyDown(KeyCode.LeftShift))
                {
                    transform.position = curPos;
                }
            }
           
            
            
        }
    }

}
