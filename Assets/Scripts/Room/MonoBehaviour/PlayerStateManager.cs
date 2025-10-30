using UnityEngine;

public class PlayerStateManager : EntityStateManager
{
    private PlayerIdleState _idleState;
    private PlayerWalkState _walkState;
    private PlayerShiftState _shiftState;
    private PlayerSwingSwordState _swingSwordState;

    public PlayerIdleState IdleState { get => _idleState; }
    public PlayerWalkState WalkState { get => _walkState; }
    public PlayerShiftState ShiftState { get => _shiftState; }
    public PlayerSwingSwordState SwingSwordState { get => _swingSwordState; }

    private void Awake()
    {
        _idleState = new PlayerIdleState(this);
        _walkState = new PlayerWalkState(this);
        _shiftState = new PlayerShiftState(this);
        _swingSwordState = new PlayerSwingSwordState(this);
    }

    protected override void Start()
    {
        base.Start();
        Doorway.ShiftRoomEvent += OnShiftRoom;
        TransitionToState(IdleState);

        InitializePlayerStats();
    }

    private void OnShiftRoom(Doorway door)
    {
        TransitionToState(ShiftState);
    }

    public void TakeDamage()
    {
        Debug.Log("player hit by NPC");
    }

    // ==========================
    // PLAYER DATA & STATS
    // ==========================

    [Header("Player Stats")]
    public PlayerData playerData;  // ScriptableObject
    public float currentHealth;
    public Inventory inventory;    // Component quản lý item

    private void InitializePlayerStats()
    {
        if (playerData != null)
            currentHealth = playerData.maxHealth;
        else
            currentHealth = 100f; // fallback mặc định

        // Lấy Inventory gắn kèm (hoặc tự thêm)
        inventory = GetComponent<Inventory>();
        if (inventory == null)
            inventory = gameObject.AddComponent<Inventory>();
    }

    // ==========================
    // HEALTH SYSTEM
    // ==========================

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }

        Debug.Log($"Player took {damage} damage. HP = {currentHealth}/{playerData.maxHealth}");
    }

    public void Heal(float amount)
    {
        currentHealth = Mathf.Min(currentHealth + amount, playerData.maxHealth);
        Debug.Log($"Player healed {amount}. HP = {currentHealth}/{playerData.maxHealth}");
    }

    private void Die()
    {
        Debug.Log("Player died!");
        // TODO: thêm animation chết, respawn, Game Over, v.v.
    }

    // ==========================
    // INVENTORY SHORTCUTS
    // ==========================

    public void PickupItem(ItemData item, int amount)
    {
        bool added = inventory.AddItem(item, amount);
        if (added)
            Debug.Log($"Đã nhặt {amount}x {item.itemName}");
    }

    public void UseItem(ItemData item)
    {
        if (item.itemType == ItemType.Consumable)
        {
            Heal(item.healAmount);
            inventory.RemoveItem(item, 1);
            Debug.Log($"Đã sử dụng {item.itemName}");
        }
        else
        {
            Debug.Log($"{item.itemName} không thể dùng trực tiếp.");
        }
    }
}
