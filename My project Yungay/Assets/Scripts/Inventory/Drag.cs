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
    private GameObject ghost;
    public GameObject inventoryPanel;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        drop = GetComponent<Drop>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        pos = rectTransform.position;
        ghost = Instantiate(eventData.pointerDrag.gameObject, rectTransform.position, Quaternion.identity);
        eventData.pointerDrag.GetComponent<Image>().color = new Color32(255, 255, 255, 100);
        ghost.transform.SetParent(inventoryPanel.transform);
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
                ghost.GetComponent<RectTransform>().anchoredPosition += eventData.delta / canvas.scaleFactor;
            }
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!drop.change)
        {
            rectTransform.position = pos;
        }

        Destroy(ghost);
        eventData.pointerDrag.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
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
