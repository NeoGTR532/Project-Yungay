using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int maxSlots;
    public List<InventorySlot> slots = new List<InventorySlot>();
    public CraftRecipes objectToCraft;
    public InventoryDisplay inventoryDisplay;

    private void Awake()
    {
        for (int i = 0; i < maxSlots; i++)
        {
            slots.Add(null);
        }
    }
    public void AddItem(Item item, ItemObject itemObject, int amount)
    {
        bool hasItem = false;
        for (int i = 0; i < slots.Count; i++)
        {
            if (slots[i].item == itemObject)
            {
                if (slots[i].amount + amount < slots[i].item.maxStack)
                {
                    slots[i].AddAmount(amount);
                    item.amount = 0;
                }
                else
                {
                    item.amount = (slots[i].amount + amount) - slots[i].item.maxStack;
                    slots[i].amount = slots[i].item.maxStack;
                }

                hasItem = true;
                break;
            }
        }
        if (!hasItem)
        {
            if (slots.Count <= maxSlots)
            {
                //slots.Add(new InventorySlot(itemObject, amount));
                for (int i = 0; i < slots.Count; i++)
                {
                    if (slots[i].item == null)
                    {
                        slots[i].item = itemObject;
                        slots[i].amount = amount;
                        break;
                    }
                }
                if (item != null)
                {
                    item.amount = 0;
                }
            }
            else
            {
                Debug.Log("No hay espacio en el inventario");
            }
        }

        inventoryDisplay.UpdateDisplay();
    }

    public void CraftItem(CraftRecipes recipe)
    {
        bool hasMaterials = false;
        int materialCount = recipe.materials.Count;
        int count = 0;
        for (int i = 0; i < recipe.materials.Count; i++)
        {
            foreach (InventorySlot slot in slots)
            {
                if (slot.item == recipe.materials[i].item)
                {
                    if (slot.amount >= recipe.materials[i].amount)
                    {
                        count++;
                    }
                }
            }
        }

        if (count == materialCount)
        {
            hasMaterials = true;
        }
        else
        {
            Debug.Log("No tienes los materiales suficientes");
        }

        if (hasMaterials)
        {
            bool hasItem = CheckItem(recipe.result);
            if (hasItem)
            {
                int index = GetItemIndex(recipe.result);
                if (slots[index].amount + recipe.amount < recipe.result.maxStack)
                {
                    Craft(recipe, count);
                }
            }
            else
            {
                Craft(recipe, count);
            }
        }
    }

    private void Craft(CraftRecipes recipe, int count)
    {
        for (int i = 0; i < recipe.materials.Count; i++)
        {
            foreach (InventorySlot slot in slots)
            {
                if (slot.item == recipe.materials[i].item)
                {
                    slot.amount -= recipe.materials[i].amount;
                }
            }
        }

        for (int i = 0; i < count; i++)
        {
            RemoveSlot();
        }

        AddItem(null, recipe.result, recipe.amount);
    }
    private void RemoveSlot()
    {
        for (int i = 0; i < slots.Count; i++)
        {
            if (slots[i].amount == 0)
            {
                slots[i].item = null;
                slots[i].amount = 0;
            }
        }
        inventoryDisplay.UpdateDisplay();
    }

    public bool CheckItem(ItemObject item)
    {
        bool hasItem = false;
        for (int i = 0; i < slots.Count; i++)
        {
                if (slots[i].item == item)
                {
                    hasItem = true;
                    break;
                }
                else
                {
                    hasItem = false;
                    break;
                }
            
        }

        return hasItem;
    }

    public int CheckAmount(ItemObject item)
    {
        int amount = 0;

        for (int i = 0; i < slots.Count; i++)
        {
            if (slots[i].item == item)
            {
                amount = slots[i].amount;
            }
        }

        return amount;
    }

    public int GetItemIndex(ItemObject item)
    {
        int index = 0;

        for (int i = 0; i < slots.Count; i++)
        {
            if (slots[i].item == item)
            {
                index = i;
            }
        }

        return index;
    }
    public void RestItem(ItemObject item, int value)
    {
        bool hasItem = CheckItem(item);
        if (hasItem)
        {
            int index = GetItemIndex(item);
            slots[index].RestAmount(value);
        }
    }
}

[System.Serializable]
public class InventorySlot
{
    public ItemObject item;
    public int amount;

    public InventorySlot(ItemObject item, int amount)
    {
        this.item = item;
        this.amount = amount;
    }

    public void AddAmount(int value)
    {
        amount += value;
    }

    public void RestAmount(int value)
    {
        amount -= value;
    }
}