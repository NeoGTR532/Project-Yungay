using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    private Inventory inventory;
    private ItemObject currentItem = null;
    private int slotIndex = 0;
    private MeshFilter meshFilter;
    private MeshRenderer meshRenderer;
    private Animator anim;
    public static bool isAttacking;
    private bool canAttack = false;
    // Start is called before the first frame update
    void Start()
    {
        meshFilter = GetComponent<MeshFilter>();
        meshRenderer = GetComponent<MeshRenderer>();
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
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
                meshFilter.sharedMesh = currentItem.prefab.GetComponent<MeshFilter>().sharedMesh;
                meshRenderer.sharedMaterial = currentItem.prefab.GetComponent<MeshRenderer>().sharedMaterial;
                EquipmentItem _ = (EquipmentItem)currentItem;
                anim.runtimeAnimatorController = _.controller;
                canAttack = true;
            }
            else
            {
                meshFilter.sharedMesh = null;
                meshRenderer.sharedMaterial = null;
                anim.runtimeAnimatorController = null;
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
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetBool("using", true);
            isAttacking = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            anim.SetBool("using", false);
        }
    }
}
