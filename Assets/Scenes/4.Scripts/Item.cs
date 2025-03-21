using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public int ATK { get; private set; }
    public int DEF { get; private set; }
    public Sprite Icon { get; private set; }
    public bool IsEquipped { get; set; }

    public void SetData(string name, string description, int atk, int def, Sprite icon)
    {
        Name = name;
        Description = description;
        ATK = atk;
        DEF = def;
        Icon = icon;        
    }
}
