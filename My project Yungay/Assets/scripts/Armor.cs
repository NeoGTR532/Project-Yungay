using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : MonoBehaviour
{
    public PlayerModel playerHealth;
    public Inventory inventory;
    public InventoryDisplay inventoryDisplay;
    public ItemObject armorItem;
    private bool hasArmor;
    public float timeArmor;
    public float timer;
    public float maxTime;
    private bool charge;

    private void Start()
    {
        inventoryDisplay = InventoryDisplay.instance;
    }
    private void Update()
    {
        hasArmor = inventory.CheckItem(armorItem);
        if (hasArmor && Input.GetMouseButtonDown(0))
        {
            charge = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            if (timer < maxTime)
            {
                timer = 0;
                charge = false;
            }
        }

        if (timer >= maxTime)
        {
            timer = 0;
            charge = false;
            Doped();
        }

        if (charge)
        {
            timer += Time.deltaTime;
        }
    }
    public void Doped()
    {
        playerHealth.armor = timeArmor;
        inventory.RestItem(armorItem, 1);
        inventory.RemoveSlot();
        inventoryDisplay.UpdateDisplay();
    }
}
