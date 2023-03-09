using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 
/// 用于控制挡板
/// </summary>
public class Flipper1 : MonoBehaviour
{
    [Header("翻转挡板的加速度")]
    public float flipperForce; // Flipper受到的推力
    [Header("最大的翻转速度")]
    public float flipperSpeed; // Flipper翻转速度
    [Header("最大的翻转角度")]
    public float maxAngle = 60f; // Flipper最大偏转角
    [Header("挡板类型")]
    [Tooltip("为1则是左挡板，为2则是右挡板")]
    [Range(1f, 2f)] public int flipperType;
    [Header("额外打击力度")]
    public float addforce;

    private HingeJoint hinge; // Flipper的摆臂
    private Rigidbody rb; // Flipper的底座
    private bool isFlipping = false; // Flipper是否正在翻转   
    public bool isUp = false;//是否上翻
    private JointMotor motor;
    private float angle;
    void Start()
    {
        Time.timeScale = 0.8f;
        hinge = GetComponent<HingeJoint>();
        rb = GetComponent<Rigidbody>();
        motor = hinge.motor;
    }

    void Update()
    {
        ReductionCheck();
        CheckInput();
    }
    void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.A) && !isFlipping && flipperType == 1)
        {

            isFlipping = true;
            isUp = true;
            StartCoroutine(Flip1());
        }
        if (Input.GetKeyDown(KeyCode.D) && !isFlipping && flipperType == 2)
        {

            isFlipping = true;
            isUp = true;
            StartCoroutine(Flip2());
        }
    }
    void ReductionCheck()
    {
        if(transform.rotation.y >=0&&flipperType == 1)
        {
            
            hinge.useMotor = false;
            isFlipping = false;
        }
        if (transform.rotation.y <= 0 && flipperType == 2)
        {

            hinge.useMotor = false;
            isFlipping = false;
        }
    }
    IEnumerator Flip1()
    {
        
        while (angle < maxAngle)
        {
            hinge.useMotor = true;
            motor.force = flipperForce;
            motor.targetVelocity = -flipperSpeed;
            hinge.motor = motor;
            angle = Mathf.Abs(hinge.angle);
            yield return null;
        }
        while (angle >= maxAngle)
        {
            isUp = false;
            hinge.useMotor = true;
            motor.force = flipperForce;
            motor.targetVelocity = flipperSpeed;
            hinge.motor = motor;
            angle = Mathf.Abs(hinge.angle);           
            yield return null;
        }          
    }
    IEnumerator Flip2()
    {

        while (angle < maxAngle)
        {
            hinge.useMotor = true;
            motor.force = flipperForce;
            motor.targetVelocity = flipperSpeed;
            hinge.motor = motor;
            angle = Mathf.Abs(hinge.angle);
            yield return null;
        }
        while (angle >= maxAngle)
        {
            isUp = false;
            hinge.useMotor = true;
            motor.force = flipperForce;
            motor.targetVelocity = -flipperSpeed;
            hinge.motor = motor;
            angle = Mathf.Abs(hinge.angle);
            yield return null;
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        ContactPoint[] contactPoints = collision.contacts;
        if (collision.gameObject.CompareTag("Ball") &&isUp)
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