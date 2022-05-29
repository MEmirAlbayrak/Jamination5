using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashPointDestroy : MonoBehaviour
{
    GameObject Player;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");

        transform.eulerAngles = new Vector3(0f, 0f, Player.transform.eulerAngles.z);
    }

    // Update is called once per frame
    void Update()
    {
       
        Destroy(gameObject,2f);
        
    }
}
