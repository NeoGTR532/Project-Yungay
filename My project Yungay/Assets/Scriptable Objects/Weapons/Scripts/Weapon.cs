using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon System/Weapons")]
public class Weapon : ScriptableObject
{
    public string name;
    [HideInInspector]
    public float lastShootTime;
    public float shootDelay;
    [Range(0f,0.9f)]
    public float bulletSpreadVarianceDis;
    [HideInInspector]
    public Vector2 bulletSpreadVariance;
    public float range;
    [Range(60,0)]
    public int zoom;
    public float damage;
    public ParticleSystem spark;
    public Sprite look;
    public AudioClip shoot;

    private void Awake()
    {
        bulletSpreadVariance = new Vector2(bulletSpreadVarianceDis, bulletSpreadVarianceDis);
    }

}
