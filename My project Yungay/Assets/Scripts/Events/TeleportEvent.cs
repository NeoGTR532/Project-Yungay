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
        player = GameObject.FindGameObjectWithTag("Player");
    }


    private void Teleport(int id)
    {
        StartCoroutine(Teleporting());
        Level1Manager.isTravel = true;
    }

    private void OnDisable()
    {
        EventManager.current.useLeverEvent -= Teleport;
    }

    IEnumerator Teleporting()
    {
        yield return new WaitForSeconds(2f);
        player.transform.position = transform.position;
        
    }
}
