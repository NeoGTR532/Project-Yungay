using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    private Inventory inventory;
    private InventoryDisplay inventoryDisplay;
    public static ItemObject currentItem = null;
    private int slotIndex = 0;
    private MeshFilter meshFilter;
    private MeshRenderer meshRenderer;
    private Animator anim;
    public static bool isAttacking;
    private bool canAttack = false;
    public float force;
    public static bool canAim = false;
    // Start is called before the first frame update
    void Start()
    {
        meshFilter = GetComponent<MeshFilter>();
        meshRenderer = GetComponent<MeshRenderer>();
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        inventoryDisplay = InventoryDisplay.instance;//GameObject.FindGameObjectWithTag("UI").GetComponent<InventoryDisplay>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        ChangeItem();
        ChangeMesh();
        if (canAttack)
        {
            UseItem();
            Throw();
        }
    }

    private void ChangeItem()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            slotIndex = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            slotIndex = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            slotIndex = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            slotIndex = 3;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            slotIndex = 4;
        }
    }

    private void ChangeMesh()
    {
        currentItem = inventory.slots[slotIndex].item;
        if (currentItem ? true:false)
        {
            if (currentItem.type == ItemType.Equipment)
            {
                EquipmentItem _ = (EquipmentItem)currentItem;
                meshFilter.sharedMesh = _.itemMesh;
                meshRenderer.sharedMaterial = _.itemMaterial;
                canAttack = true;
            }
            else
            {
                meshFilter.sharedMesh = null;
                meshRenderer.sharedMaterial = null;
                canAttack = false;
            }
        }
        else
        {
            meshFilter.sharedMesh = null;
            meshRenderer.sharedMaterial = null;
        }

    }

    private void UseItem()
    {
        EquipmentItem _ = (EquipmentItem)currentItem;

        if (_.equipmentType == EquipmentType.Range)
        {
            canAim = true;
        }


        if (Input.GetMouseButtonDown(0) && !GameManager.inPause)
        {
            if (_.equipmentType == EquipmentType.Melee)
            {
                EquipmentMelee melee = (EquipmentMelee)currentItem;
                anim.Play(melee.animation.name);
                isAttacking = true;
            }
        }

    }

    private void Throw()
    {
        if (Input.GetMouseButton(1) && !GameManager.inPause)
        {
            EquipmentItem _ = (EquipmentItem)currentItem;
            if (_.equipmentType == EquipmentType.Melee)
            {
                GameObject clone = Instantiate(currentItem.prefab, transform.position, transform.rotation);
                clone.GetComponent<Loot>().loot[0].amount = inventory.slots[slotIndex].amount;
                clone.GetComponent<Rigidbody>().isKinematic = false;
                clone.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * force, ForceMode.Impulse);
                inventory.slots[slotIndex].item = null;
                inventory.slots[slotIndex].amount = 0;
                inventory.UpdateInventory();
                inventoryDisplay.UpdateDisplay();
                canAttack = false;
            }
        }
    }

    public void AddCollider()
    {
        gameObject.AddComponent<BoxCollider>();
        GetComponent<BoxCollider>().isTrigger = true;
    }

    public void RemoveCollider()
    {
        Destroy(GetComponent<BoxCollider>());
    }
}
