using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class 心灵狙击手 : MonoBehaviour
{
    [Header("攻击间隔")]
    public float attackGap;
    [Header("攻击预制件")]
    public GameObject attackprefab;
    private NavMeshAgent agent;
    private Collider Collider;
    public float attackTime = 0;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        Collider = GetComponent<Collider>();    
    }


    void Update()
    {
        FindFlipper();
        TimeCheck();
    }
    void FindFlipper()
    {
        if ((GameObject.Find("Target").transform.position - transform.position).sqrMagnitude < 300)
        {
            agent.destination = transform.position;
            Attack();
        }
        else
        { agent.destination = GameObject.Find("Target").transform.position; }
    }
    void TimeCheck()
    {
        attackTime -= Time.deltaTime;
    }
    void Attack()
    {
       
        if(attackTime<=0)
        {
            Debug.Log(2);
            float X, Z;
        
            X =  GameObject.Find("Target").transform.position.x - transform.position.x;
            Z = GameObject.Find("Target").transform.position.z - transform.position.z;
            Vector3 direction = new Vector3(X, 0, Z);
            direction.Normalize();
            GameObject attack = Instantiate(attackprefab);
            attack.transform.position = transform.position;
            attack.GetComponent<Rigidbody>().AddForce(direction*50);
            attackTime = attackGap;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            attackTime = attackGap;
            
        }
    }
}
