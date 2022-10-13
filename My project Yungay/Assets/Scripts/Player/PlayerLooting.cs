using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLooting : MonoBehaviour
{
    public Camera cam;
    public Inventory inventory;
    public GameObject lootText;
    // Start is called before the first frame update
    void Awake()
    {
        inventory = GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
       

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        

        if (Physics.Raycast(ray, out hit, 1.5f) && hit.collider.gameObject.GetComponent<Loot>()/*CompareTag("Loot")*/)
        {
            var loot = hit.collider.gameObject.GetComponent<Loot>();
            lootText.GetComponent<Animator>().SetBool("Show", true);

            if (Input.GetKeyDown(KeyCode.F))
            {
                for (int i = 0; i < loot.loot.Count; i++)
                {
                    inventory.AddItem(loot.loot[i], loot.loot[i].item, loot.loot[i].amount);
                }
            }

        }

        else
        {
            lootText.GetComponent<Animator>().SetBool("Show", false);
        }
            
    }

    //public void OnTriggerStay(Collider other)
    //{
    //    var loot = other.gameObject.GetComponent<Loot>();

    //    if (loot)
    //    {
    //        lootText.GetComponent<Animator>().SetBool("Show", true);
    //        if (Input.GetKeyDown(KeyCode.F))
    //        {
    //            for (int i = 0; i < loot.loot.Count; i++)
    //            {
    //                inventory.AddItem(loot.loot[i], loot.loot[i].item, loot.loot[i].amount);
    //            }

    //            lootText.GetComponent<Animator>().SetBool("Show", false);
    //        }
    //    }
    //}
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(cam.transform.position, cam.transform.forward * 1f);

    }

    //private void OnTriggerExit(Collider other)
    //{
    //    var loot = other.gameObject.GetComponent<Loot>();

    //    if (loot)
    //    {
    //        lootText.GetComponent<Animator>().SetBool("Show", false);

    //    }
    //}
}
