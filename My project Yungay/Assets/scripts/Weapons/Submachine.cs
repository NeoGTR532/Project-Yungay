using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Submachine : MonoBehaviour
{
    public Camera cam;
    private Vector3 beggin;

    public Weapon submachine;

    private float BulletSpeed = 100f;

    [SerializeField]
    private TrailRenderer bulletTrail;

    public Munition munition;

    public bool lockWeapons,ammo;

    private float lastShootTime;

    private Vector2 BulletSpreadVariance;

    public GameObject sound;

    public GameObject look;

    public LayerMask enemyMask;
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

        if (Input.GetKeyDown(KeyCode.R))
        {
            munition.RechargeAmmo();
        }
    }
    public void Shoot()
    {
        beggin = cam.transform.position;
        RaycastHit hit;
        if (munition.thereBullets)
        {
            if (lastShootTime + submachine.shootDelay < Time.time)
            {
                Vector3 direction = GetDirection();
                munition.chargerBullets -= 1;
                sound.GetComponent<AudioSource>().PlayOneShot(submachine.shoot);
                if (Physics.Raycast(beggin, direction, out hit, submachine.range, enemyMask))
                {
                    if (hit.collider.CompareTag("Enemy"))
                    {
                        hit.collider.gameObject.GetComponent<EnemyHealth>().lifeE(submachine.damage);
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

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(cam.transform.position, cam.transform.forward);
        
    }

    private Vector3 GetDirection()
    {
        Vector3 direction = cam.transform.forward;
        float z = 0;
        direction += new Vector3(
            Random.Range(-BulletSpreadVariance.x, BulletSpreadVariance.x),
            Random.Range(-BulletSpreadVariance.y, BulletSpreadVariance.y),
            z
        );

        direction.Normalize();

        return direction;
    }

}
