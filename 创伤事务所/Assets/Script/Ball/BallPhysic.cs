using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPhysic : MonoBehaviour
{
    [Header("重力大小")]
    [Tooltip("模拟重力，用来调试手感，球会一直朝屏幕下方移动")]
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
