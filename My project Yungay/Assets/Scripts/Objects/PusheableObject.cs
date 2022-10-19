using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PusheableObject : MonoBehaviour
{
    public PlayerPickUp playerPickUp;
    // Start is called before the first frame update
    void Awake()
    {
        playerPickUp = FindObjectOfType<PlayerPickUp>();
        if (playerPickUp == null)
        {

        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            if (playerPickUp == null)
            {
                
            }
            else
            {
                playerPickUp.DropObject();
            }

        }
    }
}
