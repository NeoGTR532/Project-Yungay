using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PickWeapon))]
public class Spear : MonoBehaviour
{
    public GameObject modelWeapon;
    public Camera cam;
    public Weapon spear;
    public LayerMask enemyMask;
    private float lastShootTime;

    public float force;
    public CapsuleCollider capCollider;
    public BoxCollider boxTriggerUse;
    public BoxCollider boxTriggerPick;

    public string nameTransform;
    private void Awake()
    {
        GetTransform(nameTransform);

        DesactiveUseCollider();
        DesactivePickTrigger();
    }
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Shoot();
        }
    }
    private void Shoot()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, spear.range, enemyMask))
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                hit.collider.gameObject.GetComponent<EnemyHealth>().lifeE(spear.damage);
            }
            lastShootTime = Time.time;
        }
        else
        { 
            lastShootTime = Time.time;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(cam.transform.position, cam.transform.forward * spear.range);
    }
    private void GetTransform(string a)
    {
        modelWeapon = GameObject.Find(a);
    }

    public void ActiveUseCollider()
    {
        boxTriggerUse.enabled = true;
    }

    public void DesactiveUseCollider()
    {
        boxTriggerUse.enabled = false;
    }

    public void ActivePickTrigger()
    {
        boxTriggerPick.enabled = true;
    }
    public void DesactivePickTrigger()
    {
        boxTriggerPick.enabled = false;
    }
    private void OnCollisionEnter(Collision collision)
    {

        ActivePickTrigger();

        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            gameObject.tag = "Untagged";
            this.GetComponent<Rigidbody>().isKinematic = true;
            capCollider.enabled = false;
            this.enabled = false;
        }
    }
}