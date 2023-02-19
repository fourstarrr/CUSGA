using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManage : MonoBehaviour
{
    public float Hp;

    void Start()
    {
        
    }

    void Update()
    {
        HpCheck(); 
    }
    void HpCheck()
    {
        if(Hp<=0)
        {
            return;
        }
    }
}
