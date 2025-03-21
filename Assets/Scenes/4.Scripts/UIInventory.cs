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
            Debug.Log("슬롯추가");
            Debug.Log($"Creating slot {i}");
            Debug.Log($"slotPrefab: {slotPrefab}, slot: {slots}");
            UISlot slot = Instantiate(slotPrefab, slotParent);
            if (slot != null) // null 체크 추가
            {
                if (i < GameManager.Instance.Player.Inventory.Count)
                {
                    slot.SetItem(GameManager.Instance.Player.Inventory[i]);
                }
                else
                {
                    slot.SetItem(null); // 빈 슬롯 설정
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

        // 인벤토리 UI 갱신
        foreach (var slot in slots)
        {
            slot.RefreshUI();
        }
        UIManager.Instance.UIStatus.RefreshUI();
    }
}
