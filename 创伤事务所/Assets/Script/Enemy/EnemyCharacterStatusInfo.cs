using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Character
{
    /// <summary>
    /// 怪物属性信息
    /// 用于批量制作怪物数据
    /// </summary>
    [CreateAssetMenu(menuName = "ScriptableObjects/EnemyCharacterStatusInfo")]
    public class EnemyCharacterStatusInfo : ScriptableObject
    {
    

        //攻击力
        [SerializeField] private float attackDamge;
        public float AttackDamge => attackDamge;
        //生命值
        [SerializeField] private float maxHealth;
        public float MaxHealth => maxHealth;
        //属性
        [SerializeField] private int properties;
        public int Properties => properties;

    }
}