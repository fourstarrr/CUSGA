using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPhysic : MonoBehaviour
{
    [Header("������С")]
    [Tooltip("ģ�����������������ָУ����һֱ����Ļ�·��ƶ�")]
    public float gravity;

    private Rigidbody rb;
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
        rb.AddForce(gravityDirection*gravity);
    }
}
