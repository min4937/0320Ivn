using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance { get; private set; }
    public ItemSlot[] itemSlots;
    private Character character;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    void Start()
    {
        if (GameManager.Instance == null)
        {
            Debug.LogError("GameManager.Instance is null!");
            return;
        }

        if (GameManager.Instance.Player == null)
        {
            Debug.LogError("GameManager.Instance.Player is null!");
            return;
        }

        character = GameManager.Instance.Player;

        // ΩΩ∑‘ ¿Œµ¶Ω∫ √ ±‚»≠
        for (int i = 0; i < itemSlots.Length; i++)
        {
            itemSlots[i].slotIndex = i;
            
            if (itemSlots[i] == null)
            {
                Debug.LogError($"ItemSlot at index {i} is null!");
            }
        }
    }

    public void EquipUnequipItem(int slotIndex)
    {
        if (slotIndex >= 0 && slotIndex < itemSlots.Length)
        {
            Item itemToEquip = character.Inventory[slotIndex];
            if (itemToEquip != null)
            {
                if (itemToEquip.IsEquipped)
                {
                    UnEquipItem(itemToEquip);
                }
                else
                {
                    EquipItem(itemToEquip);
                }
            }
        }
    }

    private void EquipItem(Item item)
    {
        if (item != null && !item.IsEquipped)
        {
            item.IsEquipped = true;
            character.ATK += item.attackBonus;
            character.DEF += item.defenseBonus;
            RefreshUI();
            UIManager.Instance.UIStatus.RefreshUI();
        }
    }

    private void UnEquipItem(Item item)
    {
        if (item != null && item.IsEquipped)
        {
            item.IsEquipped = false;
            character.ATK -= item.attackBonus;
            character.DEF -= item.defenseBonus;
            RefreshUI();
            UIManager.Instance.UIStatus.RefreshUI();
        }
    }

    public void RefreshUI()
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (itemSlots[i] != null)
            {
                if (i < itemSlots.Length)
                {
                    if (character.Inventory[i] != null)
                    {
                        itemSlots[i].AddItem(character.Inventory[i]);
                        itemSlots[i].UpdateIconColor();
                    }
                    else
                    {
                        itemSlots[i].ClearSlot();
                    }
                }
                else
                {
                    itemSlots[i].ClearSlot();
                }
            }
        }
    }
}
