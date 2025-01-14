using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLooting : MonoBehaviour
{
    public Camera cam;
    public Inventory inventory;
    public GameObject lootText;
    public float rayDistance;
    // Start is called before the first frame update
    void Awake()
    {
        inventory = GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        Loot();
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawRay(cam.transform.position, cam.transform.forward * rayDistance);

    }

    private bool CheckLoot(Loot loot)
    {
        bool canloot = false;

        for (int i = 0; i < loot.loot.Count; i++)
        {
            if (loot.loot[i].amount > 0)
            {
                canloot = true;
                break;
            }
        }
        return canloot;
    }

    private void Loot()
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 1.5f) && hit.collider.gameObject.GetComponent<Loot>())
        {
            var loot = hit.collider.gameObject.GetComponent<Loot>();
            if (CheckLoot(loot))
            {
                lootText.GetComponent<Animator>().SetBool("Show", true);

                if (Input.GetKeyDown(KeyCode.F))
                {
                    for (int i = 0; i < loot.loot.Count; i++)
                    {
                        var _ = loot.loot[i];
                        inventory.AddItem(_, _.item, _.amount);
                    }
                    loot.DeleteObject();
                    lootText.GetComponent<Animator>().SetBool("Show", false);
                }
            }
        }
        else
        {
            lootText.GetComponent<Animator>().SetBool("Show", false);
        }
    }
}
