using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour
{

    Animator anim;
    public float force;
    public CapsuleCollider capCollider;
    public BoxCollider boxTriggerUse;
    public BoxCollider boxTriggerPick;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        DesactiveUseCollider();
        DesactivePickTrigger();
    }

    // Update is called once per frame
    void Update()
    {

        UseAxe();
        ThowAxe();
        
    }


    private void UseAxe()
    {
        if (Input.GetMouseButtonDown(0))

        {
            anim.SetBool("using", true);
        }

        else if (Input.GetMouseButtonUp(0))
        {
            anim.SetBool("using", false);
        }
    }

    private void ThowAxe()
    {
        if(Input.GetMouseButton(1))
        {
           
            this.GetComponent<Rigidbody>().isKinematic = false;
            this.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * force, ForceMode.Impulse);

            capCollider.enabled = true;
            
        }
    }

    public void ActiveUseCollider()
    {
        boxTriggerUse.enabled = true;
    }

    public void DesactiveUseCollider()
    {
        boxTriggerUse.enabled = false;
    }

    public void ActivePickTrigger()
    {
        boxTriggerPick.enabled = true;
    }

    public void DesactivePickTrigger()
    {
        boxTriggerPick.enabled = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        ActivePickTrigger();
        this.transform.SetParent(null);
        this.GetComponent<Rigidbody>().isKinematic = true;
        capCollider.enabled = false;
        this.enabled = false;
        
       
    }

   
}
