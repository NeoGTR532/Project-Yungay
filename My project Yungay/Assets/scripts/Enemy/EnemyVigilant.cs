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
    public Animator anim;
    public bool Near;
    public bool DetectPlayer;
    private bool notGun;
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
            notGun = true;
        }




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



            if ((Vector3.Distance(transform.position, Target.transform.position) < 2f))
            {
                Near = true;
               Agent.enabled = false;
            
                anim.SetBool("Run", false);
                anim.SetBool("Atack", true);
            }
            else
            {
                Near = false;
                Agent.enabled = true;
                anim.SetBool("Atack", false);
            }
        }
        else
        {
            anim.SetBool("Run", false);
            DetectPlayer = false;
            Agent.enabled = false;
        }
        
    }
    public void Shoot()
    {

       /* RaycastHit hit;
        if  (Physics.Raycast (transform))*/
    }
    public void Final_anim()
    {
        if(Vector3.Distance(transform.position, Target.transform.position) >   2.2f)
        {
            anim.SetBool("Atack", false);
        }

        //Atack = false;
       
    }
 
    

}
