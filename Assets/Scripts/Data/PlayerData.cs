using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Data/Player Data")]
public class PlayerData : ScriptableObject
{
    [Header("Thông tin cơ bản")]
    public string playerName = "Survivor";
    public float maxHealth = 100f;
    public float maxStamina = 100f;
    public float moveSpeed = 5f;
    public Sprite portrait;

    [Header("Trạng thái khởi tạo")]
    public int startingWood = 0;
    public int startingStone = 0;
    public ItemData[] startingItems;
}
