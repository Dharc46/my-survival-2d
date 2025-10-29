using UnityEngine;

[System.Serializable]
public class Ingredient
{
    public ItemData item;
    public int amount;
}

[CreateAssetMenu(fileName = "CraftingRecipe", menuName = "Data/Crafting Recipe")]
public class CraftingRecipe : ScriptableObject
{
    [Header("Nguyên liệu chế tạo")]
    public Ingredient[] ingredients;

    [Header("Kết quả")]
    public ItemData resultItem;
    public int resultCount = 1;

    [Header("Thời gian chế tạo (giây)")]
    public float craftTime = 2f;
}
