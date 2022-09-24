using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Munition : MonoBehaviour
{
    public Weapons weapons;
    public Pistol pistol;
    public Submachine submachine;
    public int nails;
    public int bullets;
    public int chargerNails;
    public int chargerBullets;
    public TMP_Text textNails;
    public TMP_Text textBullets;
    [HideInInspector]
    public bool thereBullets, thereNails;
    public bool hasItemNails, hasItemBullets;
    public Inventory inventory;
    public ItemObject nailsItem;
    public ItemObject bulletsItem;
    public InventoryDisplay inventoryDisplay;

    private void Update()
    {
        hasItemNails = inventory.CheckItem(nailsItem);
        hasItemBullets = inventory.CheckItem(bulletsItem);
        textNails.text = chargerNails.ToString();
        textBullets.text = chargerBullets.ToString();
        InventoryAmmo();
        //AmmoMax();
    }
    public void InventoryAmmo()
    {
        switch (weapons.stateWeapons)
        {
            case 1:
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
                break;
            case 2:
                if (hasItemBullets)
                {
                    bullets = inventory.CheckAmount(bulletsItem);
                }
                else if (hasItemBullets == false)
                { }
                break;
        }
      /*  weapons.hasItemNails = weapons.inventory.CheckItem(weapons.nailsItem);
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
      */
    }

  /*  public void AmmoMax()
    {
        if (weapons.armas[weapons.stateWeapons].chargerBulletsMax > bullets)
        {
            RechargeAmmo();
        }
        else
        {
            int i = inventory.GetItemIndex(weapons.bulletsItem);

            int j = chargerBullets - weapons.armas[weapons.stateWeapons].chargerBulletsMax;

            inventory.slots[i].AddAmount(j);
        }
    }
  */
    public void RechargeAmmo()
    {
        switch (weapons.stateWeapons)
        {
            case 11:
                if (pistol.ammo == true && bullets >= 1)
                {
                    for (int i = chargerBullets; i < pistol.pistol.chargerBulletsMax; i++)
                    {
                            chargerBullets++;
                            inventory.RestItem(bulletsItem, 1);
                            inventoryDisplay.UpdateDisplay();
                    }
                }
                else if (pistol.ammo == false && nails >= 1)
                {
                    for (int i = chargerNails; i < pistol.pistol.chargerNailsMax; i++)
                    {
                        chargerNails++;
                        inventory.RestItem(nailsItem,1);
                        inventoryDisplay.UpdateDisplay();
                    }
                }
                break;
            case 2:
                if (submachine.ammo == true && bullets >= 1)
                {
                    for (int i = chargerBullets; i < submachine.submachine.chargerBulletsMax; i++)
                    {
                        chargerBullets++;
                        inventory.RestItem(bulletsItem,1);
                        inventoryDisplay.UpdateDisplay();
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