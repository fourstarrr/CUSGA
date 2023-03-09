using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baffles : MonoBehaviour
{
    [Header("��������")]
    [Range(0, 1)]
    [Tooltip("ֵ�����0Ϊ�󵲰壬1�����ҵ���")]
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
    {//ʹ�ö���Ч����ʵ�ֵ������·�ת��Ч��
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
