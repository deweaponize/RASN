using System;
using System.Collections.Generic;
using UnityEngine;

public class TrackCheckPoint : MonoBehaviour
{
    public bool reset; 
    public int NextCheckpointIndex;
    public event EventHandler<CarCheckpointEventArgs> OnPlayerCorrectCheckpoint;
    public event EventHandler<CarCheckpointEventArgs> OnPlayerWrongCheckpoint;
    public List<CheckPointSingle> checkPointSinglesList;
    [SerializeField] private List<Transform> carTransformsList;
    private List<int> NextCheckpoint;

    public class CarCheckpointEventArgs : EventArgs
    {
        public Transform carTransform;
    }

    private void Awake()
    {
        Transform CheckpointsTransform = transform.Find("CheckPoints");

        checkPointSinglesList = new List<CheckPointSingle>();
        foreach(Transform CheckPointSingleTransform in CheckpointsTransform)
        {
            CheckPointSingle checkPointSingle = CheckPointSingleTransform.GetComponent<CheckPointSingle>();
            checkPointSingle.SetTrackCheckpoint(this);
            checkPointSinglesList.Add(checkPointSingle);
            
        }
        NextCheckpoint = new List<int>();

        foreach(Transform carTransform in carTransformsList)
        {
            NextCheckpoint.Add(0);
        }
    }
    
    public void CarThroughCheckpoint(CheckPointSingle checkPointSingle, Transform carTransform)
    {
        if (!reset){
        NextCheckpointIndex = NextCheckpoint[carTransformsList.IndexOf(carTransform)]; 
        }
        else{
            Debug.Log("reseted");
            NextCheckpointIndex = 0;
        }
        if(checkPointSinglesList.IndexOf(checkPointSingle) == NextCheckpointIndex)
        {
            NextCheckpoint[carTransformsList.IndexOf(carTransform)] = (NextCheckpointIndex + 1) % checkPointSinglesList.Count;
            OnPlayerCorrectCheckpoint?.Invoke(this, new CarCheckpointEventArgs{carTransform = carTransform});
        }
        else
        {
            Debug.Log("wrong");
            OnPlayerWrongCheckpoint?.Invoke(this, new CarCheckpointEventArgs{carTransform = carTransform});
        }
        reset = false;
    }

    public CheckPointSingle GetNextCheckpoint(Transform transform)
    {
        return checkPointSinglesList[NextCheckpointIndex];
    }
}
