using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Drag : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;
    private RectTransform rectTransform;
    public Vector3 pos;
    [HideInInspector]public GameObject prefabItem;
    public InventoryDisplay inventoryDisplay;
    public Inventory inventory;
    [HideInInspector]public InventorySlot slot;
    private Drop drop;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        drop = GetComponent<Drop>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        pos = rectTransform.position; 
        prefabItem = GetItemObject().prefab;
        slot = GetComponent<Slot>().slot;
        if (drop.change)
        {
            drop.change = false;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (GetComponent<Image>().sprite != null)
        {
            if (slot.item != null)
            {
                rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
            }
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!drop.change)
        {
            rectTransform.position = pos;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {

    }

    private ItemObject GetItemObject()
    {
        ItemObject item = null;
        for (int i = 0; i < inventoryDisplay.slotsUI.Count; i++)
        {
            if (inventoryDisplay.slotsUI[i] == gameObject)
            {             
                for (int j = 0; j < inventory.slots.Count; j++)
                {
                    if (j == i)
                    {
                        item = inventory.slots[j].item;
                        break;
                    }
                }

                break;
            }
        }
        return item;
    }
}
