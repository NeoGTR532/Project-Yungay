using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment Range Item", menuName = "Inventory System/Items/Equipment/Range")]
public class EquipmentRange : EquipmentItem
{
    [HideInInspector]
    public float lastShootTime;
    public float shootDelay;
    [Range(0f, 0.9f)]
    public float bulletSpreadVarianceDis;
    public int chargerNailsMax;
    public int chargerBulletsMax;
    [HideInInspector]
    public Vector2 bulletSpreadVariance;
    [Range(0f, 3f)]
    public float range;
    public float damage;
    public ParticleSystem spark;
    public Sprite look;
    public AudioClip shoot;

    private void Awake()
    {
        equipmentType = EquipmentType.Range;
        bulletSpreadVariance = new Vector2(bulletSpreadVarianceDis, bulletSpreadVarianceDis);
    }
}
