using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPush : MonoBehaviour
{
    public PlayerModel model;
    public GameObject handPos;
    public float HandRange;
    private GameObject pickedObject = null;
    public GameObject handpush;
    public bool ispushing;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        push();
    }
    public void push()
    {
        if (pickedObject != null)
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                pickedObject.gameObject.transform.SetParent(null);
                pickedObject.GetComponent<Rigidbody>().isKinematic = false;
                pickedObject = null;
                model.canJump = true;
                model.canCrouch = true;
                model.canRun = true;
                ispushing = false;
            }
        }

        RaycastHit hit;
        if (Physics.Raycast(handPos.transform.position, handPos.transform.forward, out hit, HandRange))
        {
            if (hit.transform.gameObject.CompareTag("Object"))
            {
                if (Input.GetKey(KeyCode.E) && pickedObject == null)
                {
                    ispushing = true;
                    //hit.transform.position = handpush.transform.position;
                    hit.transform.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                    hit.transform.SetParent(handpush.gameObject.transform);
                    pickedObject = hit.transform.gameObject;
                    model.canJump = false;
                    model.canCrouch = false;
                    model.canRun = false;


                }
            }
        }
    }
}
