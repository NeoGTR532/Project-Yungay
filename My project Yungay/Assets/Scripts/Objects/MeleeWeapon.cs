using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : MonoBehaviour
{

    public GameObject modelWeapon;

    Animator anim;
    public float force;
    public CapsuleCollider capCollider;
    public BoxCollider boxTriggerUse;
    public BoxCollider boxTriggerPick;
    public float damage;

    public string nameTransform;
    // Start is called before the first frame update
    void Start()
    {
        GetTransform(nameTransform);

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

    private void GetTransform(string a)
    {
        modelWeapon = GameObject.Find(a);
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
            this.transform.SetParent(null);
            modelWeapon.SetActive(false);
            anim.enabled = false;

            
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
        //this.transform.SetParent(null);
        this.GetComponent<Rigidbody>().isKinematic = true;
        capCollider.enabled = false;
        this.enabled = false;
        //this.enabled = false;

        /* if (collision.gameObject.CompareTag("Enemy"))
         {
             gameObject.GetComponent<EnemyHealth>().lifeE(damage);
         }*/

    }

   
}
