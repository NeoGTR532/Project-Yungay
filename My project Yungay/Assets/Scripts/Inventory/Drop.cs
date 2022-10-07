using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drop : MonoBehaviour, IDropHandler
{
    public Inventory inventory;
    public InventoryDisplay inventoryDisplay;
    public bool change = false;

    public void OnDrop(PointerEventData eventData)
    {
        change = false;
        if (eventData.pointerDrag != null)
        {
            Drag drag = eventData.pointerDrag.GetComponent<Drag>();
            if (drag.slot.item != GetComponent<Slot>().slot.item)
            {
                change = true;
                ItemObject item = GetComponent<Slot>().slot.item;
                ItemObject item2 = drag.slot.item;
                int amount = GetComponent<Slot>().slot.amount;
                int amount2 = drag.slot.amount;

                if (item == null)
                {
                    eventData.pointerDrag.GetComponent<Slot>().slot = new InventorySlot(null, 0);
                }
                else
                {
                    eventData.pointerDrag.GetComponent<Slot>().slot.item = item;
                    eventData.pointerDrag.GetComponent<Slot>().slot.amount = amount;
                }

                GetComponent<Slot>().slot.item = item2;
                GetComponent<Slot>().slot.amount = amount2;

                inventoryDisplay.UpdateDisplay();
                inventory.UpdateInventory();
            }
            else
            {
                Vector3 pos = PlayerModel.playerTransform.position;
                pos.x -= 1;
                pos.y += 0.5f; 
                GameObject clone = Instantiate(drag.prefabItem, new Vector3(pos.x, pos.y, pos.z), Quaternion.identity);
                clone.GetComponent<Item>().amount = GetComponent<Slot>().slot.amount;
                GetComponent<Slot>().slot.item = null;
                GetComponent<Slot>().slot.amount = 0;
                inventoryDisplay.UpdateDisplay();
                inventory.UpdateInventory();
            }
        }
    }
}
