using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class 小型心魔 : MonoBehaviour
{

    private NavMeshAgent agent;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

    }

    
    void Update()
    {
        FindFlipper();
    }
    void FindFlipper()
    {
        agent.destination = GameObject.Find("Target").transform.position;
    }
}
