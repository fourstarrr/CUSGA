using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 
/// ���ڿ��Ƶ���
/// </summary>
public class Flipper1 : MonoBehaviour
{
    [Header("��ת����ļ��ٶ�")]
    public float flipperForce; // Flipper�ܵ�������
    [Header("���ķ�ת�ٶ�")]
    public float flipperSpeed; // Flipper��ת�ٶ�
    [Header("���ķ�ת�Ƕ�")]
    public float maxAngle = 60f; // Flipper���ƫת��
    [Header("��������")]
    [Tooltip("Ϊ1�����󵲰壬Ϊ2�����ҵ���")]
    [Range(1f, 2f)] public int flipperType;
    [Header("����������")]
    public float addforce;

    private HingeJoint hinge; // Flipper�İڱ�
    private Rigidbody rb; // Flipper�ĵ���
    private bool isFlipping = false; // Flipper�Ƿ����ڷ�ת   
    public bool isUp = false;//�Ƿ��Ϸ�
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