using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using UnityEngine;

namespace Assets.Level.Scripts
{
	public class RobotAgent : Agent
	{
		[SerializeField] Controller Controller;
		[SerializeField] Transform TargetTransform;

		public override void OnEpisodeBegin()
		{
			// TODO Spawn Rover to RndPos
			// TODO Spawn point to RadPos
		}

		public override void CollectObservations(VectorSensor sensor)
		{
			sensor.AddObservation(transform.position);
			sensor.AddObservation(TargetTransform.position);
		}

		public override void Heuristic(in ActionBuffers actions)
		{
			actions.DiscreteActions.Array[0] = 0;
			actions.DiscreteActions.Array[1] = 0;
			var movement = Input.GetAxis("Vertical");
			var turn = Input.GetAxis("Horizontal");

			actions.DiscreteActions.Array[0] = movement switch
			{
				< 0 => 0,
				0 => 1,
				> 0 => 2,
				_ => actions.DiscreteActions.Array[0]
			};

			Controller.SetSteering(actions.DiscreteActions.Array[1]);

			actions.DiscreteActions.Array[1] = turn switch
			{
				< 0 => 0,
				0 => 1,
				> 0 => 2,
				_ => actions.DiscreteActions.Array[1]
			};

			Controller.SetMotor(actions.DiscreteActions.Array[1]);
		}

		public override void OnActionReceived(ActionBuffers actions)
		{
			switch (actions.DiscreteActions.Array[0])
			{
				case 0:
					Controller.SetMotor(-1);
					break;
				case 1:
					Controller.SetMotor(0);
					break;
				case 2:
					Controller.SetMotor(1);
					break;
			}

			switch (actions.DiscreteActions.Array[1])
			{
				case 0:
					Controller.SetSteering(-1);
					break;
				case 1:
					Controller.SetSteering(0);
					break;
				case 2:
					Controller.SetSteering(1);
					break;
			}
		}
	}
}
