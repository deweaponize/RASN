using UnityEngine;

namespace Assets.Scripts
{
    public class CheckPointSingle : MonoBehaviour
    {
        private TrackCheckPoint trackCheckPoint;
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<Controller>(out Controller controller))
            {
                trackCheckPoint.CarThroughCheckpoint(this, other.transform);
            }
        }

        public void SetTrackCheckpoint(TrackCheckPoint trackCheckPoint)
        {
            this.trackCheckPoint = trackCheckPoint;
        }
    }
}
