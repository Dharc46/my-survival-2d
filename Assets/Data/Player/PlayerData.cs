using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Data/PlayerData")]
public class PlayerData : ScriptableObject
{
    public string characterName = "Survivor";
    public float maxHealth = 100f;
    public float maxStamina = 100f;
    public float movementSpeed = 5f;
    public float baseDamage = 10f;
    public Sprite sprite;
}
