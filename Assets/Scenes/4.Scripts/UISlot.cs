using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour, IPointerClickHandler
{
    public Image icon;

    public Item item;
    public Image eImage;
    public int slotIndex; // ΩΩ∑‘¿« ¿Œµ¶Ω∫

    public void AddItem(Item newItem)
    {
        item = newItem;
        icon.sprite = item.itemIcon;
        icon.enabled = true;

        UpdateIconColor();
    }

    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;

        UpdateIconColor();
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        if (item != null)
        {
            Inventory.Instance.EquipUnequipItem(slotIndex);
        }
        UpdateIconColor();
    }


    public void UpdateIconColor()
    {
        if (item != null && item.IsEquipped)
        {
            eImage.gameObject.SetActive(true);
        }
        else
        {
            eImage.gameObject.SetActive(false);
        }
    }
}
