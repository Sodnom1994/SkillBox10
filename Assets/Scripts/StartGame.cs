using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class StartGame : MonoBehaviour
{
       public ConfigurableJoint joint;
    public float pullDistance = -1f;
    public float motorForce = 1000f;
    private bool isPulling = false;

    void Start()
    {
        if(joint == null)
        {
            Debug.LogError("Конфигур джоинт не назначен");
            return;
        }
        
    }
    void Update()
    {
        HandleInput();
    }
    void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            StartPulling();
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            StopPulling();
        }
    }
    void StartPulling()
    {
        joint.xDrive = new JointDrive
        {
            positionSpring = motorForce,
            positionDamper=0,
            maximumForce = pullDistance
        };
        joint.targetPosition = new Vector3(pullDistance, 0, 0);
        isPulling = true;
        Debug.Log("Заряжаем платформу");
    }
    void StopPulling()
    {
        joint.xDrive = new JointDrive
        {
            positionSpring = 0,
            positionDamper = 0,
            maximumForce = 0
        };
        isPulling = false;
        Debug.Log("Запускаем платформу");
    }
}
