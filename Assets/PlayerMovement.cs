using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float normalSpeed, nextDash;
  public  float speed;
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
  public  bool bowChar, AxeChar;


    public TrailRenderer charTrail;
    public GameObject tempHolder,blackHole;

    public bool canReturnToDash;
    Vector3 curPos;

    GameObject tempHolderGO;


   public float countTimer = 0.1f;
    bool countimerBool;


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
        AxeDashSkill();
        Dash();

    }
    private void Update()
    {
        if(countimerBool)
        {

            countTimer -= Time.deltaTime;
        }
        if(countTimer<0f)
        {
            canReturnToDash = true;
            countimerBool = false;
            countTimer = 0.1f;
        }
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
        if (Input.GetKeyDown(KeyCode.LeftShift) && Time.time > nextDash )
        {

            Debug.Log("dashhhh");
            HoldDashPosition();
            BowDashSkill();
            nextDash = Time.time + 2;
            canReturnToDash = true;
            countimerBool = true;
            if(AxeChar) { 
            speed *= 10;
            }
            else
            {
                speed *= 20;
            }
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
        if (AxeChar)
        {
            if(Input.GetKeyDown(KeyCode.LeftShift))
            { 
                if(nextDash >=Time.time && canReturnToDash)
                {

                    transform.position = curPos;
                    canReturnToDash = false;
                    tempHolderGO.SetActive(false);

                   

                }
               
            }
            if(nextDash < Time.time)
            {
                if(tempHolderGO!=null)
                {
                    Destroy(tempHolderGO);
                }
            }

        }
           
            
            
        
    }
    public void BowDashSkill()
    {
        if(bowChar)
        {
           
            tempHolderGO = Instantiate(blackHole, transform.position, Quaternion.identity);
            curPos = tempHolderGO.transform.position;
        }
    }
    public void HoldDashPosition()
    {
        if (AxeChar)
        {
             tempHolderGO = Instantiate(tempHolder, transform.position, Quaternion.identity);
           curPos = tempHolderGO.transform.position;
            
        }

    }

}
