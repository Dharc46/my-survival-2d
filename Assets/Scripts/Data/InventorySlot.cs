using UnityEngine;

[System.Serializable]   // ← chỉ giữ đúng 1 dòng này
public class InventorySlot
{
    public ItemData item;
    public int amount;

    public InventorySlot(ItemData item, int amount)
    {
        this.item = item;
        this.amount = amount;
    }
}
