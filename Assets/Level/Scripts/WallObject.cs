using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallObject : MonoBehaviour
{
    void  OnCollisionEnter(Collision other)
    {
        if(other.gameObject.GetComponent<DoorObject>() || other.gameObject.GetComponent<Rover>())
        {
            Destroy(this.gameObject);
        }
    }
}
