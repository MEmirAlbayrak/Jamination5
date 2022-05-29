using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] AudioSource clickAudio;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void ChangeSceanePls()
    {
        SceneManager.LoadScene(4);
    }

    public void ClickAudio()
    {
        if(!clickAudio.isPlaying)
        {
            clickAudio.PlayOneShot(clickAudio.clip);
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
