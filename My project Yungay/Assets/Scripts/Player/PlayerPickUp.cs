using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUp : MonoBehaviour
{
    public float pickUpRange;
    public float moveForce;

    private GameObject heldObj;
    public Transform holdParent;

    public GameObject handPos;

    public static bool isPushing;
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

                    }

                }
            }

            else
            {
                DropObject();
                //isPushing = false;
            }

        }

        if (heldObj != null)
        {
            isPushing = true;
            MoveObject();

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

    public void DropObject()
    {
        if (heldObj!=null)
        {
            isPushing = false;
            Rigidbody heldRig = heldObj.GetComponent<Rigidbody>();
            heldRig.useGravity = true;
            heldRig.drag = 1;
            heldObj.transform.parent = null;
            heldObj = null;
        }
        
        

        
    }
}
