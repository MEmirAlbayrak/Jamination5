using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    AudioSource IntroMusic, LoopMusic;


    AudioSource LowHpMusic;
    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("AudioManager");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
    void Start()
    {
        IntroMusic = GameObject.FindGameObjectWithTag("IntroMusic").GetComponent<AudioSource>();
        LoopMusic = GameObject.FindGameObjectWithTag("LoopMusic").GetComponent<AudioSource>();
        //LowHpMusic = GameObject.FindGameObjectWithTag("LowHpMusic").GetComponent<AudioSource>();
        LowHpMusic.mute=true;

        if(!IntroMusic.isPlaying)
        {
            IntroMusic.PlayOneShot(IntroMusic.clip);
        }
    }

 
    void Update()
    {
        PlayLoopMusic();
        if(LowHpMusic !=null)
        {
        PlayLowHpMusic();

        }
        else
        {
            return;
        }
        
    }

    void PlayLoopMusic()
    {
        if(!IntroMusic.isPlaying)
        {
            if(!LoopMusic.isPlaying)
            {
                Debug.Log("loop");
                LoopMusic.Play();
            }
        }
    }

    void PlayLowHpMusic()
    {
        if(!IntroMusic.isPlaying)
        {
            if(!LowHpMusic.isPlaying)
            {
                
                LowHpMusic.Play();
            }
        }

        //if(pl.hp < 30) {
        //
        // LowHpMusic.mute=false;
        //
        //}

        //else {
        //
        //LowHpMusic.mute=true;
        //}



    }

}
