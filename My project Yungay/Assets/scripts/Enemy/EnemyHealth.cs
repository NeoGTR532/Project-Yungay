using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float life;
    public GameObject[] resources;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void lifeE(float valor)
    {
        life-=valor;
        if (life <= 0)
        {
            Destroy(gameObject);
            
            Instantiate(resources[Random.Range(0, resources.Length)], transform.position, Quaternion.identity);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Axe"))
        {
            lifeE(other.GetComponent<MeleeWeapon>().damage);
        }

        if (other.CompareTag("Knife"))
        {
            lifeE(other.GetComponent<MeleeWeapon>().damage);
        }
        if (other.CompareTag("Spear"))
        {
            lifeE(other.GetComponent<MeleeWeapon>().damage);
        }
    }
}
