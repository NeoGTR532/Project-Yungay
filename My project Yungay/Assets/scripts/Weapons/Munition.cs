using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Munition : MonoBehaviour
{
    public ItemObject pistol;
    public ItemObject submachine;
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
    private RangeWeapons rangeWeapons;

    private void Start()
    {
        rangeWeapons = GetComponent<RangeWeapons>();
    }

    private void FixedUpdate()
    {
        if (Hand.canAim)
        {
            textNails.text = chargerNails.ToString();
            CheckAmmo();
            hasItemBullets = inventory.CheckItem(bulletsItem);
            hasItemNails = inventory.CheckItem(nailsItem);
            InventoryAmmo();
        }
    }

    public void InventoryAmmo()
    {
        if (hasItemNails)
        {
            int i = inventory.GetItemIndex(nailsItem);
            nails = inventory.CheckAmount(inventory.slots[i].item);
        }

        if (hasItemBullets)
        {
            int i = inventory.GetItemIndex(bulletsItem);
            bullets = inventory.CheckAmount(inventory.slots[i].item);
        }

        //switch (weapons.stateWeapons)
        //{
        //    case 1:
        //        if (hasItemNails)
        //        {
        //            int i = inventory.GetItemIndex(nailsItem);
        //            nails = inventory.CheckAmount(inventory.slots[i].item);
        //        }
        //        else if (hasItemNails == false)
        //        { }
        //        if (hasItemBullets)
        //        {
        //            int i = inventory.GetItemIndex(bulletsItem);
        //            bullets = inventory.CheckAmount(inventory.slots[i].item);
        //        }
        //        else if (hasItemBullets == false)
        //        { }
        //        break;
        //    case 2:
        //        if (hasItemBullets)
        //        {
        //            bullets = inventory.CheckAmount(bulletsItem);
        //        }
        //        else if (hasItemBullets == false)
        //        { }
        //        break;

        //    default:
        //        break;
        //}

    }

    public void RechargeAmmo(ItemObject itemObject)
    {
        EquipmentRange _ = (EquipmentRange)itemObject;
        if (itemObject == pistol)
        {
            if (rangeWeapons.ammoPistol == true && bullets >= 1)
            {

                if (bullets > _.chargerBulletsMax && chargerBullets < _.chargerBulletsMax)
                {
                    for (int i = chargerBullets; i < _.chargerBulletsMax; i++)
                    {
                        chargerBullets++;
                        inventory.RestItem(bulletsItem, 1);
                        inventoryDisplay.UpdateDisplay();
                    }
                }
                else
                {
                    for (int i = bullets; i > 0; i--)
                    {
                        if (chargerBullets < _.chargerBulletsMax)
                        {
                            chargerBullets++;
                            inventory.RestItem(bulletsItem, 1);
                            inventoryDisplay.UpdateDisplay();
                        }

                    }
                }
            }
            else if (rangeWeapons.ammoPistol == false && nails >= 1)
            {
                if (nails > _.chargerNailsMax && chargerNails < _.chargerNailsMax)
                {
                    for (int i = chargerNails; i < _.chargerNailsMax; i++)
                    {
                        chargerNails++;
                        inventory.RestItem(nailsItem, 1);
                        inventoryDisplay.UpdateDisplay();
                    }
                }
                else
                {
                    for (int i = nails; i > 0; i--)
                    {
                        if (chargerNails < _.chargerNailsMax)
                        {
                            chargerNails++;
                            inventory.RestItem(nailsItem, 1);
                            inventoryDisplay.UpdateDisplay();
                        }
                    }
                }
            }
        }

        if (itemObject == submachine)
        {
            if (rangeWeapons.ammoPistol == true && bullets >= 1)
            {
                if (bullets > _.chargerBulletsMax && chargerBullets < _.chargerBulletsMax)
                {
                    for (int i = chargerBullets; i < _.chargerBulletsMax; i++)
                    {
                        chargerBullets++;
                        inventory.RestItem(bulletsItem, 1);
                        inventoryDisplay.UpdateDisplay();

                    }
                }
                else
                {
                    for (int i = bullets; i > 0; i--)
                    {
                        if (chargerBullets < _.chargerBulletsMax)
                        {
                            chargerBullets++;
                            inventory.RestItem(bulletsItem, 1);
                            inventoryDisplay.UpdateDisplay();
                        }

                    }
                }
            }
        }
        
        //switch (itemObject)
        //{
        //    case pistol:
        //        if (pistol.ammo == true && bullets >= 1)
        //        {

        //            if (bullets > pistol.pistol.chargerBulletsMax && chargerBullets < pistol.pistol.chargerBulletsMax)
        //            {
        //                for (int i = chargerBullets; i < pistol.pistol.chargerBulletsMax; i++)
        //                {
        //                    chargerBullets++;
        //                    inventory.RestItem(bulletsItem, 1);
        //                    inventoryDisplay.UpdateDisplay();
        //                }
        //            }
        //            else
        //            {
        //                for (int i = bullets; i > 0; i--)
        //                {
        //                    if (chargerBullets < pistol.pistol.chargerBulletsMax)
        //                    {
        //                        chargerBullets++;
        //                        inventory.RestItem(bulletsItem, 1);
        //                        inventoryDisplay.UpdateDisplay();
        //                    }

        //                }
        //            }
        //        }
        //        else if (pistol.ammo == false && nails >= 1)
        //        {
        //            if (nails > pistol.pistol.chargerNailsMax && chargerNails < pistol.pistol.chargerNailsMax)
        //            {
        //                for (int i = chargerNails; i < pistol.pistol.chargerNailsMax; i++)
        //                {
        //                    chargerNails++;
        //                    inventory.RestItem(nailsItem, 1);
        //                    inventoryDisplay.UpdateDisplay();
        //                }
        //            }
        //            else
        //            {
        //                for (int i = nails; i > 0; i--)
        //                {
        //                    if (chargerNails < pistol.pistol.chargerNailsMax)
        //                    {
        //                        chargerNails++;
        //                        inventory.RestItem(nailsItem, 1);
        //                        inventoryDisplay.UpdateDisplay();
        //                    }
        //                }
        //            }
        //        }
        //        break;
        //    case 2:
        //        if (submachine.ammo == true && bullets >= 1)
        //        {
        //            if (bullets > submachine.submachine.chargerBulletsMax && chargerBullets < submachine.submachine.chargerBulletsMax)
        //            {
        //                for (int i = chargerBullets; i < submachine.submachine.chargerBulletsMax; i++)
        //                {
        //                    chargerBullets++;
        //                    inventory.RestItem(bulletsItem, 1);
        //                    inventoryDisplay.UpdateDisplay();

        //                }
        //            }
        //            else
        //            {
        //                for (int i = bullets; i > 0; i--)
        //                {
        //                    if (chargerBullets < submachine.submachine.chargerBulletsMax)
        //                    {
        //                        chargerBullets++;
        //                        inventory.RestItem(bulletsItem, 1);
        //                        inventoryDisplay.UpdateDisplay();
        //                    }

        //                }
        //            }
        //        }
        //        break;
        //}
    }

    public void CheckAmmo()
    {
        EquipmentRange _ = (EquipmentRange)Hand.currentItem;

        if (Hand.currentItem == pistol)
        {
            for (int i = chargerBullets; i > _.chargerBulletsMax; i--)
            {
                chargerBullets--;
                inventory.ReturnItem(bulletsItem, 1);
                inventoryDisplay.UpdateDisplay();
            }
        }



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