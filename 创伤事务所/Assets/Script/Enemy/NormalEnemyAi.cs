using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
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
