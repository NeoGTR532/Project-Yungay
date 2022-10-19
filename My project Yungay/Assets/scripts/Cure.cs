using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cure : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public Inventory inventory;
    public InventoryDisplay inventoryDisplay;
    public ItemObject bandageItem;
    private bool hasBandage;
    private float health;
    public float percentageCure;

    private void Start()
    {
        inventoryDisplay = InventoryDisplay.instance;
    }

    private void FixedUpdate()
    {
        hasBandage = inventory.CheckItem(bandageItem);
        if (hasBandage && Input.GetMouseButtonDown(0) && playerHealth.mb.health < playerHealth.mb.maxHealth) 
        {
            Heal();
        }
    }
    public void Heal()
    {
        health = playerHealth.mb.maxHealth * (percentageCure/100);
        playerHealth.mb.health += health;
        inventory.RestItem(bandageItem, 1);
        inventoryDisplay.UpdateDisplay();
    }
}
