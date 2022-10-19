using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public bool moveCamera = false;
    public bool grabPaper = false;
    private Transform cameraTransform;

    private void Start()
    {
        cameraTransform = GameObject.Find("Main Camera").GetComponent<Transform>();
    }
    private void Update()
    {
        if (!moveCamera)
        {
            CheckMoveCamera();
            MisionText.currentMision = 0;           
        }
        else
        {
            MisionText.currentMision = 1;
        }
     
    }

    private void CheckMoveCamera()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.gameObject.tag == "CheckCamera")
            {
                moveCamera = true;
            }
        }
    }

}
