using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Character
{
    /// <summary>
    /// ����������Ϣ
    /// ��������������������
    /// </summary>
    [CreateAssetMenu(menuName = "ScriptableObjects/EnemyCharacterStatusInfo")]
    public class EnemyCharacterStatusInfo : ScriptableObject
    {
    

        //������
        [SerializeField] private float attackDamge;
        public float AttackDamge => attackDamge;
        //����ֵ
        [SerializeField] private float maxHealth;
        public float MaxHealth => maxHealth;
        //����
        [SerializeField] private int properties;
        public int Properties => properties;

    }
}