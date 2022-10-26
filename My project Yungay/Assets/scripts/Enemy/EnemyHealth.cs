using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float life;
    public GameObject[] resources;
    private Animator anim;
    public  float timer;
    public bool dead;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (dead)
        {
            timer += Time.deltaTime;
            if (timer > 5f)
            {
                Destroy(gameObject);
            }
        }
    }
    public void lifeE(float valor)
    {
        life-=valor;
        if (life <= 0 && !dead)
        {
            dead = true;
            anim.Play("Dead");
 
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        EquipmentMelee _ = (EquipmentMelee)Hand.currentItem;
        if (other.CompareTag("Axe") || other.CompareTag("Knife") || other.CompareTag("Spear"))
        {
            lifeE(_.damage);
        }
    }
}
