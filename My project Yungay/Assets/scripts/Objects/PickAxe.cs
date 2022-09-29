using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickAxe : MonoBehaviour
{
    public GameObject parent;
    public Transform axeParent;
    public Axe axeScript;
    // Start is called before the first frame update
    void Start()
    {
        parent = GameObject.Find("Parent");
        axeParent = parent.transform.Find("Axe_Parent");
    }

    // Update is called once per frame
    void Update()
    {
        //axeParent = FindObjectsOfType<Transform>(true);
        //axeParent = gameObject.transform.Find("Axe_Parent");
        //if (axeParent == null)
        //{
        //    Debug.Log("no se encontro axe parent");
        //}
    }

    private void OnTriggerEnter(Collider collision)
    {
        //if (axeParent.childCount <= 0)
        //{

        //}
        if (collision.GetComponent<Collider>().tag == "Player" && axeParent.childCount <= 0)
        {
            
            this.GetComponent<Rigidbody>().isKinematic = true;
            axeScript.enabled = true;
            axeScript.capCollider.enabled = false;
            axeScript.DesactivePickTrigger();
            this.transform.SetParent(axeParent);
            this.transform.localPosition = new Vector3(0f, 0f, 0f);
            this.transform.localRotation = Quaternion.Euler(-180f, 0f, -90f);
            this.GetComponent<Animator>().enabled = true;
        }
    }

   
}
