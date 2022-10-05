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
    public GameObject prefabItem;
    public InventoryDisplay inventoryDisplay;
    public Inventory inventory;
    public ItemObject thisitem;
    public InventorySlot slot;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        pos = rectTransform.position;
        thisitem = GetItemObject();
        prefabItem = thisitem.prefab;
        slot = GetComponent<Slot>().slot;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (GetComponent<Image>().sprite != null)
        {
            rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        rectTransform.position = pos;
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
