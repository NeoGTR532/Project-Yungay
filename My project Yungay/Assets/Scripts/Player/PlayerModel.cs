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
    public float speedCrouch;
    public float jumpForce;
    public float jumpCooldown;

    [Header("Crouch")]
    public bool isCrouching = false;
    public CapsuleCollider cap;

    public float standHeight;
    public float standY;
    public float crouchHeight;
    public float CrouchY;

    [Header("Stamina Parameters")]
    public int staMax;
    public float staActual;
    public bool isRunning = false;

    [Header("Stamina Regen Parameters")]
    public float staminaDrain = 0.5f;
    public float staRegen = 0.3f;


    [Header("Optional Functions")]
    public bool canCrouch;
    public bool canJump;
    public bool canRun;



    public Rigidbody rb;

    public Inventory inventory;

    public AudioSource Walk;


    private void Awake()
    {
        cap = GetComponent<CapsuleCollider>();
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
