using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackCheck : MonoBehaviour
{
    private List<CheckpointSingle> checkpointSingleList;
    private void Awake()
    {
        Transform checkpointTransform = transform.Find("Checkpoints");

        checkpointSingleList = new List<CheckpointSingle>();
        foreach (Transform checkpointSingleTransform in checkpointTransform)
        {
            CheckpointSingle checkpointSingle = checkpointSingleTransform.GetComponent<CheckpointSingle>();
            checkpointSingle.SetTrackCheckpoints(this);
            checkpointSingleList.Add(checkpointSingle);
        }
    }

    public void PlayerThroughCheckpoint(CheckpointSingle checkpointSingle)
    {
        Debug.Log(checkpointSingleList.IndexOf(checkpointSingle));
    }
}
