using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float life;
    public List<ItemObject> items = new();
    private Animator anim;
    public  float timer;
    public bool dead;
    private Loot enemyLoot;
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
            if (enemyLoot?true:false)
            {
                enemyLoot.Delete();
            }
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
            enemyLoot = gameObject.AddComponent<Loot>();
            RandomLoot();
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

    private void RandomLoot()
    {
        for (int i = 0; i < (int)Random.Range(0,items.Count); i++)
        {
            enemyLoot.loot.Add(new Item(null,0));
            enemyLoot.loot[i].item = items[i];
        }
        enemyLoot.RandomAmount();
    }
}
