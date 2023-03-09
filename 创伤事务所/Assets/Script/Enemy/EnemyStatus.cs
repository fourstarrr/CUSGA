using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Character
{
    /// <summary>
    /// ���ﱾ��������Ϣ
    /// ���ڿ����˺�������
    /// </summary>
    public class EnemyStatus : MonoBehaviour
    {
        [Header("�˴������Ӧ�Ĺ��������")]
        public EnemyCharacterStatusInfo CharactersInfo;
        [SerializeField] public float enemyCurrentHealth;
        [SerializeField] public float enemyCurrentDamage;
        [SerializeField] public float enemyCurrentProperties;

        void Awake()
        {   //��Ϸ��ʼ���ݳ�ʼ��
            enemyCurrentHealth = CharactersInfo.MaxHealth;
            enemyCurrentDamage = CharactersInfo.AttackDamge;
            enemyCurrentProperties = CharactersInfo.Properties;
           
        }

        
        void Update()
        {
            Death();
        }
        void Death()
        { //����ֵ��0����
            if(enemyCurrentHealth<=0)
            {
                Destroy(gameObject);
            }
        }
        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.tag == "Flipper")
            {//��������֮���������Ҵݻٵ�λ
                GameObject.Find("CharacterManage").GetComponent<CharacterManage>().Hp -= enemyCurrentDamage;
                Destroy(gameObject);
            }
        }
    }
}