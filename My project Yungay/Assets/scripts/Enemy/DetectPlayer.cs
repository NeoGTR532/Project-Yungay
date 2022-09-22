using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : MonoBehaviour
{
    //public EnemyMovement Player;

    public Animator ani;
    public EnemyMovement1 Enemy;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ani.SetBool("Walk", false);
            ani.SetBool("Run",false);
            ani.SetBool("Atack", true);
            Enemy.atack = true;
            GetComponent<CapsuleCollider>().enabled = false;
        }
    }
    /*private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Player.inArea = false;
            

        }

    }*/

}
