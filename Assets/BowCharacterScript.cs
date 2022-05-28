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



    bool onetime;



    bool shootBool;
    public float shootTimer;
    public float maxShootTimer;


    public float bowSpeed, bowDistance;

    public List<GameObject> arrowList;

    Vector2 diraction;
    float angle;


    void Start()
    {
        shootTimer = maxShootTimer;
        pm = GetComponent<PlayerMovement>();
    }



    void Update()
    {


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

        if (pm.bulletCount > 0)
        {

            
            if (Input.GetMouseButtonDown(0))
            {

                onetime = true;

            }
            if (onetime )
            {


                if (shootTimer == maxShootTimer)
                {

                    ShootBow( bowDistance);
                }
                onetime = false;




            }
        }
    }
    void ShootBow( float distance)
    {

        BowGameObject = Instantiate(Bow, bowTip.position, Quaternion.identity);
         speed = BowGameObject.GetComponent<ThrowableBowScript>().speed;
       

        if (pm.specialAttackBool)
        {
            if(BowGameObject.GetComponent<ThrowableBowScript>().arrowTrail!=null)
            {
                BowGameObject.GetComponent<ThrowableBowScript>().speed *= 3;
            BowGameObject.GetComponent<ThrowableBowScript>().arrowTrail.enabled = true;
                BowGameObject.GetComponent<ThrowableBowScript>().lifeTime = 30;
                pm.specialAttackBool = false;
                
            }
        }
        else
        {


            if(BowGameObject.GetComponent<ThrowableBowScript>().arrowTrail != null)
            {
                
            BowGameObject.GetComponent<ThrowableBowScript>().arrowTrail.enabled = false;
                BowGameObject.GetComponent<ThrowableBowScript>().lifeTime = 15;
            }
        }
        BowGameObject.GetComponent<Rigidbody2D>().velocity = bowTip.up * BowGameObject.GetComponent<ThrowableBowScript>().speed;
        pm.bulletCount--;
        shootBool = true;
        
    }
}
