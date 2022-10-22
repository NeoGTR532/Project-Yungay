using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform cameraPosition;
    public Transform cameraRotation;

    // Update is called once per frame
    void Update()
    {
        transform.position = cameraPosition.position;
        transform.rotation = cameraRotation.rotation;
    }
}
