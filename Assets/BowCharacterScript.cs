using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowCharacterScript : MonoBehaviour
{

    PlayerMovement pm;

    GameObject BowGameObject;
    [SerializeField] GameObject Bow;
    [SerializeField] Transform bowTip;
   float speed;

    [SerializeField] float maxSpeed;
    public float moveSpeed;

    bool onetime;

    public bool wallHit;

    bool shootBool;
    public float shootTimer;
    public float maxShootTimer;


    public float bowSpeed, bowDistance;

    public List<GameObject> arrowList;

    Vector2 diraction;
    float angle;

    [SerializeField] PlayerAnimationHandler pah;


    float speedTimer, maxspeedTimer;

    void Start()
    {

        maxspeedTimer = 2f;
        speedTimer = maxspeedTimer;
        shootTimer = maxShootTimer;
        pm = GetComponent<PlayerMovement>();
    }



    void Update()
    {

        IncreaseSpeed();
        diraction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        angle = Mathf.Atan2(diraction.y, diraction.x) * Mathf.Rad2Deg;
        bowTip.transform.rotation = Quaternion.Euler(0f, 0f, angle - 90);

     
        if (shootBool)
        {

            shootTimer -= Time.deltaTime;
            if (shootTimer <= 0)
            {
                shootTimer = maxShootTimer;
                shootBool = false;
            }
        }

        if(shootTimer < maxShootTimer)
        {
            pah.AnimationState("BowIdleAnim");
        }

        if (pm.bulletCount > 0)
        {


            if (Input.GetMouseButtonDown(0))
            {

                onetime = true;

            }
            if (onetime)
            {


                if (shootTimer == maxShootTimer)
                {
                    pah.AnimationState("BowAttackAnim");
                    
                    ShootBow(bowDistance);
                }

                onetime = false;




            }
        }


    }
    void IncreaseSpeed()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        if (pm.Movespeed <= maxSpeed && !wallHit)
        {

            float plusShield = Mathf.Abs(v + h)/100 ;

            pm.Movespeed += plusShield;
        }

    }

    void ShootBow(float distance)
    {
        Quaternion bulletRot = Quaternion.Euler(bowTip.rotation.eulerAngles);
        BowGameObject = Instantiate(Bow, bowTip.position, bulletRot);
        speed = BowGameObject.GetComponent<ThrowableBowScript>().speed;


        if (pm.specialAttackBool)
        {
            if (BowGameObject.GetComponent<ThrowableBowScript>().arrowTrail != null)
            {

                BowGameObject.GetComponent<ThrowableBowScript>().destroyBool = false;
                BowGameObject.GetComponent<ThrowableBowScript>().damage += 10;
                BowGameObject.GetComponent<ThrowableBowScript>().speed = 20f;
                BowGameObject.GetComponent<ThrowableBowScript>().arrowTrail.enabled = true;
                BowGameObject.GetComponent<ThrowableBowScript>().lifeTime = 30;
                pm.specialAttackBool = false;

            }
        }
        else
        {


            if (BowGameObject.GetComponent<ThrowableBowScript>().arrowTrail != null)
            {

                BowGameObject.GetComponent<ThrowableBowScript>().destroyBool = true;
                BowGameObject.GetComponent<ThrowableBowScript>().arrowTrail.enabled = false;
                BowGameObject.GetComponent<ThrowableBowScript>().lifeTime = 15;
            }
        }
        BowGameObject.GetComponent<Rigidbody2D>().velocity = bowTip.up * BowGameObject.GetComponent<ThrowableBowScript>().speed;
        pm.bulletCount--;
        shootBool = true;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       if(collision.gameObject.CompareTag("Wall"))
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
