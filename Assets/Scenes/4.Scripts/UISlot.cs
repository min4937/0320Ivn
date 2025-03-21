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
        if (item != null)
        {
            icon.sprite = item.Icon;
            icon.enabled = true;
            // 장착 여부에 따른 UI 변경 (예시)
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
            icon.enabled = false;
            
        }
    }

    public void OnSlotClicked()
    {
        UIManager.Instance.UIInventory.SlotClick(item);
    }
}
