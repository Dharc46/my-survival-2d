using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [Header("Thiết lập kho đồ")]
    public int maxSlots = 20;

    [SerializeField]
    private List<InventorySlot> slots = new List<InventorySlot>();

    public delegate void OnInventoryChanged();
    public event OnInventoryChanged onInventoryChangedCallback;

    public bool AddItem(ItemData item, int amount)
    {
        foreach (var slot in slots)
        {
            if (slot.item == item && slot.amount < item.maxStack)
            {
                slot.amount += amount;
                onInventoryChangedCallback?.Invoke();
                return true;
            }
        }

        if (slots.Count >= maxSlots)
        {
            Debug.Log("Kho đồ đầy!");
            return false;
        }

        slots.Add(new InventorySlot(item, amount));
        onInventoryChangedCallback?.Invoke();
        return true;
    }

    public bool RemoveItem(ItemData item, int amount)
    {
        foreach (var slot in slots)
        {
            if (slot.item == item)
            {
                slot.amount -= amount;
                if (slot.amount <= 0)
                    slots.Remove(slot);

                onInventoryChangedCallback?.Invoke();
                return true;
            }
        }
        return false;
    }

    public bool HasItem(ItemData item, int requiredAmount)
    {
        foreach (var slot in slots)
        {
            if (slot.item == item && slot.amount >= requiredAmount)
                return true;
        }
        return false;
    }

    public List<InventorySlot> GetAllSlots()
    {
        return slots;
    }
}
