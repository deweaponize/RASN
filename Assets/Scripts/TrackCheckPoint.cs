using System;
using System.Collections.Generic;
using UnityEngine;

public class TrackCheckPoint : MonoBehaviour
{
	[SerializeField] List<Transform> carTransformsList;
	public List<CheckPointSingle> checkPointSinglesList;
	List<int> NextCheckpoint;
	public int NextCheckpointIndex;
	public bool reset;
	public event EventHandler<CarCheckpointEventArgs> OnPlayerCorrectCheckpoint;
	public event EventHandler<CarCheckpointEventArgs> OnPlayerWrongCheckpoint;

	void Awake()
	{
		var CheckpointsTransform = transform.Find("CheckPoints");

		checkPointSinglesList = new List<CheckPointSingle>();
		foreach (Transform CheckPointSingleTransform in CheckpointsTransform)
		{
			var checkPointSingle = CheckPointSingleTransform.GetComponent<CheckPointSingle>();
			checkPointSingle.SetTrackCheckpoint(this);
			checkPointSinglesList.Add(checkPointSingle);
		}

		NextCheckpoint = new List<int>();

		foreach (var carTransform in carTransformsList)
		{
			NextCheckpoint.Add(0);
		}
	}

	public void CarThroughCheckpoint(CheckPointSingle checkPointSingle, Transform carTransform)
	{
		if (!reset)
		{
			NextCheckpointIndex = NextCheckpoint[carTransformsList.IndexOf(carTransform)];
		}
		else
		{
			Debug.Log("reseted");
			NextCheckpointIndex = 0;
		}

		if (checkPointSinglesList.IndexOf(checkPointSingle) == NextCheckpointIndex)
		{
			NextCheckpoint[carTransformsList.IndexOf(carTransform)] =
				(NextCheckpointIndex + 1) % checkPointSinglesList.Count;
			OnPlayerCorrectCheckpoint?.Invoke(this, new CarCheckpointEventArgs { carTransform = carTransform });
		}
		else
		{
			Debug.Log("wrong");
			OnPlayerWrongCheckpoint?.Invoke(this, new CarCheckpointEventArgs { carTransform = carTransform });
		}

		reset = false;
	}

	public CheckPointSingle GetNextCheckpoint(Transform transform)
	{
		return checkPointSinglesList[NextCheckpointIndex];
	}

	public class CarCheckpointEventArgs : EventArgs
	{
		public Transform carTransform;
	}
}
