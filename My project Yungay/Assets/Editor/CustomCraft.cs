using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Inventory))]
public class CustomCraft : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        Inventory inventory = (Inventory)target;
        if (GUILayout.Button("CraftItem"))
        {
            inventory.CraftItem(inventory.objectToCraft);
        }
    }
}
