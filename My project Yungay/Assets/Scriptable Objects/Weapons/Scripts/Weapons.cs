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
        switch (stateWeapons)
        {
            case 1:
                modelPistol.GetComponent<MeshRenderer>().enabled = true;
                modelPistol.GetComponent<Pistol>().enabled = true;
                modelSubmachine.GetComponent<MeshRenderer>().enabled = false;
                modelSubmachine.GetComponent<Submachine>().enabled = false;
                modelAxe.SetActive(false);
                modelKnife.SetActive(false);
                //if (modelAxe.transform.childCount > 0)
                //{
                //    modelAxe.SetActive(false);
                //}
                //else
                //{

                //}
                break;
            case 2:
                modelPistol.GetComponent<MeshRenderer>().enabled = false;
                modelPistol.GetComponent<Pistol>().enabled = false;
                modelSubmachine.GetComponent<MeshRenderer>().enabled = true;
                modelSubmachine.GetComponent<Submachine>().enabled = true;
                modelAxe.SetActive(false);
                modelKnife.SetActive(false);
                break;
            case 3:
                modelPistol.GetComponent<MeshRenderer>().enabled = false;
                modelPistol.GetComponent<Pistol>().enabled = false;
                modelSubmachine.GetComponent<MeshRenderer>().enabled = false;
                modelSubmachine.GetComponent<Submachine>().enabled = false;
                modelAxe.SetActive(true);
                modelKnife.SetActive(false);
                break;
            /*  case 4:
                  modelPistol.GetComponent<MeshRenderer>().enabled = false;
                  modelPistol.GetComponent<Pistol>().enabled = false;
                  modelSubmachine.GetComponent<MeshRenderer>().enabled = false;
                  modelSubmachine.GetComponent<Submachine>().enabled = false;
                  modelHook.GetComponent<MeshRenderer>().enabled = true;
                  modelHook.GetComponent<Hook>().enabled = true;
                  modelAxe.SetActive(false);
                  break;*/
            case 5:
                modelPistol.GetComponent<MeshRenderer>().enabled = false;
                modelPistol.GetComponent<Pistol>().enabled = false;
                modelSubmachine.GetComponent<MeshRenderer>().enabled = false;
                modelSubmachine.GetComponent<Submachine>().enabled = false;
                modelAxe.SetActive(false);
                modelKnife.SetActive(true);
                break;
        }
    }
}