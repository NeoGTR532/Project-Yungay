using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Look : MonoBehaviour
{
    public GameObject cam;
    public Weapons weapons;
    public Weapon weapon;
    public GameObject look;
    public GameObject positionCam;
    public LayerMask collider;
    public float smooth = 5;

    public bool isZoomed = false;
    private void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(1) && weapon != null)
        {
            IsPoint();
        }
        if (isZoomed)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, weapon.range, collider))
            {
                Debug.Log(hit.collider);
                StartCoroutine(Point(cam.transform.position, cam.transform.forward * weapon.range));
                look.SetActive(true);
                
            }
            else
            {
                StartCoroutine(Point(cam.transform.position, cam.transform.forward * weapon.range));
                look.SetActive(true);
            }
        }
        else if (isZoomed == false)
        {
            StartCoroutine(Point(cam.transform.position, positionCam.transform.position));
            look.SetActive(false);
        }
    }

    public void IsPoint()
    {
        isZoomed = !isZoomed;
        look.GetComponent<RawImage>().texture = weapon.look.texture;
        weapons.lockWeapons = !weapons.lockWeapons;

    }
    IEnumerator Point(Vector3 start, Vector3 end)
    {
        Vector3 position = Vector3.Lerp(start, end, smooth * Time.deltaTime);

        cam.transform.position = position;

        yield return null;

        
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(cam.transform.position, cam.transform.forward * weapon.range);
    }
}