using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Look : MonoBehaviour
{
    public GameObject cam;
    public Weapons weapons;
    public Pistol pistol;
    public Submachine submachine;
    public GameObject point;
    int zoom;
    float normal;
    public float smooth = 5;

    private bool isZoomed = false;
    void Awake()
    {
        normal = cam.GetComponent<Camera>().fieldOfView;
    }

    // Update is called once per frame
    void Update()
    {
        switch (weapons.stateWeapons)
        {
            case 1:
                if (Input.GetMouseButtonDown(1))
                {
                    isZoomed = !isZoomed;
                    zoom = pistol.pistol.zoom;
                    pistol.look.GetComponent<RawImage>().texture = pistol.pistol.look.texture;
                    weapons.lockWeapons = !weapons.lockWeapons;
                }
                if (isZoomed)
                {
                    cam.GetComponent<Camera>().fieldOfView = Mathf.Lerp(cam.GetComponent<Camera>().fieldOfView, zoom, Time.deltaTime * smooth);
                    pistol.look.SetActive(true);
                }

                else if (isZoomed == false)
                {
                    cam.GetComponent<Camera>().fieldOfView = Mathf.Lerp(cam.GetComponent<Camera>().fieldOfView, normal, Time.deltaTime * smooth);
                    pistol.look.SetActive(false);
                }
                break;
            case 2:
                if (Input.GetMouseButtonDown(1))
                {
                    isZoomed = !isZoomed;
                    zoom = submachine.submachine.zoom;
                    submachine.look.GetComponent<RawImage>().texture = submachine.submachine.look.texture;
                    weapons.lockWeapons = !weapons.lockWeapons;
                }
                if (isZoomed)
                {
                    cam.GetComponent<Camera>().fieldOfView = Mathf.Lerp(cam.GetComponent<Camera>().fieldOfView, zoom, Time.deltaTime * smooth);
                    submachine.look.SetActive(true);
                }

                else if (isZoomed == false)
                {
                    cam.GetComponent<Camera>().fieldOfView = Mathf.Lerp(cam.GetComponent<Camera>().fieldOfView, normal, Time.deltaTime * smooth);
                    pistol.look.SetActive(false);
                }
                break;
            case 3:
                break;
            case 4:
                break;
        }
    }
}
