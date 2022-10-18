using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy Type", menuName = "Enemy Weapon")]
public class EnemyWeapon : ScriptableObject
{
    public float damage;
    public float Range;
    public float Munition;
    public float charger;
    public float timeToShoot;
    public float timetoRecharge;
    public GameObject[] Drop;
    //public RuntimeAnimatorController anim;
}
