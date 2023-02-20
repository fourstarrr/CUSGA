using Character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPhysic : MonoBehaviour
{
    [Header("������С")]
    [Tooltip("ģ�����������������ָУ����һֱ����Ļ�·��ƶ�")]
    public float gravity;
    [Header("�����˺�")]
    public float damage;
    private Rigidbody rb;
    private float realGravity;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        Vector3 gravityDirection = new Vector3(0, 0, -1);
        rb.AddForce(gravityDirection * gravity);
    }
   
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyStatus>().enemyCurrentHealth -= damage;
        }
    }
}
