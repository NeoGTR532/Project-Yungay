using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook1 : MonoBehaviour
{
    public Transform cam;
    public Transform gutip;
    public LayerMask hookable;
    public LineRenderer lr;

    // /// // /// // // // / //
    public float maxDistanceHook;
    public float delayhook;
    private Vector3 grapplePoint;

    // // // // // // //
    public float hookcd;
    public float hookcdtimer;
    public bool grappling;
    // // // // // // // //
    public float timeToreturm;
    public float MaxtimerTuretum;
    public bool hitObj;

     
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        startHook();
        if (hookcdtimer > 0)
        {
            hookcdtimer -= Time.deltaTime;
        }
    }
    private void LateUpdate()
    {
        if (grappling)
        {
            lr.SetPosition(0, gutip.position);
            timeToreturm += Time.deltaTime;
        }
    }

    public void startHook()
    {
        if (Input.GetMouseButton(0))
        {
            if (hookcdtimer > 0) return;
            grappling = true;

            RaycastHit hit;
            if (Physics.Raycast(cam.position, cam.forward, out hit, maxDistanceHook, hookable))
            {
                    grapplePoint = hit.point;
                    Invoke(nameof(executeHook), delayhook);
                    
            }
            else
            {
                grapplePoint = cam.position + cam.forward * maxDistanceHook;
                Invoke(nameof(stophook), delayhook);
            }
            lr.enabled = true;
            lr.SetPosition(1, grapplePoint);
        }
       
    }
    public void executeHook()
    {

    }
    public void stophook()
    {
        grappling = false;
        hookcdtimer = hookcd;
        lr.enabled = false;

    }
}
