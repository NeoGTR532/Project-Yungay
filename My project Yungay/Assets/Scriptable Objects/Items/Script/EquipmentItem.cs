using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EquipmentType
{
    Melee,
    Range,
    Default
}
[CreateAssetMenu(fileName = "New Equipment Item", menuName = "Inventory System/Items/Equipment")]
public class EquipmentItem : ItemObject
{
    public float damage;
    public RuntimeAnimatorController controller;
    private void Awake()
    {
        type = ItemType.Equipment;
    }
}
