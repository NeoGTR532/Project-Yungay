using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryDisplay : MonoBehaviour
{
    public Inventory inventory;
    [SerializeField] public List<GameObject> slotsUI = new List<GameObject>();
    private bool isOpen;
    [SerializeField] private GameObject inventaryPanel, craftPanel;
    private GameObject imageSlots;
    // Start is called before the first frame update
    void Awake()
    {
        imageSlots = GameObject.Find("InventoryPanel");
        for (int i = 0; i < inventory.maxSlots; i++)
        {
            slotsUI.Add(imageSlots.transform.GetChild(i).gameObject);
        }
        CloseDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I) && !isOpen && !GameManager.inPause)
        {
            OpenDisplay();
            GameManager.ShowCursor();
            Time.timeScale = 0f;

        }
        else if (Input.GetKeyDown(KeyCode.I) && !GameManager.inPause)
        {
            CloseDisplay();
            GameManager.HideCursor();
            Time.timeScale = 1f;
        }
    }

    public void UpdateDisplay()
    {
        for (int i = 0; i < inventory.slots.Count; i++)
        {
            if (inventory.slots[i] != null)
            {
                if (inventory.slots[i].item != null)
                {
                    slotsUI[i].GetComponent<Slot>().slot = inventory.slots[i];
                    slotsUI[i].GetComponent<Image>().sprite = inventory.slots[i].item.itemSprite;
                    TMP_Text text = slotsUI[i].transform.GetChild(0).GetComponent<TMP_Text>();
                    text.text = inventory.slots[i].amount.ToString();
                }
                else
                {
                    slotsUI[i].GetComponent<Slot>().slot.item = null;
                    slotsUI[i].GetComponent<Slot>().slot.amount = 0;
                    slotsUI[i].GetComponent<Image>().sprite = null;
                    TMP_Text text = slotsUI[i].transform.GetChild(0).GetComponent<TMP_Text>();
                    text.text = null;
                }
            }
        }
    }

    void OpenDisplay()
    {
        inventaryPanel.SetActive(true);
        craftPanel.SetActive(true);
        isOpen = true;
    }

    void CloseDisplay()
    {
        inventaryPanel.SetActive(false);
        craftPanel.SetActive(false);
        isOpen = false;
    }
}
