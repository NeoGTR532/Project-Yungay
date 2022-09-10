using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : MonoBehaviour
{
    public float health;

    [Header("Movement")]
    public float speed;
    public float jumpForce;
    public float jumpCooldown;



    
    public Rigidbody rb;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        
    }

}
