using UnityEngine;

public class CheckPointSingle : MonoBehaviour
{
	TrackCheckPoint trackCheckPoint;

	void OnTriggerEnter(Collider other)
	{
		if (other.TryGetComponent(out Controller controller))
		{
			trackCheckPoint.CarThroughCheckpoint(this, other.transform);
		}
	}

	public void SetTrackCheckpoint(TrackCheckPoint trackCheckPoint)
	{
		this.trackCheckPoint = trackCheckPoint;
	}
}
