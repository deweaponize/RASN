using UnityEngine;

namespace Assets.Level.Scripts
{
	public class RoverSpawning : MonoBehaviour
	{
		[Header("Can Spawn?")] public static bool CanSpawnRover = true;

		int HeightRover;

		[Header("Values")] public float Margin = 0.10f;

		int MaxHeightRover;

		int MaxWidthRover;
		int MinHeightRover;
		int MinWidthRover;

		[Header("Componenet")] public GameObject Rover;

		public GameObject Target;

		public Vector2 TargetRover;
		int WidthRover;


		// Start is called before the first frame update
		void Start()
		{
			MaxHeightRover = FindObjectOfType<Surface>().GetComponent<Surface>().HeightSurface;
			MaxWidthRover = FindObjectOfType<Surface>().GetComponent<Surface>().WidthSurface;

			MinHeightRover = FindObjectOfType<Surface>().GetComponent<Surface>().MinHeightSurface;
			MinWidthRover = FindObjectOfType<Surface>().GetComponent<Surface>().MinWidthSurface;
		}

		public void Update()
		{
			if (CanSpawnRover)
			{
				Invoke("SpawnRover", 1f);
				CanSpawnRover = false;
			}
		}

		public void SpawnRover()
		{
			HeightRover = Random.Range((int)(Margin * MinHeightRover), MaxHeightRover - (int)(Margin * MaxHeightRover));
			WidthRover = Random.Range((int)(Margin * MinWidthRover), MaxWidthRover - (int)(Margin * MaxWidthRover));
			Debug.Log("Height" + HeightRover + " Width " + WidthRover);
			Instantiate(Rover, new Vector3(HeightRover, 1f, WidthRover), Quaternion.Euler(0, 0, 0));

			TargetRover.x = Random.Range((int)(Margin * MinHeightRover),
				MaxHeightRover - (int)(Margin * MaxHeightRover));
			TargetRover.y = Random.Range((int)(Margin * MinWidthRover), MaxWidthRover - (int)(Margin * MaxWidthRover));
			Instantiate(Target, new Vector3(TargetRover.x, Target.transform.localScale.y, TargetRover.y),
				Quaternion.Euler(0, 0, 0));
		}
	}
}
