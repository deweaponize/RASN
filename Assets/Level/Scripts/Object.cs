using System.Collections.Generic;
using UnityEngine;

namespace Assets.Level.Scripts
{
	public class Object : MonoBehaviour
	{
		[Header("Object Instance")] public List<GameObject> _Objects;

		[Header("Spawn Object Or Not")] public bool canloop = true;

		int DepthObject;
		int HeightObject;

		[Header("Surface Info")] public float MarginObject = 0.10f;

		public int MaxDepthObject;
		public int MaxHeightObject;
		int MAXHeightSurface;
		public int MaxWidthObject;
		int MAXWidthSurface;
		public int MinDepthObject;
		public int MinHeightObject;
		int MinHeightSurface;
		public int MinWidthObject;
		int MinWidthSurface;

		[Header("Object Properties")] public int NumberofMaxobject = 120;

		int objectrandom;
		int RandomX;
		int RandomZ;
		int WidthObject;


		public void Update()
		{
			MinHeightSurface = FindObjectOfType<Surface>().GetComponent<Surface>().MinHeightSurface;
			MAXHeightSurface = FindObjectOfType<Surface>().GetComponent<Surface>().HeightSurface;
			MinWidthSurface = FindObjectOfType<Surface>().GetComponent<Surface>().MinWidthSurface;
			MAXWidthSurface = FindObjectOfType<Surface>().GetComponent<Surface>().WidthSurface;
			if (canloop)
			{
				Invoke("ObjectSpawnScale", 1f);
				canloop = false;
			}
		}

		public void ObjectSpawnScale()
		{
			for (var i = 1; i <= NumberofMaxobject; i++)
			{
				HeightObject = Random.Range(MinHeightObject, MaxHeightObject);
				WidthObject = Random.Range(MinWidthObject, MaxWidthObject);
				DepthObject = Random.Range(MinDepthObject, MaxDepthObject);
				RandomX = Random.Range((int)(MarginObject * MAXHeightSurface),
					MAXHeightSurface - (int)(MarginObject * MAXHeightSurface));
				RandomZ = Random.Range((int)(MarginObject * MAXWidthSurface),
					MAXWidthSurface - (int)(MarginObject * MAXWidthSurface));
				objectrandom = Random.Range(0, _Objects.Count);
				_Objects[objectrandom].transform.localScale = new Vector3(HeightObject, DepthObject, WidthObject);
				_Objects[objectrandom].transform.position = new Vector3(Mathf.Floor(RandomX), 0, Mathf.Floor(RandomZ));
				Instantiate(_Objects[objectrandom], _Objects[objectrandom].transform.position,
					Quaternion.Euler(-90, 0, 0));
				// yield return new WaitForSeconds(-1);
			}
			// StartCoroutine(InstantiateObject());
		}

		// IEnumerator InstantiateObject()
		// {
		//     for(int i = 1; i <= NumberofMaxobject; i++)
		//     {
		//         HeightObject = Random.Range(MinHeightObject, MaxHeightObject);
		//         WidthObject = Random.Range(MinWidthObject, MaxWidthObject);
		//         DepthObject = Random.Range(MinDepthObject, MaxDepthObject);
		//         RandomX = Random.Range((int)(MarginObject * MAXHeightSurface), MAXHeightSurface - (int)(MarginObject * MAXHeightSurface));
		//         RandomZ = Random.Range((int)(MarginObject * MAXWidthSurface), MAXWidthSurface - (int)(MarginObject * MAXWidthSurface));
		//         objectrandom = Random.Range(0, _Objects.Count);
		//         _Objects[objectrandom].transform.localScale = new Vector3(HeightObject, DepthObject, WidthObject);
		//         _Objects[objectrandom].transform.position = new Vector3(Mathf.Floor(RandomX), 0, Mathf.Floor(RandomZ));
		//         Instantiate(_Objects[objectrandom] as GameObject, _Objects[objectrandom].transform.position, Quaternion.Euler(-90,0,0));
		//         yield return new WaitForSeconds(-1);
		//     }
		// }
	}
}
