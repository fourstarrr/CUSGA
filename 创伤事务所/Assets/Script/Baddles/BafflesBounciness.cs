using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BafflesBounciness : MonoBehaviour
{
    [Header("��������")]
    [Tooltip("��Ȼ�ǻ�������Խ����ɳ�ȥ���ٶ�Խ����")]
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
        //����Ƿ��ڿɻ���״̬����ȡײ���㣬ȡ-�ţ�ʩ��ͻȻʩ�ӵ���
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
