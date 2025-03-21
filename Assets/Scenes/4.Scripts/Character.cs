using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class Character
{
    public string Name { get; private set; }
    public int Level { get; private set; }
    public int Gold { get; private set; }
    public int HP { get; private set; }    
    public int ATK { get; private set; }
    public int DEF { get; private set; }
    public int Critical { get; private set; } // 추가
    public int EXP { get; private set; } // 추가
    public int MaxEXP { get; private set; } // 추가
    public List<Item> Inventory { get; private set; }

    public Character(string name, int level, int gold, int hp, int atk, int def, int critical, int exp, int maxExp)
    {
        Name = name;
        Level = level;
        Gold = gold;
        HP = hp;        
        ATK = atk;
        DEF = def;
        Critical = critical;
        EXP = exp;
        MaxEXP = maxExp;
        Inventory = new List<Item>(9);
    }

    public void AddItem(Item item)
    {
        Inventory.Add(item);
    }

    public void EquipItem(Item item)
    {
        if (item != null && !item.IsEquipped)
        {
            item.IsEquipped = true;
            ATK += item.ATK;
            DEF += item.DEF;
            UIManager.Instance.UIStatus.RefreshUI();
            UIManager.Instance.UIInventory.RefreshUI();
        }
    }

    public void UnEquipItem(Item item)
    {
        if (item != null && item.IsEquipped)
        {
            item.IsEquipped = false;
            ATK -= item.ATK;
            DEF -= item.DEF;
            UIManager.Instance.UIStatus.RefreshUI();
            UIManager.Instance.UIInventory.RefreshUI();
        }
    }

    public void GainEXP(int amount) // 추가
    {
        EXP += amount;
        while (EXP >= MaxEXP)
        {
            LevelUp();
            EXP -= MaxEXP;
            MaxEXP += 4; 
        }
        UIManager.Instance.UIMainMenu.SetCharacterInfo(); // UI 업데이트
    }

    private void LevelUp() 
    {
        Level++;
        ATK += 2; 
        DEF += 1;
        HP += 10;        
        UIManager.Instance.UIStatus.RefreshUI(); // UI 업데이트
        UIManager.Instance.UIMainMenu.SetCharacterInfo();
    }
}
