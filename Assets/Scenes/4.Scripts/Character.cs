using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class Character
{
    public string Name { get; private set; }
    public int Level { get; private set; }
    public int Gold { get; private set; }
    public int HP { get; set; } 
    public int ATK { get; set; } 
    public int DEF { get; set; } 
    public int Critical { get; private set; }
    public int EXP { get; set; } 
    public int MaxEXP { get; private set; }
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
        Inventory = new List<Item>(9); // 크기가 9인 리스트로 초기화
        for (int i = 0; i < 9; i++)
        {
            Inventory.Add(null); 
        }
    }

    public void GainEXP(int amount)
    {
        EXP += amount;
        while (EXP >= MaxEXP)
        {
            LevelUp();
            EXP -= MaxEXP;
            MaxEXP += 4;
        }
        UIManager.Instance.UIMainMenu.SetCharacterInfo();
    }

    private void LevelUp()
    {
        Level++;
        ATK += 2;
        DEF += 1;
        HP += 10;
        UIManager.Instance.UIStatus.RefreshUI();
        UIManager.Instance.UIMainMenu.SetCharacterInfo();
    }
}
