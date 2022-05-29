using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFxScript : MonoBehaviour
{

    PlayerMovement pm;
    [SerializeField] AudioSource lowhpFx;
    void Start()
    {
        pm = GetComponent<PlayerMovement>();
        lowhpFx = GetComponent<AudioSource>();

    }


    void Update()
    {
        PlayFX();   
    }

    void PlayFX()
    {
        if(pm.hp<30)
        {
            if(!lowhpFx.isPlaying)
            {
                lowhpFx.PlayOneShot(lowhpFx.clip);
            }
        }
    }
}
