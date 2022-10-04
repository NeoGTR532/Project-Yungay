using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook1 : MonoBehaviour
{
    
    public Transform pick;
    public  Transform grapplingHook;
    public  Transform handpos;
    public LayerMask Hookeable;
    public float distanceHook;
    public bool isShooting, isGrappling;
    private Vector3 pointHook;
    public float speed;
    public float timer;
    public float maxtimer;
    public float speedhook;
    private bool fire;
    private float T;
    private float mt;



    void Start()
    {
        isGrappling = false;
        isShooting = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            fire = true;
            
            ShootHook();
        }
       
        if (isGrappling)
        {
            grapplingHook.position = Vector3.Lerp(grapplingHook.position, pointHook, speed * Time.deltaTime);
            timer += Time.deltaTime;
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, distanceHook, Hookeable))
            {
                hit.transform.position = Vector3.Lerp(hit.transform.position, handpos.transform.position, speedhook * Time.deltaTime);
            }
                if (timer >= maxtimer)
            {
                isGrappling = false;
            }
            
        }
        if (!isGrappling)
        {
            grapplingHook.position = Vector3.Lerp(grapplingHook.position, handpos.transform.position, speed * Time.deltaTime);
            timer = 0;
            
            grapplingHook.SetParent(handpos);

        }
    }
    private void LateUpdate()
    {
        /*if (grappling)
        {
            lr.SetPosition(0, gutip.position);
            timeToreturm += Time.deltaTime;
        }*/
    }
    public void ShootHook()
    {
        if (isShooting || isGrappling) return;
        isShooting = true;
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, distanceHook, Hookeable))
        {         
            pointHook = hit.point;
            // hit.transform.position = pick.transform.position;
            // hit.transform.position = Vector3.Lerp(hit.transform.position, pick.transform.position, speedhook * Time.deltaTime);
           // hit.transform.SetParent(pick.gameObject.transform);
            isGrappling = true;
           grapplingHook.parent = null;
            //grapplingHook.LookAt(pointHook);
        }
        isShooting = false;
    }

    
}
