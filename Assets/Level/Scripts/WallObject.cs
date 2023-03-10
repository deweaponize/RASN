using UnityEngine;

namespace Assets.Level.Scripts
{
	public class WallObject : MonoBehaviour
	{
		void OnCollisionEnter(Collision other)
		{
			if (other.gameObject.GetComponent<DoorObject>() || other.gameObject.GetComponent<Rover>())
			{
				Destroy(gameObject);
			}
		}
	}
}
