using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInventory : MonoBehaviour
{
    public ItemSlot[] itemSlots; // UI�� ItemSlot �迭
    [SerializeField] private Button backButton;
    private void Start()
    {
        backButton.onClick.AddListener(OpenMainMenu);
        gameObject.SetActive(false);
    }

    public void OpenMainMenu()
    {
        UIManager.Instance.UIMainMenu.OpenButton();
        gameObject.SetActive(false);
    }
    public void RefreshUI()
    {
        // �κ��丮�� ������ ������ UI�� �ݿ�
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (i < GameManager.Instance.Player.Inventory.Count)
            {
                if (GameManager.Instance.Player.Inventory[i] != null)
                {
                    itemSlots[i].AddItem(GameManager.Instance.Player.Inventory[i]);
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
