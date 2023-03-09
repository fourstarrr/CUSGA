using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Character
{
    /// <summary>
    /// 怪物本体属性信息
    /// 用于控制伤害死亡等
    /// </summary>
    public class EnemyStatus : MonoBehaviour
    {
        [Header("此处放入对应的怪物的数据")]
        public EnemyCharacterStatusInfo CharactersInfo;
        [SerializeField] public float enemyCurrentHealth;
        [SerializeField] public float enemyCurrentDamage;
        [SerializeField] public float enemyCurrentProperties;

        void Awake()
        {   //游戏开始数据初始化
            enemyCurrentHealth = CharactersInfo.MaxHealth;
            enemyCurrentDamage = CharactersInfo.AttackDamge;
            enemyCurrentProperties = CharactersInfo.Properties;
           
        }

        
        void Update()
        {
            Death();
        }
        void Death()
        { //生命值归0死亡
            if(enemyCurrentHealth<=0)
            {
                Destroy(gameObject);
            }
        }
        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.tag == "Flipper")
            {//碰到挡板之后死亡并且摧毁单位
                GameObject.Find("CharacterManage").GetComponent<CharacterManage>().Hp -= enemyCurrentDamage;
                Destroy(gameObject);
            }
        }
    }
}