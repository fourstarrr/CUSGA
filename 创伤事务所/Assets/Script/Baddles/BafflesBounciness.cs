using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BafflesBounciness : MonoBehaviour
{
    [Header("击球力度")]
    [Tooltip("当然是击球力度越大球飞出去的速度越快辣")]
    public float addforce;
    private Collider rb;
    void Start()
    {
        rb = GetComponent<Collider>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*private void OnCollisionEnter(Collision collision)
    {
        //检测是否处于可击飞状态，获取撞击点，取-号，施加突然施加的力
        if(collision.gameObject.CompareTag("Ball")&&transform.parent.GetComponent<Baffles>().isImpact)
        {
           
            Vector3 normal = collision.contacts[0].normal;
            Vector3 force = -normal * addforce;
            collision.gameObject.GetComponent<Rigidbody>().AddForce(force, ForceMode.Impulse);
        }
    }*/
    void OnCollisionStay(Collision collision)
    {
        ContactPoint[] contactPoints = collision.contacts;
        if (collision.gameObject.CompareTag("Ball") && transform.parent.GetComponent<Baffles>().isImpact)
        {
            foreach (ContactPoint contactPoint in contactPoints)
            {
                Vector3 normal = contactPoint.normal;
                Vector3 force = -normal * addforce;
                collision.gameObject.GetComponent<Rigidbody>().AddForce(force, ForceMode.Impulse);
            }
        }
    }
}
