using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipper : MonoBehaviour
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

    private HingeJoint hinge; // Flipper的摆臂
    private Rigidbody rb; // Flipper的底座
    private bool isFlipping = false; // Flipper是否正在翻转   
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
            StartCoroutine(Flip1());
        }
        if (Input.GetKeyDown(KeyCode.D) && !isFlipping && flipperType == 2)
        {

            isFlipping = true;
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
            hinge.useMotor = true;
            motor.force = flipperForce;
            motor.targetVelocity = -flipperSpeed;
            hinge.motor = motor;
            angle = Mathf.Abs(hinge.angle);
            yield return null;
        }
    }
}