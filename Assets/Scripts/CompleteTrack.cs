using System;
using System.Collections.Generic;
using System.Linq;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using UnityEngine;
using Random = UnityEngine.Random;

public class CompleteTrack : Agent
{
	float AwardT;
	[SerializeField] Controller controller;
	[SerializeField] readonly float NReward = 0.5f;

	[SerializeField] readonly int numberos = 1;
	public RayPerceptionSensorComponent3D ray;
	[SerializeField] Rigidbody rb;
	readonly List<float> sensordistance = new();
	[SerializeField] Transform SpawnPoint;
	[SerializeField] TrackCheckPoint trackCheckPoint;
	public MeshCollider Tracks1;
	public MeshCollider Tracks2;


	void Awake()
	{
		controller = GetComponent<Controller>();
		ray = GetComponent<RayPerceptionSensorComponent3D>();
		rb = GetComponent<Rigidbody>();
		for (var i = 0; i < numberos; i++)
		{
			sensordistance.Add(0);
		}
	}

	public void Start()
	{
		trackCheckPoint.OnPlayerCorrectCheckpoint += trackCheckPoint_OnCorrectPoint;
		trackCheckPoint.OnPlayerWrongCheckpoint += trackCheckPoint_OnWrongPoint;
	}

	void trackCheckPoint_OnCorrectPoint(object sender, TrackCheckPoint.CarCheckpointEventArgs e)
	{
		if (e.carTransform)
		{
			AddReward(+2f);
		}
	}

	void trackCheckPoint_OnWrongPoint(object sender, TrackCheckPoint.CarCheckpointEventArgs e)
	{
		if (e.carTransform)
		{
			AddReward(2f);
		}
	}

	double Speed()
	{
		return Math.Round(rb.velocity.magnitude / 2.52, 2);
	}

	void AwardSet()
	{
		var a = (float)(sensordistance.Average() * 3 + NReward * Math.Max(0, Speed())) * 2;
		// AddReward(a);
	}

	void Raydistance()
	{
		var rayinp = ray.GetRayPerceptionInput();
		var rayout = RayPerceptionSensor.Perceive(rayinp);
		for (var i = 0; i < numberos; i++)
		{
			var distance = rayout.RayOutputs[i].HitFraction;
			sensordistance[i] = distance;
		}
	}


	void FixedUpdate()
	{
		Raydistance();
		AwardT += Time.deltaTime;
		if (AwardT >= 1f)
		{
			AwardT = AwardT % 1;
			AwardSet();
		}
	}

	public override void OnEpisodeBegin()
	{
		transform.position =
			SpawnPoint.transform.position + new Vector3(Random.Range(2f, -2f), 0, Random.Range(2f, -2f));
		transform.forward = SpawnPoint.transform.forward;
		trackCheckPoint.reset = true;
	}

	public override void CollectObservations(VectorSensor sensor)
	{
		var checkpointForward = trackCheckPoint.GetNextCheckpoint(transform).transform.forward;
		var DirectionDot = Vector3.Dot(transform.forward, checkpointForward);
		sensor.AddObservation(transform.position);
		sensor.AddObservation(DirectionDot);
		sensor.AddObservation(Tracks1);
		sensor.AddObservation(Tracks2);
	}

	public override void Heuristic(in ActionBuffers actions)
	{
		actions.DiscreteActions.Array[0] = 0;
		actions.DiscreteActions.Array[1] = 0;
		var Movement = Input.GetAxis("Vertical");
		var Turn = Input.GetAxis("Horizontal");

		if (Movement < 0)
		{
			actions.DiscreteActions.Array[0] = 0;
		}
		else if (Movement == 0)
		{
			actions.DiscreteActions.Array[0] = 1;
		}
		else if (Movement > 0)
		{
			actions.DiscreteActions.Array[0] = 2;
		}

		controller.SetSteering(actions.DiscreteActions.Array[1]);

		if (Turn < 0)
		{
			actions.DiscreteActions.Array[1] = 0;
		}
		else if (Turn == 0)
		{
			actions.DiscreteActions.Array[1] = 1;
		}
		else if (Turn > 0)
		{
			actions.DiscreteActions.Array[1] = 2;
		}

		controller.SetMotor(actions.DiscreteActions.Array[1]);
	}

	public override void OnActionReceived(ActionBuffers actions)
	{
		switch (actions.DiscreteActions.Array[0])
		{
			case 0:
				controller.SetMotor(-1);
				AddReward(-0.6f);
				break;
			case 1:
				controller.SetMotor(0);
				AddReward(-1f);
				break;
			case 2:
				controller.SetMotor(1);
				// AddReward(0.2f);
				break;
		}

		switch (actions.DiscreteActions.Array[1])
		{
			case 0:
				controller.SetSteering(-1);
				break;
			case 1:
				controller.SetSteering(0);
				break;
			case 2:
				controller.SetSteering(1);
				break;
		}
	}

	void OnCollisionEnter(Collision Collision)
	{
		if (Collision.gameObject.TryGetComponent(out Wall wall))
		{
			AddReward(-5f);
			EndEpisode();
		}
	}
}
