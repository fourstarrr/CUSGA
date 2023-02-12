using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baffles : MonoBehaviour
{
    [Header("挡板类型")]
    [Range(0, 1)]
    [Tooltip("值如果是0为左挡板，1则是右挡板")]
    public int bafflesType;


    private bool doAnimator = false;
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    
    void Update()
    {
        ControllBaffles();
    }
    void ControllBaffles()
    {
        if(Input.GetButtonDown("LeftBaffles")&&!doAnimator)
        {
            doAnimator = true;
            anim.SetBool("doAnimator", true);
        }
    }
    public void AnimatorDown()
    {       
        anim.SetBool("doAnimator", false);
    }
    public void AnimatorDownEnd()
    {
        doAnimator = false;
    }
}
