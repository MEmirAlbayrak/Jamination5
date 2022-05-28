using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowableBowScript : MonoBehaviour
{

    PlayerMovement scs;
    public TrailRenderer arrowTrail;
    public float lifeTime;
    public float speed;
    private void Awake()
    {
        
        arrowTrail = GetComponentInChildren<TrailRenderer>();
    }
    void Start()
    {
        scs = GameObject.FindObjectOfType<PlayerMovement>();
    }

    void Update()
    {
        
        if (Vector2.Distance(scs.transform.position, transform.position) >= lifeTime)
        {
            Destroy(gameObject);
        }


    }
}
