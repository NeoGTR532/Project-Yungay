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
        var loot = other.gameObject.GetComponent<Loot>();

        if (loot)
        {
            lootText.GetComponent<Animator>().SetBool("Show", true);
            if (Input.GetKeyDown(KeyCode.F))
            {
                for (int i = 0; i < loot.loot.Count; i++)
                {
                    inventory.AddItem(loot.loot[i], loot.loot[i].item, loot.loot[i].amount);
                }

                lootText.GetComponent<Animator>().SetBool("Show", false);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var loot = other.gameObject.GetComponent<Loot>();

        if (loot)
        {
            lootText.GetComponent<Animator>().SetBool("Show", false);

        }
    }
}
