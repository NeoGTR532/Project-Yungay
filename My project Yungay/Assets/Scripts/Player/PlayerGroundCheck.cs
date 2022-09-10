using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundCheck : MonoBehaviour
{
    public PlayerModel model;

    [Header("GroundCheck")]
    public float height;
    public LayerMask Ground;
    public bool grounded;
    public float groundDrag;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, height * 0.5f + 0.2f, Ground);

        if (grounded)
        {
            model.rb.drag = groundDrag;
        }

        else

        {
            model.rb.drag = 0;
        }
    }

}
