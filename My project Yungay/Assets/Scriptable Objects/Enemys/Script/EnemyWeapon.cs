using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy Type", menuName = "Distance Weapon")]
public class EnemyWeapon : ScriptableObject
{
    public float Range;
    public float Munition;
    public float timeToShoot;
    public float timetoRecharge;
    public GameObject[] Drop;
    public RuntimeAnimatorController anim;
}
