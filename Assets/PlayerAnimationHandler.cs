using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationHandler : MonoBehaviour
{

    Animator anim;
    string curState;
    public bool afterAnim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }


    public void AnimationState(string newState)
    {
        if (curState == newState)
        {
            return;
        }

        anim.Play(newState);
        

        curState = newState;

    }
}
