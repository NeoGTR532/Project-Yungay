using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointSingle : MonoBehaviour
{
    private TrackCheck trackCheck;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerMovement>(out PlayerMovement playerMovement))
        {
            trackCheck.PlayerThroughCheckpoint(this);
        }
    }
    public void SetTrackCheckpoints(TrackCheck trackCheck)
    {
        this.trackCheck = trackCheck;
    }
}
