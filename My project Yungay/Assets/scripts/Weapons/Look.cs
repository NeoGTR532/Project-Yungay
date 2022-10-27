using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Look : MonoBehaviour
{
    public Camera camera;
    private EquipmentRange weapon;
    public GameObject init;
    private Vector3 end;
    private Vector3 endPosition;
    public GameObject look;
    public LayerMask collision;
    public LayerMask no;
    public float smooth;
    public bool zoom = false;
    private Coroutine coroutine;

    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Hand.canAim)
        {
            EquipmentRange _ = (EquipmentRange)Hand.currentItem;

            UpdateLimit();

            float distance1 = Vector3.Distance(camera.transform.position, endPosition);
            float distance2 = Vector3.Distance(camera.transform.position, init.transform.position);


            if (Input.GetMouseButtonDown(1) && _ != null)
            {
                IsPoint();
                zoom = true;
            }

            if (Input.GetMouseButtonUp(1))
            {
                zoom = false;
            }

            if (zoom)
            {
                if (distance1 < 0.01f)
                {
                    camera.transform.position = endPosition;
                }
                camera.transform.position = Vector3.Lerp(camera.transform.position, endPosition, Time.deltaTime * smooth);
            }
            else
            {
                camera.transform.position = Vector3.Lerp(camera.transform.position, init.transform.position, Time.deltaTime * smooth);
                if (distance2 < 0.01f)
                {
                    camera.transform.position = init.transform.position;
                }
            }
        }
    }

    public void IsPoint()
    {
        //look.GetComponent<RawImage>().texture = weapon.look.texture;
    }

    private void UpdateLimit()
    {
        weapon = (EquipmentRange)Hand.currentItem;
        RaycastHit hit;
        Ray ray = new Ray(init.transform.position, init.transform.forward * weapon.zoom);
        end = ray.origin + ray.direction * weapon.zoom;
        endPosition = end;
        if (Physics.Raycast(init.transform.position, init.transform.forward, out hit, weapon.zoom, collision))
        {
            if (hit.point != null)
            {
                endPosition = hit.point;
            }
        }
    }
}