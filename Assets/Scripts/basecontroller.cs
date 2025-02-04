using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basecontroller : MonoBehaviour
{
    public HingeJoint hingeJoint1; //Ссылка на хинтджоинт
    public HingeJoint hingeJoint2;//Ссылка на второй хинтджоинт
    private bool isMotorEnabled1 = false; //Флаг для состояния мотора джоинта
    private bool isMotorEnabled2 = false; //Флаг для состояния мотора джоинта    
    private float maxAngle = 76f;

    private void Start()
    {
        if (hingeJoint1 == null)
        {
            Debug.LogError("Назначь хинтджоинты");
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
        isMotorEnabled1 = !isMotorEnabled1;//меняем флаг                                           
        if (isMotorEnabled1)
        {
            hingeJoint1.useMotor = true;
            Debug.Log("Мотор1 включен");
            Debug.Log(isMotorEnabled1);
        }
    }
    void ToggleMotor2()
    {
        isMotorEnabled2 = !isMotorEnabled2;//меняем флаг                                          
        if (isMotorEnabled2)
        {
            hingeJoint2.useMotor = true;
            Debug.Log("Мотор2 включен");
            Debug.Log(isMotorEnabled2);
        }
    }
    void MotorOff()
    {
        if (isMotorEnabled1 == true && hingeJoint1.angle > maxAngle)
        {
            hingeJoint1.useMotor = false;
            isMotorEnabled1 = !isMotorEnabled1;//меняем флаг
        }
        if (isMotorEnabled2 == true && hingeJoint2.angle > maxAngle)
        {
            hingeJoint2.useMotor = false;
            isMotorEnabled2 = !isMotorEnabled2;//меняем флаг
        }
    }

}
