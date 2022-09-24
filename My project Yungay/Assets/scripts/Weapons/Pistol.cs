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
        beggin = this.transform.position;
        RaycastHit hit;
        if (munition.thereNails || munition.thereBullets)
        {
            Debug.Log("a");
            if (lastShootTime + pistol.shootDelay < Time.time)
            {
                if (munition.thereNails && ammo == false)
                {
                    munition.chargerNails -= 1;
                    sound.GetComponent<AudioSource>().PlayOneShot(pistol.shoot);
                }
                if (munition.thereBullets == true && ammo == true)
                {
                    munition.chargerBullets -= 1;
                    sound.GetComponent<AudioSource>().PlayOneShot(pistol.shoot);
                }
                if (Physics.Raycast(beggin, cam.transform.forward, out hit, pistol.range, enemyMask))
                {
                    TrailRenderer trail = Instantiate(bulletTrail, beggin, Quaternion.identity);
                    StartCoroutine(SpawnTrail(trail, hit.point));
                    if (hit.collider.CompareTag("Enemy"))
                    {
                        hit.collider.gameObject.GetComponent<EnemyHealth>().lifeE(pistol.damage);
                    }
                    lastShootTime = Time.time;
                }
                else
                {
                    TrailRenderer trail = Instantiate(bulletTrail, beggin, Quaternion.identity);

                    StartCoroutine(SpawnTrail(trail, cam.transform.forward * 100));

                    lastShootTime = Time.time;
                }
            }
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(cam.transform.position, cam.transform.forward * pistol.range);

        Gizmos.DrawRay(cam.transform.position, cam.transform.forward * 2);

    }
    private IEnumerator SpawnTrail(TrailRenderer Trail, Vector3 HitPoint)
    {
        Vector3 startPosition = Trail.transform.position;
        float distance = Vector3.Distance(Trail.transform.position, HitPoint);
        float remainingDistance = distance;

        while (remainingDistance > 0)
        {
            Trail.transform.position = Vector3.Lerp(startPosition, HitPoint, 1 - (remainingDistance / distance));

            remainingDistance -= BulletSpeed * Time.deltaTime;

            yield return null;
        }
        Trail.transform.position = HitPoint;

        Destroy(Trail.gameObject, Trail.time);
    }
}
