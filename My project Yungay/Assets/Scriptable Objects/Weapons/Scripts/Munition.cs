using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Munition : MonoBehaviour
{
    public Weapons weapons;
    public int nails;
    public int bullets;
    public int chargerNails;
    public int chargerBullets;
    public TMP_Text textNails;
    public TMP_Text textBullets;
    [HideInInspector]
    public bool thereBullets, thereNails;

    private void Update()
    {
        textNails.text = chargerNails.ToString();
        textBullets.text = chargerBullets.ToString(); 
        InventoryAmmo();
    }
    public void InventoryAmmo()
    {
        weapons.hasItemNails = weapons.inventory.CheckItem(weapons.nailsItem);
        weapons.hasItemBullets = weapons.inventory.CheckItem(weapons.bulletsItem);
        if (weapons.hasItemNails)
        {
            nails = weapons.inventory.CheckAmount(weapons.nailsItem);
        }
        else if (weapons.hasItemNails == false)
        { }
        if (weapons.hasItemBullets)
        {
            bullets = weapons.inventory.CheckAmount(weapons.bulletsItem);
        }
        else if (weapons.hasItemBullets == false)
        { }
    }
    public void RechargeAmmo()
    {
        switch (weapons.stateWeapons)
        {
            case 0:
                if (weapons.ammo == true && bullets > 1)
                {
                    for (int i = chargerBullets; i < weapons.armas[weapons.stateWeapons].chargerBulletsMax; i++)
                    {
                        chargerBullets++;
                        weapons.inventory.RestItem(weapons.bulletsItem,1);
                    }
                }
                else if (weapons.ammo == false && nails > 1)
                {
                    for (int i = chargerNails; i < weapons.armas[weapons.stateWeapons].chargerNailsMax; i++)
                    {
                        chargerNails++;
                        weapons.inventory.RestItem(weapons.nailsItem,1);
                    }
                }
                break;
            case 1:
                if (weapons.ammo == true && bullets > 1)
                {
                    for (int i = chargerBullets; i < weapons.armas[weapons.stateWeapons].chargerBulletsMax; i++)
                    {
                        chargerBullets++;
                        weapons.inventory.RestItem(weapons.bulletsItem,1);
                    }
                }
                break;
        }
    }
    public void CheckAmmo()
    {

        if (chargerNails >= 1)
        {
            thereNails = true;
        }
        else
        {
            thereNails = false;
        }
        if (chargerBullets >= 1)
        {
            thereBullets = true;
        }
        else
        {
            thereBullets = false;
        }
       
    }
}
