using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baffles : MonoBehaviour
{
    [Header("挡板类型")]
    [Range(0, 1)]
    [Tooltip("值如果是0为左挡板，1则是右挡板")]
    public int bafflesType;

    [HideInInspector] public bool isImpact = false;
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
    {//使用动画效果来实现挡板上下翻转的效果
        if(Input.GetButtonDown("LeftBaffles")&&!doAnimator)
        {
            isImpact = true;
            doAnimator = true;
            anim.SetBool("doAnimator", true);
        }
    }
    public void AnimatorDown()
    {       
        anim.SetBool("doAnimator", false);
        isImpact = false;
    }
    public void AnimatorDownEnd()
    {
        doAnimator = false;
    }
}
