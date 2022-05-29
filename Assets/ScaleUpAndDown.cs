using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleUpAndDown : MonoBehaviour
{

    public float scalef;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scalef = Mathf.Sin(Time.time * 5)+6;
        transform.localScale = new Vector3(scalef, scalef, 5);
    }
}
