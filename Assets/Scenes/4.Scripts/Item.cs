using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public string itemName;
    public string itemDescription;
    public int attackBonus;
    public int defenseBonus;
    public Sprite itemIcon;
    public bool IsEquipped { get; set; }
}
