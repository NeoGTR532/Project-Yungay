using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickWeapon : MonoBehaviour
{
    public GameObject parent;
    public Transform weaponTransform;
    public MeleeWeapon meleeWeapon;

    public string nameParent;
    public string nameTransform;
    // Start is called before the first frame update
    void Start()
    {
        GetParent(nameParent);
        GetTransform(nameTransform);
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

    public void GetParent(string a)
    {
        parent = GameObject.Find(a);
    }

    public void GetTransform(string b)
    {
        weaponTransform = parent.transform.Find(b);
    }

    private void OnTriggerEnter(Collider collision)
    {
        //if (axeParent.childCount <= 0)
        //{

        //}
        if (collision.GetComponent<Collider>().tag == "Player" && weaponTransform.childCount <= 0)
        {
            
            this.GetComponent<Rigidbody>().isKinematic = true;
            meleeWeapon.enabled = true;
            meleeWeapon.capCollider.enabled = false;
            meleeWeapon.DesactivePickTrigger();
            this.transform.SetParent(weaponTransform);
            this.transform.localPosition = new Vector3(0f, 0f, 0f);
            this.transform.localRotation = Quaternion.Euler(-180f, 0f, -90f);
            this.GetComponent<Animator>().enabled = true;

            if (gameObject.name == "Axe")
            {
                gameObject.tag = "Axe";
            }

            if (gameObject.name == "Knife")
            {
                gameObject.tag = "Knife";
            }
        }

        
    }
}
