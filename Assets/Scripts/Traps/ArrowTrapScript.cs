using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTrapScript : MonoBehaviour
{
    [SerializeField] private BoxCollider2D bxCollider;
    [SerializeField] private float fireRate;
    [SerializeField] private Transform firePoint;
    [SerializeField] private List<GameObject> Arrows = new List<GameObject>();
    private Vector2 direction;
    private float timer;

    private bool wallHit;
    //[SerializeField] private float maxRange;
    //[SerializeField] private int maxArrowCount;
    //public int arrowCount;


    private void ShootArrow()
    {
        timer = 0;
        Arrows[FindArrow()].transform.position = firePoint.position;
        Arrows[FindArrow()].GetComponent<ArrowBehaviour>().ActivateProjectile();
    }

    private int FindArrow()
    {
        for (int i = 0; i < Arrows.Count; i++)
        {
            if (!Arrows[i].activeInHierarchy)
                return i;
        }

        return 0;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= fireRate)
        {
            ShootArrow();
        }
    }

    
}