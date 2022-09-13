using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public enum Enemy
    {
        melee, shooting
    }
    public Enemy enemyType;
    public PlayerModel player;
    public float timer;
    public float maxtimer;
    public bool Atack;
    
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if (Atack)
        {
            timer += Time.deltaTime;
            if (timer >= maxtimer)
            {
                Atack = false;
                timer = 0;
            }
        }
    }
    public void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") & !Atack)
        {
            player.health = player.health - 1;
            Atack = true;
        }
       
    }
    

}
