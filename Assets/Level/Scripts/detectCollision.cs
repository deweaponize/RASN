using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectCollision : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.GetComponent<detectCollision>() || other.gameObject.GetComponent<WallObject>() || other.gameObject.GetComponent<DoorObject>() || other.gameObject.GetComponent<Rover>())
        {
            Destroy(this.gameObject);
        }
    }
}
