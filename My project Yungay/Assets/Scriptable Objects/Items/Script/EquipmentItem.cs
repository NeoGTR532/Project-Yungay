using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EquipmentType
{
    Melee,
    Range
}
//[CreateAssetMenu(fileName = "New Equipment Item", menuName = "Inventory System/Items/Equipment")]
public class EquipmentItem : ItemObject
{
    public Mesh itemMesh;
    public Material itemMaterial;
    private void Awake()
    {
        type = ItemType.Equipment;
    }
}
