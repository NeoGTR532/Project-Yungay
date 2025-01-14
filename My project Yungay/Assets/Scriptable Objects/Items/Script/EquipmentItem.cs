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
    public string itemName;
    public Mesh itemMesh;
    public Material itemMaterial;
    [HideInInspector]public EquipmentType equipmentType;
    private void Awake()
    {
        type = ItemType.Equipment;
    }
}
