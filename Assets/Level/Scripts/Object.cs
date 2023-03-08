using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    [Header("Spawn Object Or Not")]
    public bool canloop = true;

    [Header("Object Instance")]
    public List<GameObject> _Objects;

    [Header("Object Properties")]
    public int NumberofMaxobject = 120;
    public int MinHeightObject;
    public int MaxHeightObject;
    public int MinWidthObject;
    public int MaxWidthObject;
    public int MinDepthObject;
    public int MaxDepthObject;
    private int HeightObject;
    private int WidthObject; 
    private int DepthObject;
    private int objectrandom;
    
    [Header("Surface Info")]
    public float MarginObject = 0.10f;
    private int MinHeightSurface;
    private int MinWidthSurface;
    private int MAXWidthSurface;
    private int MAXHeightSurface;
    private int RandomX;
    private int RandomZ;
    

    public void Update()
    {   
        MinHeightSurface = (int)FindObjectOfType<Surface>().GetComponent<Surface>().MinHeightSurface;
        MAXHeightSurface = (int)FindObjectOfType<Surface>().GetComponent<Surface>().HeightSurface;
        MinWidthSurface  = (int)FindObjectOfType<Surface>().GetComponent<Surface>().MinWidthSurface;
        MAXWidthSurface  = (int)FindObjectOfType<Surface>().GetComponent<Surface>().WidthSurface;
        if(canloop)
        {
            Invoke("ObjectSpawnScale",1f);
            canloop = false;
        }
    }
    public void ObjectSpawnScale()
    {
        for(int i = 1; i <= NumberofMaxobject; i++)
        {
            HeightObject = Random.Range(MinHeightObject, MaxHeightObject);
            WidthObject = Random.Range(MinWidthObject, MaxWidthObject);
            DepthObject = Random.Range(MinDepthObject, MaxDepthObject);
            RandomX = Random.Range((int)(MarginObject * MAXHeightSurface), MAXHeightSurface - (int)(MarginObject * MAXHeightSurface));
            RandomZ = Random.Range((int)(MarginObject * MAXWidthSurface), MAXWidthSurface - (int)(MarginObject * MAXWidthSurface));
            objectrandom = Random.Range(0, _Objects.Count);
            _Objects[objectrandom].transform.localScale = new Vector3(HeightObject, DepthObject, WidthObject);
            _Objects[objectrandom].transform.position = new Vector3(Mathf.Floor(RandomX), 0, Mathf.Floor(RandomZ));
            Instantiate(_Objects[objectrandom] as GameObject, _Objects[objectrandom].transform.position, Quaternion.Euler(-90,0,0));
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
