using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLooting : MonoBehaviour
{
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

    }

    public void OnTriggerStay(Collider other)
    {
        var item = other.gameObject.GetComponent<Item>();

        if (item)
        {
            lootText.GetComponent<Animator>().SetBool("Show", true);
            if (Input.GetKeyDown(KeyCode.F))
            {
                inventory.AddItem(item, item.item, item.amount);
                lootText.GetComponent<Animator>().SetBool("Show", false);
            }



        }
    }

    private void OnTriggerExit(Collider other)
    {
        var item = other.gameObject.GetComponent<Item>();

        if (item)
        {
            lootText.GetComponent<Animator>().SetBool("Show", false);

        }
    }
}
