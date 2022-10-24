using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Submachine : MonoBehaviour
{
    public Camera cam;
    public GameObject beggin;

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
            //munition.RechargeAmmo();
        }
    }
    public void Shoot()
    {
        RaycastHit hit;
        if (munition.thereBullets)
        {
            if (lastShootTime + submachine.shootDelay < Time.time)
            {
                Vector3 direction = GetDirection();
                munition.chargerBullets -= 1;
                sound.GetComponent<AudioSource>().PlayOneShot(submachine.shoot);
                if (Physics.Raycast(beggin.transform.position, direction, out hit, submachine.range, enemyMask))
                {
                    TrailRenderer trail = Instantiate(bulletTrail, beggin.transform.position, Quaternion.identity);
                    StartCoroutine(SpawnTrail(trail, hit.point));
                    if (hit.collider.CompareTag("Enemy"))
                    {
                        hit.collider.gameObject.GetComponent<EnemyHealth>().lifeE(submachine.damage);
                    }
                    lastShootTime = Time.time;

                }
                else
                {
                    TrailRenderer trail = Instantiate(bulletTrail, beggin.transform.position, Quaternion.identity);
                    StartCoroutine(SpawnTrail(trail, cam.transform.forward * submachine.range));
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
