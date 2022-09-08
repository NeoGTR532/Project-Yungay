using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma : MonoBehaviour
{
    public Camera cam;
    private Vector3 beggin;
    [Range(1,100)]
    public float distance;
    [SerializeField]
    private TrailRenderer bulletrail;

    private void Start()
    {
        beggin = cam.transform.position;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        RaycastHit hit;

        if(Physics.Raycast(beggin,cam.transform.forward,out hit,distance))
        {
            TrailRenderer trail = Instantiate(bulletrail, beggin, Quaternion.identity);

            if(hit.collider.CompareTag("Enemigo"))
            {
                hit.collider.gameObject.GetComponent<SacoBoxeo>().RecibirDaño(5);
            }
            Debug.DrawRay(cam.transform.position, cam.transform.forward, Color.red);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(cam.transform.position, cam.transform.forward* distance);
    }
}
