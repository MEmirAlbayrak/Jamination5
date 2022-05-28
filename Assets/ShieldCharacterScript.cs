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



    [SerializeField] float reloadMaxTimer;
    public float reloadTimer;
    bool reloading;

    [SerializeField] Transform axeTip;
    [SerializeField] GameObject Axe;
    [SerializeField] GameObject AxeGameObject;

    [SerializeField] List<GameObject> Axes = new List<GameObject>();
    [SerializeField] float turningSpeed;
    [SerializeField] float RotateAxeDistance;

    Vector2 diraction;
    float angle;


     public List<GameObject> RotatingAxes = new List<GameObject>(2);




   
    bool specialAttackBool;
   public float specialAttackTimer;
    [SerializeField] float  maxSpecialAttackTimer;
   
    void Start()
    {

        specialAttackTimer = maxSpecialAttackTimer;
        axeCount = maxAxeCount;
        reloadTimer = reloadMaxTimer;
        foreach (GameObject axe in RotatingAxes)
        {
            axe.SetActive(false);
        }
            RotatingAxes[0].transform.position = new Vector3(transform.position.x - RotateAxeDistance, transform.position.y, transform.position.z);
        RotatingAxes[1].transform.position = new Vector3(transform.position.x + RotateAxeDistance, transform.position.y, transform.position.z);
    }

    private void FixedUpdate()
    {


        
    }
    void Update()
    {

        
        IncreaseShield();
        CastSpecialAttack();
        diraction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        angle = Mathf.Atan2(diraction.y, diraction.x) * Mathf.Rad2Deg;
        axeTip.transform.rotation = Quaternion.Euler(0f, 0f, angle - 90);


        if (axeCount > 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                onetime = true;

            }
            if (onetime && !reloading)
            {
                ShootAxe(axeSpeed, axeDistance);

            }
        }
        else
        {
            specialAttackBool = true;
            reloading = true;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            reloading = true;

        }
        if (reloading)
        {
            ReloadAxe();
        }
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
    void ReloadAxe()
    {

        reloadTimer -= Time.deltaTime;



        if (reloadTimer <= 0)
        {
            axeCount = maxAxeCount;
            reloadTimer = reloadMaxTimer;
            reloading = false;
        }

    }
    void ShootAxe(float speed, float distance)
    {
        AxeGameObject = Instantiate(Axe, axeTip.position, Quaternion.identity);
        AxeGameObject.GetComponent<Rigidbody2D>().velocity = axeTip.up * speed;
        Axes.Add(AxeGameObject);
        axeCount--;
        onetime = false;
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

     void CastSpecialAttack()
    {
        if(specialAttackBool)
        {
            specialAttackTimer -= Time.deltaTime;
            foreach (GameObject axe in RotatingAxes)
            {

                axe.SetActive(true);
                axe.transform.RotateAround(transform.position, new Vector3(0f, 0f, 1f), -turningSpeed);
                

            }
        }
        if(specialAttackTimer<=0)
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

    private void OnTriggerEnter2D(Collider2D collision)
    {

    }
    private void OnTriggerExit2D(Collider2D collision)
    {

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
