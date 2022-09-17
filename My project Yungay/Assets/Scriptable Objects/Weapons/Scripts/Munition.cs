using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Munition : MonoBehaviour
{
    public Weapons weapons;
    public Inventory inventory;
    public int nails;
    public int bullets;
    public ItemObject nailsItem;
    public ItemObject bulletsItem;
    [HideInInspector]
    public bool hasItemNails, hasItemBullets;
    public int chargerNails;
    public int chargerBullets;
    public TMP_Text textNails;
    public TMP_Text textBullets;
    [HideInInspector]
    public bool thereBullets, thereNails;

    private void Update()
    {
        hasItemNails = inventory.CheckItem(nailsItem);
        hasItemBullets = inventory.CheckItem(bulletsItem);
        textNails.text = nails.ToString();
        textBullets.text = bullets.ToString();
        if (hasItemNails)
        {
            nails = inventory.CheckAmount(nailsItem);
        }
        else if (hasItemNails == false)
        { }
        if (hasItemBullets)
        {
            bullets = inventory.CheckAmount(bulletsItem);
        }
        else if (hasItemBullets == false)
        { }

       
    }

    public void CheckAmmo()
    {
        switch (weapons.stateWeapons)
        {
            case 1:
                if (Input.GetKey(KeyCode.R) && weapons.stateAmmo == false)
                {
                    for (int i = chargerBullets; i < weapons.armas[weapons.stateWeapons].chargerBulletMax; i++)
                    {
                        inventory.RestItem(bulletsItem);
                    }
                }
                else if (Input.GetKey(KeyCode.R) && weapons.stateAmmo == true)
                {
                    for (int i = chargerNails; i < weapons.armas[weapons.stateWeapons].chargerNailsMax; i++)
                    {
                        inventory.RestItem(nailsItem);
                    }
                }
                break;
            case 2:
                if (Input.GetKey(KeyCode.R) && weapons.stateAmmo == false)
                {
                    for (int i = chargerBullets; i < weapons.armas[weapons.stateWeapons].chargerBulletMax; i++)
                    {
                        inventory.RestItem(bulletsItem);
                    }
                }
                break;
        }
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
    }
}
