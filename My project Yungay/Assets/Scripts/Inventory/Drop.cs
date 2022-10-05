using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drop : MonoBehaviour, IDropHandler
{
    public Inventory inventory;
    public InventoryDisplay inventoryDisplay;

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            Debug.Log("CAMBIO");
            Drag drag = eventData.pointerDrag.GetComponent<Drag>();
            ItemObject item = GetComponent<Slot>().slot.item;
            ItemObject item2 = drag.slot.item;
            int amount = GetComponent<Slot>().slot.amount;
            int amount2 = drag.slot.amount;
            eventData.pointerDrag.GetComponent<Slot>().slot.item = item;
            eventData.pointerDrag.GetComponent<Slot>().slot.amount = amount;
            GetComponent<Slot>().slot.item = item2;
            GetComponent<Slot>().slot.amount = amount2;
            inventoryDisplay.UpdateDisplay();
            inventory.UpdateInventory();
        }
    }
}
