using UnityEngine;

namespace Assets.Level.Scripts
{
	public class detectCollision : MonoBehaviour
	{
		void OnCollisionEnter(Collision other)
		{
			if (other.gameObject.GetComponent<detectCollision>() || other.gameObject.GetComponent<WallObject>() ||
			    other.gameObject.GetComponent<DoorObject>() || other.gameObject.GetComponent<Rover>())
			{
				Destroy(gameObject);
			}
		}
	}
}
