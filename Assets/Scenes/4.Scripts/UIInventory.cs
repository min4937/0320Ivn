using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInventory : MonoBehaviour
{
    [SerializeField] private Button backButton;
    [SerializeField] private Transform slotParent;
    [SerializeField] private UISlot slotPrefab;
    [SerializeField] private Text inventorySizeText;
    private List<UISlot> slots = new List<UISlot>();

    private void Start()
    {
        backButton.onClick.AddListener(OpenMainMenu);
        gameObject.SetActive(false);
        InitInventoryUI();
    }

    public void OpenMainMenu()
    {
        UIManager.Instance.UIMainMenu.OpenButton();
        gameObject.SetActive(false);
    }

    public void InitInventoryUI()
    {
        slots.Clear();
        foreach (Transform child in slotParent)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < GameManager.Instance.Player.Inventory.Count; i++)
        {
            Debug.Log("�����߰�");
            Debug.Log($"Creating slot {i}");
            Debug.Log($"slotPrefab: {slotPrefab}, slot: {slots}");
            UISlot slot = Instantiate(slotPrefab, slotParent);
            if (slot != null) // null üũ �߰�
            {
                if (i < GameManager.Instance.Player.Inventory.Count)
                {
                    slot.SetItem(GameManager.Instance.Player.Inventory[i]);
                }
                else
                {
                    slot.SetItem(null); // �� ���� ����
                }
                slots.Add(slot);
            }
        }

        inventorySizeText.text = $"{GameManager.Instance.Player.Inventory.Count} / 120";
    }

    public void RefreshUI()
    {
        InitInventoryUI();
    }

    public void SlotClick(Item item)
    {
        if (item == null) return;

        if (item.IsEquipped)
        {
            GameManager.Instance.Player.UnEquipItem(item);
        }
        else
        {
            GameManager.Instance.Player.EquipItem(item);
        }

        // �κ��丮 UI ����
        foreach (var slot in slots)
        {
            slot.RefreshUI();
        }
        UIManager.Instance.UIStatus.RefreshUI();
    }
}
