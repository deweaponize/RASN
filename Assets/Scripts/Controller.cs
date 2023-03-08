using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 10;
    public float currentBrakeForce;
    public float DelayTime;
    private bool Cam;
    // public Camera Cam1;
    // public Camera Cam2;
    public float Togle = 1f;

    [System.Serializable]
    public class WheelRot{
        public WheelCollider LeftWheels;
        public WheelCollider RightWheels;

        public bool Motor;
        public bool Steering;
    }
    public List<WheelRot> WheelProp = new List<WheelRot>();
    public int MaxMotorTorque;
    public int MaxSteerAngle;
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        //Cam1.enabled = false;
        this.transform.position.Normalize();
    }

    public void ApplyLocalPositionToVisual(WheelCollider collider){
        
        if (collider.transform.childCount == 0)
        {
            return;
        }

        Transform visualWheel = collider.transform.GetChild(0);

        Vector3 Postion;
        Quaternion Rotation;

        collider.GetWorldPose(out Postion, out Rotation);

        visualWheel.transform.position = Vector3.Lerp(visualWheel.transform.position, Postion , Time.deltaTime * speed);
        visualWheel.transform.rotation = Quaternion.Lerp(visualWheel.transform.rotation,  Rotation, Time.deltaTime * speed);
    }

    void FixedUpdate()
    {
        foreach(WheelRot wheelRot in WheelProp)
        {
            ApplyLocalPositionToVisual(wheelRot.LeftWheels);
            ApplyLocalPositionToVisual(wheelRot.RightWheels);
        }
        // Camerashift();
    }

    public void SetMotor(float forwardAmount)
    {

        float Motor = forwardAmount * MaxMotorTorque;
        foreach(WheelRot wheelRot in WheelProp)
        {      
            if(wheelRot.Motor == true)
            {
                wheelRot.LeftWheels.motorTorque = Motor;
                wheelRot.RightWheels.motorTorque = Motor;
            }
        }
    }

    public void SetSteering(float TurnAmount)
    {
        float Steering = TurnAmount * MaxSteerAngle; 
        foreach(WheelRot wheelRot in WheelProp)
        {
            if(wheelRot.Steering == true)
            {
                wheelRot.LeftWheels.steerAngle = Steering;
                wheelRot.RightWheels.steerAngle = Steering;
                
            }
        }
    }

    // void Camerashift()
    // {
    //     DelayTime += Time.deltaTime;
    //     if (Input.GetKey(KeyCode.Q) && DelayTime >= Togle)
    //     {
    //         Cam = !Cam;
    //         DelayTime = 0f;
    //     }

    //     if(Cam)
    //     {
    //         Cam1.enabled = true;
    //         Cam2.enabled = false;
    //     }
    //     else
    //     {
    //         Cam1.enabled = false; 
    //         Cam2.enabled = true;
    //     }
    // }
    
}