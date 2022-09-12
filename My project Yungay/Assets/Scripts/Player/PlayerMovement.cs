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

        model.actualSpeed = model.rb.velocity.magnitude;
         
    }
    void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        
        move = orientation.forward * ver + orientation.right * hor;

        if(playerGroundCheck.grounded)
        {
            if (Input.GetKey(KeyCode.LeftShift) && model.staActual >=0)
            {
                Run();
            }
            else
            {
                Walk();
            }
        }

        else if (!playerGroundCheck.grounded)
        {
            model.rb.AddForce(move.normalized * model.speedWalk * 10f * airMultiplier , ForceMode.Force);
        }


    }

    private void Walk()
    {
        model.rb.AddForce(move.normalized * model.speedWalk * 10f, ForceMode.Force);
        model.isRunning = false;
    }
    private void Run()
    {
        model.rb.AddForce(move.normalized * model.speedRun * 10f, ForceMode.Force);
        model.isRunning = true;
    }

    private void ControlSpeed()
    {
        Vector3 flatVel = new Vector3(model.rb.velocity.x, 0f, model.rb.velocity.z);

        if(model.isRunning)
        {
            if (flatVel.magnitude > model.speedRun)
            {
                Vector3 limitedVel = flatVel.normalized * model.speedRun;
                model.rb.velocity = new Vector3(limitedVel.x, model.rb.velocity.y, limitedVel.z);
            }
        }
        else
        {
            if (flatVel.magnitude > model.speedWalk)
            {
                Vector3 limitedVel = flatVel.normalized * model.speedWalk;
                model.rb.velocity = new Vector3(limitedVel.x, model.rb.velocity.y, limitedVel.z);
            }
        }
        
    }
}
