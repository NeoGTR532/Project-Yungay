using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CraftDisplay : MonoBehaviour, IPointerClickHandler
{
    public Inventory inventory;
    public InventoryDisplay inventoryDisplay;
    public CraftRecipes recipe;
    private Image image;
    public bool canCraft;

    
    public void OnPointerClick(PointerEventData eventData)
    {
        if (canCraft)
        {
            inventory.CraftItem(recipe);
            inventory.UpdateInventory();
            inventoryDisplay.UpdateDisplay();
            CheckIsCraftable();
        }
    }

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    private void Start()
    {
        image.color = new Color32(255, 255, 255, 100);
    }

    // Update is called once per frame
    void Update()
    {
        if (canCraft)
        {
            image.color = new Color32(255, 255, 255, 255);
        }
        else
        {
            image.color = new Color32(255, 255, 255, 100);
        }
    }

    public void CheckIsCraftable()
    {
        bool hasItems = inventory.CheckItems(recipe);

        if (hasItems)
        {
            canCraft = true;
        }
        else
        {
            canCraft = false;
            
        }
    }
}
