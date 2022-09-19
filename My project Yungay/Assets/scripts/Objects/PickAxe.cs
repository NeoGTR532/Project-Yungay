using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickAxe : MonoBehaviour
{
    public Transform axeParent;
    public Axe axeScript;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.GetComponent<Collider>().tag == "Player")
        {
            this.transform.SetParent(axeParent);
            this.GetComponent<Rigidbody>().isKinematic = true;
            axeScript.enabled = true;
            axeScript.capCollider.enabled = false;
            axeScript.DesactivePickTrigger();
            this.transform.localPosition = new Vector3(0f, 0f, 0f);
        }
    }

   
}
