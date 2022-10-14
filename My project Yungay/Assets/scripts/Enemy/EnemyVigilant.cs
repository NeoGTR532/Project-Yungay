using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyVigilant : MonoBehaviour
{
    public GameObject Target;
    public  NavMeshAgent Agent;
    public float speed;
    public EnemyWeapon Weapon;
    public float Vision;
    private Animator anim;
    public bool Near;
    public bool DetectPlayer;
    
    void Start()
    {
        Agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Weapon != null)
        {
            ToPlayerWithWeapon();
        }
        else
        {

            ToPlayWithouthWeapon();
           if (Near)
            {
                anim.SetBool("Atack", true);
            }

        }

        //ToPlayerWithWeapon();


    }
    public void ToPlayerWithWeapon()
    {
        if (Vector3.Distance(transform.position, Target.transform.position) < Vision)
        {
            var lookpos = Target.transform.position - transform.position;
            lookpos.y = 0;
            var rotation = Quaternion.LookRotation(lookpos);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 5f * Time.deltaTime);
            Agent.enabled = true;
            Agent.SetDestination(Target.transform.position);
            Agent.speed = speed;
            DetectPlayer = true;
            //anim.SetBool("Run", true);
        }
        else
        {
            DetectPlayer = false;
        }
    }
    public void ToPlayWithouthWeapon()
    {
        if (Vector3.Distance(transform.position, Target.transform.position) < Vision)
        {
            var lookpos = Target.transform.position - transform.position;
            lookpos.y = 0;
            var rotation = Quaternion.LookRotation(lookpos);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 5f * Time.deltaTime);
            Agent.enabled = true;
            Agent.SetDestination(Target.transform.position);
            Agent.speed = speed;
            DetectPlayer = true;
            anim.SetBool("Run", true);
        }
        else
        {
            DetectPlayer = false;
        }
    }
    public void Shoot()
    {
       

    }
    public void Final_ani()
    {
        //if
    }
 
    

}
