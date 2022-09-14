using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    [Header("General")]
    public Camera cam;
    private Vector3 beggin;
    public float distance = 100f;
    [SerializeField]
    [Range(1f, 100f)]
    private float BulletSpeed;
    [SerializeField]
    private TrailRenderer bulletTrail;
    public string weapons;
    public int stateWeapons;

    [Header("Pistola")]
    [SerializeField]
    private float LastShootTimePistol;
    [SerializeField]
    private float ShootDelayPistol;
    public AudioSource pistol;

    [Header("Subfusil")]
    [SerializeField]
    private Vector3 BulletSpreadVariance = new Vector3(0.1f, 0.1f, 0.1f);
    [SerializeField]
    private float LastShootTimeSubfusil;
    [SerializeField]
    private float ShootDelaySubfusil;
    public AudioSource subfusil;

    private void Start()
    {
        beggin = this.transform.position;
        ChangeWeapons();
    }

    private void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            Shoot();
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChangeWeapons();
        }
    }

    public void ChangeWeapons()
    {
        stateWeapons += 1;
        switch (stateWeapons)
        {
            case 1:
                weapons = "Pistola";
                break;
            case 2:
                weapons = "Subfusil";
                break;
            default:
                weapons = "Pistola";
                stateWeapons = 1;
                break;
        }
    }

    public void Shoot()
    {
        RaycastHit hit;
        switch (weapons)
        {
            case "Pistola":
                if (LastShootTimePistol + ShootDelayPistol < Time.time)
                {
                    if (Physics.Raycast(beggin, cam.transform.forward, out hit, distance))
                    {
                        TrailRenderer trail = Instantiate(bulletTrail, beggin, Quaternion.identity);
                        StartCoroutine(SpawnTrail(trail, hit.point));
                        if (hit.collider.CompareTag("Enemigo"))
                        {
                            hit.collider.gameObject.GetComponent<SacoBoxeo>().RecibirDaño(5);
                        }
                        LastShootTimePistol = Time.time;
                        pistol.Play();
                    }
                    else
                    {
                        TrailRenderer trail = Instantiate(bulletTrail, beggin, Quaternion.identity);

                        StartCoroutine(SpawnTrail(trail, cam.transform.forward * 100));

                        LastShootTimePistol = Time.time;
                    }
                }
                break;
            case "Subfusil":
                if (LastShootTimeSubfusil + ShootDelaySubfusil < Time.time)
                {
                    Vector3 direction = GetDirection();
                    if (Physics.Raycast(beggin, direction, out hit, distance))
                    {
                        TrailRenderer trail = Instantiate(bulletTrail, beggin, Quaternion.identity);
                        StartCoroutine(SpawnTrail(trail, hit.point));
                        if (hit.collider.CompareTag("Enemigo"))
                        {
                            hit.collider.gameObject.GetComponent<SacoBoxeo>().RecibirDaño(5);
                        }
                        LastShootTimeSubfusil = Time.time;
                        subfusil.Play();
                    }
                    else
                    {
                        TrailRenderer trail = Instantiate(bulletTrail, beggin, Quaternion.identity);

                        StartCoroutine(SpawnTrail(trail, cam.transform.forward * 100));

                        LastShootTimeSubfusil = Time.time;
                    }
                }
                break;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(cam.transform.position, cam.transform.forward * distance);
    }
    private Vector3 GetDirection()
    {
        Vector3 direction = cam.transform.forward;

        direction += new Vector3(
            Random.Range(-BulletSpreadVariance.x, BulletSpreadVariance.x),
            Random.Range(-BulletSpreadVariance.y, BulletSpreadVariance.y),
            Random.Range(-BulletSpreadVariance.z, BulletSpreadVariance.z)
        );

        direction.Normalize();

        return direction;
    }
    private IEnumerator SpawnTrail(TrailRenderer Trail, Vector3 HitPoint)
    {
        // This has been updated from the video implementation to fix a commonly raised issue about the bullet trails
        // moving slowly when hitting something close, and not
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