using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    public Transform grapplingHook;
    public Transform handPos;
    public LayerMask grappleLayer;
    public float distanceHook;
    public float speedHook;


    public bool isShooting, isGrappling;
    private Vector3 pointHook;



    
    private void Start()
    {
        isShooting = false;
        isGrappling = false;
    }
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            ShootHook();
        }
        if (isGrappling)
        {
            grapplingHook.position = Vector3.Lerp(grapplingHook.position, pointHook, speedHook * Time.deltaTime);
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

