using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Data/Enemy Data")]
public class EnemyData : ScriptableObject
{
    public string enemyName;
    public Sprite sprite;
    public float health = 50f;
    public float attackDamage = 10f;
    public float moveSpeed = 3f;
    public float attackRange = 1.2f;

    [Header("Phần thưởng khi bị tiêu diệt")]
    public ItemData[] dropItems;
    public int minDropCount = 1;
    public int maxDropCount = 3;
}
