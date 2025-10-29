using UnityEngine;

public enum ItemType { Resource, Consumable, Weapon, Tool }

[CreateAssetMenu(fileName = "ItemData", menuName = "Data/Item Data")]
public class ItemData : ScriptableObject
{
    [Header("Thông tin cơ bản")]
    public string itemID;
    public string itemName;
    public Sprite icon;
    public ItemType itemType;
    public string description;

    [Header("Giá trị")]
    public int maxStack = 99;
    public float attackPower;       // nếu là vũ khí
    public float healAmount;        // nếu là thức ăn

    public bool isCraftable;
}
