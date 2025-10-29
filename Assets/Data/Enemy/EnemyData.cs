using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Data/EnemyData")]
public class EnemyData : ScriptableObject
{
    public string enemyID;
    public string enemyName;
    public Sprite sprite;
    public float health = 50f;
    public float damage = 8f;
    public float attackSpeed = 1f;
    public float movementSpeed = 3f;
    public float detectionRadius = 8f;
    public float attackRange = 1.2f;
}
