using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CraftRecipes : ScriptableObject
{
    public List<Recipe> materials;
    public ItemObject result;
    public int amount;
}

[System.Serializable]
public class Recipe
{
    public ItemObject item;
    public int amount;
}
