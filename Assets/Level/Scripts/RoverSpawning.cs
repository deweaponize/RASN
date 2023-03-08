using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoverSpawning : MonoBehaviour
{
    [Header("Can Spawn?")]
    public bool CanSpawnRover = true;

    [Header("Componenet")]
    public GameObject Rover;

    [Header("Values")]
    public float Margin = 0.10f;

    private int MaxHeightRover;
    private int MinHeightRover;

    private int MaxWidthRover;
    private int MinWidthRover;

    private int HeightRover;
    private int WidthRover;


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
        if(CanSpawnRover)
        {
            Invoke("SpawnRover",1f);
            CanSpawnRover = false;
        }
    }

    public void SpawnRover()
    {
        HeightRover = Random.Range((int)(Margin * MinHeightRover), MaxHeightRover - (int)(Margin * MaxHeightRover));
        WidthRover = Random.Range((int)(Margin * MinWidthRover), MaxWidthRover - (int)(Margin * MaxWidthRover));
        Debug.Log("Height" + HeightRover + " Width " + WidthRover);
        Instantiate(Rover as GameObject, new Vector3(HeightRover, 0f, WidthRover), Quaternion.Euler(0,0,0));
    }
}
