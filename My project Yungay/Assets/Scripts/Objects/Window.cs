using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Window : MonoBehaviour
{
    public GameObject windowPieces;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        Instantiate(windowPieces, transform.position, Quaternion.identity);
        Destroy(this.gameObject);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            Instantiate(windowPieces, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }


    }
}
