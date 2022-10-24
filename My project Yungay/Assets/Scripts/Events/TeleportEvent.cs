using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportEvent : MonoBehaviour
{
    public int id;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        EventManager.current.useLeverEvent += Teleport;
    }


    private void Teleport(int id)
    {
        player.transform.position = transform.position;
        Level1Manager.isTravel = true;
    }

    private void OnDisable()
    {
        EventManager.current.useLeverEvent -= Teleport;
    }
}
