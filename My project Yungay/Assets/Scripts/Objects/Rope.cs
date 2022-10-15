using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        EventManager.current.cutRopeEvent += CutRope;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void CutRope()
    {
        anim.SetBool("isCut", true);
        this.GetComponent<BoxCollider>().enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Knife")
        {
            EventManager.current.StartCuttingRopeEvent(); //trigger solo para practicar, cuando sea necesario se usara el trigger en otro objecto
        }

    }

    private void OnDisable()
    {
        EventManager.current.cutRopeEvent -= CutRope;
    }
}
