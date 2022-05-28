using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ShieldCharacterScript : MonoBehaviour
{

    [SerializeField] float maxShield;
    float shield;
    [SerializeField] int shieldInt;
    [SerializeField] float axeSpeed, axeDistance;


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

    Vector2 diraction;
    float angle;


    public GameObject[] RotatingAxes;

    void Start()
    {
        axeCount = maxAxeCount;
        reloadTimer = reloadMaxTimer;
    }

    private void FixedUpdate()
    {
        
    }
    void Update()
    {


        IncreaseShield();
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
        DestroyAxe();


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
                    Destroy(Axe);
                }
            }
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
