using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{
    public Slider healthBar;
    public PlayerStateManager player;

    void Start()
    {
        if (player != null && player.playerData != null)
        {
            healthBar.maxValue = player.playerData.maxHealth;
            healthBar.value = player.currentHealth;
        }
    }

    void Update()
    {
        if (player != null && player.playerData != null)
        {
            healthBar.value = player.currentHealth;
        }
    }
}
