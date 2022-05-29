using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pentagram : MonoBehaviour
{

    void Update()
    {
        transform.Rotate(0, 0, 70 * Time.deltaTime);
    }
}
