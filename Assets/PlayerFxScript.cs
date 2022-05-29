using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFxScript : MonoBehaviour
{

    PlayerMovement pm;
    [SerializeField] AudioSource lowhpFx;
    bool musicPlayed;
    void Start()
    {
        musicPlayed = false;
        pm = GetComponent<PlayerMovement>();
        lowhpFx = GetComponent<AudioSource>();

    }


    void Update()
    {
        PlayFX();  
        if(pm.hp >30)
        {
            musicPlayed = false;
        }   
    }

    void PlayFX()
    {
        if(pm.hp<30)
        {
            if(!musicPlayed)
            {

            if(!lowhpFx.isPlaying)
            {
                musicPlayed = true;
                lowhpFx.PlayOneShot(lowhpFx.clip);
            }
            }
        }
    }
}
