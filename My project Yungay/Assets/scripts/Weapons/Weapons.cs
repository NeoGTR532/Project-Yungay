using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    public int stateWeapons;

    public bool lockWeapons;


    public GameObject modelAxe,
        modelHook,
        modelPistol,
        modelSubmachine,
        modelSpear,
        modelKnife;


    private void Awake()
    {
        ChangeWeapons();
    }

    private void Update()
    {

        if (modelAxe.transform.childCount <= 0)
        {
            modelAxe.SetActive(false);
        }

        if (lockWeapons == false)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                stateWeapons = 1;

                ChangeWeapons();
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                stateWeapons = 2;

                ChangeWeapons();
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                stateWeapons = 3;

                ChangeWeapons();
            }
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                stateWeapons = 4;

                ChangeWeapons();
            }
            if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                stateWeapons = 5;

                ChangeWeapons();
            }
        }
    }

    public void ChangeWeapons()
    {
        Desactive();
        switch (stateWeapons)
        {
            case 1:
                modelPistol.GetComponent<MeshRenderer>().enabled = true;
                modelPistol.GetComponent<Pistol>().enabled = true;
                break;
            case 2:
                modelSubmachine.GetComponent<MeshRenderer>().enabled = true;
                modelSubmachine.GetComponent<Submachine>().enabled = true;
                break;
            case 3:
                modelAxe.SetActive(true);
                break;
            case 4:
                modelSpear.SetActive(true);
                break;
            case 5:
                modelKnife.SetActive(true);
                break;
        }
    }
    public void Desactive()
    {
        modelPistol.GetComponent<MeshRenderer>().enabled = false;
        modelPistol.GetComponent<Pistol>().enabled = false;
        modelSubmachine.GetComponent<MeshRenderer>().enabled = false;
        modelSubmachine.GetComponent<Submachine>().enabled = false;
        modelAxe.SetActive(false);
        modelSpear.SetActive(false);
        modelKnife.SetActive(false);
    }
}