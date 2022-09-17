using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    [Header("General")]
    public Camera cam;
    private Vector3 beggin;
    private float BulletSpeed = 100f;
    [SerializeField]
    private TrailRenderer bulletTrail;
    public string weapons;
    public int stateWeapons;
    public Munition munition;
    [HideInInspector]
    public bool lockWeapons,stateAmmo;

    public List<Weapon> armas = new List<Weapon>();

    private float lastShootTime;
    // public AudioSource pistol;

     private Vector2 BulletSpreadVariance;
    
    private void Start()
    {
        stateWeapons = -1;
        ChangeWeapons();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            munition.CheckAmmo();
            Shoot(armas[stateWeapons]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChangeWeapons();
        }
    }

    public void ChangeWeapons()
    {
        if (lockWeapons == false)
        {
            stateWeapons += 1;
        }
        switch (stateWeapons)
        {
            case 0:
                weapons = armas[stateWeapons].name;
                break;
            case 1:
                weapons = armas[stateWeapons].name;
                break;
            default:
                stateWeapons = 0;
                weapons = armas[stateWeapons].name;
                break;
        }
    }

    public void Shoot(Weapon arma)
    {
        beggin = this.transform.position;
        arma = armas[stateWeapons];
        BulletSpreadVariance = new Vector3(armas[stateWeapons].bulletSpreadVarianceDis, armas[stateWeapons].bulletSpreadVarianceDis);

        RaycastHit hit;
        switch (weapons)
        {
            case "Pistol":
                if (munition.thereNails || munition.thereBullets)
                {
                    Debug.Log("a");
                    if (lastShootTime + arma.shootDelay < Time.time)
                    {
                        if (Physics.Raycast(beggin, cam.transform.forward, out hit, arma.range))
                        {
                            if (munition.thereNails)
                            {
                                munition.nails -= 1;
                            }
                            if (munition.thereBullets == true && munition.thereNails == false)
                            {
                                munition.bullets -= 1;
                            }
                            TrailRenderer trail = Instantiate(bulletTrail, beggin, Quaternion.identity);
                            StartCoroutine(SpawnTrail(trail, hit.point));
                            if (hit.collider.CompareTag("Enemigo"))
                            {
                                hit.collider.gameObject.GetComponent<SacoBoxeo>().RecibirDaño(arma.damage);
                            }
                            lastShootTime = Time.time;
                            //pistol.Play();
                        }
                        else
                        {
                            TrailRenderer trail = Instantiate(bulletTrail, beggin, Quaternion.identity);

                            StartCoroutine(SpawnTrail(trail, cam.transform.forward * 100));

                            lastShootTime = Time.time;
                        }
                    }
                }
                
                break;

            case "SubmachineGun":
                if (munition.thereBullets)
                {
                    if (lastShootTime + arma.shootDelay < Time.time)
                    {
                        Vector3 direction = GetDirection();
                        if (Physics.Raycast(beggin, direction, out hit, arma.range))
                        {
                            munition.bullets -= 1;
                            TrailRenderer trail = Instantiate(bulletTrail, beggin, Quaternion.identity);
                            StartCoroutine(SpawnTrail(trail, hit.point));
                            if (hit.collider.CompareTag("Enemigo"))
                            {
                                hit.collider.gameObject.GetComponent<SacoBoxeo>().RecibirDaño(arma.damage);
                            }
                            lastShootTime = Time.time;
                            //pistol.Play();
                        }
                        else
                        {
                            TrailRenderer trail = Instantiate(bulletTrail, beggin, Quaternion.identity);

                            StartCoroutine(SpawnTrail(trail, cam.transform.forward * 100));

                            lastShootTime = Time.time;
                        }

                    }
                }
                break;
               
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(cam.transform.position, cam.transform.forward * armas[stateWeapons].range);
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