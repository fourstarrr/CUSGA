using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
/// <summary>
/// 给怪物设定一个寻路点，怪物会一直朝寻路点前进
/// 
/// </summary>
public class NormalEnemyAi : MonoBehaviour
{

    private NavMeshAgent agent;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
        FindFlipper();
    }
    void FindFlipper()
    {
        agent.destination = GameObject.Find("Target").transform.position;
    }
}
