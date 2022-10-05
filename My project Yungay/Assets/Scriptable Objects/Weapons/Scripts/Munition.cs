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
    //[HideInInspector]
    public bool thereBullets, thereNails;
    public bool hasItemNails, hasItemBullets;
    public Inventory inventory;
    public ItemObject nailsItem;
    public ItemObject bulletsItem;
    public InventoryDisplay inventoryDisplay;

   /* private void Update()
    {
        


        //for (int i = 0; i < inventory.slots.Count; i++)
        //{
        //    if (inventory.slots[i] != null)
        //    {
        //        if (inventory.slots[i].item == nailsItem)
        //        {
        //            hasItemNails = true;
        //            break;
        //        }
        //        else if (inventory.slots[i].item != bulletsItem)
        //        {
        //            hasItemBullets = false;
        //            break;
        //        }
        //        else
        //        {
        //            hasItemBullets = false;
        //            hasItemNails = false;
        //        }
        //    }
        //}

    }*/
    private void FixedUpdate()
    {
        textNails.text = chargerNails.ToString();
        textBullets.text = chargerBullets.ToString();
        //AmmoMax();
        CheckAmmo();
        hasItemBullets = inventory.CheckItem(bulletsItem);
        hasItemNails = inventory.CheckItem(nailsItem);
        InventoryAmmo();

    }
    public void InventoryAmmo()
    {
        switch (weapons.stateWeapons)
        {
            case 1:
                if (hasItemNails)
                {
                    int i = inventory.GetItemIndex(nailsItem);
                    nails = inventory.CheckAmount(inventory.slots[i].item);
                }
                else if (hasItemNails == false)
                { }
                if (hasItemBullets)
                {
                    int i = inventory.GetItemIndex(bulletsItem);
                    bullets = inventory.CheckAmount(inventory.slots[i].item);
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
            case 1:
                if (pistol.ammo == true && bullets >= 1)
                {
                    if (bullets > 10 && chargerBullets < pistol.pistol.chargerBulletsMax)
                    {
                        for (int i = chargerBullets; i < pistol.pistol.chargerBulletsMax; i++)
                        {
                            chargerBullets++;
                            inventory.RestItem(bulletsItem, 1);
                            inventoryDisplay.UpdateDisplay();
                        }
                    }
                    else if(chargerBullets < pistol.pistol.chargerBulletsMax)
                    {
                        for (int i = chargerBullets; i < pistol.pistol.chargerBulletsMax; i++)
                        {

                            if (bullets > 0)
                            {
                                chargerBullets++;
                                inventory.RestItem(bulletsItem, 1);
                                inventoryDisplay.UpdateDisplay();
                            }
                            else { break; }
                        }
                    }
                }
                else if (pistol.ammo == false && nails >= 1)
                {
                    if (nails > pistol.pistol.chargerNailsMax && chargerNails < pistol.pistol.chargerNailsMax)
                    {
                        for (int i = chargerNails; i < pistol.pistol.chargerNailsMax; i++)
                        {
                            chargerNails++;
                            inventory.RestItem(nailsItem, 1);
                            inventoryDisplay.UpdateDisplay();
                        }
                    }
                    else if (chargerNails < pistol.pistol.chargerNailsMax && nails < pistol.pistol.chargerNailsMax)
                    {
                        for (int i = chargerNails; i < pistol.pistol.chargerNailsMax; i++)
                        {
                            if (nails > 0)
                            {
                                chargerNails++;
                                inventory.RestItem(nailsItem, 1);
                                inventoryDisplay.UpdateDisplay();
                            }
                            else 
                            {
                                break;
                            }
                        }

                    }
                }
                break;
            case 2:
                if (submachine.ammo == true && bullets >= 1)
                {
                    if (bullets > 20 && chargerBullets < submachine.submachine.chargerBulletsMax)
                    {
                        for (int i = chargerBullets; i < submachine.submachine.chargerBulletsMax; i++)
                        {
                            chargerBullets++;
                            inventory.RestItem(bulletsItem, 1);
                            inventoryDisplay.UpdateDisplay();
                        }
                    }
                    else if(chargerBullets < submachine.submachine.chargerBulletsMax)
                    {
                        for (int i = chargerBullets; i < submachine.submachine.chargerBulletsMax; i++)
                        {
                            if (bullets > 0)
                            {
                                chargerBullets++;
                                inventory.RestItem(bulletsItem, 1);
                                inventoryDisplay.UpdateDisplay();
                            }
                            else { break; }
                        }
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