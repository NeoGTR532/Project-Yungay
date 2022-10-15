using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public int leverID;
    public Animator anim;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        {
            EventManager.current.StartUseLeverEvent(leverID);
            anim.SetBool("isUse", true);
            this.enabled = false;

        }
    }


}
