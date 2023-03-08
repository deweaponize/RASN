using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Surface : MonoBehaviour
{
    [Header("Surface Spawn")]
    public GameObject SurfacePlane;

    [Header("Surface Properties")]
    public int MinHeightSurface;
    public int MaxHeightSurface;
    public int MinWidthSurface;
    public int MaxWidthSurface;
    [HideInInspector]
    public int HeightSurface;
    [HideInInspector]
    public int WidthSurface;

    void Awake()
    {
        HeightSurface = Random.Range(MinHeightSurface, MaxHeightSurface);
        WidthSurface = Random.Range(MinWidthSurface, MaxWidthSurface);
        SurfacePlane.transform.localScale = new Vector3(HeightSurface, WidthSurface, SurfacePlane.transform.localScale.z);
        SurfacePlane.transform.position= new Vector3(HeightSurface/2, 0, WidthSurface/2);
    }
}