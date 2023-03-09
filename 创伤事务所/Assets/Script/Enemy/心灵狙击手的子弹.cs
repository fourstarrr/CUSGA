using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 心灵狙击手的子弹 : MonoBehaviour
{
    [Header("子弹伤害")]
    public int damage;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag =="Flipper")
        {
            GameObject.Find("CharacterManage").GetComponent<CharacterManage>().Hp-=damage;
            Destroy(gameObject);
        }
    }
}
