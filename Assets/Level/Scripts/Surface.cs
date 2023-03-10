using UnityEngine;

namespace Assets.Level.Scripts
{
	public class Surface : MonoBehaviour
	{
		[HideInInspector] public int HeightSurface;

		public int MaxHeightSurface;
		public int MaxWidthSurface;

		[Header("Surface Properties")] public int MinHeightSurface;

		public int MinWidthSurface;

		[Header("Surface Spawn")] public GameObject SurfacePlane;

		[HideInInspector] public int WidthSurface;

		void Awake()
		{
			HeightSurface = Random.Range(MinHeightSurface, MaxHeightSurface);
			WidthSurface = Random.Range(MinWidthSurface, MaxWidthSurface);
			SurfacePlane.transform.localScale =
				new Vector3(HeightSurface, WidthSurface, SurfacePlane.transform.localScale.z);
			SurfacePlane.transform.position = new Vector3(HeightSurface / 2, 0, WidthSurface / 2);
		}
	}
}
