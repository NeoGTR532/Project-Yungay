using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Window : MonoBehaviour
{
    public int windowId;
    public GameObject windowPieces;
    // Start is called before the first frame update
    void Start()
    {
        EventManager.current.brokeWindowEvent += BreakWindow;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void BreakWindow(int id)
    {
        if (id == windowId)
        {
            Instantiate(windowPieces, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Axe") || other.CompareTag("Spear"))
        {
            EventManager.current.StartBreakingWindowEvent(windowId);
        }
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.tag != "Player")
    //    {
    //        BreakWindow(windowId);
    //    }


    //}

    private void OnDestroy()
    {
        EventManager.current.brokeWindowEvent -= BreakWindow;
    }
}
