using System;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
	bool Cam;
	public float currentBrakeForce;
	public float DelayTime;
	public int MaxMotorTorque;
	public int MaxSteerAngle;
	public Rigidbody rb;

	public float speed = 10;

	// public Camera Cam1;
	// public Camera Cam2;
	public float Togle = 1f;
	public List<WheelRot> WheelProp = new();

	void Start()
	{
		Cursor.lockState = CursorLockMode.Locked;
		//Cam1.enabled = false;
		transform.position.Normalize();
	}

	public void ApplyLocalPositionToVisual(WheelCollider collider)
	{
		if (collider.transform.childCount == 0)
		{
			return;
		}

		var visualWheel = collider.transform.GetChild(0);

		Vector3 Postion;
		Quaternion Rotation;

		collider.GetWorldPose(out Postion, out Rotation);

		visualWheel.transform.position = Vector3.Lerp(visualWheel.transform.position, Postion, Time.deltaTime * speed);
		visualWheel.transform.rotation =
			Quaternion.Lerp(visualWheel.transform.rotation, Rotation, Time.deltaTime * speed);
	}

	void FixedUpdate()
	{
		foreach (var wheelRot in WheelProp)
		{
			ApplyLocalPositionToVisual(wheelRot.LeftWheels);
			ApplyLocalPositionToVisual(wheelRot.RightWheels);
		}
		// Camerashift();
	}

	public void SetMotor(float forwardAmount)
	{
		var Motor = forwardAmount * MaxMotorTorque;
		foreach (var wheelRot in WheelProp)
		{
			if (wheelRot.Motor)
			{
				wheelRot.LeftWheels.motorTorque = Motor;
				wheelRot.RightWheels.motorTorque = Motor;
			}
		}
	}

	public void SetSteering(float TurnAmount)
	{
		var Steering = TurnAmount * MaxSteerAngle;
		foreach (var wheelRot in WheelProp)
		{
			if (wheelRot.Steering)
			{
				wheelRot.LeftWheels.steerAngle = Steering;
				wheelRot.RightWheels.steerAngle = Steering;
			}
		}
	}

	[Serializable]
	public class WheelRot
	{
		public WheelCollider LeftWheels;

		public bool Motor;
		public WheelCollider RightWheels;
		public bool Steering;
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
