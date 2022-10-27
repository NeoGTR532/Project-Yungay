using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickWeapon : MonoBehaviour
{
    Rigidbody rdbd;

    private void Start()
    {
        rdbd = GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        rdbd.isKinematic = true;
    }
}
