using System.Collections.Generic;
using UnityEngine;

namespace Assets.Level.Scripts
{
	public class WallGeneration : MonoBehaviour
	{
		[Header("Wall Instances")] public GameObject CornerWallPiece;

		[Header("Arrays")] public List<Vector3> CurrentWallPos;

		float DistanceBetween;
		public GameObject DoorPoint;
		int DoorPointPos;
		public RaycastHit hit;
		public Vector2 Margin = new(10, 10);
		public float MarginWall = 0.05f;
		int MAXHeightSurface;
		int MAXWidthSurface;

		[Header("Wall Properties")] public int NumberofWalls = 3;

		readonly List<Vector3> Pillarpos = new();
		int RandomX;
		int RandomZ;
		public int sizofDoor;
		public GameObject WallSegment;
		int WallX;
		int WallY;

		void Start()
		{
			MAXHeightSurface = FindObjectOfType<Surface>().GetComponent<Surface>().HeightSurface;
			MAXWidthSurface = FindObjectOfType<Surface>().GetComponent<Surface>().WidthSurface;
			sizofDoor = (int)DoorPoint.GetComponentInChildren<Transform>().Find("Door").transform.localScale.z;

			BoundaryWallGen();
			while (NumberofWalls - 1 >= 0)
			{
				RandomX = Random.Range((int)(MarginWall * MAXHeightSurface),
					MAXHeightSurface - (int)(MarginWall * MAXHeightSurface));
				RandomZ = Random.Range((int)(MarginWall * MAXWidthSurface),
					MAXWidthSurface - (int)(MarginWall * MAXWidthSurface));

				var rotationincrm = 0;
				Vector3[] directionname =
				{
					Vector3.right,
					Vector3.forward,
					-Vector3.right,
					-Vector3.forward
				};

				if (CheckPillarPos(RandomX, RandomZ))
				{
					CornerWallPiece.transform.position = new Vector3(Mathf.Floor(RandomX), 10f, Mathf.Floor(RandomZ));
					Instantiate(CornerWallPiece, CornerWallPiece.transform.position, Quaternion.identity);
					Pillarpos.Add(CornerWallPiece.transform.position);
					foreach (var diec in directionname)
					{
						PointRaycasts(diec, rotationincrm);
						rotationincrm += 90;
					}
				}
				else
				{
					continue;
				}

				NumberofWalls -= 1;
			}
		}

		public bool CheckPillarPos(int pointx, int pointz)
		{
			if (Pillarpos.Count == 0)
			{
				return true;
			}

			for (var i = 0; i < Pillarpos.Count; ++i)
			{
				if (Mathf.Abs(pointx - Pillarpos[i].x) < Margin.x || Mathf.Abs(pointz - Pillarpos[i].z) < Margin.y)
				{
					return false;
				}
			}

			return true;
		}

		void BoundaryWallGen()
		{
			WallSegment.transform.localScale = new Vector3(WallSegment.transform.localScale.x,
				WallSegment.transform.localScale.y, MAXHeightSurface);
			Instantiate(WallSegment, Vector3.zero, Quaternion.Euler(0, -90, 0));
			WallSegment.transform.localScale = new Vector3(WallSegment.transform.localScale.x,
				WallSegment.transform.localScale.y, MAXWidthSurface);
			Instantiate(WallSegment, Vector3.zero, Quaternion.Euler(0, -180, 0));
			WallSegment.transform.localScale = new Vector3(WallSegment.transform.localScale.x,
				WallSegment.transform.localScale.y, MAXHeightSurface);
			Instantiate(WallSegment, new Vector3(MAXHeightSurface, 0, MAXWidthSurface), Quaternion.Euler(0, 90, 0));
			WallSegment.transform.localScale = new Vector3(WallSegment.transform.localScale.x,
				WallSegment.transform.localScale.y, MAXWidthSurface);
			Instantiate(WallSegment, new Vector3(MAXHeightSurface, 0, MAXWidthSurface), Quaternion.Euler(0, 0, 0));
		}

		void PointRaycasts(Vector3 direction, int rotation)
		{
			if (direction == Vector3.right)
			{
				Debug.DrawRay(
					new Vector3(CornerWallPiece.transform.position.x + 1f, 5f, CornerWallPiece.transform.position.z),
					direction, Color.red, Mathf.Infinity);
				if (Physics.Raycast(
					    new Vector3(CornerWallPiece.transform.position.x + 1f, 5f,
						    CornerWallPiece.transform.position.z), direction, out hit, Mathf.Infinity))
				{
					if (hit.collider.tag == "Wall")
					{
						DoorPointPos = (int)Random.Range(CornerWallPiece.transform.position.x + sizofDoor,
							hit.point.x - sizofDoor * 2);
						WallSegment.transform.position = new Vector3(CornerWallPiece.transform.position.x + 1f, 0,
							CornerWallPiece.transform.position.z);
						WallSegment.transform.localScale = new Vector3(WallSegment.transform.localScale.x,
							WallSegment.transform.localScale.y,
							Mathf.Abs(WallSegment.transform.position.x - DoorPointPos));
						Instantiate(WallSegment, WallSegment.transform.position,
							Quaternion.Euler(0f, rotation - 90, 0f));
						Instantiate(DoorPoint,
							new Vector3(DoorPointPos, WallSegment.transform.position.y,
								WallSegment.transform.position.z), Quaternion.Euler(0f, rotation + 90, 0f));
						WallSegment.transform.position = new Vector3(DoorPointPos + sizofDoor, 0,
							CornerWallPiece.transform.position.z);
						WallSegment.transform.localScale = new Vector3(WallSegment.transform.localScale.x,
							WallSegment.transform.localScale.y, Mathf.Abs(DoorPointPos + sizofDoor - hit.point.x));
						Instantiate(WallSegment, WallSegment.transform.position,
							Quaternion.Euler(0f, rotation - 90, 0f));
					}
				}
			}

			if (direction == Vector3.forward)
			{
				if (Physics.Raycast(
					    new Vector3(CornerWallPiece.transform.position.x, 5f,
						    CornerWallPiece.transform.position.z + 1f), direction, out hit, Mathf.Infinity))
				{
					if (hit.collider.tag == "Wall")
					{
						DoorPointPos = (int)Random.Range(CornerWallPiece.transform.position.z + sizofDoor,
							hit.point.z - sizofDoor * 2);
						WallSegment.transform.position = new Vector3(CornerWallPiece.transform.position.x, 0,
							CornerWallPiece.transform.position.z + 1f);
						WallSegment.transform.localScale = new Vector3(WallSegment.transform.localScale.x,
							WallSegment.transform.localScale.y,
							Mathf.Abs(WallSegment.transform.position.z - DoorPointPos));
						Instantiate(WallSegment, WallSegment.transform.position,
							Quaternion.Euler(0f, rotation + 90, 0f));
						Instantiate(DoorPoint,
							new Vector3(WallSegment.transform.position.x, WallSegment.transform.position.y,
								DoorPointPos), Quaternion.Euler(0f, rotation - 90, 0f));
						WallSegment.transform.position = new Vector3(CornerWallPiece.transform.position.x, 0,
							DoorPointPos + sizofDoor);
						WallSegment.transform.localScale = new Vector3(WallSegment.transform.localScale.x,
							WallSegment.transform.localScale.y, Mathf.Abs(DoorPointPos + sizofDoor - hit.point.z));
						Instantiate(WallSegment, WallSegment.transform.position,
							Quaternion.Euler(0f, rotation + 90, 0f));
					}
				}
			}

			if (direction == -Vector3.right)
			{
				if (Physics.Raycast(
					    new Vector3(CornerWallPiece.transform.position.x - 1f, 5f,
						    CornerWallPiece.transform.position.z), direction, out hit, Mathf.Infinity))
				{
					if (hit.collider.tag == "Wall")
					{
						DoorPointPos = (int)Random.Range(CornerWallPiece.transform.position.x - sizofDoor,
							hit.point.x + sizofDoor * 2);
						WallSegment.transform.position = new Vector3(CornerWallPiece.transform.position.x - 1f, 0,
							CornerWallPiece.transform.position.z);
						WallSegment.transform.localScale = new Vector3(WallSegment.transform.localScale.x,
							WallSegment.transform.localScale.y,
							Mathf.Abs(WallSegment.transform.position.x - DoorPointPos));
						Instantiate(WallSegment, WallSegment.transform.position,
							Quaternion.Euler(0f, rotation - 90, 0f));
						Instantiate(DoorPoint,
							new Vector3(DoorPointPos, WallSegment.transform.position.y,
								WallSegment.transform.position.z), Quaternion.Euler(0f, rotation + 90, 0f));
						WallSegment.transform.position = new Vector3(DoorPointPos - sizofDoor, 0,
							CornerWallPiece.transform.position.z);
						WallSegment.transform.localScale = new Vector3(WallSegment.transform.localScale.x,
							WallSegment.transform.localScale.y, Mathf.Abs(DoorPointPos - sizofDoor - hit.point.x));
						Instantiate(WallSegment, WallSegment.transform.position,
							Quaternion.Euler(0f, rotation - 90, 0f));
					}
				}
			}

			if (direction == -Vector3.forward)
			{
				if (Physics.Raycast(
					    new Vector3(CornerWallPiece.transform.position.x, 5f,
						    CornerWallPiece.transform.position.z - 1f), direction, out hit, Mathf.Infinity))
				{
					if (hit.collider.tag == "Wall")
					{
						DoorPointPos = (int)Random.Range(CornerWallPiece.transform.position.z - sizofDoor,
							hit.point.z + sizofDoor * 2);
						WallSegment.transform.position = new Vector3(CornerWallPiece.transform.position.x, 0,
							CornerWallPiece.transform.position.z - 1);
						WallSegment.transform.localScale = new Vector3(WallSegment.transform.localScale.x,
							WallSegment.transform.localScale.y,
							Mathf.Abs(WallSegment.transform.position.z - DoorPointPos));
						Instantiate(WallSegment, WallSegment.transform.position,
							Quaternion.Euler(0f, rotation + 90, 0f));
						Instantiate(DoorPoint,
							new Vector3(WallSegment.transform.position.x, WallSegment.transform.position.y,
								DoorPointPos), Quaternion.Euler(0f, rotation - 90, 0f));
						WallSegment.transform.position = new Vector3(CornerWallPiece.transform.position.x, 0,
							DoorPointPos - sizofDoor);
						WallSegment.transform.localScale = new Vector3(WallSegment.transform.localScale.x,
							WallSegment.transform.localScale.y, Mathf.Abs(DoorPointPos - sizofDoor - hit.point.z));
						Instantiate(WallSegment, WallSegment.transform.position,
							Quaternion.Euler(0f, rotation + 90, 0f));
					}
				}
			}
		}
	}
}
