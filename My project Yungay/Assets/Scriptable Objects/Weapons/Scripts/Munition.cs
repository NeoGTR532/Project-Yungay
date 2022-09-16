using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Munition : MonoBehaviour
{
    public Weapons weapons;
    public int nails;
    [HideInInspector]
    public bool thereBullets, thereNails;
    public int bullets;

    public void CheckAmmo()
    {
        if (nails >= 1)
        {
            thereNails = true;
        }
        else
        {
            thereNails = false;
        }
        if (bullets >= 1)
        {
            thereBullets = true;
        }
        else
        {
            thereBullets = false;
        }
        /*
        switch (weapons.stateWeapons)
        {
            case 0:
                if (thereNails || Input.GetMouseButton(0))
                {
                    nails -= 1;
                }
                else if(thereBullets || Input.GetMouseButton(0)) 
                {
                    bullets -= 1;
                }
                break;

            case 1:
                if (thereBullets || Input.GetMouseButton(0))
                {
                    bullets -= 1;
                }
                break;
        }
        */
    }
}
