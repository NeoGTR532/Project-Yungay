using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public PlayerModel model;
    //public PlayerGroundCheck playerGroundCheck;
    public Transform orientation;

    private float hor;
    private float ver;

    public float airMultiplier;

    public Animator anim;

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
        Movement();
    }
    void FixedUpdate()
    {
        
        
    }

    private void Movement()
    {
        
        move = orientation.forward * ver + orientation.right * hor;
        
        if (PlayerGroundCheck.grounded/*playerGroundCheck.grounded*/)
        {
            
            if (Input.GetKey(KeyCode.LeftShift) && model.staActual >=0 && !model.isCrouching)
            {
                Run();
            }
            
            else
            {
                Walk();
            }
        }

        else if (!PlayerGroundCheck.grounded/*playerGroundCheck.grounded*/)
        {
            model.rb.AddForce(move.normalized * model.speedWalk * 10f * airMultiplier , ForceMode.Force);

        }

        if (hor != 0 || ver != 0)
        {
           model.sourceSound.SetActive(true);
        }
        else
        {
           model.sourceSound.SetActive(false);
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
        if (model.actualSpeed >=4.5)
        {
            model.isRunning = true;
        }
        else
        {
            model.isRunning = false;
        }
        
        
            
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
