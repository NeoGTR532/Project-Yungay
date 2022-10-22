using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Look : MonoBehaviour
{
    public Camera camera;
    public Weapon weapon;
    public GameObject init;
    public GameObject limit;
    public GameObject look;
    public Vector3 a;
    public LayerMask collision;
    public LayerMask no;
    public float smooth;
    bool one = false;
    public bool isZoomed = false;
    private void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
         RaycastHit hit;
         Ray ray = new Ray(init.transform.position, init.transform.forward * weapon.zoom);
         Vector3 _ = new Vector3(0,0,0);
         _= new Vector3(camera.transform.position.x, camera.transform.position.y, camera.transform.position.z * -weapon.zoom);
         limit.transform.position = ray.GetPoint(_.z);
         one = true;
        if (Input.GetMouseButtonDown(1) && weapon != null)
        {
            IsPoint();
        }
        if(Input.GetMouseButtonUp(1))
        {
            one = !one;
        }
        if(isZoomed)
        {
            if (Physics.Raycast(init.transform.position, init.transform.forward, out hit, weapon.zoom, collision))
            {
                if (hit.point != null)
                {
                    Debug.Log(hit.collider);
                    limit.transform.position = hit.point;
                    Debug.Log(limit.transform.position);
                    camera.transform.position = Vector3.Lerp(hit.distance * a, init.transform.position, smooth * Time.deltaTime);
                }
            }
            else if(Physics.Raycast(init.transform.position, init.transform.forward, out hit, weapon.zoom))
            {
                limit.transform.position = hit.point;
                Debug.Log(hit.collider);
                camera.transform.position = Vector3.Lerp(limit.transform.position,init.transform.position, smooth * Time.deltaTime);
            }
        }
        else
        {
           // camera.transform.position = Vector3.Lerp( init.transform.position, limit.transform.position, smooth * Time.deltaTime);
        }
    }

    public void IsPoint()
    {
        isZoomed = !isZoomed;
        look.GetComponent<RawImage>().texture = weapon.look.texture;
       // weapons.lockWeapons = !weapons.lockWeapons;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(init.transform.position, init.transform.forward * weapon.zoom);
    }
}