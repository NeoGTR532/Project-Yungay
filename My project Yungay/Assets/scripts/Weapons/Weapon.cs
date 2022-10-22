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
    public int chargerNailsMax;
    public int chargerBulletsMax;
    [HideInInspector]
    public Vector2 bulletSpreadVariance;
    [Range(1f, 15f), Min(1)]
    public float zoom;
    [Range(1f, 50f), Min(1)]
    public float range;
    public float damage;
    public ParticleSystem spark;
    public Sprite look;
    public AudioClip shoot;

    private void Awake()
    {
        bulletSpreadVariance = new Vector2(bulletSpreadVarianceDis, bulletSpreadVarianceDis);
    }

}
