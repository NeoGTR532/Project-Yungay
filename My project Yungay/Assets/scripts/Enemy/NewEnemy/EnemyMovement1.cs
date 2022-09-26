using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement1 : MonoBehaviour
{ 
    //Variables de rutina del enemigo
    public int rutine;
    public float timer;
    private Animator anim;
    private Quaternion angule;
    private float grade;
    public float speedWalk;
    //Variables para detectar al Player
    public GameObject target;
    public float RunSpeed;
    public bool atack;

    public DetectPlayer Range;
    //NavMesh variables
    public NavMeshAgent agent;
    public float AtackDistance;
    public float Vision;

    //
    public LayerMask layerWall;
    public bool inContact;


    
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
      
        
            RutineEnemy();
        
        
    }
    public void RutineEnemy()
    {
        if (Vector3.Distance(transform.position, target.transform.position) > Vision)
        {

            anim.SetBool("Run", false);
            
            timer += 1 * Time.deltaTime;
            if (timer >= 2)
            {
                rutine = Random.Range(0, 2);
                timer = 0;
            }
            switch (rutine)
            {
                case 0:
                    anim.SetBool("Walk", false);
                    break;
                case 1:
                    grade = Random.Range(0, 360);
                    angule = Quaternion.Euler(0, grade, 0);
                    rutine++;
                    break;
                case 2:
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, angule, 3f);
                    transform.Translate(Vector3.forward * speedWalk * Time.deltaTime);
                    anim.SetBool("Walk", true);
                    break;



            }
        }
        else
        {
            var lookpos = target.transform.position - transform.position  ;
            lookpos.y = 0;
            var rotation = Quaternion.LookRotation(lookpos);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 5f * Time.deltaTime);
            agent.enabled = true;
            agent.SetDestination(target.transform.position);
            if (Vector3.Distance (transform.position,target.transform.position)>AtackDistance && !atack)
            {
                anim.SetBool("Walk", false);
                anim.SetBool("Run", true);
            }
            else
            {
                 if (!atack)
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 1);
                    anim.SetBool("Walk", false);
                    anim.SetBool("Run", false);
                }
            }
            /*if (Vector3.Distance(transform.position, target.transform.position) > 1.4 && !atack)
          {

              transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 3);
              anim.SetBool("Walk", false);
              anim.SetBool("Run", true);
              transform.Translate(Vector3.forward * RunSpeed * Time.deltaTime);
              anim.SetBool("Atack", false);
          }
          else
          {
              transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 3);
              anim.SetBool("Walk", false);
              anim.SetBool("Run", false);


          }*/
        }
        if (atack)
        {
            agent.enabled = false;
        }
    }
    public void Final_Ani()
    {
        if (Vector3.Distance(transform.position,target.transform.position)>AtackDistance+0.2f)
        {
            anim.SetBool("Atack", false);
        }
        
        atack = false;
        Range.GetComponent<CapsuleCollider>().enabled = true;
    }
   
    
}
