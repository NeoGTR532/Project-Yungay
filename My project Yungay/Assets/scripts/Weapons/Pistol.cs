using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    public Camera cam;
    private Vector3 beggin;

    public Weapon pistol;

    private float BulletSpeed = 100f;

    [SerializeField]
    private TrailRenderer bulletTrail;

    public Munition munition;

    public bool lockWeapons, ammo;

    private float lastShootTime;

    public GameObject sound;

    public LayerMask enemyMask;
    public GameObject look;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0))
        {
            Shoot();
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            StateAmmo();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            munition.RechargeAmmo();
        }
    }
    public void StateAmmo()
    {
        ammo = !ammo;
    }
    public void Shoot()
    {
        beggin = cam.transform.position;
        RaycastHit hit; 
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (munition.thereNails || munition.thereBullets)
        {
            if (lastShootTime + pistol.shootDelay < Time.time)
            {
                if (munition.thereNails && ammo == false)
                {
                    munition.chargerNails -= 1;
                    sound.GetComponent<AudioSource>().PlayOneShot(pistol.shoot);
                    if (Physics.Raycast(ray, out hit, pistol.range, enemyMask))
                    {
                        if (hit.collider.CompareTag("Enemy"))
                        {
                            hit.collider.gameObject.GetComponent<EnemyHealth>().lifeE(pistol.damage);
                        }
                        lastShootTime = Time.time;
                    }
                    else
                    {

                        lastShootTime = Time.time;
                    }
                }
                if (munition.thereBullets == true && ammo == true)
                {
                    munition.chargerBullets -= 1;
                    sound.GetComponent<AudioSource>().PlayOneShot(pistol.shoot);
                    if (Physics.Raycast(ray, out hit, pistol.range, enemyMask))
                    {
                        if (hit.collider.CompareTag("Enemy"))
                        {
                            hit.collider.gameObject.GetComponent<EnemyHealth>().lifeE(pistol.damage);
                        }
                        lastShootTime = Time.time;
                    }
                    else
                    {
                        lastShootTime = Time.time;
                    }
                }
            }
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(cam.transform.position, cam.transform.forward * pistol.range);

    }
}
