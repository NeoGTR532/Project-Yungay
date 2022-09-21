using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    [Header("General")]
    public Camera cam;
    public Inventory inventory;
    public ItemObject nailsItem;
    public ItemObject bulletsItem;
    [HideInInspector]
    public bool hasItemNails, hasItemBullets;
    private Vector3 beggin;
    private float BulletSpeed = 100f;
    [SerializeField]
    private TrailRenderer bulletTrail;
    public string weapons;
    public int stateWeapons;
    public Munition munition;
    //[HideInInspector]
    public bool lockWeapons,ammo;
    public GameObject sound;

    public bool a;

    [Header("Hook")]
    public Hook hook;
   
    public List<Weapon> armas = new List<Weapon>();

    private float lastShootTime;
    // public AudioSource pistol;

     private Vector2 BulletSpreadVariance;

    public LayerMask enemyMask;

    public GameObject modelAxe,modelHook;

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
            switch (stateWeapons)
            {
                case 0:
                    Shoot(armas[stateWeapons]);
                    hook.active = false;
                    break;
                case 1:
                    Shoot(armas[stateWeapons]);
                    hook.active = false;
                    break;
                case 2:
                    hook.active = true;
                    break;
                case 3:
                    hook.active = false;
                    break;
            }
            
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChangeWeapons();
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            StateAmmo();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            munition.RechargeAmmo();
        }
        /*
        if (isGrappling)
        {
            grapplingHook.position = Vector3.Lerp(grapplingHook.position, pointHook, speedHook * Time.deltaTime);
            timer += Time.deltaTime;
            if (timer >= maxtimer)
            {
                isGrappling = false;
                returm = true;

            }
        }
        if (!isGrappling)
        {
            grapplingHook.position = Vector3.Lerp(grapplingHook.position, handPos.transform.position, speedHook * Time.deltaTime);
            timer = 0;
            //grapplingHook.SetParent(CamPos);
            returm = false;
        }
        */
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
                modelHook.SetActive(false);
                modelAxe.SetActive(false);
                a = true;
                break;
            case 1:
                weapons = armas[stateWeapons].name;
                ammo = true;
                modelHook.SetActive(false);
                modelAxe.SetActive(false);
                a = true;
                break;
            case 2:
                weapons = "Hook";
                modelHook.SetActive(true);
                modelAxe.SetActive(false);
                a = false;
                break;
            case 3:
                weapons = "Axe";
                modelAxe.SetActive(true);
                modelHook.SetActive(false);
                a = false;
                break;
            default:
                stateWeapons = 0;
                weapons = armas[stateWeapons].name;
                modelHook.SetActive(false);
                modelAxe.SetActive(false);
                a = true;
                break;
        }
    }

    

    public void StateAmmo()
    {
        switch (stateWeapons)
        {
            case 0:
                ammo = !ammo;
                break;
            case 1:
                ammo = true;
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
                        if (munition.thereNails && ammo == false)
                        {
                            munition.chargerNails -= 1;
                            sound.GetComponent<AudioSource>().PlayOneShot(armas[stateWeapons].shoot);
                        }
                        if (munition.thereBullets == true && ammo == true)
                        {
                            munition.chargerBullets -= 1;
                            sound.GetComponent<AudioSource>().PlayOneShot(armas[stateWeapons].shoot);
                        }
                        if (Physics.Raycast(beggin, cam.transform.forward, out hit, arma.range, enemyMask))
                        {
                            TrailRenderer trail = Instantiate(bulletTrail, beggin, Quaternion.identity);
                            StartCoroutine(SpawnTrail(trail, hit.point));
                            if (hit.collider.CompareTag("Enemy"))
                            {
                                hit.collider.gameObject.GetComponent<EnemyHealth>().lifeE(arma.damage);
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
                
                break;

            case "SubmachineGun":
                if (munition.thereBullets)
                {
                    if (lastShootTime + arma.shootDelay < Time.time)
                    {
                        Vector3 direction = GetDirection();
                        munition.chargerBullets -= 1;
                        sound.GetComponent<AudioSource>().PlayOneShot(armas[stateWeapons].shoot);
                        if (Physics.Raycast(beggin, direction, out hit, arma.range, enemyMask))
                        {
                            TrailRenderer trail = Instantiate(bulletTrail, beggin, Quaternion.identity);
                            StartCoroutine(SpawnTrail(trail, hit.point));
                            if (hit.collider.CompareTag("Enemy"))
                            {
                                hit.collider.gameObject.GetComponent<EnemyHealth>().lifeE(arma.damage);
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
                break;

               
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        if (a == true)
        {
            Gizmos.DrawRay(cam.transform.position, cam.transform.forward * armas[stateWeapons].range);
        }
        else
        {
            Gizmos.DrawRay(cam.transform.position, cam.transform.forward * 2);
        }
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