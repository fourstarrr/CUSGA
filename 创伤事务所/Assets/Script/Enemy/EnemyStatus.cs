using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Character
{
    public class EnemyStatus : MonoBehaviour
    {
        [Header("此处放入对应的怪物的数据")]
        public EnemyCharacterStatusInfo CharactersInfo;
        [SerializeField] public float enemyCurrentHealth;
        [SerializeField] public float enemyCurrentDamage;
        [SerializeField] public float enemyCurrentProperties;

        void Start()
        {
            enemyCurrentHealth = CharactersInfo.MaxHealth;
            enemyCurrentDamage = CharactersInfo.AttackDamge;
            enemyCurrentProperties = CharactersInfo.Properties;
           
        }

        
        void Update()
        {

        }
        void Death()
        {
            if(enemyCurrentHealth<=0)
            {
                Destroy(gameObject);
            }
        }
        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.tag == "Flipper")
            {
                GameObject.Find("CharacterManage").GetComponent<CharacterManage>().Hp -= enemyCurrentDamage;
                Destroy(gameObject);
            }
        }
    }
}