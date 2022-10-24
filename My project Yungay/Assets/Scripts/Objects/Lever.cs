using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public int leverID;
    public int id;
    public Animator anim;

    private void Start()
    {
        EventManager.current.useLeverEvent += StartCinematic;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        {
            EventManager.current.StartUseLeverEvent(leverID);
            anim.SetBool("isUse", true);

        }
    }


    private void StartCinematic(int id)
    {
        if (id == this.id)
        {
            Debug.Log("Inicia la cinematica");
        }

    }

    private void OnDisable()
    {
        EventManager.current.useLeverEvent -= StartCinematic;
    }

}
