 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook1 : MonoBehaviour
{
    
    public Transform pick;
    public  Transform grapplingHook;
    public  Transform handpos;
    public LayerMask Hookeable;
    public LayerMask obstaculos;
    public float distanceHook;
    public bool isShooting, isGrappling;
    private Vector3 pointHook;
    public float speed;
    public float timer;
    public float maxtimer;
    public float speedhook;

    


    void Start()
    {
        isGrappling = false;
        isShooting = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            
            
            ShootHook();
        }

        RaycastHit hit1;
        Ray ray1 = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (isGrappling)
        {
            grapplingHook.position = Vector3.Lerp(grapplingHook.position, pointHook, speed * Time.deltaTime);
            timer += Time.deltaTime;
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);


            if (Physics.Raycast(ray, out hit, distanceHook, Hookeable))
            {
                if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Hookeble"))
                {
                    hit.transform.position = Vector3.Lerp(hit.transform.position, handpos.transform.position, speedhook * Time.deltaTime);
                }
            }
            if (timer >= maxtimer)
            {
                isGrappling = false;
            }


        }
        else
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
            if(hit.transform.gameObject.layer == LayerMask.NameToLayer("Hookeble"))
            {
                pointHook = hit.point;
                // hit.transform.position = pick.transform.position;
                // hit.transform.position = Vector3.Lerp(hit.transform.position, pick.transform.position, speedhook * Time.deltaTime);
                // hit.transform.SetParent(pick.gameObject.transform);
                isGrappling = true;
                grapplingHook.parent = null;
                //grapplingHook.LookAt(pointHook);
            }
        }
        isShooting = false;
    }

    /*IEnumerator Hook()
    {
        
    }*/
    
}
