using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Look : MonoBehaviour
{
    public Weapons weapons;
    public GameObject point;
    int zoom;
    float normal;
    float smooth = 5;

    private bool isZoomed = false;
    void Start()
    {
        normal = weapons.cam.GetComponent<Camera>().fieldOfView;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            isZoomed = !isZoomed;
            zoom = weapons.armas[weapons.stateWeapons].zoom;
            point.GetComponent<RawImage>().texture = weapons.armas[weapons.stateWeapons].look.texture;
            weapons.lockWeapons = !weapons.lockWeapons;
        }

        if (isZoomed)
        {
            weapons.cam.GetComponent<Camera>().fieldOfView = Mathf.Lerp(weapons.cam.GetComponent<Camera>().fieldOfView, zoom, Time.deltaTime * smooth);
            point.SetActive(true);
        }

        else if (isZoomed == false)
        {
            weapons.cam.GetComponent<Camera>().fieldOfView = Mathf.Lerp(weapons.cam.GetComponent<Camera>().fieldOfView, normal, Time.deltaTime * smooth);
            point.SetActive(false);
        }
    }
}
