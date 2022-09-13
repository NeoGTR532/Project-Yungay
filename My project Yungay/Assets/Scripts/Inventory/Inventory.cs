using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<InventorySlot> slots = new List<InventorySlot>();
    public int maxSlots;

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
            if (slots.Count<maxSlots)
            {
                slots.Add(new InventorySlot(itemObject, amount));
                if (item!=null)
                {
                    item.amount = 0;
                }
            }
            else
            {
                Debug.Log("No hay espacio en el inventario");
            }
        }
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
                if (slot.item==recipe.materials[i].item)
                {
                    if (slot.amount >= recipe.materials[i].amount)
                    {
                        count++;
                    }
                }
            }
        }

        if (count==materialCount)
        {
            hasMaterials = true;
        }

        if (hasMaterials)
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
    }

    private void RemoveSlot()
    {
        for (int i = 0; i < slots.Count; i++)
        {
            if (slots[i].amount==0)
            {
                slots.RemoveAt(i);
            }
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
}
