using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : MonoBehaviour
{
    public float health;

    [Header("Movement")]
    public float actualSpeed;
    public float speedWalk;
    public float speedRun;
    public float jumpForce;
    public float jumpCooldown;


    [Header("Stamina Parameters")]
    public int staMax;
    public float staActual;
    public bool isRunning = false;

    [Header("Stamina Regen Parameters")]
    public float staminaDrain = 0.5f;
    public float staRegen = 0.3f;


    public Rigidbody rb;

    public Inventory inventory;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        inventory = GetComponent<Inventory>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        var item = collision.gameObject.GetComponent<Item>();
        if (item)
        {
            inventory.AddItem(item, item.item, item.amount);
        }
    }
}
