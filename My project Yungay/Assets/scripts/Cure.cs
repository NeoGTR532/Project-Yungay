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
    public float speed;
    public float timer;
    public float maxTime;

    private void Start()
    {
        inventoryDisplay = InventoryDisplay.instance;
    }

    private void FixedUpdate()
    {
        hasBandage = inventory.CheckItem(bandageItem);
        if (hasBandage && Input.GetMouseButtonDown(0) && playerHealth.mb.health < playerHealth.mb.maxHealth) 
        {
            timer += Time.deltaTime;
        }
        else if(Input.GetMouseButtonUp(0))
        {
            if(timer < maxTime)
            {
                timer = 0;
            }
        }

        if (timer >= maxTime)
        {
            timer = 0;
            Heal();
        }
    }
    public void Heal()
    {
        health = playerHealth.mb.maxHealth * (percentageCure/100);
        StartCoroutine(healing(playerHealth.mb.health + health));

        //playerHealth.mb.health += health;
        inventory.RestItem(bandageItem, 1);
        inventory.RemoveSlot();
        inventoryDisplay.UpdateDisplay();
    }

    IEnumerator healing(float heal)
    {
        while(playerHealth.mb.health < heal)
        {
            playerHealth.mb.health += speed * Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        yield break;

    }
}
