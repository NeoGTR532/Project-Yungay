using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    public Transform grapplingHook;
    public Transform handPos;
    public Transform CamPos;
    public LayerMask grappleLayer;
    public float distanceHook;
    public float speedHook;
    public float timer;
    public float maxtimer;



    public bool isShooting, isGrappling , returm;
    private Vector3 pointHook;
    public GameObject HandPoint;



    
    private void Start()
    {
        isShooting = false;
        isGrappling = false;
        
    }
    void Update()
    {
        if (Input.GetMouseButton(0) )
        {
            ShootHook();
        }
        if (isGrappling)
        {
            grapplingHook.position = Vector3.Lerp(grapplingHook.position, pointHook, speedHook * Time.deltaTime);
            timer += Time.deltaTime;
            if ( timer >= maxtimer)
            {
                isGrappling = false;
                returm = true;
        
            }
        }
        if (!isGrappling)
        {
            grapplingHook.position = Vector3.Lerp(grapplingHook.position, handPos.transform.position, speedHook * Time.deltaTime);
            timer = 0;
            //grapplingHook.SetParent(CamPos);
            returm = false;
        }
    }

    public void ShootHook()
    {
        if (isShooting || isGrappling ) return ;
        isShooting = true;
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray,out hit , distanceHook , grappleLayer))
        {
            pointHook = hit.point;
            isGrappling = true;
            grapplingHook.parent = null;
            //grapplingHook.LookAt(pointHook);
            
             
        }
        isShooting = false;
    }
}

