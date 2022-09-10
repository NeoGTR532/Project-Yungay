using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public PlayerModel model;
    public PlayerGroundCheck playerGroundCheck;
    public Transform orientation;

    private float hor;
    private float ver;

    public float airMultiplier;

    Vector3 move;
    // Start is called before the first frame update
    void Start()
    {
        model.rb.freezeRotation = true;
    }

    private void Update()
    {
        hor = Input.GetAxisRaw("Horizontal");
        ver = Input.GetAxisRaw("Vertical");

        ControlSpeed();
         
    }
    void FixedUpdate()
    {
        Walk();
    }

    private void Walk()
    {
        
        move = orientation.forward * ver + orientation.right * hor;

        if(playerGroundCheck.grounded)
        {
            model.rb.AddForce(move.normalized * model.speed * 10f, ForceMode.Force);
        }

        else if (!playerGroundCheck.grounded)
        {
            model.rb.AddForce(move.normalized * model.speed * 10f * airMultiplier , ForceMode.Force);
        }


    }

    private void ControlSpeed()
    {
        Vector3 flatVel = new Vector3(model.rb.velocity.x, 0f, model.rb.velocity.z);


        if(flatVel.magnitude > model.speed)
        {
            Vector3 limitedVel = flatVel.normalized * model.speed;
            model.rb.velocity = new Vector3(limitedVel.x, model.rb.velocity.y, limitedVel.z);
        }
    }
}
