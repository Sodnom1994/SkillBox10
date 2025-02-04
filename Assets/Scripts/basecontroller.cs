using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basecontroller : MonoBehaviour
{
    public HingeJoint hingeJoint1; //������ �� ����������
    public HingeJoint hingeJoint2;//������ �� ������ ����������
    private bool isMotorEnabled1 = false; //���� ��� ��������� ������ �������
    private bool isMotorEnabled2 = false; //���� ��� ��������� ������ �������    
    private float maxAngle = 76f;

    private void Start()
    {
        if (hingeJoint1 == null)
        {
            Debug.LogError("������� �����������");
            return;
        }
    }
    private void Update()
    {
        HandleMotorToggle();
        MotorOff();
    }
    void HandleMotorToggle()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            ToggleMotor1();
        }
        if (Input.GetKeyDown(KeyCode.Slash))
        {
            ToggleMotor2();
        }
    }
    void ToggleMotor1()
    {
        isMotorEnabled1 = !isMotorEnabled1;//������ ����                                           
        if (isMotorEnabled1)
        {
            hingeJoint1.useMotor = true;
            Debug.Log("�����1 �������");
            Debug.Log(isMotorEnabled1);
        }
    }
    void ToggleMotor2()
    {
        isMotorEnabled2 = !isMotorEnabled2;//������ ����                                          
        if (isMotorEnabled2)
        {
            hingeJoint2.useMotor = true;
            Debug.Log("�����2 �������");
            Debug.Log(isMotorEnabled2);
        }
    }
    void MotorOff()
    {
        if (isMotorEnabled1 == true && hingeJoint1.angle > maxAngle)
        {
            hingeJoint1.useMotor = false;
            isMotorEnabled1 = !isMotorEnabled1;//������ ����
        }
        if (isMotorEnabled2 == true && hingeJoint2.angle > maxAngle)
        {
            hingeJoint2.useMotor = false;
            isMotorEnabled2 = !isMotorEnabled2;//������ ����
        }
    }

}
