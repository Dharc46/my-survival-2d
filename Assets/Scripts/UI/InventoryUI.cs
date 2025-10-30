using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public Inventory inventory;              // kéo Inventory component của Player vào đây
    public GameObject slotPrefab;            // kéo InventorySlotPrefab vào đây
    public Transform slotParent;             // SlotParent (GridLayoutGroup)
    private List<GameObject> uiSlots = new List<GameObject>();

    void Start()
    {
        if (inventory == null)
        {
            Debug.LogWarning("InventoryUI: inventory chưa được gán.");
            return;
        }

        // Đăng ký callback để update khi inventory thay đổi
        inventory.onInventoryChangedCallback += RefreshUI;

        // Khởi tạo UI lần đầu
        RefreshUI();
    }

    public void RefreshUI()
    {
        // Xóa UI cũ
        foreach (var go in uiSlots) Destroy(go);
        uiSlots.Clear();

        // Lấy danh sách slot từ inventory
        var slots = inventory.GetAllSlots();
        if (slots == null) return;

        foreach (var s in slots)
        {
            var inst = Instantiate(slotPrefab, slotParent);
            uiSlots.Add(inst);

            // Tìm child components (Image + Text)
            var icon = inst.transform.Find("Icon")?.GetComponent<Image>();
            var countText = inst.transform.Find("CountText")?.GetComponent<Text>();

            if (icon != null)
            {
                icon.sprite = s.item != null ? s.item.icon : null;
                icon.enabled = s.item != null;
            }

            if (countText != null)
            {
                countText.text = s.amount > 1 ? s.amount.ToString() : "";
            }
        }
    }

    private void OnDestroy()
    {
        if (inventory != null)
            inventory.onInventoryChangedCallback -= RefreshUI;
    }
}
