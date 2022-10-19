using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUp : MonoBehaviour
{
    public float pickUpRange = 5;
    public float moveForce = 250;

    private GameObject heldObj;
    public Transform holdParent;
    public PlayerCam playerCam;

    public GameObject handPos;
    public float HandRange;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (heldObj == null)
            {
                RaycastHit hit;
                if (Physics.Raycast(handPos.transform.position, handPos.transform.TransformDirection(Vector3.forward), out hit, pickUpRange))
                {
                    if (hit.transform.gameObject.CompareTag("Object"))
                    {
                        PickupObject(hit.transform.gameObject);
                        //playerCam.enabled = !playerCam.enabled;
                    }

                }
            }

            else
            {
                DropObject();
            }
           
        }

        if (heldObj != null)
        {
            MoveObject();
            playerCam.enabled = !playerCam.enabled;
        }
    }

    void MoveObject()
    {
        if (Vector3.Distance(heldObj.transform.position, holdParent.position) > 0.1f)
        {
            Vector3 moveDirection = (holdParent.transform.position - heldObj.transform.position);
            heldObj.GetComponent<Rigidbody>().AddForce(moveDirection * moveForce);
        }
    }

    void PickupObject(GameObject pickObj)
    {
        if (pickObj.GetComponent<Rigidbody>())
        {
            Rigidbody objRig = pickObj.GetComponent<Rigidbody>();
            //objRig.useGravity = false;
            objRig.drag = 10;

            objRig.transform.parent = holdParent;
            heldObj = pickObj;
        }
    }

    void DropObject()
    {
        Rigidbody heldRig = heldObj.GetComponent<Rigidbody>();
        heldRig.useGravity = true;
        heldRig.drag = 1;

        heldObj.transform.parent = null;
        heldObj = null;
        playerCam.enabled = playerCam.enabled;
    }
}
