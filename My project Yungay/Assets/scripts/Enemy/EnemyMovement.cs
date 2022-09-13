using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public enum EnemyType {Melee,Shooting }
     public EnemyType enemyType;

    [Header("Estadisticas del enemigo melee")]
    public float speed;
    public bool inArea;
    public GameObject Target; 
    private Rigidbody rbEnemy;
    private Vector3 rec;

    void Start()
    {
        rbEnemy = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
       
        if (enemyType == EnemyType.Melee)
        {
            EnemyMelee();

        }
        if (enemyType == EnemyType.Shooting)
        {
            EnemyShoot();
        }
       
    }
    public void EnemyMelee()
    {
        if (inArea == true && Target != null)
        {


            rec = (Target.transform.position - transform.position).normalized * speed;
            rec.y = 0;

            Vector3 vel = rbEnemy.velocity;
            vel.x = rec.x;
            vel.z = rec.z;
            rbEnemy.velocity = vel;
            transform.forward = rec.normalized;



        }

    }
    public void EnemyShoot()
    {
        //falta especificar que hace 
    }
}
