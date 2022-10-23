using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Look : MonoBehaviour
{
    public Camera camera;
    public Weapon weapon;
    public GameObject init,limit;
    public GameObject look;
    public LayerMask collision;
    public LayerMask no;
    public float smooth;
    public bool zoom = false;
    public Vector3 end;
    private Coroutine coroutine;

    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        UpdateLimit();

        if (Input.GetMouseButtonDown(1) && weapon != null)
        {
            IsPoint();
            zoom = true;
            //StartCoroutine(MoveCamera(limit.transform.position));
        }

        if (Input.GetMouseButtonUp(1))
        {
            zoom = false;

            coroutine = StartCoroutine(MoveCamera(init.transform.position));
        }

        if (zoom)
        {
            if (coroutine != null)
            {
                StopCoroutine(coroutine);
            }
            camera.transform.position = Vector3.Lerp(camera.transform.position, limit.transform.position, Time.deltaTime * smooth);
        }

    }

    public void IsPoint()
    {
        look.GetComponent<RawImage>().texture = weapon.look.texture;
    }

    private void UpdateLimit()
    {
        RaycastHit hit;
        Ray ray = new Ray(init.transform.position, init.transform.forward * weapon.zoom);
        end = ray.origin + ray.direction * weapon.zoom;
        limit.transform.position = end;
        if (Physics.Raycast(init.transform.position, init.transform.forward, out hit, weapon.zoom, collision))
        {
            if (hit.point != null)
            {
                limit.transform.position = hit.point;
            }
        }
    }

    IEnumerator MoveCamera(Vector3 end)
    {
        while (camera.transform.position != end)
        {
            camera.transform.position = Vector3.Lerp(camera.transform.position, end, Time.deltaTime * smooth);
            yield return new WaitForEndOfFrame();
        }
        camera.transform.position = end;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(init.transform.position, init.transform.forward * weapon.zoom);
    }
}