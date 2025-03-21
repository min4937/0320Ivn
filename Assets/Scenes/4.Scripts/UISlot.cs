using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISlot : MonoBehaviour
{
    [SerializeField] private Image icon;
    private Item item;
    public Button button;
    public Image eImage;

    private void Start()
    {
        button.onClick.AddListener(OnSlotClicked);
    }

    public void SetItem(Item newItem)
    {
        item = newItem;
        RefreshUI();
    }

    public void RefreshUI()
    {
        Debug.Log($"RefreshUI() called, item: {item}, icon: {icon}");
        if (item != null)
        {
            icon.sprite = item.Icon;
            icon.enabled = true;
            Debug.Log($"item.IsEquipped: {item.IsEquipped}");
            if (item.IsEquipped)
            {
               eImage.gameObject.SetActive(true);
            }
            else
            {
               eImage.gameObject.SetActive(false);
            }
        }
        else
        {
            icon.sprite = null;
            icon.enabled = true;
            eImage.gameObject.SetActive(false);
        }
    }

    public void OnSlotClicked()
    {
        UIManager.Instance.UIInventory.SlotClick(item);
    }
}
